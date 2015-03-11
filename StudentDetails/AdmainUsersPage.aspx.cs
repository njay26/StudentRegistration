using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.Services;

namespace StudentDetails
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmailID"] == null)
            {
                Response.Redirect("StudentLogin.aspx");
            }
            else
            {
                TextHeader.Text = Session["LoggedUserName"].ToString() + " you are currently  logged in";
            }
        }
        protected void Logout_OnClick(object Sender, EventArgs E)
        {
            if (Session["EmailID"] != null)
            {
                Session["EmailID"] = null;
                Response.Redirect("StudentLogin.aspx");
            }
        }

        [WebMethod]
        public static void GetAllStudentInformation()
        {
            const string query = "select EmailID,(FirstName+LastName)as Name,Sex,Telephone,DateOfBirth,([Address]+', '+AreaCode) as [Address],Status from StudentRegister";
            var prpareJSONObjectData = new StringBuilder();
            prpareJSONObjectData.Append("{");
            prpareJSONObjectData.Append("\"data\":[");
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (var con = new SqlConnection(CS))
            {
                using (var cmd = new SqlDataAdapter(query, con))
                {
                    var dataTable = new DataTable();
                    cmd.Fill(dataTable);
                    if (dataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            prpareJSONObjectData.Append("[");
                            prpareJSONObjectData.Append("\"" + dataTable.Rows[i][0] + "\",");
                            prpareJSONObjectData.Append("\"" + dataTable.Rows[i][1] + "\",");
                            prpareJSONObjectData.Append("\"" + dataTable.Rows[i][2] + "\",");
                            prpareJSONObjectData.Append("\"" + dataTable.Rows[i][3] + "\",");
                            prpareJSONObjectData.Append("\"" + dataTable.Rows[i][4] + "\",");
                            prpareJSONObjectData.Append("\"" + dataTable.Rows[i][5] + "\",");
                            prpareJSONObjectData.Append("\"" + dataTable.Rows[i][6] + "\"");
                            prpareJSONObjectData.Append("]");
                            if (dataTable.Rows.Count - 1 > i)
                            {
                                prpareJSONObjectData.Append(",");
                            }
                            else
                            {
                                prpareJSONObjectData.Append("]");
                                prpareJSONObjectData.Append("}");
                            }
                        }
                    }
                }
            }
            System.IO.File.WriteAllText(@"F:\C#\Visual Studio\WCF\StudentDetails\StudentDetails\Data\AdminUsersData.txt", prpareJSONObjectData.ToString());
        }

        [WebMethod]
        public static void RegistrationAccepted(string EmailID)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                string query = "update StudentRegister set Status='Accepted' where EmailID='" + EmailID + "'";
                SqlConnection con = new SqlConnection(CS);
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                   con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        [WebMethod]
        public static void RegistrationRejected(string EmailID)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            try
            {
                string query = "update StudentRegister set Status='Rejected' where EmailID='" + EmailID + "'";
                SqlConnection con = new SqlConnection(CS);
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}