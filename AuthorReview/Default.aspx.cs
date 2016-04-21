using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DataClass dc = new DataClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        LoadDropDownList();
    }

    protected void LoadDropDownList()
    {
        DataTable tbl = dc.GetAuthor();
        DropDownList1.DataSource = tbl;
        DropDownList1.DataTextField = "AuthorName";
        DropDownList1.DataValueField = "AuthorKey";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Choose an Author");
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }

    protected void FillGrid()
    {
        if (!DropDownList1.Equals("Choose an Author"))
        {
            int key = int.Parse(DropDownList1.SelectedValue.ToString());
            DataTable tbl = dc.GetBooks(key);
            GridView1.DataSource = tbl;
            GridView1.DataBind();

        }
    }
}