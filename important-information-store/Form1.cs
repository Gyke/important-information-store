using important_information_store.Methods;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace important_information_store
{
    public partial class Form1 : Form
    {
        public string path;
        public Information data = new Information();
        public int secretCode;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // button of encrypting
        {
            var First_Method = new RSA();

            path = textBox1.Text;
            textBox1.Text = "";

            try
            {
                data.msg = File.ReadAllText(path);
                data.msg = Convert.ToString(data.msg);
                First_Method.Method(data.msg, path);
            }
            catch
            {
                var msg = MessageBox.Show("Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)  // button of decrypting
        {
            var First_Method = new RSA();

            path = textBox1.Text;
            textBox1.Text = "";

            try
            {
                data.msg = File.ReadAllText(path);
                First_Method.Method(data.msg, secretCode, path);
            }
            catch
            {
                var msg = MessageBox.Show("Error");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

    public class Information
    {
        public string msg;
    }
}
