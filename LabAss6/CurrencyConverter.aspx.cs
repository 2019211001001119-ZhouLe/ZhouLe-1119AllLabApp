using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LabAss6
{
    public partial class CurrencyConverter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cny = TextBox1.Text;
            if (!cny.Equals(""))
            {
                string dollar = (int.Parse(TextBox1.Text) * 0.15).ToString();
                Label1.Text = dollar; 
            }
            else
            {
                Label1.Text = "Please enter a number";
            }
            Label1.Visible = true;
        
        }
    }
}