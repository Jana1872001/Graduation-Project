﻿using System;
using System.Data.SqlClient;
using System.Net.Mail;

public partial class Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    
    }

    protected void txtid_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Button_Login_Click(object sender, EventArgs e)
    {



    }


    protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
    {

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {


        string ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
        string a = "SELECT Admin_ID,pass FROM Login_adminn where Admin_ID=@value1 and pass=@value2";
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            if (IDTextBox.Text != "" && PassTextBox.Text != "")
            {
                connection.Open();
                SqlCommand command = new SqlCommand(a, connection);
                command.Parameters.AddWithValue("@value1", Convert.ToInt32(IDTextBox.Text));
                command.Parameters.AddWithValue("@value2", Convert.ToInt32(PassTextBox.Text));
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    Session["Admin_ID"] = IDTextBox.Text;
                    Response.Redirect("Home.aspx");

                }
                else
                {
                    Label2.Visible = true;
                    Label2.ForeColor = System.Drawing.Color.Red;
                    Label2.Text = ("ID or Password not correct, please tray again.");
                }
                reader.Close();
                command.Clone();

            }

            else
            {
                Label2.Visible = true;
                Label2.ForeColor = System.Drawing.Color.Red;
                Label2.Text = ("ID or Password not correct, please tray again.");
            }





        }
    }

        protected void SendButton_Click1(object sender, EventArgs e)
    {


        SqlConnection ssd = new SqlConnection();

        ssd.ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
        ssd.Open();

        string a = "select Email from Adminn where ID =" + IDTextBox1.Text;
        SqlCommand com = new SqlCommand(a, ssd);
        object result = com.ExecuteScalar();
        string email = "tickme040@gmail.com";

        string recipientEmail = result.ToString();
        Random rand = new Random();
        int newPassword = rand.Next(1, 100000);
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(email);
            mail.To.Add(recipientEmail);
            mail.Subject = "Password Recovery";
            mail.Body = "Your new password is:" + newPassword;
            Label1.Text = newPassword.ToString();
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(email, "kqcjlvpvuwrfovcr");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);


        }

        catch (Exception ex)
        {
            Label1.Visible = true;
            Label1.Text = ("An error occurred: " + ex.Message);
        }
        Label1.Visible = true;
        Label1.Text = ("Password recovery email sent successfully.");

        string x = "update Login_adminn set pass =" + newPassword + "where Admin_ID =" + IDTextBox1.Text;
        com = new SqlCommand(x, ssd);
        com.ExecuteScalar();
        ssd.Close();

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        MultiView1.Visible = true;
        MultiView1.ActiveViewIndex = 0;
    }
}