
using DevExpress.Utils.CommonDialogs.Internal;
using Microsoft.Win32;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

public partial class MyProfile_Inst : System.Web.UI.Page
{
   int InstructorID ;
    object result;
    string a;
    string cs= "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
   // SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
        {
            InstructorID = Convert.ToInt32((string)Session["InstructorID"]);
           
            SqlConnection ssd = new SqlConnection();

            ssd.ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
            ssd.Open();
            SqlCommand com;

            IDtxtLable.Text = InstructorID.ToString();




            //name
            //  IDtxtLable.Text = "14785";
            a = "select Fname from Instructor where ID =" + IDtxtLable.Text;
            com = new SqlCommand(a, ssd);
            result = com.ExecuteScalar();

            a = "select Lname from Instructor where ID =" + IDtxtLable.Text;
            com = new SqlCommand(a, ssd);
            object result2 = com.ExecuteScalar();
            NametxtLable.Text = Convert.ToString(result) + " " + Convert.ToString(result2);

            // gender
            a = "select Gender from Instructor where ID =" + IDtxtLable.Text;
            com = new SqlCommand(a, ssd);
            result = com.ExecuteScalar();
            GendertxtLable.Text = Convert.ToString(result);

            // email
            a = "select Email from Instructor where ID =" + IDtxtLable.Text;
            com = new SqlCommand(a, ssd);
            result = com.ExecuteScalar();
            EmailtxtLable.Text = Convert.ToString(result);
            //College
            a = "select College from Instructor where ID =" + IDtxtLable.Text;
            com = new SqlCommand(a, ssd);
            result = com.ExecuteScalar();
            CollegetxtLable.Text = Convert.ToString(result);
            //Section
           

            //Specialization
            a = "select Specialization from Instructor where ID =" + IDtxtLable.Text;
            com = new SqlCommand(a, ssd);
            result = com.ExecuteScalar();
            SpecializationtxtLable.Text = Convert.ToString(result);


            //pass
            a = "select pass from Login_inst where Instrucor_ID=" + IDtxtLable.Text;
            com = new SqlCommand(a, ssd);
            result = com.ExecuteScalar();
            PasswordtxtLable.Text = Convert.ToString(result);


            ssd.Close();

            cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spGetImageByTd", con);
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

    }

    protected void ChangePasswordButton_Click(object sender, EventArgs e)
    {
       
       
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


                SqlCommand cmd = new SqlCommand("addImage", con);
              

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

                SqlParameter paramNewId = new SqlParameter()
                {
                    ParameterName = "@NewId",
                    Value = -1,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(paramNewId);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Visible = true;
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Upload Successful";
             
                    cmd.Parameters["@NewId"].Value.ToString();
            }
            Response.Redirect("MyProfile_Inst.aspx");
        }
        else
        {
            lblMessage.Visible = true;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "Only images (.jpg, .png, .gif and .bmp) can be uploaded";
    
        }
    }







}






