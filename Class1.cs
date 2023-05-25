using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace SimpleBillApplication
{
    public class clsbill
    {
        public string Billno;
        public string BillDate;
        public string CustomerCode;
        public List<clsbilltr> arrbilltr;


        public static bool savedata(clsbill objbill)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=192.168.1.100; User Id=a; Password=a; Initial Catalog=SimpleBillApplication; Integrated Security=false";
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            string str1 = "insert into Bill (Billno,BillDate,CustomerCode) values('" + objbill.Billno + "','" + objbill.BillDate + "','" + objbill.CustomerCode + "')";
            cmd.CommandText = str1;
            cmd.ExecuteNonQuery();
            for(int i = 0; i < objbill.arrbilltr.Count; i++)
            {
                string str2 = "insert into Billtr (Billno,Icode,Qty,Rate,Amt) values('" + objbill.Billno + "','" + objbill.arrbilltr[i].Icode + "','" + objbill.arrbilltr[i].Qty + "','" + objbill.arrbilltr[i].Rate + "','" + objbill.arrbilltr[i].Amt + "')";
                cmd.CommandText = str2;
                cmd.ExecuteNonQuery();
            }
            

            conn.Close();
            return true;

        }

        public static clsbill getdata(string sbillno)
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=192.168.1.100; User Id=a; Password=a; Initial Catalog=SimpleBillApplication; Integrated Security=false";
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string str1 = "select * from Bill where Billno='" + sbillno + "'";

            cmd.CommandText = str1;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);


            clsbill objbill = new clsbill();
            objbill.Billno = dt1.Rows[0]["Billno"].ToString();
            objbill.BillDate = dt1.Rows[0]["BillDate"].ToString();
            objbill.CustomerCode = dt1.Rows[0]["CustomerCode"].ToString();

            objbill.arrbilltr = new List<clsbilltr>();

            string str2 = "select * from Billtr where Billno='" + sbillno + "'";

            cmd.CommandText = str2;
            da = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);

            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                clsbilltr objbilltr = new clsbilltr();
                objbilltr.Icode = dt2.Rows[i]["Icode"].ToString();
                objbilltr.Qty = dt2.Rows[i]["Qty"].ToString();
                objbilltr.Rate = dt2.Rows[i]["Rate"].ToString();
                objbilltr.Amt = dt2.Rows[i]["Amt"].ToString();
                objbill.arrbilltr.Add(objbilltr);
            }
            conn.Close();
            return objbill;

        }

    }

        

    public class clsbilltr
    {
        public string Icode;
        public string Qty;
        public string Rate;
        public string Amt;
    }
   
    public class clsclient
    {
        public string Code;
        public string Name;

        public static clsclient getclientdata(string ccode)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=192.168.1.100; User Id=a; Password=a; Initial Catalog=SimpleBillApplication; Integrated Security=false";
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string str1 = "select * from Client where Code='" + ccode + "'";

            cmd.CommandText = str1;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);


            clsclient objclient = new clsclient();
            objclient.Code = dt1.Rows[0]["Code"].ToString();
            objclient.Name = dt1.Rows[0]["Name"].ToString();
            
            conn.Close();
            return objclient;
        }
    }

    public class clsItem
    {
        public string Id;
        public string Name;
        public string Rate;

        public static clsItem getitemdata(string item)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=192.168.1.100; User Id=a; Password=a; Initial Catalog=SimpleBillApplication; Integrated Security=false";
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string str1 = "select * from Item where Id ='" + item + "'";

            cmd.CommandText = str1;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);


            clsItem objitem = new clsItem();

            objitem.Id = dt1.Rows[0]["Id"].ToString();
            objitem.Name = dt1.Rows[0]["Name"].ToString();
            objitem.Rate = dt1.Rows[0]["Rate"].ToString();

            conn.Close();
            return objitem;
        }

    }

    public class clsModal
    {
        public List<clsItem> arritems = new List<clsItem>();
        
        public static clsModal showData()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=192.168.1.100; User Id=a; Password=a; Initial Catalog=SimpleBillApplication; Integrated Security=false";
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string str1 = "select * from Item";

            cmd.CommandText = str1;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);

            clsModal objModal = new clsModal();

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                clsItem objItem = new clsItem();
                objItem.Id = dt1.Rows[i]["Id"].ToString();
                objItem.Name = dt1.Rows[i]["Name"].ToString();
                objItem.Rate = dt1.Rows[i]["Rate"].ToString();

                objModal.arritems.Add(objItem);
            }

            conn.Close();
            return objModal;
        }
    }
}