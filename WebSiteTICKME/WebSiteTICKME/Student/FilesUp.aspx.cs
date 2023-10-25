
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_FilesUp : System.Web.UI.Page
{
    string StudentID;public string crsid;
    object crname;
    int div,instid;
    string a;
    string conStr = @"Data Source=DESKTOP-NK8PQBE; Database=P2SQL;Integrated Security=True";
    protected void Page_Load(object sender, EventArgs e)
    {
        StudentID = (string)Session["Student_ID"];

       

          
        if (!IsPostBack)
        {
            FileUpload1.Enabled = false;
            SendButton.Enabled =false;
            StudentID = (string)Session["Student_ID"];
           
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string a = "SELECT [Course_name],id  FROM [STU_CORS]  where [stu_ID]=" + StudentID;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(a, connection);



                DropDownList1.DataSource = command.ExecuteReader();
                DropDownList1.DataTextField = "Course_name";
                DropDownList1.DataValueField = "id";
                DropDownList1.DataBind();
                connection.Close();
            }
        }
      

        if (!IsPostBack)
        {
            FillData();
        }

    }
    protected void show()
    {

        a = "select div from  [STU_CORS] where [Course_name]=@nn and STU_ID=@v2" ;
        string ba = "select Course_ID from[STU_CORS] where[Course_name] = @ss";
        string na = "select Instructor_ID from [Course] where ID=@v1 and div =@v2";
        //[Course
        using (SqlConnection connection = new SqlConnection(conStr))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(a, connection);
            
            

            command.Parameters.AddWithValue("@nn", DropDownList1.SelectedItem.Text);
            command.Parameters.AddWithValue("@v2",StudentID);
            SqlCommand command2 = new SqlCommand(ba, connection);
            command2.Parameters.AddWithValue("@ss", DropDownList1.SelectedItem.Text);


            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                div = Convert.ToInt32(reader["div"]);
               Label2.Text = div.ToString();

            }
            reader.Close();
            SqlDataReader reader2 = command2.ExecuteReader();
            if (reader2.Read())
            {
                crsid = reader2["Course_ID"].ToString();
                Label1.Text = crsid;

            }
            reader2.Close();

            
            SqlCommand command3 = new SqlCommand(na, connection);
            command3.Parameters.AddWithValue("@v1", crsid.ToString());
            command3.Parameters.AddWithValue("@v2", div);
            SqlDataReader reader3 = command3.ExecuteReader();

            if (reader3.Read())
            {
                instid = Convert.ToInt32(reader3["Instructor_ID"]);

                Label5.Text = instid.ToString();
            }
            reader3.Close();

            // reader = command.ExecuteReader();
            connection.Close();
        }
        //if (Label1.Text != null || Label2.Text != null)
        //{
        //    FileUpload1.Enabled = true;
        //}

       


    }
    protected void OpenDocument(object sender, EventArgs e)
    {
        LinkButton Ink = (LinkButton)sender;
        GridViewRow gr = (GridViewRow)Ink.NamingContainer;
        int id = int.Parse(GridView1.DataKeys[gr.RowIndex].Value.ToString());
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
        DataTable dt = new DataTable();
        using (SqlConnection cn = new SqlConnection(conStr))
        {
            SqlCommand cmd = new SqlCommand("GetDocuments", cn);
            /*  
   alter PROCEDURE GetDocuments(@st_id int)
  AS
   SELECT *
  FROM Documents where st_id=@st_id
 */
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            cmd.Parameters.Add("@st_id", SqlDbType.VarChar).Value = StudentID;

            SqlDataReader reader = cmd.ExecuteReader();

            dt.Load(reader);
        }

        if (dt.Rows.Count > 0)
        {
            GridView1.Visible = true;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            Label4.Visible = false;
        }
        else { Label4.Visible = true; Label1.Visible = false; GridView1.Visible = false; Label4.Text = "There is no any Execuses"; }

    }






    protected void DeleteDocument(object sender, EventArgs e)
    {
        LinkButton Ink = (LinkButton)sender;
        GridViewRow gr = (GridViewRow)Ink.NamingContainer;
        int id = int.Parse(GridView1.DataKeys[gr.RowIndex].Value.ToString());

       // GridViewRow gr = (GridViewRow)Ink.NamingContainer;

        string a = "DELETE FROM Documents WHERE ID=" + id;
        using (SqlConnection connection = new SqlConnection(conStr))
        {

            SqlCommand command = new SqlCommand(a, connection);

            connection.Open();
            command.ExecuteNonQuery();
            command.Clone();
           
        }

        FillData();


    }

    protected void SendButton_Click1(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)

        {
            FileInfo fi = new FileInfo(FileUpload1.FileName);
            byte[] documentContent = FileUpload1.FileBytes;
            string name = fi.Name;
            string extn = fi.Extension;
            if (extn.ToLower() == ".jpg" || extn.ToLower() == ".gif"
               || extn.ToLower() == ".png" || extn.ToLower() == ".bmp" || extn.ToLower() == ".pdf" || extn.ToLower() == ".doc")
            {
                using (SqlConnection cn = new SqlConnection(conStr))
                {
                    SqlCommand cmd = new SqlCommand("SaveDocument", cn);
                    /*alter PROCEDURE SaveDocument
    (@Name VARCHAR (100),
    @Content VARBINARY (5000),
    @EXtn VARCHAR (5),
    @st_id int,
    @cr_id varchar(10),
    @div int,
    @crname varchar(max),
    @dat date
                    @instid int


    )
    AS
    INSERT INTO Documents (Name, DocumentContent, Extn,st_id ,cr_id,div,crname,dat,instid)
     VALUES (@Name, @Content, @Extn ,@st_id ,@cr_id,@div,@crname,@dat,@instid)
    */
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@Content", SqlDbType.VarBinary).Value = documentContent;
                    cmd.Parameters.Add("@Extn", SqlDbType.VarChar).Value = extn;
                    cmd.Parameters.Add("@div", SqlDbType.VarChar).Value = Label2.Text;
                    cmd.Parameters.Add("@st_id", SqlDbType.VarChar).Value = StudentID;
                    cmd.Parameters.Add("@cr_id", SqlDbType.VarChar).Value = Label1.Text;
                    cmd.Parameters.Add("@crname", SqlDbType.VarChar).Value = DropDownList1.SelectedItem.Text;
                    cmd.Parameters.Add("@dat", SqlDbType.Date).Value = DateTime.Now.ToString("yyy - MM - dd");
                    cmd.Parameters.Add("@instid", SqlDbType.Int).Value = Label5.Text;

                    // Label1.Text = crsid;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    Label1.Visible = true;
                    Label1.ForeColor = System.Drawing.Color.White;
                    Label1.Text = "Send Successful";

                }
                FillData();
            }
            else
            {
                Label1.Visible = true;
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Only images (.jpg, .png, .gif and .bmp .pdf .doc) can be uploaded";

            }
        }
        else
        {
            Label1.Visible = true;
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "Chose file";
        }

    }

    
    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        FileUpload1.Enabled = true;
        SendButton.Enabled = true;

        //  Label1.Text = DropDownList1.SelectedItem.Text;
        show();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}