using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;

namespace WPF1
{
    internal partial class Form1 : Form
    {
        Program program = new Program();
        
        private const string XmlExtension = ".xml";
        private const string ExcelExtension = ".xlsx";
        private const string FileExtensionFilter = "Text files (*.csv) | *.csv";
        private const string Space = " ";
        private const string DefaultFileName = "DefaultFileName";

        /// <summary>
        /// Инициализирует главную форму, размещая её по центру экрана.
        /// </summary>
        internal Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox1.Text = "Выберите, пожалуйста, файл!\t\t\t\t\t--------->\r\n(в формате csv)";
        }

        /// <summary>
        /// Запускается при нажатии кнопки выбора файла. 
        /// Позволяет выбрать файл в проводнике и загрузить его в программу, 
        /// после чего считывает из него данные и записывает их в БД.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonChooseFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = FileExtensionFilter;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = "Открытие файла и перенос данных могут занять некоторое время...";

                string fileName = openFileDialog1.FileName;
                await program.ReadFromCsvFileAsync(fileName);
                await program.AddToDBAsync();

                textBox1.Text = "Данные загружены в базу даных и готовы к экспорту.";
            }
        }

        /// <summary>
        /// Запускается при нажатии кнопки экспорта.
        /// Собирает введённую пользователем в поля для выборки информацию,
        /// вызывает метод создания выборки из БД и выводит произведённую выборку на экран,
        /// и запускает метод создания файла для экспорта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonExport_Click(object sender, EventArgs e)
        {
            string newFileName = DefaultFileName;
            if (!textBoxFileName.Text.IsNullOrEmpty())
                newFileName = textBoxFileName.Text;

            string date = maskedTextBoxDate.Text;
            date = program.FormateDate(date);

            string firstName = textBoxFirstName.Text;
            string lastName = textBoxLastName.Text;
            string patronymic = textBoxPatronymic.Text;
            string city = textBoxCity.Text;
            string country = textBoxCountry.Text;

            string[] dataForExport = { date, firstName, lastName, patronymic, city, country };
            
            await program.ReadFromDBAsync(dataForExport);

            OutputUsersToTextbox();
            await CreateFileAsync(newFileName);
            
        }

        /// <summary>
        /// Вызывает метод создания файла для экспорта в зависимости от 
        /// выбранного пользователем в полях radioButton расширения.
        /// </summary>
        /// <param name="newFileName"> Имя создаваемого файла. </param>
        /// <returns></returns>
        private async Task CreateFileAsync(string newFileName)
        {
            if (radioButtonExcel.Checked)
            {
                newFileName += ExcelExtension;
                await program.WriteIntoExcelFileAsync(newFileName);
            }
            else if (radioButtonXml.Checked)
            {
                newFileName += XmlExtension;
                await program.WriteIntoXmlFileAsync(newFileName);
            }
            else
            {
                MessageBox.Show("Выберите тип файла!");
            }
        }

        /// <summary>
        /// Выводит выборку из БД на экран.
        /// </summary>
        private void OutputUsersToTextbox()
        {
            if (!program.ListOfUsersFromDB.IsNullOrEmpty())
            {
                textBox1.Text = "Список пользователей выбранных из базы данных:\r\n";
                foreach (User user in program.ListOfUsersFromDB)
                {
                    textBox1.Text += user.Date.ToString() + Space + user.FirstName + Space + user.LastName + Space
                        + user.Patronymic + Space + user.City + Space + user.Country + "\r\n";
                }
            }            
        }
        
        /// <summary>
        /// Медот для проверки корректности введённых строковых данных 
        /// для выборки из БД.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxData_Validating(object sender, CancelEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (!textBox.Text.All(Char.IsLetter))
            {
                errorProvider1.SetError(textBox, "Невозможен ввод цифр и пробелов!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        /// <summary>
        /// Медот для проверки корректности введённой даты 
        /// для выборки из БД.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskedTextBoxDate_Validating(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                errorProvider1.SetError(maskedTextBoxDate, "Неверный ввод даты!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
