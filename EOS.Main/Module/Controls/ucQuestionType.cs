using EXON.Data.Services;
using EXON.Model.Models;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace EXON.Main.Module.Controls
{
    public partial class ucQuestionType : BaseModule
    {
        private QuestionTypeService _QuestionTypeService;
        public override string ModuleName { get { return Properties.Resources.TypeQuestionName; } }

        private QUESTION_TYPES CurrenQuestionType
        {
            get
            {
                if (gcMain.CurrentCell.RowIndex < 0) return null;
                DataGridViewRow data = gcMain.Rows[gcMain.CurrentCell.RowIndex];
                try
                {
                    return new QUESTION_TYPES()
                    {
                        QuestionTypeID = int.Parse(data.Cells["colQuestionTypeID"].Value.ToString()),
                        Description = data.Cells["colDescription"].Value.ToString(),
                        QuestionTypeName = data.Cells["colQuestionTypeName"].Value.ToString(),
                        IsParagraph = bool.Parse(data.Cells["colIsParagraph"].Value.ToString()),
                        IsQuestionContent = bool.Parse(data.Cells["colIsQuestionContent"].Value.ToString()),
                        IsQuiz = bool.Parse(data.Cells["colIsQuiz"].Value.ToString()),
                        IsSingleChoice = bool.Parse(data.Cells["colIsSingleChoice"].Value.ToString()),
                        NumberAnswer = int.Parse(data.Cells["colNumberAnswer"].Value.ToString()),
                        NumberSubQuestion = int.Parse(data.Cells["colNumberSubQuestion"].Value.ToString())
                    };
                }
                catch (Exception ex) { return null; }
            }
        }

        private QUESTION_TYPES bindingQuestionType;

        public ucQuestionType()
        {
            InitializeComponent();
            _QuestionTypeService = new QuestionTypeService();
            bindingQuestionType = new QUESTION_TYPES()
            {
                QuestionTypeID = 0,
                Description = string.Empty,
                QuestionTypeName = string.Empty,
                IsQuiz = true,
                IsParagraph = false,
                IsQuestionContent = false,
                IsSingleChoice = true,
                NumberAnswer = 4,
                NumberSubQuestion = 1,
                Status = 1
            };
            BindingData();
        }

        private void BindingData()
        {
            txtName.DataBindings.Clear();
            txtDescription.DataBindings.Clear();
            icbIsQuiz.DataBindings.Clear();
            ceSingleChoice.DataBindings.Clear();
            ceParagraph.DataBindings.Clear();
            ceQuestionContent.DataBindings.Clear();
            seNumberSubQuestion.DataBindings.Clear();
            seNumberAnswer.DataBindings.Clear();

            txtName.DataBindings.Add("Text", bindingQuestionType, "QuestionTypeName");
            txtDescription.DataBindings.Add("Text", bindingQuestionType, "Description");
            icbIsQuiz.DataBindings.Add("Checked", bindingQuestionType, "IsQuiz");
            ceSingleChoice.DataBindings.Add("Checked", bindingQuestionType, "IsSingleChoice");
            ceParagraph.DataBindings.Add("Checked", bindingQuestionType, "IsParagraph");
            ceQuestionContent.DataBindings.Add("Checked", bindingQuestionType, "IsQuestionContent");
            seNumberSubQuestion.DataBindings.Add("Value", bindingQuestionType, "NumberSubQuestion");
            seNumberAnswer.DataBindings.Add("Value", bindingQuestionType, "NumberAnswer");
        }

        internal override void InitModule()
        {
            base.InitModule();
            this.gcMain.AutoGenerateColumns = false;
            EnabledFlagButtons(false, false);
            ShowData();
        }

        private void ShowData()
        {
            gcMain.DataSource = GetQuestionTypeData();
            UpdateCurrentTask();
        }

        private object GetQuestionTypeData()
        {
            IEnumerable ret = _QuestionTypeService.GetAll();
            return ret.Cast<QUESTION_TYPES>().ToList();
        }

        private void UpdateCurrentTask()
        {
            bool enableDelete = gcMain.SelectedRows.Count != 0;
            if (!enableDelete) return;
            if (CurrenQuestionType != null)
            {
                bindingQuestionType = CurrenQuestionType;
                BindingData();

                btnSave.Text = Properties.Resources.Update;
                EnabledFlagButtons(true, enableDelete);
            }
            else
            {
                EnabledFlagButtons(true, enableDelete);
                bindingQuestionType = new QUESTION_TYPES()
                {
                    QuestionTypeID = 0,
                    Description = string.Empty,
                    QuestionTypeName = string.Empty,
                    IsQuiz = true,
                    IsParagraph = false,
                    IsQuestionContent = false,
                    IsSingleChoice = true,
                    NumberAnswer = 4,
                    NumberSubQuestion = 1,
                    Status = 1
                };
                BindingData();
                btnSave.Text = Properties.Resources.Insert;
            }
        }

        internal void EnabledFlagButtons(bool enabledEdit, bool enabledDelete)
        {
            btnSave.Enabled = enabledEdit;
            btnDelete.Enabled = enabledDelete;
        }

        private void RemoveCurrentTask()
        {
            if (CurrenQuestionType == null)
            {
                MessageBox.Show(Properties.Resources.NotSelectQuestionTypeMessage, Properties.Resources.WarningDialog);
                return;
            }
            _QuestionTypeService.Delete(CurrenQuestionType.QuestionTypeID);
            _QuestionTypeService.Save();
            ShowData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(Properties.Resources.YesNoMessage,
                Properties.Resources.WarningDialog,
                MessageBoxButtons.YesNo))
            {
                RemoveCurrentTask();
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            btnSave.Text = Properties.Resources.Insert;
            bindingQuestionType = new QUESTION_TYPES();
            BindingData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (bindingQuestionType.QuestionTypeID > 0)
                {
                    QUESTION_TYPES temp = _QuestionTypeService.GetById(bindingQuestionType.QuestionTypeID);
                    temp.QuestionTypeName = bindingQuestionType.QuestionTypeName;
                    temp.Description = bindingQuestionType.Description;
                    temp.IsParagraph = bindingQuestionType.IsParagraph;
                    temp.IsQuestionContent = bindingQuestionType.IsQuestionContent;
                    temp.IsQuiz = bindingQuestionType.IsQuiz;
                    temp.IsSingleChoice = bindingQuestionType.IsSingleChoice;
                    temp.NumberAnswer = bindingQuestionType.NumberAnswer;
                    temp.NumberSubQuestion = bindingQuestionType.NumberSubQuestion;

                    _QuestionTypeService.Update(temp);
                }
                else _QuestionTypeService.Add(bindingQuestionType);
                _QuestionTypeService.Save();

                MessageBox.Show(Properties.Resources.Success, Properties.Resources.Notification);
                ShowData();
            }
            catch (Exception ex)
            {
#if DEBUG
                MessageBox.Show(ex.Message, Properties.Resources.Error);
#endif
            }
        }

        internal void EnabledCheckBox(bool enabledEdit)
        {
            ceParagraph.Enabled = enabledEdit;
            ceQuestionContent.Enabled = enabledEdit;
            ceSingleChoice.Enabled = enabledEdit;
        }

        private void icbIsQuiz_CheckedChanged(object sender, EventArgs e)
        {
            if (icbIsQuiz.Checked)
                EnabledCheckBox(true);
            else EnabledCheckBox(false);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
                btnSave.Enabled = false;
            else btnSave.Enabled = true;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()) || txtName.Text.Length > 45)
                e.Cancel = true;
        }

        private void gcMain_SelectionChanged(object sender, EventArgs e)
        {
            UpdateCurrentTask();
        }

        private void btnCreateTemplate_Click(object sender, EventArgs e)
        {

        }
    }
}