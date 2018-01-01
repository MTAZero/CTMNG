using EXON.Common;
using EXON.Data.Services;
using EXON.Model.Models;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace EXON.Main.Module.Controls
{
    public partial class ucTask : BaseModule
    {
        private StaffService _StaffService;
        private StaffPositionService _StaffPositionService;
        private TopicStaffService _TopicStaffService;
        private TopicService _TopicService;
        private SubjectService _SubjectService;

        public override string ModuleName { get { return Properties.Resources.QuestionName; } }

        private bool IsUpdate = true;

        private STAFF CurrentStaff
        {
            get
            {
                return _StaffService.GetById(CurrentStaffId);
            }
        }

        private int CurrentAssigmentStaffId
        {
            get
            {
                try
                {
                    if (cbNguoiNhan.SelectedValue == null) return -1;
                    return int.Parse(cbNguoiNhan.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentTopicStaffId
        {
            get
            {
                try
                {
                    if (gcTopicStaff.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcTopicStaff.Rows[gcTopicStaff.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["TopicStaffID"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentTopicId
        {
            get
            {
                try
                {
                    if (cbTopic.SelectedValue == null) return -1;
                    return int.Parse(cbTopic.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }

        private int CurrentSubjectId
        {
            get
            {
                try
                {
                    if (cbSubject.SelectedValue == null) return -1;
                    return int.Parse(cbSubject.SelectedValue.ToString());
                }
                catch { return -1; }
            }
        }

        public ucTask()
        {
            InitializeComponent();
            InitializeServices();

            gcTopicStaff.AutoGenerateColumns = false;
        }

        private void InitializeServices()
        {
            _StaffService = new StaffService();
            _StaffPositionService = new StaffPositionService();
            _TopicStaffService = new TopicStaffService();
            _TopicService = new TopicService();
            _SubjectService = new SubjectService();
        }

        internal override void InitModule()
        {
            base.InitModule();
            if (CurrentStaff != null)
            {
                cbNguoiNhan.DataSource = (from s in _StaffService.GetAllDeparment(CurrentStaff.DepartmentID)
                                          where _StaffPositionService.GetMaxPosition(s.StaffID) > _StaffPositionService.GetMaxPosition(CurrentStaffId)
                                          select new
                                          {
                                              FullName = s.FullName,
                                              StaffID = s.StaffID
                                          }).ToList();
                cbNguoiNhan.ValueMember = "StaffID";
                cbNguoiNhan.DisplayMember = "FullName";

                GetData4GcTopicStaff();

                cbSubject.DataSource = _SubjectService.GetAllByDepartment(CurrentStaff.DepartmentID).ToList();
                cbSubject.ValueMember = "SubjectID";
                cbSubject.DisplayMember = "SubjectName";
            }
        }

        private void GetData4GcTopicStaff()
        {
            gcTopicStaff.DataSource = (from ts in _TopicStaffService.GetAll(CurrentStaffId)
                                       select new
                                       {
                                           TopicStaffID = ts.TopicStaffID,
                                           BeginDate = DateTimeHelpers.ConvertUnixToDateTime(ts.BeginDate),
                                           EndDate = DateTimeHelpers.ConvertUnixToDateTime(ts.EndDate),
                                           Description = ts.Description,
                                           TopicID = ts.TopicID,
                                           TopicName = _TopicService.GetById(ts.TopicID).TopicName,
                                           AssignedStaffID = ts.AssignedStaffID,
                                           AssignedStaffName = _StaffService.GetById(ts.AssignedStaffID).FullName,
                                           Status = GetStatusTask(ts.Status)
                                       }).ToList();
        }

        private string GetStatusTask(int status)
        {
            switch ((TaskStatusEnum)(status))
            {
                case TaskStatusEnum.Complete:
                    return Properties.Resources.Complete;

                case TaskStatusEnum.During:
                    return Properties.Resources.During;

                case TaskStatusEnum.New:
                    return Properties.Resources.New;

                case TaskStatusEnum.Over:
                    return Properties.Resources.Over;

                default:
                    return Properties.Resources.New;
            }
        }

        private void gcTopicStaff_SelectionChanged(object sender, System.EventArgs e)
        {
            if (CurrentTopicStaffId <= 0) return;
            TOPICS_STAFFS topicStaff = _TopicStaffService.GetById(CurrentTopicStaffId);

            if (topicStaff == null) return;
            else btnUpdate.Enabled = true;

            if (topicStaff.Status == (int)TaskStatusEnum.Complete) btnUpdate.Enabled = false;
            else
            {
                btnUpdate.Enabled = true;
                cbNguoiNhan.SelectedValue = topicStaff.AssignedStaffID;
                txtMoTa.Text = topicStaff.Description;
                deStartDate.Value = DateTimeHelpers.ConvertUnixToDateTime(topicStaff.BeginDate);
                deEndDate.Value = DateTimeHelpers.ConvertUnixToDateTime(topicStaff.EndDate);
            }
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            if (CheckToSave())
            {
                if (CurrentTopicStaffId < 0)
                    IsUpdate = false;

                try
                {
                    if (!IsUpdate)
                    {
                        TOPICS_STAFFS topicStaff = new TOPICS_STAFFS()
                        {
                            AssignedStaffID = CurrentAssigmentStaffId,
                            TaskmasterStaffID = CurrentStaffId,
                            BeginDate = DateTimeHelpers.ConvertDateTimeToUnix(deStartDate.Value),
                            EndDate = DateTimeHelpers.ConvertDateTimeToUnix(deEndDate.Value),
                            Description = txtMoTa.Text,
                            TopicID = CurrentTopicId,
                            Status = (int)TaskStatusEnum.New
                        };
                        _TopicStaffService.Add(topicStaff);

                        btnDelete.Enabled = true;
                        btnUpdate.Text = Properties.Resources.Update;
                    }
                    else
                    {
                        TOPICS_STAFFS topicStaff = _TopicStaffService.GetById(CurrentTopicStaffId);
                        topicStaff.AssignedStaffID = CurrentAssigmentStaffId;
                        topicStaff.TaskmasterStaffID = CurrentStaffId;
                        topicStaff.BeginDate = DateTimeHelpers.ConvertDateTimeToUnix(deStartDate.Value);
                        topicStaff.EndDate = DateTimeHelpers.ConvertDateTimeToUnix(deEndDate.Value);
                        topicStaff.Description = txtMoTa.Text;
                        topicStaff.TopicID = CurrentTopicId;
                        topicStaff.Status = (int)TaskStatusEnum.New;

                        _TopicStaffService.Update(topicStaff);
                    }
                    _TopicStaffService.Save();

                    ClearData();
                    GetData4GcTopicStaff();
                    btnUpdate.Enabled = false;

                    MessageBox.Show(Properties.Resources.Success, Properties.Resources.Insert);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Properties.Resources.Error);
                    return;
                }
            }
        }

        private bool CheckToSave()
        {
            if (CurrentAssigmentStaffId <= 0)
            {
                MessageBox.Show(Properties.Resources.NotSelectStaff, Properties.Resources.WarningDialog);
                return false;
            }
            if (CurrentTopicId <= 0)
            {
                MessageBox.Show(Properties.Resources.NotSelectStaffMessage, Properties.Resources.WarningDialog);
                return false;
            }
            if (deStartDate.Value < SystemTimeService.Now)
            {
                MessageBox.Show(Properties.Resources.SmallDateMessage, Properties.Resources.WarningDialog);
                return false;
            }
            if (deStartDate.Value > deEndDate.Value)
            {
                MessageBox.Show(Properties.Resources.SmallDateStartMessage, Properties.Resources.WarningDialog);
                return false;
            }
            return true;
        }

        private void cbSubject_SelectedValueChanged(object sender, EventArgs e)
        {
            cbTopic.DataSource = null;

            cbTopic.DataSource = _TopicService.GetAll(CurrentSubjectId).ToList();
            cbTopic.ValueMember = "TopicID";
            cbTopic.DisplayMember = "TopicName";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearData();
            btnDelete.Enabled = false;
            btnUpdate.Text = Properties.Resources.Insert;
            btnUpdate.Enabled = true;
        }

        private void ClearData()
        {
            IsUpdate = false;

            txtMoTa.Text = string.Empty;
            deEndDate.Value = SystemTimeService.Now;
            deStartDate.Value = SystemTimeService.Now;
        }

        private void gcTopicStaff_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (gcTopicStaff.DataSource == null) return;
            string temp = gcTopicStaff.Rows[e.RowIndex].Cells["Status"].Value.ToString();

            if (temp == Properties.Resources.Complete)
            {
                gcTopicStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
            }
            if (temp == Properties.Resources.Over)
            {
                gcTopicStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            }
            if (temp == Properties.Resources.During)
            {
                gcTopicStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
            if (temp == Properties.Resources.New)
            {
                gcTopicStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(Properties.Resources.YesNoMessage,
                Properties.Resources.WarningDialog,
                MessageBoxButtons.YesNo))
            {
                _TopicStaffService.Delete(CurrentTopicStaffId);
                _TopicStaffService.Save();
                GetData4GcTopicStaff();
            }
        }
    }
}