using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessClient
{
    public partial class Form2 : Form
    {
        bool temp = false;
        public Form2()
        {
            InitializeComponent();

        }

        private async void buttonEnterQueue_Click(object sender, EventArgs e)
        {
            await globalVar.conn.SendOneMessageAsync("qe");
            //Console.WriteLine("!*1");
        }
        public void QueueConfirmed()
        {
            labelQueueState.Text = "В очереди";
        }
        public void GameStart()
        {
            labelQueueState.Text = "Игра началась";
            BeginInvoke(() => FForms.F2.closeForm());
            //Console.WriteLine("3 окно");
        }
        public void Restart()
        {
            //labelQueueState.Text = "Вне очереди";
        }
        public void closeForm()
        {
            //Console.WriteLine("Переходим к другой форме");
            FForms.F2.Box();
            if (temp == false)
            {
                globalVar.conn.SendOneMessageAsync("terminated");
                globalVar.conn.terminationCommencing = true;
                return;
            }
            ClientClass.startedGame = true;
            Invoke(() => this.Hide());
            //this.Hide();
            //Console.WriteLine("1");
            FForms.F3 = new Form3();
            FForms.F3.ShowDialog();

            //Console.WriteLine("2");
            //FForms.F3.Init();
            //Console.WriteLine("3");

            Invoke(() => this.Close());
            //this.Close();

            // Console.WriteLine("4");
        }
        public async void Box()
        {
            string message = "Вы готовы играть?";
            string caption = "Готов";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.Yes)
            {
                //тут надо отправить сообщение серваку и чтоб игрок ждал ответа, ответ от сервака клиент получит тогда
                //и только тогда когда оба клиента отправили положительный ответ иначе выход из комнаты
                if (globalVar.conn.terminationCommencing == false)
                {
                    temp = true;
                }
                else
                    globalVar.conn.terminationCommencing = true;
            }
            else if (result == DialogResult.No)
            {
                globalVar.conn.SendOneMessageAsync("terminated");
                temp = false;

            }
            else
            {

            }
        }

        private void labelQueueState_Click(object sender, EventArgs e)
        {

        }
    }
}
