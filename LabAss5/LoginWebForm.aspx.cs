using System;
using System.Data;
using System.Data.Odbc;

namespace LabAss5
{
    public partial class LoginWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string strConn = "Dsn=lab5;uid=root";
            OdbcConnection objConn = new OdbcConnection(strConn);
            objConn.Open();
            string queryString = "Select username, password from logon where username='" + txtUsername.Text + "'";
            OdbcDataAdapter adapter = new OdbcDataAdapter();
            adapter.SelectCommand = new OdbcCommand(queryString, objConn);

            DataSet ds1 = new DataSet();
            adapter.Fill(ds1, "logon");
            if (ds1.Tables["logon"].Rows.Count == 0)
                lblCaption.Text = "Invalid username";
            else
            if (ds1.Tables["logon"].Rows[0][1].ToString().Trim() == txtPassword.Text.Trim())
            {
                lblCaption.Text = "Welcome, " + txtUsername.Text;

                Session["Uname"] = txtUsername.Text;
                Server.Transfer("WelCome.aspx");
            }
            else
                lblCaption.Text = "Invalid Password";
            objConn.Close();

        }
    }
}