using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GLApp
{
    public partial class Desc : Form
    {
        public Desc()
        {
            //FormClosing += Desc_FormClosing;
            InitializeComponent();
        }

        void Desc_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        void Desc_Load(object sender, EventArgs e)
        {
            textBox2.Text = Form1.txt;
            textBox2.Enabled = false;
        }

        void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    int n;
                    bool isNum = int.TryParse(textBox2.Text, out n);
                    if (isNum)
                    {
                        File.AppendAllText(Form1.des + textBox2.Text + "_description.txt", textBox1.Text);
                        Close();
                    }
                    else
                        MessageBox.Show("Unable to save description. Text file name can only contain numbers.", "Set", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Unable to save description. File name is empty.", "Set", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Unable to save description. Description is empty.", "Set", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
