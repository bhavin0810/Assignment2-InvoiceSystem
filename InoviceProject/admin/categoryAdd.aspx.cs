using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Add reference to the EF Model
using InoviceProject.Models;
using System.Linq.Dynamic;


namespace InoviceProject
{
    public partial class categoryAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {             
                //get the product Category if editing
                if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
                {                  
                    GetCategory();
                }
            }
        }

        protected void GetCategory() 
        {
            //populate the existing product category for editing
            using (InoviceConnection db = new InoviceConnection())
            {
                Int32 ID = Convert.ToInt32(Request.QueryString["ID"]);

                category_information objC = (from c in db.category_information
                               where c.ID == ID
                               select c).FirstOrDefault();

                //populate the form
                txtName.Text = objC.CATEGORY_NAME;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //do insert or update
            using (InoviceConnection db = new InoviceConnection())
            {
                category_information objC = new category_information();

                if (!String.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    Int32 ID = Convert.ToInt32(Request.QueryString["ID"]);
                    objC = (from c in db.category_information
                            where c.ID == ID
                            select c).FirstOrDefault();
                }

                //populate the product category from the input form
                objC.CATEGORY_NAME = txtName.Text;
                
                if (String.IsNullOrEmpty(Request.QueryString["ID"]))
                {
                    //add product category
                    db.category_information.Add(objC);
                }

                //save and redirect
                db.SaveChanges();
                Response.Redirect("categoryList.aspx");
            }
        }               
    }
}