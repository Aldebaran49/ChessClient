namespace ChessClient
{
    public partial class Form1 : Form
    {
        bool mode = false; //false - авторизация, true - регистрация
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {

            try
            {
                if (!mode)
                {
                    authMe();
                }
                if (mode)
                {
                    registerMe();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("НЕТ СОЕДИНЕНИЯ!");
                Console.WriteLine(ex.Message);
            }

        }
        private async Task authMe()
        {
            Console.WriteLine("Запрос на авторизацию с данными: "+ textBoxLogin.Text + " " + textBoxPassword.Text);
            globalVar.conn.connect();
            await globalVar.conn.SendOneMessageAsync("!!" + textBoxLogin.Text + "!" + textBoxPassword.Text);
        }
        private async Task registerMe()
        {
            Console.WriteLine("Запрос на регистрацию с данными: " + textBoxLogin.Text + " " + textBoxPassword.Text);
            globalVar.conn.connect();
            await globalVar.conn.SendOneMessageAsync("!?" + textBoxLogin.Text + "!" + textBoxPassword.Text);
        }
        public void closeForm()
        {
            //Console.WriteLine("Переходим к другой форме");
            BeginInvoke(() => this.Hide());
            //this.Hide();
            //Console.WriteLine("1");
            FForms.F2 = new Form2();
            //Console.WriteLine("2");
            //Invoke(() => this.Close());
            //Task.Run(() => FForms.F2.ShowDialog());
            //BeginInvoke(() => FForms.F2.ShowDialog());
            FForms.F2.ShowDialog();
            //Console.WriteLine("3");
            BeginInvoke(() => this.Close());
            //this.Close();
            //Console.WriteLine("4");
        }

        private void buttonToggleLogin_Click(object sender, EventArgs e)
        {
            mode = false;
            buttonToggleLogin.Enabled = false;
            buttonToggleRegister.Enabled = true;
        }

        private void buttonToggleRegister_Click(object sender, EventArgs e)
        {
            mode = true;
            buttonToggleLogin.Enabled = true;
            buttonToggleRegister.Enabled = false;
        }
    }
}
