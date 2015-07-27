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
    public partial class supplierAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //get the product Supplier if editing
                if (!String.IsNullOrEmpty(Request.QueryString["SUPPLIER_ID"]))
                {
                    GetSupplier();
                }
            }
        }

        protected void GetSupplier()
        {
            //populate the existing product supplier for editing
            using (InoviceConnection db = new InoviceConnection())
            {
                Int32 SUPPLIER_ID = Convert.ToInt32(Request.QueryString["SUPPLIER_ID"]);

                supplier_information objC = (from s in db.supplier_information
                                             where s.SUPPLIER_ID == SUPPLIER_ID
                                             select s).FirstOrDefault();

                //populate the form
                txtName.Text = objC.SUPPLIER_NAME;
                txtAddress.Text = objC.ADDRESS;
                txtCity.Text = objC.CITY;
                txtState.Text = objC.STATE;
                txtPostalCode.Text = objC.POSTAL_CODE;

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //do insert or update
            using (InoviceConnection db = new InoviceConnection())
            {
                supplier_information objC = new supplier_information();

                if (!String.IsNullOrEmpty(Request.QueryString["SUPPLIER_ID"]))
                {
                    Int32 SUPPLIER_ID = Convert.ToInt32(Request.QueryString["SUPPLIER_ID"]);
                    objC = (from c in db.supplier_information
                            where c.SUPPLIER_ID == SUPPLIER_ID
                            select c).FirstOrDefault();
                }

                //populate the supplier from the input form
                objC.SUPPLIER_NAME= txtName.Text;
                objC.ADDRESS = txtAddress.Text;
                objC.CITY = txtCity.Text;
                objC.STATE = txtState.Text;
                objC.POSTAL_CODE = txtPostalCode.Text;

                if (String.IsNullOrEmpty(Request.QueryString["SUPPLIER_ID"]))
                {
                    //add
                    db.supplier_information.Add(objC);
                }

                //save and redirect
                db.SaveChanges();
                Response.Redirect("SupplierList.aspx");
            }
        }
    }
}