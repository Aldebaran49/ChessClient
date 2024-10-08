using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClient
{
    public class costul
    {
       static  public  PieceKind SelectedPiece(string msg)
        {
            if(msg.Substring(5)=="Pawn")
            {
                return PieceKind.Pawn;
            }
            else if(msg.Substring(5)== "King")
            {
                return PieceKind.King;
            }
            else if (msg.Substring(5)=="Knight")
            {
                return PieceKind.Knight;
            }
            else if (  msg.Substring(5)== "Queen")
            {
                Console.WriteLine("абоба");
                return PieceKind.Queen;
            }
            else if(msg.Substring(5)=="Rook")
            {
                return PieceKind.Rook;
            }
            else if(msg.Substring(5)=="Bishop")
            {
                return PieceKind.Bishop;
            }
            else
            {
                return PieceKind.EMPTY;
            }
        }
        static public byte AnotherCOORD(string msg,int x)
        {
            byte result=0;
            if(x == 1)
            {
                byte.TryParse(msg.Substring(0, 1), out result);
                return result;
            }
            if(x == 2)
            {
                byte.TryParse(msg.Substring(1, 1),out result);
                return result;
            }
            if(x==3)
            {
                byte.TryParse(msg.Substring(2, 1), out result);
                return result;
            }
            if (x==4)
            {
                byte.TryParse(msg.Substring(3, 1), out result);
                return result;
            }
            else
            {
                return result;
            }
        }
        
    }
}
