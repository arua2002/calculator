using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace калькулятор
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        Button[,] but = new Button[5,3];
        List<string> ty = new List<string>();
        Button b = new Button();
        bool a = true;
        TextBox text = new TextBox();
        string[] items = { "*", "/", "+", "-"};
        List<string> mas = new List<string>();
        void sozdanie_but()
        {
            int num = 0;
            int x = 25,y=55;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    num++;
                    but[i, j] = new Button();
                    if (num < 10)
                    {
                        but[i, j].Text = num.ToString();
                        but[i, j].Location = new Point(x + (j * 40), y + (i * 40));
                        but[i, j].Size = new Size(40, 40);
                    }
                    else
                    {
                        switch (num)
                        {
                            case 10:
                                but[i, j].Text = (0).ToString();
                                but[i, j].Location = new Point(x + (1 * 40), y + (i * 40));
                                but[i, j].Size = new Size(40, 40);
                                break;

                            case 11:
                                but[i, j].Text = "/";
                                but[i, j].Location = new Point(x + (3 * 40), y + (0 * 40));
                                but[i, j].Size = new Size(40, 40);
                                break;
                            case 12:
                                but[i, j].Text = "*";
                                but[i, j].Location = new Point(x + (3 * 40), y + (1 * 40));
                                but[i, j].Size = new Size(40, 40);
                                break;
                            case 13:
                                but[i, j].Text = "-";
                                but[i, j].Location = new Point(x + (3 * 40), y + (2 * 40));
                                but[i, j].Size = new Size(40, 40);
                                break;
                            case 14:
                                but[i, j].Text = "+";
                                but[i, j].Location = new Point(x + (3 * 40), y + (3 * 40));
                                but[i, j].Size = new Size(40, 40);
                                break;
                            case 15:
                                but[i, j].Text = "=";
                                but[i, j].Location = new Point(x + (j * 40), y + (3 * 40));
                                but[i, j].Size = new Size(40, 40);
                                break;
                        }
                    }
                    but[i, j].Click += new EventHandler(but_clk);
                    but[i, j].BackColor = Color.AntiqueWhite;
                    Controls.Add(but[i, j]);
                }
            }
            b.Text = ",";
            b.Location = new Point(x + (0 * 40), y + (3 * 40));
            b.Size = new Size(40, 40);
            b.Click += new EventHandler(but_clk);
            b.BackColor = Color.AntiqueWhite;
            Controls.Add(b);    
        }
        void sozd_text()
        {
            text.Enabled = false;
            text.Location = new Point(25,30);
            text.Size = new Size(160,60);
            Controls.Add(text);
        }
        double math(List<string>s)//работать должна будет с / * - +
        {
            double otvet = 0;
            string[] n = new string[s.Count];//получение чисел
            List<string> n1 = new List<string>();
            int r = 0;
            List<string> w = new List<string>();//получение действий
            List<string> ew = new List<string>();//соединение массивов
            bool s1 = false;
            try
            {
                foreach (var i in s)
                {
                    for (int j = 0; j < items.Length; j++) if (i == items[j]) s1 = true;
                    if (s1 == false)
                    {
                        n[r] += i;
                    }
                    else
                    {
                        w.Add(i);
                        r++;
                        s1 = false;
                    }
                }
                foreach (var i in n) if (i != null) n1.Add(i);
                int qw = 0, qw1 = 0;
                for (int i = 0; i < n1.Count + w.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        ew.Add(n1[qw]);
                        qw++;
                    }
                    else
                    {
                        ew.Add(w[qw1]);
                        qw1++;
                    }
                }
                ty = ew;
                while (ty.Count > 3)
                {
                        a = true;
                        ty = qer(ty);
                }
                otvet = rech(Convert.ToDouble(ty[0]), Convert.ToDouble(ty[2]),ty[1]);
            }
            catch (Exception)
            {
                text.Text = "Erorr";
            }
            
            return otvet;
        }
        List<string> qer(List<string>obh)
        {
            double a;
            bool a1 = true,g = false,h=false;
            List<string> s = new List<string>();
            foreach (var i in obh)
                {
                    if (i == "*" || i == "/") g = true;// * /
                    if (i == "+" || i == "-") h = true; // +-
                }
          
            try
            {
                if (g && h)
                {
                    for (int j = 0; j < obh.Count; j++)
                    {
                        for (int i = 0; i < items.Length / 2; i++)
                        {
                            if (obh[j] == items[i] && a1 == true)
                            {
                                a = rech(Convert.ToDouble(obh[j - 1]), Convert.ToDouble(obh[j + 1]), obh[j]);
                                obh.RemoveAt(j - 1);
                                obh.RemoveAt(j - 1);
                                obh[j - 1] = a.ToString();
                                s = obh;
                                a1 = false;
                                break;
                            }
                        }
                    }
                }
                else if (g)
                {
                    for (int j = 0; j < obh.Count; j++)
                    {
                        for (int i = 0; i < items.Length / 2; i++)
                        {
                            if (obh[j] == items[i] && a1 == true)
                            {
                                a = rech(Convert.ToDouble(obh[j - 1]), Convert.ToDouble(obh[j + 1]), obh[j]);
                                obh.RemoveAt(j - 1);
                                obh.RemoveAt(j - 1);
                                obh[j - 1] = a.ToString();
                                s = obh;
                                a1 = false;
                                break;
                            }
                        }
                    }
                }
                else if (h)
                {
                    for (int j = 0; j < obh.Count; j++)
                    {
                        for (int i = 0; i < items.Length; i++)
                        {
                            if (obh[j] == items[i] && a1 == true)
                            {
                                a = rech(Convert.ToDouble(obh[j - 1]), Convert.ToDouble(obh[j + 1]), obh[j]);
                                obh.RemoveAt(j - 1);
                                obh.RemoveAt(j - 1);
                                obh[j - 1] = a.ToString();
                                s = obh;
                                a1 = false;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                text.Text = "Error";
            }
            
            return s;
        }
        double rech(double a, double b,string s)
        {
            double otver = 0;
            switch (s)
            {
                case "*":
                    otver = a * b;
                    break;
                case "/":
                    otver = a / b;
                    break;
                case "+":
                    otver = a + b;
                    break;
                case "-":
                    otver = a - b;
                    break;
            }
                return otver;
        }
        void but_clk(object sender, EventArgs e)
        {
            if (a)
            {
                text.Text += (sender as Button).Text;
                if (text.Text[text.Text.Length - 1] == '=')
                {
                    a = false;
                }
                else mas.Add((sender as Button).Text);
            }
            if (a == false)
            {
                if (mas.Count > 10) text.Text = math(mas).ToString();
                else text.Text += math(mas).ToString();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            sozdanie_but();
            sozd_text();
        }
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            text.Clear();
            mas.Clear();
            ty.Clear();        
            a = true;
        }
        private void отменаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                a = true;
                mas.RemoveAt(mas.Count - 1);
                text.Text = "";
                foreach (var item in mas)
                {
                    text.Text += item;
                }
            }
            catch (Exception)
            {
                text.Text = "тут пусто как и в твоей голове";
            }        
        }
    }
}
