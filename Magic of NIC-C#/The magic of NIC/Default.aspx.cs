using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using The_magic_of_NIC.Models;

namespace The_magic_of_NIC
{
    public partial class _Default : Page
    {
        Generate _Generate;
        Details _Details;

        protected void Page_Load(object sender, EventArgs e)
        {
            _Generate = new Generate();
        }

        protected void Cmd_find_Click(object sender, EventArgs e)
        {
            string number = Txt_nicNumber.Text;

            _Details = _Generate.GenerateData(number);

            if (_Details == null)
            {
                Lbl_error.Text = "Invalide NIC number";
                Lbl_birthDay.Text = " ";
                Lbl_gender.Text = " ";
            }
            else
            {
                Lbl_error.Text = " ";
                Lbl_birthDay.Text = _Details.year + "/" + _Details.month + "/" + _Details.day;
                Lbl_gender.Text = _Details.gender;
            }
        }
    }
}