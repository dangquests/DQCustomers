using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DQCustomers.Models;
using Microsoft.AspNet.Identity;

namespace DQCustomers
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        void LoadData()
        {
            using (DBDIENQUANGEntities db=new DBDIENQUANGEntities())
            {
                string username = User.Identity.Name;
                var data = db.tblSanPhamTheoNguoiDungs.Where(c => c.UserName == username).OrderByDescending(c => c.NgayLuuSanPham).ToList();
                rptList.DataSource = data;
                rptList.DataBind();
            }
        }

        protected void lbtThoat_Click(object sender, EventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}