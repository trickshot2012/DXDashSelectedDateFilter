using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXDashSelectedDateFilter
{
    public partial class Viewer : System.Web.UI.Page
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["NWindConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
           // DBExecuteNq("update Orders set OrderDate=DATEADD(month, -4, OrderDate) ");
            string dx = "" + Request.QueryString["dx"] + ".xml";
            if (dx != ".xml") ASPxDashboard1.DashboardXmlPath = "~/App_Data/Dashboards/" + dx;
        }

        public static string DBExecuteNq(string AktionSql)
        {
            int retValue = 0;
            string reError = "";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connStr;
            conn.Open();
            try
            {
                SqlCommand Cmd = new SqlCommand(AktionSql, conn);
                retValue = Cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                reError = ex.Message;
            }
            conn.Close();
            return (reError == "") ? retValue.ToString() : reError;
        }

    }
}