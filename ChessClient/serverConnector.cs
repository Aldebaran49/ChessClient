using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ChessClient
{
    
    internal class serverConnector
    {
        public string host = "127.0.0.1";
        public int port = 8888;
        public string? userName;
        public StreamReader? Reader = null;
        public StreamWriter? Writer = null;
        public TcpClient client;
        bool isConnected = false;
        public bool terminationCommencing = false;
        public serverConnector()
        {
            client = new TcpClient();
        }
        public async Task connect()
        {
            //Reader = null; Writer = null;
            //isConnected = false;
            if (!client.Connected)
                client = new TcpClient();
            client.Connect(host, port); //подключение клиента
            Reader = new StreamReader(client.GetStream());
            Writer = new StreamWriter(client.GetStream());
            if (Writer is null || Reader is null) return;
            // запускаем новый поток для получения данных
            isConnected = true;
            Console.WriteLine("Подключено успешно");
            Task.Run(() => ReceiveMessageAsync(Reader));
        }

        public bool checkConnection()
        {
            if (Writer is null || Reader is null)
                return false;
            if (!client.Connected)
                return false;
            return true;
        }
        public void reconnect()
        {
            Reader = null; Writer = null; client.Close(); client = new TcpClient();
            connect();
        }
        public async Task SendOneMessageAsync(string msg)
        {
            if (!checkConnection())
            {
                isConnected = false;
                Console.WriteLine("Потеряно соединение");
            }
            if (!isConnected)
            {
                reconnect();
                return;
            }
            Console.WriteLine("Отправка данных");
            await Writer.WriteLineAsync(msg);
            await Writer.FlushAsync();
        }
       
        // получение сообщений
        public async Task ReceiveMessageAsync(StreamReader reader)
        {
            while (true)
            {
                try
                {
                    // считываем ответ в виде строки
                    Console.WriteLine("!!!");
                    string? message = await reader.ReadLineAsync();
                    if (string.IsNullOrEmpty(message))
                    {
                        Console.WriteLine("Пришёл пустой ответ");
                        continue;
                    }
                    //Console.WriteLine(message);
                    else if (message == "authcorrect")
                        ClientClass.AuthCorrect();
                    else if (message == "qeok")
                    {
                        FForms.F2.Invoke(() =>FForms.F2.QueueConfirmed());  
                    }
                    else if (message == "gameStart")
                        FForms.F2.BeginInvoke(() => FForms.F2.GameStart());
                        //ClientClass.Kostyl();
                        
                    else if(message == "White")
                    {
                       
                        board.CurrentPlayer = ChessColor.WHITE;
                        ClientClass.firstmove= true;
                        
                    }
                    else if( message == "Black")
                    {
                        board.CurrentPlayer = ChessColor.BLACK;
                        ClientClass.firstmove = false;
                        
                    }
                    
                    else if(message.Substring(0,1)=="[")
                    {
                        //Console.WriteLine("ура я зашел в if");
                        //message = message.Substring(3);
                        
                        ClientClass.TileNowSelected.TileClickedComfirmed(message);
                    }
                    else if(message == "да")
                    {
                        bool move = true;
                        ClientClass.TileNowSelected.Hide();
                        ClientClass.TileNowSelected.TileClickedComfirmed2(move);
                    }
                    
                    else if(message.Substring(0,1)=="A")
                    {
                        //Console.WriteLine("аааааааааааааааааааааа"); 
                        message = message.Substring(1);

                        FForms.F3.BeginInvoke(() => FForms.F3.UpdateBoard(message,0));
                        
                        //Movement.curmove = true;
                    }
                    else if(message == "hide")
                    {
                        ClientClass.TileNowSelected.Hide();
                    }
                    else if(message == "win!")
                    {

                        FForms.F3.BeginInvoke(() => FForms.F3.Box1(message));
                    }
                    else if (message == "Lose!")
                    {
                        FForms.F3.BeginInvoke(() => FForms.F3.Box1(message));
                    }
                    else if (message == "term")
                    {
                        Console.WriteLine("TERMINATION");
                        if (terminationCommencing)
                        {
                            terminationCommencing = false;
                            //FForms.F2.Restart();
                        }
                        else
                        {
                            //FForms.F3.Close();
                            //FForms.F2.Restart();
                            terminationCommencing = true;
                        }
                        if (ClientClass.startedGame == true) 
                        {
                            Console.WriteLine("TERMINATION IN GAME");
                            ClientClass.startedGame = false;
                            FForms.F2.Restart();
                            globalVar.conn.terminationCommencing = false;
                            //FForms.F3.Invoke(() => FForms.F3.closeFrom());
                            FForms.F3.BeginInvoke(()=> FForms.F3.closeFrom());
                        }
                    }
                    else if(message.Substring(0,4) == "prom")
                    {
                        message = message.Substring(4);
                        FForms.F3.BeginInvoke(() => FForms.F3.UpdateBoard(message, 1));

                    }
                    else if(message.Substring(0,2) == "pp")
                    {
                        message=message.Substring(2);
                        ClientClass.TileNowSelected.TileClickedComfirmed3(message);
                    }

                    //Print(message);//вывод сообщения
                }
                catch (Exception ex)
                {
                    Console.WriteLine("RECIEVE ERROR: " + ex.Message);
                    break;
                }
            }
        }
        ~serverConnector()
        {
            Writer?.Close();
            Reader?.Close();
        }
    }
}
