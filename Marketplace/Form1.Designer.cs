namespace Marketplace
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.connectLabel = new System.Windows.Forms.Label();
            this.reconButton = new System.Windows.Forms.Button();
            this.warningLabel = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.registrationButton = new System.Windows.Forms.Button();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.minimizeButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(580, 36);
            this.panel1.TabIndex = 11;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // minimizeButton
            // 
            this.minimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.minimizeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.minimizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Font = new System.Drawing.Font("SFNS Display", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minimizeButton.ForeColor = System.Drawing.Color.White;
            this.minimizeButton.Location = new System.Drawing.Point(494, 0);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(43, 36);
            this.minimizeButton.TabIndex = 15;
            this.minimizeButton.Text = "_";
            this.minimizeButton.UseVisualStyleBackColor = false;
            this.minimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            this.minimizeButton.MouseLeave += new System.EventHandler(this.MinimizeButton_MouseLeave);
            this.minimizeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MinimizeButton_MouseMove);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("SFNS Display", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(537, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(43, 36);
            this.closeButton.TabIndex = 14;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.closeButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            this.closeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CloseButton_MouseMove);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.connectLabel);
            this.panel2.Controls.Add(this.reconButton);
            this.panel2.Controls.Add(this.warningLabel);
            this.panel2.Controls.Add(this.passwordBox);
            this.panel2.Controls.Add(this.registrationButton);
            this.panel2.Controls.Add(this.loginBox);
            this.panel2.Controls.Add(this.loginButton);
            this.panel2.Location = new System.Drawing.Point(106, 79);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 546);
            this.panel2.TabIndex = 12;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            // 
            // connectLabel
            // 
            this.connectLabel.BackColor = System.Drawing.Color.Transparent;
            this.connectLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.connectLabel.Font = new System.Drawing.Font("SFNS Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.connectLabel.ForeColor = System.Drawing.Color.Red;
            this.connectLabel.Location = new System.Drawing.Point(0, 351);
            this.connectLabel.Name = "connectLabel";
            this.connectLabel.Size = new System.Drawing.Size(358, 48);
            this.connectLabel.TabIndex = 29;
            this.connectLabel.Text = "При подключении к серверу\r\n произошла ошибка!";
            this.connectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.connectLabel.Visible = false;
            // 
            // reconButton
            // 
            this.reconButton.BackColor = System.Drawing.Color.White;
            this.reconButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reconButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.reconButton.FlatAppearance.BorderSize = 0;
            this.reconButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reconButton.Font = new System.Drawing.Font("SFNS Display", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reconButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.reconButton.Location = new System.Drawing.Point(0, 399);
            this.reconButton.Name = "reconButton";
            this.reconButton.Size = new System.Drawing.Size(358, 49);
            this.reconButton.TabIndex = 28;
            this.reconButton.Text = "Подключиться заново";
            this.reconButton.UseVisualStyleBackColor = false;
            this.reconButton.Visible = false;
            this.reconButton.Click += new System.EventHandler(this.ReconButton_Click);
            // 
            // warningLabel
            // 
            this.warningLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.warningLabel.BackColor = System.Drawing.Color.Transparent;
            this.warningLabel.Font = new System.Drawing.Font("SFNS Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.warningLabel.ForeColor = System.Drawing.Color.Red;
            this.warningLabel.Location = new System.Drawing.Point(85, 157);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(192, 51);
            this.warningLabel.TabIndex = 27;
            this.warningLabel.Text = "Поля не заполнены!";
            this.warningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.warningLabel.Visible = false;
            // 
            // passwordBox
            // 
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordBox.Font = new System.Drawing.Font("SFNS Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.passwordBox.Location = new System.Drawing.Point(18, 277);
            this.passwordBox.MaxLength = 30;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '•';
            this.passwordBox.Size = new System.Drawing.Size(336, 24);
            this.passwordBox.TabIndex = 22;
            this.passwordBox.Text = "Пароль";
            this.passwordBox.Enter += new System.EventHandler(this.PasswordBox_Enter);
            this.passwordBox.Leave += new System.EventHandler(this.PasswordBox_Leave);
            // 
            // registrationButton
            // 
            this.registrationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.registrationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registrationButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.registrationButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.registrationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registrationButton.Font = new System.Drawing.Font("SFNS Display", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registrationButton.ForeColor = System.Drawing.Color.White;
            this.registrationButton.Location = new System.Drawing.Point(0, 448);
            this.registrationButton.Name = "registrationButton";
            this.registrationButton.Size = new System.Drawing.Size(358, 49);
            this.registrationButton.TabIndex = 25;
            this.registrationButton.Text = "Регистрация";
            this.registrationButton.UseVisualStyleBackColor = false;
            this.registrationButton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // loginBox
            // 
            this.loginBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginBox.Font = new System.Drawing.Font("SFNS Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.loginBox.Location = new System.Drawing.Point(18, 211);
            this.loginBox.MaxLength = 8;
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(333, 24);
            this.loginBox.TabIndex = 21;
            this.loginBox.Text = "Логин";
            this.loginBox.Enter += new System.EventHandler(this.LoginBox_Enter);
            this.loginBox.Leave += new System.EventHandler(this.LoginBox_Leave);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.White;
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loginButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("SFNS Display", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.loginButton.Location = new System.Drawing.Point(0, 497);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(358, 49);
            this.loginButton.TabIndex = 23;
            this.loginButton.Text = "Войти";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Location = new System.Drawing.Point(18, 248);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(336, 2);
            this.panel3.TabIndex = 30;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Location = new System.Drawing.Point(18, 314);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(336, 2);
            this.panel4.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("SFNS Display", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 62);
            this.label1.TabIndex = 32;
            this.label1.Text = "Marketplace";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(580, 698);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Маркетплейс для фермерских продуктов";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label connectLabel;
        private System.Windows.Forms.Button reconButton;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button registrationButton;
        public System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.Button loginButton;
    }
}

