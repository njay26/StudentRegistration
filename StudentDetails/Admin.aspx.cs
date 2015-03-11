using System;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace StudentDetails
{
    public partial class Admin1 : System.Web.UI.Page
    {
        #region Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DBTextBox.Text = string.Empty;
            }
        }
        /// <summary>
        /// In order to create DB for Student CreateDB_Click event handler has been used.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CreateDB_Click(object sender, EventArgs e)
        {
            ViewState["DBName"] = DBTextBox.Text;
            ViewState["ServerName"] = ServerName.Text;
            string cmd = "create database " + ViewState["DBName"].ToString();
            using (SqlConnection myConn = new SqlConnection("Data Source=.\\" + ViewState["ServerName"].ToString() + ";Initial Catalog=master;Integrated Security=True"))
            {
                SqlCommand myCommand = new SqlCommand(cmd, myConn);
                try
                {
                    if (CheckDataBaseExistence(myConn, DBTextBox.Text))
                    {
                        myConn.Open();
                        myCommand.ExecuteNonQuery();
                        dbStatus.Text = "DataBase has been created successfully.";
                    }
                    else
                    {
                        dbStatus.Text = "DataBase name already exist.";
                    }
                }
                catch (System.Exception ex)
                {
                    dbStatus.Text = "DataBase hasn't been created.";
                }
            }
        }
        /// <summary>
        /// In order to create table, CreateTable_Click click event hander has been used.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CreateTable_Click(object sender, EventArgs e)
        {
            using (SqlConnection myConn = new SqlConnection("Data Source=.\\" + ViewState["ServerName"].ToString() + ";Initial Catalog=" + ViewState["DBName"].ToString() + ";Integrated Security=True"))
            {
                SqlCommand myCommand = new SqlCommand(CreateTables(), myConn);
                try
                {
                    myConn.Open();
                    myCommand.ExecuteNonQuery();
                    TableStatus.Text = "Table has been created successfully.";
                }
                catch (System.Exception ex)
                {
                    TableStatus.Text = "Table hasn't been created.";
                }
            }
        }
        protected void CreateStoreProcedure_Click(object sender, EventArgs e)
        {
            try
            {
                using (
                    SqlConnection con =
                        new SqlConnection(("Data Source=.\\" + ViewState["ServerName"].ToString() + ";Initial Catalog=" + ViewState["DBName"].ToString() +
                                           ";Integrated Security=True")))
                {
                    SqlCommand cmdUserDetails = new SqlCommand(SetUserDetails(), con);
                    SqlCommand cmdStudentRegistration = new SqlCommand(StudentRegistration(), con);
                    SqlCommand cmdGetUserDetails = new SqlCommand(GetUserDetails(), con);
                    con.Open();
                    cmdUserDetails.ExecuteNonQuery();
                    cmdStudentRegistration.ExecuteNonQuery();
                    cmdGetUserDetails.ExecuteNonQuery();
                    LableCreateStoreProcedure.Text = "Store procedure has been created successfully <br/> 1. spGetUserDetails <br/> 2. spStudentRegistration <br/> 3. spGetusetDetails ";
                }
            }
            catch (System.Exception ex)
            {
                LableCreateStoreProcedure.Text = "Some error occur.";
            }
        }

        /// <summary>
        /// Configure the Web config connnection string to web config file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ConfigureWebConfig_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Server.MapPath("Web.config");
                string newConnectionString = @"Data Source=.\" + ViewState["ServerName"].ToString() + ";Initial Catalog=" +
                                             ViewState["DBName"].ToString() + ";Integrated Security=True";
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(path);
                XmlNodeList nodeList = xDoc.GetElementsByTagName("connectionStrings");
                XmlNodeList nodeAppSettings = nodeList[0].ChildNodes;
                XmlAttributeCollection xmlAttCollection = nodeAppSettings[0].Attributes;
                xmlAttCollection[0].InnerXml = "DBCS";
                xmlAttCollection[1].InnerXml = newConnectionString;
                xDoc.Save(path); // saves the web.config file
                WebConfigStatus.Text = "Connection string has configured successfully.";
            }
            catch (System.Exception ex)
            {
                WebConfigStatus.Text = ex.Message.ToString();
            }
        }
        /// <summary>
        /// In order to create table sql query CreateTable() method can be use
        /// </summary>
        /// <returns></returns>
        private string CreateTables()
        {
            StringBuilder query = new StringBuilder();
            query.Append("use " + ViewState["DBName"].ToString() + "\n");
            query.Append("create Table Studentregister(\n");
            query.Append("ID int primary key identity(1,1) not null,\n");
            query.Append("EmailID varchar(40) not null,\n");
            query.Append("FirstName char(20) not null,\n");
            query.Append("LastName varchar(20),\n");
            query.Append("[Password] varchar(20) not null,\n");
            query.Append("ConfirmPassword varchar(20) not null,\n");
            query.Append("PasswordHint varchar(100),\n");
            query.Append("Constraint CK_ValidatePassword check([Password]=ConfirmPassword),\n");
            query.Append("Sex char(25),\n");
            query.Append("Nationality char(40),\n");
            query.Append("Telephone BigInt,\n");
            query.Append("DateOfBirth Date NOT NULL DEFAULT GETDATE(),\n");
            query.Append("AreaCode varchar(30),\n");
            query.Append("Address nvarchar(130),\n");
            query.Append("Status varchar(30) default 'Under Processing',\n");
            query.Append(");");
            return query.ToString();
        }
        /// <summary>
        ///  In order to do registraion for Student StudentRegistration store procedure can be use.
        /// </summary>
        /// <returns></returns>
        private string StudentRegistration()
        {
            StringBuilder procQuery = new StringBuilder();
            procQuery.Append("create proc spStudentRegistration\n");
            procQuery.Append("@EmailID varchar(30),\n");
            procQuery.Append("@FirstName varchar(25),\n");
            procQuery.Append("@LastName varchar(20),\n");
            procQuery.Append("@Password nvarchar(30),\n");
            procQuery.Append("@ConfirmPassword nvarchar(30),\n");
            procQuery.Append("\n");
            procQuery.Append("@PasswordHint nvarchar(50)\n");
            procQuery.Append("as\n");
            procQuery.Append("begin\n");
            procQuery.Append("Insert into StudentRegister(EmailID,FirstName,LastName,[Password],ConfirmPassword,PasswordHint)\n");
            procQuery.Append("Values(@EmailID,@FirstName,@LastName,@Password,@ConfirmPassword,@PasswordHint);\n");
            procQuery.Append("end\n");
            return procQuery.ToString();
        }
        /// <summary>
        /// In order to set the Student details SetUserDetails store procedure can be use.
        /// </summary>
        /// <returns></returns>
        private string SetUserDetails()
        {
            StringBuilder setUserDetailsQuery = new StringBuilder();
            setUserDetailsQuery.Append("create procedure spSetUserDetails\n");
            setUserDetailsQuery.Append("@Sex varchar(20),\n");
            setUserDetailsQuery.Append("@Nationality Varchar(30),\n");
            setUserDetailsQuery.Append("@Telephone BigInt,\n");
            setUserDetailsQuery.Append("@DateOfBirth Date,\n");
            setUserDetailsQuery.Append("@AreaCode varchar(30),\n");
            setUserDetailsQuery.Append("@Address nvarchar(200),\n");
            setUserDetailsQuery.Append("@EmailID varchar(40)\n");
            setUserDetailsQuery.Append("As\n");
            setUserDetailsQuery.Append("Begin\n");
            setUserDetailsQuery.Append("Update StudentRegister\n");
            setUserDetailsQuery.Append("Set Sex=@Sex,Nationality=@Nationality,Telephone=@Telephone,DateOfBirth=@DateOfBirth,AreaCode=@AreaCode,[Address]=@Address\n");
            setUserDetailsQuery.Append("where EmailID =@EmailID;\n");
            setUserDetailsQuery.Append("End\n");
            return setUserDetailsQuery.ToString();
        }
        /// <summary>
        ///  In order to get the Student details GetUserDetails store procedure can be use.
        /// </summary>
        /// <returns></returns>
        private string GetUserDetails()
        {
            StringBuilder getUsersDetailsQuery = new StringBuilder();
            getUsersDetailsQuery.Append(" create proc spGetUsetDetails\n");
            getUsersDetailsQuery.Append("as\n");
            getUsersDetailsQuery.Append("begin\n");
            getUsersDetailsQuery.Append("select FirstName+LastName as Name,Sex,DateOfBirth,Nationality,Telephone,[Address],AreaCode from StudentRegister\n");
            getUsersDetailsQuery.Append("end\n");
            return getUsersDetailsQuery.ToString();
        }
        /// <summary>
        /// check Data base name exist or not
        /// </summary>
        /// <param name="con"></param>
        /// <param name="DBName"></param>
        /// <returns></returns>
        public bool CheckDataBaseExistence(SqlConnection con, string DBName)
        {
            bool IsDBExist;
            string QueryString = string.Format("SELECT COUNT(*) FROM sys.databases WHERE Name = '{0}'", DBName);
            con =
                new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=" + DBTextBox.Text +
                                  ";Integrated Security=True");
            try
            {
                using (SqlCommand cmd = new SqlCommand(QueryString, con))
                {
                    con.Open();
                    int DBCount = (int)cmd.ExecuteNonQuery();
                    if (DBCount > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception e)
            {
                return true;
            }
        }
        #endregion
    }
}