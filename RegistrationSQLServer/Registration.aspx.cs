using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RegistrationSQLServer
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EnterInfoButton_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                //send the user info to the database
                BusinessLayer.UserInformation userInfo = new BusinessLayer.UserInformation();

                userInfo.FirstName = Server.HtmlEncode(firstNameTextBox.Text);
                userInfo.LastName = Server.HtmlEncode(lastNameTextBox.Text);
                userInfo.Address = Server.HtmlEncode(addressTextBox.Text);
                userInfo.City = Server.HtmlEncode(cityTextBox.Text);
                userInfo.Province = Server.HtmlEncode(stateOrProvinceTextBox.Text);
                userInfo.PostalCode = Server.HtmlEncode(zipCodeTextBox.Text);
                userInfo.Country = Server.HtmlEncode(countryTextBox.Text);

                int getId = DBLayer.DBUtilities.InsertUserInformation(userInfo);
                if (getId > -1)
                {
                    //this.lblResultMessage.Text = "The User Information was successfully inserted into db table";

                    Response.Redirect("EditUserInformationById.aspx?id="+ getId);
                }
                else
                    this.lblResultMessage.Text = "There was an error on inserting the user information!!!!!!";
            }
        }
    }
}