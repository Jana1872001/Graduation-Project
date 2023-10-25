using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class packages_InstructorCourses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string a;object result,result2;
        SqlConnection ssd = new SqlConnection();

        ssd.ConnectionString = "Data Source=DESKTOP-6PR70F3;Initial Catalog=P2SQL;Integrated Security=True";
        ssd.Open();
        SqlCommand com;
       // do
        {
            a = "select ID from Course where Instructor_ID =" + idLable.Text;
            string b= "select Course_name from Course where Instructor_ID = " + idLable.Text;
            com = new SqlCommand(a, ssd);
            result = com.ExecuteScalar();
            com = new SqlCommand(b, ssd);
            result2 = com.ExecuteScalar();
            ImageButton btn = new ImageButton();
            btn.Visible = true;
            Label ll = new Label();
            ll.Text = "1236";
            ll.ForeColor = System.Drawing.Color.Black;
            idLable.Text = result2.ToString() +" "+ result.ToString() ;

        }
      //  while (result != null);

    }
}