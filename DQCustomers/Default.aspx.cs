using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DQCustomers.Models;

namespace DQCustomers
{
    public partial class Default : System.Web.UI.Page
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
                BasicClass BS = new BasicClass();
                string qr = BS.RequestQueryString("q", "");
                var data = db.tblSanPhams.Where(c => c.QRCode == qr).Take(1).FirstOrDefault();
                if (data!=null)
                {
                    txtTenSP.Text = data.TenSanPham;

                }
            }
        }
    }
}