using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class ChoosenCourse : System.Web.UI.Page
{
    string corsid,crsdiv,crsname;
    protected void Page_Load(object sender, EventArgs e)
    {
         corsid = (string)Session["CourseID"];//recivee var
         crsdiv = (string)Session["CourseDiv"];
        crsname = (string)Session["CoursName"];


        Label1.Text = "Lecture :" + " " + crsname;
        Label2.Text= "Section :" + " " + crsdiv.ToString();
        string ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
           string a = "SELECT [stu_ID]  FROM [STU_CORS] where div=@value1 and Course_ID=@value2";
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(a, connection);
            command.Parameters.AddWithValue("@value1",Convert.ToInt32( crsdiv));
            command.Parameters.AddWithValue("@value2", corsid);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                GridView1.DataSource = reader;
                GridView1.DataBind();
            }
            reader.Close();
            command.Clone();
        }
        
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }

    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
       /* Session["CourseID"] = corsid;
        Session["CourseDiv"] = crsdiv;*/
        Session["Student_ID"]= GridView1.SelectedRow.Cells[1].Text;
       // Session["Student_Name"] = GridView1.SelectedRow.Cells[1].Text;
        Response.Redirect("Details.aspx");
    }
}