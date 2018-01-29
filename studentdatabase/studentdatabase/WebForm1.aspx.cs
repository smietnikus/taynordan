using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Odbc;


namespace studentdatabase
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string _ConnectionString = "data source=localhost;database=Student1;integrated security=SSPI";
        //  private SqlDataReader_DataReader;


        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection Conn = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from Student ", Conn);
            Conn.Open();


            //GridView1.DataSource = _DataReader;
            //_DataReader = cmd.ExecuteReader();

            DataSet Ds = new DataSet();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(Ds);
            GridView1.DataSource = Ds;
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            InsertUpdateRecord(Firstname.Text, Lastname.Text, Homenumber.Text, Mobile.Text, Email.Text);
            Response.Redirect(Request.Url.ToString());
        }

        private void InsertUpdateRecord(string firstName, string lastName, string telephone, string mobile, string email)
        {
            SqlConnection Conn = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("InsertUpdate", Conn); ;
            cmd.CommandType = CommandType.StoredProcedure;




            /* if (Sid.Text == "")
             {
                 cmd = new SqlCommand(, Conn);

             }
             else
             {
                 cmd = new SqlCommand("Update_Student", Conn);
                 cmd.Parameters.AddWithValue("@Studentid", Sid.Text);
             }*/

            cmd.Parameters.AddWithValue("@Studentid", Sid.Text);
            cmd.Parameters.AddWithValue("@Firstname", Firstname.Text);
            cmd.Parameters.AddWithValue("@Lastname", Lastname.Text);
            cmd.Parameters.AddWithValue("@HomeNumber", Homenumber.Text);
            cmd.Parameters.AddWithValue("@Mobile", Mobile.Text);
            cmd.Parameters.AddWithValue("@Email", Email.Text);
            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();

        }

        /*private void InsertSturedRecord(string firstName, string lastName, string telephone, string mobile, string email)
       {
           SqlConnection Conn = new SqlConnection(_ConnectionString);
             string cmdText = "insert into Student" +
                             "(" +
                                 "Firstname," +
                                 "Lastname," +
                                 "Homenumber," +
                                 "Mobile," +
                                 "Email" +
                             ")" +
                             "values" +
                             "(" +
                                 "'" + firstName + "'," +
                                 "'" + lastName + "'," +
                                 "'" + telephone + "'," +
                                 "'" + mobile + "'," +
                                 "'" + email + "')";


           SqlCommand cmd = new SqlCommand("Insert_Student", Conn);
           cmd.CommandType = CommandType.StoredProcedure;

           cmd.Parameters.AddWithValue("@Firstname", Firstname.Text);
           cmd.Parameters.AddWithValue("@Lastname", Lastname.Text);
           cmd.Parameters.AddWithValue("@HomeNumber", Homenumber.Text);
           cmd.Parameters.AddWithValue("@Mobile", Mobile.Text);
           cmd.Parameters.AddWithValue("@Email", Email.Text);
           Conn.Open();
           cmd.ExecuteNonQuery();
           Conn.Close();
       }      */


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from Student", Conn);
            Conn.Open();
            Sid.Text = GridView1.SelectedRow.Cells[1].Text;
            Firstname.Text = GridView1.SelectedRow.Cells[2].Text;
            Lastname.Text = GridView1.SelectedRow.Cells[3].Text;
            Homenumber.Text = GridView1.SelectedRow.Cells[4].Text;
            Mobile.Text = GridView1.SelectedRow.Cells[5].Text;
            Email.Text = GridView1.SelectedRow.Cells[6].Text;

        }

        private void UpdateRecord(string firstName, string lastName, string telephone, string mobile, string email)
        {
            SqlConnection Conn = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("Update_Student", Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Studentid", Sid.Text);

            cmd.Parameters.AddWithValue("@Firstname", Firstname.Text);
            cmd.Parameters.AddWithValue("@Lastname", Lastname.Text);
            cmd.Parameters.AddWithValue("@HomeNumber", Homenumber.Text);
            cmd.Parameters.AddWithValue("@Mobile", Mobile.Text);
            cmd.Parameters.AddWithValue("@Email", Email.Text);
            Conn.Open();
            cmd.ExecuteNonQuery();
            Conn.Close();

        }


        protected void Button2_Click(object sender, EventArgs e)

        {


            UpdateRecord(Firstname.Text, Lastname.Text, Homenumber.Text, Mobile.Text, Email.Text);
            Response.Redirect(Request.Url.ToString());

            /*  SqlCommand cmd = new SqlCommand("update Student Set Firstname=@Firstname,Lastname=@Lastname,Homenumber=@Homenumber,Mobile=@Mobile,Email=@Email Where Studentid=@Sid", Conn);
              cmd.Parameters.AddWithValue("@Sid", Sid.Text);
              cmd.Parameters.AddWithValue("@Firstname", Firstname.Text);
              cmd.Parameters.AddWithValue("@Lastname", Lastname.Text);
              cmd.Parameters.AddWithValue("@HomeNumber", Homenumber.Text);
              cmd.Parameters.AddWithValue("@Mobile", Mobile.Text);
              cmd.Parameters.AddWithValue("@Email", Email.Text);
              Conn.Open();
              cmd.ExecuteNonQuery();
              Response.Redirect(Request.Url.ToString());
              Conn.Close();
          
            
            SqlCommand cmd = new SqlCommand("update Student Set Sid=@Sid ,Firstname='" + Firstname.Text + "',Lastname='" + Lastname.Text + "',Homenumber= '" + Homenumber.Text + "',Mobile='" + Mobile.Text + "',Email='" + Email.Text + "'Where Sid='"+Sid.Text+"'", Conn);
            SqlCommand cmd = new SqlCommand("UPDATE Student set Firstname ='" + Firstname.Text + "' Where Id ='" + Sid + "' ,  Conn");
            cmd.CommandType = CommandType.Text;
            Conn.Open();*/
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlConnection Conn = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("DELETE from Student Where Studentid ='" + Sid.Text + "'", Conn);
            Conn.Open();
            cmd.ExecuteNonQuery();
            Response.Redirect(Request.Url.ToString());
            Conn.Close();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        for (int colIndex = 0; colIndex < e.Row.Cells.Count; colIndex++)
        //        {
        //            if (colIndex != 0)
        //            {
        //                TextBox txtName = new TextBox();
        //                txtName.Width = (colIndex == 6) ? 250 : 100;
        //                txtName.ID = "txtboxname" + colIndex;

        //                e.Row.Cells[colIndex].Controls.Add(txtName);

        //                txtName.Text = e.Row.Cells[colIndex].Text;

        //            }
        //        }
        //    }
        //}

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow) 
            //{
            //    for (int colIndex = 0; colIndex < e.Row.Cells.Count; colIndex++)
            //    {

            //            CheckBox chkName = new CheckBox();
            //            chkName.Width = 50;
            //            chkName.ID = "chkboxname" + colIndex;


            //              if (e.Row.RowIndex %2 == 0 && colIndex %2 == 0)
            //            {
            //                e.Row.Cells[colIndex].Controls.Add(chkName);

            //            }
            //         if (e.Row.RowIndex % 2 != 0 && colIndex % 2 != 0)
            //        {
            //            e.Row.Cells[colIndex].Controls.Add(chkName);

            //        }


            //        chkName.Text = e.Row.Cells[colIndex].Text;


            //    }
            //}
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

            string Query = "SELECT * FROM Student ORDER BY " + e.SortExpression;
            int A = (string.IsNullOrEmpty(txtSortHidden.Text)) ? 0 : int.Parse(txtSortHidden.Text);
            A++;
            txtSortHidden.Text = A.ToString();

            if (A % 2 == 0)
            {
                Query  +=  " ASC ";
            }
            else
            {
                Query +=  " DESC ";
            }

            SqlConnection Conn = new SqlConnection(_ConnectionString);

            SqlCommand cmd = new SqlCommand(Query, Conn);


            Conn.Open();

            //_DataReader = cmd.ExecuteReader();
            //GridView1.DataSource = _DataReader;
            DataSet Ds = new DataSet();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(Ds);
            GridView1.DataSource = Ds;

            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SqlConnection Conn = new SqlConnection(_ConnectionString);
            SqlCommand cmd = new SqlCommand("select * from Student ", Conn);
            DataSet Ds = new DataSet();
            SqlDataAdapter Da = new SqlDataAdapter(cmd);
            Da.Fill(Ds);
            GridView1.PageIndex = e.NewPageIndex;

        }
    }
}
