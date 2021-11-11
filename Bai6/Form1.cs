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

namespace Bai6
{
    public partial class Form1 : Form
    {
        string filename1, filename2;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedFolder;
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {

                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    selectedFolder = dialog.SelectedPath;
                    textBox1.Text = selectedFolder;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedFolder;
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    selectedFolder = dialog.SelectedPath;
                    textBox2.Text = selectedFolder;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DirectoryInfo diSource = new DirectoryInfo(textBox1.Text);
            DirectoryInfo diTarget = new DirectoryInfo(textBox2.Text);

            CopyAll(diSource, diTarget);
            int i; 

            progressBar1.Minimum = 0; 
            progressBar1.Maximum = 200; 
            for (i = 0; i <= 200; i++)
            {
                progressBar1.Value = i; 
            }
            MessageBox.Show("Copy thành công");
        }
        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

    }
}
