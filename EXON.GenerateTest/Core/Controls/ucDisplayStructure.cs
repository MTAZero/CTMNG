using EXON.Data.Services;
using EXON.Model.Models;
using MetroFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tung.Log;

namespace EXON.GenerateTest.Core.Controls
{
    public partial class ucDisplayStructure : UserControl
    {
        private STRUCTURE currentStructure;
        private TOPIC currentTopic;
        private List<NumericUpDown> listNumScore;
        private List<NumericUpDown> listNumQuestion;

        private StructureDetailService _StructureDetailService;
        public int TotalNumQuestion { get; private set; }
        public double TotalScore { get; private set; }
        public int StructureId { get; private set; }
        public int TopicId { get; private set; }

        private Color defaultColor;

        public delegate void UpdateEventHandle();
        public event UpdateEventHandle UpdateStatus;

        public ucDisplayStructure(STRUCTURE structureTest, TOPIC topic)
        {
            InitializeComponent();
            this.currentStructure = structureTest;
            this.currentTopic = topic;
            this.StructureId = structureTest.StructureID;
            this.TopicId = topic.TopicID;
            defaultColor = this.BackColor;

            _StructureDetailService = new StructureDetailService();
            listNumQuestion = new List<NumericUpDown>() { numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4 };
            listNumScore = new List<NumericUpDown>() { numericUpDown5, numericUpDown6, numericUpDown7, numericUpDown8 };

            InitControls();
            InitEvent();

            this.Dock = DockStyle.Top;
            this.AutoSize = true;
            this.DoubleBuffered = true;
        }

        private void InitEvent()
        {
            foreach (NumericUpDown n in listNumScore)
                n.ValueChanged += NumericValueChanged;
            foreach (NumericUpDown n in listNumQuestion)
                n.ValueChanged += NumericValueChanged;
        }

        private void InitControls()
        {
            TotalNumQuestion = 0;
            TotalScore = 0;

            _StructureDetailService = new StructureDetailService();
            List<STRUCTURE_DETAILS> listStructureDetail = _StructureDetailService
                .GetAll(currentStructure.StructureID, currentTopic.TopicID)
                .ToList();

            lbTopicName.Text = currentTopic.TopicName;
            lbLv1.Text = Properties.Resources.Level1;
            lbLv2.Text = Properties.Resources.Level2;
            lbLv3.Text = Properties.Resources.Level3;
            lbLv4.Text = Properties.Resources.Level4;

            for (int i = 0; i < listNumQuestion.Count; i++)
            {
                if (i < listStructureDetail.Count)
                {
                    TotalNumQuestion += listStructureDetail[i].NumberQuestions;
                    TotalScore += listStructureDetail[i].Score * listStructureDetail[i].NumberQuestions;

                    listNumQuestion[i].Value = listStructureDetail[i].NumberQuestions;
                    listNumScore[i].Value = (decimal)listStructureDetail[i].Score > 0 ? (decimal)listStructureDetail[i].Score : 1;
                }
                else
                {
                    listNumQuestion[i].Value = 0;
                    listNumScore[i].Value = 0.00M;
                }
            }

            lbNoQ.Text = TotalNumQuestion.ToString();
            lbNoS.Text = TotalScore.ToString("00.00");
            if (CheckHasValue()) EnableEdit(true);
            else EnableEdit(false);
        }

        private void NumericValueChanged(object sender, EventArgs e)
        {
            TotalScore = 0;
            TotalNumQuestion = 0;

            for (int i = 0; i < listNumQuestion.Count; i++)
                TotalNumQuestion += (int)listNumQuestion[i].Value;
            for (int i = 0; i < listNumScore.Count; i++)
                TotalScore += (double)(listNumScore[i].Value * listNumQuestion[i].Value);

            lbNoQ.Text = TotalNumQuestion.ToString();
            lbNoS.Text = TotalScore.ToString("00.00");
        }

        public void Refesh()
        {
            InitControls();
        }

        public bool CheckCorrectStructureDetail(int structureId, int topicId)
        {
            return (StructureId == structureId) && (TopicId == topicId);
        }

        private bool CheckHasValue()
        {
            foreach (NumericUpDown n in listNumQuestion)
            {
                if (n.Value != 0)
                    return true;
            }
            return false;
        }

        internal void ChangeColor(bool v)
        {
            if (v) this.BackColor = Color.Yellow;
            else this.BackColor = defaultColor;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<STRUCTURE_DETAILS> listStructureDetail = _StructureDetailService
               .GetAll(currentStructure.StructureID, currentTopic.TopicID)
               .ToList();
            try
            {
                for (int i = 0; i < listNumQuestion.Count; i++)
                {
                    if (i < listStructureDetail.Count)
                    {
                        listStructureDetail[i].NumberQuestions = (int)listNumQuestion[i].Value;
                        listStructureDetail[i].Score = (double)listNumScore[i].Value;
                        _StructureDetailService.Update(listStructureDetail[i]);
                    }
                }
                _StructureDetailService.Save();
                MetroMessageBox.Show(this, Properties.Resources.UpdateSuccessMessage, Properties.Resources.Notification, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                EnableEdit(true);
                UpdateStatus();

                Log.Instance.WriteLog(LogType.INFO, string.Format("Update structure id {0} of topic {1}",
                    currentStructure.StructureID,
                    currentTopic.TopicName));
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, Properties.Resources.Error, Properties.Resources.Notification,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Log.Instance.WriteErrorLog(LogType.ERROR, string.Format("Error when update structure {0} of topic {1}, error: {2}",
                    currentStructure.StructureID,
                    currentTopic.TopicName,
                    ex.Message));
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EnableEdit(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            List<STRUCTURE_DETAILS> listStructureDetail = _StructureDetailService
               .GetAll(currentStructure.StructureID, currentTopic.TopicID)
               .ToList();

            try
            {
                for (int i = 0; i < listNumQuestion.Count; i++)
                {
                    if (i < listStructureDetail.Count)
                    {
                        listStructureDetail[i].NumberQuestions = 0;
                        listStructureDetail[i].Score = 0;
                        _StructureDetailService.Update(listStructureDetail[i]);
                    }
                }
                _StructureDetailService.Save();
                MetroMessageBox.Show(this, Properties.Resources.DeleteSuccessMessage, Properties.Resources.Notification);
                foreach (NumericUpDown n in listNumQuestion) { n.Enabled = false; n.Value = 0; }
                foreach (NumericUpDown n in listNumScore) { n.Enabled = false; n.Value = 1; }

                EnableEdit(true);
                Update();

                Log.Instance.WriteLog(LogType.INFO, string.Format("Update structure id {0} of topic {1}",
                   currentStructure.StructureID,
                   currentTopic.TopicName));
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, Properties.Resources.Error, Properties.Resources.Notification);
                Log.Instance.WriteErrorLog(LogType.ERROR, string.Format("Error when update structure {0} of topic {1}, error: {2}",
                    currentStructure.StructureID,
                    currentTopic.TopicName,
                    ex.Message));
            }
        }

        private void EnableEdit(bool b)
        {
            btnEdit.Enabled = b;
            btnUpdate.Enabled = !b;
            btnDelete.Enabled = !b;

            foreach (NumericUpDown n in listNumQuestion) n.Enabled = !b;
            foreach (NumericUpDown n in listNumScore) n.Enabled = !b;
        }
    }
}