using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            up.Hide();
            down.Hide();
            left.Hide();
            right.Hide();          
        }
        Random rnd = new Random();
        int[,] ads = new int[4, 4];
        private void up_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < 4; a++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int b = 1; b <4; b++)
                    {
                        if (ads[b - 1, a] == ads[b, a])
                        {
                            ads[b - 1, a] *= 2;
                            ads[b, a] = 0;
                        }
                        if (ads[b - 1, a] == 0)
                        {
                            ads[b - 1, a] = ads[b, a];
                            ads[b, a] = 0;
                        }
                    }
                }
            }
            tets();
        }
        private void down_Click(object sender, EventArgs e)
        {
            for (int a = 0; a<4; a++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int b = 2; b >= 0; b--)
                    {
                        if (ads[b + 1, a] == ads[b, a])
                        {
                            ads[b + 1, a] *= 2;
                            ads[b, a] = 0;
                        }
                        if (ads[b + 1, a] == 0)
                        {
                            ads[b + 1, a] = ads[b, a];
                            ads[b, a] = 0;
                        }
                    }
                }
            }
            tets();
        }
        private void right_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < 4; a++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int b = 2; b >=0; b--)
                    {
                        if (ads[a, b +1] == ads[a, b])
                        {
                            ads[a, b + 1] *= 2;
                            ads[a, b] = 0;
                        }
                        if (ads[a, b +1] == 0)
                        {
                            ads[a, b +1] = ads[a, b];
                            ads[a, b] = 0;
                        }
                    }
                }
            }
            tets();
        }
        private void left_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < 4; a++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int b = 1; b < 4; b++)
                    {
                        if (ads[a, b - 1] == ads[a, b])
                        {
                            ads[a, b - 1] *= 2;
                            ads[a, b] = 0;
                        }
                        if (ads[a, b - 1] == 0)
                        {
                            ads[a, b - 1] = ads[a, b];
                            ads[a, b] = 0;
                        }
                    }
                }
            }
            tets();
        }
         public void tets()
        {
            List<int> ts1 = new List<int>();
            List<int> ts2 = new List<int>();
            for (int a = 0; a < 4; a++)
            {
                for (int b = 0; b < 4; b++)
                {
                    if (ads[a, b] == 0)
                    {
                        ts1.Add(a);
                        ts2.Add(b);
                    }
                }
            }
            if (ts1.Count != 0 && ts2.Count != 0)
            {
                int jb = ts1.Count;
                int jk = rnd.Next(0, jb);
                ads[ts1.ElementAt(jk), ts2.ElementAt(jk)] = 2;
                label1.Text = "";
                for (int i = 0; i < 4; i++)
                {
                    for (int b = 0; b < 4; b++)
                    {
                        if (ads[i, b]>99)                      // не нужно в label выводить ...
                        {
                            label1.Text += ads[i, b] + "     ";
                        }
                        if (ads[i, b] > 9&& ads[i, b]<100)
                        {
                            label1.Text += ads[i, b] + "       ";                            
                        }
                        if(ads[i, b]<10)
                        {
                            label1.Text += ads[i, b] + "         ";
                        }                       
                    }
                    label1.Text += "\r\n\r\n";
                }
            }
            else
            {
                label1.Text = "game \r\n over";
                up.Hide();
                down.Hide();
                left.Hide();
                right.Hide();
                button1.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            for (int a =0; a<4;a++)
            {
                for (int y = 0;y<4;y++)
                {
                    ads[a, y] = 0;                }
            }
            int j = rnd.Next(0, 4);
            int k = rnd.Next(0, 4);
            ads[j, k] = 2;
            for (int i = 0; i < 4; i++)
            {
                for (int b = 0; b < 4; b++)
                {
                    label1.Text += ads[i, b] + "         ";
                }
                label1.Text += "\r\n\r\n";
            }
            up.Show();
            down.Show();
            left.Show();
            right.Show();
            button1.Hide();
        }
    }
}
