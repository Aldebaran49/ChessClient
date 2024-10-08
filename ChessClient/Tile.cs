using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessClient
{
    public enum ChessColor { WHITE,BLACK,NONE};
    public partial class Tile : UserControl
    {
        public ChessPiece piece = new ChessPiece(PieceKind.EMPTY); //EMPTY piece
        public ChessColor color = ChessColor.WHITE;
        public Location location = new Location();
        static Movement piecemoves;
        public static string json;
        public string coordinates;
        public static string This;
        
        bool move = false;
        public byte GetY { get { return location.y; } }
        public byte GetX { get { return location.x; } }
        public byte SetX { set { location.x = value; } }
        public byte SetY { set { location.y = value; } }
        public Tile(byte y, byte x) { InitializeComponent(); location.y = y; location.x = x; Location = new Point(x * Size.Width, y * Size.Height); }
        public Tile(byte y, byte x, ChessColor color) : this(y, x) { this.color = color; }
       
        public Color TileColor() => color != ChessColor.WHITE ? Color.Gray : Color.LightGray;

        private void Tile_Load(object sender, EventArgs e)
        {
            this.PieceImage.BackColor = TileColor();
            this.BackColor = TileColor();
            this.Click += TileClicked;
            this.PieceImage.Click += TileClicked;
            
        }
        static int click = 0;

        

        //static Movement piecemoves;
        public void PossibleMove(bool show)
        {
            if (!show) PieceImage.Image = null;
            else PieceImage.Image = Properties.Resources.PossibleMove;
            //Console.WriteLine("победа");
        }
        
        
        public void PieceAssign(ChessPiece piece)
        {
            this.piece = piece;

            PieceImage.BackgroundImage = PieceImages[piece.ImageName()];
        }
        private async void TileClicked(object sender, EventArgs e)
        {
            if (click == 0 && this.piece.color != board.CurrentPlayer) return;
            if (ClientClass.firstmove == true)
            {
                click++;
                if (click == 1)
                {
                    //Console.WriteLine("работает");
                    coordinates = GetCoordinatesAsString();
                    //Console.WriteLine(coordinates +" в TileClicked");
                    coordinates = "?" + coordinates;
                    await globalVar.conn.SendOneMessageAsync(coordinates);
                    ClientClass.TileNowSelected = this;

                }
                else
                {
                    Console.WriteLine("пытаюсь ходить");
                    ClientClass.TileNowSelected = this;
                    coordinates = GetCoordinatesAsString();
                    coordinates = "?" + coordinates;
                    await globalVar.conn.SendOneMessageAsync(coordinates);
                    Console.WriteLine("отправил координаты сервера для хода");
                    click = 0;
                }
            }
            else
            {
                return;
            }
        }
        public void TileClickedComfirmed(string json)
        {
            piecemoves = new Movement(this, json);
            piecemoves.MoveInterface(true);
        }
        public void Hide()
        {
            piecemoves.MoveInterface(false);
        }
        public void TileClickedComfirmed2(bool moves)
        {
            move = moves;
            piecemoves.isAvailableMove(this);
        }
        public void TileClickedComfirmed3(string msg)
        {
            
            piecemoves.isAvailableMove1(this,msg);
        }
        public string GetCoordinatesAsString()
        {
            return string.Format("{0},{1}", GetY, GetX);
        }
        public static Dictionary<string, Image> PieceImages = new Dictionary<string, Image> {
            { "BBishop",Properties.Resources.BBishop},
            { "BKnight",Properties.Resources.BKnight },
            { "BRook",Properties.Resources.BRook },
            { "BKing",Properties.Resources.BKing },
            { "BQueen",Properties.Resources.BQueen },
            { "BPawn",Properties.Resources.BPawn },
            { "WBishop",Properties.Resources.WBishop },
            { "WKnight",Properties.Resources.WKnight },
            { "WRook",Properties.Resources.WRook },
            { "WKing",Properties.Resources.WKing},
            { "WQueen",Properties.Resources.WQueen },
            { "WPawn",Properties.Resources.WPawn },
            { "EMPTY",null }
        };
    }
    public struct Location
    {
        public byte y, x;
    }
}
