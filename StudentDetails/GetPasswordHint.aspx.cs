using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace StudentDetails
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        private string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string query = "select * from StudentRegister where EmailID='" + EmailID.Text + "';";
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    if (Validate(con, EmailID.Text))
                    {
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            if (!string.IsNullOrEmpty(dr["PasswordHint"].ToString()))
                            {
                                StatausofPassword.Text = "Your password hint is = <b><i>" + dr["PasswordHint"].ToString() +
                                                         "</i></b>";
                            }
                            else
                            {
                                StatausofPassword.Text = "Your password hint is not available. <b><i> Please contact to admin.</i></b>";  
                            }
                        }
                        con.Close();
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
        }

        protected void Login_Click(Object sender, EventArgs e)
        {
            Response.Redirect("StudentLogin.aspx");
        }
        private bool Validate(SqlConnection con, string EmailID)
        {
            string query = "select count(EmailID) from StudentRegister where EmailID='" + EmailID + "';";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    int NoOfEmailID = (int)cmd.ExecuteScalar();
                    if (NoOfEmailID != 1)
                    {
                        if (NoOfEmailID == 0)
                        {
                            con.Close();
                            StatausofPassword.Text = "please register your emailid first";
                            return false;
                        }
                        else
                        {
                            con.Close();
                            StatausofPassword.Text = "please contact to administrator.";
                            return false;
                        }
                    }
                    con.Close();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                StatausofPassword.Text = "Some Error occur during Email validation.";
                con.Close();
                return false;
            }
        }
    }
}