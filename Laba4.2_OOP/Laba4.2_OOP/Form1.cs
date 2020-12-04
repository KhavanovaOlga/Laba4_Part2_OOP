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
        Model model; //Ссылки на
        Model model1; //модель
        public MainForm()
        {
            InitializeComponent();
            model = new Model(); //Создаем модель 1-й группы
            //Обновление компонент 1
            model.observers += new System.EventHandler(this.UpdateFromModel);
            model1 = new Model(); //Создаем модель 2-ой группы
            //Обновление компонент 2
            model1.observers += new System.EventHandler(this.UpdateFromModel1);
            model1.setValue(30);
        }

        //Обработчик события "Изменение значения компонента"
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            //При изменении значения компонента, передаем его в модель
            model.setValue(Decimal.ToInt32(numericUpDown1.Value));      
        }

        //Обработчик события "Нажатие на клавишу"
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                model.setValue(Int32.Parse(textBox1.Text)); 
            }

        }
        //Обработчик события "Перемещение курсора мыши по компоненту"
        private void progressBar1_MouseMove(object sender, MouseEventArgs e)
        {
            model.setValue((int)(e.X * 5.586592));

        }

        //Обновление значений компонент 1-ой группы на форме
        private void UpdateFromModel(object sender, EventArgs e)
        {
            textBox1.Text = model.getValue().ToString();
            numericUpDown1.Value = model.getValue();
            progressBar1.Value = model.getValue();
        }

        //Обработчик события "Изменение значения компонента"
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            //При изменении значения компонента, передаем его в модель
            model1.setValue1(Decimal.ToInt32(numericUpDown2.Value));
        }

        //Обработчик события "Нажатие на клавишу"
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            //При нажатии на клавишу "Enter"
            if (e.KeyCode == Keys.Enter)
            {
                //При изменении значения компонента, передаем его в модель
                model1.setValue1(Int32.Parse(textBox2.Text));
            }              
        }

        //Обработчик события "Нажатие на компонент"
        private void button1_Click(object sender, EventArgs e)
        {
            //При изменении значения компонента, передаем его в модель
            model1.setValue1((model1.getValue() + 1));
        }

        //Обновление значений компонент 2-ой группы на форме
        private void UpdateFromModel1(object sender, EventArgs e)
        {
            textBox2.Text = model1.getValue().ToString();
            numericUpDown2.Value = model1.getValue();
            button1.Size = new System.Drawing.Size(model1.getValue(), model1.getValue());
        }

    }

    public class Model
    {
        private int value; //Значения компонента
        public System.EventHandler observers; //Событие

        //Функция для изменения значения компонента 1-ой группы(четные)
        public void setValue(int value)
        {
            if (value % 2 == 1)
                this.value = value + 1;
            else
                this.value = value;
            observers.Invoke(this, null); //Вызов обновления
        }

        //Функция для изменения значения компонента 2-ой группы(любые)
        public void setValue1(int value)
        {
                this.value = value;
            observers.Invoke(this, null);
        }

        //Функция для возвращения значения компонента при обновлении
        public int getValue()
        {
            return value;
        }
    }
}
