using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Student_Details : System.Web.UI.Page
{
    string conStr = @"Data Source=DESKTOP-NK8PQBE; Database=P2SQL;Integrated Security=True";

    int StudentID, total, abc, div;
    string crsid, a;
    string ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        StudentID = Convert.ToInt32((string)Session["Student_ID"]);






        if (!IsPostBack)
        {
            //StudentID = (string)Session["Student_ID"];

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


        /***************************/
        GridView2.Visible = false;
        // ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
        // a = "SELECT [Course_ID],[div], Course_name  FROM [STU_CORS]  where [stu_ID]=" + StudentID;
        //using (SqlConnection connection = new SqlConnection(ConnectionString))
        //{
        //    connection.Open();
        //    SqlCommand command = new SqlCommand(a, connection);

        //    SqlDataReader reader = command.ExecuteReader();
        //    if (reader.HasRows)
        //    {
        //        GridView1.DataSource = reader;
        //        GridView1.DataBind();



        //    }
        //    reader.Close();
        //    connection.Close();
        //}

    }







    protected void show()
    {


        //  ConnectionString = "Data Source=DESKTOP-NK8PQBE; Initial Catalog=P2SQL;Integrated Security=True";
        // Label1.Text = stunam;
        string ba = "select Course_ID from[STU_CORS] where[Course_name] = @ss";

        using (SqlConnection connection = new SqlConnection(conStr))
        {
            connection.Open();
            SqlCommand command = new SqlCommand(ba, connection);

            // command.Parameters.AddWithValue("@value1", Convert.ToInt32(crsdiv));
            command.Parameters.AddWithValue("@ss", DropDownList1.SelectedItem.Text);

            SqlDataReader reader2 = command.ExecuteReader();
            if (reader2.Read())
            {
                crsid = reader2["Course_ID"].ToString();
                //  Label1.Text = crsid;

            }
            reader2.Close();

            /*Only execused*/

            string s = "select Count(Student_ID) From Attendance_Absence where Student_ID = @ID and Status='Execused' and Course_ID=@v2";
            command = new SqlCommand(s, connection);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(StudentID));
            //  command.Parameters.AddWithValue("@v1", Convert.ToInt32(crsdiv));
            command.Parameters.AddWithValue("@v2", crsid);
            object ex = command.ExecuteScalar();

            /*only abcen*/

            s = "select Count(Student_ID) From Attendance_Absence where Student_ID = @ID and Status='Abcens' and Course_ID=@v2";
            command = new SqlCommand(s, connection);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(StudentID));
            //  command.Parameters.AddWithValue("@v1", Convert.ToInt32(crsdiv));
            command.Parameters.AddWithValue("@v2", crsid);
            var count = command.ExecuteScalar();

            /*Only blocked*/

            s = "select Count(Student_ID) From Attendance_Absence where Student_ID = @ID and Status='Blocked' and Course_ID=@v2";
            command = new SqlCommand(s, connection);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(StudentID));
            //  command.Parameters.AddWithValue("@v1", Convert.ToInt32(crsdiv));
            command.Parameters.AddWithValue("@v2", crsid);
            var block = command.ExecuteScalar();



            /*All abc attnd*/

            s = "select Count(Student_ID) From Attendance_Absence where Student_ID = @ID  and Course_ID=@v2";
            command = new SqlCommand(s, connection);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(StudentID));
            command.Parameters.AddWithValue("@v2", crsid);
            var count2 = command.ExecuteScalar();
            int abc = Convert.ToInt32(count);
            int total = Convert.ToInt32(count2);


            Label2.Text = "Total number of student absences = " + count.ToString();
            Label4.Text = "Total times of blocking this student=" + Convert.ToInt32(block);
            Label5.Text = "Total number of student execuses=" + Convert.ToInt32(ex);


           // Label1.Text = "Total number of student absences = " + count.ToString() + "\t" + "Total Number of excused absences=" + Convert.ToInt32(ex) + "\n" + "Total times of blocking this user=" + Convert.ToInt32(block);

            string attendanceQuery = "SELECT [Status], [dat] FROM [Attendance_Absence] WHERE Course_ID=@value2 AND Student_ID=@value3 AND Status IN ('Abcens', 'Execused', 'Blocked')";

            using (SqlCommand command4 = new SqlCommand(attendanceQuery, connection))
            {
                command4.Parameters.AddWithValue("@value2", crsid);
                command4.Parameters.AddWithValue("@value3", Convert.ToInt32(StudentID));

                using (SqlDataReader reader = command4.ExecuteReader())
                {
                    if (reader.HasRows)
                    {

                        if ((abc + Convert.ToInt32(block) + (Convert.ToInt32(ex)) / 2) >= 14)
                        {
                            //  GridView2.Visible = false;
                            Label2.Text = "Sorry to tell you that, but you were fired from this subject";
                            GridView2.Visible = true;
                            GridView2.DataSource = reader;
                            GridView2.DataBind();
                        }
                        else
                        {
                            double res = ((abc + Convert.ToDouble(block)) / (double)total) * 100.0;
                            Label3.Text = "Student Absence rate = " + res.ToString("0.00") + "%";
                            GridView2.Visible = true;
                            GridView2.DataSource = reader;
                            GridView2.DataBind();
                        }
                    }


                    else
                    {
                        GridView2.Visible = false;
                        Label3.Text = "Student Absence rate = 0.00%";
                        Label1.Text = "There is no any abcense for you";
                    }


                   
                    reader.Close();

                }




            }
        } 
    

    }

        //        protected void show()
        //{
        //    string ba = "SELECT Course_ID FROM [STU_CORS] WHERE [Course_name] = @ss";

        //    using (SqlConnection connection = new SqlConnection(conStr))
        //    {
        //        connection.Open();

        //        // Retrieve the Course_ID based on the selected course name
        //        using (SqlCommand command = new SqlCommand(ba, connection))
        //        {
        //            command.Parameters.AddWithValue("@ss", DropDownList1.SelectedItem.Text);
        //            crsid = command.ExecuteScalar().ToString();
        //        }

        //        if (!string.IsNullOrEmpty(crsid))
        //        {
        //            // Retrieve the count of excused absences
        //            string excusedQuery = "SELECT COUNT(Student_ID) FROM Attendance_Absence WHERE Student_ID = @ID AND Status='Execused' AND Course_ID=@v2";
        //            using (SqlCommand command = new SqlCommand(excusedQuery, connection))
        //            {
        //                command.Parameters.AddWithValue("@ID", Convert.ToInt32(StudentID));
        //                command.Parameters.AddWithValue("@v2", crsid);
        //                object ex = command.ExecuteScalar();

        //                // Retrieve the count of blocked instances
        //                string blockedQuery = "SELECT COUNT(Student_ID) FROM Attendance_Absence WHERE Student_ID = @ID AND Status='Blocked' AND Course_ID=@v2";
        //                using (SqlCommand command2 = new SqlCommand(blockedQuery, connection))
        //                {
        //                    command2.Parameters.AddWithValue("@ID", Convert.ToInt32(StudentID));
        //                    command2.Parameters.AddWithValue("@v2", crsid);
        //                    var block = command2.ExecuteScalar();

        //                    // Retrieve the count of all absences
        //                    string allAbsencesQuery = "SELECT COUNT(Student_ID) FROM Attendance_Absence WHERE Student_ID = @ID AND Course_ID=@v2";
        //                    using (SqlCommand command3 = new SqlCommand(allAbsencesQuery, connection))
        //                    {
        //                        command3.Parameters.AddWithValue("@ID", Convert.ToInt32(StudentID));
        //                        command3.Parameters.AddWithValue("@v2", crsid);
        //                        var count2 = command3.ExecuteScalar();
        //                        int total = Convert.ToInt32(count2);

        //                        // Retrieve the attendance data (abcens, execused, blocked)
        //                        string attendanceQuery = "SELECT [Status], [dat] FROM [Attendance_Absence] WHERE Course_ID=@value2 AND Student_ID=@value3 AND Status IN ('Abcens', 'Execused', 'Blocked')";
        //                        using (SqlCommand command4 = new SqlCommand(attendanceQuery, connection))
        //                        {
        //                            command4.Parameters.AddWithValue("@value2", crsid);
        //                            command4.Parameters.AddWithValue("@value3", Convert.ToInt32(StudentID));

        //                            using (SqlDataReader reader = command4.ExecuteReader())
        //                            {
        //                                if (reader.HasRows)
        //                                {
        //                                    //int abc = 0;
        //                                    //while (reader.Read())
        //                                    //{
        //                                    //    string status = reader["Status"].ToString();
        //                                    //    if (status == "Abcens")
        //                                    //        abc++;
        //                                    //}

        //                                    double res = ((abc + Convert.ToDouble(block)) / (double)total) * 100.0;

        //                                    //if (res >= 14)
        //                                    //{
        //                                    //    Label2.Text = "Sorry to tell you that, but you were fired from this subject";
        //                                    //    GridView2.Visible = true;
        //                                    //    GridView2.DataSource = reader;
        //                                    //    GridView2.DataBind();
        //                                    //}

        //                                    {
        //                                        Label3.Text = "Student Absence rate = " + res.ToString("0.00") + "%" + "\n" + "Total number of student excused absences=" + Convert.ToInt32(ex);
        //                                        GridView2.Visible = true;
        //                                        GridView2.DataSource = reader;
        //                                        GridView2.DataBind();
        //                                    }
        //                                }
        //                                //else
        //                                //{
        //                                //    GridView2.Visible = false;
        //                                //    Label3.Text = "Student Absence rate = 0.00%";
        //                                //    Label1.Text = "There is no any absence for you";
        //                                //}
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}



        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            show();
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    } 