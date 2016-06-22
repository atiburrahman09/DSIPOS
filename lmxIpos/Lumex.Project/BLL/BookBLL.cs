﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Lumex.Project.DAL;
using Lumex.Tech;


namespace Lumex.Project.BLL
{
    public class BookBLL
    {
        public string No { get; set; }

        public string KitaberSerialNo { get; set; }

        public string AlmariNo { get; set; }

        public string TakNo { get; set; }

        public string KolamNo { get; set; }

        public string KitabNo { get; set; }

        public string CopyNo { get; set; }

        public string TotalVolumeNo { get; set; }

        public string VolumeNo { get; set; }

        public string KhondoNo { get; set; }

        public string PageNumber { get; set; }

        public string Price { get; set; }

        public string KitaberMainName { get; set; }

        public string KitaberMashurName { get; set; }

        public string Writter { get; set; }

        public string WritterBirthYear { get; set; }

        public string WritterDeathYear { get; set; }

        public string WritterMajhab { get; set; }

        public string Songkolok { get; set; }

        public string Translator { get; set; }

        public string TranslatorDate { get; set; }

        public string TranslatorMajhab { get; set; }

        public string KitaberMainLanguage { get; set; }

        public string KitaberTranslateLanguage { get; set; }

        public string Subject { get; set; }

        public string Chapter { get; set; }

        public string Publisher { get; set; }

        public string PublishDate { get; set; }

        public string Publication { get; set; }

        public string PublicationPlace { get; set; }

        public string Sompadona { get; set; }

        public string Songskoron { get; set; }

        public string Summary { get; set; }

        public string Comment { get; set; }

        public bool SaveBook()
        {
            BookDLL bookDll=new BookDLL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2,true);
                status = bookDll.SaveBook(this, db);
                db.Stop();
                return status;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable GetBookList()
        {
            DataTable dt=new DataTable();
            BookDLL bookDll=new BookDLL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2, true);
                dt = bookDll.GetBookList(db);
                db.Stop();
            }
            catch (Exception)
            {
                
                throw;
            }
            return dt;
        }

        public bool UpdateBook()
        {
            BookDLL bookDll = new BookDLL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2, true);
                status = bookDll.UpdateBook(this, db);
                db.Stop();
                return status;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetBookListBySerial()
        {
            DataTable dt = new DataTable();
            BookDLL bookDll = new BookDLL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2,true);
                dt = bookDll.GetBookListBySerial(this,db);
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public bool CheckDuplicate()
        {
            DataTable dt = new DataTable();
            bool status = false;
            BookDLL bookDll = new BookDLL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2,true);
                dt = bookDll.CheckDuplicate(this, db);
                if (dt.Rows.Count > 0)
                {
                    status = true;
                }
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        public DataTable GetBookName()
        {
            DataTable dt = new DataTable();
            BookDLL bookDll = new BookDLL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2, true);
                dt = bookDll.GetBookName(db);
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public string searchId { get; set; }

        public DataTable GetBookListBySerchId()
        {
            DataTable dt = new DataTable();
            BookDLL bookDll = new BookDLL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2, true);
                dt = bookDll.GetBookListBySerchId(this, db);
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable GetBookNamesOnly()
        {
            DataTable dt = new DataTable();
            BookDLL bookDll = new BookDLL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2, true);
                dt = bookDll.GetBookNamesOnly(db);
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public string BookName { get; set; }

        public DataTable SearchForBook(string querry)
        {
            DataTable dt = new DataTable();
            BookDLL bookDll = new BookDLL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2, true);
                dt = bookDll.SearchForBook(querry , db);
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public string LanguageName { get; set; }

        public string Country { get; set; }

        public bool SaveLanguageForBook()
        {
            DataTable dt = new DataTable();
            BookDLL bookDll = new BookDLL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2, true);
                status = bookDll.SaveLanguageForBook(this, db);
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        public DataTable GetLanguageList()
        {
            DataTable dt = new DataTable();
            BookDLL bookDll = new BookDLL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2, true);
                dt = bookDll.GetLanguageList(db);
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable GetLanguageListBySerial(string LanguageSerial)
        {
            DataTable dt = new DataTable();
            BookDLL bookDll = new BookDLL();
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2, true);
                dt = bookDll.GetLanguageListBySerial(LanguageSerial,db);
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public bool UpdateLanguageForBook()
        {
            DataTable dt = new DataTable();
            BookDLL bookDll = new BookDLL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2, true);
                status = bookDll.UpdateLanguageForBook(this, db);
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            return status;
        }

        public string Serial { get; set; }

        public string BookSerial { get; set; }

        public string PublishYear { get; set; }

        public DataTable GetTotalRowForBookID()
        {
            DataTable dt = new DataTable();
            BookDLL bookDll = new BookDLL();
            bool status = false;
            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2, true);
                dt = bookDll.GetTotalRowForBookID( db);
                db.Stop();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }



        public void DeleteBook(string BookId)
        {
            BookDLL bookDll = new BookDLL();

            try
            {
                LumexDBPlayer db = LumexDBPlayer.Start(2,true);
                bookDll.DeleteBook(BookId, db);
                db.Stop();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                bookDll = null;
            }
        }

        public string KitaberMainLanguageValue { get; set; }

        public string KitaberTranslateLanguageValue { get; set; }
    }
}
