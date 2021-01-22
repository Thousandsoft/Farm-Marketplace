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
    public partial class Profile : Form
    {
        // SqlDataAdapter adapter;
        SQLiteConnection conn = DBUtils.GetDBConnection();
        public Profile()
        {
            InitializeComponent();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            conn.Open();
            // TODO: данная строка кода позволяет загрузить данные в таблицу "marketplaceDBDataSet4.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.marketplaceDBDataSet4.Categories);
            usernameLabel.Text = User.Login;
            emailLabel.Text = User.Email;
            balanceLabel.Text = Convert.ToString(User.Balance) + " ₽";
            dateLabel.Text = Convert.ToString(Convert.ToDateTime(User.Date).ToShortDateString());
            if (User.Admin != true)
            {
                if (User.Kind == true)
                {
                    kindLabel.Text = "Продавец";
                    kindLabel.ForeColor = Color.Red;
                    balanceButton.Text = "Снять средства";
                    balanceButton.Visible = false;
                    goodsButton.Text = "Добавить товар";
                    SQLiteDataAdapter da = new SQLiteDataAdapter("select Name from Categories", conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Categories");
                    foreach (DataRow row in ds.Tables["Categories"].Rows)
                    {

                        comboBox1.Items.Add(row["Name"].ToString());
                    }
                    Refresh_Table();
                    tabControl1.TabPages.Remove(tabPage3);
                    Refresh_Orders_Seller();
                }
                else
                {
                    kindLabel.Text = "Покупатель";
                    kindLabel.ForeColor = Color.Green;
                    balanceButton.Text = "Пополнить баланс";
                    balanceButton.Visible = true;
                    goodsButton.Text = "Перейти в корзину";
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Remove(tabPage4);
                    label9.Visible = true;
                    addressLable.Visible = true;
                    editAddress.Visible = true;
                    if (User.Address != "")
                    {
                        addressLable.Text = User.Address;
                    }
                    else
                    {
                        addressLable.Text = "Адрес отсутствует";
                    }
                    Refresh_Orders_Buyer();
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void GoodsButton_Click(object sender, EventArgs e)
        {
            if (User.Admin == true)
            {

            }
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8) 
            {
                e.Handled = true;
            }
        }

        private void GoodsButton_Click_1(object sender, EventArgs e)
        {
            if (nameBox.Text == "" || countBox.Text == "" || priceBox.Text == "" || comboBox1.SelectedItem == null)
            {
                succsessLabel.Visible = true;
                succsessLabel.Text = "Заполните все поля";
                succsessLabel.ForeColor = Color.Red;
            }
            else
            {
                try
                {
                    string sql = "Insert into Goods (CategoryId, UserId, Name, Price, Count, Date) " + " values (@categoryid, @userid, @name, @price, @count, @date)";
                    string sql1 = "Select CategoryId From Categories Where Name = '" + comboBox1.SelectedItem + "'";
                    string sql2 = "Select Id From User_table Where Login = '" + User.Login + "'";
                    string sql3 = "Select COUNT(*) From Goods where Name like '" + nameBox.Text + "'" + "and UserId like '" + User.Id + "'";
                    int categoryId, userId;
                    SQLiteCommand cmd = conn.CreateCommand();
                    cmd.CommandText = sql3; 
                    int countN = 0;
                    countN = Convert.ToInt32(cmd.ExecuteScalar());
                    if (countN == 0)
                    {
                        cmd.CommandText = sql1;
                        categoryId = Convert.ToInt32(cmd.ExecuteScalar());
                        cmd.CommandText = sql2;
                        userId = Convert.ToInt32(cmd.ExecuteScalar());
                        cmd.CommandText = sql;
                        cmd.Parameters.Add("@categoryid", DbType.Int32).Value = categoryId;
                        cmd.Parameters.Add("@userid", DbType.Int32).Value = userId;
                        cmd.Parameters.Add("@name", DbType.String).Value = nameBox.Text;
                        cmd.Parameters.Add("@price", DbType.Int32).Value = priceBox.Text;
                        cmd.Parameters.Add("@count", DbType.Int32).Value = countBox.Text;
                        cmd.Parameters.Add("@date", DbType.Date).Value = DateTime.Today;
                        cmd.ExecuteNonQuery();
                        succsessLabel.Visible = true;
                        succsessLabel.ForeColor = Color.FromArgb(51, 204, 102);
                        succsessLabel.Text = "Товар успешно добавлен!";
                        nameBox.Text = "";
                        countBox.Text = "";
                        priceBox.Text = "";
                        comboBox1.SelectedItem = null;
                        Refresh_Table();
                    }
                    else
                    {
                        succsessLabel.Visible = true;
                        succsessLabel.Text = "Такой товар уже существует";
                        succsessLabel.ForeColor = Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                }
            }
        }
        

        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
        }

        public void Refresh_Table()
        {
            listView1.Items.Clear();
            try
            {
                string sql = "Select count(*) from Goods where UserId = " + User.Id;
                string sql1 = "Select Name from Goods where UserId = " + User.Id;
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count != 0)
                {
                    SQLiteDataAdapter da = new SQLiteDataAdapter("Select Name from Goods where UserId = " + User.Id, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Goods");
                    List<string> names = new List<string>();
                    foreach (DataRow row in ds.Tables["Goods"].Rows)
                    {

                        names.Add(row["Name"].ToString());
                    }
                    cmd.CommandText = sql1;
                    for (int i = 0; i < count; i++)
                    {
                        string sql2 = "Select CategoryId from Goods where UserId = " + User.Id + " and Name = '" + names[i] + "'";
                        cmd.CommandText = sql2;
                        int categoryid = Convert.ToInt32(cmd.ExecuteScalar());
                        string sql3 = "Select Name from Categories where CategoryId = " + categoryid;
                        string sql4 = "Select Price from Goods where UserId = " + User.Id + " and Name = '" + names[i] + "'";
                        string sql5 = "Select Count from Goods where UserId = " + User.Id + " and Name = '" + names[i] + "'";
                        cmd.CommandText = sql3;
                        listView1.Items.Add(names[i]);
                        listView1.Items[i].SubItems.Add(Convert.ToString(cmd.ExecuteScalar()));
                        cmd.CommandText = sql4;
                        listView1.Items[i].SubItems.Add(Convert.ToString(cmd.ExecuteScalar()));
                        cmd.CommandText = sql5;
                        listView1.Items[i].SubItems.Add(Convert.ToString(cmd.ExecuteScalar()));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void TabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            Refresh_Table();
            cancelOrder.Enabled = false;
            confirmOrder.Enabled = false;
            cancelSeller.Enabled = false;
        }

        private void BalanceButton_Click(object sender, EventArgs e)
        {
            if (User.Kind == false)
            {
                string sql = "Select Balance From User_table where Login = '" + User.Login + "'";
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                int balance = Convert.ToInt32(cmd.ExecuteScalar());
                balance += 5000;
                string sql1 = "Update User_table Set Balance = " + balance + "where Login = '" + User.Login + "'";
                cmd.CommandText = sql1;
                cmd.ExecuteNonQuery();
                cmd.CommandText = sql;
                balance = Convert.ToInt32(cmd.ExecuteScalar());
                balanceLabel.Text = Convert.ToString(balance) + " ₽";
                User.Balance = balance;
            }
        }

        private void EditAddress_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    SQLiteCommand cmd = conn.CreateCommand();
                    string sql = "Update User_table Set Address = '" + textBox1.Text + "' where Login = '" + User.Login + "'";
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                    User.Address = textBox1.Text;
                    addressLable.Text = textBox1.Text;
                    textBox1.Text = "";
                    groupBox1.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                }
            }
        }
        public void Refresh_Orders_Buyer()
        {
            confirmOrder.Enabled = false;
            cancelOrder.Enabled = false;
            try
            {
                listView2.Items.Clear();
                SQLiteCommand cmd = conn.CreateCommand();
                string sql1 = "Select count(*) from Orders where BuyerId = " + User.Id;
                int count = 0;
                cmd.CommandText = sql1;
                count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count != 0)
                {
                    SQLiteDataAdapter da = new SQLiteDataAdapter("Select OrderId from Orders where BuyerId = " + User.Id, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Orders");
                    List<string> names = new List<string>();
                    foreach (DataRow row in ds.Tables["Orders"].Rows)
                    {
                        names.Add(row["OrderId"].ToString());
                    }
                    for (int i = 0;i < count; i++)
                    {
                        listView2.Items.Add(names[i]);
                        string sql2 = "Select Name From Goods where GoodsId = (select GoodsId from Orders where BuyerId = " + User.Id + " and OrderId = '" + names[i] + "')";
                        cmd.CommandText = sql2;
                        listView2.Items[i].SubItems.Add(cmd.ExecuteScalar().ToString());
                        string sql3 = "Select Count from Orders where BuyerId = " + User.Id + " and OrderId = '" + names[i] + "'";
                        cmd.CommandText = sql3;
                        listView2.Items[i].SubItems.Add(cmd.ExecuteScalar().ToString());
                        string sql4 = "Select Price from Orders where BuyerId = " + User.Id + " and OrderId = '" + names[i] + "'";
                        cmd.CommandText = sql4;
                        listView2.Items[i].SubItems.Add(cmd.ExecuteScalar().ToString());
                        string sql5 = "Select Login from User_table where Id = (select SellerId from Orders where BuyerId = " + User.Id + " and OrderId = '" + names[i] + "')";
                        cmd.CommandText = sql5;
                        listView2.Items[i].SubItems.Add(cmd.ExecuteScalar().ToString());
                        string sql6 = "Select Email from User_table where Id = (select SellerId from Orders where BuyerId = " + User.Id + " and OrderId = '" + names[i] + "')";
                        cmd.CommandText = sql6;
                        listView2.Items[i].SubItems.Add(cmd.ExecuteScalar().ToString());
                        string sql7 = "Select Date from Orders where BuyerId = " + User.Id + " and OrderId = '" + names[i] + "'";
                        cmd.CommandText = sql7;
                        listView2.Items[i].SubItems.Add(cmd.ExecuteScalar().ToString());
                        string sql8 = "Select Completed from Orders where BuyerId = " + User.Id + " and OrderId = '" + names[i] + "'";
                        cmd.CommandText = sql8;
                        bool completed = Convert.ToBoolean(cmd.ExecuteScalar());
                        if (completed)
                        {
                            listView2.Items[i].SubItems.Add("Да");
                        }
                        else
                        {
                            listView2.Items[i].SubItems.Add("Нет");
                        }
                        
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
            }
        }

        public void Refresh_Orders_Seller()
        {
            cancelSeller.Enabled = false;
            try
            {
                listView3.Items.Clear();
                SQLiteCommand cmd = conn.CreateCommand();
                string sql1 = "Select count(*) from Orders where SellerId = " + User.Id;
                int count = 0;
                cmd.CommandText = sql1;
                count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count != 0)
                {
                    SQLiteDataAdapter da = new SQLiteDataAdapter("Select OrderId from Orders where SellerId = " + User.Id, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Orders");
                    List<string> names = new List<string>();
                    foreach (DataRow row in ds.Tables["Orders"].Rows)
                    {
                        names.Add(row["OrderId"].ToString());
                    }
                    for (int i = 0; i < count; i++)
                    {
                        listView3.Items.Add(names[i]);
                        string sql2 = "Select Name From Goods where GoodsId = (select GoodsId from Orders where SellerId = " + User.Id + " and OrderId = '" + names[i] + "')";
                        cmd.CommandText = sql2;
                        listView3.Items[i].SubItems.Add(cmd.ExecuteScalar().ToString());
                        string sql3 = "Select Count from Orders where SellerId = " + User.Id + " and OrderId = '" + names[i] + "'";
                        cmd.CommandText = sql3;
                        listView3.Items[i].SubItems.Add(cmd.ExecuteScalar().ToString());
                        string sql4 = "Select Price from Orders where SellerId = " + User.Id + " and OrderId = '" + names[i] + "'";
                        cmd.CommandText = sql4;
                        listView3.Items[i].SubItems.Add(cmd.ExecuteScalar().ToString());
                        string sql5 = "Select Login from User_table where Id = (select BuyerId from Orders where SellerId = " + User.Id + " and OrderId = '" + names[i] + "')";
                        cmd.CommandText = sql5;
                        listView3.Items[i].SubItems.Add(cmd.ExecuteScalar().ToString());
                        string sql6 = "Select Email from User_table where Id = (select BuyerId from Orders where SellerId = " + User.Id + " and OrderId = '" + names[i] + "')";
                        cmd.CommandText = sql6;
                        listView3.Items[i].SubItems.Add(cmd.ExecuteScalar().ToString());
                        string sql7 = "Select Address from Orders where SellerId = " + User.Id + " and OrderId = '" + names[i] + "'";
                        cmd.CommandText = sql7;
                        listView3.Items[i].SubItems.Add(cmd.ExecuteScalar().ToString());
                        string sql8 = "Select Date from Orders where SellerId = " + User.Id + " and OrderId = '" + names[i] + "'";
                        cmd.CommandText = sql8;
                        listView3.Items[i].SubItems.Add(cmd.ExecuteScalar().ToString());
                        string sql9 = "Select Completed from Orders where SellerId = " + User.Id + " and OrderId = '" + names[i] + "'";
                        cmd.CommandText = sql9;
                        bool completed = Convert.ToBoolean(cmd.ExecuteScalar());
                        if (completed)
                        {
                            listView3.Items[i].SubItems.Add("Да");
                        }
                        else
                        {
                            listView3.Items[i].SubItems.Add("Нет");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count != 0)
            {
                if (listView2.SelectedItems[0].SubItems[7].Text != "Да")
                {
                    cancelOrder.Enabled = true;
                    confirmOrder.Enabled = true;
                }
                else
                {
                    cancelOrder.Enabled = false;
                    confirmOrder.Enabled = false;
                }
            }
            
        }

        private void CancelOrder_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand cmd = conn.CreateCommand();
                string sql1 = "Select Balance From User_table where Login = '" + User.Login + "'";
                cmd.CommandText = sql1;
                int balance = Convert.ToInt32(cmd.ExecuteScalar()) + Convert.ToInt32(listView2.SelectedItems[0].SubItems[3].Text);
                string sql2 = "Update User_table Set Balance = " + balance + " where Login = '" + User.Login + "'";
                cmd.CommandText = sql2;
                cmd.ExecuteNonQuery();
                User.Balance = balance;
                string sql5 = "Select Count from Goods where GoodsId = (select GoodsId from Orders where BuyerId = " + User.Id + " and OrderId = " + listView2.SelectedItems[0].Text + ")";
                cmd.CommandText = sql5;
                int count = Convert.ToInt32(cmd.ExecuteScalar()) + Convert.ToInt32(listView2.SelectedItems[0].SubItems[2].Text);
                string sql4 = "Update Goods Set Count = " + count + " where GoodsId = (select GoodsId from Orders where BuyerId = " + User.Id + " and OrderId = " + listView2.SelectedItems[0].Text + ")";
                cmd.CommandText = sql4;
                cmd.ExecuteNonQuery();
                string sql = "Delete from Orders where BuyerId = " + User.Id + " and OrderId = " + listView2.SelectedItems[0].Text;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                Refresh_Orders_Buyer();
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void ConfirmOrder_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand cmd = conn.CreateCommand();
                string sql = "Update Orders Set Completed = " + 1 + " where BuyerId = " + User.Id + " and OrderId = " + listView2.SelectedItems[0].Text;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                string sql1 = "Select Balance From User_table where Login = '" + listView2.SelectedItems[0].SubItems[4].Text + "'";
                cmd.CommandText = sql1;
                int balance = Convert.ToInt32(cmd.ExecuteScalar()) + Convert.ToInt32(listView2.SelectedItems[0].SubItems[3].Text);
                string sql2 = "Update User_table Set Balance = " + balance +  " where Login = '" + listView2.SelectedItems[0].SubItems[4].Text + "'";
                cmd.CommandText = sql2;
                cmd.ExecuteNonQuery();
                Refresh_Orders_Buyer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void ListView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count != 0)
            {
                if (listView3.SelectedItems[0].SubItems[8].Text != "Да")
                {
                    cancelSeller.Enabled = true;
                    
                }
                else
                {
                    cancelSeller.Enabled = false;
                }
            }
            
        }

        private void CancelSeller_Click(object sender, EventArgs e)
        {
            try
            {
                cancelSeller.Enabled = false;
                SQLiteCommand cmd = conn.CreateCommand();
                string sql1 = "Select Balance From User_table where Login = '" + listView3.SelectedItems[0].SubItems[4].Text + "'";
                cmd.CommandText = sql1;
                int balance = Convert.ToInt32(cmd.ExecuteScalar()) + Convert.ToInt32(listView3.SelectedItems[0].SubItems[3].Text);
                string sql2 = "Update User_table Set Balance = " + balance + " where Login = '" + listView3.SelectedItems[0].SubItems[4].Text + "'";
                cmd.CommandText = sql2;
                cmd.ExecuteNonQuery();
                string sql5 = "Select Count from Goods where GoodsId = (select GoodsId from Orders where SellerId = " + User.Id + " and OrderId = " + listView3.SelectedItems[0].Text + ")";
                cmd.CommandText = sql5;
                int count = Convert.ToInt32(cmd.ExecuteScalar()) + Convert.ToInt32(listView3.SelectedItems[0].SubItems[2].Text);
                string sql4 = "Update Goods Set Count = " + count + " where GoodsId = (select GoodsId from Orders where SellerId = " + User.Id + " and OrderId = " + listView3.SelectedItems[0].Text + ")";
                cmd.CommandText = sql4;
                cmd.ExecuteNonQuery();
                string sql = "Delete from Orders where SellerId = " + User.Id + " and OrderId = " + listView3.SelectedItems[0].Text;
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                Refresh_Orders_Seller();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
            }
        }
    }
}
