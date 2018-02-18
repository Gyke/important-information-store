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
            label1.Hide();
            label2.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Encrypt()
        {
            Method1();
            Method2();
            Method3();
            //...

        }

        public void Decrypt()
        {

        }

        public void Serialization()
        {

        }

        public void Deserialization()
        {

        }

        public void Method1()
        {

        }

        public void Method2()
        {

        }
        public void Method3()
        {

        }

        private void button1_Click(object sender, EventArgs e) // button of encrypting
        {
            path = textBox1.Text;
            textBox1.Text = "";

            try
            {
                data.msg = File.ReadAllText(path);
                Encrypt();


                label1.Show();
                label2.Show();
                label2.Text = secretCode.ToString(); 
            }
            catch
            {
                var msg = MessageBox.Show("Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)  // button of decrypting
        {

            path = textBox1.Text;
            textBox1.Text = "";

            try
            {
                data.msg = File.ReadAllText(path);
                Decrypt();
            }
            catch
            {
                var msg = MessageBox.Show("Error");
            }
        }
    }

    public class Information
    {
        public string msg;
    }

}
