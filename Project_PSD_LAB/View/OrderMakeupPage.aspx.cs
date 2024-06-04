using Project_PSD_LAB.Controller;
using Project_PSD_LAB.Model;
using Project_PSD_LAB.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_PSD_LAB.View
{
    public partial class OrderMakeupPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<Makeup> makeup = MakeupController.getAllMakeup();
                MakeupListGV.DataSource = makeup;
                MakeupListGV.DataBind();

                User user = UserController.getUserBySessionCookie();
                if (user != null)
                {
                    List<object> allCart = CartController.showCart(user.UserID);
                    if (allCart.Count() == 0)
                    {
                        CartGV.Visible = false;
                        CartLbl.Text = "Cart is empty!";
                        CartLbl.Visible = true;
                        return;
                    }
                    else
                    {
                        CartGV.DataSource = allCart;
                        CartGV.DataBind();
                        CartLbl.Visible = false;
                    }
                }
            }
        }
        protected void OrderButton_Click(object sender, EventArgs e)
        {
            Button orderButton = (Button)sender;

            User user = UserController.getUserBySessionCookie();
            int userId = Convert.ToInt32(user.UserID);           
            int makeupId = Convert.ToInt32(orderButton.CommandArgument);
            //DebugLbl.Text = makeupId.ToString();
            TextBox quantityTextBox = (TextBox) orderButton.NamingContainer.FindControl("QuantityTextBox");
            int quantity;
            if (quantityTextBox.Text == "")
            {
                errorMsgLbl.Visible = true;
                errorMsgLbl.Text = "Quantity must be bigger than 0!";
            }
            else
            {
                quantity = Convert.ToInt32(quantityTextBox.Text);
                string validationGroup = orderButton.UniqueID;
                ClientScriptManager cs = Page.ClientScript;
                cs.RegisterForEventValidation(validationGroup, makeupId.ToString());

                Response<Makeup> response = MakeupController.validateOrder(quantity);
                if (response.IsSuccess)
                {
                    errorMsgLbl.Visible = false;
                    Response<Cart> responseCart = CartController.addToCart(userId, makeupId, quantity);                   
                }
                else
                {                   
                    errorMsgLbl.Visible = true;
                    errorMsgLbl.Text = response.Message.ToString();
                    return;
                }

                User cartOwner = UserController.getUserBySessionCookie();
                List<object> allCart = CartController.showCart(cartOwner.UserID);
                if(allCart.Count() != 0)
                {
                    CartGV.DataSource = allCart;
                    CartGV.DataBind();
                    CartGV.Visible = true;
                    CartLbl.Visible = false;
                }
                else
                {
                    CartGV.Visible = false;
                    CartLbl.Visible = true;
                    CartLbl.Text = "Cart is empty!";
                }
            }
            Response.Redirect("~/View/OrderMakeupPage.aspx");
        }
        protected void ClearCartButton_Click(object sender, EventArgs e)
        {
            CartGV.DataSource = null;
            CartGV.DataBind();
            CartGV.Visible = false;
            CartLbl.Visible = true;
            CartLbl.Text = "Cart is empty!";
            User cartOwner = UserController.getUserBySessionCookie();
            CartController.clearCart(cartOwner.UserID);
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            User cartOwner = UserController.getUserBySessionCookie();
            List<Cart> allCart = CartController.getAllCartOfAnUser(cartOwner.UserID);
            if(allCart.Count() != 0)
            {
                Response<TransactionHeader> response = TransactionHeaderController.addTransaction(cartOwner.UserID, DateTime.Now, "Unhandled", allCart);
                CartGV.DataSource = null;
                CartGV.DataBind();
                CartGV.Visible = false;
                CartLbl.Visible = true;
                CartLbl.Text = "Cart is empty!";
                CartController.clearCart(cartOwner.UserID);
                CheckoutLbl.Text = response.Message.ToString() + "!";
            }            
        }
    }
}