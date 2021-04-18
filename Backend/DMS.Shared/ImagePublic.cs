using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using DMS.Shared;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using ICSharpCode.SharpZipLib.Zip;
using System.IO.Compression;

namespace DMS.Shared
{
    public static class ImagePublic
    {
        private static HttpClient CreateClient()
        {
            var orcHost = AppSettings.Instance.OcrSettings.Hosts;
            var client = new HttpClient()
            {
                BaseAddress = new Uri(orcHost),
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        //public static string URL_FTP = "ftp://10.70.123.2";
        //public static string USER_FTP = "sohoa";
        //public static string PASS_FTP = "sohoa";
        public static async System.Threading.Tasks.Task<string> WriteFileAsync(IFormFile file, string id, string linkFtpLuu)
        {
            var settings = AppSettings.Instance.FtpServers;
            var URL_FTP = settings.Hosts;
            var USER_FTP = settings.Username;
            var PASS_FTP = settings.Password;

            string fileName;

   
           
            try
            {
                fileName = file.FileName;

                var seperate = fileName.Split('.');
                var onlyName = fileName.Replace("." + seperate[seperate.Length - 1], "");
                onlyName = onlyName.Replace(".", "_");
                onlyName = onlyName.Replace("#", "_");
                onlyName = onlyName.Replace("-", "_");
                onlyName = onlyName.Replace(" ", "_");
                onlyName = onlyName + '.' + seperate[seperate.Length - 1];


                var filePath = Path.GetFullPath(onlyName);
                //Tạo folder
                var folder = id + "//" + id;
                CreateFolderFTP(folder);
                CreateFolderFTP2(folder);
                //upload
                string requestUriString = string.Format(@"{0}/{1}//{2}", URL_FTP, folder, Path.GetFileName(filePath));
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(requestUriString);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(USER_FTP, PASS_FTP);
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = true;

                var a = file.OpenReadStream();
                byte[] buffer = new byte[file.Length];
                a.Read(buffer, 0, buffer.Length);
                a.Close();
                Stream reqStream = request.GetRequestStream();
                reqStream.Write(buffer, 0, buffer.Length);
                reqStream.Close();

                var ms = new MemoryStream();
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                var linkFtpFile = requestUriString;
                using (var client = CreateClient())
                {
                    var url = "convert";
                    OcrConvertToPdf2 body = new OcrConvertToPdf2(linkFtpFile, linkFtpLuu, fileName);
                    var content = JsonConvert.SerializeObject(body);
                    var payload = new StringContent(content, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(url, payload);
                    if (response.IsSuccessStatusCode == false) return null;
                    var responseBody = await response.Content.ReadAsStringAsync();

                    return responseBody;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            //return fileName;
        }
        public  static void CreateFolderFTP(string folder)
        {
            var settings = AppSettings.Instance.FtpServers;
            var URL_FTP = settings.Hosts;
            var USER_FTP = settings.Username;
            var PASS_FTP = settings.Password;
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(URL_FTP + "/" + folder);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;
                request.Credentials = new NetworkCredential(USER_FTP, PASS_FTP);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                var requestStream = response.GetResponseStream();
                requestStream.Close();
                response.Close();
            }
            catch (Exception ex)
            {
                //directory already exist I know that is weak but there is no way to check if a folder exist on ftp...
            }
        }
        public static void CreateFolderFTP2(string folder)
        {
            var settings = AppSettings.Instance.FtpServers;
            var URL_FTP = settings.Hosts;
            var USER_FTP = settings.Username;
            var PASS_FTP = settings.Password;
            try
            {
                FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(URL_FTP + "/FilePdf/" + folder);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                request.UsePassive = true;
                request.UseBinary = true;
                request.KeepAlive = false;
                request.Credentials = new NetworkCredential(USER_FTP, PASS_FTP);
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                var requestStream = response.GetResponseStream();
                requestStream.Close();
                response.Close();
                //return URL_FTP + "//" + folder;
            }
            catch (Exception ex)
            {
                //return ex.Message;
                //directory already exist I know that is weak but there is no way to check if a folder exist on ftp...
            }
        }
        public static string DownLoadImage(string linkFtp)
        {
            try
            {
                string[] temptype = linkFtp.Split('/');
                var host = temptype[0] + "//" + temptype[2] + "/";
                var hostDownLoad = AppSettings.Instance.FtpServers.Hosts;

                linkFtp = linkFtp.Replace(host, hostDownLoad);

                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential("sohoa", "sohoa");
                byte[] bytes = client.DownloadData(linkFtp);

                String file = Convert.ToBase64String(bytes);
                return file;
            }
            catch (Exception err)
            {
                return "";
            }
        }
        public static byte[] ZipProfile(List<string> links, List<string> documentsName, string ProfileName)
        {
            var listBytes = new List<byte[]>();
            for(int i = 0;i< links.Count; i++)
            {
                var bytes = ZipDocument(links[i]);
                listBytes.Add(bytes);
            }
            //FileStream fZip = File.Create("C:\\Users\\demo2\\Desktop\\1_files\\"+ProfileName+".zip");
            var outputMemStream = new MemoryStream();
            using (ZipOutputStream zipOStream = new ZipOutputStream(outputMemStream))
            {
                for (int i = 0; i < listBytes.Count; i++)
                {
                    ZipEntry entry = new ZipEntry((CommonUntil.convertToUnSign(documentsName[i]) + ".zip"));
                    zipOStream.PutNextEntry(entry);
                    zipOStream.Write(listBytes[i], 0, listBytes[i].Length);

                }
                //outputMemStream.Position = 0;
                zipOStream.CloseEntry();
              
            }
            //using (ZipOutputStream zipOStream = new ZipOutputStream(fZip))
            //{
            //    for (int i = 0; i < listBytes.Count; i++)
            //    {
            //        ZipEntry entry = new ZipEntry((CommonUntil.convertToUnSign(documentsName[i]) + ".zip"));
            //        zipOStream.PutNextEntry(entry);
            //        zipOStream.Write(listBytes[i], 0, listBytes[i].Length);

            //    }
            //    //outputMemStream.Position = 0;
            //    zipOStream.CloseEntry();

            //}

            //var base64 = Convert.ToBase64String(outputMemStream.ToArray());
            return outputMemStream.ToArray();
        }
        public static byte[] ZipDocument(string link)
        {
            FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(link);
            ftpRequest.Credentials = new NetworkCredential("sohoa", "sohoa");
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            List<string> directories = new List<string>();

            string line = streamReader.ReadLine();
            while (!string.IsNullOrEmpty(line))
            {
                directories.Add(line);
                line = streamReader.ReadLine();
            }
            streamReader.Close();

            var listFile = new List<byte[]>();
            //var listName = new List<string>();

            using (WebClient ftpClient = new WebClient())
            {
                ftpClient.Credentials = new System.Net.NetworkCredential("sohoa", "sohoa");

                for (int i = 0; i <= directories.Count - 1; i++)
                {
                    if (directories[i].Contains("."))
                    {

                        string path = link + directories[i].ToString();
                        byte[] bytes = ftpClient.DownloadData(path);
                        listFile.Add(bytes);
                    }
                }
            }

            var outputMemStream = new MemoryStream();
            using (ZipOutputStream zipOStream = new ZipOutputStream(outputMemStream))
            {
                for (int i = 0; i < listFile.Count; i++)
                {
                    ZipEntry entry = new ZipEntry((directories[i].ToString()));
                    zipOStream.PutNextEntry(entry);
                    zipOStream.Write(listFile[i], 0, listFile[i].Length);

                }
                zipOStream.CloseEntry();
            }
            return outputMemStream.ToArray();

        }



        public static bool CheckIfFileExistsOnServer(string link)
        {
            var request = (FtpWebRequest)WebRequest.Create(link);
            request.Credentials = new NetworkCredential("sohoa", "sohoa");
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    return false;
            }
            return false;
        }

        public static string TranslateText(string input)
        {
            string url = string.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", "vi", "en", input);
            HttpClient httpClient = new HttpClient();
            string result = httpClient.GetStringAsync(url).Result;
            string[] temp = result.Split('"');
            if (temp[1] is null)
            {
                return input;
            }
            return temp[1].Trim();

        }
        public  static ResultCreateFolder ReadFile()
        {
            string line;
            string fileName = @"C:\VNPT-SoHoa\idOrganization.txt";
            try
            {
                if (File.Exists(fileName) == false)
                {
                    return new ResultCreateFolder(null);
                }
                StreamReader sr = new StreamReader(fileName);
                line = sr.ReadLine();
                sr.Close();
                return new ResultCreateFolder(line);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
        }
        public static ResultCreateFolder WriteFile(string data)
        {
            string fileName = @"C:\VNPT-SoHoa\idOrganization.txt";
            string dicrect = @"C:\VNPT-SoHoa";
            try
            {
                if(File.Exists(fileName) == false)
                {
                    Directory.CreateDirectory(dicrect);
                    StreamWriter sw = File.CreateText(fileName);
                    sw.WriteLine(data);
                    sw.Close();
                    return new ResultCreateFolder(data);
                } else
                {
                    StreamWriter sw = File.CreateText(fileName);
                    sw.WriteLine(data);
                    sw.Close();
                    return new ResultCreateFolder(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return null;
            }
        }

    }

    public class OcrConvertToPdf2
    {
        public string linkFtpFile { get; set; }
        public string linkFtpLuu { get; set; }
        public string fileName { get; set; }

        public OcrConvertToPdf2(string _fileBase64, string linkLuu, string _nameFile)
        {
            linkFtpFile = _fileBase64;
            linkFtpLuu = linkLuu;
            fileName = _nameFile;
        }
    }

    public class ResultCreateFolder
    {
        public string data { get; set; }
        public ResultCreateFolder(string _data)
        {
            data = _data;
        }
    }

    public class FileModel
    {
        public string FileName { get; set; }
        public byte[] FileStream { get; set; }
        public string FileType { get; set; }
    }
}
