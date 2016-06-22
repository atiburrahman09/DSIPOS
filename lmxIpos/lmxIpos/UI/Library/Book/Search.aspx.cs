﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lumex.Project.BLL;
using Lumex.Tech;

namespace lmxIpos.UI.Library.Book
{
    public partial class Search : System.Web.UI.Page
    {
        private string SearchString = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
            }
            if (bookListGridView.Rows.Count > 0)
            {
                bookListGridView.UseAccessibleHeader = true;
                bookListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
       

        public string HighlightText(string InputTxt)
        {
            string Search_Str = txtbxSearch.Text;
            // Setup the regular expression and add the Or operator.
            Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
            // Highlight keywords by calling the
            //delegate each time a keyword is found.
            return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
        }

        public string ReplaceKeyWords(Match m)
        {
            return ("<span class=highlight>" + m.Value + "</span>");
        }
     
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            int check = 0;
            BookBLL bookBll = new BookBLL();
            bookBll.BookName = "";
            bookBll.Writter = "";
            bookBll.Publisher = "";
            bookBll.KitaberMainLanguage = "";
            string querry = "";
            string name = txtbxSearch.Text.Trim();
            StringBuilder output = new StringBuilder(name.Length);
            SearchString = txtbxSearch.Text;

            for (int index = 0; index < name.Length; index++)
            {
                if (!Char.IsWhiteSpace(name, index))
                {
                    output.Append(name[index]);
                }
            }

            try
            {

                foreach (ListItem listItem in bookCheckBoxList.Items)
                {
                    if (listItem.Selected)
                    {
                        check++;
                        switch (listItem.Value)
                        {
                            case "BN":
                                {
                                    if (querry == "")
                                    {
                                        querry = "[BookName] LIKE '%" + output.ToString() + "%'";
                                    }
                                    else
                                    {
                                        querry = "or [BookName] LIKE '%" + output.ToString() + "%'";
                                    }

                                    break;
                                }
                            case "WN":
                                {
                                    if (querry == "")
                                    {
                                        querry += "[WriterName] LIKE '%" + output.ToString() + "%'";
                                    }
                                    else
                                    {
                                        querry += "or " + "[WriterName] LIKE '%" + output.ToString() + "%'";
                                    }

                                    break;
                                }
                            case "PN":
                                {
                                    if (querry == "")
                                    {
                                        querry += "[Publisher] LIKE '%" + output.ToString() + "%'";
                                    }
                                    else
                                    {
                                        querry += "or " + "[Publisher] LIKE '%" + output.ToString() + "%'";
                                    }

                                    break;
                                }
                            case "BL":
                                {
                                    if (querry == "")
                                    {
                                        querry += "[BookLanguage] LIKE '%" + output.ToString() + "%'";
                                    }
                                    else
                                    {
                                        querry += "or " + "[BookLanguage] LIKE '%" + output.ToString() + "%'";
                                    }

                                    break;
                                }
                            case "AN":
                                {
                                    if (querry == "")
                                    {
                                        querry += "[AlmariNo] LIKE '%" + output.ToString() + "%'";
                                    }
                                    else
                                    {
                                        querry += "or " + "[AlmariNo] LIKE '%" + output.ToString() + "%'";
                                    }

                                    break;
                                }
                            case "LN":
                                {
                                    if (querry == "")
                                    {
                                        querry += "[LibraryName] LIKE '%" + output.ToString() + "%'";
                                    }
                                    else
                                    {
                                        querry += "or " + "[LibraryName] LIKE '%" + output.ToString() + "%'";
                                    }

                                    break;
                                }
                            default:
                                {
                                    continue;
                                }
                        }

                    }

                }
                if (check <= 0)
                {
                    msgbox.Visible = true;
                    msgTitleLabel.Text = "Validation!!!";
                    msgDetailLabel.Text = "Please Select Any CheckBox";
                }
                else
                {


                    DataTable dt = new DataTable();
                    Session["Querry"] = querry.ToString();
                    dt = bookBll.SearchForBook(querry);
                    if (dt.Rows.Count > 0)
                    {
                        infoBody.Visible = false;
                        bookListGridView.DataSource = dt;
                        bookListGridView.DataBind();
                        GridViewStyle();
                        GetSearchedBookList(dt);
                    }
                    else
                    {
                        string message = "Book Not <span class='actionTopic'> Found</span>.";
                        MyAlertBox("SuccessAlert(\"" + "Process Succeed" + "\", \"" + message + "\", \"\");");
                    }


                }
            }

            catch (Exception)
            {

                //throw;
            }
        }
      
