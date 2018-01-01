using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using CL.Persistance;
using GeneralManagement.Common;
using GeneralManagement.Bus;

namespace GeneralManagement.Supervisors
{
    public partial class frmInputKey : MetroForm
    {
        private int divisionShiftID;
        public delegate void SendWorking(bool isprogress);
        SendWorking s;
        public delegate void SendIsCrypt(bool IsDecrypt);
        public event SendIsCrypt Sender;
        public frmInputKey()
        {
            InitializeComponent();
        }
        public frmInputKey(int _divisionShiftID)
        {
            InitializeComponent();
            this.divisionShiftID = _divisionShiftID;
        }
        private void frmInputKey_Load(object sender, EventArgs e)
        {

        }

        private void mtxtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                MTAQuizEntities Db = new MTAQuizEntities();
                //DTO.frmLoading = new frmLoading();
                //s = new SendWorking(DTO.frmLoading.HandelWorlking);
                En_Decrypt _decrypt;
                string key = Db.DIVISION_SHIFTS.Where(x => x.DivisionShiftID == divisionShiftID).SingleOrDefault().Key;
                if (key == mtxtKey.Text)
                {
                    set();
                    
                    _decrypt = new En_Decrypt(key);
                    List<QUESTIONS_TEMP> lsTempQuestion = new List<QUESTIONS_TEMP>();
                    lsTempQuestion = Db.QUESTIONS_TEMP.Where(x => x.DivisionShiftID == divisionShiftID).ToList();
                    //DTO.frmLoading.totalProgress = lsTempQuestion.Count;
                    //DTO.frmLoading.Owner = this;
                    //DTO.frmLoading.Show();
                    //DTO.frmLoading.FormClosed += frmclose;
                    int count = 0;
                    foreach (var item in lsTempQuestion)
                    {
                        QUESTION Question = new QUESTION();
                        Question = Db.QUESTIONS.Where(x => x.QuestionID == item.QuestionID).SingleOrDefault();
                        Question.QuestionContent = _decrypt.Encrypt(item.QuestionContent);
                        List<SUBQUESTION> lsSubQuestion = new List<SUBQUESTION>();
                        lsSubQuestion = Question.SUBQUESTIONS.ToList();

                        try
                        {
                            Db.SaveChanges();
                            int countlsSub = 0;
                            foreach (var sub in lsSubQuestion)
                            {
                                string s = Db.SUBQUESTIONS_TEMP.Where(x => x.SubQuestionID == sub.SubQuestionID && x.DivisionShiftID == divisionShiftID).FirstOrDefault().SubQuestionContent;
                                sub.SubQuestionContent = _decrypt.Encrypt(s);
                                Db.SaveChanges();
                                countlsSub++;
                            }
                            if (countlsSub == lsSubQuestion.Count && lsSubQuestion.Count>0 )
                            {
                                
                                count++;

                            }

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Thông báo", "Giải mã không thành công!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        //s(true);
                        progressBar1.Value = count * 100 / lsTempQuestion.Count;
                        lbProgress.Text = progressBar1.Value.ToString()+"%";
                        lbProgress.Update();
                    }
                    if (count == lsTempQuestion.Count)
                    {
                        btnOK.Enabled = true;
                        lbstatus.Text = "Hoàn thành giải mã đề thi!";
                        lbstatus.ForeColor = Color.DarkGreen;
                        Sender(true);
                        BusALL.Instance.UpdateStatusDivisionShift(divisionShiftID, UserHelper.Common.STATUS_DECRYPT);
                        MessageBox.Show("Giải mã đề thi thành công!");
                    }
                }
                else
                {
                    MessageBox.Show("Nhập mã sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        void set()
        {
            this.Height = 253;
            mtxtKey.Enabled = false;
            lbstatus.Text = "Đang giải mã đề..";
            lbstatus.Update();
            this.Update();
            
        }
        //void frmclose(object sender, EventArgs e)
        //{

        //    this.Close();
        //}

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    
}

