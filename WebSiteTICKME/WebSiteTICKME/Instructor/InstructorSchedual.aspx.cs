using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class InstructorSchedual : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
       string InstructorID = (string)Session["InstructorID"]; 
       // GridView1.SelectedIndex = -1;
       
      

        SqlConnection ssd = new SqlConnection();
        ssd.ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";

        string a = "SELECT Course_name, ID, div,CourseRoom FROM Course where  Instructor_ID=" + InstructorID;
        SqlCommand com = new SqlCommand(a, ssd);
        ssd.Open();
        SqlDataReader dr = com.ExecuteReader();
        GridView1.DataSource = dr;
        GridView1.DataBind();
        dr.Close();
        ssd.Close();
       



    }



    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
           
             
              Session["CourseID"] = GridView1.SelectedRow.Cells[2].Text;
        Session["CoursName"] = GridView1.SelectedRow.Cells[1].Text;
        Session["CourseDiv"] = GridView1.SelectedRow.Cells[3].Text;
            Response.Redirect("ChoosenCourse.aspx");
           
        
        

       

    }





    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ChoosenCourse.aspx");
    }
}
