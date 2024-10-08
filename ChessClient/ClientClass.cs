using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessClient
{
    internal class ClientClass
    {
        static bool auth = false;
        static public Tile TileNowSelected;
        static public bool firstmove;
        static public bool isF3TrashingCommencing = false;
        static public bool startedGame = false;
        public static void AuthCorrect()
        {
            if (!auth)
            {
                auth = true;
                Console.WriteLine("Авторизация успешна");
                //FForms.F1.Invoke(() => FForms.F1.closeForm());
                Task.Run(()=> FForms.F1.closeForm());
                //Forms.F2.Show();
            }
            else
            {
                Console.WriteLine("Пользователь уже авторизован");
            }
        }
        
    }
}
