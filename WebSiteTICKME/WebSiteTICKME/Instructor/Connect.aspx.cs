using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Net.Mail;




public partial class Connect : System.Web.UI.Page
{
    string InstructorID ;
  
    protected void Page_Load(object sender, EventArgs e)
    {
        SubjectTextBox.Text = null;
        MsgTextBox.Text = null;
        if (!IsPostBack)
        { Label1.Text = null; }
    }



    protected void SendButton_Click(object sender, EventArgs e)
    {
        InstructorID = (string)Session["InstructorID"];

        SqlConnection ssd = new SqlConnection();

        ssd.ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
        ssd.Open();

        string a = "select Email from Instructor where ID ="+InstructorID ;
        SqlCommand com = new SqlCommand(a, ssd);
        object result = com.ExecuteScalar();
        string email = result.ToString(); 

        string recipientEmail = "tickme040@gmail.com";//#######
      //  Label1.Text=ToDropDownList1.Text;
        Random rand = new Random();
        int newPassword = rand.Next(1, 100000);
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