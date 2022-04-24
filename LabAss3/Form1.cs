using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabAss3
{
    public partial class frame1 : Form
    {
        public frame1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Gender, Hobby, Status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Female";
            if (chkReading.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMale.Checked) Status = "Married";
            else Status = "Unmarried";

            try
            {
                CustomerValidation objVal = new CustomerValidation();
                objVal.CheckCustomerName(txtName.Text);

                FrmCustomerPreview objPreview = new FrmCustomerPreview();
                objPreview.SetValue(txtName.Text, txtCountry.Text, Gender, Hobby, Status);
                objPreview.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void frame1_Load(object sender, EventArgs e)
        {
            loadCustomer();
        }

        private void loadCustomer()
        {
            string strConn = "Dsn=lab3;uid=root";
            OdbcConnection objConn = new OdbcConnection(strConn);
            objConn.Open();

            string strCommand = "Select * from Customer";
            OdbcCommand objCommand = new OdbcCommand(strCommand, objConn);

            DataSet objDataSet = new DataSet();
            OdbcDataAdapter objAdapter = new OdbcDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            dtgCustomer.DataSource = objDataSet.Tables[0];

            objConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Gender, Hobby, Status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Female";
            if (chkReading.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMale.Checked) Status = "1";
            else Status = "0";

            string strConn = "Dsn=lab3-32";
            OdbcConnection objConn = new OdbcConnection(strConn);
            objConn.Open();
            string strCommand = "insert into Customer(CustomerName, Country, Gender, Hobby, Married) values('"
                + txtName.Text + "','"
                + txtCountry.Text + "','"
                + Gender + "','"
                + Hobby + "',"
                + Status + ")";
            OdbcCommand objCommand = new OdbcCommand(strCommand, objConn);
            objCommand.ExecuteNonQuery();

            objConn.Close();
            loadCustomer();
        }

        private void dtgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clearForm();
            string id = dtgCustomer.Rows[e.RowIndex].Cells[0].Value.ToString();
            displayCustomer(id);
        }

        private void displayCustomer(string ID)
        {
            string strConn = "Dsn=lab3;uid=root";
            OdbcConnection objConn = new OdbcConnection(strConn);
            objConn.Open();

            string strCommand = "Select * from Customer where id =" + ID;
            OdbcCommand objCommand = new OdbcCommand(strCommand, objConn);

            DataSet objDataSet = new DataSet();
            OdbcDataAdapter objAdapter = new OdbcDataAdapter(objCommand);
            objAdapter.Fill(objDataSet);
            objConn.Close();
            lblID.Text = ID;
            txtName.Text = objDataSet.Tables[0].Rows[0][1].ToString().Trim();
            txtCountry.Text = objDataSet.Tables[0].Rows[0][2].ToString().Trim();
            string Gender = objDataSet.Tables[0].Rows[0][3].ToString().Trim();
            if (Gender.Equals("Male")) radioMale.Checked = true;
            else radioFemale.Checked = true;
            string Hobby = objDataSet.Tables[0].Rows[0][4].ToString().Trim();
            if (Hobby.Equals("Reading")) chkReading.Checked = true;
            else chkPainting.Checked = true;
            string Married = objDataSet.Tables[0].Rows[0][5].ToString().Trim();
            if (Married.Equals("True")) radioMerried.Checked = true;
            else radioUnmerried.Checked = true;
        }

        private void clearForm()
        {
            txtName.Text = "";
            txtCountry.Text = "";
            radioMale.Checked = false;
            radioFemale.Checked = false;
            chkPainting.Checked = false;
            chkReading.Checked = false;
            radioMerried.Checked = false;
            radioUnmerried.Checked = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String Gender, Hobby, Status = "";
            if (radioMale.Checked) Gender = "Male";
            else Gender = "Female";
            if (chkReading.Checked) Hobby = "Reading";
            else Hobby = "Painting";
            if (radioMale.Checked) Status = "1";
            else Status = "0";

            string strConn = "Dsn=lab3-32";
            OdbcConnection objConn = new OdbcConnection(strConn);
            objConn.Open();

            string strCommad = "UPDATE Customer SET CustomerName =@CustomerName, Country=@Country, " +
                "Gender=@Gender,Hobby=@Hobby,Married= @Married WHERE id=@id";
            OdbcCommand objCommand = new OdbcCommand(strCommad, objConn);
            objCommand.Parameters.AddWithValue("@CustomerName", txtName.Text.Trim());
            objCommand.Parameters.AddWithValue("@Country", txtCountry.Text.Trim());
            objCommand.Parameters.AddWithValue("@Gender", Gender);
            objCommand.Parameters.AddWithValue("@Hobby", Hobby);
            objCommand.Parameters.AddWithValue("@Married", Status);
            objCommand.Parameters.AddWithValue("@id", lblID.Text.Trim());
            objCommand.ExecuteNonQuery();
            objConn.Close();
            clearForm();
            loadCustomer();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string strConn = "Dsn=lab3-32";
            OdbcConnection objConn = new OdbcConnection(strConn);
            objConn.Open();

            string strCommad = "delete from customer where id='"+lblID.Text+"'";
            OdbcCommand objCommand = new OdbcCommand(strCommad, objConn);
            objCommand.ExecuteNonQuery();

            objConn.Close();
            loadCustomer();
        }
    }
}
