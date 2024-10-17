using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
            button2.Visible = false;
            label2.Visible = false;
        }

        private bool IsTriangle(int storonaA, int storonaB, int storonaC) 
        {
            return (storonaA + storonaB > storonaC) && (storonaA + storonaC > storonaB) && (storonaB + storonaC > storonaA);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int storonaA = Convert.ToInt32(textBox1.Text);
            int storonaB = Convert.ToInt32(textBox2.Text);
            int storonaC = Convert.ToInt32(textBox3.Text);

            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;

            if (!IsTriangle(storonaA, storonaB, storonaC))
            {
                label1.Visible = false;
                label2.Visible = true;
                button1.Visible = false;
                button2.Visible = true;
                return; // Выход из метода, если треугольник не существует
            }

            // Если треугольник существует, проверяем его тип
            if ((storonaA == storonaB) && (storonaB == storonaC))
            {
                label1.Text = "Треугольник равносторонний";
            }
            else if (storonaA == storonaB || storonaA == storonaC || storonaB == storonaC)
            {
                label1.Text = "Треугольник равнобедренный";
            }
            else
            {
                label1.Text = "Треугольник разносторонний";
            }

            button1.Visible = false;
            button2.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            button1 .Visible = true;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;

            label2 .Visible = false;

            label1 .Visible = true;
            label1.Text = "Введите стороны треугольника";

        }

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли символ не цифрой и не управляющим символом 
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
    }
}
