using EXON.Data.Services;
using EXON.Model.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EXON.Main.Module.Controls
{
    public partial class ucTopic : BaseModule
    {
        private SubjectService _SubjectService;
        private StaffService _StaffService;
        private TopicService _TopicService;

        private bool IsUpdate = true;

        private int CurrentDepartment
        {
            get
            {
                return _StaffService.GetById(CurrentStaffId).DepartmentID;
            }
        }

        private int CurrentSubjectId
        {
            get
            {
                try
                {
                    if (gcSubject.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcSubject.Rows[gcSubject.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["SubjectID"].Value.ToString());
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
                    if (gcTopic.CurrentCell.RowIndex < 0) return -1;
                    DataGridViewRow data = gcTopic.Rows[gcTopic.CurrentCell.RowIndex];
                    return int.Parse(data.Cells["TopicID"].Value.ToString());
                }
                catch { return -1; }
            }
        }

        public ucTopic()
        {
            _SubjectService = new SubjectService();
            _StaffService = new StaffService();
            _TopicService = new TopicService();
            InitializeComponent();
        }

        internal override void InitModule()
        {
            gcSubject.AutoGenerateColumns = false;
            gcTopic.AutoGenerateColumns = false;

            gcSubject.DataSource = _SubjectService
                .GetAllByDepartment(CurrentDepartment)
                .ToList();
        }

        private void GetData4GcTopic()
        {
            try
            {
                var data = _TopicService.GetAll(CurrentSubjectId).ToList();
                gcTopic.DataSource = data;

                if (data.Count == 0)
                {
                    IsUpdate = false;
                    txtDescription.Text = string.Empty;
                    txtName.Text = string.Empty;
                    btnUpdate.Enabled = true;
                }
            }
            catch
            {
                gcTopic.DataSource = null;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                if (!IsUpdate)
                {
                    TOPIC newTopic = new TOPIC()
                    {
                        TopicName = txtName.Text,
                        Description = txtDescription.Text,
                        Status = 1,
                        SubjectID = CurrentSubjectId
                    };
                    _TopicService.Add(newTopic);
                }
                else
                {
                    TOPIC topic = _TopicService.GetById(CurrentTopicId);
                    topic.TopicName = txtName.Text;
                    topic.Description = txtDescription.Text;
                    _TopicService.Update(topic);
                }
                _TopicService.Save();
                btnUpdate.Enabled = false;
                GetData4GcTopic();
            }
            else MessageBox.Show(Properties.Resources.NotInputMessage, Properties.Resources.WarningDialog);
        }

        private void gcSubject_SelectionChanged(object sender, EventArgs e)
        {
            GetData4GcTopic();
            btnDelete.Enabled = CurrentTopicId > 0;
        }

        private void gcTopic_SelectionChanged(object sender, EventArgs e)
        {
            SUBJECT currentSubject = _SubjectService.GetById(CurrentSubjectId);
            lbSubject.Text = Properties.Resources.Subject + "  " + currentSubject.SubjectName;

            TOPIC topic = _TopicService.GetById(CurrentTopicId);
            btnDelete.Enabled = topic != null;
            if (topic == null) return;

            txtName.Text = topic.TopicName;
            txtDescription.Text = topic.Description;

            IsUpdate = topic != null;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            IsUpdate = false;
            txtDescription.Text = string.Empty;
            txtName.Text = string.Empty;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show(Properties.Resources.YesNoMessage,
                Properties.Resources.WarningDialog,
                MessageBoxButtons.OK))
            {
                _TopicService.Delete(CurrentTopicId);
                _TopicService.Save();
            }
        }
    }
}