using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference the EF Model
using InoviceProject.Models;
using System.Linq.Dynamic;


namespace InoviceProject
{
    public partial class productAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCategory();
                GetSupplier();

                //add default options to the 2 dropdowns
                ListItem newItem = new ListItem("-Select-", "0");
                ddlSupplier.Items.Insert(0, newItem);
                ddlCategory.Items.Insert(0, newItem);

                //get the product if editing
                if (!String.IsNullOrEmpty(Request.QueryString["PRODUCT_ID"]))
                {
                    GetProduct();
                }
            }
        }

        protected void GetProduct()
        {
            //populate the existing product for editing
            using (InoviceConnection db = new InoviceConnection())
            {
                Int32 PRODUCT_ID = Convert.ToInt32(Request.QueryString["PRODUCT_ID"]);

                product_information objC = (from p in db.product_information
                                             where p.PRODUCT_ID == PRODUCT_ID
                                             select p).FirstOrDefault();

                //populate the form
                txtName.Text = objC.NAME;
                txtPrice.Text = objC.UNIT_PRICE.ToString();
                txtQuantity.Text = objC.QUANTITY.ToString();
                ddlCategory.SelectedValue = objC.CATEGORY_ID.ToString();
                ddlSupplier.SelectedValue = objC.SUPPLIER_ID.ToString();
            }
        }

        protected void GetSupplier()
        {
            using (InoviceConnection db = new InoviceConnection())
            {
                var supp = (from s in db.supplier_information
                            orderby s.SUPPLIER_NAME
                            select s);

                ddlSupplier.DataSource = supp.ToList();
                ddlSupplier.DataBind();                
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
                product_information objC = new product_information();

                if (!String.IsNullOrEmpty(Request.QueryString["PRODUCT_ID"]))
                {
                    Int32 PRODUCT_ID = Convert.ToInt32(Request.QueryString["PRODUCT_ID"]);
                    objC = (from p in db.product_information
                            where p.PRODUCT_ID == PRODUCT_ID
                            select p).FirstOrDefault();
                }

                //populate the product details from the input form
                objC.NAME = txtName.Text;
                objC.QUANTITY = Convert.ToInt32(txtQuantity.Text);
                objC.UNIT_PRICE = Convert.ToDecimal(txtPrice.Text);
                objC.SUPPLIER_ID = Convert.ToInt32(ddlSupplier.SelectedValue);
                objC.CATEGORY_ID = Convert.ToInt32(ddlCategory.SelectedValue);
                
                if (String.IsNullOrEmpty(Request.QueryString["PRODUCT_ID"]))
                {
                    //add
                    db.product_information.Add(objC);
                }

                //save and redirect
                db.SaveChanges();
                Response.Redirect("productList.aspx");
            }
        }
    }
}