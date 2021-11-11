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
    public partial class AddForm : Form
    {
        #region data
        private static AddForm instance;
        void Reset()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            textBox1.Focus();
        }
        public static AddForm Instance { get { if (instance == null) instance = new AddForm(); return instance; } set => instance = value; }
        #endregion
        public AddForm()
        {
            InitializeComponent();
            Reset();
        }
        #region button event
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.Instance.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" ||
                comboBox1.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin");
                return;
            }
            try
            {
                Convert.ToDouble(textBox4.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Nhập điểm sai format (vd đúng : 9 or 9.3");
                return;
            }
            string[] r = {(Form1.Instance.Row.Count+1).ToString(),textBox1.Text,
            textBox2.Text,comboBox1.Text,textBox4.Text};

            Form1.Instance.Row.Add(r);

            Reset();
        }
        #endregion

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1.Instance.Show();
        }
    }
}
