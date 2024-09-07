using System.Windows.Forms;

namespace WPF1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            buttonChooseFile = new Button();
            openFileDialog1 = new OpenFileDialog();
            textBox1 = new TextBox();
            radioButtonExcel = new RadioButton();
            radioButtonXml = new RadioButton();
            label1 = new Label();
            buttonExport = new Button();
            maskedTextBoxDate = new MaskedTextBox();
            textBoxLastName = new TextBox();
            textBoxPatronymic = new TextBox();
            textBoxFirstName = new TextBox();
            textBoxCity = new TextBox();
            textBoxCountry = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            textBoxFileName = new TextBox();
            label8 = new Label();
            errorProvider1 = new ErrorProvider(components);
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // buttonChooseFile
            // 
            buttonChooseFile.Location = new Point(654, 44);
            buttonChooseFile.Name = "buttonChooseFile";
            buttonChooseFile.Size = new Size(120, 48);
            buttonChooseFile.TabIndex = 0;
            buttonChooseFile.Text = "Выбрать файл с данными";
            buttonChooseFile.UseVisualStyleBackColor = true;
            buttonChooseFile.Click += ButtonChooseFile_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(28, 44);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.Size = new Size(616, 202);
            textBox1.TabIndex = 1;
            // 
            // radioButtonExcel
            // 
            radioButtonExcel.AutoSize = true;
            radioButtonExcel.Location = new Point(632, 301);
            radioButtonExcel.Name = "radioButtonExcel";
            radioButtonExcel.Size = new Size(144, 24);
            radioButtonExcel.TabIndex = 2;
            radioButtonExcel.TabStop = true;
            radioButtonExcel.Text = "Excel файл (.xlsx)";
            radioButtonExcel.UseVisualStyleBackColor = true;
            // 
            // radioButtonXml
            // 
            radioButtonXml.AutoSize = true;
            radioButtonXml.Location = new Point(632, 335);
            radioButtonXml.Name = "radioButtonXml";
            radioButtonXml.Size = new Size(139, 24);
            radioButtonXml.TabIndex = 3;
            radioButtonXml.TabStop = true;
            radioButtonXml.Text = "XML файл (.xml)";
            radioButtonXml.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 266);
            label1.Name = "label1";
            label1.Size = new Size(310, 20);
            label1.TabIndex = 4;
            label1.Text = "Введите данные для выборки для экспорта";
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(682, 365);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(94, 29);
            buttonExport.TabIndex = 5;
            buttonExport.Text = "Экспорт";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += ButtonExport_Click;
            // 
            // maskedTextBoxDate
            // 
            maskedTextBoxDate.Location = new Point(320, 300);
            maskedTextBoxDate.Mask = "00/00/0000";
            maskedTextBoxDate.Name = "maskedTextBoxDate";
            maskedTextBoxDate.Size = new Size(125, 27);
            maskedTextBoxDate.TabIndex = 6;
            maskedTextBoxDate.ValidatingType = typeof(DateTime);
            maskedTextBoxDate.TypeValidationCompleted += MaskedTextBoxDate_Validating;
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(110, 333);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(125, 27);
            textBoxLastName.TabIndex = 7;
            textBoxLastName.Validating += TextBoxData_Validating;
            // 
            // textBoxPatronymic
            // 
            textBoxPatronymic.Location = new Point(110, 366);
            textBoxPatronymic.Name = "textBoxPatronymic";
            textBoxPatronymic.Size = new Size(125, 27);
            textBoxPatronymic.TabIndex = 8;
            textBoxPatronymic.Validating += TextBoxData_Validating;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(110, 300);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(125, 27);
            textBoxFirstName.TabIndex = 9;
            textBoxFirstName.Validating += TextBoxData_Validating;
            // 
            // textBoxCity
            // 
            textBoxCity.Location = new Point(320, 333);
            textBoxCity.Name = "textBoxCity";
            textBoxCity.Size = new Size(125, 27);
            textBoxCity.TabIndex = 10;
            textBoxCity.Validating += TextBoxData_Validating;
            // 
            // textBoxCountry
            // 
            textBoxCountry.Location = new Point(320, 366);
            textBoxCountry.Name = "textBoxCountry";
            textBoxCountry.Size = new Size(125, 27);
            textBoxCountry.TabIndex = 11;
            textBoxCountry.Validating += TextBoxData_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(253, 303);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 12;
            label2.Text = "Дата:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 303);
            label3.Name = "label3";
            label3.Size = new Size(42, 20);
            label3.TabIndex = 13;
            label3.Text = "Имя:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 336);
            label4.Name = "label4";
            label4.Size = new Size(76, 20);
            label4.TabIndex = 14;
            label4.Text = "Фамилия:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 369);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 15;
            label5.Text = "Отчество:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(253, 336);
            label6.Name = "label6";
            label6.Size = new Size(54, 20);
            label6.TabIndex = 16;
            label6.Text = "Город:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(253, 369);
            label7.Name = "label7";
            label7.Size = new Size(61, 20);
            label7.TabIndex = 17;
            label7.Text = "Страна:";
            // 
            // textBoxFileName
            // 
            textBoxFileName.Location = new Point(489, 300);
            textBoxFileName.Name = "textBoxFileName";
            textBoxFileName.Size = new Size(125, 27);
            textBoxFileName.TabIndex = 18;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(489, 266);
            label8.Name = "label8";
            label8.Size = new Size(89, 20);
            label8.TabIndex = 19;
            label8.Text = "Имя файла:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(632, 266);
            label9.Name = "label9";
            label9.Size = new Size(85, 20);
            label9.TabIndex = 20;
            label9.Text = "Тип файла:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(textBoxFileName);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxCountry);
            Controls.Add(textBoxCity);
            Controls.Add(textBoxFirstName);
            Controls.Add(textBoxPatronymic);
            Controls.Add(textBoxLastName);
            Controls.Add(maskedTextBoxDate);
            Controls.Add(buttonExport);
            Controls.Add(label1);
            Controls.Add(radioButtonXml);
            Controls.Add(radioButtonExcel);
            Controls.Add(textBox1);
            Controls.Add(buttonChooseFile);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonChooseFile;
        private OpenFileDialog openFileDialog1;
        private TextBox textBox1;
        private RadioButton radioButtonExcel;
        private RadioButton radioButtonXml;
        private Label label1;
        private Button buttonExport;
        private MaskedTextBox maskedTextBoxDate;
        private TextBox textBoxLastName;
        private TextBox textBoxPatronymic;
        private TextBox textBoxFirstName;
        private TextBox textBoxCity;
        private TextBox textBoxCountry;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox textBoxFileName;
        private Label label8;
        private ErrorProvider errorProvider1;
        private Label label9;
    }
}
