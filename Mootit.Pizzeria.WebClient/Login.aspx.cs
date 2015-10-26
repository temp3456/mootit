using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mootit.Users.Service.Accounts;

namespace Mootit.Pizzeria.WebClient
{
    public partial class Login : System.Web.UI.Page
    {
        internal const string SESSION_KEY_PHONE = "Customer.Phone";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                this.ValidateEntrance();
        }

        private void ValidateEntrance()
        {
            try
            {
                this.Label_Response.Text = String.Empty;

                if (!String.IsNullOrEmpty(this.TextBox_Phone.Text) && RegisterCustomer.ValidateIfValidNumber(this.TextBox_Phone.Text))
                {
                    Session[SESSION_KEY_PHONE] = this.TextBox_Phone.Text;

                    if (RegisterCustomer.ValidateIfNumberExists(this.TextBox_Phone.Text))
                        Response.Redirect("~/Main.aspx", true);
                    else
                        Response.Redirect("~/RegisterCustomer.aspx", true);

                }
                else
                    throw new Exception(RegisterCustomer.USER_RESPONSES_INVALID_NUMBER);
            }
            catch (Exception ex)
            {
                Label_Response.Text = ex.Message;
            }
            finally
            {
                this.TextBox_Phone.Text = String.Empty;
            }
        }
    }
}