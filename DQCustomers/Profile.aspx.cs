using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DQCustomers.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace DQCustomers
{
    public partial class Profile : System.Web.UI.Page
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
            try
            {
                using (DBDIENQUANGEntities db = new DBDIENQUANGEntities())
                {
                    string userName = Context.User.Identity.Name;
                    var data = db.AspNetUsers.Where(c => c.UserName == userName).Take(1).FirstOrDefault();
                    if (data!=null)
                    {
                        txtDiaChi.Text = data.DiaChi;
                        txtDienThoai.Text = data.DienThoai;
                        txtEmail.Text = data.Email;
                        txtHoTen.Text = data.HoTen;
                    }
                }
            }
            catch
            {

            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                using (DBDIENQUANGEntities db=new DBDIENQUANGEntities())
                {
                    string username = User.Identity.Name;
                    AspNetUser u = db.AspNetUsers.Where(c => c.UserName == username).Take(1).FirstOrDefault();
                    if (u != null)
                    {
                        u.Id = u.Id;
                        u.HoTen = txtHoTen.Text;
                        u.DienThoai = txtDienThoai.Text;
                        u.Email = txtEmail.Text;
                        u.DiaChi = txtDiaChi.Text;

                        if (db.SaveChanges() > 0)
                        {
                            if (txtMatKhau1.Text.Length > 5)
                            {
                                //Cập nhật lại mật khẩu
                                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                                manager.RemovePassword(u.Id);
                                IdentityResult result2 = manager.AddPassword(u.Id, txtMatKhau1.Text);
                            }
                            ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", "showAndDismissAlert('success', 'Lưu thông tin thành công.')", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", "showAndDismissAlert('danger', 'Vui lòng nhập thông tin cần thay đổi.')", true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", "showAndDismissAlert('danger', 'Lưu thông tin không thành công.')", true);
            }
        }

        public enum MessageType { Success, Error, Info, Warning };
        protected void ShowMessage(string Message, MessageType type)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
        }
        protected void btnInfo_Click(object sender, EventArgs e)
        {
            ShowMessage("Please verify your data before submitting", MessageType.Info);
        }
    }
}