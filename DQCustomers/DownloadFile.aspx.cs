using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace DQCustomers
{
    public partial class DownloadFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            BasicClass BS = new BasicClass();
            DataTable dt = BS.ExcelToDatatable(Server.MapPath("2021-11-17.xlsx"), true, false, "2021-11-17");

            SqlBulkCopy objbik = new SqlBulkCopy(BS.ConnectionString);

            objbik.DestinationTableName = "tblSanPham";

            objbik.ColumnMappings.Add(0, "QRCode");//Code
            objbik.ColumnMappings.Add(1, "SoYeuCau");
            objbik.ColumnMappings.Add(2, "MaLBT");
            objbik.ColumnMappings.Add(3, "NhaMay");
            objbik.ColumnMappings.Add(4, "MaSanPham");

            objbik.ColumnMappings.Add(5, "TenSanPham");
            objbik.ColumnMappings.Add(6, "Model");
            objbik.ColumnMappings.Add(7, "SoLot");
            objbik.ColumnMappings.Add(8, "TrangThai");
            objbik.ColumnMappings.Add(9, "NguoiTao");

            objbik.ColumnMappings.Add(10, "NgayTao");
            objbik.ColumnMappings.Add(11, "NgayDuyet");
            objbik.ColumnMappings.Add(12, "CongSuat");
            objbik.ColumnMappings.Add(13, "MoTa");
            objbik.ColumnMappings.Add(14, "NamBaoHanh");

            objbik.ColumnMappings.Add(14, "LinkSanPham");

            objbik.WriteToServer(dt);
        }


        public string TuDDongTaiFile()
        {
            BasicClass BS = new BasicClass();

            string strDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            string strUrl = "https://beeapi.dienquang.info:8443/dqc-warranty-info-api/api/v1/productEntities?created_at=" + strDate;
            string token = "token:" + BS.MD5Hash("/api/v1/productEntities?created_at=" + strDate + "." + BS.MD5Hash(strDate.Replace("-", "")));

            string filenameCsv = @"D:\" + strDate + ".csv";
            var webRequest = System.Net.WebRequest.Create(strUrl);
            webRequest.ContentType = "application/text;charset=UTF-8-BOM";
            webRequest.Method = "GET";
            webRequest.Headers.Add(token);

            using (System.IO.Stream s = webRequest.GetResponse().GetResponseStream())
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(s, System.Text.Encoding.UTF8))
                {
                    //Save zip file on D: drive
                    StreamWriter oWriter = new StreamWriter(filenameCsv, false, Encoding.UTF8);
                    oWriter.Write(sr.ReadToEnd());
                    oWriter.Close();

                    string xls = @"D:\" + strDate + ".xlsx";

                    Application app = new Application();
                    Workbook wb = app.Workbooks.Open(filenameCsv, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    wb.SaveAs(xls, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, Type.Missing, Type.Missing, XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    wb.Close();
                    app.Quit();


                    //DataTable dt = BS.ExcelToDatatable(xls, true, false);

                    //using (TANHUYNHCHAUEntities db = new TANHUYNHCHAUEntities())
                    //{
                    //    for (int i = 0; i < 3; i++)
                    //    {
                    //        tblTest t = new tblTest();
                    //        t.Ten = dt.Rows[i]["factory_name"].ToString();
                    //        db.tblTests.Add(t);

                    //    }
                    //    db.SaveChanges();
                    //}
                }
            }
            return filenameCsv;
        }
    }
}