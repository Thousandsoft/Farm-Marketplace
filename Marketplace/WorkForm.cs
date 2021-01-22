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
    public partial class WorkForm : Form
    {
        string catName = "";
        bool loaded = false;
        bool openCart = false;
        string userName;
        SQLiteConnection conn = DBUtils.GetDBConnection();
        
        public WorkForm()
        {
            InitializeComponent();
        }

        private void WorkForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "marketplaceDBDataSet3.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter1.Fill(this.marketplaceDBDataSet3.Categories);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "marketplaceDBDataSet2.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.marketplaceDBDataSet2.Categories);
            try
            {
                conn.Open();
                this.Text += " (Online)";
                usernameLabel.Text = User.Login;
                userName = User.Login;
                moneyLabel.Text = Convert.ToString(User.Balance) + "₽";
                if (User.Kind == false)
                {
                    panel6.Visible = true;
                    panel6.Width = button2.Width;
                    openCart = false;
                    panel6.BackColor = Color.Transparent;
                    groupBox2.Height = panel6.Height - groupBox1.Height;
                }
                loaded = true;
            }
            catch (Exception n)
            {
                this.Text += " (Offline)";
            }
        }

        private void WorkForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void WorkForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть программу?", "Выход из программы", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                conn.Close();
                conn.Dispose();
            }
            else e.Cancel = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            userName = "";
            Form1 form = (Form1)this.Owner;
            form.Show();
            this.Hide();
            this.Dispose();
        }

        

        private void UsernameLabel_Click(object sender, EventArgs e)
        {
            if (User.Admin == false)
            {
                Profile profile = new Profile();
                profile.ShowDialog();
            }
            else
            {
                AdminPanel adminP = new AdminPanel();
                adminP.ShowDialog();
            }
        }

        private void UsernameLabel_MouseMove(object sender, MouseEventArgs e)
        {
            usernameLabel.ForeColor = Color.Red;
        }

        private void UsernameLabel_MouseLeave(object sender, EventArgs e)
        {
            usernameLabel.ForeColor = Color.FromArgb(51,204,102);
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            UpdateCon();
        }

        public void UpdateCon()
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter("select Name from Categories", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Categories");
            foreach (DataRow row in ds.Tables["Categories"].Rows)
            {

                listBox1.Items.Add(row["Name"].ToString());
            }
        }

        private void WorkForm_Activated(object sender, EventArgs e)
        {
            if (loaded)
            {
                string sql = "Select Balance From User_table where Login = '" + User.Login + "'";
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                int balance = Convert.ToInt32(cmd.ExecuteScalar());
                moneyLabel.Text = Convert.ToString(balance) + "₽";
            }
            listBox1.Items.Clear();
            UpdateCon();
            if (catName != "")
            {
                Refresh_Table(Convert.ToString(catName));
            }
            groupBox1.Visible = false;
        }

        private void Button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.ForeColor = Color.White;
            button1.BackColor = Color.FromArgb(51,204,102);
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(51, 204, 102);
            button1.BackColor = Color.White;
        }

        public void Refresh_Table(string name)
        {
            listView1.Items.Clear();
            try
            {
                SQLiteCommand cmd = conn.CreateCommand();
                string sql2 = "Select CategoryId from Categories where Name = '" + name + "'";
                cmd.CommandText = sql2;
                int categoryid = Convert.ToInt32(cmd.ExecuteScalar());
                string sql = "Select count(*) from Goods where CategoryId = " + categoryid;
                cmd.CommandText = sql;
                int count = 0;
                count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count != 0)
                {
                    SQLiteDataAdapter da = new SQLiteDataAdapter("Select Name from Goods where CategoryId = " + categoryid, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Goods");
                    List<string> names = new List<string>();
                    foreach (DataRow row in ds.Tables["Goods"].Rows)
                    {
                        names.Add(row["Name"].ToString());
                    }
                    for (int i = 0; i < count; i++)
                    {
                        listView1.Items.Add(names[i]);
                        string sql3 = "Select UserId from Goods where Name = '" + names[i] + "'";
                        cmd.CommandText = sql3;
                        int userid = Convert.ToInt32(cmd.ExecuteScalar());
                        string sql4 = "Select Login from User_table where Id = '" + userid + "'";
                        cmd.CommandText = sql4;
                        string username = Convert.ToString(cmd.ExecuteScalar());
                        listView1.Items[i].SubItems.Add(username);
                        string sql5 = "Select Price from Goods where UserId = " + userid + " and Name = '" + names[i] + "'";
                        cmd.CommandText = sql5;
                        listView1.Items[i].SubItems.Add(Convert.ToString(cmd.ExecuteScalar()));
                        string sql6 = "Select Count from Goods where UserId = " + userid + " and Name = '" + names[i] + "'";
                        cmd.CommandText = sql6;
                        listView1.Items[i].SubItems.Add(Convert.ToString(cmd.ExecuteScalar()));
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
            }
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            catName = listBox1.SelectedItem.ToString();
            string name = listBox1.SelectedItem.ToString();
            Refresh_Table(name);
        }

        /*private bool Is_Form_Loaded_Already(string FormName)
        {
            foreach (Form form_loaded in Application.OpenForms)
            {
                if (form_loaded.Text.IndexOf(FormName) >= 0)
                {
                    return true;
                }
            }
            return false;
        }*/

        private void Button2_Click(object sender, EventArgs e)
        {
            
            if (openCart)
            {
                panel6.Width = button2.Width;
                openCart = false;
                panel6.BackColor = Color.Transparent;
                groupBox2.Visible = false;
                if (cartCount.Text != "0")
                {
                    cartCount.Visible = true;
                }
            }
            else
            {
                panel6.Width = panel2.Width;
                openCart = true;
                panel6.BackColor = Color.FromArgb(51,204,102);
                groupBox2.Visible = true;
                cartCount.Visible = false;
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            addInCart.Enabled = false;
            if (listView1.SelectedItems.Count > 0)
            {
                Adding_Cart(Convert.ToString(listView1.SelectedItems[0].Text));
                groupBox1.Visible = true;
            }
            else
            {
                groupBox1.Visible = false;
            }
            groupBox2.Visible = true;
        }

        public void Adding_Cart(string name)
        {
            numericUpDown1.Maximum = Convert.ToInt32(Convert.ToString(listView1.SelectedItems[0].SubItems[3].Text));
            sumLable.Text = Convert.ToString((Convert.ToInt32(listView1.SelectedItems[0].SubItems[2].Text)) * (Convert.ToInt32(Math.Round(numericUpDown1.Value, 0)))) + "₽";
            panel6.Width = panel2.Width;
            openCart = true;
            panel6.BackColor = Color.FromArgb(51, 204, 102);
            groupBox1.Visible = true;
            if (listView1.SelectedItems[0].SubItems[3].Text != "0")
            {
                addInCart.Enabled = true;
                numericUpDown1.Value = 1;
            }
           
                nameLable.Text = name;
                sellerLable.Text = Convert.ToString(listView1.SelectedItems[0].SubItems[1].Text);
                priceLable.Text = Convert.ToString(listView1.SelectedItems[0].SubItems[2].Text + " ₽ за 1 единицу");
        }

        /*public void Editing_Cart(string name)
        {
            numericUpDown1.Value = 1;
            sumLable.Text = Convert.ToString((Convert.ToInt32(listView1.SelectedItems[0].SubItems[2].Text)) * (Convert.ToInt32(Math.Round(numericUpDown1.Value, 0)))) + "₽";
            panel6.Width = panel2.Width;
            openCart = true;
            panel6.BackColor = Color.FromArgb(51, 204, 102);
            groupBox1.Visible = true;
            try
            {
                nameLable.Text = name;
                sellerLable.Text = Convert.ToString(listView1.SelectedItems[0].SubItems[1].Text);
                priceLable.Text = Convert.ToString(listView1.SelectedItems[0].SubItems[2].Text + " ₽ за 1 единицу");
                numericUpDown1.Maximum = Convert.ToInt32(Convert.ToString(listView1.SelectedItems[0].SubItems[3].Text));
            }
            catch
            {

            }

        }*/

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            sumLable.Text = Convert.ToString((Convert.ToInt32(listView1.SelectedItems[0].SubItems[2].Text)) * (Convert.ToInt32(Math.Round(numericUpDown1.Value,0)))) + "₽";

        }

        private void AddInCart_Click(object sender, EventArgs e)
        {
            bool exist = false;
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                exist = nameLable.Text == listView2.Items[i].Text;
            }
            if (!exist)
            {
                listView2.Items.Add(nameLable.Text);
                listView2.Items[listView2.Items.Count - 1].SubItems.Add(Convert.ToString(numericUpDown1.Value));

                listView2.Items[listView2.Items.Count - 1].SubItems.Add(Convert.ToString(Convert.ToInt32(listView1.SelectedItems[0].SubItems[2].Text) * (Convert.ToInt32(numericUpDown1.Value))));
                costLable.Text = "0";
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    costLable.Text = Convert.ToString(Convert.ToInt32(costLable.Text) + Convert.ToInt32(listView2.Items[i].SubItems[2].Text));
                }
                payButton.Enabled = true;
            }
            groupBox1.Visible = false;
            cartCount.Text = Convert.ToString(Convert.ToInt32(cartCount.Text) + 1);

        }

        private void ListView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = true;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection collection = listView2.SelectedIndices;
            if (collection.Count != 0)
            {
                listView2.Items.RemoveAt(collection[0]);
                deleteButton.Enabled = false;
                
            }
            costLable.Text = "0";
            for (int i = 0; i < listView2.Items.Count; i++)
            {
                costLable.Text = Convert.ToString(Convert.ToInt32(costLable.Text) + Convert.ToInt32(listView2.Items[i].SubItems[2].Text));
            }
            cartCount.Text = Convert.ToString(Convert.ToInt32(cartCount.Text) - 1);
            if (listView2.Items.Count == 0)
            {
                payButton.Enabled = false;
            }
        }

        private void PayButton_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(costLable.Text) > User.Balance)
            {
                MessageBox.Show("Недостаточно средств! Пополните баланс через Личный кабинет", "Ошибка", MessageBoxButtons.OK);
            }
            else if (User.Address == "")
            {
                MessageBox.Show("Не указан адрес доставки! Укажите адрес через Личный кабинет", "Ошибка", MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    for (int i = 0; i < listView2.Items.Count; i++)
                    {
                        SQLiteCommand cmd = conn.CreateCommand();
                        string sql = "Insert into Orders (BuyerId, SellerId, GoodsId, Count, Price, Date, Completed, Address) " + " values (@buyerid, @sellerid, @goodsid, @count, @price, @date, @completed, @address) ";
                        string sql1 = "Select UserId from Goods where Name = '" + listView2.Items[i].Text + "'";
                        string sql2 = "Select GoodsId from Goods where Name = '" + listView2.Items[i].Text + "'";
                        cmd.CommandText = sql1;
                        int sellerid = Convert.ToInt32(cmd.ExecuteScalar());
                        cmd.CommandText = sql2;
                        int goodsid = Convert.ToInt32(cmd.ExecuteScalar());
                        cmd.CommandText = sql;
                        cmd.Parameters.Add("@buyerid", DbType.Int32).Value = User.Id;
                        cmd.Parameters.Add("@sellerid", DbType.Int32).Value = sellerid;
                        cmd.Parameters.Add("@goodsid", DbType.Int32).Value = goodsid;
                        cmd.Parameters.Add("@count", DbType.Int32).Value = Convert.ToInt32(listView2.Items[i].SubItems[1].Text);
                        cmd.Parameters.Add("@price", DbType.Int32).Value = Convert.ToInt32(listView2.Items[i].SubItems[2].Text);
                        cmd.Parameters.Add("@date", DbType.Date).Value = DateTime.Today;
                        cmd.Parameters.Add("@completed", DbType.Boolean).Value = false;
                        cmd.Parameters.Add("@address", DbType.String).Value = User.Address;
                        cmd.ExecuteNonQuery();
                        string sql6 = "Select Count from Goods where GoodsId = " + goodsid;
                        cmd.CommandText = sql6;
                        int count = Convert.ToInt32(cmd.ExecuteScalar()) - Convert.ToInt32(listView2.Items[i].SubItems[1].Text);
                        string sql5 = "Update Goods Set Count = " + count + " where GoodsId = " + goodsid;
                        cmd.CommandText = sql5;
                        cmd.ExecuteNonQuery();
                    }
                    SQLiteCommand cmd1 = conn.CreateCommand();
                    string sql3 = "Select Balance From User_table where Login = '" + User.Login + "'";
                    cmd1.CommandText = sql3;
                    int balance = Convert.ToInt32(cmd1.ExecuteScalar());
                    balance -= Convert.ToInt32(costLable.Text);
                    string sql4 = "Update User_table Set Balance = " + balance + " where Login = '" + User.Login + "'";
                    cmd1.CommandText = sql4;
                    cmd1.ExecuteNonQuery();
                    User.Balance = balance;
                    MessageBox.Show("Заказы успешно сформированы! Вы можете просмотреть свои заказы в Личном кабинете", "Успешно", MessageBoxButtons.OK);
                    listView2.Items.Clear();
                    deleteButton.Enabled = false;
                    costLable.Text = "0";
                    payButton.Enabled = false;
                    cartCount.Text = "0";
                    cartCount.Visible = false;
                    Refresh_Table(catName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex + "\n" + ex.StackTrace, "Ошибка", MessageBoxButtons.OK);
                }
            }
        }

        
    }
}
