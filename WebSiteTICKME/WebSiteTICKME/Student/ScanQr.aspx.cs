using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Http;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

public partial class Student_ScanQr : System.Web.UI.Page
{

    string crid;
    string div;int ID;
    int insID;
    string qr;
    string conStr = @"Data Source=DESKTOP-NK8PQBE; Database=P2SQL;Integrated Security=True";
    SqlConnection cn;
    string macAddress;

    protected void Page_Load(object sender, EventArgs e)
    {
        ID = Convert.ToInt32((string)Session["Student_ID"]);

        Label7.Text = ID.ToString();     
        if (!IsPostBack)

        {
            Timer1.Enabled = false;
            string a = "SELECT [Course_ID],[div], Course_name  FROM [STU_CORS]  where [stu_ID]=" + ID;
            using( cn = new SqlConnection(conStr))
            {
                cn.Open();
                SqlCommand command = new SqlCommand(a, cn);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    GridView1.DataSource = reader;
                    GridView1.DataBind();



                }
                reader.Close();
                cn.Close();
            }
        }

        if (!IsPostBack)
        {
          

            // Response.Write($"MAC Address: {macAddress}");
        }






    }
    private string GetMacAddress()
    {
        string macAddress = string.Empty;

       
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface nic in networkInterfaces)
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet
                    || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    if (nic.GetPhysicalAddress().ToString() != string.Empty)
                    {
                        macAddress = nic.GetPhysicalAddress().ToString();
                        break;
                    }
                }
            }

        string m = " UPDATE Attendance_Absence SET mac= @v  WHERE Student_ID = @v1 and dat = @v2 and Course_ID = @v3 and Cours_div = @v4; ";

        using (SqlConnection connection = new SqlConnection(conStr))
        {

            using (SqlCommand command1 = new SqlCommand(m, connection))
            {
                command1.Parameters.AddWithValue("@v", macAddress);

                command1.Parameters.AddWithValue("@v1", Label7.Text);
                command1.Parameters.Add("@v2", SqlDbType.Date).Value = DateTime.Now.ToString("yyy-MM-dd");
                command1.Parameters.AddWithValue("@v3", Label2.Text);
                command1.Parameters.AddWithValue("@v4", Convert.ToInt32(Label5.Text));
                connection.Open();
                command1.ExecuteNonQuery();
            }
            connection.Close();
        }


        return macAddress;
    }



    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Timer1.Enabled = true;
        crid = GridView1.SelectedRow.Cells[2].Text;//recivee var  "div"
        Label2.Text = crid;
        div = GridView1.SelectedRow.Cells[3].Text;
        Label5.Text = div;
        DataTable dt = new DataTable();
        string a1 = "Select Instructor_ID  FROM Course WHERE ID=@v1 and div=@v2";
        //  Label3.Text = div.ToString();
        SqlConnection cn;
        SqlCommand command1;
        using ( cn = new SqlConnection(conStr))
        {

            cn.Open();
             command1 = new SqlCommand(a1, cn);
            command1.Parameters.AddWithValue("@v1", crid);
            command1.Parameters.AddWithValue("@v2",Convert.ToInt32( div));

            SqlDataReader reader1 = command1.ExecuteReader();
            if (reader1.Read())
            {
                insID = Convert.ToInt32(reader1["Instructor_ID"]);


            }
            reader1.Close();


            a1 = "Select QR  FROM QRCode WHERE ID =" + insID;
            command1 = new SqlCommand(a1, cn);
            reader1 = command1.ExecuteReader();
            if (reader1.Read())
            {
                qr = (reader1["QR"]).ToString();
                Label3.Text = qr;



            }
            reader1.Close();
            Timer1.Enabled = true;
            //  Label3.Text = qr.ToString();



        }
        Label4.Text = GridView1.SelectedRow.Cells[1].Text;

        cn.Close();
        Timer1.Enabled = true;
     //  Label1.Text = Label3.Text;
        macAddress = GetMacAddress();
        Label8.Text = macAddress;
        // Label6.Text = qr;
        //  Label6.Text = macAddress;
    }


   


    protected void Timer1_Tick1(object sender, EventArgs e)
    {
        int res;
        Timer1.Enabled = false;
        
        if (Label1.Text == Label3.Text)
        {

           

            string s = "select Count(mac) From Attendance_Absence where  dat = @dat  and Course_ID=@v3";

            using (SqlConnection connection = new SqlConnection(conStr))
            {

                using (SqlCommand command1 = new SqlCommand(s, connection))
                {
                    command1.Parameters.AddWithValue("@dat", DateTime.Now.ToString("yyy-MM-dd"));
                    command1.Parameters.AddWithValue("@v3", Label2.Text);
                    connection.Open();
                    var count2 = command1.ExecuteScalar();
                    res = Convert.ToInt32(count2);
                }

                connection.Close();

            }


            if (res == 1)

            {
                Timer1.Enabled = false;
                s = "UPDATE Attendance_Absence SET Status ='Attendance'  WHERE Student_ID=@v1 and dat=@v2 and Course_ID=@v3 and Cours_div=@v4 ;";


                using (SqlConnection connection = new SqlConnection(conStr))
                {

                    using (SqlCommand command1 = new SqlCommand(s, connection))
                    {
                        command1.Parameters.AddWithValue("@v1", Label7.Text);
                        command1.Parameters.Add("@v2", SqlDbType.Date).Value = DateTime.Now.ToString("yyy-MM-dd");
                        command1.Parameters.AddWithValue("@v3", Label2.Text);
                        command1.Parameters.AddWithValue("@v4", Convert.ToInt32(Label5.Text));
                        connection.Open();
                       command1.ExecuteNonQuery();


                    }
                    connection.Close();

                }
                Label6.Text = "Succesfully scaned";



            }


            else
            {
               // Label6.Text = macAddress;
                s = "UPDATE Attendance_Absence SET  Status ='Blocked'  WHERE mac=@v1 and dat=@v2 and Course_ID=@v3 and Cours_div=@v4 ;";
                using (SqlConnection connection = new SqlConnection(conStr))
                {

                    using (SqlCommand command1 = new SqlCommand(s, connection))
                    {
                        command1.Parameters.AddWithValue("@v1", Label8.Text);
                        command1.Parameters.Add("@v2", SqlDbType.Date).Value = DateTime.Now.ToString("yyy-MM-dd");
                        command1.Parameters.AddWithValue("@v3", Label2.Text);
                        command1.Parameters.AddWithValue("@v4", Convert.ToInt32(Label5.Text));
                        connection.Open();
                        command1.ExecuteNonQuery();

                        Label6.Text = "You have been blocked";

                    }
                    connection.Close();

                }
                


            }



        }
       
        else
        {
            Label6.Text = "Dosent match";
            Timer1.Enabled = true;
        }
        Timer1.Enabled = true;


    }

}





