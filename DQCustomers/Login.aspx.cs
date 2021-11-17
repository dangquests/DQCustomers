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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                BasicClass BS = new BasicClass();
                using (DBDIENQUANGEntities db = new DBDIENQUANGEntities())
                {
                    string email = "";
                    string matkhau = txtMatKhauDK.Text;
                    string username = txtEmailDK.Text;

                    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                    var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
                    var user = new ApplicationUser() { UserName = username, Email = username };
                    IdentityResult result = manager.Create(user, BS.MD5Hash(matkhau));

                    if (result.Succeeded)
                    {
                        var data = manager.Users.Where(c => c.UserName == username).FirstOrDefault();
                        if (data != null)
                        {
                            manager.RemovePassword(data.Id);
                            IdentityResult result2 = manager.AddPassword(data.Id, matkhau);

                            //Call API Insert to Antbuddy CRM
                            int result_API = 0;
                            

                            var thamso = new Dictionary<String, String>() { { "Id", data.Id }, { "HoTen", txtHoTenDK.Text }
                        , { "DienThoai", txtDienThoaiDK.Text }, { "DiaChi", ""}, { "SyncToAntbuddy",result_API.ToString() }};
                            var data2 = BS.SQL_GetStoredProcedure("SP_AspNetUsers_Update", thamso);

                        }

                        divOK.Visible = true;
                        divClose.Visible = false;

                        //Hiển thị thông báo thành công
                        lblmess.Text = "Đăng ký thành công.";
                        ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", "ShowPopupMess()", true);
                    }
                    else
                    {
                        //Hiển thị thông báo Đăng ký thất bại
                        lblmess.Text = "Đăng ký không thành công, vui lòng kiểm tra lại thông tin.";
                        ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", "ShowPopupMess()", true);
                    }
                }
            }
            catch (Exception ex)
            {
                //Ghi log đăng ký thất bại

                //Hiển thị thông báo đăng ký thất bại
                lblmess.Text = "Đăng ký không thành công.";
                ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", "ShowPopupMess()", true);
            }
           
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                var result = signinManager.PasswordSignIn(txtEmailDN.Text, txtMatKhauDN.Text, true, shouldLockout: false);

                switch (result)
                {
                    case SignInStatus.Success:
                        {

                            using (DBDIENQUANGEntities db = new DBDIENQUANGEntities())
                            {
                                IdentityHelper.RedirectToReturnUrl("Profile.aspx", Response);
                            }
                            break;
                        }
                    case SignInStatus.LockedOut:
                        Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}",
                                                        Request.QueryString["ReturnUrl"],
                                                        true),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        lblMessDN.Text = "Sai thông tin đăng nhập.";
                        break;
                }
            }
        }
    }
}