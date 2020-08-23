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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Button1_Click_1(object sender, EventArgs e)      
        {
            listBox1.Items.Clear();
            string ishodnik = textBox1.Text;
            string[] ishodwslova = ishodnik.Split(' ');
            Sinonim(ishodwslova);              
            Sort(ishodwslova);
             string[] Sinonim(string[] otsMassiv)
            {
                string sinonim = "sinonim.txt";
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
                    for (int j = 1; j < num.GetLength(1); j++)
                    {
                        for (int k = 0; k < otsMassiv.Length; k++)
                        {
                            if (otsMassiv[k] == num[i, j])
                                otsMassiv[k] = otsMassiv[k].Replace(otsMassiv[k], num[i, 0]);
                        }
                    }
                }
                return otsMassiv;
            }
             void Sort(string[] vhodmassiv)
            {
                string sort = "Кошки.txt";
                string[] sortwords = File.ReadAllLines(sort);
                string[,] num = new string[sortwords.Length, sortwords[0].Split(' ').Length];
                for (int i = 0; i < sortwords.Length; i++)
                {
                    string[] temp = sortwords[i].Split(' ');
                    for (int j = 0; j < temp.Length; j++)
                    {
                        num[i, j] = Convert.ToString(temp[j]);
                    }
                }
                int[,] cifra = new int[num.GetLength(0), num.GetLength(1)];
                for (int i = 0; i < num.GetLength(0); i++)
                {
                    cifra[i, 0] = i;
                    cifra[i, 1] = 0;
                }
                for (int i = 0; i < num.GetLength(0); i++)
                {
                    for (int j = 1; j < num.GetLength(1); j++)
                    {
                        for (int k = 0; k < vhodmassiv.Length; k++)
                        {
                            if (vhodmassiv[k] == num[i, j])
                            {
                                cifra[i, 1]++;
                            }
                        }
                    }
                }
                for (int i = 0; i < num.GetLength(0); i++)
                    for (int j = 0; j < num.GetLength(0) - 1; j++)
                        if (cifra[j, 1] < cifra[j + 1, 1])
                        {
                            for (int c = 0; c < cifra.GetLength(1); c++)
                            {
                                var temp = cifra[j, c];
                                cifra[j, c] = cifra[j + 1, c];
                                cifra[j + 1, c] = temp;
                            }
                        }
                int chet = 0;
                for (int i = 0; i < num.GetLength(0); i++)
                {
                    if (cifra[i, 1] != 0)
                    {
                        listBox1.Items.Add(num[cifra[i, 0], 0]);
                        chet++;
                        if (chet == 3)
                        {
                            break;
                        }
                        else if ((cifra[0, 1] > (cifra[i, 2] + 1)) && (cifra[0, 1] > 2))
                        {
                            break;
                        }

                    }
                    else if (chet==0 && (cifra[i, 1] == 0))
                    {
                        MessageBox.Show("Не найдено животное по заданным параметарам" + "\n База скоро будет расширена :)");
                        string writePath = "300Chinese.txt";
                        for (int g = 0; g < vhodmassiv.Length; g++)
                            using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                            {
                                sw.Write(vhodmassiv[g] + "\n");
                            }
                        break;
                    }
                }
            }
        }                  
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Clear();
        }
    }
}     

    

