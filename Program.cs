using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OfficeOpenXml;
using System.Xml.Linq;

namespace WPF1
{
    internal class Program
    {
        private const string Space = " ";
        private const string Dot = ".";
        private const string Semicolon = ";";
        private const string Dash = "-";
        private const string Percent = "%";

        private const string UsersWord = "Users";
        private const string UserWord = "User";
        private const string IdWord = "ID";
        private const string DateWord = "Date";
        private const string FirstNameWord = "FirstName";
        private const string LastNameWord = "LastName";
        private const string PatronymicWord = "Patronymic";
        private const string CityWord = "City";
        private const string CountryWord = "Country";
        private const string WorksheetWord = "Лист1";

        private List<User> _listOfUsersFromFile = new List<User>();
        internal List<User> ListOfUsersFromDB = new List<User>();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        /// <summary>
        /// Асинхронный метод чтения данных из CSV файла.
        /// </summary>
        /// <param name="fileName"> Имя файла для чтения. </param>
        /// <returns></returns>
        public async Task ReadFromCsvFileAsync(string fileName)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    string stringFromFile;
                    string[] dataFromString = new string[5];
                    User user;
                    while ((stringFromFile = await streamReader.ReadLineAsync()) != null)
                    {
                        dataFromString = stringFromFile.Split(Semicolon);
                        user = new User(dataFromString);
                        _listOfUsersFromFile.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Выбранный файл невозможно открыть. Возможно он поврежден.");
            }
        }

        /// <summary>
        /// Асинхронный метод записи выборки из БД в Excel файл.
        /// </summary>
        /// <param name="excelFileName"> Имя создаваемого файла. </param>
        /// <returns></returns>
        public async Task WriteIntoExcelFileAsync(string excelFileName)
        {
            try
            {
                if (ListOfUsersFromDB.IsNullOrEmpty())
                    throw new Exception("Выборка не была осуществена!");

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    excelPackage.Workbook.Worksheets.Add(WorksheetWord);

                    var headerRow = new List<string[]>() { new string[] { IdWord, DateWord, FirstNameWord, LastNameWord, PatronymicWord, CityWord, CountryWord } };
                    string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";
                    var worksheet = excelPackage.Workbook.Worksheets[WorksheetWord];
                    worksheet.Cells[headerRange].LoadFromArrays(headerRow);

                    List<string[]> dataForFile = new List<string[]>();
                    string[] cellData;

                    foreach (User user in ListOfUsersFromDB)
                    {
                        cellData = new string[7] { user.Id.ToString(), user.Date.ToString(), user.FirstName, user.LastName, user.Patronymic,
                            user.City, user.Country};
                        dataForFile.Add(cellData);
                    }

                    worksheet.Cells[2, 1].LoadFromArrays(dataForFile);

                    FileInfo excelFile = new FileInfo(excelFileName);
                    
                    await excelPackage.SaveAsAsync(excelFile);
                }
                MessageBox.Show("Excel файл " + excelFileName + " создан");
                ListOfUsersFromDB.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось создать Excel файл!");
            }
        }

        /// <summary>
        /// Асинхронный метод записи выборки из БД в Xml файл.
        /// </summary>
        /// <param name="xmlFileName"> Имя создаваемого файла. </param>
        /// <returns></returns>
        public async Task WriteIntoXmlFileAsync(string xmlFileName)
        {
            try
            {
                if (ListOfUsersFromDB.IsNullOrEmpty()) 
                    throw new Exception("Выборка не была осуществена!");

                XDocument xDoc = new XDocument();
                XElement users = new XElement(UsersWord);

                foreach (User user in ListOfUsersFromDB)
                {
                    XElement newUser = new XElement(UserWord + user.Id.ToString());
                    XElement newUserDate = new XElement(DateWord, user.Date);
                    XElement newUserFirstName = new XElement(FirstNameWord, user.FirstName);
                    XElement newUserLastName = new XElement(LastNameWord, user.LastName);
                    XElement newUserPatronymic = new XElement(PatronymicWord, user.Patronymic);
                    XElement newUserCity = new XElement(CityWord, user.City);
                    XElement newUserCountry = new XElement(CountryWord, user.Country);

                    newUser.Add(newUserDate, newUserFirstName, newUserLastName, newUserPatronymic, newUserCity, newUserCountry);
                    users.Add(newUser);
                }
                xDoc.Add(users);

                await Task.Factory.StartNew(() => xDoc.Save(xmlFileName));

                MessageBox.Show("XML файл " + xmlFileName + " создан");
                ListOfUsersFromDB.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось создать XML файл!");
            }
        }

        /// <summary>
        /// Асинхронный метод записи данных в БД.
        /// </summary>
        /// <returns></returns>
        public async Task AddToDBAsync()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                await db.Database.EnsureDeletedAsync();
                await db.Database.EnsureCreatedAsync();

                foreach (User user in _listOfUsersFromFile)
                    await db.Users.AddAsync(user);

                await db.SaveChangesAsync();
                _listOfUsersFromFile.Clear();
            }
        }

        /// <summary>
        /// Асинхронный метод чтения данных из БД для создания выборки 
        /// по любой комбинации полей.
        /// </summary>
        /// <param name="dataForExport"> Массив значений полей для выборки. </param>
        /// <returns></returns>
        public async Task ReadFromDBAsync(string[] dataForExport)
        {
            
            for (int i = 1; i < dataForExport.Length; i++)
            {
                if (dataForExport[i].IsNullOrEmpty()) dataForExport[i] = Percent;
            }
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    ListOfUsersFromDB = await
                                (from user in db.Users
                                 where
                                 EF.Functions.Like(user.Date.ToString(), dataForExport[0]) && //гггг-мм-дд
                                 EF.Functions.Like(user.FirstName, dataForExport[1]) &&
                                 EF.Functions.Like(user.LastName, dataForExport[2]) &&
                                 EF.Functions.Like(user.Patronymic, dataForExport[3]) &&
                                 EF.Functions.Like(user.City, dataForExport[4]) &&
                                 EF.Functions.Like(user.Country, dataForExport[5])
                                 select user).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сначала загрузите файл!");
            }
        }

        /// <summary>
        /// Метод преобразования даты в формат БД.
        /// </summary>
        /// <param name="date"> Преобразуемая дата. </param>
        /// <returns></returns>
        public String FormateDate(string date)
        {
            if (!date.Contains(Space))
            {
                string[] dayMonthYear = new string[2];
                dayMonthYear = date.Split(Dot);
                return date = dayMonthYear[2] + Dash + dayMonthYear[1] + Dash + dayMonthYear[0];
            }
            else return date = Percent;
        }
    }
}