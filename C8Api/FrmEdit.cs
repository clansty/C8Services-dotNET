using ServiceStack.Redis;
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
    public partial class FrmEdit : Form
    {
        public FrmEdit()
        {
            InitializeComponent();
            using (var rds = new RedisClient("101.132.178.136", 6379, "qVAo9C1tCbD2PEiR"))
            {
                var date = DateTime.Now.ToShortDateString();
                textBox1.Text = rds.GetValueFromHash("zy" + date, "c");
                textBox2.Text = rds.GetValueFromHash("zy" + date, "m");
                textBox3.Text = rds.GetValueFromHash("zy" + date, "e");
                textBox4.Text = rds.GetValueFromHash("zy" + date, "p");
                textBox5.Text = rds.GetValueFromHash("zy" + date, "b");
            }
        }

        private void FrmEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (var rds = new RedisClient("101.132.178.136", 6379, "qVAo9C1tCbD2PEiR"))
            {
                var date = DateTime.Now.ToShortDateString();
                rds.SetEntryInHash("zy" + date, "c", textBox1.Text);
                rds.SetEntryInHash("zy" + date, "m", textBox2.Text);
                rds.SetEntryInHash("zy" + date, "e", textBox3.Text);
                rds.SetEntryInHash("zy" + date, "p", textBox4.Text);
                rds.SetEntryInHash("zy" + date, "b", textBox5.Text);
            }
        }
    }
}
