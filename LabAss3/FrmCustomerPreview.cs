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
    public partial class FrmCustomerPreview : Form
    {
        public FrmCustomerPreview()
        {
            InitializeComponent();
        }
        public void SetValue(String Name, String Country, String Sex, String Hobby, String Statu)
        {
            label2.Text = Name;
            label4.Text = Country;
            label6.Text = Sex;
            label8.Text = Hobby;
            label10.Text = Statu;
        }
    }
}
