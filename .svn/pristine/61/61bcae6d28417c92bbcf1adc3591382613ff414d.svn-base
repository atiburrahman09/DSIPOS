using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Web;
using System.Web.UI;
using Lumex.Project.Security;
using Lumex.Tech;

namespace lmxIpos.UI.Backup
{
    public partial class BackupDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                msgbox.Visible = false;

                if (!IsPostBack)
                {

                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void MyAlertBox(string alertScript)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ServerControlScript", alertScript, true);
        }

        protected void ClearBackupDirectory()
        {
            try
            {
                Array.ForEach(Directory.GetFiles(Server.MapPath("/BackupDB/")), delegate(string path) { File.Delete(path); });
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected string BackupDatabaseFile(string dbName)
        {
            string databaseBackupPath = "";

            try
            {
                string dateString = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + "_" + DateTime.Now.Ticks.ToString();
                string connectionString = ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
                SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder(connectionString);

                databaseBackupPath = Server.MapPath("/BackupDB/") + connectionBuilder.InitialCatalog + "_" + dateString + ".bak";
                databaseBackupPath = databaseBackupPath.Replace("'", "''");

                string sql = "BACKUP DATABASE " + connectionBuilder.InitialCatalog + " TO DISK = '" + databaseBackupPath + "'";

                LumexDBPlayer db = LumexDBPlayer.Start();
                db.ExecuteNonQuery(sql);
                db.Stop();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }

            return databaseBackupPath;
        }

        protected void DownloadDatabaseFile(string strURL)
        {
            try
            {
                string[] urlBlocks = strURL.Split('\\');

                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("Content-Disposition", "attachment;filename=\"" + urlBlocks[urlBlocks.Length - 1].ToString() + "\"");

                byte[] data = req.DownloadData(strURL);

                response.BinaryWrite(data);
                response.End();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void backupButton_Click(object sender, EventArgs e)
        {
            try
            {
                ClearBackupDirectory();
                System.Threading.Thread.Sleep(100);

                string backupURL = BackupDatabaseFile(dbNameDropDownList1.SelectedValue.Trim());
                backupURL = backupURL.Replace("''", "'");
                System.Threading.Thread.Sleep(100);

                DirectoryInfo directorySelected = new DirectoryInfo(Server.MapPath("/BackupDB/"));
                foreach (FileInfo fileToCompress in directorySelected.GetFiles())
                { AppSecurity.CompressFile(fileToCompress); }
                System.Threading.Thread.Sleep(100);

                DownloadDatabaseFile(backupURL + ".zip");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
            finally
            {
                //MyAlertBox("MyOverlayStop();");
            }
        }

        protected void clearBackupDirectoryButton_Click(object sender, EventArgs e)
        {
            ClearBackupDirectory();
            string message = "Backup Directory <span class='actionTopic'>Cleared</span> Successfully.";
            MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
        }

        protected void RestoreDatabaseFile(string dbName, string filePath)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings[dbName].ConnectionString;
                SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder(connectionString);

                filePath = filePath.Substring(0, filePath.Length - 4);
                filePath = filePath.Replace("'", "''");

                string sql = "USE master ALTER DATABASE " + connectionBuilder.InitialCatalog + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                sql += " RESTORE DATABASE " + connectionBuilder.InitialCatalog + " FROM DISK = '" + filePath + "' ";
                sql += "ALTER DATABASE " + connectionBuilder.InitialCatalog + " SET MULTI_USER";

                LumexDBPlayer db = LumexDBPlayer.Start();
                db.ExecuteNonQuery(sql);
                db.Stop();
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void restoreButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dbFileUpload.HasFile)
                {
                    if (Path.GetExtension(dbFileUpload.FileName) == ".zip")
                    {
                        string message = "Database <span class='actionTopic'>Restored</span> Successfully.";
                        MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");

                        ClearBackupDirectory();
                        System.Threading.Thread.Sleep(100);

                        string uploadPath = Server.MapPath("/BackupDB/" + dbFileUpload.FileName);
                        dbFileUpload.PostedFile.SaveAs(uploadPath);
                        System.Threading.Thread.Sleep(100);

                        DirectoryInfo directorySelected = new DirectoryInfo(Server.MapPath("/BackupDB/"));
                        foreach (FileInfo fileToDecompress in directorySelected.GetFiles())
                        { AppSecurity.DecompressFile(fileToDecompress); }
                        System.Threading.Thread.Sleep(100);

                        RestoreDatabaseFile(dbNameDropDownList2.SelectedValue.ToString(), uploadPath);
                    }
                    else
                    {
                        msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "Only Compressed (.zip) file of Database is allowed.";
                    }
                }
                else
                {
                    msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = "No Backup Database File is Selected.";
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                if (ex.InnerException != null) { message += " --> " + ex.InnerException.Message; }
                MyAlertBox("ErrorAlert(\"" + ex.GetType() + "\", \"" + message + "\", \"\");");
            }
        }

        protected void clearRestoreDirectoryButton_Click(object sender, EventArgs e)
        {
            ClearBackupDirectory();
            string message = "Restore Directory <span class='actionTopic'>Cleared</span> Successfully.";
            MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
        }
    }
}