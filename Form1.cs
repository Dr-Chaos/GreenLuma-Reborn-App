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
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Security.Principal;

namespace GLApp
{
    public partial class Form1 : Form
    {
        public static string des = string.Empty;
        public static string txt = string.Empty;
        public Desc win;

        public Form1()
        {
            InitializeComponent();
        }

        void Win_FormClosed(object sender, FormClosedEventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        void button1_Click(object sender, EventArgs e)
        {
            int n;
            bool isNum = int.TryParse(textBox2.Text, out n);
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (isNum)
                {
                    if (n > 65)
                        MessageBox.Show("Unable to save file. Text file name can only contain numbers from 0-65.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        if (File.Exists(des + textBox2.Text + ".txt"))
                        {
                            DialogResult dialogResult = MessageBox.Show("\"" + textBox2.Text + ".txt\" already exists. Replace it ?\n\n(Clicking \"Yes\" will allow you to modify the description.)", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogResult == DialogResult.Yes)
                            {
                                txt = textBox2.Text;
                                File.Delete(des + textBox2.Text + ".txt");
                                File.Delete(des + textBox2.Text + "_description.txt");
                                File.AppendAllText(des + textBox2.Text + ".txt", textBox1.Text);
                                File.AppendAllText(des + textBox2.Text + "_description.txt", textBox4.Text);
                                win = new Desc();
                                win.FormClosed += Win_FormClosed;
                                win.Show();
                                //MessageBox.Show("Please set a description for the App ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(textBox1.Text))
                            {
                                if (isNum)
                                {
                                    txt = textBox2.Text;
                                    File.AppendAllText(des + textBox2.Text + ".txt", textBox1.Text);
                                    //string line = Environment.NewLine;
                                    File.WriteAllText("Info.txt", string.Empty);
                                    File.AppendAllText("Info.txt", "LastTextAdded=" + textBox2.Text + ".txt");
                                    string file = File.ReadAllText("Info.txt");
                                    string[] b = file.Split(new char[] { '=' });
                                    textBox5.Text = b[1];
                                    win = new Desc();
                                    win.FormClosed += Win_FormClosed;
                                    win.Show();
                                    //MessageBox.Show("Please set a description for the App ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show("Unable to save file. Text file name can only contain numbers.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (!string.IsNullOrEmpty(textBox2.Text))
                                MessageBox.Show("Unable to save file. Either App ID or text file name is missing.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Unable to save file. Text file name can only contain numbers.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Unable to save file. App ID is missing.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox4.Text = string.Empty;
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                button3.Enabled = true;
                textBox1.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
                textBox1.Enabled = false;
            }
            if (File.Exists(des + textBox2.Text + ".txt"))
                button6.Enabled = true;
            else
            {
                button6.Enabled = false;
            }
        }

        void button2_Click(object sender, EventArgs e)
        {
            int n;
            bool isNum = int.TryParse(textBox2.Text, out n);
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                if (File.Exists(des + textBox2.Text + ".txt"))
                {
                    if (isNum)
                    {
                        if (n > 65)
                            MessageBox.Show("Unable to load file. Text file name can only contain numbers from 0-65.", "Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            textBox1.Text = File.ReadAllText(des + textBox2.Text + ".txt");
                    }
                    else
                        MessageBox.Show("Unable to load file. Text file name can only contain numbers.", "Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Unable to load file. File doesn't exist.", "Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Unable to load file. Text box is empty.", "Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (File.Exists(des + textBox2.Text + "_description.txt"))
            {
                textBox4.Text = File.ReadAllText(des + textBox2.Text + "_description.txt");
            }
        }

        void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox4.Text = string.Empty;
        }

        void button4_Click(object sender, EventArgs e)
        {
            if (File.Exists("steamdir.txt"))
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Browse to your Steam directory and find \"AppList\" folder.";
                    DialogResult folder = fbd.ShowDialog();
                    if (folder == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        File.WriteAllText("steamdir.txt", string.Empty);
                        File.AppendAllText("steamdir.txt", fbd.SelectedPath + @"\");
                        textBox3.Text = File.ReadAllText("steamdir.txt");
                        fbd.Dispose();
                    }
                }
            }
            else
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Browse to your Steam directory and find \"AppList\" folder.";
                    DialogResult folder = fbd.ShowDialog();
                    if (folder == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        File.AppendAllText("steamdir.txt", fbd.SelectedPath + @"\");
                        textBox3.Text = File.ReadAllText("steamdir.txt");
                        fbd.Dispose();
                    }
                }
            }
        }

        void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("Info.txt"))
            {
                string file = File.ReadAllText("Info.txt");
                string[] b = file.Split(new char[] { '=' });
                textBox5.Text = b[1];
            }
            button6.Enabled = false;
            textBox4.ReadOnly = true;
            bool isElevated;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
                if (!isElevated)
                {
                    MessageBox.Show("This program requires to be ran as an Administrator!", "Load", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Process.GetCurrentProcess().Kill();
                    Environment.Exit(0);
                }
            }
            button3.Enabled = false;
            /*if (!Directory.Exists("AppList"))
            {
                Directory.CreateDirectory("AppList");
            }*/
            if (File.Exists("steamdir.txt"))
            {
                des = File.ReadAllText("steamdir.txt");
                textBox3.Text = des;
            }
            else
                button4_Click(sender, e);
        }

        void button5_Click(object sender, EventArgs e)
        {
            Process.Start(des);
        }

        /*void button6_Click(object sender, EventArgs e) //"Move to Folder" button
        {
            foreach (var file in Directory.GetFiles(@"AppList"))
            {
                File.SetAttributes(des, FileAttributes.Normal);
                File.Move(file, des);
            }
            MessageBox.Show("Files have been transfered to \"" + des + "\"", "Move", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }*/

        void label3_Click(object sender, EventArgs e)
        {

        }

        void button6_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete \"" + textBox2.Text + ".txt\" ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                File.Delete(des + textBox2.Text + ".txt");
                File.Delete(des + textBox2.Text + "_description.txt");
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
            }
        }
    }
}
