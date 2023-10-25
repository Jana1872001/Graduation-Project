using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_ChangePassword : System.Web.UI.Page
{
    int StudentID; 
    protected void Page_Load(object sender, EventArgs e)
    {
        StudentID = Convert.ToInt32((string)Session["Student_ID"]);
        if (!IsPostBack)
        {
            ErrorLable.Visible = false;
            StudentID = Convert.ToInt32((string)Session["Student_ID"]);
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
            string a = "update Login_stu set pass =" + ConfirmNewPasswordTextBox.Text + "where Student_ID =" + StudentID;
            SqlCommand com = new SqlCommand(a, ssd);
            object r = com.ExecuteScalar();
            PasswordtxtLable.Text = ConfirmNewPasswordTextBox.Text;
        }
        ssd.Close();
    }
}