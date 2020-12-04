using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4._2_OOP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //Обработчик события "Изменение значения компонента"
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //Проверка значения на четность
            if (numericUpDown1.Value % 2 == 1)
                numericUpDown1.Value = numericUpDown1.Value + 1;
            //Обновляем вручную значения всех остальных компонентов
            progressBar1.Value = Decimal.ToInt32(numericUpDown1.Value);
            textBox1.Text = numericUpDown1.Value.ToString();
        }

        //Обработчик события "Нажатие на клавишу"
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //При нажатии на клавишу "Enter"
            if (e.KeyCode == Keys.Enter)
                //Проверка значения на четность
                if (Int32.Parse(textBox1.Text) % 2 == 1)
                    textBox1.Text = (Int32.Parse(textBox1.Text) + 1).ToString();
            //Обновляем вручную значения всех остальных компонентов
            numericUpDown1.Value = Int32.Parse(textBox1.Text);
            progressBar1.Value = Int32.Parse(textBox1.Text);

        }
        //Обработчик события "Перемещение курсора мыши по компоненту"
        private void progressBar1_MouseMove(object sender, MouseEventArgs e)
        {
            progressBar1.Value = (int)(e.X * 5.586592);

            //Проверка значения на четность
            if (progressBar1.Value%2==1)
            {
                //Обновляем вручную значения всех остальных компонентов
                textBox1.Text = (progressBar1.Value + 1).ToString();
                numericUpDown1.Value = progressBar1.Value + 1;
            }

            else
            {
                //Обновляем вручную значения всех остальных компонентов
                textBox1.Text = (progressBar1.Value).ToString();
                numericUpDown1.Value = progressBar1.Value;
            }
        }

        //Обработчик события "Изменение значения компонента"
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown2.Value = numericUpDown2.Value;
            //Обновляем вручную значения всех остальных компонентов
            button1.Size = new System.Drawing.Size (Decimal.ToInt32(numericUpDown2.Value), Decimal.ToInt32(numericUpDown2.Value));
            textBox2.Text = numericUpDown2.Value.ToString();
        }

        //Обработчик события "Нажатие на клавишу"
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //При нажатии на клавишу "Enter"
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Text = (Int32.Parse(textBox2.Text)).ToString();
                //Обновляем вручную значения всех остальных компонентов
                numericUpDown2.Value = Int32.Parse(textBox2.Text);
                button1.Size = new System.Drawing.Size(Int32.Parse(textBox2.Text), Int32.Parse(textBox2.Text));
            }              
        }

        //Обработчик события "Нажатие на компонент"
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Size = new System.Drawing.Size(this.button1.Width + 1, this.button1.Height + 1);
            //Обновляем вручную значения всех остальных компонентов
            textBox2.Text = button1.Width.ToString();
            numericUpDown2.Value = button1.Width;
        }
    }
}
