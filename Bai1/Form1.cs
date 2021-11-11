using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20520708_BTH4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.AppendFormat("{0} {1} \n{2} = {3}","Location: ",e.Location,"Button",e.Button);
            MessageBox.Show(stringBuilder.ToString(), "MouseClick Event");
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            Char temp = e.KeyChar;
            int temp2 = (int)temp;
            stringBuilder.AppendFormat("{0} {1}\n{2} {3}", "Keycode: ", e.KeyChar,"Mã ACSII của button đã nhấn: ",temp2.ToString());
            MessageBox.Show(stringBuilder.ToString(), "KeyPress Event");
        }
    }
}
