using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hackaton
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string sinonim = "300Chinese.txt";
            string[] sinonimwords = File.ReadAllLines(sinonim);
            string[,] num = new string[sinonimwords.Length, sinonimwords[0].Split(' ').Length];
            for (int i = 0; i < sinonimwords.Length; i++)
            {
                string[] temp = sinonimwords[i].Split(' ');
                for (int j = 0; j < temp.Length; j++)
                    num[i, j] = Convert.ToString(temp[j]);
            }
            for (int i = 0; i < num.GetLength(0); i++)
            {
                for (int j = 0; j < num.GetLength(1); j++)
                {
                    listBox1.Items.Add(Convert.ToString(num[i, j]));
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
             
        }

        private void Button3_Click(object sender, EventArgs e)
        {     
            listBox2.Items.Add(textBox1.Text);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}