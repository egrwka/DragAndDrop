using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DragAndDrop
{
    public partial class Form1 : Form
    {
        Rectangle Rectangle = new Rectangle(10, 10, 200, 100);
        Rectangle Cirkle = new Rectangle(220, 10, 150, 150);
        Rectangle Square = new Rectangle(380, 10, 150, 150);
        bool RectangleClicked, CircleClicked, SquareClicked = false;
        int RectangleX, CircleX2, SquareX3, RectangleY, CircleY2, SquareY3 = 0;


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            RectangleClicked = false;
            CircleClicked = false;
            SquareClicked = false;
            if (LastClicked == 2)
            {
                if ((label2.Location.X < Cirkle.X + Cirkle.Width) && (label2.Location.X > Cirkle.X))
                {
                    if ((label2.Location.Y < Cirkle.Y + Cirkle.Height) && (label2.Location.Y > Cirkle.Y))
                    {
                        X = Cirkle.X;
                        Y = Cirkle.Y;
                        dX = CircleX2;
                        dY = CircleY2;
                        Cirkle.X = Rectangle.X;
                        Cirkle.Y = Rectangle.Y;
                        CircleX2 = RectangleX;
                        CircleY2 = RectangleY;

                        Rectangle.X = X;
                        Rectangle.Y = Y;
                        RectangleX = dX;
                        RectangleY = dY;
                    }
                }
            }
            if (LastClicked == 3)
            {
                if ((label2.Location.X < Square.X + Square.Width) && (label2.Location.X > Square.X))
                {
                    if ((label2.Location.Y < Square.Y + Square.Height) && (label2.Location.Y > Square.Y))
                    {
                        X = Square.X;
                        Y = Square.Y;
                        dX = SquareX3;
                        dY = SquareY3;
                        Square.X = Cirkle.X;
                        Square.Y = Cirkle.Y;
                        SquareX3 = CircleX2;
                        SquareY3 = CircleY2;

                        Cirkle.X = X;
                        Cirkle.Y = Y;
                        CircleX2 = dX;
                        CircleY2 = dY;
                    }
                }
            }
            if (LastClicked == 1)
            {
                if ((label2.Location.X < Rectangle.X + Rectangle.Width) && (label2.Location.X > Rectangle.X))
                {
                    if ((label2.Location.Y < Rectangle.Y + Rectangle.Height) && (label2.Location.Y > Rectangle.Y))
                    {
                        X = Rectangle.X;
                        Y = Rectangle.Y;
                        dX = RectangleX;
                        dY = RectangleY;
                        Rectangle.X = Square.X;
                        Rectangle.Y = Square.Y;
                        RectangleX = SquareX3;
                        RectangleY = SquareY3;

                        Square.X = X;
                        Square.Y = Y;
                        SquareX3 = dX;
                        SquareY3 = dY;
                    }
                }
                pictureBox1.Invalidate();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.X < Rectangle.X + Rectangle.Width) && (e.X > Rectangle.X))
            {
                if ((e.Y < Rectangle.Y + Rectangle.Height) && (e.Y > Rectangle.Y))
                {
                    RectangleClicked = true;

                    RectangleX = e.X - Rectangle.X;
                    RectangleY = e.Y - Rectangle.Y;
                    //LastClicked = 1;
                }
            }
            if ((e.X < Cirkle.X + Cirkle.Width) && (e.X > Cirkle.X))
            {
                if ((e.Y < Cirkle.Y + Cirkle.Height) && (e.Y > Cirkle.Y))
                {
                    CircleClicked = true;

                    CircleX2 = e.X - Cirkle.X;
                    CircleY2 = e.Y - Cirkle.Y;
                    //LastClicked = 2;
                }
            }
            if ((e.X < Square.X + Square.Width) && (e.X > Square.X))
            {
                if ((e.Y < Square.Y + Square.Height) && (e.Y > Square.Y))
                {
                    SquareClicked = true;

                    SquareX3 = e.X - Square.X;
                    SquareY3 = e.Y - Square.Y;
                    //LastClicked = 3;
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Red, Cirkle);
            e.Graphics.FillRectangle(Brushes.Blue, Square);
            e.Graphics.FillRectangle(Brushes.Yellow, Rectangle);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (CircleClicked)
            {
                Cirkle.X = e.X - CircleX2;
                Cirkle.Y = e.Y - CircleY2;
                pictureBox1.Invalidate();
            }
            if (RectangleClicked)
            {
                Rectangle.X = e.X - RectangleX;
                Rectangle.Y = e.Y - RectangleY;
                pictureBox1.Invalidate();
            }
            if (SquareClicked)
            {
                Square.X = e.X - SquareX3;
                Square.Y = e.Y - SquareY3;
                pictureBox1.Invalidate();
            }
            if ((label4.Location.X < Square.X + Square.Width) && (label4.Location.X > Square.X))
            {
                if ((label4.Location.Y < Square.Y + Square.Height) && (label4.Location.Y > Square.Y))
                {
                    label1.Text = "Синий";
                    label2.Text = "Квадрат";
                    label3.Text = "Синий квадрат";
                }
            }
            else if ((label4.Location.X < Cirkle.X + Cirkle.Width) && (label4.Location.X > Cirkle.X))
            {
                if ((label4.Location.Y < Cirkle.Y + Cirkle.Height) && (label4.Location.Y > Cirkle.Y))
                {
                    label1.Text = "Красный";
                    label2.Text = "Круг";
                    label3.Text = "Красный круг";
                }
            }
            else if ((label4.Location.X < Rectangle.X + Rectangle.Width) && (label4.Location.X > Rectangle.X))
            {
                if ((label4.Location.Y < Rectangle.Y + Rectangle.Height) && (label4.Location.Y > Rectangle.Y))
                {
                    label1.Text = "Жёлтый";
                    label2.Text = "Прямоугольник";
                    label3.Text = "Жёлтый прямоугольник";
                }
            }
            else
            {
                label1.Text = "Вид";
                label2.Text = "Форма";
                label3.Text = "Информация";
            }
        }

        int X, Y, dX, dY;
        int LastClicked = 0;

        

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
