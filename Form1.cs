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

namespace DZ
{
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




        public class Class1
        {

            public static int Distance(string str1Param, string str2Param)
            {
                if ((str1Param == null) || (str2Param == null)) return -1;
                int str1Len = str1Param.Length;
                int str2Len = str2Param.Length;

                if ((str1Len == 0) && (str2Len == 0)) return 0;
                if (str1Len == 0) return str2Len;
                if (str2Len == 0) return str1Len;

                string str1 = str1Param.ToUpper();
                string str2 = str2Param.ToUpper();
                int[,] matrix = new int[str1Len + 1, str2Len + 1];
                //Инициализация нулевой строки и нулевого столбца матрицы 
                for (int i = 0; i <= str1Len; i++) matrix[i, 0] = i;
                for (int j = 0; j <= str2Len; j++) matrix[0, j] = j;

                for (int i = 1; i <= str1Len; i++)
                {
                    for (int j = 1; j <= str2Len; j++)
                    {
                        int symbEqual = ((str1.Substring(i - 1, 1) == str2.Substring(j - 1, 1)) ? 0 : 1);
                        int ins = matrix[i, j - 1] + 1; //Добавление
                        int del = matrix[i - 1, j] + 1; //Удаление
                        int subst = matrix[i - 1, j - 1] + symbEqual; //Замена
                        matrix[i, j] = Math.Min(Math.Min(ins, del), subst);

                        if ((i > 1) && (j > 1) &&
                        (str1.Substring(i - 1, 1) == str2.Substring(j - 2, 1)) && (str1.Substring(i - 2, 1) == str2.Substring(j - 1, 1)))
                        {
                            matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + symbEqual);
                        }
                    }
                }
                return matrix[str1Len, str2Len];
            }


