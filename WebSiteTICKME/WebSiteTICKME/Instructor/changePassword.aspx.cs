using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Instructor_changePassword : System.Web.UI.Page
{
   int InstructorID ;

    protected void Page_Load(object sender, EventArgs e)
    {
        InstructorID = Convert.ToInt32((string)Session["InstructorID"]);
        if (!IsPostBack)
        { ErrorLable.Visible = false;
            InstructorID = Convert.ToInt32((string)Session["InstructorID"]);
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
        else if (ConfirmNewPasswordTextBox.Text=="" || NewPasswordTextBox.Text=="")
        {
            ErrorLable.Visible = true;

            ErrorLable.Text = "insert password please.";
        }
        else

        {
            ErrorLable.Visible = true;
            ErrorLable.Text = "Password succesfully changed";
            ErrorLable.ForeColor = System.Drawing.Color.Green;
            string a = "update Login_inst set pass =" + ConfirmNewPasswordTextBox.Text + "where Instrucor_ID  =" + InstructorID;
            SqlCommand com = new SqlCommand(a, ssd);
            object r = com.ExecuteScalar();
            PasswordtxtLable.Text = ConfirmNewPasswordTextBox.Text;
        }
        ssd.Close();
    }
}