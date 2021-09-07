using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chessDzi
{
    public partial class Form1 : Form
    {

        field[,] pics;
        List<field> pics2 = new List<field>();
        private int min;

        Graphics g;



        Button btn1;


        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pics = new field[8, 8];

           



            
            for(int i = 0;i < 8; i++)
            {
                for(int j = 0;j < 8; j++)
                {
                    pics[i, j] = new field();
                    pics[i, j].Location = new Point(200 + 80 * i,100 + 80 * j);
                    pics[i, j].Size = new Size(80, 80);
                    if (i % 2 == 0)
                    {
                        if(j % 2 == 0)
                        {
                            pics[i, j].BackColor = Color.Black;
                        }
                        if (j % 2 != 0)
                            pics[i, j].BackColor = Color.White;
                    }
                    if(i % 2!= 0)
                    {
                        if (j % 2 != 0)
                            pics[i, j].BackColor = Color.Black;
                        if (j % 2 == 0)
                            pics[i, j].BackColor = Color.White;
                    }
                    
                    Controls.Add(pics[i, j]);
                }
            }
            pics[3, 6].BackColor = Color.White;
          
            pics[3, 6].Image = new Bitmap(Properties.Resources.kon_chernyj_png);

            pics[3, 6].SizeMode = PictureBoxSizeMode.StretchImage;

            btn1 = new Button();
            btn1.Text = "Start";
            btn1.Location = new Point(Width - 200, 40);
            Controls.Add(btn1);
            btn1.Click += Btn1_Click;
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Queue<field> queue = new Queue<field>();
            pics[3, 6].i = 3;
            pics[3,6].j = 6;
            queue.Enqueue(pics[3, 6]);
            pics[3, 6].isChecked = true;

            pics[3, 6].BackColor = Color.Green;
            pics[3, 6].Image = new Bitmap(pics[3, 6].Width, pics[3, 6].Height);

            g = Graphics.FromImage(pics[3, 6].Image);
            g.DrawString("1", Font, new SolidBrush(Color.Black), 20, 20);

            int c = 2;
           
            while (c < 65) {

                for (int i = 0; i < 1; i++)
                {
                    var l = queue.Dequeue();
                    if (l.i + 1 >= 0 && l.i + 1 < 8 && l.j - 2 >= 0 && l.j - 2 < 8 && pics[l.i + 1, l.j - 2].isChecked == false)
                    {
                        queue.Enqueue(pics[l.i + 1, l.j - 2]);
                        pics[l.i + 1, l.j - 2].i = l.i + 1;
                        pics[l.i + 1, l.j - 2].j = l.j - 2;

                    }

                    if (l.i + 2 >= 0 && l.i + 2 < 8 && l.j - 1 >= 0 && l.j - 1 < 8 && pics[l.i + 2, l.j - 1].isChecked == false)
                    {
                        queue.Enqueue(pics[l.i + 2, l.j - 1]);
                        pics[l.i + 2, l.j - 1].i = l.i + 2;
                        pics[l.i + 2, l.j - 1].j = l.j - 1;
                    }
                    if (l.i - 1 >= 0 && l.i - 1 < 8 && l.j - 2 >= 0 && l.j - 2 < 8 && pics[l.i - 1, l.j - 2].isChecked == false)
                    {
                        queue.Enqueue(pics[l.i - 1, l.j - 2]);
                        pics[l.i - 1, l.j - 2].i = l.i - 1;
                        pics[l.i - 1, l.j - 2].j = l.j - 2;
                    }
                    if (l.i - 2 >= 0 && l.i - 2 < 8 && l.j + 1 >= 0 && l.j + 1 < 8 && pics[l.i - 2, l.j + 1].isChecked == false)
                    {
                        queue.Enqueue(pics[l.i - 2, l.j + 1]);
                        pics[l.i - 2, l.j + 1].i = l.i - 2;
                        pics[l.i - 2, l.j + 1].j = l.j + 1;
                    }
                    if (l.i + 2 >= 0 && l.i + 2 < 8 && l.j + 1 >= 0 && l.j + 1 < 8 && pics[l.i + 2, l.j + 1].isChecked == false)
                    {
                        queue.Enqueue(pics[l.i + 2, l.j + 1]);
                        pics[l.i + 2, l.j + 1].i = l.i + 2;
                        pics[l.i + 2, l.j + 1].j = l.j + 1;
                    }
                    if (l.i - 2 >= 0 && l.i - 2 < 8 && l.j - 1 >= 0 && l.j - 1 < 8 && pics[l.i - 2, l.j - 1].isChecked == false)
                    {
                        queue.Enqueue(pics[l.i - 2, l.j - 1]);
                        pics[l.i - 2, l.j - 1].i = l.i - 2;
                        pics[l.i - 2, l.j - 1].j = l.j - 1;
                    }
                    if (l.i - 1 >= 0 && l.i - 1 < 8 && l.j + 2 >= 0 && l.j + 2 < 8 && pics[l.i - 1, l.j + 2].isChecked == false)
                    {
                        queue.Enqueue(pics[l.i - 1, l.j + 2]);
                        pics[l.i - 1, l.j + 2].i = l.i - 1;
                        pics[l.i - 1, l.j + 2].j = l.j + 2;
                    }
                    if (l.i + 1 >= 0 && l.i + 1 < 8 && l.j + 2 >= 0 && l.j + 2 < 8 && pics[l.i + 1, l.j + 2].isChecked == false)
                    {
                        queue.Enqueue(pics[l.i + 1, l.j + 2]);
                        pics[l.i + 1, l.j + 2].i = l.i + 1;
                        pics[l.i + 1, l.j + 2].j = l.j + 2;
                    }
                }
                
                field[] arr = new field[queue.Count];
                queue.CopyTo(arr, 0);
                while (queue.Count > 0)
                {
                    var element = queue.Dequeue();

                    if (element.i + 1 >= 0 && element.i + 1 < 8 && element.j - 2 >= 0 && element.j - 2 < 8)
                    {
                        if (pics[element.i + 1, element.j - 2].isChecked == false)
                        {
                            element.count++;
                        }
                    }

                    if (element.i + 2 >= 0 && element.i + 2 < 8 && element.j - 1 >= 0 && element.j - 1 < 8)
                    {
                        if (pics[element.i + 2, element.j - 1].isChecked == false)
                        {
                            element.count++;
                        }
                    }
                    if (element.i - 1 >= 0 && element.i - 1 < 8 && element.j - 2 >= 0 && element.j - 2 < 8)
                    {
                        if (pics[element.i - 1, element.j - 2].isChecked == false)
                        {
                            element.count++;
                        }
                    }
                    if (element.i - 2 >= 0 && element.i - 2 < 8 && element.j + 1 >= 0 && element.j + 1 < 8)
                    {
                        if (pics[element.i - 2, element.j + 1].isChecked == false)
                        {
                            element.count++;
                        }
                    }

                    if (element.i + 2 >= 0 && element.i + 2 < 8 && element.j + 1 < 8 && element.j + 1 >= 0)
                    {
                        if (pics[element.i + 2, element.j + 1].isChecked == false)
                        {
                            element.count++;
                        }
                    }

                    if (element.i - 2 >= 0 && element.i - 2 < 8 && element.j - 1 >= 0 && element.j - 1 < 8)
                    {
                        if (pics[element.i - 2, element.j - 1].isChecked == false)
                        {
                            element.count++;
                        }
                    }

                    if (element.i + 1 >= 0 && element.i + 1 < 8 && element.j + 2 >= 0 && element.j + 2 < 8)
                    {
                        if (pics[element.i + 1, element.j + 2].isChecked == false)
                        {
                            element.count++;
                        }
                    }
                    if (element.i - 1 >= 0 && element.i - 1 < 8 && element.j + 2 >= 0 && element.j + 2 < 8)
                    {
                        if (pics[element.i - 1, element.j + 2].isChecked == false)
                        {
                            element.count++;
                        }
                    }
                  
                }

                int z = 0, y = 0;
                min = arr[0].count;
                foreach (var i in arr)
                {
                    if (i.count > min)
                    {

                    }
                    else
                    {
                        min = i.count;
                        z = i.i;
                        y = i.j;
                    }
                }
                foreach(var j in arr)
                {
                    j.count = 0;
                }

                pics[z, y].isChecked = true;
                pics[z, y].Image = new Bitmap(pics[z, y].Width, pics[z, y].Height);
                g = Graphics.FromImage(pics[z, y].Image);
                g.DrawString($"{c}", Font, new SolidBrush(Color.Black), 20, 20);
                queue.Enqueue(pics[z, y]);

                if (c == 64)
                {
                    pics[z, y].BackColor = Color.Green;
                }
                else
                    pics[z, y].BackColor = Color.Red;
                c++;

                pics2.Add(pics[z, y]);


            }
        }
    }

    
}
