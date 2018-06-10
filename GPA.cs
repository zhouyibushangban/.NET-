using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeachingManagement
{
    class GPA
    {
        
        private string connectionString = "server=服务器;database=TeachingManagement;uid=用户名;pwd=密码";//数据库连接字符串

        public double Gpa(int user,string passwd)
        {
            double G = 0;
            double Credit = 0;
            double GAP = 0;
            string sql = "SELECT 成绩,C.学分 FROM SC, Course C WHERE C.课程号 = SC.课程号 AND SC.成绩 IS NOT NULL AND C.课程号 NOT LIKE '1%' AND SC.学号=" + user;
            SqlConnection con = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            con.Open();//连接数据库
            SqlDataAdapter dataAdpt = new SqlDataAdapter(sql, con);
            dataAdpt.Fill(ds);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Credit += float.Parse((ds.Tables[0].Rows[i][1]).ToString());
                if (float.Parse((ds.Tables[0].Rows[i][0]).ToString())<60)
               {
                    G += 0;
                    
                }
                else if(float.Parse((ds.Tables[0].Rows[i][0]).ToString()) >=60 && float.Parse((ds.Tables[0].Rows[i][0]).ToString()) < 90)
                {
                    G += ((float.Parse((ds.Tables[0].Rows[i][0]).ToString()) - 60) * 0.1 + 1) * (float.Parse((ds.Tables[0].Rows[i][1]).ToString()));
                }
                else
                {
                    G += 4.0* (float.Parse((ds.Tables[0].Rows[i][1]).ToString()));

                }
            }
            GAP = G / Credit;
            return GAP;
        }
    }
}
