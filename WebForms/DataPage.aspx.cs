using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms
{
    public partial class DataPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies[Constants.loggedIn] == null || Request.Cookies[Constants.loggedIn].Value != Constants.yes)
            {
                Response.Redirect(Constants.Login);
            }
            if (!IsPostBack)
            {
                gv_kupci.Visible = false;
                LoadDrzaveIntoDDL();
                LoadGradoviIntoDDL();
            }

        }
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Session["brojKupaca"] != null)
            {
                tb_number.Text = Session["brojKupaca"].ToString();
            }
            if (Session["ddl_drzava"] != null)
            {
                ddl_drzava.SelectedValue = Session["ddl_drzava"].ToString();
                LoadGradoviIntoDDL();
            }

        }

        protected void btn_showKupci_Click(object sender, EventArgs e)
        {
            int numberOfKupci;
            try
            {
                numberOfKupci = int.Parse(tb_number.Text);
            }
            catch (Exception)
            {
                numberOfKupci = 10;
            }
            gv_kupci.PageSize = numberOfKupci;
            gv_kupci.Visible = true;

        }
        protected void ddl_drzava_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ddl_drzava"] = ddl_drzava.SelectedValue;
            Session["brojKupaca"] = tb_number.Text;
            Response.Redirect(Request.Path);
        }

        private void LoadDrzaveIntoDDL()
        {
            ddl_drzava.DataSource = Repo.GetDrzave();
            ddl_drzava.DataTextField = "Naziv";
            ddl_drzava.DataValueField = "IDDrzava";
            ddl_drzava.DataBind();
        }
        private void LoadGradoviIntoDDL()
        {
            if (ddl_drzava.SelectedValue != "" && ddl_drzava.SelectedValue != "-1")
            {
                ddl_grad.DataSource = Repo.GetGradoviFromDrzava(int.Parse(ddl_drzava.SelectedValue));
                ddl_grad.DataTextField = "Naziv";
                ddl_grad.DataValueField = "IDGrad";
                ddl_grad.DataBind();
            }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Response.Cookies[Constants.loggedIn].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect(Constants.Login);
        }

        protected void gv_kupci_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedKupacID = (int)gv_kupci.SelectedDataKey.Value;
            Response.Redirect("http://localhost:61336/ShowKupacData/" + selectedKupacID);
        }
    }
}