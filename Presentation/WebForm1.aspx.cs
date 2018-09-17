using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinesLogic;
using System.Data;

namespace Presentation
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        User NewUser = new User();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = NewUser.ListUsers();
            GridView1.DataSource = dt;
            GridView1.DataBind();
          
        }
    }
}