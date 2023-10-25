﻿using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Add_Studant : System.Web.UI.Page
{
    string connectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
      //  add();
        if (!IsPostBack)
        {

            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            add();

        }

        TextBox12.Visible = false;
        TextBox4.Visible = false;
        TextBox5.Visible = false;
        TextBox6.Visible = false;
        TextBox7.Visible = false;
        TextBox8.Visible = false;
        TextBox9.Visible = false;
        TextBox10.Visible = false;
        Button4.Visible = false;
        Button3.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "" || TextBox2.Text == "" || TextBox3.Text == "")
        {
            Label3.Text = "Fill all text boxes please.";
        }
        else
        {
            Label3.Text = "";
            string gender = DropDownList1.SelectedValue;
            string photoPath;
            if (gender == "M")
            {
                photoPath = Server.MapPath("~/Media/mann.png"); // Path to male photo
            }
            else
            {
                photoPath = Server.MapPath("~/Media/woman.png"); // Path to female photo
            }
            // Convert the photo file to byte array
            byte[] photoBytes = File.ReadAllBytes(photoPath);

            string selectQuery = "INSERT INTO Student VALUES(@ID,@Fname,@Lname,@Gender,@Email,@Specialization,@College,@ImageData)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(selectQuery, connection);
                Random rn = new Random();
                string newID = TextBox13.Text + rn.Next(1, 100000);
                command.Parameters.AddWithValue("@ID", newID);
                command.Parameters.AddWithValue("@Fname", TextBox1.Text);
                command.Parameters.AddWithValue("@Lname", TextBox2.Text);
                command.Parameters.AddWithValue("@Gender", DropDownList1.SelectedItem.Text);
                command.Parameters.AddWithValue("@Email", TextBox3.Text);
                command.Parameters.AddWithValue("@Specialization", TextBox11.Text);
                command.Parameters.AddWithValue("@College", DropDownList2.SelectedItem.Text);


                command.Parameters.AddWithValue("@ImageData", photoBytes);
                int tt = command.ExecuteNonQuery();
                rn = new Random();
                int newPassword = rn.Next(1, 100000);
                selectQuery = "INSERT INTO Login_stu VALUES(@Student_name,@Student_ID,@pass)";
                command = new SqlCommand(selectQuery, connection);

                command.Parameters.AddWithValue("@Student_name", TextBox1.Text + TextBox2.Text);
                command.Parameters.AddWithValue("@Student_ID", newID);
                command.Parameters.AddWithValue("@pass", newPassword);


                int t = command.ExecuteNonQuery();
                if (t > 0)
                {
                    Response.Write("<script> alert('Data has been submetted successfuly') </script>");
                }
                connection.Close();
            }
        }
        add();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
        add();

    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        string delete2 = "Delete from[Login_stu] where Student_ID = @Student_ID ";
        string delete = "Delete from[Student] where ID = @ID";
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            cn.Open();
            SqlCommand command = new SqlCommand(delete2, cn);

            command.Parameters.AddWithValue("@Student_ID", Label1.Text);
           
            command.ExecuteNonQuery();
            SqlCommand command2 = new SqlCommand(delete, cn);
            command2.Parameters.AddWithValue("@ID", Label1.Text);
            command2.ExecuteNonQuery();

            cn.Close();
        }
        add();
    }

    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Label1.Text = GridView1.SelectedRow.Cells[1].Text;
        TextBox4.Visible = false;
        TextBox5.Visible = true;
        TextBox6.Visible = true;
        TextBox7.Visible = true;
        TextBox8.Visible = true;
        TextBox9.Visible = true; 
        TextBox12.Visible = true;
        //  TextBox10.Visible = true;
        Button4.Visible = true;
        Button3.Visible = true;
        TextBox4.Text = GridView1.SelectedRow.Cells[1].Text;
        TextBox5.Text = GridView1.SelectedRow.Cells[2].Text;
        TextBox6.Text = GridView1.SelectedRow.Cells[3].Text;
        TextBox7.Text = GridView1.SelectedRow.Cells[4].Text;
        TextBox8.Text = GridView1.SelectedRow.Cells[5].Text;
        TextBox12.Text = GridView1.SelectedRow.Cells[6].Text;

        TextBox9.Text = GridView1.SelectedRow.Cells[7].Text;
        //  TextBox10.Text = GridView1.SelectedRow.Cells[7].Text;
        add();
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        string s = "UPDATE [Student] SET ID=@IDD,Fname=@Fname,Lname=@Lname,Gender=@Gender,College=@College,Specialization=@Specialization,Email=@Email WHERE ID=@ID ";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(s, connection);
            command.Parameters.AddWithValue("@IDD", TextBox4.Text);
            command.Parameters.AddWithValue("@ID", GridView1.SelectedRow.Cells[1].Text);
            command.Parameters.AddWithValue("@Fname", TextBox5.Text);
            command.Parameters.AddWithValue("@Lname", TextBox6.Text);
            command.Parameters.AddWithValue("@Gender", TextBox7.Text);
            command.Parameters.AddWithValue("@College", TextBox8.Text);
            command.Parameters.AddWithValue("@Specialization", TextBox12.Text);
            command.Parameters.AddWithValue("@Email", TextBox9.Text);
            command.ExecuteNonQuery();
            connection.Close();
        }
        add();
       
    }
    void add()
    {
        string m = "SELECT * FROM [Student]";
        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            SqlCommand cmd = new SqlCommand(m, cn);


            cn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {

                GridView1.Visible = true;
                GridView1.DataSource = reader;
                GridView1.DataBind();

            }
            else { GridView1.Visible = false; }
            cn.Close();
        }
    }
}

