using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ChessClient
{
    public class Movement
    {
        Tile pieceTile;
       
        public PieceMoves?[] availableMoves;
        PieceMoves? previousMove;
        
        public Movement() { previousMove = new PieceMoves(1, 1); }
        public Movement(Tile pieceTile, string json):this(){
            this.pieceTile = pieceTile;
            
            stringDictionarytoarray(json);
        }
        public void stringDictionarytoarray(string json)
        {
            Console.WriteLine(json);
            PieceMoves[] moveDict = JsonConvert.DeserializeObject<PieceMoves[]>(json);
            
            //Console.WriteLine(moveDict + " а как так");
            availableMoves = new PieceMoves?[moveDict.Length];
            
            for(int i =0; i < moveDict.Length; i++)
            {
                PieceMoves move = moveDict[i];
                availableMoves[i] = new PieceMoves(move.y,move.x);
                //Console.WriteLine("y: " + (int)availableMoves[i]?.y + ", x: " + (int)availableMoves[i]?.x);
            }
        }
        public void MoveInterface(bool show)
        {
            for (int i = 0; i < availableMoves.Length; i++)
            {
                if (availableMoves[i] == null)
                {
                    
                    continue;
                }
                //Console.WriteLine("y: "+(int)availableMoves[i]?.y+", x: "+ (int)availableMoves[i]?.x);
                board.tiles[(int)availableMoves[i]?.y, (int)availableMoves[i]?.x].PossibleMove(show);
                Console.WriteLine("отрисовал");
            }
        }

        public async void isAvailableMove(Tile clickedTile)
        {
            //MoveInterface(false);
            for (int move = 0; move < availableMoves.Length; move++)
            {
                if (availableMoves[move] == null) continue;
                if (availableMoves[move]?.x == clickedTile.location.x && availableMoves[move]?.y == clickedTile.location.y)
                {
                    
                    ClientClass.firstmove = false;
                    Console.WriteLine("хожу");
                    clickedTile.PieceAssign(pieceTile.piece);
                    Tile.This ="A"+ pieceTile.GetY.ToString() + pieceTile.GetX.ToString() + clickedTile.GetY.ToString() + clickedTile.GetX.ToString()+clickedTile.piece.ImageName();
                    pieceTile.PieceAssign(new ChessPiece(PieceKind.EMPTY));
                    Console.WriteLine(Tile.This);
                    await globalVar.conn.SendOneMessageAsync(Tile.This);
                    
                    //return true;
                }
            }
            //return false;
        }
        public async void isAvailableMove1(Tile clickedTile,string msg)
        {
            //MoveInterface(false);
            
            PieceKind pi;
            if(msg=="Queen")
            {
                pi = PieceKind.Queen;
            }
            else if(msg == "Rook")
            {
                pi = PieceKind.Rook;
            }
            else if (msg == "Bishop")
            {
                pi = PieceKind.Bishop;
            }
            else if (msg == "Knight")
            {
                pi = PieceKind.Knight;
            }
            else
            {
                pi = PieceKind.Queen;
            }
            pieceTile.piece= new ChessPiece(pi,board.CurrentPlayer);
            for (int move = 0; move < availableMoves.Length; move++)
            {
                if (availableMoves[move] == null) continue;
                if (availableMoves[move]?.x == clickedTile.location.x && availableMoves[move]?.y == clickedTile.location.y)
                {

                    ClientClass.firstmove = false;
                    Console.WriteLine("хожу");
                    clickedTile.PieceAssign(pieceTile.piece);
                    Tile.This = "A" + pieceTile.GetY.ToString() + pieceTile.GetX.ToString() + clickedTile.GetY.ToString() + clickedTile.GetX.ToString() + clickedTile.piece.ImageName();
                    pieceTile.PieceAssign(new ChessPiece(PieceKind.EMPTY));
                    Console.WriteLine(Tile.This);
                    await globalVar.conn.SendOneMessageAsync(Tile.This);

                    //return true;
                }
            }
            //return false;
        }
    }
    
    public struct PieceMoves
    {
        public int y, x;
        public PieceMoves(int y, int x) { this.y = y; this.x = x; }
    }
}
