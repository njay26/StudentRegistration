using System;
using System.Configuration;
using System.Data.SqlClient;

namespace StudentDetails
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextHeader.Text = "Student Details Login Page";
        }
        protected void GetpasswordHint_Click(object sender, EventArgs e)
        {
            Response.Redirect("GetPasswordHint.aspx");
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                //check Admin user if user is belongs to admin then navigate to Student list for admin page
                if (LoginInput.Text == "admin" && txtPassword.Text == "admin")
                {
                    Session["EmailID"] = "Admin";
                    Session["LoggedUserName"] = "Admin user";
                    Response.Redirect("AdmainUsersPage.aspx");
                }
                else
                {
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        if (Validate(con, LoginInput.Text))
                        {
                            if (Validate(con, LoginInput.Text, txtPassword.Text))
                            {


                                Session["EmailID"] = LoginInput.Text;
                                validationMessage.Text = "Successfully Log in.";
                                Response.Redirect("Detailes.aspx");
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                validationMessage.Text = "Some Problem occur during Login process";
            }
        }

        //check Email id
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
                            validationMessage.Text = "please register your emailid first";
                            return false;
                        }
                        else
                        {
                            con.Close();
                            validationMessage.Text = "please contact to administrator.";
                            return false;
                        }
                    }
                    con.Close();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                validationMessage.Text = "Some Error occur during Email validation.";
                con.Close();
                return false;
            }
        }

        private bool Validate(SqlConnection Con, string EmailID, string Password)
        {
            string query = "select * from StudentRegister where EmailID='" + EmailID + "';";
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, Con))
                {
                    Con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr["Password"].ToString() == Password)
                        {
                            Session["LoggedUserName"] = dr["FirstName"] + " " + dr["LastName"];
                            Con.Close();
                            return true;
                        }
                        else
                        {
                            Con.Close();
                            validationMessage.Text = "Password is not matching.";
                            return false;
                        }
                    }
                    Con.Close();
                    validationMessage.Text = "Please enter your password.";
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                Con.Close();
                validationMessage.Text = "Some error occur during Password validation.";
                return false;
            }
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentRegistration.aspx");
        }
    }
}