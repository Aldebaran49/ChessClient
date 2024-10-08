using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessClient
{
    public enum PieceKind { King, Queen, Pawn, Bishop, Knight, Rook, EMPTY }
    public struct ChessPiece
    {
        public PieceKind piecekind { get; set; }
        public ChessColor color;
        //public bool firstmove;
        public string ImageName()
        {
            string name = "";
            if (color != ChessColor.NONE)
                name = color == ChessColor.BLACK ? name = "B" : name = "W";
            return name + piecekind.ToString();
        }
        public ChessPiece(PieceKind piecekind = PieceKind.EMPTY, ChessColor color = ChessColor.NONE/*, bool TwoTilesMove = false, bool firstMove = false*/)
        {
            //attackingTiles = new Tile[32];
            //this.firstmove = Movement.curmove;
            //this.TwoTilesMove = TwoTilesMove;
            this.piecekind = piecekind;
            this.color = color;
            //if (piecekind == PieceKind.EMPTY) this.firstMove = firstMove;
        }
        public ChessPiece(string key, Tile tile) : this(PieceKind.Queen)
        {
            color = key.First() == 'B' ? ChessColor.BLACK : ChessColor.WHITE;
            key = key.Remove(0, 1);
            switch (key)
            {
                case "Bishop": piecekind = PieceKind.Bishop; break;
                case "Rook": piecekind = PieceKind.Rook; break;
                case "Queen": piecekind = PieceKind.Queen; break;
                case "Knight": piecekind = PieceKind.Knight; break;
            }
            tile.PieceImage.BackgroundImage = Tile.PieceImages[ImageName()];
        }
    }
}
