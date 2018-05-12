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
            textBox1.Text = File.ReadAllText(des + comboBox1.SelectedIndex + ".txt");
            if (File.Exists(des + comboBox1.SelectedIndex + "_description.txt"))
                textBox4.Text = File.ReadAllText(des + comboBox1.SelectedIndex + "_description.txt");
        }

        void button1_Click(object sender, EventArgs e)
        {
            int n;
            bool isNum = int.TryParse(textBox1.Text, out n);
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                if (comboBox1.SelectedItem != null)
                {
                    if (textBox1.Text == "381210")
                    {
                        DialogResult result = MessageBox.Show("The usage of GreenLuma Reborn on this specific game has been reported to result in an EAC ban. It is highly recommended that you do not use GreenLuma Reborn to unlock DLC or add its app ID to play it from a friend's library. I'm not held responsible for the decision that you make.\n\nWould you still like to save \"" + comboBox1.SelectedIndex + ".txt\" ?\n\n(If you truly understand the risk and don't want to get banned. Click \"No.\")", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (result == DialogResult.Yes)
                        {
                            if (File.Exists(des + comboBox1.SelectedIndex + ".txt"))
                            {
                                if (isNum)
                                {
                                    DialogResult dialogResult = MessageBox.Show("\"" + comboBox1.SelectedIndex + ".txt\" already exists. Replace it ?\n\n(Clicking \"Yes\" will allow you to modify the description.)", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        txt = comboBox1.SelectedIndex.ToString();
                                        File.Delete(des + comboBox1.SelectedIndex + ".txt");
                                        File.AppendAllText(des + comboBox1.SelectedIndex + ".txt", textBox1.Text);
                                        win = new Desc();
                                        win.FormClosed += Win_FormClosed;
                                        win.Show();
                                        //MessageBox.Show("Please set a description for the App ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                    MessageBox.Show("Unable to save file. Text file name can only contain numbers.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(textBox1.Text))
                                {
                                    if (isNum)
                                    {
                                        txt = comboBox1.SelectedIndex.ToString();
                                        File.AppendAllText(des + comboBox1.SelectedIndex + ".txt", textBox1.Text);
                                        //string line = Environment.NewLine;
                                        File.WriteAllText("Info.txt", string.Empty);
                                        File.AppendAllText("Info.txt", "LastTextAdded=" + comboBox1.SelectedIndex + ".txt");
                                        button6.Enabled = true;
                                        string file = File.ReadAllText("Info.txt");
                                        string[] b = file.Split(new char[] { '=' });
                                        textBox5.Text = b[1];
                                        DialogResult dialogResult = MessageBox.Show("Set a description for \"" + comboBox1.SelectedIndex + ".txt\" ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (dialogResult == DialogResult.Yes)
                                        {
                                            win = new Desc();
                                            win.FormClosed += Win_FormClosed;
                                            win.Show();
                                        }
                                        //MessageBox.Show("Please set a description for the App ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                        MessageBox.Show("Unable to save file. Text file name can only contain numbers.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else if (!string.IsNullOrEmpty(comboBox1.SelectedIndex.ToString()))
                                    MessageBox.Show("Unable to save file. Either App ID or text file name is missing.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            textBox1.Text = string.Empty;
                    }
                    else
                    {
                        if (File.Exists(des + comboBox1.SelectedIndex + ".txt"))
                        {
                            if (isNum)
                            {
                                DialogResult dialogResult = MessageBox.Show("\"" + comboBox1.SelectedIndex + ".txt\" already exists. Replace it ?\n\n(Clicking \"Yes\" will allow you to modify the description.)", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    txt = comboBox1.SelectedIndex.ToString();
                                    File.Delete(des + comboBox1.SelectedIndex + ".txt");
                                    File.AppendAllText(des + comboBox1.SelectedIndex + ".txt", textBox1.Text);
                                    win = new Desc();
                                    win.FormClosed += Win_FormClosed;
                                    win.Show();
                                    //MessageBox.Show("Please set a description for the App ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                                MessageBox.Show("Unable to save file. Text file name can only contain numbers.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(textBox1.Text))
                            {
                                if (isNum)
                                {
                                    txt = comboBox1.SelectedIndex.ToString();
                                    File.AppendAllText(des + comboBox1.SelectedIndex + ".txt", textBox1.Text);
                                    //string line = Environment.NewLine;
                                    File.WriteAllText("Info.txt", string.Empty);
                                    File.AppendAllText("Info.txt", "LastTextAdded=" + comboBox1.SelectedIndex + ".txt");
                                    button6.Enabled = true;
                                    string file = File.ReadAllText("Info.txt");
                                    string[] b = file.Split(new char[] { '=' });
                                    textBox5.Text = b[1];
                                    DialogResult dialogResult = MessageBox.Show("Set a description for \"" + comboBox1.SelectedIndex + ".txt\" ?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        win = new Desc();
                                        win.FormClosed += Win_FormClosed;
                                        win.Show();
                                    }
                                    //MessageBox.Show("Please set a description for the App ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                    MessageBox.Show("Unable to save file. Text file name can only contain numbers.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else if (!string.IsNullOrEmpty(comboBox1.SelectedIndex.ToString()))
                                MessageBox.Show("Unable to save file. Either App ID or text file name is missing.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Unable to save file. Please select a number.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("Unable to save file. App ID is missing.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        /*void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox4.Text = string.Empty;
            if (!string.IsNullOrEmpty(comboBox1.SelectedIndex.ToString()))
            {
                button3.Enabled = true;
                textBox1.Enabled = true;
            }
            else
            {
                button3.Enabled = false;
                textBox1.Enabled = false;
            }
            if (File.Exists(des + comboBox1.SelectedIndex + ".txt"))
                button6.Enabled = true;
            else
            {
                button6.Enabled = false;
            }
        }*/

        void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                if (File.Exists(des + comboBox1.SelectedIndex + ".txt"))
                {
                    textBox1.Text = File.ReadAllText(des + comboBox1.SelectedIndex + ".txt");
                    button3.Enabled = true;
                    textBox4.Multiline = true;
                    textBox4.ScrollBars = ScrollBars.Vertical;
                }
                else
                    MessageBox.Show("Unable to load file. File doesn't exist.", "Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (File.Exists(des + comboBox1.SelectedIndex + "_description.txt"))
                    textBox4.Text = File.ReadAllText(des + comboBox1.SelectedIndex + "_description.txt");
            }
            else
                MessageBox.Show("Unable to load file. Please select a number.", "Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            textBox1.Text = string.Empty;
            //comboBox1.SelectedIndex = string.Empty;
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
                        Process.Start("GLRApp.exe");
                        Process.GetCurrentProcess().Kill();
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
                        Process.Start("GLRApp.exe");
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }
        }

        void Form1_Load(object sender, EventArgs e)
        {
            if (Application.ExecutablePath.Contains("AppData/Local/Temp"))
            {
                MessageBox.Show("Please extract GLRApp from the Winrar archive.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Process.GetCurrentProcess().Kill();
            }
            if (File.Exists("Info.txt"))
            {
                if (File.ReadAllLines("Info.txt")[0].Split(new char[] { '=' })[1] != null)
                {
                    string file = File.ReadAllText("Info.txt");
                    string[] b = file.Split(new char[] { '=' });
                    textBox5.Text = b[1];
                }
            }
            textBox1.Enabled = false;
            button6.Enabled = false;
            textBox4.ReadOnly = true;
            bool isElevated;
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
                if (!isElevated)
                {
                    MessageBox.Show("This program requires to be ran as an Administrator!", "Load", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.GetCurrentProcess().Kill();
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

        void button6_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete \"" + comboBox1.SelectedIndex + ".txt\" ?", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                File.Delete(des + comboBox1.SelectedIndex + ".txt");
                if (File.Exists(des + comboBox1.SelectedIndex + "_description.txt"))
                    File.Delete(des + comboBox1.SelectedIndex + "_description.txt");
                button6.Enabled = false;
                button3.Enabled = false;
                textBox1.Text = string.Empty;
                textBox4.Text = string.Empty;
                File.WriteAllText("Info.txt", string.Empty);
                File.AppendAllText("Info.txt", "LastTextAdded=");
                textBox5.Text = string.Empty;
            }
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
                textBox1.Enabled = true;
            else
                textBox1.Enabled = false;
            if (File.Exists(des + comboBox1.SelectedIndex + ".txt"))
                button6.Enabled = true;
            else
                button6.Enabled = false;
            button3.Enabled = false;
            textBox1.Text = string.Empty;
            textBox4.Text = string.Empty;
        }
    }
}
