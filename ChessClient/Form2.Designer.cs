namespace ChessClient
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonEnterQueue = new Button();
            labelQueueState = new Label();
            SuspendLayout();
            // 
            // buttonEnterQueue
            // 
            buttonEnterQueue.Location = new Point(520, 170);
            buttonEnterQueue.Margin = new Padding(4, 5, 4, 5);
            buttonEnterQueue.Name = "buttonEnterQueue";
            buttonEnterQueue.Size = new Size(107, 38);
            buttonEnterQueue.TabIndex = 0;
            buttonEnterQueue.Text = "Играть";
            buttonEnterQueue.UseVisualStyleBackColor = true;
            buttonEnterQueue.Click += buttonEnterQueue_Click;
            // 
            // labelQueueState
            // 
            labelQueueState.AutoSize = true;
            labelQueueState.Location = new Point(520, 672);
            labelQueueState.Margin = new Padding(4, 0, 4, 0);
            labelQueueState.Name = "labelQueueState";
            labelQueueState.Size = new Size(124, 25);
            labelQueueState.TabIndex = 1;
            labelQueueState.Text = "Не в очереди";
            labelQueueState.Click += labelQueueState_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1143, 750);
            Controls.Add(labelQueueState);
            Controls.Add(buttonEnterQueue);
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonEnterQueue;
        private Label labelQueueState;
    }
}