using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Add security references
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

//reference the EF Model
using InoviceProject.Models;
using System.Linq.Dynamic;

namespace InoviceProject
{
    public partial class orderAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategory();               

                //add default options to the 2 dropdowns
                ListItem newItem = new ListItem("-Select-", "0");               
                ddlCategory.Items.Insert(0, newItem);

                //get the product if editing
                if (!String.IsNullOrEmpty(Request.QueryString["ORDER_ID"]))
                {
                    GetOrder();
                }
            }
        }

        protected void GetOrder()
        {
            //populate the existing product for editing
            using (InoviceConnection db = new InoviceConnection())
            {
                Int32 ORDER_ID = Convert.ToInt32(Request.QueryString["ORDER_ID"]);

                order_master objC = (from o in db.order_master
                                     where o.ORDER_ID == ORDER_ID
                                            select o).FirstOrDefault();

                //populate the form
                txtOrderDate.Text = String.Format("{0:MM-dd-yyyy}",objC.ORDER_DATE);
                txtQuantity.Text = objC.QUANTITY.ToString();                
                ddlCategory.SelectedValue = objC.CATEGORY_ID.ToString();
                GetProduct();
                ddlProduct.SelectedValue = objC.PRODUCT_ID.ToString();
                lblPrice.Text = String.Format("{0:n2}" ,objC.UNIT_PRICE);
                lblTotal.Text = String.Format("{0:n2}" ,(objC.UNIT_PRICE * objC.QUANTITY));
            }
        }

        protected void GetProduct()
        {
            using (InoviceConnection db = new InoviceConnection())
            {
                //Store the selected DepartmentID
                Int32 CATEGORY_ID = Convert.ToInt32(ddlCategory.SelectedValue);

                var ObjC = from c in db.product_information
                           where c.CATEGORY_ID == CATEGORY_ID
                           orderby c.NAME
                           select c;

                //bind to the course dropdown
                ddlProduct.DataSource = ObjC.ToList();
                ddlProduct.DataBind();

                //add default options to the 2 dropdowns
                ListItem newItem = new ListItem("-Select-", "0");
                ddlProduct.Items.Insert(0, newItem);                
            }
        }

        protected void GetCategory()
        {
            using (InoviceConnection db = new InoviceConnection())
            {
                var cate = (from c in db.category_information
                            orderby c.CATEGORY_NAME
                            select c);

                ddlCategory.DataSource = cate.ToList();
                ddlCategory.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //do insert or update
            using (InoviceConnection db = new InoviceConnection())
            {
                order_master objC = new order_master();

                if (!String.IsNullOrEmpty(Request.QueryString["ORDER_ID"]))
                {
                    Int32 ORDER_ID = Convert.ToInt32(Request.QueryString["ORDER_ID"]);
                    objC = (from p in db.order_master
                            where p.ORDER_ID == ORDER_ID
                            select p).FirstOrDefault();
                }

                //populate the product details from the input form
                objC.ORDER_DATE = Convert.ToDateTime(txtOrderDate.Text);
                objC.QUANTITY = Convert.ToInt32(txtQuantity.Text);
                objC.UNIT_PRICE = Convert.ToDecimal(lblPrice.Text);
                objC.PRODUCT_ID = Convert.ToInt32(ddlProduct.SelectedValue);
                objC.CATEGORY_ID = Convert.ToInt32(ddlCategory.SelectedValue);

                if (String.IsNullOrEmpty(Request.QueryString["ORDER_ID"]))
                {
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        objC.USER_ID = HttpContext.Current.User.Identity.GetUserId();
                    }

                    //add
                    db.order_master.Add(objC);
                }

                //save and redirect
                db.SaveChanges();
                Response.Redirect("orderList.aspx");
            }
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProduct();
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPrice();
        }
        protected void GetPrice()
        {
            using (InoviceConnection db = new InoviceConnection())
            {
                //Store the selected DepartmentID
                Int32 PRODUCT_ID = Convert.ToInt32(ddlProduct.SelectedValue);
                
                product_information objC = (from o in db.product_information
                                     where o.PRODUCT_ID == PRODUCT_ID
                                            select o).FirstOrDefault();


                lblPrice.Text = objC.UNIT_PRICE.ToString();
            }              
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            double total  =Convert.ToInt32(txtQuantity.Text) * Convert.ToDouble(lblPrice.Text);
            lblTotal.Text = String.Format("{0:n2}",total);
        }
    }
}