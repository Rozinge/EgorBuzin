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
using System.Diagnostics;



/*namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Запись текста в текстовое поле
            textBox1.Text = "Кнопка нажата";
            //Окно сообщения
            MessageBox.Show("Кнопка нажата");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
*/

namespace Lab5
{
    using ClassLibrary1;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> list = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Только текстовые файлы|*.txt"; //если пользователь не выбрал файл
            if (fd.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Необходимо выбрать файл");
                return;
            }

            Stopwatch timer = new Stopwatch();
            timer.Start();
            //считывание текста из файла
            string text = File.ReadAllText(fd.FileName);
            //разделители слов
            char[] separators = new char[] { '?', '.', ',', '!', '-', '–', '*', '/', ' ', '\t', '\n' };

            string[] textArray = text.Split(separators);

            foreach (string strTemp in textArray)
            {
                //Удаление пробелов в начале и конце строки
                string str = strTemp.Trim();
                //Добавление строки в список, если строка не содержится в списке
                if (!list.Contains(str)) list.Add(str);
            }

            timer.Stop();

            this.textBox1.Text = timer.Elapsed.ToString();
            this.textBox2.Text = list.Count.ToString();

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshTimer();
        }



        /// <summary>
        /// Текущее состояние таймера
        /// </summary>
        TimeSpan currentTimer = new TimeSpan();
        /// <summary>
        /// Обновление текущего состояния таймера
        /// </summary>
        private void RefreshTimer()
        {
            textBox1.Text = currentTimer.ToString();
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            //Добавление к текущему состоянию таймера
            //интервала в одну секунду
            currentTimer = currentTimer.Add(new TimeSpan(0, 0, 1)); //Обновление текущего состояния таймера
            RefreshTimer();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Необходимо отрыть файл и выбрать слово для поиска");



            //string word = this.textBox3.Text.Trim();

            ////word = word.ToUpper();
            //string MaxDiststr = this.textBox5.Text.Trim();

            //this.listBox1.BeginUpdate();
            //this.listBox1.Items.Clear();
            ////Stopwatch timer = new Stopwatch();

            //if (!string.IsNullOrWhiteSpace(MaxDiststr))
            //{
            //    int MaxDist = int.Parse(MaxDiststr);
            //    if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
            //    {
            //        word = word.ToUpper();
            //        Stopwatch timer = new Stopwatch();
            //        timer.Start();
            //        //Проверка на случай отсутствия совпадений
            //        bool NoMatches = true; //запуск таймера

            //        foreach (string str in list)
            //        {
            //            //идёт проверка слов в верхнем регистре
            //            if (Class1.Distance(str.ToUpper(), word) <= MaxDist)
            //            {
            //                this.listBox1.Items.Add(str);
            //                NoMatches = false;
            //            }
            //        }

            //        timer.Stop();

            //        this.textBox4.Text = timer.Elapsed.ToString();




            //        if (NoMatches) this.listBox1.Items.Add("Нет сопадений");
            //        }

            //    else
            //    {
            //        MessageBox.Show("Необходимо отрыть файл и выбрать слово для поиска");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Необходимо ввести максимальное расстояние"); 
            //}
           





            
            //this.listBox1.EndUpdate();
            ////запись даных из таймера 

            //this.textBox4.Text = timer.Elapsed.ToString();
            //this.listBox1.BeginUpdate();
            ////Очистка списка
            //this.listBox1.Items.Clear();
            ////Вывод результатов поиска
           
            //this.listBox1.EndUpdate();

                                                                         
















            //if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
            //{
            //    //Слово для поиска в верхнем регистре
            //    string wordUpper = word.ToUpper();
            //    //Временные результаты поиска
            //    List<string> tempList = new List<string>();
            //    Stopwatch t = new Stopwatch();
            //    t.Start();

            //    foreach (string str in list)
            //    {
            //        if (str.ToUpper().Contains(wordUpper))
            //        {
            //            tempList.Add(str);
            //        }
            //    }
            //    t.Stop();

            //    this.textBox4.Text = t.Elapsed.ToString();
            //    this.listBox1.BeginUpdate();
            //    //Очистка списка
            //    this.listBox1.Items.Clear();
            //    //Вывод результатов поиска
            //    foreach (string str in tempList)
            //    {
            //        this.listBox1.Items.Add(str);
            //    }
            //    this.listBox1.EndUpdate();
            //}

            //else
            //{
            //    MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
            //}

        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {



            string word = this.textBox3.Text.Trim();

            if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
            {

                int maxDist;
                if (!int.TryParse(this.textBox5.Text.Trim(), out maxDist))
                {
                    MessageBox.Show("Необходимо указать максимальное расстояние");
                    return;
                }
               
                if (maxDist < 1 || maxDist > 5)
                {
                    MessageBox.Show("Максимальное расстояние должно быть в диапазоне от 1 до 5");
                    return;
                }

                Stopwatch timer = new Stopwatch();
                timer.Start();

                this.listBox1.Items.Clear();
                this.listBox1.BeginUpdate();

                //Слово для поиска в верхнем регистре
                string wordUpper = word.ToUpper();
                //Временные результаты поиска
                bool same = true;

                foreach (string str in list)
                {
                    if (Class1.Distance(str.ToUpper(), word) <= maxDist)
                    {
                        this.listBox1.Items.Add(str);
                        same = false;
                    }
                }
                timer.Stop();

                if (same) this.listBox1.Items.Add("Нет сопадений");




                this.textBox4.Text = timer.Elapsed.ToString();
                this.listBox1.EndUpdate();

            }
            else
            {
                MessageBox.Show("Необходимо отрыть файл и выбрать слово для поиска");
            }
            

        }




        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}
