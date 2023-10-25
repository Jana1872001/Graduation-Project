using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Xml.Linq;
using System.Runtime.Remoting.Messaging;
using System.Activities.Expressions;
using System.Management;

public partial class Admin_Courses_Detiles : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
    string cID;
    string div;

    protected void Page_Load(object sender, EventArgs e)
    {
        add();
        if (!IsPostBack)
        {
            TextBox15.Text = "";
            TextBox8.Text = "";
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            add();
        }
        string st = "SELECT * FROM [Course]";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            SqlCommand command = new SqlCommand(st, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {




                GridView1.DataSource = reader;
                GridView1.DataBind();
                connection.Close();
            }
        }
        TextBox4 .Visible = false;
        TextBox9 .Visible = false;
        TextBox10.Visible = false;
        TextBox11.Visible = false;
        TextBox12.Visible = false;
        TextBox13.Visible = false;
        TextBox14.Visible = false;
        TextBox16.Visible = false;
        Button4.Visible = false;
        Button3.Visible = false;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {if (
            TextBox8.Text == "" || TextBox1.Text == "" || TextBox2.Text == ""  || TextBox5.Text == "" || TextBox6.Text == "" || TextBox7.Text == "")
        { Label3.Text = "Fill all text boxes please."; }
        else
        {
            Label3.Text = "";
            //string connectionString = ConfigurationManager.ConnectionStrings["Attendace_SystemConnectionString"].ConnectionString;
            string selectQuery = "INSERT INTO Course VALUES(@Course_name ,@ID ,@div , @College ,@Section ,@Instructor_name ,@Instructor_ID,@CourseRoom)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(selectQuery, connection);
                command.Parameters.AddWithValue("@Course_name", TextBox8.Text);
                command.Parameters.AddWithValue("@ID", TextBox1.Text);
                command.Parameters.AddWithValue("@div", TextBox2.Text);
                command.Parameters.AddWithValue("@CourseRoom", TextBox15.Text);

                command.Parameters.AddWithValue("@College", DropDownList2.SelectedItem.Text);
                command.Parameters.AddWithValue("@Section", TextBox5.Text);
                command.Parameters.AddWithValue("@Instructor_name", TextBox6.Text);
                command.Parameters.AddWithValue("@Instructor_ID", TextBox7.Text);

                int t = command.ExecuteNonQuery();
                if (t > 0)
                {
                    Response.Write("<script> alert('Data has been submetted successfuly') </script>");
                }
                //SqlDataReader reader = command.ExecuteReader();
                //if (reader.HasRows)
                //{
                //    // login successful
                //    Response.Redirect("Home.aspx");
                //}
                //else
                //{
                //    // login failed
                //    Console.WriteLine("Login failed.");
                //}
                connection.Close();
            }
        }
        add();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox15.Text = "";
        TextBox8.Text = "";
        TextBox1.Text = "";
        TextBox2.Text = "";
        //TextBox4.Text = "";
        TextBox5.Text = "";
        TextBox6.Text = "";
        TextBox7.Text = "";
        add();
    }
   


   

    protected void Button3_Click(object sender, EventArgs e)
    {


        string delete2 = "Delete from[STU_CORS] where Course_ID = @Course_ID AND div=@div";
        string delete = "Delete from[Course] where ID = @ID";
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            cn.Open();
            SqlCommand command = new SqlCommand(delete2, cn);

            command.Parameters.AddWithValue("@Course_ID", Label1.Text);
            command.Parameters.AddWithValue("@div", Label2.Text);
            command.ExecuteNonQuery();
            SqlCommand command2 = new SqlCommand(delete, cn);
            command2.Parameters.AddWithValue("@ID", Label1.Text);
            command2.ExecuteNonQuery();

            cn.Close();
        }
        add();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label1.Text = GridView1.SelectedRow.Cells[2].Text;
        Label2.Text = GridView1.SelectedRow.Cells[4].Text;
        TextBox4.Visible = true;
        TextBox9.Visible = true;
        TextBox10.Visible =true;
        TextBox11.Visible =true;
        TextBox12.Visible =true;
        TextBox13.Visible =true;
        TextBox16.Visible = true;
        TextBox14.Visible = true;
        Button3.Visible = true;
        Button4.Visible=true;
        TextBox4 .Text=GridView1.SelectedRow.Cells[1].Text;
        TextBox9 .Text=GridView1.SelectedRow.Cells[2].Text;
        TextBox16.Text = GridView1.SelectedRow.Cells[3].Text;
        TextBox10.Text=GridView1.SelectedRow.Cells[4].Text;
        TextBox11.Text=GridView1.SelectedRow.Cells[5].Text;
        TextBox12.Text=GridView1.SelectedRow.Cells[6].Text;
        TextBox13.Text=GridView1.SelectedRow.Cells[7].Text;
        TextBox14.Text= GridView1.SelectedRow.Cells[8].Text;
        add();

    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string s = "UPDATE [Course] SET Course_name=@Course_name,ID=@IDD,@CourseRoom=@CourseRoom,div=@divv,College=@College,Section=@Section,Instructor_name=@Instructor_name,Instructor_ID=@Instructor_ID WHERE ID=@ID AND div=@div";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(s, connection);
            command.Parameters.AddWithValue("@Course_name", TextBox4.Text);
            command.Parameters.AddWithValue("@IDD", TextBox9.Text);
            command.Parameters.AddWithValue("@divv", TextBox10.Text);
            command.Parameters.AddWithValue("@ID", GridView1.SelectedRow.Cells[2].Text);
            command.Parameters.AddWithValue("@div", GridView1.SelectedRow.Cells[4].Text);
            command.Parameters.AddWithValue("@CourseRoom", TextBox16.Text);

            command.Parameters.AddWithValue("@College", TextBox11.Text);
            command.Parameters.AddWithValue("@Section", TextBox12.Text);
            command.Parameters.AddWithValue("@Instructor_name", TextBox13.Text);
            command.Parameters.AddWithValue("@Instructor_ID", TextBox14.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }


        string ss = "UPDATE [STU_CORS] SET Course_ID=@Course_IDD,div=@divv,Course_name=@Course_name WHERE Course_ID=@Course_ID AND div=@div ";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command2 = new SqlCommand(ss, connection);
            command2.Parameters.AddWithValue("@Course_name", TextBox4.Text);
            command2.Parameters.AddWithValue("@Course_IDD", TextBox9.Text);
            command2.Parameters.AddWithValue("@Course_ID", GridView1.SelectedRow.Cells[2].Text);
            command2.Parameters.AddWithValue("@divv", TextBox10.Text);
            command2.Parameters.AddWithValue("@div", GridView1.SelectedRow.Cells[4].Text);
           command2.ExecuteNonQuery();
            connection.Close(); 
        }
        add();
    }
    void add()
    {
        string m = "SELECT* FROM[Course]";

        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(m, cn);


            cn.Open();

            SqlDataReader reader = cmd.ExecuteReader();


            if (reader.HasRows)
            {

                GridView1.Visible =true;
                GridView1.DataSource = reader;
                GridView1.DataBind();

            }
            else { GridView1.Visible = false; }
            cn.Close();
        }
    }
}