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
        /// �������������� ������� �����, �������� � �� ������ ������.
        /// </summary>
        internal Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            textBox1.Text = "��������, ����������, ����!\t\t\t\t\t--------->\r\n(� ������� csv)";
        }

        /// <summary>
        /// ����������� ��� ������� ������ ������ �����. 
        /// ��������� ������� ���� � ���������� � ��������� ��� � ���������, 
        /// ����� ���� ��������� �� ���� ������ � ���������� �� � ��.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonChooseFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = FileExtensionFilter;
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = "�������� ����� � ������� ������ ����� ������ ��������� �����...";

                string fileName = openFileDialog1.FileName;
                await program.ReadFromCsvFileAsync(fileName);
                await program.AddToDBAsync();

                textBox1.Text = "������ ��������� � ���� ����� � ������ � ��������.";
            }
        }

        /// <summary>
        /// ����������� ��� ������� ������ ��������.
        /// �������� �������� ������������� � ���� ��� ������� ����������,
        /// �������� ����� �������� ������� �� �� � ������� ������������ ������� �� �����,
        /// � ��������� ����� �������� ����� ��� ��������.
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
        /// �������� ����� �������� ����� ��� �������� � ����������� �� 
        /// ���������� ������������� � ����� radioButton ����������.
        /// </summary>
        /// <param name="newFileName"> ��� ������������ �����. </param>
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
                MessageBox.Show("�������� ��� �����!");
            }
        }

        /// <summary>
        /// ������� ������� �� �� �� �����.
        /// </summary>
        private void OutputUsersToTextbox()
        {
            if (!program.ListOfUsersFromDB.IsNullOrEmpty())
            {
                textBox1.Text = "������ ������������� ��������� �� ���� ������:\r\n";
                foreach (User user in program.ListOfUsersFromDB)
                {
                    textBox1.Text += user.Date.ToString() + Space + user.FirstName + Space + user.LastName + Space
                        + user.Patronymic + Space + user.City + Space + user.Country + "\r\n";
                }
            }            
        }
        
        /// <summary>
        /// ����� ��� �������� ������������ �������� ��������� ������ 
        /// ��� ������� �� ��.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxData_Validating(object sender, CancelEventArgs e)
        {
            var textBox = (TextBox)sender;

            if (!textBox.Text.All(Char.IsLetter))
            {
                errorProvider1.SetError(textBox, "���������� ���� ���� � ��������!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        /// <summary>
        /// ����� ��� �������� ������������ �������� ���� 
        /// ��� ������� �� ��.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaskedTextBoxDate_Validating(object sender, TypeValidationEventArgs e)
        {
            if (!e.IsValidInput)
            {
                errorProvider1.SetError(maskedTextBoxDate, "�������� ���� ����!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }
    }
}
