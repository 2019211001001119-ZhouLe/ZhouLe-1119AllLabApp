using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            FrmCustomerPreview objPreview = new FrmCustomerPreview();
            objPreview.SetValue(txtName.Text, txtCountry.Text, Gender, Hobby, Status);
            objPreview.Show();
            
        }
    }
}
