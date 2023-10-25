using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Sockets;
using QRCoder;
using System.Drawing;
using System.IO;

using System.Data.SqlClient;


public partial class Student_ttttttttttttt : System.Web.UI.Page
{
    int countdownValue = 5;
    string connectionString = @"Data Source=DESKTOP-NK8PQBE; Database=P2SQL;Integrated Security=True";
   // private const int initialCountdownValue = 5;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Timer2.Enabled = true;
        }
    }
    private byte[] FetchQRCodeImageData(int qrCodeID)
    {
        byte[] imageData = null;

      
        string selectQuery = "SELECT qr FROM qqrr WHERE id = @QRCodeID";

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
                    imageData = (byte[])reader["qr"];
                }

                reader.Close();
            }
        }

        return imageData;
    }



  




    private Bitmap ConvertBytesToImage(byte[] imageData)
    {
        using (MemoryStream stream = new MemoryStream(imageData))
        {
            return new Bitmap(stream);
        }
    }

   

    protected void Button1_Click(object sender, EventArgs e)
    {
        Timer2.Enabled = true;

        Random rn = new Random();
        string dataTextBox = rn.Next(1, 10000).ToString();      // Label1.Text = 5.ToString();
      // Replace with the data you want to encode in the QR code

        // Step 1: Generate the QR Code Image
        byte[] qrCodeImageData = GenerateQRCodeImage(dataTextBox);

        // Step 2: Save the QR Code Image to Database
        SaveQRCodeImageToDatabase(qrCodeImageData);


        int qrCodeID = 1; // Replace with the actual QR code ID you want to retrieve

        // Fetch the QR code image data from the database
         qrCodeImageData = FetchQRCodeImageData(qrCodeID);

        // If the image data is retrieved successfully
        if (qrCodeImageData != null)
        {
            // Convert the image data to a Bitmap object
            Bitmap qrCodeImage = ConvertBytesToImage(qrCodeImageData);

            // Display the image in an Image control or save it to a file, etc.
            Image2.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(qrCodeImageData);
        }
        else
        {
            // Handle the case when the image data is not found or any other error
            // Display a default image or show an error message, etc.
            Image2.ImageUrl = "~/QQ/default.jpg"; // Replace with the path to your default image
        }
        Timer2.Enabled = true;
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

    private void SaveQRCodeImageToDatabase(byte[] imageData)
    {
        string connectionString = @"Data Source=DESKTOP-NK8PQBE; Database=P2SQL;Integrated Security=True";
        string insertQuery = "UPDATE qqrr SET qr=@qr,id=@v where id=@v2";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@qr", imageData);
                command.Parameters.AddWithValue("@v", 1);
                command.Parameters.AddWithValue("@v2", 1);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
       
    }
    int initialCountdownValue = 5;
    protected void Timer2_Tick(object sender, EventArgs e)
    {
        Timer2.Enabled = false;
        // Label1.Text = countdownValue.ToString();

        initialCountdownValue = 0;

        if (initialCountdownValue == 0)
        {
            // Generate new QR code image data
            GenerateQRCodeImage("55555");
            string updateQuery = "UPDATE qqrr SET qr = @qr id=@id  WHERE id  =1 ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@qr", "5555");
                     command.Parameters.AddWithValue("@id", "5");
                    command.ExecuteNonQuery();

                }
            } // Replace 1 with the actual QR code ID

            // Load the updated QR code image
            LoadQRCodeImage();
            initialCountdownValue = 5;
            // Reset the countdown value to 5 seconds
            //  countdownValue = initialCountdownValue;
        }
      

        Timer2.Enabled = true; ;




    }
    private void LoadQRCodeImage()
    {
        // Assuming you have an identifier to retrieve the specific QR code image
        int qrCodeID = 1; // Replace with the actual QR code ID you want to retrieve

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

    public string GetImageURL()
    {
        // You may replace "photo.jpg" with the actual URL of your photo
        // Here, we add a query parameter "counter" with the current timestamp to force image refresh
        return "159874.jpg?counter=" + Guid.NewGuid().ToString();
    }

}