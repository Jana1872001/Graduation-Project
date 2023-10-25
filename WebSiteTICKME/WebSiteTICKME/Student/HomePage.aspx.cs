using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_HomePage : System.Web.UI.Page
{
    int Student_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        Student_ID = Convert.ToInt32((string)Session["Student_ID"]);
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
    }

    protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Contact_Us.aspx");
    }

    protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("FilesUp.aspx");
    }

    protected void ImageButton3_Click1(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Details.aspx");
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ScanQr.aspx");
    }



    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ChangePassword.aspx");
    }
}