using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileSuffixNameModificationTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = FBD.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (textBox1.Text != "")
                {
                    string stringOldFileName;
                    string stringNewFileName;
                    string stringOldPart = this.textBox1.Text.Trim();
                    string stringNewPart = this.textBox2.Text.Trim();
                    string stringNewFilePath;
                    string stringFileFolder;
                    int TotalFiles = 0;
                    DateTime StartTime = DateTime.Now;
                    try
                    {
                        DirectoryInfo di = new DirectoryInfo(textBox3.Text);
                        FileInfo[] filelist = di.GetFiles("*.*");
                        stringFileFolder = textBox3.Text;
                        int i = 0;
                        foreach (FileInfo fi in filelist)
                        {
                            stringOldFileName = fi.Name;
                            stringNewFileName = fi.Name.Replace(stringOldPart, stringNewPart);
                            stringNewFilePath = @stringFileFolder + "\\" + stringNewFileName;
                            filelist[i].MoveTo(@stringNewFilePath);
                            TotalFiles += 1;
                            this.listBox1.Items.Add("Flie Name：" + stringOldFileName + "  Renamed to the " + stringNewFileName + "");
                            i += 1;
                        }
                        MessageBox.Show("Modify the suffix name complete");
                    }
                    catch
                    {
                        MessageBox.Show("invalid path");
                    }
                }
                else
                {
                    MessageBox.Show("Matching the suffix name is not found");
                }
            }
            else
            {
                MessageBox.Show("Please select the directory");
            }
        }
    }
}
