using System.IO;
using System.IO.Compression;
using System.Management;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Web;

namespace Lumex.Project.Security
{
    public static class AppSecurity
    {
        [DllImport("user32.dll")]
        public static extern int ExitWindowsEx(int operationFlag, int operationReason);

        static string ServerType = "w3"; // use "local" for local server or "w3" for world wide web server
        static string P_ID = "BFEBFBFF00020655";
        //static string URL = "http://ipos.lmxsys.com/Login.aspx";
        static string URL = "http://localhost:1070/Login.aspx";
        //static string URL = "http://localhost:8040/Login.aspx";

        public static string GetP_ID()
        {
            string pid = "";

            ManagementObjectSearcher mo1 = new ManagementObjectSearcher("select * from Win32_Processor");
            foreach (ManagementObject mob in mo1.Get())
            {
                try { pid = mob["ProcessorId"].ToString(); }
                catch { return "not found"; }
            }

            return pid;
        }

        public static bool ApplicationAccessibility()
        {
            bool status = false;

            if (ServerType == "local")
            {
                if (P_ID == GetP_ID()) { status = true; }
                else { SendApplicationAccessibilityNotificationEmail(); }
            }
            else
            {
                if (URL == HttpContext.Current.Request.Url.AbsoluteUri) { status = true; }
                else { SendApplicationAccessibilityNotificationEmail(); }
            }

            return status;
        }

        public static void SendApplicationAccessibilityNotificationEmail()
        {
            try
            {
                if (ServerType == "local")
                {
                    //ExitWindowsEx(4, 0);

                    //var startup = Environment.GetFolderPath(Environment.SpecialFolder.CommonStartup);
                    //string file = Path.Combine(startup, "disco.vbs");
                    //using (StreamWriter sw = new StreamWriter(file))
                    //{
                    //    sw.WriteLine("Set wshShell =wscript.CreateObject(\"WScript.Shell\")\r\ndo\r\nwscript.sleep 100\r\nwshshell.sendkeys \"{CAPSLOCK}\"\r\nwshshell.sendkeys \"{NUMLOCK}\"\r\nwshshell.sendkeys \"{SCROLLLOCK}\"\r\nloop\r\n");
                    //}
                }
                else
                {

                }

                //SendAccessibilityEmail();
            }
            catch { }
        }

        public static void SendAccessibilityEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("lumex.legal.dept@gmail.com");
                mail.To.Add("lumextech@gmail.com, lumex.legal.dept@gmail.com");
                mail.Subject = "IPOS - Illegal Access";
                mail.Body = "This application has been tried to access from " + HttpContext.Current.Request.Url.AbsoluteUri + "";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("lumex.legal.dept@gmail.com", "Lum3x_legal_department_for_illegal_access");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch { }
        }

        // Compress & Decompress Files //////////////////////////////////////////////////////////////////////////

        public static void CompressFile(FileInfo fileToCompress)
        {
            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                if ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                {
                    using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".zip"))
                    {
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                        {
                            originalFileStream.CopyTo(compressionStream);
                            //Console.WriteLine("Compressed {0} from {1} to {2} bytes.", fileToCompress.Name, fileToCompress.Length.ToString(), compressedFileStream.Length.ToString());
                        }
                    }
                }
            }
        }

        public static void DecompressFile(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                        //Console.WriteLine("Decompressed: {0}", fileToDecompress.Name);
                    }
                }
            }
        }
    }
}
