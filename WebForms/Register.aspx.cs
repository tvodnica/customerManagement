using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            bool userAlreadyExists;
            try
            {
                userAlreadyExists = Repo.Register(tb_username.Text, tb_password.Text);
            }
            catch (Exception)
            {
                message.Style.Value = "color:red";
                message.InnerText = "Greška - registracija nije provedena.";
                return;
            }

            if (userAlreadyExists)
            {
                message.Style.Value = "color:red";
                message.InnerText = "Greška - korisnik s odabranom E-mail adresom već postoji.";
                return;
            }

            message.Style.Value = "color:lime";
            message.InnerText = "Korisnički račun je uspešno kreiran. Sada se možete prijaviti";

            tb_username.Text = "";
            tb_password.Text = "";
            tb_password_again.Text = "";

        }
    }
}