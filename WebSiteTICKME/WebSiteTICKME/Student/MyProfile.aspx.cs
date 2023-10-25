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

public partial class Student_MyProfile : System.Web.UI.Page
{
    string cs;
    int StudentID;
    protected void Page_Load(object sender, EventArgs e)
    {
        StudentID = Convert.ToInt32((string)Session["Student_ID"]);
        IDtxtLable.Text = StudentID.ToString();

        cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;


        string a;
        SqlConnection ssd = new SqlConnection();

        ssd.ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
        ssd.Open();
        SqlCommand com;
        object result, result2;


        //  IDtxtLable.Text = "14785";
        a = "select Fname from Student where ID =" + IDtxtLable.Text;
        com = new SqlCommand(a, ssd);
        result = com.ExecuteScalar();
        a = "select Lname from Student where ID =" + IDtxtLable.Text;
        com = new SqlCommand(a, ssd);
        result2= com.ExecuteScalar();
        NametxtLable.Text = Convert.ToString(result)+" "+ Convert.ToString(result2);

        // gender
        a = "select Gender from Student where ID =" + IDtxtLable.Text;
        com = new SqlCommand(a, ssd);
        result = com.ExecuteScalar();
        GendertxtLable.Text = Convert.ToString(result);

        // email
        a = "select Email from Student where ID =" + IDtxtLable.Text;
        com = new SqlCommand(a, ssd);
        result = com.ExecuteScalar();
        EmailtxtLable.Text = Convert.ToString(result);
        //College
        a = "select College from Student where ID =" + IDtxtLable.Text;
        com = new SqlCommand(a, ssd);
        result = com.ExecuteScalar();
        CollegetxtLable.Text = Convert.ToString(result);
        //Section
        a = "select Specialization from Student where ID =" + IDtxtLable.Text;
        com = new SqlCommand(a, ssd);
        result = com.ExecuteScalar();
        SectiontxtLable.Text = Convert.ToString(result);

       


        //pass
        a = "select pass from Login_stu where Student_ID=" + IDtxtLable.Text;
        com = new SqlCommand(a, ssd);
        result = com.ExecuteScalar();
        PasswordtxtLable.Text = Convert.ToString(result);


        ssd.Close();

        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("spGetImageByTdi", con);
            /*
             create proc spGetImageByTdi
@id int
as
begin
select ImageData from Student where ID=@id
end */
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter Id = new SqlParameter()
            {
                ParameterName = "@Id",
                Value = Convert.ToInt32(IDtxtLable.Text)
            };
            cmd.Parameters.Add(Id);

            con.Open();
            byte[] bytes = (byte[])cmd.ExecuteScalar();
            string strBase64 = Convert.ToBase64String(bytes);
            Image1.ImageUrl = "data:Image/png;base64," + strBase64;

        }
        }

    protected void SavePictureButton_Click(object sender, EventArgs e)
    {
        HttpPostedFile postedFile = FileUpload1.PostedFile;
        string filename = Path.GetFileName(postedFile.FileName);
        string fileExtension = Path.GetExtension(filename);
        int fileSize = postedFile.ContentLength;

        if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif"
            || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
        {
            Stream stream = postedFile.InputStream;
            BinaryReader binaryReader = new BinaryReader(stream);
            Byte[] bytes = binaryReader.ReadBytes((int)stream.Length);



            using (SqlConnection con = new SqlConnection(cs))
            {

                SqlCommand cmd = new SqlCommand("addImagei", con);
                /*
                 * create proc addImagei
  @ID int,
  @ImageData varbinary(max)
  as
  Begin
  update Student set ImageData= @ImageData where ID=@ID
  End
                 */
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ID = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value = Convert.ToInt32(IDtxtLable.Text)
                };
                cmd.Parameters.Add(ID);

                SqlParameter paramImageData = new SqlParameter()
                {
                    ParameterName = "@ImageData",
                    Value = bytes
                };
                cmd.Parameters.Add(paramImageData);

              
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Upload Successful";

            }
            Response.Redirect("MyProfile.aspx");
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";

        }
    }

   
    protected void SaveButton_Click(object sender, EventArgs e)
    {
    }
}