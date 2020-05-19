using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationSQLServer
{
    public partial class EditUserInformationById : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int selectedID = int.Parse(Request.QueryString["id"]);
                BusinessLayer.UserInformation selectedUserInformation = DBLayer.DBUtilities.SelectUserInformationById(selectedID);
                firstNameTextBox.Text = selectedUserInformation.FirstName;
                lastNameTextBox.Text = selectedUserInformation.LastName;
                addressTextBox.Text = selectedUserInformation.Address;
                cityTextBox.Text = selectedUserInformation.City;
                stateOrProvinceTextBox.Text = selectedUserInformation.Province;
                zipCodeTextBox.Text = selectedUserInformation.PostalCode;
                countryTextBox.Text = selectedUserInformation.Country;
            }
        }

        protected void updateInfoButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int selectedID = int.Parse(Request.QueryString["id"]);
                BusinessLayer.UserInformation newUserInfo = new BusinessLayer.UserInformation();     
                newUserInfo.FirstName = Server.HtmlEncode(firstNameTextBox.Text);
                newUserInfo.LastName = Server.HtmlEncode(lastNameTextBox.Text);
                newUserInfo.Address = Server.HtmlEncode(addressTextBox.Text);
                newUserInfo.City = Server.HtmlEncode(cityTextBox.Text);
                newUserInfo.Province = Server.HtmlEncode(stateOrProvinceTextBox.Text);
                newUserInfo.PostalCode = Server.HtmlEncode(zipCodeTextBox.Text);
                newUserInfo.Country = Server.HtmlEncode(countryTextBox.Text);

                // MessageBox popup to test entered information 
                //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + newUserInfo.FirstName + "');", true);

                if (DBLayer.DBUtilities.UpdateUserInformationById(selectedID, newUserInfo) == 1)
                {
                    this.lblResultMessage.Text = "The User Information was successfully updated in db table";
                    Response.Redirect("Registration.aspx");
                }
                else
                    this.lblResultMessage.Text = "There was an error on inserting the user information!!!!!!";
            }
        }
    }
}