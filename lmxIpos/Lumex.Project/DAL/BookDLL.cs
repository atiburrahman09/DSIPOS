﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Configuration;
using System.Security.Policy;
using System.Text;

namespace Lumex.Project.DAL
{
    public class BookDLL
    {
        internal bool SaveBook(BLL.BookBLL bookBLL, Tech.LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            bool status = false;
            try
            {

                db.AddParameters("@BookSerial", bookBLL.KitaberSerialNo);
                db.AddParameters("@AlmariNo", bookBLL.AlmariNo);
                db.AddParameters("@takno", bookBLL.TakNo);
                db.AddParameters("@KitabNo", bookBLL.KitabNo);
                db.AddParameters("@KolamNo", bookBLL.KolamNo);
                db.AddParameters("@CopyNo", bookBLL.CopyNo);
                db.AddParameters("@TotalVolium", bookBLL.TotalVolumeNo);
                db.AddParameters("@Volium", bookBLL.VolumeNo);
                db.AddParameters("@PartNo", bookBLL.KhondoNo);
                db.AddParameters("@PageNo", bookBLL.PageNumber);
                db.AddParameters("@Price", bookBLL.Price);
                db.AddParameters("@BookName", bookBLL.KitaberMainName);
                db.AddParameters("@BookKnownName", bookBLL.KitaberMashurName);
                db.AddParameters("@WriterName", bookBLL.Writter);
                db.AddParameters("@WriterDOB", bookBLL.WritterBirthYear);
                db.AddParameters("@WriterDD", bookBLL.WritterDeathYear);
                db.AddParameters("@WriterMazhab", bookBLL.WritterMajhab);
                db.AddParameters("@Songkolok", bookBLL.Songkolok);
                db.AddParameters("@Onubadok ", bookBLL.Translator);
                db.AddParameters("@OnubadokDOB_DD", bookBLL.TranslatorDate);
                db.AddParameters("@OnubadokMazvab", bookBLL.TranslatorMajhab);
                db.AddParameters("@BookLanguage", bookBLL.KitaberMainLanguage);
                db.AddParameters("@TranslateLanguage", bookBLL.KitaberTranslateLanguage);
                db.AddParameters("@BookLanguageValue", bookBLL.KitaberMainLanguageValue);
                db.AddParameters("@TranslateLanguageValue", bookBLL.KitaberTranslateLanguageValue);
                db.AddParameters("@Bishoy", bookBLL.Subject);
                db.AddParameters("@Chapter", bookBLL.Chapter);
                db.AddParameters("@Publisher", bookBLL.Publisher);
                db.AddParameters("@PublishDate", bookBLL.PublishDate);
                db.AddParameters("@Publication", bookBLL.Publication);
                db.AddParameters("@PublicationPlace", bookBLL.PublicationPlace);
                db.AddParameters("@Editor", bookBLL.Sompadona);
                db.AddParameters("@Edition", bookBLL.Songskoron);
                db.AddParameters("@suchi", bookBLL.Summary);
                db.AddParameters("@Remarks", bookBLL.Comment);
                db.AddParameters("@BookId", bookBLL.AlmariNo.PadLeft(3, '0') + bookBLL.TakNo.PadLeft(3, '0') + bookBLL.KolamNo.PadLeft(3, '0') + bookBLL.KitabNo.PadLeft(3, '0') + bookBLL.KitaberSerialNo.PadLeft(4, '0'));
                dt = db.ExecuteDataTable("INSERT INTO [dbo].[bookInfo]([BookSerial],[AlmariNo],[takno],[KitabNo],[KolamNo],[CopyNo],[TotalVolium],[Volium],[PartNo],[PageNo],[Price],[BookName],[BookKnownName],[WriterName],[WriterDOB],[WriterDD],[WriterMazhab],[Songkolok],[Onubadok],[OnubadokDOB_DD],[OnubadokMazvab],[BookLanguage],[BookLanguageValue],[TranslateLanguage],[TranslateLanguageValue],[Bishoy],[Chapter],[Publisher],[PublishDate],[Publication],[PublicationPlace],[Editor],[Edition],[suchi],[Remarks],[BookId])VALUES(@BookSerial,@AlmariNo,@takno,@KitabNo,@KolamNo,@CopyNo,@TotalVolium,@Volium,@PartNo,@PageNo,@Price,@BookName,@BookKnownName,@WriterName,@WriterDOB,@WriterDD,@WriterMazhab,@Songkolok,@Onubadok ,@OnubadokDOB_DD,@OnubadokMazvab,@BookLanguage,@BookLanguageValue,@TranslateLanguage,@TranslateLanguageValue,@Bishoy,@Chapter,@Publisher,@PublishDate,@Publication,@PublicationPlace,@Editor,@Edition,@suchi,@Remarks,@BookId)");
                status = true;
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        internal DataTable GetBookList(Tech.LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db.ExecuteDataTable("SELECT [Serial],[BookSerial],[AlmariNo],[takno],[KitabNo],[CopyNo],[TotalVolium],[Volium],[PartNo],[PageNo],[Price],[BookName],[BookKnownName],[WriterName],[WriterDOB],[WriterDD],[WriterMazhab],[Songkolok],[Onubadok],[OnubadokDOB_DD],[OnubadokMazvab],[BookLanguage],[TranslateLanguage],[Bishoy],[Chapter],[Publisher],[PublishDate],[Publication],[PublishYear],[Editor],[Edition],[suchi],[Remarks],[BookId]FROM [dbo].[bookInfo]");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal bool UpdateBook(BLL.BookBLL bookBLL, Tech.LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            bool status = false;
            try
            {

                db.AddParameters("@BookSerial", bookBLL.KitaberSerialNo);
                db.AddParameters("@AlmariNo", bookBLL.AlmariNo);
                db.AddParameters("@takno", bookBLL.TakNo);
                db.AddParameters("@KitabNo", bookBLL.KitabNo);
                db.AddParameters("@KolamNo", bookBLL.KolamNo);
                db.AddParameters("@CopyNo", bookBLL.CopyNo);
                db.AddParameters("@TotalVolium", bookBLL.TotalVolumeNo);
                db.AddParameters("@Volium", bookBLL.VolumeNo);
                db.AddParameters("@PartNo", bookBLL.KhondoNo);
                db.AddParameters("@PageNo", bookBLL.PageNumber);
                db.AddParameters("@Price", bookBLL.Price);
                db.AddParameters("@BookName", bookBLL.KitaberMainName);
                db.AddParameters("@BookKnownName", bookBLL.KitaberMashurName);
                db.AddParameters("@WriterName", bookBLL.Writter);
                db.AddParameters("@WriterDOB", bookBLL.WritterBirthYear);
                db.AddParameters("@WriterDD", bookBLL.WritterDeathYear);
                db.AddParameters("@WriterMazhab", bookBLL.WritterMajhab);
                db.AddParameters("@Songkolok", bookBLL.Songkolok);
                db.AddParameters("@Onubadok ", bookBLL.Translator);
                db.AddParameters("@OnubadokDOB_DD", bookBLL.TranslatorDate);
                db.AddParameters("@OnubadokMazvab", bookBLL.TranslatorMajhab);
                db.AddParameters("@BookLanguage", bookBLL.KitaberMainLanguage);
                db.AddParameters("@TranslateLanguage", bookBLL.KitaberTranslateLanguage);
                db.AddParameters("@BookLanguageValue", bookBLL.KitaberMainLanguageValue);
                db.AddParameters("@TranslateLanguageValue", bookBLL.KitaberTranslateLanguageValue);
                db.AddParameters("@Bishoy", bookBLL.Subject);
                db.AddParameters("@Chapter", bookBLL.Chapter);
                db.AddParameters("@Publisher", bookBLL.Publisher);
                db.AddParameters("@PublishDate", bookBLL.PublishDate);
                db.AddParameters("@Publication", bookBLL.Publication);
                db.AddParameters("@PublishYear", bookBLL.PublishDate);
                db.AddParameters("@PublicationPlace", bookBLL.PublicationPlace);
                db.AddParameters("@Editor", bookBLL.Sompadona);
                db.AddParameters("@Edition", bookBLL.Songskoron);
                db.AddParameters("@suchi", bookBLL.Summary);
                db.AddParameters("@Remarks", bookBLL.Comment);
                db.AddParameters("@BookId", bookBLL.No);
                dt = db.ExecuteDataTable("UPDATE [dbo].[bookInfo] SET [BookSerial]=@BookSerial,[AlmariNo]=@AlmariNo,[takno]=@takno,[KitabNo]=@kitabNo,[KolamNo]=@KolamNo,[CopyNo]=@CopyNo,[TotalVolium]=@TotalVolium,[Volium]=@Volium,[PartNo]=@PartNo,[PageNo]=@PageNo,[Price]=@Price,[BookName]=@BookName,[BookKnownName]=@BookKnownName,[WriterName]=@WriterName,[WriterDOB]=@WriterDOB,[WriterDD]=@WriterDD,[WriterMazhab]=@WriterMazhab,[Songkolok]=@Songkolok,[Onubadok]=@Onubadok,[OnubadokDOB_DD]=@OnubadokDOB_DD,[OnubadokMazvab]=@OnubadokMazvab,[BookLanguage]=@BookLanguage,[BookLanguageValue]=@BookLanguageValue,[TranslateLanguage]=@TranslateLanguage,[TranslateLanguageValue]=@TranslateLanguageValue,[Bishoy]=@Bishoy,[Chapter]=@Chapter,[Publisher]=@Publisher,[PublishDate]=@PublishDate,[Publication]=@Publication,[PublishYear]=@PublishYear,[PublicationPlace]=@PublicationPlace,[Editor]=@Editor,[Edition]=@Edition,[suchi]=@suchi,[Remarks]=@Remarks,[BookId]=@BookId WHERE [BookId]=@BookId");
                status = true;
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        internal DataTable GetBookListBySerial(BLL.BookBLL bookBLL, Tech.LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@BookId", bookBLL.No);
                dt = db.ExecuteDataTable("SELECT [Serial],[BookSerial],[AlmariNo],[takno],[KitabNo],[KolamNo],[CopyNo],[TotalVolium],[Volium],[PartNo],[PageNo],[Price],[BookName],[BookKnownName],[WriterName],[WriterDOB],[WriterDD],[WriterMazhab],[Songkolok],[Onubadok],[OnubadokDOB_DD],[OnubadokMazvab],[BookLanguage],[BookLanguageValue],[TranslateLanguage],[TranslateLanguageValue],[Bishoy],[Chapter],[Publisher],[PublishDate],[Publication],[PublishYear],[PublicationPlace],[Editor],[Edition],[suchi],[Remarks],[BookId]FROM [dbo].[bookInfo] WHERE [BookId]=@BookId");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable CheckDuplicate(BLL.BookBLL bookBLL, Tech.LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@BookId", bookBLL.No);
                dt = db.ExecuteDataTable("SELECT [Serial],[BookSerial],[AlmariNo],[takno],[KitabNo],[CopyNo],[TotalVolium],[Volium],[PartNo],[PageNo],[Price],[BookName],[BookKnownName],[WriterName],[WriterDOB],[WriterDD],[WriterMazhab],[Songkolok],[Onubadok],[OnubadokDOB_DD],[OnubadokMazvab],[BookLanguage],[TranslateLanguage],[Bishoy],[Chapter],[Publisher],[PublishDate],[Publication],[PublishYear],[Editor],[Edition],[suchi],[Remarks],[BookId]FROM [dbo].[bookInfo] WHERE [BookId]=@BookId");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable GetBookName(Tech.LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db.ExecuteDataTable("SELECT BookId, (BookName+' ['+ WriterName+']')  as BookName FROM [dbo].[bookInfo]");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable GetBookListBySerchId(BLL.BookBLL bookBLL, Tech.LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@BookId", bookBLL.searchId);
                dt = db.ExecuteDataTable("SELECT [Serial],[BookSerial],[AlmariNo],[takno],[KitabNo],[KolamNo],[CopyNo],[TotalVolium],[Volium],[PartNo],[PageNo],[Price],[BookName],[BookKnownName],[WriterName],[WriterDOB],[WriterDD],[WriterMazhab],[Songkolok],[Onubadok],[OnubadokDOB_DD],[OnubadokMazvab],[BookLanguage],[TranslateLanguage],[Bishoy],[Chapter],[Publisher],[PublishDate],[Publication],[PublishYear],[PublicationPlace],[Editor],[Edition],[suchi],[Remarks],[BookId]FROM [dbo].[bookInfo] WHERE [BookId]=@BookId");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable GetBookNamesOnly(Tech.LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db.ExecuteDataTable("SELECT [BookName] FROM [dbo].[bookInfo]");
            }
            catch (Exception)
            {

                throw;
            }
           return dt;
        }

        internal DataTable SearchForBook(string query, Tech.LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@Query", query);
                //db.AddParameters("@WriterName",bookBLL.Writter);
                //db.AddParameters("@Publisher",bookBLL.Publisher);
                //db.AddParameters("@BookLanguage",bookBLL.KitaberMainLanguage);
                //dt = db.ExecuteDataTable("SELECT [Serial],[BookSerial],[AlmariNo],[takno],[KitabNo],[KolamNo],[CopyNo],[TotalVolium],[Volium],[PartNo],[PageNo],[Price],[BookName],[BookKnownName],[WriterName],[WriterDOB],[WriterDD],[WriterMazhab],[Songkolok],[Onubadok],[OnubadokDOB_DD],[OnubadokMazvab],[BookLanguage],[TranslateLanguage],[Bishoy],[Chapter],[Publisher],[PublishDate],[Publication],[PublishYear],[PublicationPlace],[Editor],[Edition],[suchi],[Remarks],[BookId] FROM [dbo].[bookInfo] WHERE " + query);
                dt = db.ExecuteDataTable("SEARCH_FOR_BOOK",true);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal bool SaveLanguageForBook(BLL.BookBLL bookBLL, Tech.LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            bool status = false;
            try
            {
                db.AddParameters("@LanguageName", bookBLL.LanguageName);
                db.AddParameters("@Country", bookBLL.Country);
                dt = db.ExecuteDataTable("INSERT INTO [dbo].[tbl_language]([LanguageName],[Country])VALUES(@LanguageName, @Country)");
                status = true;

            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        internal DataTable GetLanguageList(Tech.LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = db.ExecuteDataTable("SELECT [Serial],[LanguageName], [Country] FROM [dbo].[tbl_language]");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal DataTable GetLanguageListBySerial(string LanguageSerial, Tech.LumexDBPlayer db)
        {
            DataTable dt = new DataTable();
            try
            {
                db.AddParameters("@Serial", LanguageSerial);
                dt = db.ExecuteDataTable("SELECT [LanguageName], [Country] FROM [dbo].[tbl_language] WHERE Serial=@Serial");
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        internal bool UpdateLanguageForBook(BLL.BookBLL bookBLL, Tech.LumexDBPlayer db)
        {
            try
            {
                DataTable dt = new DataTable();
                bool status = false;
                db.AddParameters("Serial", bookBLL.Serial);
                db.AddParameters("LanguageName", bookBLL.LanguageName);
                db.AddParameters("Country", bookBLL.Country);
                dt = db.ExecuteDataTable("UPDATE [dbo].[tbl_language] SET [LanguageName]=@LanguageName,[Country]=@Country WHERE [Serial]=@Serial");
                status = true;
                return status;
            }
            catch (Exception)
            {

                throw;
            }

        }

        internal DataTable GetTotalRowForBookID(Tech.LumexDBPlayer db)
        {
            DataTable dt = db.ExecuteDataTable("SELECT COUNT (Serial)+1 FROM [dbo].[bookInfo]");
            return dt;
        }

        internal void DeleteBook(string BookId, Tech.LumexDBPlayer db)
        {
            try
            {
                db.AddParameters("@BookId",BookId);
                DataTable dt=db.ExecuteDataTable("DELETE FROM [dbo].[bookInfo] WHERE BookId=@BookId");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
