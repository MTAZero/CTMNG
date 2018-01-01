using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using DW.RtfWriter;
using EXON.Common;
using EXON.Data.Services;
using EXON.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXON.Main.Core.DocumentProcess
{
    public static class DocumentHelper
    {
        private static QuestionTypeService _QuestionTypeService=new QuestionTypeService();
        public static List<QUESTION> GetQuestionFromDoc(string path, int QuestionTypeID)
        {
            QUESTION_TYPES currentQuestionType = _QuestionTypeService.GetById(QuestionTypeID);
            if (!currentQuestionType.IsQuiz) return new List<QUESTION>();

            WordprocessingDocument doc = WordprocessingDocument.Open(path, false);

            string body_table = "DocumentFormat.OpenXml.Wordprocessing.Table";
            string body_paragraph = "DocumentFormat.OpenXml.Wordprocessing.Paragraph";
            string table_row = "DocumentFormat.OpenXml.Wordprocessing.TableRow";
            string table_cell = "DocumentFormat.OpenXml.Wordprocessing.TableCell";
            string run = "DocumentFormat.OpenXml.Wordprocessing.Run";
            string run_properties = "DocumentFormat.OpenXml.Wordprocessing.RunProperties";
            string text = "DocumentFormat.OpenXml.Wordprocessing.Text";
            string bold = "DocumentFormat.OpenXml.Wordprocessing.Bold";
            string italic = "DocumentFormat.OpenXml.Wordprocessing.Italic";
            string underline = "DocumentFormat.OpenXml.Wordprocessing.Underline";


            Body body = doc.MainDocumentPart.Document.Body;
            QUESTION question = new QUESTION()
            {
                QuestionTypeID = currentQuestionType.QuestionTypeID,
                CreatedDate = DateTimeHelpers.ConvertDateTimeToUnix(SystemTimeService.Now),
                Level = 1,
                QuestionFormat = (int)QuestionFormat.RTF,
                
            };
            List<SUBQUESTION> listSubQuestion = new List<SUBQUESTION>();
            
            foreach (var b in body)
            {
                string body_type = b.ToString();

                #region get paragrap
                if (currentQuestionType.IsParagraph && !currentQuestionType.IsQuestionContent)
                {
                                       
                    if (body_type == body_paragraph)
                    {
                        foreach (var r in b)
                        {
                            if (r.ToString() == run)
                            {
                                string paragraph_properties = string.Empty;
                                string paragraph_content = string.Empty;
                                foreach (var rv in r)
                                {
                                    if (rv.ToString() == run_properties)
                                    {
                                        foreach (var tp in rv)
                                        {
                                            paragraph_properties += tp.ToString() + '\n';
                                        }
                                    }
                                    if (rv.ToString() == text)
                                    {
                                        paragraph_content += rv.InnerText + '\n';
                                    }
                                }

                                if (paragraph_content.Trim() == string.Empty)
                                    continue;

                                var rtfDoc = new RtfDocument(PaperSize.A4, PaperOrientation.Portrait, Lcid.TraditionalChinese);
                                var times = rtfDoc.createFont("Times New Roman");

                                RtfParagraph par = rtfDoc.addParagraph(); ;
                                par.DefaultCharFormat.Font = times;
                                par.setText(paragraph_content);

                                RtfCharFormat fmt = par.addCharFormat(0, paragraph_content.Length - 1);
                                fmt.FontSize = 18;
                                if (paragraph_properties.Contains(bold)) fmt.FontStyle.addStyle(FontStyleFlag.Bold);
                                fmt.Font = times;

                                question.QuestionContent = rtfDoc.render();
                            }
                        }
                    }                  
                }
                #endregion

                if (body_type == body_table)
                {
                    foreach (var tr in b)
                    {
                        if (tr.ToString() == table_row)
                        {
                            foreach (var tc in tr)
                            {
                                if (tc.ToString() == table_cell)
                                {
                                    foreach (var p in tc)
                                    {
                                        if (p.InnerText.Count() <= 2) continue;

                                        SUBQUESTION subquestion = new SUBQUESTION();
                                        subquestion.QuestionID = question.QuestionID;

                                        if (p.ToString() == body_paragraph)
                                        {
                                            var rtfDoc = new RtfDocument(PaperSize.A4, PaperOrientation.Portrait, Lcid.TraditionalChinese);
                                            var times = rtfDoc.createFont("Times New Roman");
                                            RtfParagraph par = rtfDoc.addParagraph(); ;
                                            par.DefaultCharFormat.Font = times;
                                            par.setText(p.InnerText);

                                            int start = 0;
                                            int end = 0;
                                            foreach (var r in p)
                                            {
                                                if (r.ToString() == run)
                                                {
                                                    string runProperties = string.Empty;
                                                    string runContext = string.Empty;
                                                    foreach (var rv in r)
                                                    {
                                                        if (rv.ToString() == run_properties)
                                                        {
                                                            foreach (var tp in rv)
                                                            {
                                                                runProperties += tp.ToString() + '\n';
                                                            }
                                                        }
                                                        if (rv.ToString() == text)
                                                        {
                                                            runContext = rv.InnerText;
                                                            if (end != 0) start = end;
                                                            end += runContext.Length;
                                                        }
                                                    }
                                                    if (runContext.Trim() == string.Empty)
                                                        continue;

                                                    RtfCharFormat fmt = par.addCharFormat(start, end - 1);
                                                    fmt.FontSize = 18;
                                                    if (runProperties.Contains(bold)) fmt.FontStyle.addStyle(FontStyleFlag.Bold);
                                                    if (runProperties.Contains(italic)) fmt.FontStyle.addStyle(FontStyleFlag.Italic);
                                                    if (runProperties.Contains(underline)) fmt.FontStyle.addStyle(FontStyleFlag.Underline);
                                                    fmt.Font = times;
                                                   
                                                }
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            doc.Close();

            return new List<QUESTION>();
        }
    }
}
