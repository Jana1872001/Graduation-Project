using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;


   
public partial class Admin_Recover_pass : System.Web.UI.Page
{
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
       id = Convert.ToInt32((string)Session["Admin_ID"]);
        if (!IsPostBack)
        {
            ErrorLable.Visible = false;
            id= Convert.ToInt32((string)Session["InstructorID"]);
        }

    }
    protected void SaveButton_Click(object sender, EventArgs e)
    {

        SqlConnection ssd = new SqlConnection();

        ssd.ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
        ssd.Open();
        if (ConfirmNewPasswordTextBox.Text != NewPasswordTextBox.Text)
        {

            ErrorLable.Visible = true;

            ErrorLable.Text = "Passwords not matches,tray again please.";

        }
        else if (ConfirmNewPasswordTextBox.Text == "" || NewPasswordTextBox.Text == "")
        {
            ErrorLable.Visible = true;

            ErrorLable.Text = "insert password please.";
        }
        else

        {
            ErrorLable.Visible = true;
            ErrorLable.Text = "Password succesfully changed";
            ErrorLable.ForeColor = System.Drawing.Color.Green;
            string a = "update Login_adminn set pass =" + ConfirmNewPasswordTextBox.Text + "where Admin_ID  =" + id;
            SqlCommand com = new SqlCommand(a, ssd);
            object r = com.ExecuteScalar();
            PasswordtxtLable.Text = ConfirmNewPasswordTextBox.Text;
        }
        ssd.Close();
    }



}
 
