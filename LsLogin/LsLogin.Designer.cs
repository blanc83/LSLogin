namespace LsLogin
{
    partial class LsLogin
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtUserPWD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Button();
            this.txtLoginKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CreateBat = new System.Windows.Forms.Button();
            this.StartGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(91, 27);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 21);
            this.txtUserID.TabIndex = 1;
            // 
            // txtUserPWD
            // 
            this.txtUserPWD.Location = new System.Drawing.Point(91, 73);
            this.txtUserPWD.Name = "txtUserPWD";
            this.txtUserPWD.Size = new System.Drawing.Size(100, 21);
            this.txtUserPWD.TabIndex = 2;
            this.txtUserPWD.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(207, 30);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(100, 58);
            this.Login.TabIndex = 4;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // txtLoginKey
            // 
            this.txtLoginKey.Location = new System.Drawing.Point(91, 123);
            this.txtLoginKey.Name = "txtLoginKey";
            this.txtLoginKey.Size = new System.Drawing.Size(306, 21);
            this.txtLoginKey.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "Key";
            // 
            // CreateBat
            // 
            this.CreateBat.Location = new System.Drawing.Point(25, 153);
            this.CreateBat.Name = "CreateBat";
            this.CreateBat.Size = new System.Drawing.Size(112, 23);
            this.CreateBat.TabIndex = 7;
            this.CreateBat.Text = "Create Bat File";
            this.CreateBat.UseVisualStyleBackColor = true;
            this.CreateBat.Click += new System.EventHandler(this.button1_Click);
            // 
            // StartGame
            // 
            this.StartGame.Location = new System.Drawing.Point(154, 153);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(113, 23);
            this.StartGame.TabIndex = 8;
            this.StartGame.Text = "Start Game";
            this.StartGame.UseVisualStyleBackColor = true;
            this.StartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // LsLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 188);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.CreateBat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLoginKey);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUserPWD);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.label1);
            this.Name = "LsLogin";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtUserPWD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.TextBox txtLoginKey;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CreateBat;
        private System.Windows.Forms.Button StartGame;
    }
}

