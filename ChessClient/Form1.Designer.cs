namespace ChessClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonConnect = new Button();
            textBoxPassword = new TextBox();
            textBoxLogin = new TextBox();
            buttonToggleLogin = new Button();
            buttonToggleRegister = new Button();
            SuspendLayout();
            // 
            // buttonConnect
            // 
            buttonConnect.Location = new Point(274, 333);
            buttonConnect.Name = "buttonConnect";
            buttonConnect.Size = new Size(144, 55);
            buttonConnect.TabIndex = 0;
            buttonConnect.Text = "Подключиться";
            buttonConnect.UseVisualStyleBackColor = true;
            buttonConnect.Click += buttonConnect_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(278, 304);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.PlaceholderText = "Пароль";
            textBoxPassword.Size = new Size(140, 23);
            textBoxPassword.TabIndex = 1;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(278, 275);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.PlaceholderText = "Логин";
            textBoxLogin.Size = new Size(140, 23);
            textBoxLogin.TabIndex = 2;
            // 
            // buttonToggleLogin
            // 
            buttonToggleLogin.Enabled = false;
            buttonToggleLogin.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            buttonToggleLogin.Location = new Point(274, 246);
            buttonToggleLogin.Name = "buttonToggleLogin";
            buttonToggleLogin.Size = new Size(68, 23);
            buttonToggleLogin.TabIndex = 3;
            buttonToggleLogin.Text = "Вход";
            buttonToggleLogin.UseVisualStyleBackColor = true;
            buttonToggleLogin.Click += buttonToggleLogin_Click;
            // 
            // buttonToggleRegister
            // 
            buttonToggleRegister.Location = new Point(348, 246);
            buttonToggleRegister.Name = "buttonToggleRegister";
            buttonToggleRegister.Size = new Size(75, 23);
            buttonToggleRegister.TabIndex = 4;
            buttonToggleRegister.Text = "Регистр.";
            buttonToggleRegister.UseVisualStyleBackColor = true;
            buttonToggleRegister.Click += buttonToggleRegister_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(695, 470);
            Controls.Add(buttonToggleRegister);
            Controls.Add(buttonToggleLogin);
            Controls.Add(textBoxLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(buttonConnect);
            Name = "Form1";
            Text = "RainbowChess";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonConnect;
        private TextBox textBoxPassword;
        private TextBox textBoxLogin;
        private Button buttonToggleLogin;
        private Button buttonToggleRegister;
    }
}
