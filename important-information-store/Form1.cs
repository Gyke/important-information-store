using important_information_store.Methods;
using System;
using System.IO;
using System.Windows.Forms;

namespace important_information_store
{
    public partial class Form1 : Form
    {
        public string path;
        public Information data = new Information();
        public int secret_D;
        public int secret_N;
        public int public_E;

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

            try
            {
                path = textBox1.Text;
                textBox1.Text = "";
                secret_N = Convert.ToInt32(textBox2.Text);
                textBox2.Text = "";
                secret_D = Convert.ToInt32(textBox3.Text);
                textBox3.Text = "";
                public_E = Convert.ToInt32(textBox4.Text);
                textBox4.Text = "";

                try
                {
                    data.msg = File.ReadAllText(path);
                    data.msg = Convert.ToString(data.msg);
                    First_Method.Method(data.msg, secret_D, secret_N, public_E, path);
                }
                catch
                {
                    var msg = MessageBox.Show("Error");
                }
            }
            catch
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                MessageBox.Show("Incorrect incomming data!");
            }
        }
    }

    public class Information
    {
        public string msg;
    }
}
