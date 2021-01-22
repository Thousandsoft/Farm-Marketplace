namespace Marketplace
{
    partial class Registration
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
            this.loginBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.repeatPasswordBox = new System.Windows.Forms.TextBox();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.radioBuyer = new System.Windows.Forms.RadioButton();
            this.radioSeller = new System.Windows.Forms.RadioButton();
            this.labelWarning = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginBox
            // 
            this.loginBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loginBox.Font = new System.Drawing.Font("SFNS Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.loginBox.Location = new System.Drawing.Point(89, 66);
            this.loginBox.MaxLength = 8;
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(183, 24);
            this.loginBox.TabIndex = 3;
            this.loginBox.Text = "Логин";
            this.loginBox.Enter += new System.EventHandler(this.LoginBox_Enter);
            this.loginBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginBox_KeyPress);
            this.loginBox.Leave += new System.EventHandler(this.LoginBox_Leave);
            // 
            // passwordBox
            // 
            this.passwordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordBox.Font = new System.Drawing.Font("SFNS Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.passwordBox.Location = new System.Drawing.Point(89, 119);
            this.passwordBox.MaxLength = 100;
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(183, 24);
            this.passwordBox.TabIndex = 4;
            this.passwordBox.Text = "Пароль";
            this.passwordBox.TextChanged += new System.EventHandler(this.PasswordBox_TextChanged);
            this.passwordBox.Enter += new System.EventHandler(this.PasswordBox_Enter);
            this.passwordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginBox_KeyPress);
            this.passwordBox.Leave += new System.EventHandler(this.PasswordBox_Leave);
            // 
            // repeatPasswordBox
            // 
            this.repeatPasswordBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.repeatPasswordBox.Font = new System.Drawing.Font("SFNS Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.repeatPasswordBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.repeatPasswordBox.Location = new System.Drawing.Point(89, 172);
            this.repeatPasswordBox.MaxLength = 100;
            this.repeatPasswordBox.Name = "repeatPasswordBox";
            this.repeatPasswordBox.Size = new System.Drawing.Size(183, 24);
            this.repeatPasswordBox.TabIndex = 5;
            this.repeatPasswordBox.Text = "Повторите";
            this.repeatPasswordBox.TextChanged += new System.EventHandler(this.RepeatPasswordBox_TextChanged);
            this.repeatPasswordBox.Enter += new System.EventHandler(this.RepeatPasswordBox_Enter);
            this.repeatPasswordBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RepeatPasswordBox_KeyPress);
            this.repeatPasswordBox.Leave += new System.EventHandler(this.RepeatPasswordBox_Leave);
            // 
            // emailBox
            // 
            this.emailBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailBox.Font = new System.Drawing.Font("SFNS Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.emailBox.Location = new System.Drawing.Point(89, 222);
            this.emailBox.MaxLength = 100;
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(183, 24);
            this.emailBox.TabIndex = 6;
            this.emailBox.Text = "Email";
            this.emailBox.Enter += new System.EventHandler(this.EmailBox_Enter);
            this.emailBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LoginBox_KeyPress);
            this.emailBox.Leave += new System.EventHandler(this.EmailBox_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("SFNS Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(0, 409);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(365, 64);
            this.button1.TabIndex = 9;
            this.button1.Text = "Зарегистрироваться";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // radioBuyer
            // 
            this.radioBuyer.AutoSize = true;
            this.radioBuyer.Checked = true;
            this.radioBuyer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioBuyer.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.radioBuyer.FlatAppearance.BorderSize = 10;
            this.radioBuyer.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.radioBuyer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioBuyer.Font = new System.Drawing.Font("SFNS Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioBuyer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.radioBuyer.Location = new System.Drawing.Point(116, 277);
            this.radioBuyer.Name = "radioBuyer";
            this.radioBuyer.Size = new System.Drawing.Size(139, 28);
            this.radioBuyer.TabIndex = 7;
            this.radioBuyer.TabStop = true;
            this.radioBuyer.Text = "Покупатель";
            this.radioBuyer.UseVisualStyleBackColor = true;
            // 
            // radioSeller
            // 
            this.radioSeller.AutoSize = true;
            this.radioSeller.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioSeller.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.radioSeller.Font = new System.Drawing.Font("SFNS Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioSeller.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.radioSeller.Location = new System.Drawing.Point(116, 311);
            this.radioSeller.Name = "radioSeller";
            this.radioSeller.Size = new System.Drawing.Size(125, 28);
            this.radioSeller.TabIndex = 8;
            this.radioSeller.Text = "Продавец";
            this.radioSeller.UseVisualStyleBackColor = true;
            // 
            // labelWarning
            // 
            this.labelWarning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelWarning.Font = new System.Drawing.Font("SFNS Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(0, 342);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(365, 67);
            this.labelWarning.TabIndex = 14;
            this.labelWarning.Text = "Заполните обязательные поля!";
            this.labelWarning.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelWarning.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(278, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(278, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "*";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(278, 175);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(278, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(278, 311);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 20);
            this.label10.TabIndex = 19;
            this.label10.Text = "*";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 39);
            this.panel1.TabIndex = 0;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Registration_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Registration_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Registration_MouseUp);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("SFNS Display", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(190, 39);
            this.label5.TabIndex = 1;
            this.label5.Text = "Регистрация";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Registration_MouseDown);
            this.label5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Registration_MouseMove);
            this.label5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Registration_MouseUp);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.White;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("SFNS Display", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.closeButton.Location = new System.Drawing.Point(322, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(43, 39);
            this.closeButton.TabIndex = 2;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.closeButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            this.closeButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CloseButton_MouseMove);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Location = new System.Drawing.Point(89, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 2);
            this.panel2.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gainsboro;
            this.panel3.Location = new System.Drawing.Point(89, 156);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(183, 2);
            this.panel3.TabIndex = 22;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Gainsboro;
            this.panel4.Location = new System.Drawing.Point(89, 209);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(183, 2);
            this.panel4.TabIndex = 22;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Gainsboro;
            this.panel5.Location = new System.Drawing.Point(89, 259);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(183, 2);
            this.panel5.TabIndex = 22;
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(365, 473);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.radioSeller);
            this.Controls.Add(this.radioBuyer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.emailBox);
            this.Controls.Add(this.repeatPasswordBox);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.loginBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Registration_FormClosed);
            this.Load += new System.EventHandler(this.Registration_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Registration_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Registration_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Registration_MouseUp);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.TextBox repeatPasswordBox;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioBuyer;
        private System.Windows.Forms.RadioButton radioSeller;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
    }
}