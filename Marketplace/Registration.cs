using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Data.SQLite;


namespace Marketplace
{
    
    public partial class Registration : Form
    {
        SQLiteConnection connection = DBUtils.GetDBConnection();
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public Registration()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (loginBox.Text == "Логин" || passwordBox.Text == "Пароль" || repeatPasswordBox.Text == "Повторите" || emailBox.Text == "Email")//проверка, заполнены-ли все поля
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Заполните обязательные поля!";
            }
            else if (isValid(emailBox.Text) == false)
            {
                labelWarning.Visible = true;
                labelWarning.Text = "Некорректный Email!";
            }
            else
            {
                connection = DBUtils.GetDBConnection();
                labelWarning.Visible = false;
                connection.Open();
                try
                {
                    string sql1 = "SELECT COUNT(*) from User_table where Login like '" + loginBox.Text + "'";
                    string sql2 = "SELECT COUNT(*) from User_table where Email like '" + emailBox.Text + "'";
                    SQLiteCommand cmd1 = connection.CreateCommand();
                    cmd1.CommandText = sql1;
                    int countL = 0, countE = 0;
                    countL = Convert.ToInt32(cmd1.ExecuteScalar());
                    cmd1.CommandText = sql2;
                    countE = Convert.ToInt32(cmd1.ExecuteScalar());
                    if (countL == 0 && countE == 0)
                    {
                        string sql = "Insert into User_table (Login, Password, Email, Kind, Balance, Admin, Date) " + " values (@login, @password, @email, @kind, @balance, @admin, @date) ";
                        SQLiteCommand cmd = connection.CreateCommand();
                        cmd.CommandText = sql;
                        cmd.Parameters.Add("@login", DbType.String).Value = loginBox.Text;
                        cmd.Parameters.Add("@password", DbType.String).Value = passwordBox.Text;
                        cmd.Parameters.Add("@email", DbType.String).Value = emailBox.Text;
                        if (radioSeller.Checked)
                        {
                            cmd.Parameters.Add("@kind", DbType.Boolean).Value = 1;
                        }
                        else
                        {
                            cmd.Parameters.Add("@kind", DbType.Boolean).Value = 0;
                        }
                        cmd.Parameters.Add("@balance", DbType.Int32).Value = 0;
                        cmd.Parameters.Add("@admin", DbType.Boolean).Value = 0;
                        cmd.Parameters.Add("@date", DbType.Date).Value = DateTime.Today;
                        cmd.ExecuteNonQuery();
                        this.Close();
                    }
                    else if (countL != 0 && countE ==0)
                    {
                        labelWarning.Visible = true;
                        labelWarning.Text = "Пользователь с таким логином уже существует";
                    }
                    else if (countL == 0 && countE != 0)
                    {
                        labelWarning.Visible = true;
                        labelWarning.Text = "Пользователь с таким Email уже существует";
                    }
                    else
                    {
                        labelWarning.Visible = true;
                        labelWarning.Text = "Пользователь с таким логином и Email уже существует";
                    }
                }
                catch (Exception ex)
                {
                    labelWarning.Text = "Ошибка: " + ex + "\n"+ ex.StackTrace;
                    labelWarning.Visible = true;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
                
            }
        }

