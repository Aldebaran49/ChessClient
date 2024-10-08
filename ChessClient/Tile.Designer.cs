namespace ChessClient
{
    partial class Tile
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            PieceImage = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PieceImage).BeginInit();
            SuspendLayout();
            // 
            // PieceImage
            // 
            PieceImage.BackColor = Color.White;
            PieceImage.ErrorImage = null;
            PieceImage.InitialImage = null;
            PieceImage.Location = new Point(0, 0);
            PieceImage.Margin = new Padding(4, 5, 4, 5);
            PieceImage.MaximumSize = new Size(80, 100);
            PieceImage.MinimumSize = new Size(80, 100);
            PieceImage.Name = "PieceImage";
            PieceImage.Size = new Size(80, 100);
            PieceImage.SizeMode = PictureBoxSizeMode.CenterImage;
            PieceImage.TabIndex = 0;
            PieceImage.TabStop = false;
            // 
            // Tile
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PieceImage);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Tile";
            Size = new Size(60, 60);
            Load += Tile_Load;
            ((System.ComponentModel.ISupportInitialize)PieceImage).EndInit();
            ResumeLayout(false);
        }

        #endregion
        public System.Windows.Forms.PictureBox PieceImage;
    }
}
