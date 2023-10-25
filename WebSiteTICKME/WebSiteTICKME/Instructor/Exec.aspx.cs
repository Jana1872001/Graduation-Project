using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Instructor_Exec : System.Web.UI.Page
{
    int div;
    string crsid;
    int stid;
    DateTime date;
    int id,ID;
    string conStr = @"Data Source=DESKTOP-NK8PQBE; Database=P2SQL;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
       ID =Convert.ToInt32( (string)Session["InstructorID"]);

        if (!IsPostBack)
        {
            FillData();
        }

    }
    protected void OpenDocument(object sender, EventArgs e)
    {
        LinkButton Ink = (LinkButton)sender;
        GridViewRow gr = (GridViewRow)Ink.NamingContainer;
        id = int.Parse(GridView1.DataKeys[gr.RowIndex].Value.ToString());
        Download(id);
    }
    private void Download(int id)
    {

        DataTable dt = new DataTable();
        using (SqlConnection cn = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("GetDogument", cn);
            /*alter PROCEDURE GetDogument
--(
--@ID INT
--)
--AS
-- SELECT ID,Name,documentContent,Extn FROM Documents WHERE ID=@ID*/
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            cn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
        }
        string name = dt.Rows[0]["Name"].ToString();
        byte[] documentBytes = (byte[])dt.Rows[0]["documentContent"];
        Response.ClearContent();
        Response.ContentType = "application/octetstream";
        Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", name));
        Response.AddHeader("Content-Length", documentBytes.Length.ToString());
        Response.BinaryWrite(documentBytes);
        Response.Flush();
        Response.Close();


    }

    private void FillData()
    {
        DataTable dt= new DataTable();
        using (SqlConnection cn = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("GetDocumentsinst", cn);
            /*  
  create PROCEDURE GetDocumentsinst (@instid int)
  AS
   SELECT *
  FROM Documents where instid=@instid
 */
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            cmd.Parameters.Add("@instid", SqlDbType.Int).Value = ID;

            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
        }

        if (dt.Rows.Count > 0)
        {
            GridView1.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        else { GridView1.Visible = false; Label1.Text = "there is no any Execuses"; }

    }

    protected void AceptExec(object sender, EventArgs e)
    {
        LinkButton Ink = (LinkButton)sender;
        GridViewRow gr = (GridViewRow)Ink.NamingContainer;
        int id = int.Parse(GridView1.DataKeys[gr.RowIndex].Value.ToString());

        string a1 = "Select dat  FROM Documents WHERE ID=" + id;
        string a2 = "Select st_id  FROM Documents WHERE ID=" + id;
        string a3 = "Select cr_id  FROM Documents WHERE ID=" + id;
        using (SqlConnection connection = new SqlConnection(conStr))
        {

            connection.Open();
            SqlCommand command1 = new SqlCommand(a1, connection);
            SqlCommand command2 = new SqlCommand(a2, connection);
            SqlCommand command3 = new SqlCommand(a3, connection);
            SqlDataReader reader1 = command1.ExecuteReader();
            if (reader1.Read())
            {

                date =Convert.ToDateTime( (reader1["dat"]));



            }
            reader1.Close();
            SqlDataReader reader2 = command2.ExecuteReader();

            if (reader2.Read())
            {
                stid = Convert.ToInt32(reader2["st_id"]);

            }
            reader2.Close();
            SqlDataReader reader3 = command3.ExecuteReader();

            if (reader3.Read())
            {
                crsid = reader3["cr_id"].ToString();

            }
            reader3.Close();


            Label1.Text = date.ToString("yyy - MM - dd");
            a1 = "update Attendance_Absence set Status = 'Execused' where  Course_ID=@v2 and Student_ID=@v3 and dat=@v4";
             SqlCommand command = new SqlCommand(a1, connection);
             command.Parameters.AddWithValue("@v2", crsid);
             command.Parameters.AddWithValue("@v3", Convert.ToInt32(stid));
             command.Parameters.AddWithValue("@v4", Label1.Text);
             command.ExecuteScalar();
             //string add = " UPDATE Attendance_Absence SET counter = counter -1  WHERE Course_ID=@v2 and Student_ID=@v3 and dat=@v4;";
             //command = new SqlCommand(add, connection);
             //command.Parameters.AddWithValue("@v2", crsid);
             //command.Parameters.AddWithValue("@v3", Convert.ToInt32(stid));
             //command.Parameters.AddWithValue("@v4", Label1.Text);
             //command.ExecuteScalar();
            

        }



          Delete(Ink, id);
        FillData();

    }
    private void Delete(LinkButton Ink, int id)

   
   {
        GridViewRow gr = (GridViewRow)Ink.NamingContainer;

        string a = "DELETE FROM Documents WHERE ID=" + id;
        using (SqlConnection connection = new SqlConnection(conStr))
        {

            SqlCommand command = new SqlCommand(a, connection);

            connection.Open();
            command.ExecuteNonQuery();
            command.Clone();
            FillData();

        }
       
    }
        
        
    

    protected void RejecttExec(object sender, EventArgs e)
    {
        LinkButton Ink = (LinkButton)sender;
        GridViewRow gr = (GridViewRow)Ink.NamingContainer;
        int id = int.Parse(GridView1.DataKeys[gr.RowIndex].Value.ToString());

        Delete(Ink, id);
    }




    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}