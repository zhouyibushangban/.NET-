using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeachingManagement
{
    public partial class Attendances : Form
    {
        public Attendances()
        {
            InitializeComponent();
        }
        private int user;
        private string passwd;
        public int recieve_user
        {
            set { this.user = value; }
        }
        public string recieve_passwd
        {
            set { this.passwd = value; }
        }
        private void Attendances_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Columns[i].DefaultCellStyle.SelectionBackColor = Color.White;
                dataGridView1.Columns[i].DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            SQL Att = new SQL(user,passwd,"老师");
            DataSet ds = new DataSet();
            Att.Attendances("","");
            ds = Att.ds;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                dataGridView1.Rows.Add(i + 1, ds.Tables[0].Rows[i][0],Att.CourseNmae(ds.Tables[0].Rows[i][0].ToString()),Att.ClassNmae(ds.Tables[0].Rows[i][0].ToString()) ,ds.Tables[0].Rows[i][1]);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.ToString() == "5")
            {
                Attendancess Atss = new Attendancess();
                Atss.recieve_user = user;
                Atss.recieve_passwd = passwd;
                Atss.recieve_cid = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                Atss.recieve_cname= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                Atss.Show();
            }
        }
    }
}