        private void LoginBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
            labelWarning.Visible = false;
        }

        private void RepeatPasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
            labelWarning.Visible = false;
            if (repeatPasswordBox.Text + Convert.ToString(e.KeyChar) != passwordBox.Text)
            {
                repeatPasswordBox.BackColor = Color.FromArgb(255,204,153);
            }
            else
            {
                repeatPasswordBox.BackColor = Color.FromArgb(153,255,153);
            }
        }

        private void RepeatPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (passwordBox.Text != "Пароль" && repeatPasswordBox.Text != "")
            {
                if (repeatPasswordBox.Text != passwordBox.Text)
                {
                    repeatPasswordBox.BackColor = Color.FromArgb(255, 204, 153);
                }
                else
                {
                    repeatPasswordBox.BackColor = Color.FromArgb(153, 255, 153);
                }
            }
        }

        private void PasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (repeatPasswordBox.Text != "" && repeatPasswordBox.Text != "Повторите")
            {
                if (repeatPasswordBox.Text != passwordBox.Text)
                {
                    repeatPasswordBox.BackColor = Color.FromArgb(255, 204, 153);
                }
                else
                {
                    repeatPasswordBox.BackColor = Color.FromArgb(153, 255, 153);
                }
            }
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            connection.Close();
            connection.Dispose();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Registration_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Registration_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Registration_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void CloseButton_MouseMove(object sender, MouseEventArgs e)
        {
            closeButton.BackColor = Color.FromArgb(51, 204, 102);
            closeButton.ForeColor = Color.White;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.White;
            closeButton.ForeColor = Color.FromArgb(51, 204, 102);
            
        }

        private void PasswordBox_Enter(object sender, EventArgs e)
        {
            if (passwordBox.Text == "Пароль")
            {
                passwordBox.Text = "";
                passwordBox.UseSystemPasswordChar = true;
                passwordBox.ForeColor = Color.FromArgb(51, 204, 102);
                panel3.BackColor = Color.FromArgb(51, 204, 102);
            }
        }

        private void PasswordBox_Leave(object sender, EventArgs e)
        {
            if (passwordBox.Text == "")
            {
                passwordBox.UseSystemPasswordChar = false;
                passwordBox.Text = "Пароль";
                passwordBox.ForeColor = Color.Gainsboro;
                panel3.BackColor = Color.Gainsboro;
            }
        }

        private void RepeatPasswordBox_Enter(object sender, EventArgs e)
        {
            if (repeatPasswordBox.Text == "Повторите")
            {
                repeatPasswordBox.Text = "";
                repeatPasswordBox.UseSystemPasswordChar = true;
                repeatPasswordBox.ForeColor = Color.FromArgb(51, 204, 102);
                panel4.BackColor = Color.FromArgb(51, 204, 102);
            }
        }

        private void RepeatPasswordBox_Leave(object sender, EventArgs e)
        {
            if (repeatPasswordBox.Text == "")
            {
                repeatPasswordBox.UseSystemPasswordChar = false;
                repeatPasswordBox.Text = "Повторите";
                repeatPasswordBox.ForeColor = Color.Gainsboro;
                panel4.BackColor = Color.Gainsboro;
                repeatPasswordBox.BackColor = Color.White;
            }
        }

        private void LoginBox_Enter(object sender, EventArgs e)
        {
            if (loginBox.Text == "Логин")
            {
                loginBox.Text = "";
                loginBox.ForeColor = Color.FromArgb(51, 204, 102);
                panel2.BackColor = Color.FromArgb(51, 204, 102);
            }
        }

        private void LoginBox_Leave(object sender, EventArgs e)
        {
            if (loginBox.Text == "")
            {
                loginBox.Text = "Логин";
                loginBox.ForeColor = Color.Gainsboro;
                panel2.BackColor = Color.Gainsboro;
                loginBox.BackColor = Color.White;
            }
        }

        private void EmailBox_Enter(object sender, EventArgs e)
        {
            if (emailBox.Text == "Email")
            {
                emailBox.Text = "";
                emailBox.ForeColor = Color.FromArgb(51, 204, 102);
                panel5.BackColor = Color.FromArgb(51, 204, 102);
            }
        }

        private void EmailBox_Leave(object sender, EventArgs e)
        {
            if (emailBox.Text == "")
            {
                emailBox.Text = "Email";
                emailBox.ForeColor = Color.Gainsboro;
                panel5.BackColor = Color.Gainsboro;
                emailBox.BackColor = Color.White;
            }
        }

        bool isValid(string email)
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
            return isMatch.Success;
        }
    }
}
