using ggAPI_Demo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C8Api
{
    public partial class FrmPrint : Form
    {
        public FrmPrint(string text)
        {
            InitializeComponent();
            textBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string result = ggApiHelper.PrintPaper("b9d6fe6526d3e0ec", "lw", "T:" + Convert.ToBase64String(Encoding.Default.GetBytes(textBox1.Text)));
        }
    }
}
