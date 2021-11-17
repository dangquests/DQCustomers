using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using AspNetProfile = System.Web.Profile;
using System.Globalization;
using System.Reflection;
using System.IO;
using DQCustomers.Models;
using System.Security.Cryptography;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Page = System.Web.UI.Page;
using System.Configuration;

namespace DQCustomers
{
    public class BasicClass
    {/// <summary>
     /// Active LeftMenu, dùng trong trang con, trang chi tiết mà muốn giử lại vị trí của trang trước;
     /// </summary>
     /// <param name="position">Vị trí cần active-Tính từ 0 trong PlaceHolder</param>
        public void ActiveLeftMenu(int position)
        {
            Page page = HttpContext.Current.Handler as Page;
            page.ClientScript.RegisterStartupScript(page.GetType(), "ActiveLeftMenu", "ActiveLeftMenu(" + position + ");", true);
        }

        #region RequestQueryString
        /// <summary>
        /// Get Value Of QueryString
        /// </summary>
        /// <param name="QueryName"></param>
        /// <param name="DefaultValue"></param>
        /// <returns>long</returns>
        public int RequestQueryString(string QueryName, int DefaultValue)
        {
            int returnVal = TryParse(DefaultValue.ToString(), 0);

            ///Request QueryString
            if (HttpContext.Current.Request.QueryString[QueryName] != null && IsNumeric(HttpContext.Current.Request.QueryString[QueryName].ToString()))
            {
                returnVal = System.Convert.ToInt32(HttpContext.Current.Request.QueryString[QueryName].ToString().Replace("#", ""));
            }
            ///Return
            return returnVal > int.MaxValue ? 0 : returnVal;
        }
        #endregion

        #region RequestQueryString
        /// <summary>
        /// Get Value Of QueryString
        /// </summary>
        /// <param name="QueryName">string QueryName</param>
        /// <param name="DefaultValue">string DefaultValue</param>
        /// <returns>string</returns>
        public string RequestQueryString(string QueryName, string DefaultValue)
        {
            string returnVal = ((DefaultValue != null) ? DefaultValue : "");

            ///Request QueryString
            if (HttpContext.Current.Request.QueryString[QueryName] != null)
            {
                returnVal = HttpContext.Current.Request.QueryString[QueryName].ToString().Replace("'", "''").Replace("\"", "").Replace("#", "");
            }

            ///Return
            return returnVal.Trim();
        }
        #endregion

        #region UpdateQueryString
        public string UpdateQueryString(string QueryStringKey, string QueryStringValue, string Url)
        {
            string NewUrl = Url;
            if (Url == "")
            {
                NewUrl = HttpContext.Current.Request.Url.PathAndQuery;
            }
            string PageUrl = NewUrl;
            if (NewUrl.IndexOf("?", 0) >= 0)
                PageUrl = NewUrl.Substring(0, NewUrl.IndexOf("?", 0));

            string NewKey = QueryStringKey + "=" + QueryStringValue;
            string NewQueryString = "";

            string OldQueryString = "";
            if (NewUrl.IndexOf("?", 0) >= 0)
                OldQueryString = NewUrl.Substring(NewUrl.IndexOf("?", 0) + 1);

            if (OldQueryString != "" && QueryStringKey != "")
            {
                string[] ArrayQuery = OldQueryString.Split('&');
                for (int i = 0; i < ArrayQuery.Length; i++)
                {
                    if (string.Compare(QueryStringKey, ArrayQuery[i].Substring(0, ArrayQuery[i].LastIndexOf("=")), true) == 0)
                    {
                        //NewQueryString += NewKey;
                    }
                    else
                    {
                        if (NewQueryString != "")
                            NewQueryString += "&";

                        NewQueryString += ArrayQuery[i];
                    }
                }


                if (QueryStringValue != "")
                {
                    if (NewQueryString != "")
                        NewQueryString += "&";

                    NewQueryString += NewKey;
                }


                if (NewQueryString != "")
                    NewUrl = PageUrl + "?" + NewQueryString;
                else
                    NewUrl = PageUrl;

            }
            else
            {
                if (QueryStringKey != "" && QueryStringValue != "")
                {
                    NewUrl = PageUrl + "?" + NewKey;
                }
            }
            return NewUrl;
        }
        #endregion

