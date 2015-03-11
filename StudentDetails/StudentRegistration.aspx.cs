using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;

namespace StudentDetails
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                using (SqlConnection con = new SqlConnection(ConString))
                {
                    SqlCommand cmd = new SqlCommand("spStudentRegistration", con);
                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.Add("@EmailID",SqlDbType.VarChar).Value= EmailID.Text;
                    cmd.Parameters.Add("@FirstName",SqlDbType.VarChar).Value= FirstName.Text;
                    cmd.Parameters.Add("@LastName",SqlDbType.VarChar).Value= LastName.Text;
                    cmd.Parameters.Add("@Password",SqlDbType.NVarChar).Value= Password.Text;
                    cmd.Parameters.Add("@ConfirmPassword",SqlDbType.NVarChar).Value= ConfirmPassword.Text;
                    cmd.Parameters.Add("@PasswordHint",SqlDbType.VarChar).Value= PasswordHint.Text;
                    if (validateInput())
                    {
                        if (ValidatePassword())
                        {
                            if (CheckEmailExistance(con,EmailID.Text))
                            {
                                con.Open();
                                cmd.ExecuteNonQuery();
                                StatusLabel.Text = "Your Registraion is succeessfully completed";
                                Session["LoggedUserName"] = FirstName.Text + " " + LastName.Text;
                                Session["EmailID"] = EmailID.Text;
                                Response.Redirect("Detailes.aspx");
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                StatusLabel.Text = "Your Registraion is not succeessfully completed";
            }
        }

        protected void AlreadyExist_Click(Object sender, EventArgs e)
        {
            Response.Redirect("StudentLogin.aspx");
        }
        private bool validateInput()
        {
            if (string.IsNullOrEmpty(EmailID.Text))
            {
                StatusLabel.Text = "Email id can not be empty";
                return false;
            }
            else if (string.IsNullOrEmpty(FirstName.Text))
            {
                StatusLabel.Text = "First Name can not be empty";
                return false;  
            }
            else if (string.IsNullOrEmpty(LastName.Text))
            {
                StatusLabel.Text = "Last Name can not be empty";
                return false;  
            }
            else if (string.IsNullOrEmpty(Password.Text))
            {
                StatusLabel.Text = "Password can not be empty";
                return false;
            }
            else if (string.IsNullOrEmpty(ConfirmPassword.Text))
            {
                StatusLabel.Text = "Confirm Password can not be empty";
                return false;
            }
            return true;
        }

        private bool ValidatePassword()
        {
            if (Password.Text == ConfirmPassword.Text)
            {
                return true;
            }
            StatusLabel.Text = "Password is not matching";
            return false;
        }

        private bool CheckEmailExistance(SqlConnection con, string EmailId)
        {
            try
            {
                using (
                    SqlCommand cmd =
                        new SqlCommand("select Count(EmailID) from StudentRegister where EmailId='" + EmailId + "';",con))
                {
                    con.Open();
                    int TotalEmail = (int) cmd.ExecuteScalar();
                    if (TotalEmail > 0)
                    {
                        StatusLabel.Text =
                            "With this email ID registration is already has been done.<br/>For login please click on Already Exist button.";
                        return false;
                    }
                    con.Close();
                    return true;
                }
            }
            catch (System.Exception ex)
            {
                StatusLabel.Text = "Error occur during Email validation.";
                return false;
            }
        }
    }
}