using SaveTestCasesFromRallyToJson.CommonMethods;
using System;
using System.Windows.Forms;

namespace SaveTestCasesFromRallyToJson
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox5.Text = "";

            if (textBox1.Text != "" && 
                textBox2.Text != "" && 
                textBox3.Text != "" && 
                textBox4.Text != "")
            {
                button1.Enabled = false;

                CommonMethodsClass commonMethods = new CommonMethodsClass(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5);
                commonMethods.SetupApi();
                commonMethods.GetRawTestCasesResult(textBox4.Text);
                commonMethods.SaveTestCasesIntoExcelFile();

                button1.Enabled = true;
                textBox5.AppendText("---Done---");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