        #region TryParse
        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent. Returns 0 if the conversion fails.
        /// </summary>
        public int TryParse(string s)
        {
            return TryParse(s, 0);
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent. Returns defaultValue if the conversion fails.
        /// </summary>
        public int TryParse(string s, int defaultValue)
        {
            try
            {
                return int.Parse(s);
            }
            catch
            {
                return defaultValue;
            }
        }

        /// <summary>
        /// Converts the string representation of a number to its 32-bit signed integer equivalent. Returns defaultValue if the conversion fails.
        /// </summary>
        public long TryParse(string s, long defaultValue)
        {
            try
            {
                return int.Parse(s);
            }
            catch
            {
                return defaultValue;
            }
        }

        public DateTime TryParseToDateTime(object d)
        {
            try
            {
                return Convert.ToDateTime(d);
            }
            catch
            {
                return new DateTime(0);
            }
        }
        public bool IsInt32(string input)
        {
            try
            {
                Convert.ToInt32(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsFloat(string input)
        {
            try
            {
                Convert.ToSingle(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region IsNumeric
        /// <summary>
        /// Ex Input is a numeric
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public bool IsNumeric(string Text)
        {
            if (Text == "" || Text == null)
            {
                return false;
            }
            Text = Text.Trim();
            bool bResult = Regex.IsMatch(Text, @"^\d+$");
            return bResult;
        }
        #endregion

        #region ***ShowMsg - javascript**
        /// <summary>
        /// ShowMsg
        /// </summary>
        /// <param name="Msg">Set Msg</param>
        /// <param name="RedirectURL">Set redirectULR</param>
        /// <param name="PopupURL">Set PopupURL</param>
        /// <param name="Width">Set PopupWidth</param>
        /// <param name="Height">Set PopupHeight</param>
        /// <param name="p">set Page</param>
        public string ShowMsg(string Msg, string RedirectURL, string PopupURL, string Width, string Height, Page p)
        {
            string w = (Width.Length > 1) ? Width : "100";
            string h = (Height.Length > 1) ? Height : "100";
            StringBuilder sbScript = new StringBuilder(string.Empty);
            if (Msg.Length > 1)
                sbScript.AppendLine("alert('" + Msg.Replace(Environment.NewLine, string.Empty) + "');");
            if (PopupURL.Length > 1)
                sbScript.AppendLine("window.open('" + PopupURL.Replace(Environment.NewLine, string.Empty) + "','Popup','width=" + w + ",height=" + h + ",menubar=no,scrollbars=yes');");
            if (RedirectURL.Length > 1)
                sbScript.AppendLine("window.location='" + RedirectURL.Replace(Environment.NewLine, string.Empty) + "';");
            if (!p.ClientScript.IsStartupScriptRegistered("ScriptMsg"))
                ScriptManager.RegisterStartupScript(p, p.GetType(), DateTime.Now.Ticks.ToString(), sbScript.ToString(), true);
            return sbScript.ToString().Replace(Environment.NewLine, string.Empty);
        }
        #endregion
        #region Number to string
        /// <summary>
        /// Hàm đọc từ số thành chữ (Tiếng Việt)
        /// </summary>
        /// <param name="num">Số đưa vào theo dạng chuổi</param>
        /// <returns>Kết quả sau khi đọc</returns>
        public string ReadNumToString(string num)
        {
            //num = Convert.ToDouble(num).ToString();
            double a = 0;
            if (Double.TryParse(num, out a))
            {
                string text = "";
                if (num.Length == 1)
                    text = Doc1So(num);
                else if (num.Length == 2)
                    text = Doc2So(num);
                else if (num.Length == 3)
                    text = Doc3So(num);
                else if (num.Length > 3)
                {
                    int temp = 0;
                    int j = num.Length;

                    while (j > 0)
                    {
                        if (temp + 1 == num.Length)
                            text = text.Insert(0, Doc1So(num.Substring(j - 1, 1)));
                        else if (temp + 2 == num.Length)
                            text = text.Insert(0, Doc2So(num.Substring(j - 2, 2)));
                        else
                        {
                            text = text.Insert(0, Doc3So(num.Substring(j - 3, 3)));
                        }
                        j = j - 3;
                        temp = temp + 3;
                        if (temp < num.Length)
                            text = text.Insert(0, GhepSo(temp));
                    }
                }
                text = text.Trim().Replace("tỷ  triệu  nghìn", " tỷ ").Replace("triệu  nghìn", " triệu ").Replace("tỷ  tỷ", " tỷ ");
                return text = text.Substring(0, 1).ToUpper() + text.Substring(1, text.Length - 1) + " đồng";
            }
            return "";
        }
        private string GhepSo(int index)
        {
            string temp = "";
            if (index == 3)
                temp = " nghìn ";
            else if (index == 6)
                temp = " triệu ";
            else if (index == 9)
                temp = " tỷ ";
            else if (index == 12)
                temp = " nghìn tỷ";
            else if (index == 15)
                temp = " triệu tỷ";
            else if (index == 18)
                temp = " tỷ tỷ ";
            return temp;
        }
        private string Doc3So(string text)
        {
            if (text.Substring(1, 1).Equals("0"))
                if (text.Substring(2, 1).Equals("0"))
                    if (text.Substring(0, 1).Equals("0"))
                        return "";
                    else
                        return Doc1So(text.Substring(0, 1)) + " trăm";
                else
                    return Doc1So(text.Substring(0, 1)) + " trăm lẻ " + Doc1So(text.Substring(2, 1));
            else
                return Doc1So(text.Substring(0, 1)) + " trăm " + Doc2So(text.Substring(1, 2));
        }
        private string Doc2So(string text)
        {
            // neu so dau la so 1
            if (text.Substring(0, 1) == "1")
            {
                //neu so cuoi la so 0
                if (text.Substring(1, 1).Equals("0"))
                    return "mười";
                else if (text.Substring(1, 1).Equals("1"))
                    return "mười một";
                else if (text.Substring(1, 1).Equals("5"))
                    return "mười lăm";
                else
                    return "mười " + Doc1So(text.Substring(1, 1));
            }
            else
            {
                if (text.Substring(1, 1).Equals("0"))
                    return Doc1So(text.Substring(0, 1)) + " mươi";
                else if (text.Substring(1, 1).Equals("5"))
                    return Doc1So(text.Substring(0, 1)) + " mươi lăm";
                else
                    if (text.Substring(1, 1).Equals("1"))
                    return Doc1So(text.Substring(0, 1)) + " mươi mốt";
                else
                    return Doc1So(text.Substring(0, 1)) + " mươi " + Doc1So(text.Substring(1, 1));
            }
        }
        private string Doc1So(string lsNumber)
        {
            string result = "";
            switch (lsNumber)
            {
                case "0":
                    result = "không";
                    break;
                case "1":
                    result = "một";
                    break;
                case "2":
                    result = "hai";
                    break;
                case "3":
                    result = "ba";
                    break;
                case "4":
                    result = "bốn";
                    break;
                case "5":
                    result = "năm";
                    break;
                case "6":
                    result = "sáu";
                    break;
                case "7":
                    result = "bảy";
                    break;
                case "8":
                    result = "tám";
                    break;
                case "9":
                    result = "chín";
                    break;
            }
            return result;
        }
        #endregion
        public void Alert(string message, Page obj)
        {
            obj.RegisterClientScriptBlock("Alert", "<script language=javascript>alert(\"" + message + "\");</script>");
        }

        public void Alert(string message, string url, Page obj)
        {
            obj.RegisterClientScriptBlock("Alert", "<script language=javascript>alert(\"" + message + "\"); window.location='" + url + "';</script>");
        }

        #region ***URL***
        public string EncodeURL(string s)
        {
            return HttpContext.Current.Server.UrlEncode(s.Length > 0 ? s : string.Empty);
        }
        public string DecodeURL(string s)
        {
            return HttpContext.Current.Server.UrlDecode(s.Length > 0 ? s : string.Empty);
        }
        #endregion

        #region IsDate
        /// <summary>
        /// IsDate
        /// </summary>
        /// <param name="Text">String</param>
        /// <returns>True or False?</returns>
        public bool IsDate(string Text)
        {
            bool result = true;
            DateTime date;

            try
            {
                date = Convert.ToDateTime(Text);
            }
            catch
            {
                result = false;
            }

            return result;
        }
        #endregion



        #region FormatDate
        public string ParseDateTimeToEng(string strDate)
        {
            string rs;
            string days, months, years;

            string strD = strDate.Replace("/", " ");
            char[] chr = { ' ' };
            string[] strArray;
            strArray = strD.Split(chr);
            int len = strArray.Length;

            if (len == 3)
            {
                days = strArray[0];
                days = (days.Length < 2) ? "0" + days : days;
                months = strArray[1];
                months = (months.Length < 2) ? "0" + months : months;
                years = strArray[2];
            }
            else if (len == 2)
            {
                days = "01";
                months = strArray[0];
                months = (months.Length < 2) ? "0" + months : months;
                years = strArray[1];
            }
            else//len=1
            {
                days = "01";
                months = "01";
                years = strArray[0];
            }
            rs = months + "/" + days + "/" + years;

            return rs;
        }
        public string ConvertToSqlDateTime(string strDate)
        {
            try
            {
                if (strDate.Length < 0)
                {
                    return "01-01-01";
                }
                else
                {
                    //SqlDateTime sdt = SqlDateTime.Parse(ParseDateTimeToEng(strDate));
                    //string sdtStr = sdt.ToString();
                    return ParseDateTimeToEng(strDate.Substring(0, 10));
                }
            }
            catch (Exception)
            {

                return string.Empty;
            }

        }
        /// <summary>
        /// Convert string to datetime;
        /// </summary>
        /// <param name="strDate">ngày cần convert</param>
        /// <param name="typeFormat">Loại format của ngày hiện tại-1: dd/MM/yyyy</param>
        /// <returns></returns>
        public DateTime ParseStringToDateTime(string strDate, int typeFormat)
        {
            DateTime aDateTime;
            DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
            switch (typeFormat)
            {
                case 1://dd/MM/yyyy
                    dtfi.ShortDatePattern = "dd/MM/yyyy";
                    dtfi.DateSeparator = "/";
                    aDateTime = Convert.ToDateTime(strDate, dtfi);
                    break;
                default:
                    aDateTime = DateTime.Now;
                    break;
            }

            return aDateTime;
        }

        public bool IsValidDateTime(string dateTime)
        {
            string[] formats = { "dd/MM/yyyy" };
            DateTime parsedDateTime;
            return DateTime.TryParseExact(dateTime, formats, new CultureInfo("vi-VN"),
                                           DateTimeStyles.None, out parsedDateTime);
        }
        #endregion

        #region ***Set Culture ***
        /// <summary>
        /// 
        /// </summary>
        CultureInfo aCultureInfo = new CultureInfo("vi-VN", true);
        /// <summary>
        /// 
        /// </summary>
        public CultureInfo myCultureInfo
        {
            get
            {
                aCultureInfo.ClearCachedData();
                aCultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                aCultureInfo.DateTimeFormat.ShortTimePattern = "hh:mm:ss tt";
                aCultureInfo.DateTimeFormat.LongDatePattern = "{0} dd ";
                aCultureInfo.NumberFormat.NumberDecimalDigits = 0;
                aCultureInfo.NumberFormat.CurrencyDecimalDigits = 0;
                return aCultureInfo;
            }
        }
        #endregion


        /// <summary>
        /// Get computer INTERNET address like 93.136.91.7
        /// </summary>
        /// <returns></returns>
        private string GetComputer_InternetIP()
        {
            // check IP using DynDNS's service
            System.Net.WebRequest request = System.Net.WebRequest.Create("http://checkip.dyndns.org");
            System.Net.WebResponse response = request.GetResponse();
            System.IO.StreamReader stream = new System.IO.StreamReader(response.GetResponseStream());

            // IMPORTANT: set Proxy to null, to drastically INCREASE the speed of request
            request.Proxy = null;

            // read complete response
            string ipAddress = stream.ReadToEnd();

            // replace everything and keep only IP
            return ipAddress.
                Replace("<html><head><title>Current IP Check</title></head><body>", string.Empty).
                Replace("</body></html>", string.Empty);
        }

        const string vn1 = "áàảãạâấầẩẫậăắằẳẵặúùủũụưứừửữựóòỏõọôốồổỗộơớờởỡợéèẻẽẹêếềểễệýỳỷỹỵíìỉĩịđ";
        const string vn2 = "aaaaaaaaaaaaaaaaauuuuuuuuuuuoooooooooooooooooeeeeeeeeeeeyyyyyiiiiid";
        public string RemoveAccents(string s)
        {
            string v1 = vn1 + vn1.ToUpper();
            string v2 = vn2 + vn2.ToUpper();
            char ch;
            int index;
            StringBuilder B = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                ch = s[i];
                index = v1.IndexOf(ch);
                if (index != -1)
                    B.Append(v2[index]);
                else
                    B.Append(ch);
            }

            string Val = B.ToString().Trim().Replace("?", "").Replace("`", "").Replace("~", "").Replace("^", "").Replace("'", "").Replace("&", "").Replace(" ", "-");
            Val = Val.Replace("---", "-").Replace("--", "-");
            return Val;
        }

        public string RemoveSpecialKey(string s)
        {
            string Val = s.ToString().Trim().Replace("?", "").Replace("`", "").Replace("~", "").Replace("^", "").Replace("'", "").Replace("&", "");//
            return Val;
        }
        /// <summary>
        /// Tạo tên đăng nhập cho khách hàng
        /// </summary>
        /// <param name="id">ID khách hàng</param>
        /// <returns></returns>
        public string TaoTenDangNhap(int id)
        {
            Random rd = new Random();
            return "DF" + rd.Next(100, 999).ToString() + id.ToString();
        }

        /// <summary>
        /// Tạo tên đăng nhập cho công ty
        /// </summary>
        /// <returns></returns>
        public string TaoTenDangNhap()
        {
            Random rd = new Random();
            return "DFT" + rd.Next(100, 999).ToString();
        }

        public string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }




        /// <summary>
        /// Read from excel to Datatable
        /// </summary>
        /// <param name="excelPath">excel file path</param>
        /// <param name="hasHeader">whether read column header, false - read, true - won't read</param>
        /// <param name="isMixedData">false - all string, true - string & numeric</param>
        /// <param name="sheetName">sheet name, default sheet1</param>
        /// <param name="startRow">read from row, start from 0</param>
        /// <param name="endRow">read to row, start from 0</param>
        /// <param name="startColumn">read from column, start from 0</param>
        /// <param name="endColumn">read to column, start from 0</param>
        /// <returns></returns>
        public DataTable ExcelToDatatable(string excelPath, bool hasHeader, bool isMixedData, string sheetName = "sheet1", int startRow = -1, int endRow = -1, int startColumn = -1, int endColumn = -1)
        {
            string HDR = hasHeader ? "Yes" : "No";
            string IMEX = isMixedData ? "1" : "0";
            string strConn;
            if (excelPath.Substring(excelPath.LastIndexOf('.')).ToLower() == ".xlsx")
                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelPath + ";Extended Properties=\"Excel 12.0;HDR=" + HDR + ";IMEX=" + IMEX + "\"";
            else
                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath + ";Extended Properties=\"Excel 8.0;HDR=" + HDR + ";IMEX=" + IMEX + "\"";

            DataTable outputTable = null;

            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                try
                {
                    conn.Open();

                    DataTable schemaTable = conn.GetOleDbSchemaTable(
                        OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "$]", conn);
                    cmd.CommandType = CommandType.Text;

                    outputTable = new DataTable(sheetName);
                    new OleDbDataAdapter(cmd).Fill(outputTable);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message + string.Format("Sheet:{0}.File:F{1}", sheetName, excelPath), ex);
                }
            }

            // remove tail rows not expected
            if (endRow != -1 && endRow < outputTable.Rows.Count)
            {
                for (int i = endRow + 1; i < outputTable.Rows.Count; i++)
                {
                    outputTable.Rows.RemoveAt(endRow + 1);
                }
            }

            // remove start rows not expected
            if (startRow != -1)
            {
                for (int i = 0; i < startRow; i++)
                {
                    outputTable.Rows.RemoveAt(0);
                }
            }

            // remove tail columns not expected
            if (endColumn != -1 && endColumn < outputTable.Columns.Count)
            {
                for (int i = endColumn + 1; i < outputTable.Columns.Count; i++)
                {
                    outputTable.Columns.RemoveAt(endColumn + 1);
                }
            }

            // remove start columns not expected
            if (startColumn != -1)
            {
                for (int i = 0; i < startColumn; i++)
                {
                    outputTable.Columns.RemoveAt(0);
                }
            }

            return outputTable;
        }

        public DataTable ToDataTable<T>(List<T> items)
        {

            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        public string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultCNN"].ConnectionString;
        private SqlTransaction trans = null;
        public DataTable SQL_GetStoredProcedure(string storedProcedure, Dictionary<String, String> parameters = null)
        {
            SqlConnection sqlConn = new SqlConnection(ConnectionString);
            if (sqlConn.State == ConnectionState.Closed)
            {
                sqlConn.Open();
            }
            SqlCommand sqlCmd = new SqlCommand();
            if (trans != null)
                sqlCmd.Transaction = trans;
            sqlCmd.Connection = sqlConn;
            try
            {
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = storedProcedure;
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        sqlCmd.Parameters.AddWithValue("@" + param.Key, param.Value);
                    }
                }
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlCmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (trans == null)
                {
                    if (sqlConn.State == ConnectionState.Open)
                    {
                        sqlConn.Close();
                    }
                }
            }
        }
    }
}