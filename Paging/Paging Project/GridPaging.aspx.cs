using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Paging_Project_GridPaging : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["Ginie"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    protected void BindGrid()
    {
        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();
            string sql = "select UserID, AppType, AppNo from AllApps867";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Close();

            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);

            int pageSize = int.Parse(ddlPageSize.SelectedValue);
            GridUser.PageSize = pageSize;

            GridUser.DataSource = dt;
            GridUser.DataBind();
        }
    }

    // grid paging
    protected void GridUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //binding GridView to PageIndex object
        GridUser.PageIndex = e.NewPageIndex;
        BindGrid();
    }

    // for changed page size
    protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
}