            public static void WriteDistance(string str1Param, string str2Param)
            {
                int d = Distance(str1Param, str2Param);
                Console.WriteLine("'" + str1Param + "','" + str2Param + "' -> " + d.ToString());
            }


        }

        public class ParallelSearchResult
        {
            /// <summary>
            /// Найденное слово
            /// </summary>
            public string word { get; set; }
            /// <summary>
            /// Расстояние
            /// </summary>
            public int dist { get; set; }
            /// <summary>
            /// Номер потока
            /// </summary>
            public int ThreadNum { get; set; }
        }

        class ParallelSearchThreadParam
        {
            /// <summary>
            /// Массив для поиска
            /// </summary>
            public List<string> tempList { get; set; }
            /// Слово для поиска
            /// </summary>
            public string wordPattern { get; set; }
            /// <summary>
            /// Максимальное расстояние для нечеткого поиска
            /// </summary>
            public int maxDist { get; set; }
            /// <summary>
            /// Номер потока
            /// </summary>
            public int ThreadNum { get; set; }
        }

        public class MinMax{
              public int Min {get; set;}
              public int Max {get; set;}
              public MinMax(int pmin, int pmax)
              {
                  this.Min = pmin;
                  this.Max = pmax;
              }
          }

        public static class SubArrays{
            /// <summary>
            /// Деление массива на последовательности
            /// </summary>
            /// <param name="beginIndex">Начальный индекс массива</param>
            /// <param name="endIndex">Конечный индекс массива</param>
            /// <param name="subArraysCount">Требуемое количество подмассивов</param>
            /// <returns>Список пар с индексами подмассивов</returns>
            public static List<MinMax> DivideSubArrays(int beginIndex, int endIndex, int subArraysCount)
            {
            //Результирующий список пар с индексами подмассивов
            List<MinMax> result = new List<MinMax>();
             //Если число элементов в массиве слишком мало для деления
             //то возвращается массив целиком
            if ((endIndex - beginIndex) <= subArraysCount)
            {
                result.Add(new MinMax(0, (endIndex - beginIndex)));
            }
            else
            {
                //Размер подмассива
                int delta = (endIndex - beginIndex) / subArraysCount;
                //Начало отсчета
                int currentBegin = beginIndex;
                //Пока размер подмассива укладывается в оставшуюся
                //последовательность
                while ((endIndex - currentBegin) >= 2 * delta)
                {
                    //Формируем подмассив на основе начала
                    //последовательности
                    result.Add(new MinMax(currentBegin, currentBegin + delta));
                    //Сдвигаем начало последовательности
                    //вперед на размер подмассива
                    currentBegin += delta;
                }
                //Оставшийся фрагмент массива
                result.Add(new MinMax(currentBegin, endIndex));
            }
            
            //Возврат списка результатов
            return result;
            }
         }

        public static List<ParallelSearchResult> ArrayThreadTask(object paramObj)
        {
            ParallelSearchThreadParam param = (ParallelSearchThreadParam)paramObj;
            //Слово для поиска в верхнем регистре
            string wordUpper = param.wordPattern.Trim().ToUpper();

            //Результаты поиска в одном потоке
            List<ParallelSearchResult> Result = new List<ParallelSearchResult>();
            //Перебор всех слов во временном списке данного потока
            foreach (string str in param.tempList)
            {
                //Вычисление расстояния Дамерау-Левенштейна
                int dist = Class1.Distance(str.ToUpper(), wordUpper);
                //Если расстояние меньше порогового, то слово добавляется в результат
                if (dist <= param.maxDist)
                {
                    ParallelSearchResult temp = new ParallelSearchResult()
                 {
                     word = str,
                     dist = dist,
                     ThreadNum = param.ThreadNum
                 };
                    Result.Add(temp);
                }
            }
            return Result;
        }






        private void button2_Click_1(object sender, EventArgs e)
        {

           

             //string word = this.textBox3.Text.Trim();
             ////Если слово для поиска не пусто
             //if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
             //{
             //    int maxDist;
             //    if (!int.TryParse(this.textBox5.Text.Trim(), out maxDist))
             //    {
             //        MessageBox.Show("Необходимо указать максимальное расстояние");
             //        return;
             //    }
             //    if (maxDist < 1 || maxDist > 5)
             //    {
             //        MessageBox.Show("Максимальное расстояние должно быть в диапазоне от 1 до 5");
             //        return;
             //    }
             //    int ThreadCount;
             //    if (!int.TryParse(this.textBox6.Text.Trim(), out ThreadCount))
             //    {
             //        MessageBox.Show("Необходимо указать количество потоков");
             //        return;
             //    }
             //    Stopwatch timer = new Stopwatch();
             //    timer.Start();


             //    //-------------------------------------------------
             //    // Начало параллельного поиска
             //    //-------------------------------------------------

             //    //Результирующий список
             //    List<ParallelSearchResult> Result = new List<ParallelSearchResult>();
             //    //Деление списка на фрагменты для параллельного запуска в потоках
             //    List<MinMax> arrayDivList = SubArrays.DivideSubArrays(0, list.Count, ThreadCount);
             //    int count = arrayDivList.Count;

             //    //Количество потоков соответствует количеству фрагментов массива
             //    Task<List<ParallelSearchResult>>[] tasks = new Task<List<ParallelSearchResult>>[count];
             //    //Запуск потоков
             //    for (int i = 0; i < count; i++)
             //    {
             //        //Создание временного списка, чтобы потоки не работали параллельно с одной коллекцией
             //        List<string> tempTaskList = list.GetRange(arrayDivList[i].Min, arrayDivList[i].Max - arrayDivList[i].Min);

             //        tasks[i] = new Task<List<ParallelSearchResult>>(ArrayThreadTask, new ParallelSearchThreadParam()
             //        {
             //            tempList = tempTaskList,
             //            maxDist = maxDist,
             //            ThreadNum = i,
             //            wordPattern = word
             //        });

             //        tasks[i].Start();
             //    }

             //    Task.WaitAll(tasks);
             //    timer.Stop();
             //    //Объединение результатов
             //    for (int i = 0; i < count; i++)
             //    {
             //        Result.AddRange(tasks[i].Result);
             //    }
             //    //-------------------------------------------------
             //    // Завершение параллельного поиска
             //    //-------------------------------------------------


             //    timer.Stop();
             //    //Вывод результатов
             //    this.textBox4.Text = timer.Elapsed.ToString();
             //    //Вычисленное количество потоков
             //    this.textBox7.Text = count.ToString();
             //    //Начало обновления списка результатов
             //    this.listBox1.BeginUpdate();
             //    //Очистка списка
             //    this.listBox1.Items.Clear();
             //    //Вывод результатов поиска
             //    foreach (var x in Result)
             //    {
             //        string temp = x.word + "(расстояние=" + x.dist.ToString() + " поток=" + x.ThreadNum.ToString() + ")";
             //        this.listBox1.Items.Add(temp);
             //    }
             //    //Окончание обновления списка результатов
             //    this.listBox1.EndUpdate();
             //}
             //else
             //{
             //    MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
             //}
        



























            /*
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
                //List<string> tempList = new List<string>();
                //Stopwatch t = new Stopwatch();
                //t.Start();

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
            */

       
        
        
        
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

        private void label8_Click(object sender, EventArgs e)
        {

        }




        private void button2_Click_2(object sender, EventArgs e)
        {
            string word = this.textBox3.Text.Trim();
            //Если слово для поиска не пусто
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
                int ThreadCount;
                if (!int.TryParse(this.textBox6.Text.Trim(), out ThreadCount))
                {
                    MessageBox.Show("Необходимо указать количество потоков");
                    return;
                }
                Stopwatch timer = new Stopwatch();
                timer.Start();


                //-------------------------------------------------
                // Начало параллельного поиска
                //-------------------------------------------------

                //Результирующий список
                List<ParallelSearchResult> Result = new List<ParallelSearchResult>();
                //Деление списка на фрагменты для параллельного запуска в потоках
                List<MinMax> arrayDivList = SubArrays.DivideSubArrays(0, list.Count, ThreadCount);
                int count = arrayDivList.Count;

                //Количество потоков соответствует количеству фрагментов массива
                Task<List<ParallelSearchResult>>[] tasks = new Task<List<ParallelSearchResult>>[count];
                //Запуск потоков
                for (int i = 0; i < count; i++)
                {
                    //Создание временного списка, чтобы потоки не работали параллельно с одной коллекцией
                    List<string> tempTaskList = list.GetRange(arrayDivList[i].Min, arrayDivList[i].Max - arrayDivList[i].Min);

                    tasks[i] = new Task<List<ParallelSearchResult>>(ArrayThreadTask, new ParallelSearchThreadParam()
                    {
                        tempList = tempTaskList,
                        maxDist = maxDist,
                        ThreadNum = i,
                        wordPattern = word
                    });

                    tasks[i].Start();
                }

                Task.WaitAll(tasks);
                timer.Stop();
                //Объединение результатов
                for (int i = 0; i < count; i++)
                {
                    Result.AddRange(tasks[i].Result);
                }
                //-------------------------------------------------
                // Завершение параллельного поиска
                //-------------------------------------------------


                timer.Stop();
                //Вывод результатов
                this.textBox4.Text = timer.Elapsed.ToString();
                //Вычисленное количество потоков
                this.textBox7.Text = count.ToString();
                //Начало обновления списка результатов
                this.listBox1.BeginUpdate();
                //Очистка списка
                this.listBox1.Items.Clear();
                //Вывод результатов поиска
                foreach (var x in Result)
                {
                    string temp = x.word + " (расстояние = " + x.dist.ToString() + " поток = " + x.ThreadNum.ToString() + ")";
                    this.listBox1.Items.Add(temp);
                }
                //Окончание обновления списка результатов
                this.listBox1.EndUpdate();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
            }
        }




        private void button3_Click(object sender, EventArgs e)
        {
             //Имя файла отчета
             string TempReportFileName = "Report_" +
             DateTime.Now.ToString("dd_MM_yyyy_hhmmss");
             //Диалог сохранения файла отчета
             SaveFileDialog fd = new SaveFileDialog();
             fd.FileName = TempReportFileName;
             fd.DefaultExt = ".html";
             fd.Filter = "HTML Reports|*.html";
             if (fd.ShowDialog() == DialogResult.OK)
             {
                 string ReportFileName = fd.FileName;
                 //Формирование отчета
                 StringBuilder b = new StringBuilder();

                 b.AppendLine("<html>");
                 b.AppendLine("<head>");
                 b.AppendLine("<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'/>");
                 b.AppendLine("<title>" + "Отчет: " + ReportFileName + "</title>");
                 b.AppendLine("</head>");

                 b.AppendLine("<body>");
                 b.AppendLine("<h1>" + "Отчет: " + ReportFileName + "</h1>");
                 b.AppendLine("<table border='1'>");

                 b.AppendLine("<tr>");
                 b.AppendLine("<td>Время чтения из файла</td>");
                 b.AppendLine("<td>" + this.textBox1.Text + "</td>");
                 b.AppendLine("</tr>");

                 b.AppendLine("<tr>");
                 b.AppendLine("<td>Количество уникальных слов в файле</td>");
                 b.AppendLine("<td>" + this.textBox2.Text + "</td>");
                 b.AppendLine("</tr>");

                 b.AppendLine("<tr>");
                 b.AppendLine("<td>Слово для поиска</td>");
                 b.AppendLine("<td>" + this.textBox3.Text + "</td>");
                 b.AppendLine("</tr>");

                 b.AppendLine("<tr>");
                 b.AppendLine("<td>Максимальное расстояние</td>");
                 b.AppendLine("<td>" + this.textBox5.Text + "</td>");
                 b.AppendLine("</tr>");

                 b.AppendLine("<tr>");
                 b.AppendLine("<td>Количество потоков</td>");
                 b.AppendLine("<td>" + this.textBox6.Text + "</td>");
                 b.AppendLine("</tr>");

                 b.AppendLine("<tr>");
                 b.AppendLine("<td>Время поиска</td>");
                 b.AppendLine("<td>" + this.textBox4.Text + "</td>");
                 b.AppendLine("</tr>");

                 b.AppendLine("<tr valign='top'>");
                 b.AppendLine("<td>Найденные слова</td>");
                 b.AppendLine("<td>");
                 b.AppendLine("<ul>");

                 foreach (var x in this.listBox1.Items)
                 {
                     b.AppendLine("<li>" + x.ToString() + "</li>");
                 }
                b.AppendLine("</ul>");
                b.AppendLine("</td>");
                b.AppendLine("</tr>");

                b.AppendLine("</table>");
                b.AppendLine("</body>");
                b.AppendLine("</html>");

                //Сохранение файла
                File.AppendAllText(ReportFileName, b.ToString());
                MessageBox.Show("Отчет сформирован. Файл: " + ReportFileName);
            }
        }


    }
}
