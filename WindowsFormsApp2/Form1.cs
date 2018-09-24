using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {

        private String str;
        public string Str
        {
            get
            {
                return str;
            }

            set
            {
                str = value;
            }
        }

        public static string connectionInfo = "datasource=localhost; port=3306; username=root; password=''; database=ppk2018; SslMode=none";
        public MySqlConnection connect = new MySqlConnection(connectionInfo);


        public static Form2 frm2;
        public static Form3 frmMdi3;
        public static Form4 form4;   

        public Form1()
        {
            InitializeComponent();
            frmMdi3 = new Form3(this);
            frmMdi3.MdiParent = this;
            frm2 = new Form2(this);
            form4 = new Form4(this);
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2.Show();
        }

        private void showToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMdi3.Show();
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2.Hide();
        }

        private void maximizedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2.WindowState = FormWindowState.Maximized;
        }

        private void minimizedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm2.WindowState = FormWindowState.Minimized;
        }

        private void hideToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMdi3.Hide();
        }

        private void maximizedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMdi3.WindowState = FormWindowState.Maximized;
        }

        private void minimizedToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmMdi3.WindowState = FormWindowState.Minimized;
        }

        private void hideToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            frmMdi3.Hide();
        }

        private void formUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form4.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connect.Open();
                MessageBox.Show("connected");
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
