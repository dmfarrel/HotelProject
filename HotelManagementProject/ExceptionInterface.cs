using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementProject
{
    public partial class ExceptionInterface : Form
    {
        private string text;

        public ExceptionInterface(string text)
        {
            InitializeComponent();

            this.text = text;
        }

        private void ExceptionInterface_Load(object sender, EventArgs e)
        {
            this.exceptionTextBox.Text = text;
        }

        public void setExceptionText(string text)
        {
            this.exceptionTextBox.Text = text;
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
