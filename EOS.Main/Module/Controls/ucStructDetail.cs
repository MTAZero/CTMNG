using EXON.Data.Services;
using EXON.Model.Models;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.Linq;
using System.Threading;
using System.Drawing;

namespace EXON.Main.Module.Controls
{
    public partial class ucStructDetail : UserControl
    {
        private STRUCTURE currentStructure;
        private TOPIC currentTopic;
        private List<Label> listLabelNumScore;
        private List<Label> listLabelNumQuestion;

        private StructureDetailService _StructureDetailService;
        public int TotalNumQuestion { get; private set; }
        public double TotalScore { get; private set; }
        public int StructureId { get; private set; }
        public int TopicId { get; private set; }

        private Color defaultColor;
        public ucStructDetail(STRUCTURE structureTest, TOPIC topic)
        {
            InitializeComponent();
            this.currentStructure = structureTest;
            this.currentTopic = topic;
            this.StructureId = structureTest.StructureID;
            this.TopicId = topic.TopicID;
            defaultColor = this.BackColor;

            _StructureDetailService = new StructureDetailService();
            listLabelNumQuestion = new List<Label>() { label18, label19, label20, label21 };
            listLabelNumScore = new List<Label>() { label22, label23, label24, label25 };

            InitControls();
            this.Dock = DockStyle.Top;
            this.AutoSize = true;
            this.DoubleBuffered = true;
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

            for (int i = 0; i < listLabelNumQuestion.Count; i++)
            {
                if (i < listStructureDetail.Count)
                {
                    TotalNumQuestion += listStructureDetail[i].NumberQuestions;
                    TotalScore += listStructureDetail[i].Score * listStructureDetail[i].NumberQuestions;

                    listLabelNumQuestion[i].Text = listStructureDetail[i].NumberQuestions.ToString();
                    listLabelNumScore[i].Text = (listStructureDetail[i].Score).ToString();
                }
                else
                {
                    listLabelNumQuestion[i].Text = "0";
                    listLabelNumScore[i].Text = "0.00";
                }
            }

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

        internal void ChangeColor(bool v)
        {
            if (v) this.BackColor = Color.Yellow;
            else this.BackColor = defaultColor;
        }
    }
}