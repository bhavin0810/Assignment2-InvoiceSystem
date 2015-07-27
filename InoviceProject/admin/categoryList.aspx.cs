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
    public partial class categoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortColumn"] = "ID";
                Session["SortDirection"] = "ASC";
                GetCategories();
            }
        }

        protected void GetCategories()
        {
            using (InoviceConnection db = new InoviceConnection())
            {

                //append the current direction to the Sort Column
                String sortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                //Get the Product Category Details
                var category = from c in db.category_information
                                select new { c.ID, c.CATEGORY_NAME };

                //bind the Category GridView
                grdCategory.DataSource = category.AsQueryable().OrderBy(sortString).ToList();
                grdCategory.DataBind();
            }
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set new page size
            grdCategory.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetCategories();

        }

        protected void grdCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //get selected category ID
            Int32 ID = Convert.ToInt32(grdCategory.DataKeys[e.RowIndex].Values["ID"]);

            using (InoviceConnection db = new InoviceConnection())
            {
                //get selected Category
                category_information objC = (from c in db.category_information
                               where c.ID == ID
                               select c).FirstOrDefault();

                //delete
                db.category_information.Remove(objC);
                db.SaveChanges();

                //refresh grid
                GetCategories();
            }
        }

        protected void grdCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the new page #
            grdCategory.PageIndex = e.NewPageIndex;
            GetCategories();
        }

        protected void grdCategory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdCategory.Columns.Count - 1; i++)
                    {
                        if (grdCategory.Columns[i].SortExpression == Session["SortColumn"].ToString())
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

        protected void grdCategory_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the column to sort by
            Session["SortColumn"] = e.SortExpression;

            //reload the grid
            GetCategories();

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
    }
}