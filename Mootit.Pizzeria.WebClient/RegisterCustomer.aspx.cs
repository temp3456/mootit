using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mootit.Users.Service.Accounts;

namespace Mootit.Pizzeria.WebClient
{
    public partial class RegisterCustomer : System.Web.UI.Page
    {
        internal const string USER_RESPONSES_ERROR_REGISTER = "O cliente não foi registrado!";
        internal const string USER_RESPONSES_INVALID_NUMBER = "O número de telefone é inválido";
        internal const string USER_RESPONSES_PHONE_EXISTS = "Esse telefone já está cadastrado!";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session[Login.SESSION_KEY_PHONE] != null)
                    this.TextBox_Phone.Text = Session[Login.SESSION_KEY_PHONE].ToString();
            }
            else
                Register_Customer();

        }

        protected void Register_Customer()
        {
            Customer customer = null;

            try
            {
                this.Label_Response.Text = String.Empty;

                if (ValidateIfValidNumber(this.TextBox_Phone.Text))
                    if (!ValidateIfNumberExists(this.TextBox_Phone.Text))
                    {
                        AccountsClient client = new AccountsClient();
                        customer = client.InsertCustomer(new Customer()
                        {
                            Address = this.TextBox_Address.Text,
                            Fullname = this.TextBox_FullName.Text,
                            PhoneNumer = int.Parse(this.TextBox_Phone.Text),
                            User = new User()
                            {
                                Username = this.TextBox_UserName.Text
                            }
                        });

                        if (customer != null)
                        {
                            Session[Login.SESSION_KEY_PHONE] = customer.PhoneNumer.ToString();
                            Response.Redirect("~/Main.aspx", true);
                        }
                        else
                            throw new Exception(USER_RESPONSES_ERROR_REGISTER);
                    }
                    else
                        throw new Exception(USER_RESPONSES_PHONE_EXISTS);
                else
                    throw new Exception(USER_RESPONSES_INVALID_NUMBER);
            }
            catch (Exception ex)
            {
                this.Label_Response.Text = ex.Message;
            }
            finally
            {
                customer = null;
            }
        }

        internal static bool ValidateIfValidNumber(string phoneNumber)
        {
            int valid = -1;

            return int.TryParse(phoneNumber, out valid);
        }

        internal static bool ValidateIfNumberExists(string phoneNumber)
        {
            AccountsClient client = new AccountsClient();

            Customer customer = client.GetCustomerByPhone(int.Parse(phoneNumber));

            return customer != null;
        }
    }
}