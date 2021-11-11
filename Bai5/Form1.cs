using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai5
{
    
    public partial class Form1 : Form
    {
        private static Form1 instance;

        private List<string[]> row = new List<string[]>();

        public static Form1 Instance
        {
            get { if (instance == null) instance = new Form1(); return instance; }
            set => instance = value;
        }

        public List<string[]> Row { get => row; set => row = value; }

        void LoadData()
        {
            dataGridView1.Rows.Clear();
            foreach (string[] row in Row)
            {
                dataGridView1.Rows.Add(row);
            }
        }
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }
    
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddForm.Instance.Show();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
      
        
        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (toolStripTextBox1.Text == "")
                {
                    LoadData();
                    return;
                }
                dataGridView1.Rows.Clear();
                foreach (string[] row in Row)
                {
                    string str = row[2].ToUpper();
                    toolStripTextBox1.Text = toolStripTextBox1.Text.ToUpper();

                    if (str.Contains(toolStripTextBox1.Text) == true)
                    {
                        dataGridView1.Rows.Add(row);
                    }
                }
                toolStripTextBox1.Text = "";
            }

        }
 
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddForm.Instance.Show();
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
