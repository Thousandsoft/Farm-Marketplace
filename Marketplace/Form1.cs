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
using System.Data.SQLite;

namespace Marketplace
{
    
    public partial class Form1 : Form
    {
        SQLiteConnection conn = DBUtils.GetDBConnection();
        string login, password;
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        public Form1()
        {
            InitializeComponent();
        }
        

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
            Registration reg = new Registration();
            reg.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (loginBox.Text == String.Empty || passwordBox.Text == String.Empty)
            {
                warningLabel.Visible = true;
            }
            else
            {
                try
                {
                    SQLiteCommand myCommand = new SQLiteCommand("select Id,Login,Password,Balance,Email,Date,Kind,Admin,Address from User_table where Login = " + "'"+loginBox.Text + "'", conn);
                    SQLiteDataReader myReader = myCommand.ExecuteReader();
                    while (myReader.Read())
                    {
                        User.Id = Convert.ToInt32(myReader["Id"]);
                        login = myReader["Login"].ToString();
                        password = myReader["Password"].ToString();
                        User.Balance = Convert.ToInt32(myReader["Balance"]);
                        User.Email = myReader["Email"].ToString();
                        User.Date = Convert.ToDateTime(myReader["Date"]);
                        User.Kind = Convert.ToBoolean(myReader["Kind"]);
                        User.Admin = Convert.ToBoolean(myReader["Admin"]);
                        User.Address = myReader["Address"].ToString();
                    }
                    if (login == loginBox.Text && password == passwordBox.Text)
                    {
                        warningLabel.Visible = false;
                        myReader.Close();
                        User.Login = loginBox.Text;
                        WorkForm wf = new WorkForm();
                        wf.Show(this);
                        this.Hide();
                        
                    }
                    else
                    {
                        warningLabel.Visible = true;
                        warningLabel.Text = "Не верный логин или пароль!";
                        myReader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                }
                /*finally
                {
                    conn.Close();
                    conn.Dispose();
                }*/
            }
        }

        private void LoginBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
            warningLabel.Visible = false;
        }

        private void PasswordBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Space)
                e.KeyChar = '\0';
            warningLabel.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            try
            {
                conn.Open();
                this.Text += " (Online)";
            }
            catch (Exception n)
            {
                this.Text += " (Offline)";
                connectLabel.Visible = true;
                reconButton.Visible = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
            conn.Dispose();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void LoginBox_Enter(object sender, EventArgs e)
        {
            if (loginBox.Text == "Логин" && loginBox.ForeColor == Color.Gainsboro)
            {
                loginBox.Text = "";
                loginBox.ForeColor = Color.FromArgb(51, 204, 102);
                panel3.BackColor = Color.FromArgb(51, 204, 102);
            }
        }

        private void LoginBox_Leave(object sender, EventArgs e)
        {
            if (loginBox.Text == "")
            {
                loginBox.Text = "Логин";
                loginBox.ForeColor = Color.Gainsboro;
                panel3.BackColor = Color.Gainsboro;
            }
        }

        private void PasswordBox_Enter(object sender, EventArgs e)
        {
            if (passwordBox.Text == "Пароль" && passwordBox.ForeColor == Color.Gainsboro)
            {
                passwordBox.Text = "";
                passwordBox.ForeColor = Color.FromArgb(51, 204, 102);
                panel4.BackColor = Color.FromArgb(51, 204, 102);
            }
        }

        private void PasswordBox_Leave(object sender, EventArgs e)
        {
            if (passwordBox.Text == "")
            {
                passwordBox.Text = "Пароль";
                passwordBox.ForeColor = Color.Gainsboro;
                panel4.BackColor = Color.Gainsboro;
            }
        }

        

        private void Form1_Activated(object sender, EventArgs e)
        {
            this.Opacity = 1.0;
        }

        private void CloseButton_MouseMove(object sender, MouseEventArgs e)
        {
            closeButton.BackColor = Color.White;
            closeButton.ForeColor = Color.FromArgb(51, 204, 102);
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.BackColor = Color.FromArgb(51, 204, 102);
            closeButton.ForeColor = Color.White;
        }

        private void MinimizeButton_MouseMove(object sender, MouseEventArgs e)
        {
            minimizeButton.BackColor = Color.White;
            minimizeButton.ForeColor = Color.FromArgb(51, 204, 102);
        }

        private void MinimizeButton_MouseLeave(object sender, EventArgs e)
        {
            minimizeButton.BackColor = Color.FromArgb(51, 204, 102);
            minimizeButton.ForeColor = Color.White;
        }

        private void ReconButton_Click(object sender, EventArgs e)
        {
            SQLiteConnection conn = DBUtils.GetDBConnection();
            try//попытка
            {
                conn.Open();
                this.Text = "Маркетплейс для фермерских продуктов (Online)";
                connectLabel.Visible = false;
                reconButton.Visible = false;
            }
            catch (Exception n)
            {
                this.Text = "Маркетплейс для фермерских продуктов (Offline)";
                connectLabel.Visible = true;
                reconButton.Visible = true;
            }
        }
    }
}
