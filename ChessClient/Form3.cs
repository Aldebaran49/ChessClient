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
    public partial class Form3 : Form
    {
        board Board;
        
        public Form3()
        {
            InitializeComponent();
            
            //Init();
            
            
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            Board = new board(this);
            
            
        }
       
       
        public  async void UpdateBoard(string msg, int x)
        {
            if(x == 0)
            {
                Board.AnotherXod(msg);

            }
            else if(x == 1)
            {
                string prom = Box2("Выберите фигуру","Rook,Bishop,Queen,Knight");
                
                if(prom != "Rook"&& prom != "Bishop"&& prom != "Queen"&& prom != "Knight")
                {
                    prom = "Queen";
                }
                prom = "F" + prom;Console.WriteLine(prom);
                await globalVar.conn.SendOneMessageAsync(prom);               
            }
            
            
        }
        
        public void closeFrom()
        {
            
            Invoke(() => this.Hide());
            
            FForms.F2 = new Form2();
            
            FForms.F2.ShowDialog();
            
            Invoke(() => this.Close());
            
        }

        public async void Box1(string msg)
        {
            DialogResult result = MessageBox.Show(msg, "MessageBox Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                // Присваиваем значение переменной
                globalVar.conn.SendOneMessageAsync("terminated1");
                // Тут вы можете добавить дополнительную логику
            }
        }
        public string Box2(string title,string prompt)
        {
            Form promptForm = new Form();
            promptForm.Width = 500;
            promptForm.Height = 300;
            promptForm.Text = title;

            System.Windows.Forms.Label textLabel = new System.Windows.Forms.Label() { Left = 50, Top = 20, Text = prompt };
            TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Height = 50, Top = 70, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { promptForm.Close(); };

            promptForm.Controls.Add(textBox);
            promptForm.Controls.Add(confirmation);
            promptForm.Controls.Add(textLabel);
            promptForm.AcceptButton = confirmation;
            return promptForm.ShowDialog() == DialogResult.OK ? textBox.Text : "Queen";
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
