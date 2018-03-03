using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Develop Roman and Lev, group IP-615");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (int item in listBox1.SelectedIndices)
            {
                listBox2.Items.Add(listBox1.Items[item]);
                listBox1.Items.RemoveAt(item);
            }
            listBox1.Update();
            listBox2.Update();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(dlg.FileName, Encoding.Default);
                textBox2.Text = reader.ReadToEnd();
                reader.Close();
            }
            dlg.Dispose();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    writer.WriteLine((string)listBox1.Items[i]);
                }
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    writer.WriteLine((string)listBox2.Items[i]);
                }
                writer.Close();
            }
            dlg.Dispose();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            
            string[] strings = textBox2.Text.Split(new char[] { '\n', '\t', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in strings)
            {
                string str = s.Trim();
                if (str == String.Empty) continue;
                if (radioButton1.Checked)
                {
                    listBox1.Items.Add(str);
                }
                if (radioButton2.Checked)
                {
                    if (Regex.IsMatch(str, @"\d")) {
                        listBox1.Items.Add(str);
                    }
                }
                if (radioButton3.Checked)
                {
                    if (str.Contains('@'))
                    {
                        listBox1.Items.Add(str);
                    }
                }
            }
            listBox1.Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox2.Items.AddRange(listBox1.Items);
            listBox1.Items.Clear();
            listBox1.Update();
            listBox2.Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(listBox2.Items);
            listBox2.Items.Clear();
            listBox1.Update();
            listBox2.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (int item in listBox2.SelectedIndices)
            {
                listBox1.Items.Add(listBox2.Items[item]);
                listBox2.Items.RemoveAt(item);
            }
            listBox1.Update();
            listBox2.Update();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (int item in listBox1.SelectedIndices)
            {
                listBox1.Items.RemoveAt(item);
            }
            foreach (int item in listBox2.SelectedIndices)
            {
                listBox2.Items.RemoveAt(item);
            }
            listBox1.Update();
            listBox2.Update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 add = new Form2();
            if(add.ShowDialog() == DialogResult.OK)
            {
                if(add.changeRadioButton == 0)
                {
                    listBox1.Items.Add(add.inputTextBox1);
                }
                if(add.changeRadioButton == 1)
                {
                    listBox2.Items.Add(add.inputTextBox1);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            System.Threading.Thread.Sleep(1000);

            SortListBox(listBox1, comboBox2);

            this.Cursor = Cursors.Default;
        }

        public class Comparer1 : IComparer<string>
        {
            int IComparer<string>.Compare(string x, string y)
            {
                return (new CaseInsensitiveComparer()).Compare(y, x);
            }
        }

        public class Comparer2 : IComparer<string>
        {
            int IComparer<string>.Compare(string x, string y)
            {
                return (new CaseInsensitiveComparer()).Compare(x.Length, y.Length);
            }
        }

        public class Comparer3 : IComparer<string>
        {
            int IComparer<string>.Compare(string x, string y)
            {
                return (new CaseInsensitiveComparer()).Compare(y.Length, x.Length);
            }
        }

        private void SortListBox(ListBox list, ComboBox combo)
        {
            List<string> buff_list = new List<string>();
            foreach (string i in list.Items)
            {
                buff_list.Add(i);
            }
            switch(combo.SelectedIndex)
            {
                case 0:
                    buff_list.Sort();
                    break;
                case 1:
                    Comparer1 comp1 = new Comparer1();
                    buff_list.Sort(comp1);
                    break;
                case 2:
                    Comparer2 comp2 = new Comparer2();
                    buff_list.Sort(comp2);
                    break;
                case 3:
                    Comparer3 comp3 = new Comparer3();
                    buff_list.Sort(comp3);
                    break;
                default:
                    return;
            }
            list.Items.Clear();
            foreach (string i in buff_list)
            {
                list.Items.Add(i);
            }
            list.Update();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Update();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            SortListBox(listBox2, comboBox3);

            this.Cursor = Cursors.Default;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            List<string> buffer = new List<string>();
            if (checkBox1.Checked)
            {
                buffer.AddRange(SearchElem(textBox1.Text, listBox1));
            }
            if (checkBox2.Checked)
            {
                buffer.AddRange(SearchElem(textBox1.Text, listBox2));
            }
            listBox3.Items.Clear();
            listBox3.Items.AddRange(buffer.ToArray());
        }
        private List<string> SearchElem(string elem, ListBox list)
        {
            List<string> ret_list = new List<string>();
            foreach (string item in list.Items)
            {
                if (item.Contains(elem))
                {
                    ret_list.Add(item);
                }
            }
            return ret_list;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            radioButton1.Checked = true;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
