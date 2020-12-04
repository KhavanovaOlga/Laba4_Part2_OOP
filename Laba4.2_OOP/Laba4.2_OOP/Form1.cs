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
                textBox1.Text = (progressBar1.Value + 1).ToString();
                numericUpDown1.Value = progressBar1.Value + 1;
            }

            else
            {
                textBox1.Text = (progressBar1.Value).ToString();
                numericUpDown1.Value = progressBar1.Value;
            }
        }
    }
}
