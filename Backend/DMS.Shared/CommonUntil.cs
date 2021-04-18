using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;


using System.IO;
using Microsoft.AspNetCore.Http;
using System.Net.Sockets;
using System.Collections;
using ImageMagick;
//using Microsoft.Reporting.WinForms.Internal.Soap.ReportingServices2005.Execution;

namespace DMS.Shared
{
    public class CommonUntil
    {
        int a = 0;
        public int KMPSearch(string pat, string txt)
        {
            int M = pat.Length;
            int N = txt.Length;

            int[] lps = new int[M];
            int j = 0;

            computeLPSArray(pat, M, lps);

            int i = 0;
            while (i < N)
            {
                if (pat[j] == txt[i])
                {
                    j++;
                    i++;
                }
                if (j == M)
                {

                    a = 1;
                    j = lps[j - 1];

                }
                else if (i < N && pat[j] != txt[i])
                {

                    if (j != 0)
                        j = lps[j - 1];
                    else
                        i = i + 1;
                }
            }
            return a;
        }
        public void computeLPSArray(string pat, int M, int[] lps)
        {
            int len = 0;
            int i = 1;
            lps[0] = 0;

            while (i < M)
            {
                if (pat[i] == pat[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0)
                    {
                        len = lps[len - 1];
                    }
                    else
                    {
                        lps[i] = len;
                        i++;
                    }
                }
            }
        }
        public static string convertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        private bool ValidateImport(List<dynamic> model, String hosostyle, String kestyle, String khostyle)
        {
            if (model.Count < 3)
            {
                //KryptonMessageBox.Show("Không có dữ liệu để import.");
                return false;
            }
            //errorProvider.Clear();
            bool result = true;
            List<string> fields = new List<string>();
            if (hosostyle + "" == "0")
            {
                fields.Add(" - Loại hồ sơ");
                //errorProvider.SetError(cbLoaiHoSoImport, "Chọn loại hồ sơ");
                result = false;
            }
            if (khostyle + "" == "0")
            {
                fields.Add(" - Kho");
                //errorProvider.SetError(cbKhoImport, "Chọn kho");
                result = false;
            }
            if (result)
            {
                if (kestyle + "" == "0")
                {
                    return false;
                }
            }
            /*else
            {
                KryptonMessageBox.Show(string.Join(Environment.NewLine, fields), "Chọn các trường dữ liệu sau", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
            return result;
        }
        public DataTable ConvertToDataTable<T>(IList<T> list)
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable();
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static bool DeleteFileOnFtpServer(Uri serverUri, string ftpUsername, string ftpPassword)
        {
            try
            {
                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return false;
                }
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.Method = WebRequestMethods.Ftp.DeleteFile;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //Console.WriteLine("Delete status: {0}", response.StatusDescription);
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string GetIPAddress()
        {
            /*var ipAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ipAdd))
            {
                ipAdd = Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                lblIPAddress.Text = ipAdd;
            }*/
            return "";
        }

        public static bool DeleteFolderOnFtp(Uri serverUri, string ftpUsername, string ftpPassword)
        {
            try
            {

                if (serverUri.Scheme != Uri.UriSchemeFtp)
                {
                    return false;
                }
                // Get the object used to communicate with the server.
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(serverUri);
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
                request.Method = WebRequestMethods.Ftp.RemoveDirectory;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                //Console.WriteLine("Delete status: {0}", response.StatusDescription);
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static void SendTcpLogStash(string message)
        {
            //try
            //{
            //    using (var socket = new TcpClient(AppSettings.Instance.ElasticLoggerSettings.Hosts, AppSettings.Instance.ElasticLoggerSettings.Port))
            //    {
            //        var body = Encoding.UTF8.GetBytes(message);
            //        var bodyLength = Encoding.UTF8.GetByteCount(message);

            //        var headerContent = new StringBuilder();
            //        headerContent.AppendLine("POST /someUrl/someReceiver.aspx HTTP/1.0");
            //        headerContent.AppendLine("Accept: */*");
            //        headerContent.AppendLine("Host: " + AppSettings.Instance.ElasticLoggerSettings.Port);
            //        headerContent.AppendLine("Content-Type: application/javascript; charset=utf-8");
            //        headerContent.AppendLine("Content-Length: " + bodyLength);
            //        headerContent.AppendLine("Connection: Close");
            //        headerContent.AppendLine();

            //        var headerString = headerContent.ToString();
            //        var header = Encoding.UTF8.GetBytes(headerString);
            //        var headerLength = Encoding.UTF8.GetByteCount(headerString);

            //        using (var stream = socket.GetStream())
            //        {
            //            stream.Write(header, 0, headerLength);
            //            stream.Write(body, 0, bodyLength);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
                
            //}
        }
        public static String HexColorConvert(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public ArrayList ConvertFileToImages(string filePath, string destinationPath)
        {
            int noofPages = 0;
            var listImage = new ArrayList();
            MagickReadSettings magickReadSettings = new MagickReadSettings();
            magickReadSettings.Density = new Density(200, 200);
            using (MagickImageCollection magickImageCollection = new MagickImageCollection())
            {
                magickImageCollection.Read(filePath, magickReadSettings);
                int page = 1;
                noofPages = magickImageCollection.Count;
                if (magickImageCollection.Count < 1)
                {
                    return null;
                }
                foreach (MagickImage magickImage in magickImageCollection)
                {
                    magickImage.Format = MagickFormat.Png;
                    string imageFilePath = string.Concat(destinationPath, "file-", page, ".png");
                    //magickImage.Write(imageFilePath);
                    var image = magickImage.ToBase64();
                    listImage.Add(image);
                    page++;
                }
            }
            return listImage;
        }

    }

}
