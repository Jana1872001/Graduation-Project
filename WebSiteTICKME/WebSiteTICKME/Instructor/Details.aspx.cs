using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;
using System.Data;

public partial class Details : System.Web.UI.Page
{
    string crsdiv, crsid, studid, stunam, a;
    string ConnectionString;
    int total, abc;
    object count2, count, ex, block;


    protected void Page_Load(object sender, EventArgs e)
    {
        crsid = (string)Session["CourseID"];
        crsdiv = (string)Session["CourseDiv"];
        studid = (string)Session["Student_ID"];
        // stunam= (string)Session["Student_Name"];
        Label1.Text = "Student ID:" + " " + studid;
        ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";

        if (!IsPostBack)
        {
            FillData();

        }




    }

    private void FillData()
    {



        using (SqlConnection cn = new SqlConnection(ConnectionString))
        {
            cn.Open();
            string s = "select Count(Student_ID) From Attendance_Absence where Student_ID = @ID and Status='Abcens' and Cours_div=@v1 and Course_ID=@v2";
            SqlCommand command = new SqlCommand(s, cn);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(studid));
            command.Parameters.AddWithValue("@v1", Convert.ToInt32(crsdiv));
            command.Parameters.AddWithValue("@v2", crsid);
            count = command.ExecuteScalar();

            /*Only blocked*/

            s = "select Count(Student_ID) From Attendance_Absence where Student_ID = @ID and Status='Blocked' and Course_ID=@v2";
            command = new SqlCommand(s, cn);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(studid));
            //  command.Parameters.AddWithValue("@v1", Convert.ToInt32(crsdiv));
            command.Parameters.AddWithValue("@v2", crsid);
            block = command.ExecuteScalar();



            Label2.Text = "Total number of student absences = " + count.ToString();
            Label6.Text = "Total times of blocking this student=" + Convert.ToInt32(block);

            s = "select Count(Student_ID) From Attendance_Absence where Student_ID = @ID  and Cours_div=@v1 and Course_ID=@v2";
            command = new SqlCommand(s, cn);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(studid));
            command.Parameters.AddWithValue("@v1", Convert.ToInt32(crsdiv));
            command.Parameters.AddWithValue("@v2", crsid);
            count2 = command.ExecuteScalar();

            s = "select Count(Student_ID) From Attendance_Absence where Student_ID = @ID and Status='Execused' and Cours_div=@v1 and Course_ID=@v2";
            command = new SqlCommand(s, cn);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(studid));
            command.Parameters.AddWithValue("@v1", Convert.ToInt32(crsdiv));
            command.Parameters.AddWithValue("@v2", crsid);
            ex = command.ExecuteScalar();
            Label7.Text = "Total number of student execuses=" + Convert.ToInt32(ex);

            int abc = Convert.ToInt32(count);
        int total = Convert.ToInt32(count2);
        DataTable dt = new DataTable();

        string attendanceQuery = "SELECT [Status], [dat] ,id FROM [Attendance_Absence] WHERE Course_ID=@value2 AND Student_ID=@value3 AND Status IN ('Abcens', 'Execused', 'Blocked')";

            using (SqlCommand command4 = new SqlCommand(attendanceQuery, cn))
            {
                command4.Parameters.AddWithValue("@value2", crsid);
                command4.Parameters.AddWithValue("@value3", Convert.ToInt32(studid));

                using (SqlDataReader reader = command4.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        if ((abc + Convert.ToInt32(block) + (Convert.ToInt32(ex)) / 2) >= 14)
                        {
                            //  GridView1.Visible = false;
                            Label2.Text = "Student dismissed";
                            GridView1.Visible = true;
                            GridView1.DataSource = reader;
                            GridView1.DataBind();
                        }
                        else
                        {
                            double res = ((abc + Convert.ToDouble(block)) / (double)total) * 100.0;
                            Label3.Text = "Student Absence rate = " + res.ToString("0.00") + "%";
                            GridView1.Visible = true;
                            GridView1.DataSource = reader;
                            GridView1.DataBind();
                        }
                    }


                    else
                    {
                        GridView1.Visible = false;
                        Label3.Text = "Student Absence rate = 0.00%";
                        Label1.Text = "There is no any abcense for you";
                    }



                    reader.Close();

                }

            }
        }
    }
   




//protected void show()
//    {


//        //  ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
//        // Label1.Text = stunam;
//        string ba = "select Course_ID from[STU_CORS] where[Course_name] = @ss";

//        using (SqlConnection connection = new SqlConnection(conStr))
//        {
//            connection.Open();
//            SqlCommand command = new SqlCommand(ba, connection);

//            // command.Parameters.AddWithValue("@value1", Convert.ToInt32(crsdiv));
//            command.Parameters.AddWithValue("@ss", DropDownList1.SelectedItem.Text);

