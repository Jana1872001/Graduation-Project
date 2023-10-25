using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Contact_Us : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SendButton_Click(object sender, EventArgs e)
    {
       int ID = Convert.ToInt32((string)Session["Student_ID"]);

        SqlConnection ssd = new SqlConnection();

        ssd.ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
        ssd.Open();

        string a = "select Email from Student where ID =" + ID;
        SqlCommand com = new SqlCommand(a, ssd);
        object result = com.ExecuteScalar();
        string email = result.ToString();

        string recipientEmail = "tickme040@gmail.com";//#######
                                                      //  Label1.Text=ToDropDownList1.Text;
        
        try
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(email);
            mail.To.Add(recipientEmail);
            mail.Subject = SubjectTextBox.Text;
            mail.Body = MsgTextBox.Text;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(email, "qlpvwnygkdvnxbtq");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            Label1.Text = (" email sent successfully.");

        }
        catch (Exception ex)
        {
            Label1.Text = ("An error occurred: " + ex.Message);
        }


    }
}