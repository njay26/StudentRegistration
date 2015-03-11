using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace StudentDetails
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        private String CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmailID"] == null)
            {
                Response.Redirect("StudentLogin.aspx");
            }
            else
            {
                TextHeader.Text = Session["LoggedUserName"].ToString() + " you are Currently  logged in";
                if (!IsPostBack)
                {
                    LoadIntialInformation();
                }
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CS))
                {
                    if (Validate(con, Session["EmailID"].ToString()))
                    {
                        SqlCommand cmd = new SqlCommand("[spSetUserDetails]", con);
                        cmd.CommandType= CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Sex", SqlDbType.VarChar).Value = (!string.IsNullOrEmpty(SexDDM.Text)) ? SexDDM.Text : string.Empty;
                        cmd.Parameters.Add("@Nationality", SqlDbType.VarChar).Value = (!string.IsNullOrEmpty(NationalityText.Text))?NationalityText.Text:string.Empty;
                        cmd.Parameters.Add("@Telephone", SqlDbType.BigInt).Value = Convert.ToInt64((!string.IsNullOrEmpty(ContactText.Text))?ContactText.Text:null);
                        cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = (!string.IsNullOrEmpty(DOBText.Text) && DOBText.Text != "YYYY/MM/DD")?DOBText.Text:"";
                        cmd.Parameters.Add("@AreaCode", SqlDbType.VarChar).Value = (!string.IsNullOrEmpty(AreaCodeText.Text))?AreaCodeText.Text:string.Empty;
                        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = (!string.IsNullOrEmpty(AddressText.Text))?AddressText.Text:string.Empty;
                        cmd.Parameters.Add("@EmailID", SqlDbType.VarChar).Value = (!string.IsNullOrEmpty(Session["EmailID"].ToString()))?Session["EmailID"].ToString():string.Empty;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        validationMessage.Text = "All details has been saved successfully.";
                        con.Close();
                    }
                    else
                    {
                        validationMessage.Text = "Please login first";
                    }
                }
            }
            catch (System.Exception ex)
            {
                validationMessage.Text = "Error occur during saving.";   
            }
        }

        protected void Logout_Click(Object sender, EventArgs e)
        {
            if (Session["EmailID"] != null)
            {
                Session["EmailID"] = null;
                Response.Redirect("StudentLogin.aspx");
            }
        }
        protected void StudentList_Click(Object sender, EventArgs e)
        {
            Response.Redirect("StudentsTable.aspx");
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
        private void LoadIntialInformation()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string query = "select * from StudentRegister where EmailID='"+Session["EmailID"].ToString()+"'";
            var con = new SqlConnection(CS);
            try
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (!string.IsNullOrEmpty(dr["Sex"].ToString()))
                        {
                            var sex = dr["Sex"].ToString();
                            if (sex == "Male")
                            {
                                SexDDM.Items.Insert(0, new ListItem("Default text", "Default value"));
                            }
                            if (sex == "Female"){ SexDDM.SelectedIndex = 2;}
                        }
                        if (!string.IsNullOrEmpty(dr["Nationality"].ToString()))
                        {
                            NationalityText.Text = dr["Nationality"].ToString();
                        }
                        if (!string.IsNullOrEmpty(dr["Telephone"].ToString()))
                        {
                            ContactText.Text = dr["Telephone"].ToString();
                        }
                        if (!string.IsNullOrEmpty(dr["DateOfBirth"].ToString()))
                        {
                            DOBText.Text = dr["DateOfBirth"].ToString();
                        }
                        if (!string.IsNullOrEmpty(dr["AreaCode"].ToString()))
                        {
                            AreaCodeText.Text = dr["AreaCode"].ToString();
                        }
                        if (!string.IsNullOrEmpty(dr["Address"].ToString()))
                        {
                            AddressText.Text = dr["Address"].ToString();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                validationMessage.Text = "Some Error occur during initial data loading.";
                con.Close();  
            }
            }
    }
}