//            SqlDataReader reader2 = command.ExecuteReader();
//            if (reader2.Read())
//            {
//                crsid = reader2["Course_ID"].ToString();
//                //  Label1.Text = crsid;

//            }
//            reader2.Close();

//            /*Only execused*/

//            string s = "select Count(Student_ID) From Attendance_Absence where Student_ID = @ID and Status='Execused' and Course_ID=@v2";
//            command = new SqlCommand(s, connection);
//            command.Parameters.AddWithValue("@ID", Convert.ToInt32(StudentID));
//            //  command.Parameters.AddWithValue("@v1", Convert.ToInt32(crsdiv));
//            command.Parameters.AddWithValue("@v2", crsid);
//            object ex = command.ExecuteScalar();

//            /*only abcen*/

//            s = "select Count(Student_ID) From Attendance_Absence where Student_ID = @ID and Status='Abcens' and Course_ID=@v2";
//            command = new SqlCommand(s, connection);
//            command.Parameters.AddWithValue("@ID", Convert.ToInt32(StudentID));
//            //  command.Parameters.AddWithValue("@v1", Convert.ToInt32(crsdiv));
//            command.Parameters.AddWithValue("@v2", crsid);
//            var count = command.ExecuteScalar();

//            /*Only blocked*/

//            s = "select Count(Student_ID) From Attendance_Absence where Student_ID = @ID and Status='Blocked' and Course_ID=@v2";
//            command = new SqlCommand(s, connection);
//            command.Parameters.AddWithValue("@ID", Convert.ToInt32(StudentID));
//            //  command.Parameters.AddWithValue("@v1", Convert.ToInt32(crsdiv));
//            command.Parameters.AddWithValue("@v2", crsid);
//            var block = command.ExecuteScalar();



//            /*All abc attnd*/

//            s = "select Count(Student_ID) From Attendance_Absence where Student_ID = @ID  and Course_ID=@v2";
//            command = new SqlCommand(s, connection);
//            command.Parameters.AddWithValue("@ID", Convert.ToInt32(StudentID));
//            command.Parameters.AddWithValue("@v2", crsid);
//            var count2 = command.ExecuteScalar();
//            int abc = Convert.ToInt32(count);
//            int total = Convert.ToInt32(count2);



//            Label1.Text = "Total number of student absences = " + count.ToString() + "\t" + "Total Number of excused absences=" + Convert.ToInt32(ex) + "\n" + "Total times of blocking this user=" + Convert.ToInt32(block);

//            string attendanceQuery = "SELECT [Status], [dat] FROM [Attendance_Absence] WHERE Course_ID=@value2 AND Student_ID=@value3 AND Status IN ('Abcens', 'Execused', 'Blocked')";

//            using (SqlCommand command4 = new SqlCommand(attendanceQuery, connection))
//            {
//                command4.Parameters.AddWithValue("@value2", crsid);
//                command4.Parameters.AddWithValue("@value3", Convert.ToInt32(StudentID));

//                using (SqlDataReader reader = command4.ExecuteReader())
//                {
//                    if (reader.HasRows)
//                    {

//                        if ((abc + Convert.ToInt32(block) + (Convert.ToInt32(ex)) / 2) >= 14)
//                        {
//                            //  GridView1.Visible = false;
//                            Label2.Text = "Sorry to tell you that, but you were fired from this subject";
//                            GridView1.Visible = true;
//                            GridView1.DataSource = reader;
//                            GridView1.DataBind();
//                        }
//                        else
//                        {
//                            double res = ((abc + Convert.ToDouble(block)) / (double)total) * 100.0;
//                            Label3.Text = "Student Absence rate = " + res.ToString("0.00") + "%" + "\n" + "Total number of student execuses=" + Convert.ToInt32(ex);
//                            GridView1.Visible = true;
//                            GridView1.DataSource = reader;
//                            GridView1.DataBind();
//                        }
//                    }


//                    else
//                    {
//                        GridView1.Visible = false;
//                        Label3.Text = "Student Absence rate = 0.00%";
//                        Label1.Text = "There is no any abcense for you";
//                    }



//                    reader.Close();

//                }




//            }
//        }


//    }
   

    protected void DeleteExec(object sender, EventArgs e)
    {
       
       string conStr = @"Data Source=DESKTOP-NK8PQBE; Database=P2SQL;Integrated Security=True";

        LinkButton Ink = (LinkButton)sender;
        GridViewRow gr = (GridViewRow)Ink.NamingContainer;
        int id = int.Parse(GridView1.DataKeys[gr.RowIndex].Value.ToString());


       

        string a = " UPDATE Attendance_Absence SET Status= 'Attendance' WHERE  id = " + id;
        using (SqlConnection connection = new SqlConnection(conStr))
        {

            SqlCommand command = new SqlCommand(a, connection);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

          
        }
        FillData();

    }
    

    protected void DeleteButton_Click(object sender, EventArgs e)
    {
       
        
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}