        private void GridViewStyle()
        {
            if (bookListGridView.Rows.Count > 0)
            {
                bookListGridView.UseAccessibleHeader = true;
                bookListGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        private void GetSearchedBookList(DataTable dt)
        {
            try
            {
                lblNo.Text = dt.Rows[0]["BookId"].ToString();
                lblKitaberSerialNo.Text = dt.Rows[0]["BookSerial"].ToString();
                lblAlmariNo.Text = dt.Rows[0]["AlmariNo"].ToString();
                lblTakNo.Text = dt.Rows[0]["takno"].ToString();
                lblKitabNo.Text = dt.Rows[0]["KitabNo"].ToString();
                lblKolamNo.Text = dt.Rows[0]["KolamNo"].ToString();
                lblCopyNumber.Text = dt.Rows[0]["CopyNo"].ToString();
                lblTotalVolume.Text = dt.Rows[0]["TotalVolium"].ToString();
                lblVolumeNo.Text = dt.Rows[0]["Volium"].ToString();
                lblKhondoNo.Text = dt.Rows[0]["PartNo"].ToString();
                lblPageNo.Text = dt.Rows[0]["PageNo"].ToString();
                lblPrice.Text = dt.Rows[0]["Price"].ToString();
                lblKitaberMainName.Text = dt.Rows[0]["BookName"].ToString();
                lblKitaberSpecialName.Text = dt.Rows[0]["BookKnownName"].ToString();
                lblWritter.Text = dt.Rows[0]["WriterName"].ToString();
                lblWritterBornDate.Text = dt.Rows[0]["WriterDOB"].ToString();
                lblWritterDeathDate.Text = dt.Rows[0]["WriterDD"].ToString();
                lblWritterMajhab.Text = dt.Rows[0]["WriterMazhab"].ToString();
                lblSongkolp.Text = dt.Rows[0]["Songkolok"].ToString();
                lblTranslator.Text = dt.Rows[0]["Onubadok"].ToString();
                lblTranslatorsDate.Text = dt.Rows[0]["OnubadokDOB_DD"].ToString();
                lblTranslatorMajhab.Text = dt.Rows[0]["OnubadokMazvab"].ToString();
                lblMainLanguage.Text = dt.Rows[0]["BookLanguage"].ToString();
                lblTranslatedLanguage.Text = dt.Rows[0]["TranslateLanguage"].ToString();
                lblSubject.Text = dt.Rows[0]["Bishoy"].ToString();
                lblChapter.Text = dt.Rows[0]["Chapter"].ToString();
                lblProkashok.Text = dt.Rows[0]["Publisher"].ToString();
                lblProkashkal.Text = dt.Rows[0]["PublishDate"].ToString();
                lblProkashoni.Text = dt.Rows[0]["Publication"].ToString();
                lblProkashsthan.Text = dt.Rows[0]["PublicationPlace"].ToString();
                //lblp.Text = dt.Rows[0]["PublishYear"].ToString();
                lblSompadona.Text = dt.Rows[0]["Editor"].ToString();
                lblSongokoron.Text = dt.Rows[0]["Edition"].ToString();
                lblSarSonkhep.Text = dt.Rows[0]["suchi"].ToString();
                lblComment.Text = dt.Rows[0]["Remarks"].ToString();
                // txtbxContactMobile.Text = dt.Rows[0]["BookId"].ToString();
                //txtContactEmail.Text = dt.Rows[0]["Songkolok"].ToString();

                //if (dt.Rows.Count > 0)
                //{
                //    bookListGridView.DataSource = dt;
                //    bookListGridView.DataBind();
                //}
                //GridViewStyle();
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
        protected void EditLinkButton_OnClick(object sender, EventArgs e)
        {
            try
            {
                BookBLL bookBll = new BookBLL();
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;

                string BookId = bookListGridView.Rows[row.RowIndex].Cells[0].Text.ToString();
                LumexSessionManager.Add("BookIdForUpdate", BookId);
                Response.Redirect("Update.aspx");

            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
        protected void viewLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                LinkButton lnkBtn = (LinkButton)sender;
                GridViewRow row = (GridViewRow)lnkBtn.NamingContainer;
                string BookId = bookListGridView.Rows[row.RowIndex].Cells[0].Text.ToString();
                //Label lblUserId = (Label)userListGridView.Rows[row.RowIndex].Cells[0].FindControl("lblUserId");
                LumexSessionManager.Add("BookIdForView", BookId);
                Response.Redirect("View.aspx");

            }
            catch (Exception ex)
            {
                msgbox.Attributes.Add("Class", "alert alert-warning"); msgbox.Visible = true; msgTitleLabel.Text = "Exception!!!"; msgDetailLabel.Text = ex.Message;
            }
        }
    }
}