using System;
using System.Drawing;
using ZXing;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI;
using QRCoder;
using System.IO;

public partial class QR_code : System.Web.UI.Page
{
    string InstructorID;
    string crname, crsid;
    string conStr = @"Data Source=DESKTOP-NK8PQBE; Database=P2SQL;Integrated Security=True";
    string cs, a;
    protected void Page_Load(object sender, EventArgs e)
    {
        //  Timer2.Enabled = false;
        InstructorID = (string)Session["InstructorID"];

       // Label2.Text = InstructorID;
        cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        Timer2.Enabled = true;
        if (!IsPostBack)
        {
            //string script = "document.getElementById('" + Image1.ClientID + "').src = '~/QQ/" + InstructorID.ToString() + ".jpg?" + DateTime.Now.Ticks + "';";
            //ScriptManager.RegisterStartupScript(this, GetType(), "UpdateImageScript", script, true);


            //   Timer2.Enabled = false;

            Timer2.Enabled = true;
            // Timer2.Enabled = true;



            GenerateButton.Enabled = false;

            InstructorID = (string)Session["InstructorID"];

            a = "SELECT [Course_name],id  FROM [Course]  where [Instructor_ID]=" + InstructorID;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(a, connection);



                DropDownList1.DataSource = command.ExecuteReader();
                DropDownList1.DataTextField = "Course_name";
                DropDownList1.DataValueField = "id";
                DropDownList1.SelectedIndex = -1;
                DropDownList1.DataBind();


                connection.Close();
                //    Image1.ImageUrl = "~/QQ/" + InstructorID.ToString() + ".jpg";



            }
        }
          //  Timer2.Enabled = false;




