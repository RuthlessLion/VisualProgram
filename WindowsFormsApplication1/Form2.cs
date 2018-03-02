using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public int changeRadioButton;
        public string inputTextBox1;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            changeRadioButton = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            changeRadioButton = 1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            inputTextBox1 = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked || radioButton2.Checked)
            {
                DialogResult = DialogResult.OK;
                Close();
            } else
            {
                MessageBox.Show("Вы не выбрали раздел!");
            }
        }
    }
}
