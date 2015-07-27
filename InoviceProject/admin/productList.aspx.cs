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
    public partial class productList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortColumn"] = "PRODUCT_ID";
                Session["SortDirection"] = "ASC";
                GetProduct();
            }
        }

        protected void GetProduct()
        {
            using (InoviceConnection db = new InoviceConnection())
            {

                //append the current direction to the Sort Column
                String sortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                //Get the Product Details
                var supp = (from p in db.product_information
                           select new { p.PRODUCT_ID, p.NAME, p.category_information.CATEGORY_NAME, p.supplier_information.SUPPLIER_NAME,p.QUANTITY, p.UNIT_PRICE});

                //bind the Product GridView
                grdProduct.DataSource = supp.AsQueryable().OrderBy(sortString).ToList();
                grdProduct.DataBind();
            }
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set new page size
            grdProduct.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetProduct();

        }

        protected void grdProduct_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //get selected Product ID
            Int32 PRODUCT_ID = Convert.ToInt32(grdProduct.DataKeys[e.RowIndex].Values["PRODUCT_ID"]);

            using (InoviceConnection db = new InoviceConnection())
            {
                //get selected Product
                product_information objC = (from p in db.product_information
                                             where p.PRODUCT_ID== PRODUCT_ID
                                             select p).FirstOrDefault();

                //delete
                db.product_information.Remove(objC);
                db.SaveChanges();

                //refresh grid
                GetProduct();
            }
        }

        protected void grdProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new page #
            grdProduct.PageIndex = e.NewPageIndex;
            GetProduct();
        }

        protected void grdProduct_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            //reload the grid
            GetProduct();

            //toggle the direction
            if (Session["SortDirection"].ToString() == "ASC")
            {
                Session["SortDirection"] = "DESC";
            }
            else
            {
                Session["SortDirection"] = "ASC";
            }
        }

        protected void grdProduct_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdProduct.Columns.Count - 1; i++)
                    {
                        if (grdProduct.Columns[i].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "DESC")
                            {
                                SortImage.ImageUrl = "/images/desc.jpg";
                                SortImage.AlternateText = "Sort Descending";
                            }
                            else
                            {
                                SortImage.ImageUrl = "/images/asc.jpg";
                                SortImage.AlternateText = "Sort Ascending";
                            }

                            e.Row.Cells[i].Controls.Add(SortImage);

                        }
                    }
                }
            }
        }
    }
}