            /*****************************************/


} 







    protected void di()
    {
        using (SqlConnection connection = new SqlConnection(cs))
        {
            connection.Open();


            a = "SELECT div,id FROM [Course]  where [Instructor_ID]=@v1 and [Course_name]=@v2";
            SqlCommand command = new SqlCommand(a, connection);

            command.Parameters.AddWithValue("@v1", InstructorID);

            command.Parameters.AddWithValue("@v2", DropDownList1.SelectedItem.Text);
            DropDownList2.DataSource = command.ExecuteReader();
            DropDownList2.DataTextField = "div";
            DropDownList2.DataValueField = "id";
            DropDownList2.DataBind();
            connection.Close();
        }


    }
    void Generate(string s, int d)
    {

        //  Label1.Text = (DateTime.MinValue).ToString("00:s");

        SqlConnection ssd = new SqlConnection();
        SqlCommand com;
        ssd.ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
        ssd.Open();

        string ba = "select ID from[Course] where[Course_name] = @ss and div=@nn";
        using (SqlConnection connection = new SqlConnection(conStr))
        {
            connection.Open();
            SqlCommand command2 = new SqlCommand(ba, connection);
            command2.Parameters.AddWithValue("@ss", s);
            command2.Parameters.AddWithValue("@nn", d);

            SqlDataReader reader = command2.ExecuteReader();

            if (reader.Read())
            {
                crsid = (reader["ID"]).ToString();
                //Label4.Text = crsid;
                reader.Close();


                string a1 = "INSERT INTO Attendance_Absence (Course_ID, Cours_div, Student_ID, Status, dat) SELECT @v3, @v4, STU_CORS.stu_ID, @v1, @v2 FROM STU_CORS WHERE Course_ID = @v3 AND div = @v4; ";

                /*INSERT INTO Attendance_Absence (Course_ID,Cours_div, Student_ID,Status, dat)
VALUES ( @v3, @v4, 'Abcens', (SELECT stu_ID FROM  STU_CORS WHERE WHERE Course_ID = @v3 AND div = @v4 ),@v2);
*/
                SqlCommand com1 = new SqlCommand(a1, ssd);
                com1.Parameters.AddWithValue("@v3", crsid);
                com1.Parameters.AddWithValue("@v4", d);
                com1.Parameters.AddWithValue("@v1", "Abcens");
                com1.Parameters.Add("@v2", SqlDbType.Date).Value = DateTime.Now.ToString("yyy-MM-dd");
                com1.ExecuteScalar();

                //Random rnd = new Random();
                //string DataTextBox = rnd.Next(1, 1000000).ToString();
                //// string qr = DataTextBox;
                //BarcodeWriter qrcode = new BarcodeWriter();
                //qrcode.Format = BarcodeFormat.QR_CODE;
                //qrcode.Write(DataTextBox).Save(@"C:/Users/danah/OneDrive/Desktop/WebSiteTICKME/QQ/" + InstructorID.ToString() + ".jpg");
                //Image1.ImageUrl = "~/QQ/" + InstructorID.ToString() + ".jpg";

                //string m = "select Count(ID) From QRCode  WHERE ID = " + InstructorID;
                //com = new SqlCommand(m, ssd);
                //object ex = com.ExecuteScalar();
                //if (Convert.ToInt32(ex) == 0)
                //{
                //    m = "INSERT INTO QRCode(QR, ID) VALUES(@v1, @v2);";
                //    com = new SqlCommand(m, connection);
                //    com.Parameters.AddWithValue("@v1", DataTextBox);
                //    com.Parameters.AddWithValue("@v2", Convert.ToInt32(InstructorID));
                //    com.ExecuteNonQuery();
                //}
                //else
                //{
                //    string a = "UPDATE QRCode SET QR = " + DataTextBox + " WHERE ID = " + InstructorID;
                //    com = new SqlCommand(a, connection);
                //    com.ExecuteNonQuery();
                //}
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshScript", "window.location.reload();", true);

            }
            else
            { }

            connection.Close();

        }







        ssd.Close();

    }











    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {



    }




    protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        di();
    }

    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

        GenerateButton.Enabled = true;

    }

    //protected void Timer1_Tick1(object sender, EventArgs e)
    //{

    //    //  Label1.Text = DateTime.Now.ToString();
    //    //Label1.Text = (Convert.ToInt32(Label1.Text) - 1).ToString();
    //    //if (string.Equals(Label1.Text, "0"))
    //    //{
    //    //    Timer1.Enabled = false;
    //    //    Random rnd = new Random();
    //    //    string DataTextBox = rnd.Next(1, 10000).ToString() + InstructorID.ToString();
    //    //    string a = "UPDATE QRCode SET QR =@qr  WHERE ID = " + InstructorID;

    //    //    //    Timer1.Enabled = false;
    //    //    using (SqlConnection connection = new SqlConnection(conStr))
    //    //    {

    //    //        using (SqlCommand com = new SqlCommand(a, connection))
    //    //        {


    //    //            connection.Open();
    //    //            com.Parameters.AddWithValue("@qr", DataTextBox);


    //    //            com.ExecuteNonQuery();

    //    //            // string qr = DataTextBox;

    //    //  }
    //    //        update(DataTextBox);


    //    //    }





    //    //}


    //    // Timer1.Enabled = true;
    //    //  Label1.Text = 5.ToString();

    //    //int countdownValue = Convert.ToInt32(Label1.Text) - 1;
    //    //if (countdownValue >= 0)
    //    //{
    //    //    Label1.Text = countdownValue.ToString();
    //    //}

    //    //else if (countdownValue == 0)
    //    //{
    //    //    Timer1.Enabled = false;
    //    //    Random rnd = new Random();
    //    //    string dataTextBox = rnd.Next(1, 10000).ToString() + InstructorID.ToString();
    //    //    string updateQuery = "UPDATE QRCode SET QR = @qr WHERE ID = " + InstructorID;

    //    //    using (SqlConnection connection = new SqlConnection(conStr))
    //    //    {
    //    //        using (SqlCommand command = new SqlCommand(updateQuery, connection))
    //    //        {
    //    //            connection.Open();
    //    //            command.Parameters.AddWithValue("@qr", dataTextBox);
    //    //            command.ExecuteNonQuery();
    //    //        }

    //    //        // Generate and update the QR code image
    //    //        update(dataTextBox);
    //    //        Label1.Text = 5.ToString();
    //    //        Timer1.Enabled = true;
    //    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshScript", "window.location.reload();", true);

    //    //    }
    //    //}



    //}
    void update(string d)
    {
        BarcodeWriter qrcode = new BarcodeWriter();
        qrcode.Format = BarcodeFormat.QR_CODE;
        qrcode.Write(d).Save(@"C:/Users/danah/OneDrive/Desktop/WebSiteTICKME/QQ/" + InstructorID.ToString() + ".jpg");
        Image1.ImageUrl = "~/QQ/" + InstructorID.ToString() + ".jpg";
        // Response.Redirect("QR_code.aspx");


    }
    string dataTextBox;
    protected void GenerateButton_Click2(object sender, EventArgs e)
    {
        Generate(DropDownList1.SelectedItem.Text,Convert.ToInt32( DropDownList2.SelectedItem.Text));
        //Generate(DropDownList1.SelectedItem.Text, Convert.ToInt32(DropDownList2.SelectedItem.Text));
        // Label1.Text = 2.ToString();
        Random rn = new Random();
        dataTextBox = rn.Next(1, 1000000).ToString();      // Label1.Text = 5.ToString();

        //// Step 1: Generate the QR Code Image
        byte[] qrCodeImageData = GenerateQRCodeImage(dataTextBox);

        //// Step 2: Save the QR Code Image to Database
        SaveQRCodeImageToDatabase(qrCodeImageData,Convert.ToInt32( dataTextBox));


        int qrCodeID =Convert.ToInt32( InstructorID); ; // Replace with the actual QR code ID you want to retrieve

        // Fetch the QR code image data from the database
        qrCodeImageData = FetchQRCodeImageData(qrCodeID);

        // If the image data is retrieved successfully
        if (qrCodeImageData != null)
        {
            // Convert the image data to a Bitmap object
            Bitmap qrCodeImage = ConvertBytesToImage(qrCodeImageData);

            // Display the image in an Image control or save it to a file, etc.
            Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(qrCodeImageData);
        }
        else
        {
            // Handle the case when the image data is not found or any other error
            // Display a default image or show an error message, etc.
            Image1.ImageUrl = "~/QQ/default.jpg"; // Replace with the path to your default image
        }
        Label1.Text = 5.ToString();
       Timer2.Enabled = true;


    }
    private Bitmap ConvertBytesToImage(byte[] imageData)
    {
        using (MemoryStream stream = new MemoryStream(imageData))
        {
            return new Bitmap(stream);
        }
    }
    private byte[] GenerateQRCodeImage(string data)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);
        QRCode qrCode = new QRCode(qrCodeData);
        Bitmap qrCodeImage = qrCode.GetGraphic(10); // Adjust the size as needed

        using (MemoryStream stream = new MemoryStream())
        {
            qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);

            return stream.ToArray();
        }

    }

    private void SaveQRCodeImageToDatabase(byte[] imageData, int dataTextBox)
    {
        object ex;
        string insertQuery;
        string connectionString = @"Data Source=DESKTOP-NK8PQBE; Database=P2SQL;Integrated Security=True";

        string m = "select Count(ID) From QRCode  WHERE ID = " + InstructorID;
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(m, connection))
            {
                connection.Open();
                ex = command.ExecuteScalar();
                connection.Close();

            }
        }
                //com = new SqlCommand(m, ssd);
       
        if (Convert.ToInt32(ex) == 0)
        {
            m = "INSERT INTO QRCode(QR,qrdata, ID) VALUES(@v1,@v3, @v2);";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(m, connection))
                {
                    command.Parameters.AddWithValue("@v1", dataTextBox);
                    command.Parameters.AddWithValue("@v3", imageData);
                    command.Parameters.AddWithValue("@v2", Convert.ToInt32(InstructorID));
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

           
        }
        else
        {
            insertQuery = "UPDATE QRCode SET qrdata=@qr,QR=@v2 where ID=@v";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@qr", imageData);

                command.Parameters.AddWithValue("@v2", dataTextBox);

                command.Parameters.AddWithValue("@v", Convert.ToInt32(InstructorID));

                connection.Open();
                command.ExecuteNonQuery();
                    connection.Close();
            }
           }
       }






        

    }

    protected void Timer2_Tick(object sender, EventArgs e)

    {
        //    Label1.Text = (Convert.ToInt32(Label1.Text) - 1).ToString();
        //    if (string.Equals(Label1.Text, "0"))
        //    {
        //        Random rnd = new Random();
        //        string DataTextBox = rnd.Next(1, 10000).ToString() + InstructorID.ToString();
        //        string a = "UPDATE QRCode SET QR =@qr  WHERE ID = " + InstructorID;

        //        //    Timer1.Enabled = false;
        //        using (SqlConnection connection = new SqlConnection(conStr))
        //        {

        //            using (SqlCommand com = new SqlCommand(a, connection))
        //            {


        //                connection.Open();
        //                com.Parameters.AddWithValue("@qr", DataTextBox);


        //                com.ExecuteNonQuery();

        //                // string qr = DataTextBox;
        //                BarcodeWriter qrcode = new BarcodeWriter();
        //                qrcode.Format = BarcodeFormat.QR_CODE;
        //                qrcode.Write(DataTextBox).Save(@"C:/Users/danah/OneDrive/Desktop/WebSiteTICKME/QQ/" + InstructorID.ToString() + ".jpg");

        //            }
        //        }
        //        Label1.Text = 5.ToString();
        //    }

        //    Timer2.Enabled = true;


        /*************************************************/
        Timer2.Enabled = false;

       
        if (string.Equals(Label1.Text, "0"))
        {
            Random rn = new Random();
            dataTextBox = rn.Next(1, 1000000).ToString();      // Label1.Text = 5.ToString();

            //// Step 1: Generate the QR Code Image
            byte[] qrCodeImageData = GenerateQRCodeImage(dataTextBox);

            //// Step 2: Save the QR Code Image to Database
            SaveQRCodeImageToDatabase(qrCodeImageData, Convert.ToInt32(dataTextBox));


            int qrCodeID = Convert.ToInt32(InstructorID); ; // Replace with the actual QR code ID you want to retrieve

            // Fetch the QR code image data from the database
            qrCodeImageData = FetchQRCodeImageData(qrCodeID);

            // If the image data is retrieved successfully
            if (qrCodeImageData != null)
            {
                // Convert the image data to a Bitmap object
                Bitmap qrCodeImage = ConvertBytesToImage(qrCodeImageData);

                // Display the image in an Image control or save it to a file, etc.
                Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(qrCodeImageData);
            }
            else
            {
                // Handle the case when the image data is not found or any other error
                // Display a default image or show an error message, etc.
                Image1.ImageUrl = "~/QQ/default.jpg"; // Replace with the path to your default image
            }

            Label1.Text = "5";

            //        // Reset the countdown value to 5 seconds
            //       
        }
        else
        {
         Label1.Text=(   Convert.ToInt32(Label1.Text) - 1).ToString();
          //  Label1.Text = countdownValue.ToString();
        }
        Timer2.Enabled = true;

    }
    private void GenerateQRCode(string data)
    {
        BarcodeWriter qrcode = new BarcodeWriter();
        qrcode.Format = BarcodeFormat.QR_CODE;
        Bitmap qrBitmap = qrcode.Write(data);

        string imagePath = @"C:/Users/danah/OneDrive/Desktop/WebSiteTICKME/QQ/" + InstructorID.ToString() + ".jpg";
        qrBitmap.Save(imagePath);
        // Use the ClientScriptManager to register the JavaScript for updating the image URL
        string instructorImage = "~/QQ/" + InstructorID.ToString() + ".jpg";
        string script = "document.getElementById('" + Image1.ClientID + "').src = '" + instructorImage + "';";

        ScriptManager.RegisterStartupScript(this, GetType(), "RefreshImageScript", script, true);

        // ScriptManager.RegisterStartupScript(this, this.GetType(), "RefreshScript", "window.location.reload();", true);
    }
    private void LoadQRCodeImage()
    {
        // Assuming you have an identifier to retrieve the specific QR code image
        int qrCodeID =Convert.ToInt32( InstructorID); // Replace with the actual QR code ID you want to retrieve

        // Fetch the QR code image data from the database
        byte[] qrCodeImageData = FetchQRCodeImageData(qrCodeID);

        // If the image data is retrieved successfully
        if (qrCodeImageData != null)
        {
            // Convert the image data to a Base64 string
            string base64String = Convert.ToBase64String(qrCodeImageData);

            // Set the Base64 string as the ImageUrl for the Image control
            Image2.ImageUrl = "data:image/png;base64," + base64String;
        }
        else
        {
            // Handle the case when the image data is not found or any other error
            // Display a default image or show an error message, etc.
            Image2.ImageUrl = "~/QQ/default.jpg"; // Replace with the path to your default image
        }
    }
    string connectionString = @"Data Source=DESKTOP-NK8PQBE; Database=P2SQL;Integrated Security=True";

    private byte[] FetchQRCodeImageData(int qrCodeID)
    {
        byte[] imageData = null;


        string selectQuery = "SELECT qrdata FROM QRCode WHERE ID = @QRCodeID";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(selectQuery, connection))
            {
                command.Parameters.AddWithValue("@QRCodeID", qrCodeID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Read the image data from the database
                    imageData = (byte[])reader["qrdata"];
                }

                reader.Close();
            }
        }

        return imageData;
    }





}


