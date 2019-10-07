using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinIP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            outputip();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            outputip();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string url = textBox1.Text + "." + textBox2.Text + "." + textBox3.Text + "." + textBox4.Text;
            XDocument doc = XDocument.Load("http://ip-api.com/xml/"+url);
            outputip(doc);
        }

        public void outputip()
        {
            XDocument doc = XDocument.Load("http://ip-api.com/xml");
            label1.Text = doc.Element("query").Element("country").Value;
            label2.Text = doc.Element("query").Element("city").Value;
            label3.Text = doc.Element("query").Element("timezone").Value;
            label4.Text = doc.Element("query").Element("query").Value;
        }

        public void outputip(XDocument doc)
        {
            try
            {
                label1.Text = doc.Element("query").Element("country").Value;
                label2.Text = doc.Element("query").Element("city").Value;
                label3.Text = doc.Element("query").Element("timezone").Value;
                label4.Text = doc.Element("query").Element("query").Value;
            }
            catch
            {
                MessageBox.Show("This IP is not available!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
