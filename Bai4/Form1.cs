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

namespace Bai4
{
    public partial class Form1 : Form
    {
        FontDialog fontDialog;
        private string path;
        private string currentText;
        public Form1()
        {
            InitializeComponent();
            path = null;
            currentText = "";
            richTextBox1.Text = "";
            System.Drawing.Text.InstalledFontCollection fonts = new System.Drawing.Text.InstalledFontCollection();
            foreach (FontFamily f in fonts.Families)
            {
                toolStripComboBox1.Items.Add(f.Name.ToString());
            }
            richTextBox1.SelectionFont = new Font("toolStripComboBox1.SelectedItem.ToString()", float.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Regular);
        }
        private void tạoTậpTinMớiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(currentText != richTextBox1.Text)
            {
                if(MessageBox.Show("Bạn có muốn lưu văn bản đã nhập?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    lưuVănBảnToolStripMenuItem_Click(sender, e);
                    return;
                }
                else
                {
                    path = "";
                    richTextBox1.Text = "";
                    currentText = "";
                    richTextBox1.SelectionFont = new Font("toolStripComboBox1.SelectedItem.ToString()", float.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Regular);
                }
            }
            else
            {
                return;
            }
        }
        private void lưuVănBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(path == null || path =="")
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    Filter = "Text files (*.rtf)|*.rtf|All Files (*.*)|*.*"
                };
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                    path = saveFileDialog.FileName;
                }
            }
            else
            {
                File.WriteAllText(path, richTextBox1.Text);
            }
            currentText = richTextBox1.Text;
            richTextBox1.SelectionFont = new Font("toolStripComboBox1.SelectedItem.ToString()", float.Parse(toolStripComboBox2.SelectedItem.ToString()), FontStyle.Regular);
        }

        private void mởTậpTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(currentText != richTextBox1.Text)
            {
                 if(MessageBox.Show("Bạn có muốn lưu văn bản đã nhập không?","Thông báo",MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                 {
                    lưuVănBảnToolStripMenuItem_Click(sender, e);
                    return;
                 }
                 else
                 {
                    if(MessageBox.Show("Bạn có muốn lưu văn bản đã nhập không?", "Thông báo", MessageBoxButtons.YesNoCancel) == DialogResult.No)
                    {
                        OpenFileDialog openFileDialog = new OpenFileDialog()
                        {
                            Filter = "Text file (*rtf)|*.rtf|TXT|*.txt|All File (*.*)|*.*"
                        };
                        if(openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            path = openFileDialog.FileName;
                            richTextBox1.Text = File.ReadAllText(path);
                            this.Text = openFileDialog.SafeFileName;
                            currentText = richTextBox1.Text;
                        }
                        return;
                    }
                    else
                    {
                        return;
                    }
                 }
            }
            OpenFileDialog openFileDialog1 = new OpenFileDialog()
            {
                Filter = "Text file(*rtf|*rtf|*txt)|*txt|All File (*.*)|*.*"
            };
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                richTextBox1.Text = File.ReadAllText(path);
                this.Text = openFileDialog1.SafeFileName;
                currentText = richTextBox1.Text;
            }
        }

        private void thoáyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentText != richTextBox1.Text)
            {
                DialogResult Edlg = MessageBox.Show("Bạn có muốn lưu file lại không ?", "Thông báo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Edlg == DialogResult.Yes)
                {
                    lưuVănBảnToolStripMenuItem_Click(sender, e);
                    return;
                }
                else
                {
                    if (Edlg == DialogResult.No)
                    {
                        Application.Exit();
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                Application.Exit();
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont(richTextBox1, toolStripComboBox1.SelectedItem.ToString());
        }

        private void ChangeFont(RichTextBox richTextBox,string fontTemp)
        {
            Font font = new Font(new FontFamily(fontTemp), richTextBox.SelectionFont.Size, richTextBox.SelectionFont.Style);
            richTextBox.SelectionFont = font;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            BoldText(richTextBox1);
        }

        private void BoldText(RichTextBox richTextBox)
        {
            Font font = new Font(richTextBox.SelectionFont.FontFamily.Name, richTextBox.SelectionFont.Size, FontStyle.Bold);
            richTextBox.SelectionFont = font;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            ItalicText(richTextBox1);
        }

        private void ItalicText(RichTextBox richTextBox)
        {
            Font font = new Font(richTextBox.SelectionFont.FontFamily.Name, richTextBox.SelectionFont.Size, FontStyle.Italic);
            richTextBox.SelectionFont = font;
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            NormalText(richTextBox1);
        }

        private void NormalText(RichTextBox richTextBox)
        {
            Font font = new Font(richTextBox.SelectionFont.FontFamily.Name, richTextBox.SelectionFont.Size, FontStyle.Regular);
            richTextBox.SelectionFont = font;
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeSize(richTextBox1,float.Parse(toolStripComboBox2.SelectedItem.ToString()));
        }
        void ChangeSize(RichTextBox richTextBox,float size)
        {
            Font font = new Font(richTextBox.SelectionFont.FontFamily.Name, size, richTextBox.SelectionFont.Style);
            richTextBox.SelectionFont = font;
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontDialog = new FontDialog();
            fontDialog.ShowDialog();
            dinhDangFont(richTextBox1);
        }

        private void dinhDangFont(RichTextBox richTextBox)
        {
            Font font = new Font(fontDialog.Font.FontFamily, fontDialog.Font.Size, fontDialog.Font.Style);
            richTextBox.SelectionFont = font;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tạoTậpTinMớiToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            lưuVănBảnToolStripMenuItem_Click(sender, e);
        }
    }
}
