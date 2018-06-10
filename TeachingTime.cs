using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeachingManagement
{
    class TeachingTime
    {
         
   
        public string Time(string time1,string time2)
        {
            char[] chars1 = time1.ToCharArray();
            char[] chars2 = time2.ToCharArray();
            string result1="";
            string result2="";
            if (time1 == "")
                result1 = "待定";
            else
            {
                if (chars1[0] == '1' || chars1[0] == '3')
                {
                    int x = int.Parse(chars1[0].ToString());
                    int y = x + int.Parse(chars1[2].ToString())-1;
                    result1 = "星期" + chars1[1].ToString() + "早上第" + x + "节到第" + y + "节";
                }
                else if (chars1[0] == '6' || chars1[0] == '8')
                {
                    int x = int.Parse(chars1[0].ToString()) ;
                    int y = x + int.Parse(chars1[2].ToString())-1;
                    result1 = "星期" + chars1[1].ToString() + "下午第" + x + "节到第" + y + "节";
                }
                else
                {
                    result1 = "星期" + chars1[1].ToString()+"晚上" + chars1[2].ToString() + "节";

                }
            }
            if (time2 == "")
                result2 = "";
            else
            {
                if (chars2[0] == '1' || chars2[0] == '3')
                {
                    int x = int.Parse(chars2[0].ToString());
                    int y = x + int.Parse(chars2[2].ToString())-1;
                    result2 = "|星期" + chars2[1].ToString() + "早上第" + x + "节到第" + y + "节";
                }
                else if (chars2[0] == '6' || chars2[0] == '8')
                {
                    int x = int.Parse(chars2[0].ToString());
                    int y = x + int.Parse(chars2[2].ToString())-1;
                    result2 = "|星期" + chars2[1].ToString() + "下午第" + x + "节到第" + y + "节";
                }
                else
                {
                    result2 = "|星期" + chars1[1].ToString() + "晚上" + chars2[2].ToString() + "节";

                }
            }
            return result1 + result2;

           
        }
    }
}
