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
    public partial class AdminPanel : Form
    {
        
        SQLiteDataAdapter adapter;
        public AdminPanel()
        {
            InitializeComponent();
            SQLiteConnection connection = DBUtils.GetDBConnection();
            string command = "Select * From Categories";
            adapter = new SQLiteDataAdapter(command, connection);
            SQLiteCommandBuilder builder = new SQLiteCommandBuilder(adapter);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "marketplaceDBDataSet7.Goods". При необходимости она может быть перемещена или удалена.
            this.goodsTableAdapter1.Fill(this.marketplaceDBDataSet7.Goods);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "marketplaceDBDataSet6.User_table". При необходимости она может быть перемещена или удалена.
            this.user_tableTableAdapter1.Fill(this.marketplaceDBDataSet6.User_table);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "marketplaceDBDataSet5.Goods". При необходимости она может быть перемещена или удалена.
            //this.goodsTableAdapter.Fill(this.marketplaceDBDataSet5.Goods);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "marketplaceDBDataSet1.Categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.marketplaceDBDataSet1.Categories);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "marketplaceDBDataSet.User_table". При необходимости она может быть перемещена или удалена.
            this.user_tableTableAdapter.Fill(this.marketplaceDBDataSet.User_table);

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateCategory_Click(object sender, EventArgs e)
        {
            adapter.Update((DataTable)dataGridView2.DataSource);
        }


        private void CloseButton_MouseMove(object sender, MouseEventArgs e)
        {
            closeButton.ForeColor = Color.FromArgb(51, 204, 102);
            closeButton.BackColor = Color.White;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            closeButton.ForeColor = Color.White;
            closeButton.BackColor = Color.FromArgb(51, 204, 102);
        }

        private void UpdateCategory_MouseMove(object sender, MouseEventArgs e)
        {
            updateCategory.ForeColor = Color.FromArgb(51, 204, 102);
            updateCategory.BackColor = Color.White;
        }

        private void UpdateCategory_MouseLeave(object sender, EventArgs e)
        {
            updateCategory.ForeColor = Color.White;
            updateCategory.BackColor = Color.FromArgb(51, 204, 102);
        }
    }
}
