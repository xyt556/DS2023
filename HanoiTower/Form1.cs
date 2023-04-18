using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HanoiTower
{
    public partial class Form1 : Form
    {
        private int numOfDisks = 3;
        private Tower[] towers = new Tower[3];

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                towers[i] = new Tower(i, this);
            }
            Reset();
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
        }

        private void Reset()
        {
            for (int i = 0; i < 3; i++)
            {
                towers[i].Clear();
            }
            for (int i = numOfDisks; i > 0; i--)
            {
                towers[0].Add(i);
            }
            DrawDisks();
        }

        private void DrawDisks()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(this.BackColor);
            for (int i = 0; i < 3; i++)
            {
                towers[i].Draw(g);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                if (towers[i].IsInside(e.Location))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        towers[i].Select();
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        towers[i].Release();
                    }
                    break;
                }
            }
            DrawDisks();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numOfDisks = trackBar.Value;
            Reset();
        }
    }

    public class Tower
    {
        private int index;
        private Form1 form;
        private int x;
        private int y;
        private int width;
        private int height;
        private int selectedDisk = -1;
        private int[] disks = new int[10];

        public Tower(int index, Form1 form)
        {
            this.index = index;
            this.form = form;
            this.x = 10 + index * 110;
            this.y = 10;
            this.width = 100;
            this.height = 200;
        }
        public void Clear()
        {
            for (int i = 0; i < disks.Length; i++)
            {
                disks[i] = 0;
            }
        }
        public void Release()
        {
            if (selectedDisk != -1)
            {
                for (int i = 0; i < disks.Length; i++)
                {
                    if (disks[i] == 0)
                    {
                        disks[i] = selectedDisk;
                        selectedDisk = -1;
                        break;
                    }
                }
            }
        }
        public void Select()
        {
            if (selectedDisk == -1)
            {
                for (int i = disks.Length - 1; i >= 0; i--)
                {
                    if (disks[i] != 0)
                    {
                        selectedDisk = disks[i];
                        disks[i] = 0;
                        break;
                    }
                }
            }
        }
        public void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Black, x, y, width, height);
            for (int i = 0; i < disks.Length; i++)
            {
                if (disks[i] != 0)
                {
                    int diskWidth = disks[i] * 10;
                    int diskX = x + (width - diskWidth) / 2;
                    int diskY = y + height - (i + 1) * 20;
                    g.FillRectangle(Brushes.Red, diskX, diskY, diskWidth, 15);
                    g.DrawRectangle(Pens.Black, diskX, diskY, diskWidth, 15);
                }
            }
        }
        public bool IsInside(Point p)
        {
            return p.X >= x && p.X <= x + width && p.Y >= y && p.Y <= y + height;
        }
        public void Add(int disk)
        {
            for (int i = 0; i < disks.Length; i++)
            {
                if (disks[i] == 0)
                {
                    disks[i] = disk;
                    break;
                }
            }
        }
    }
}