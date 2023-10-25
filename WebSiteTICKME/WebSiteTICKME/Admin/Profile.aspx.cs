using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Profile : System.Web.UI.Page
{
    int id ;

    object result;
    string a;
    string cs = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";

    protected void Page_Load(object sender, EventArgs e)
    {
        id = Convert.ToInt32((string)Session["Admin_ID"]);

        if (!IsPostBack)
        {
             id  = Convert.ToInt32((string)Session["Admin_ID"]);
            ErrorLable.Text = "";
            ErrorLable.Visible = false;
            SqlConnection ssd = new SqlConnection();

            ssd.ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
            ssd.Open();
            SqlCommand com;

            IDtxtLable.Text = id.ToString();




            //name
            //  IDtxtLable.Text = "14785";
            a = "select Fname from Adminn where ID =" + IDtxtLable.Text;
            com = new SqlCommand(a, ssd);
            result = com.ExecuteScalar();

            a = "select Lname from Adminn where ID =" + IDtxtLable.Text;
            com = new SqlCommand(a, ssd);
            object result2 = com.ExecuteScalar();
            NametxtLable.Text = Convert.ToString(result) + " " + Convert.ToString(result2);

            // gender


            // email
            a = "select Email from Adminn where ID =" + IDtxtLable.Text;
            com = new SqlCommand(a, ssd);
            result = com.ExecuteScalar();
            EmailtxtLable.Text = Convert.ToString(result);



            //pass
            a = "select pass from Login_adminn where Admin_ID=" + IDtxtLable.Text;
            com = new SqlCommand(a, ssd);
            result = com.ExecuteScalar();
            PasswordtxtLable.Text = Convert.ToString(result);


            ssd.Close();

            cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SPGetImageByTddii", con);
                /*
                 create proc spGetImageByTd
    @id int
    as
    begin
    select ImageData from Instructor where ID=@id
    end
                 */
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Id = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value = Convert.ToInt32(IDtxtLable.Text)
                };
                cmd.Parameters.Add(Id);

                con.Open();
                byte[] bytes = (byte[])cmd.ExecuteScalar();
                string strBase64 = Convert.ToBase64String(bytes);
                Image1.ImageUrl = "data:Image/png;base64," + strBase64;
            }
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


                SqlCommand cmd = new SqlCommand("addImageeii", con);


                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter ID = new SqlParameter()
                {
                    ParameterName = "@ID",
                    Value = Convert.ToInt32(IDtxtLable.Text)
                };
                cmd.Parameters.Add(ID);

                SqlParameter paramImageData = new SqlParameter()
                {
                    ParameterName = "@img",
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
           Response.Redirect("Profile.aspx");
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";

        }
    }
}