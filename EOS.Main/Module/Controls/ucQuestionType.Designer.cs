namespace EXON.Main.Module.Controls
{
    partial class ucQuestionType
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.icbIsQuiz = new System.Windows.Forms.CheckBox();
            this.btnRefesh = new System.Windows.Forms.Button();
            this.btnCreateTemplate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.seNumberAnswer = new System.Windows.Forms.NumericUpDown();
            this.seNumberSubQuestion = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.ceQuestionContent = new System.Windows.Forms.CheckBox();
            this.ceParagraph = new System.Windows.Forms.CheckBox();
            this.ceSingleChoice = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gcMain = new System.Windows.Forms.DataGridView();
            this.colQuestionTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberSubQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumberAnswer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsQuiz = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsSingleChoice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsParagraph = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsQuestionContent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colQuestionTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seNumberAnswer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seNumberSubQuestion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.icbIsQuiz);
            this.groupBox1.Controls.Add(this.btnRefesh);
            this.groupBox1.Controls.Add(this.btnCreateTemplate);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.seNumberAnswer);
            this.groupBox1.Controls.Add(this.seNumberSubQuestion);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ceQuestionContent);
            this.groupBox1.Controls.Add(this.ceParagraph);
            this.groupBox1.Controls.Add(this.ceSingleChoice);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(521, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 548);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // icbIsQuiz
            // 
            this.icbIsQuiz.AutoSize = true;
            this.icbIsQuiz.Location = new System.Drawing.Point(14, 339);
            this.icbIsQuiz.Name = "icbIsQuiz";
            this.icbIsQuiz.Size = new System.Drawing.Size(87, 17);
            this.icbIsQuiz.TabIndex = 17;
            this.icbIsQuiz.Text = "Trắc Nghiệm";
            this.icbIsQuiz.UseVisualStyleBackColor = true;
            this.icbIsQuiz.CheckedChanged += new System.EventHandler(this.icbIsQuiz_CheckedChanged);
            // 
            // btnRefesh
            // 
            this.btnRefesh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefesh.Location = new System.Drawing.Point(134, 490);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(140, 23);
            this.btnRefesh.TabIndex = 16;
            this.btnRefesh.Text = "Làm Mới";
            this.btnRefesh.UseVisualStyleBackColor = true;
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // btnCreateTemplate
            // 
            this.btnCreateTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreateTemplate.Location = new System.Drawing.Point(7, 490);
            this.btnCreateTemplate.Name = "btnCreateTemplate";
            this.btnCreateTemplate.Size = new System.Drawing.Size(121, 23);
            this.btnCreateTemplate.TabIndex = 15;
            this.btnCreateTemplate.Text = "Tạo Template Mẫu";
            this.btnCreateTemplate.UseVisualStyleBackColor = true;
            this.btnCreateTemplate.Click += new System.EventHandler(this.btnCreateTemplate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(134, 519);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Thêm Mới Loại Câu Hỏi";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(7, 519);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(121, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Xóa Loại Câu Hỏi";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Số Câu Trả Lời";
            // 
            // seNumberAnswer
            // 
            this.seNumberAnswer.Location = new System.Drawing.Point(95, 415);
            this.seNumberAnswer.Name = "seNumberAnswer";
            this.seNumberAnswer.Size = new System.Drawing.Size(176, 20);
            this.seNumberAnswer.TabIndex = 11;
            // 
            // seNumberSubQuestion
            // 
            this.seNumberSubQuestion.Location = new System.Drawing.Point(95, 389);
            this.seNumberSubQuestion.Name = "seNumberSubQuestion";
            this.seNumberSubQuestion.Size = new System.Drawing.Size(176, 20);
            this.seNumberSubQuestion.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Số Câu Hỏi Con";
            // 
            // ceQuestionContent
            // 
            this.ceQuestionContent.AutoSize = true;
            this.ceQuestionContent.Location = new System.Drawing.Point(137, 362);
            this.ceQuestionContent.Name = "ceQuestionContent";
            this.ceQuestionContent.Size = new System.Drawing.Size(143, 17);
            this.ceQuestionContent.TabIndex = 8;
            this.ceQuestionContent.Text = "Câu Hỏi Con Có Tiêu Đề";
            this.ceQuestionContent.UseVisualStyleBackColor = true;
            // 
            // ceParagraph
            // 
            this.ceParagraph.AutoSize = true;
            this.ceParagraph.Location = new System.Drawing.Point(137, 339);
            this.ceParagraph.Name = "ceParagraph";
            this.ceParagraph.Size = new System.Drawing.Size(90, 17);
            this.ceParagraph.TabIndex = 7;
            this.ceParagraph.Text = "Có Đoạn Văn";
            this.ceParagraph.UseVisualStyleBackColor = true;
            // 
            // ceSingleChoice
            // 
            this.ceSingleChoice.AutoSize = true;
            this.ceSingleChoice.Location = new System.Drawing.Point(14, 362);
            this.ceSingleChoice.Name = "ceSingleChoice";
            this.ceSingleChoice.Size = new System.Drawing.Size(83, 17);
            this.ceSingleChoice.TabIndex = 6;
            this.ceSingleChoice.Text = "Một Đáp An";
            this.ceSingleChoice.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(6, 81);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(268, 252);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mô Tả Chi Tiết";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(6, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(268, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Loại Câu Hỏi";
            // 
            // gcMain
            // 
            this.gcMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.gcMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gcMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colQuestionTypeName,
            this.colNumberSubQuestion,
            this.colNumberAnswer,
            this.colDescription,
            this.colIsQuiz,
            this.colIsSingleChoice,
            this.colIsParagraph,
            this.colIsQuestionContent,
            this.colQuestionTypeID});
            this.gcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcMain.Location = new System.Drawing.Point(0, 0);
            this.gcMain.MultiSelect = false;
            this.gcMain.Name = "gcMain";
            this.gcMain.ReadOnly = true;
            this.gcMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gcMain.Size = new System.Drawing.Size(521, 548);
            this.gcMain.TabIndex = 1;
            this.gcMain.SelectionChanged += new System.EventHandler(this.gcMain_SelectionChanged);
            // 
            // colQuestionTypeName
            // 
            this.colQuestionTypeName.DataPropertyName = "QuestionTypeName";
            this.colQuestionTypeName.HeaderText = "Tên Loại Câu Hỏi";
            this.colQuestionTypeName.Name = "colQuestionTypeName";
            this.colQuestionTypeName.ReadOnly = true;
            this.colQuestionTypeName.Width = 91;
            // 
            // colNumberSubQuestion
            // 
            this.colNumberSubQuestion.DataPropertyName = "NumberSubQuestion";
            this.colNumberSubQuestion.HeaderText = "Số Câu Hỏi Con";
            this.colNumberSubQuestion.Name = "colNumberSubQuestion";
            this.colNumberSubQuestion.ReadOnly = true;
            this.colNumberSubQuestion.Width = 82;
            // 
            // colNumberAnswer
            // 
            this.colNumberAnswer.DataPropertyName = "NumberAnswer";
            this.colNumberAnswer.HeaderText = "Số Câu Trả Lời";
            this.colNumberAnswer.Name = "colNumberAnswer";
            this.colNumberAnswer.ReadOnly = true;
            this.colNumberAnswer.Width = 82;
            // 
            // colDescription
            // 
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescription.DataPropertyName = "Description";
            this.colDescription.HeaderText = "Mô Tả";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colIsQuiz
            // 
            this.colIsQuiz.DataPropertyName = "IsQuiz";
            this.colIsQuiz.HeaderText = "Loại Câu Hỏi";
            this.colIsQuiz.Name = "colIsQuiz";
            this.colIsQuiz.ReadOnly = true;
            this.colIsQuiz.Width = 52;
            // 
            // colIsSingleChoice
            // 
            this.colIsSingleChoice.DataPropertyName = "IsSingleChoice";
            this.colIsSingleChoice.HeaderText = "Loại Một Đáp Án";
            this.colIsSingleChoice.Name = "colIsSingleChoice";
            this.colIsSingleChoice.ReadOnly = true;
            this.colIsSingleChoice.Width = 72;
            // 
            // colIsParagraph
            // 
            this.colIsParagraph.DataPropertyName = "IsParagraph";
            this.colIsParagraph.HeaderText = "Có Đoạn Văn";
            this.colIsParagraph.Name = "colIsParagraph";
            this.colIsParagraph.ReadOnly = true;
            this.colIsParagraph.Width = 69;
            // 
            // colIsQuestionContent
            // 
            this.colIsQuestionContent.DataPropertyName = "IsQuestionContent";
            this.colIsQuestionContent.HeaderText = "Có Nội Dung Câu Hỏi Con";
            this.colIsQuestionContent.Name = "colIsQuestionContent";
            this.colIsQuestionContent.ReadOnly = true;
            this.colIsQuestionContent.Width = 89;
            // 
            // colQuestionTypeID
            // 
            this.colQuestionTypeID.DataPropertyName = "QuestionTypeID";
            this.colQuestionTypeID.HeaderText = "QuestionTypeID";
            this.colQuestionTypeID.Name = "colQuestionTypeID";
            this.colQuestionTypeID.ReadOnly = true;
            this.colQuestionTypeID.Visible = false;
            // 
            // ucQuestionType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gcMain);
            this.Controls.Add(this.groupBox1);
            this.Name = "ucQuestionType";
            this.Size = new System.Drawing.Size(801, 548);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seNumberAnswer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seNumberSubQuestion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown seNumberAnswer;
        private System.Windows.Forms.NumericUpDown seNumberSubQuestion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox ceQuestionContent;
        private System.Windows.Forms.CheckBox ceParagraph;
        private System.Windows.Forms.CheckBox ceSingleChoice;
        private System.Windows.Forms.Button btnRefesh;
        private System.Windows.Forms.Button btnCreateTemplate;
        private System.Windows.Forms.DataGridView gcMain;
        private System.Windows.Forms.CheckBox icbIsQuiz;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuestionTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberSubQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumberAnswer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsQuiz;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsSingleChoice;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsParagraph;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsQuestionContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuestionTypeID;
    }
}
