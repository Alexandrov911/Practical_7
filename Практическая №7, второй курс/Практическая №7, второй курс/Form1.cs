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

namespace Практическая__7__второй_курс
{
    public partial class Form1 : Form
    {
        public struct Person
        {
            public string FIO;
            public int school;
            public int klass;
            public int test;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.RowCount = Convert.ToInt32(numericUpDown1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int n = Convert.ToInt32(numericUpDown1.Value);
                Person[] mas = new Person[n];
                for (int i = 0; i < n; i++)
                {
                    mas[i].FIO = dataGridView1[0, i].Value.ToString();
                    mas[i].school = Convert.ToInt32(dataGridView1[1, i].Value);
                    mas[i].klass = Convert.ToInt32(dataGridView1[2, i].Value);
                    mas[i].test = Convert.ToInt32(dataGridView1[3, i].Value);
                }
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName,
                        true, System.Text.Encoding.Default);
                    for (int i = 0; i < n; i++)
                    {
                        sw.WriteLine(mas[i].FIO);
                        sw.WriteLine(mas[i].school);
                        sw.WriteLine(mas[i].klass);
                        sw.WriteLine(mas[i].test);
                    }
                    sw.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName,
                    System.Text.Encoding.Default);
                Person[] mas = new Person[0];
                int k = 0;
                while (!sr.EndOfStream)
                {
                    k++;
                    Array.Resize(ref mas, k);
                    mas[k - 1].FIO = sr.ReadLine();
                    mas[k - 1].school = Convert.ToInt32(sr.ReadLine());
                    mas[k - 1].klass = Convert.ToInt32(sr.ReadLine());
                    mas[k - 1].test = Convert.ToInt32(sr.ReadLine());
                }
                sr.Close();
                dataGridView1.RowCount = k;
                numericUpDown1.Value = k;
                for (int i = 0; i < k; i++)
                {
                    dataGridView1[0, i].Value = mas[i].FIO;
                    dataGridView1[1, i].Value = mas[i].school;
                    dataGridView1[2, i].Value = mas[i].klass;
                    dataGridView1[3, i].Value = mas[i].test;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.RowCount = Convert.ToInt32(numericUpDown1.Value);
            Person[] mas = new Person[n];
            for (int i = 0; i < n; i++)
            {
                mas[i].FIO = dataGridView1[0, i].Value.ToString();
                mas[i].school = Convert.ToInt32(dataGridView1[1, i].Value);
                mas[i].klass = Convert.ToInt32(dataGridView1[2, i].Value);
                mas[i].test = Convert.ToInt32(dataGridView1[3, i].Value);
            }
            int min = mas[0].klass;
            for(int i=0; i<n; i++)
            {
                if (min > mas[i].klass)
                {
                    min = mas[i].klass;
                }
                
            }
            MessageBox.Show(min.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.RowCount = Convert.ToInt32(numericUpDown1.Value);
            Person[] mas = new Person[n];
            for (int i = 0; i < n; i++)
            {
                mas[i].FIO = dataGridView1[0, i].Value.ToString();
                mas[i].school = Convert.ToInt32(dataGridView1[1, i].Value);
                mas[i].klass = Convert.ToInt32(dataGridView1[2, i].Value);
                mas[i].test = Convert.ToInt32(dataGridView1[3, i].Value);
            }
            int max = mas[0].klass;
            for (int i = 0; i < n; i++)
            {
                if (max < mas[i].klass)
                {
                    max = mas[i].klass;
                }

            }
            MessageBox.Show(max.ToString());
        }
    }
}
