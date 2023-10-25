using System;
using System.Web.UI;
using System.Data.SqlClient;

using System.Linq;
using System.Configuration;
using System.Data;

public partial class Instructor_profile_page : System.Web.UI.Page
{
    string InstructorID;
    string a;
    object result;
   // SqlConnection ssd = new SqlConnection();
    SqlCommand com;
    protected void Page_Load(object sender, EventArgs e)
    {
        InstructorID = (string)Session["InstructorID"];
        //string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(cs))
        //{
        //    SqlCommand cmd = new SqlCommand("spGetImageByTd", con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    SqlParameter Id = new SqlParameter()
        //    {
        //        ParameterName = "@Id",
        //        Value = Convert.ToInt32(InstructorID)
        //    };
        //    cmd.Parameters.Add(Id);
        //    con.Open();
        //    byte[] bytes = (byte[])cmd.ExecuteScalar();
        //    string strBase64 = Convert.ToBase64String(bytes);
        //    MyProfileImageButton.ImageUrl = "data:Image/png;base64," + strBase64;

        //}

     
      

     /*   ssd.ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
        ssd.Open();

         a = "select Gender from Instructor where ID =" + InstructorID;
        com = new SqlCommand(a, ssd);
         result = com.ExecuteScalar();
        //if (Convert.ToString(result) == "F")
        //{ MyProfileImageButton.ImageUrl = "~/images/femaleinstructorprofile.jpg"; }
        //else
        //    MyProfileImageButton.ImageUrl = "~/images/maleinstructorlogo-512.jpg";
        ssd.Close();*/
    }

  

    protected void InstructorScheduleImageButton_Click(object sender, ImageClickEventArgs e)
    {
       
    }
   

    protected void CoursesImageButton_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Exec.aspx");
    }

    

   
    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Connect.aspx");
    }

    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Exec.aspx");
    }

    protected void ImageButton3_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("InstructorSchedual.aspx");

    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("QR_code.aspx");
    }

    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("changePassword.aspx");
    }
}