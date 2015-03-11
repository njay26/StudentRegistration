using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Configuration;
using System.Text;
using System.Web.Services;

namespace StudentDetails
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmailID"] == null)
            {
                Response.Redirect("StudentLogin.aspx");
            }
            else
            {
                TextHeader.Text = Session["LoggedUserName"].ToString() + " you are Currently  logged in";
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
        protected void GoBackPage_Onclick(Object sender, EventArgs e)
        {
            Response.Redirect("Detailes.aspx");
        }
        [WebMethod]
        public static void Data()
        {
            const string query = "select FirstName+LastName as Name,sex,Nationality,Telephone,([Address]+', '+AreaCode)as [Address],Status from StudentRegister";
            var prpareJSONObjectData= new StringBuilder(); 
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
                            prpareJSONObjectData.Append("\""+dataTable.Rows[i][0]+"\",");
                            prpareJSONObjectData.Append("\"" + dataTable.Rows[i][1] + "\",");
                            prpareJSONObjectData.Append("\"" + dataTable.Rows[i][2] + "\",");
                            prpareJSONObjectData.Append("\"" + dataTable.Rows[i][3] + "\",");
                            prpareJSONObjectData.Append("\"" + dataTable.Rows[i][4] + "\",");
                            prpareJSONObjectData.Append("\"" + dataTable.Rows[i][5] + "\"");
                                prpareJSONObjectData.Append("]");
                            if (dataTable.Rows.Count-1 > i)
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
            System.IO.File.WriteAllText(@"F:\C#\Visual Studio\WCF\StudentDetails\StudentDetails\Data\Data.txt", prpareJSONObjectData.ToString());
        }
        /// <summary>
        /// Get the status of the student. 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        [WebMethod]
        public static string GetStatus(int index)
        {
            string Status = "Not Seen by Admin";
            string query = "select * from StudentRegister where ID=" + (index + 1);
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (var con = new SqlConnection(CS))
            {
                using (var cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    var dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        string StatusValue = dr["status"].ToString();
                        if (!string.IsNullOrEmpty(StatusValue))
                        {
                            if (StatusValue == "Accepted") Status = StatusValue;
                            if (StatusValue == "NotAccepted") Status = "Not accepted";
                            else Status = "Under Processing";
                        }
                    }
                }
            }
            return Status;
        }
    }
}