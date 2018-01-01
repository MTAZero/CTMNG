namespace ExamManagement.GUI
{
    partial class FrmLoaiCauHoi
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoaiCauHoi));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLoaiCauHoi = new System.Windows.Forms.DataGridView();
            this.groupThongTin = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkIsQuestionContent = new System.Windows.Forms.CheckBox();
            this.chkIsParagraph = new System.Windows.Forms.CheckBox();
            this.chkIsSingleChoice = new System.Windows.Forms.CheckBox();
            this.chkIsQuiz = new System.Windows.Forms.CheckBox();
            this.txtNumberAnswer = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumberSubQuestion = new System.Windows.Forms.NumericUpDown();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtQuestionTypeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.QuestionTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuestionTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsQuiz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsSingleChoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsParagraph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsQuestionContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberSubQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberAnswer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiCauHoi)).BeginInit();
            this.groupThongTin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberAnswer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberSubQuestion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sách các loại câu hỏi";
            // 
            // dgvLoaiCauHoi
            // 
            this.dgvLoaiCauHoi.AllowDrop = true;
            this.dgvLoaiCauHoi.AllowUserToAddRows = false;
            this.dgvLoaiCauHoi.AllowUserToResizeColumns = false;
            this.dgvLoaiCauHoi.AllowUserToResizeRows = false;
            this.dgvLoaiCauHoi.BackgroundColor = System.Drawing.Color.White;
            this.dgvLoaiCauHoi.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLoaiCauHoi.ColumnHeadersHeight = 30;
            this.dgvLoaiCauHoi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLoaiCauHoi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.QuestionTypeID,
            this.QuestionTypeName,
            this.Description,
            this.IsQuiz,
            this.IsSingleChoice,
            this.IsParagraph,
            this.IsQuestionContent,
            this.NumberSubQuestion,
            this.NumberAnswer,
            this.Status});
            this.dgvLoaiCauHoi.EnableHeadersVisualStyles = false;
            this.dgvLoaiCauHoi.GridColor = System.Drawing.Color.Black;
            this.dgvLoaiCauHoi.Location = new System.Drawing.Point(45, 107);
            this.dgvLoaiCauHoi.MultiSelect = false;
            this.dgvLoaiCauHoi.Name = "dgvLoaiCauHoi";
            this.dgvLoaiCauHoi.ReadOnly = true;
            this.dgvLoaiCauHoi.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLoaiCauHoi.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLoaiCauHoi.RowHeadersWidth = 20;
            this.dgvLoaiCauHoi.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLoaiCauHoi.RowTemplate.Height = 40;
            this.dgvLoaiCauHoi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoaiCauHoi.Size = new System.Drawing.Size(651, 435);
            this.dgvLoaiCauHoi.TabIndex = 1;
            this.dgvLoaiCauHoi.SelectionChanged += new System.EventHandler(this.dgvDonVi_SelectionChanged);
            // 
            // groupThongTin
            // 
            this.groupThongTin.Controls.Add(this.groupBox2);
            this.groupThongTin.Controls.Add(this.txtNumberAnswer);
            this.groupThongTin.Controls.Add(this.label5);
            this.groupThongTin.Controls.Add(this.txtNumberSubQuestion);
            this.groupThongTin.Controls.Add(this.txtDescription);
            this.groupThongTin.Controls.Add(this.txtQuestionTypeName);
            this.groupThongTin.Controls.Add(this.label4);
            this.groupThongTin.Controls.Add(this.label3);
            this.groupThongTin.Controls.Add(this.label2);
            this.groupThongTin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupThongTin.Location = new System.Drawing.Point(740, 39);
            this.groupThongTin.Name = "groupThongTin";
            this.groupThongTin.Size = new System.Drawing.Size(534, 335);
            this.groupThongTin.TabIndex = 2;
            this.groupThongTin.TabStop = false;
            this.groupThongTin.Text = "Thông tin loại câu hỏi";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkIsQuestionContent);
            this.groupBox2.Controls.Add(this.chkIsParagraph);
            this.groupBox2.Controls.Add(this.chkIsSingleChoice);
            this.groupBox2.Controls.Add(this.chkIsQuiz);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(61, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(426, 104);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tùy chọn câu hỏi";
            // 
            // chkIsQuestionContent
            // 
            this.chkIsQuestionContent.AutoSize = true;
            this.chkIsQuestionContent.Location = new System.Drawing.Point(215, 64);
            this.chkIsQuestionContent.Name = "chkIsQuestionContent";
            this.chkIsQuestionContent.Size = new System.Drawing.Size(142, 17);
            this.chkIsQuestionContent.TabIndex = 3;
            this.chkIsQuestionContent.Text = "Có nội dung câu hỏi con";
            this.chkIsQuestionContent.UseVisualStyleBackColor = true;
            // 
            // chkIsParagraph
            // 
            this.chkIsParagraph.AutoSize = true;
            this.chkIsParagraph.Location = new System.Drawing.Point(78, 64);
            this.chkIsParagraph.Name = "chkIsParagraph";
            this.chkIsParagraph.Size = new System.Drawing.Size(88, 17);
            this.chkIsParagraph.TabIndex = 2;
            this.chkIsParagraph.Text = "Có đoạn văn";
            this.chkIsParagraph.UseVisualStyleBackColor = true;
            // 
            // chkIsSingleChoice
            // 
            this.chkIsSingleChoice.AutoSize = true;
            this.chkIsSingleChoice.Location = new System.Drawing.Point(215, 29);
            this.chkIsSingleChoice.Name = "chkIsSingleChoice";
            this.chkIsSingleChoice.Size = new System.Drawing.Size(105, 17);
            this.chkIsSingleChoice.TabIndex = 1;
            this.chkIsSingleChoice.Text = "Đáp án duy nhất";
            this.chkIsSingleChoice.UseVisualStyleBackColor = true;
            // 
            // chkIsQuiz
            // 
            this.chkIsQuiz.AutoSize = true;
            this.chkIsQuiz.Location = new System.Drawing.Point(78, 29);
            this.chkIsQuiz.Name = "chkIsQuiz";
            this.chkIsQuiz.Size = new System.Drawing.Size(85, 17);
            this.chkIsQuiz.TabIndex = 0;
            this.chkIsQuiz.Text = "Trắc nghiệm";
            this.chkIsQuiz.UseVisualStyleBackColor = true;
            // 
            // txtNumberAnswer
            // 
            this.txtNumberAnswer.Location = new System.Drawing.Point(276, 303);
            this.txtNumberAnswer.Name = "txtNumberAnswer";
            this.txtNumberAnswer.Size = new System.Drawing.Size(100, 20);
            this.txtNumberAnswer.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Số lượng câu trả lời của mỗi câu";
            // 
            // txtNumberSubQuestion
            // 
            this.txtNumberSubQuestion.Location = new System.Drawing.Point(139, 266);
            this.txtNumberSubQuestion.Name = "txtNumberSubQuestion";
            this.txtNumberSubQuestion.Size = new System.Drawing.Size(100, 20);
            this.txtNumberSubQuestion.TabIndex = 6;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(139, 66);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(348, 75);
            this.txtDescription.TabIndex = 5;
            // 
            // txtQuestionTypeName
            // 
            this.txtQuestionTypeName.Location = new System.Drawing.Point(139, 25);
            this.txtQuestionTypeName.Name = "txtQuestionTypeName";
            this.txtQuestionTypeName.Size = new System.Drawing.Size(193, 20);
            this.txtQuestionTypeName.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Số câu hỏi con";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Mô tả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên";
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.White;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThem.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Image = ((System.Drawing.Image)(resources.GetObject("btnThem.Image")));
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(740, 380);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(270, 50);
            this.btnThem.TabIndex = 3;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.BackColor = System.Drawing.Color.White;
            this.btnSua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSua.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSua.Image = ((System.Drawing.Image)(resources.GetObject("btnSua.Image")));
            this.btnSua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSua.Location = new System.Drawing.Point(1016, 380);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(258, 50);
            this.btnSua.TabIndex = 4;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = false;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.White;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Image = ((System.Drawing.Image)(resources.GetObject("btnXoa.Image")));
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(740, 436);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(534, 50);
            this.btnXoa.TabIndex = 5;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.White;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.Image")));
            this.btnDong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDong.Location = new System.Drawing.Point(740, 492);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(534, 50);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng chức năng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(70, 29);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(236, 20);
            this.txtTimKiem.TabIndex = 2;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.White;
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Location = new System.Drawing.Point(330, 27);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(109, 23);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.txtTimKiem);
            this.groupBox1.Location = new System.Drawing.Point(45, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 65);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm loại câu hỏi";
            // 
            // QuestionTypeID
            // 
            this.QuestionTypeID.DataPropertyName = "QuestionTypeID";
            this.QuestionTypeID.HeaderText = "Mã loại câu hỏi";
            this.QuestionTypeID.Name = "QuestionTypeID";
            this.QuestionTypeID.ReadOnly = true;
            this.QuestionTypeID.Visible = false;
            // 
            // QuestionTypeName
            // 
            this.QuestionTypeName.DataPropertyName = "QuestionTypeName";
            this.QuestionTypeName.HeaderText = "Tên loại câu hỏi";
            this.QuestionTypeName.Name = "QuestionTypeName";
            this.QuestionTypeName.ReadOnly = true;
            this.QuestionTypeName.Width = 220;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Mô tả";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 259;
            // 
            // IsQuiz
            // 
            this.IsQuiz.DataPropertyName = "IsQuiz";
            this.IsQuiz.HeaderText = "Trắc nghiệm";
            this.IsQuiz.Name = "IsQuiz";
            this.IsQuiz.ReadOnly = true;
            this.IsQuiz.Visible = false;
            // 
            // IsSingleChoice
            // 
            this.IsSingleChoice.DataPropertyName = "IsSingleChoice";
            this.IsSingleChoice.HeaderText = "Đáp án duy nhất";
            this.IsSingleChoice.Name = "IsSingleChoice";
            this.IsSingleChoice.ReadOnly = true;
            this.IsSingleChoice.Visible = false;
            // 
            // IsParagraph
            // 
            this.IsParagraph.DataPropertyName = "IsParagraph";
            this.IsParagraph.HeaderText = "Có đoạn văn";
            this.IsParagraph.Name = "IsParagraph";
            this.IsParagraph.ReadOnly = true;
            this.IsParagraph.Visible = false;
            // 
            // IsQuestionContent
            // 
            this.IsQuestionContent.DataPropertyName = "IsQuestionContent";
            this.IsQuestionContent.HeaderText = "Có nội dung câu hỏi con";
            this.IsQuestionContent.Name = "IsQuestionContent";
            this.IsQuestionContent.ReadOnly = true;
            this.IsQuestionContent.Visible = false;
            // 
            // NumberSubQuestion
            // 
            this.NumberSubQuestion.DataPropertyName = "NumberSubQuestion";
            this.NumberSubQuestion.HeaderText = "Số lượng câu hỏi con";
            this.NumberSubQuestion.Name = "NumberSubQuestion";
            this.NumberSubQuestion.ReadOnly = true;
            this.NumberSubQuestion.Width = 150;
            // 
            // NumberAnswer
            // 
            this.NumberAnswer.DataPropertyName = "NumberAnswer";
            this.NumberAnswer.HeaderText = "Số lượng câu trả lời của mỗi câu";
            this.NumberAnswer.Name = "NumberAnswer";
            this.NumberAnswer.ReadOnly = true;
            this.NumberAnswer.Visible = false;
            this.NumberAnswer.Width = 150;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Trạng thái";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Visible = false;
            // 
            // FrmLoaiCauHoi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1327, 576);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.groupThongTin);
            this.Controls.Add(this.dgvLoaiCauHoi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmLoaiCauHoi";
            this.Text = "FrmDonVi";
            this.Load += new System.EventHandler(this.FrmDonVi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoaiCauHoi)).EndInit();
            this.groupThongTin.ResumeLayout(false);
            this.groupThongTin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberAnswer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberSubQuestion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupThongTin;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtQuestionTypeName;
        private System.Windows.Forms.NumericUpDown txtNumberSubQuestion;
        private System.Windows.Forms.DataGridView dgvLoaiCauHoi;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown txtNumberAnswer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsQuiz;
        private System.Windows.Forms.CheckBox chkIsQuestionContent;
        private System.Windows.Forms.CheckBox chkIsParagraph;
        private System.Windows.Forms.CheckBox chkIsSingleChoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuestionTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuestionTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsQuiz;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsSingleChoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsParagraph;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsQuestionContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberSubQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberAnswer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;

    }
}