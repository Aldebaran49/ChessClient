using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ChessClient
{
    public  class board
    {
        public  static ChessColor color;
        public  static ChessColor CurrentPlayer;
        public static Form3 Window;
        public static Tile[,] tiles = new Tile[8, 8];
        public static ChessPiece GetPiece(int y , int x)=> tiles[y,x].piece;
        public board(Form3 chess)
        {
            Window = chess;
            Console.WriteLine(CurrentPlayer);
            if(CurrentPlayer == ChessColor.WHITE
                
                ) { FForms.F3.Text = "White"; }
            else
            {
                FForms.F3.Text = "Black";
            }
            byte rows = 0;
            for (byte x = 0; x < 8; x++, rows++)
            {
                for (byte y = 0; y < 8; y++, rows++)
                {
                    Tile CorrectTile() => rows % 2 == 0 ? new Tile(y, x, ChessColor.WHITE) : new Tile(y, x, ChessColor.BLACK);
                    tiles[y, x] = CorrectTile();
                    chess.Controls.Add(tiles[y, x]);
                }
            }
            SetPieces(0, ChessColor.BLACK);
            SetPieces(7, ChessColor.WHITE);
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                {
                    if (tiles[y, x].piece.piecekind != PieceKind.EMPTY)
                        tiles[y, x].PieceImage.BackgroundImage = Tile.PieceImages[tiles[y, x].piece.ImageName()];
                }
        }
        public void AnotherXod(string msg)
        {
            ChessPiece pieces = new ChessPiece();
            PieceKind pi = costul.SelectedPiece(msg);
            
            pieces.piecekind = pi;
            string piec;
            if(CurrentPlayer == ChessColor.WHITE)
            {
                piec="B"+msg.Substring(5);
            }
            else
            {
                piec = "W"+msg.Substring(5);
            }
            
            byte Set2X = costul.AnotherCOORD(msg, 4);
            byte Set2Y = costul.AnotherCOORD(msg, 3);
            //Console.WriteLine("рисую");
            
            byte Set1X = costul.AnotherCOORD(msg, 2);
            byte Set1Y = costul.AnotherCOORD(msg, 1);
            
            tiles[Set1Y,Set1X].piece = new ChessPiece(PieceKind.EMPTY, ChessColor.NONE);
            tiles[Set1Y, Set1X].PieceImage.BackgroundImage = Tile.PieceImages["EMPTY"];
            tiles[Set2Y, Set2X].piece = new ChessPiece(pi, CurrentPlayer);
            tiles[Set2Y, Set2X].PieceImage.BackgroundImage = Tile.PieceImages[piec];
            ClientClass.firstmove = true;
        }
        
        private void SetPieces(int y, ChessColor color)
        {
            tiles[y, 0].piece = new ChessPiece(PieceKind.Rook, color);
            tiles[y, 1].piece = new ChessPiece(PieceKind.Knight, color);
            tiles[y, 2].piece = new ChessPiece(PieceKind.Bishop, color);
            tiles[y, 3].piece = new ChessPiece(PieceKind.Queen, color);
            tiles[y, 4].piece = new ChessPiece(PieceKind.King, color);
            tiles[y, 5].piece = new ChessPiece(PieceKind.Bishop, color);
            tiles[y, 6].piece = new ChessPiece(PieceKind.Knight, color);
            tiles[y, 7].piece = new ChessPiece(PieceKind.Rook, color);
            y += y == 0 ? 1 : -1;
            for (int x = 0; x < 8; x++)
                tiles[y, x].piece = new ChessPiece(PieceKind.Pawn, color);
        }
    }
}
