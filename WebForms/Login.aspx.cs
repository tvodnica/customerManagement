using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies[Constants.loggedIn] != null && Request.Cookies[Constants.loggedIn].Value == Constants.yes)
            {
                Response.Redirect(Constants.DataPage);
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if (Repo.Login(tb_username.Text, tb_password.Text))
            {
                HttpCookie httpCookie = new HttpCookie(Constants.loggedIn);
                httpCookie.Value = Constants.yes;
                Response.Cookies.Add(httpCookie);
                Response.Redirect(Constants.DataPage);
            }
            else
            {
                message.Style.Value = "color: red;";
                message.InnerText = "Pogrešno korisničko ime ili lozinka";
            }
        }
    }
}