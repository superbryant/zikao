﻿namespace WindowsFormsApplication1
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnX1 = new System.Windows.Forms.Button();
            this.btnX2 = new System.Windows.Forms.Button();
            this.txtFliter = new System.Windows.Forms.TextBox();
            this.txtC = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSource = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txtMyText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnX3 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.btnExceptSpecial = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReplaceImg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLook4Topic = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiGraphicCalc = new System.Windows.Forms.ToolStripMenuItem();
            this.科目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAddSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.cboSubject = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboChapter = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSection = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIssue = new System.Windows.Forms.TextBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.chkCurSubject = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCompare = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnX1
            // 
            this.btnX1.Location = new System.Drawing.Point(584, 65);
            this.btnX1.Name = "btnX1";
            this.btnX1.Size = new System.Drawing.Size(75, 23);
            this.btnX1.TabIndex = 4;
            this.btnX1.Text = "模板一";
            this.btnX1.UseVisualStyleBackColor = true;
            this.btnX1.Click += new System.EventHandler(this.btnX1_Click);
            // 
            // btnX2
            // 
            this.btnX2.Location = new System.Drawing.Point(670, 65);
            this.btnX2.Name = "btnX2";
            this.btnX2.Size = new System.Drawing.Size(75, 23);
            this.btnX2.TabIndex = 5;
            this.btnX2.Text = "模板二";
            this.btnX2.UseVisualStyleBackColor = true;
            this.btnX2.Click += new System.EventHandler(this.btnX2_Click);
            // 
            // txtFliter
            // 
            this.txtFliter.Location = new System.Drawing.Point(84, 14);
            this.txtFliter.Name = "txtFliter";
            this.txtFliter.Size = new System.Drawing.Size(422, 21);
            this.txtFliter.TabIndex = 0;
            // 
            // txtC
            // 
            this.txtC.BackColor = System.Drawing.Color.White;
            this.txtC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtC.Font = new System.Drawing.Font("宋体", 14F);
            this.txtC.Location = new System.Drawing.Point(0, 0);
            this.txtC.Multiline = true;
            this.txtC.Name = "txtC";
            this.txtC.Size = new System.Drawing.Size(351, 220);
            this.txtC.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(503, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSource
            // 
            this.btnSource.Location = new System.Drawing.Point(667, 36);
            this.btnSource.Name = "btnSource";
            this.btnSource.Size = new System.Drawing.Size(75, 23);
            this.btnSource.TabIndex = 2;
            this.btnSource.Text = "原文";
            this.btnSource.UseVisualStyleBackColor = true;
            this.btnSource.Click += new System.EventHandler(this.btnSource_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtC);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtMyText);
            this.splitContainer1.Size = new System.Drawing.Size(707, 220);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.TabIndex = 3;
            // 
            // txtMyText
            // 
            this.txtMyText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMyText.Font = new System.Drawing.Font("宋体", 14F);
            this.txtMyText.Location = new System.Drawing.Point(0, 0);
            this.txtMyText.Multiline = true;
            this.txtMyText.Name = "txtMyText";
            this.txtMyText.Size = new System.Drawing.Size(352, 220);
            this.txtMyText.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(503, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "屏蔽所有";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnX3
            // 
            this.btnX3.Location = new System.Drawing.Point(755, 66);
            this.btnX3.Name = "btnX3";
            this.btnX3.Size = new System.Drawing.Size(75, 23);
            this.btnX3.TabIndex = 9;
            this.btnX3.Text = "模板X";
            this.btnX3.UseVisualStyleBackColor = true;
            this.btnX3.Click += new System.EventHandler(this.btnX3_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(774, 42);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(39, 21);
            this.numericUpDown1.TabIndex = 8;
            this.numericUpDown1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnExceptSpecial
            // 
            this.btnExceptSpecial.Location = new System.Drawing.Point(584, 36);
            this.btnExceptSpecial.Name = "btnExceptSpecial";
            this.btnExceptSpecial.Size = new System.Drawing.Size(75, 23);
            this.btnExceptSpecial.TabIndex = 1;
            this.btnExceptSpecial.Text = "除了特殊";
            this.btnExceptSpecial.UseVisualStyleBackColor = true;
            this.btnExceptSpecial.Click += new System.EventHandler(this.btnExceptSpecial_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具ToolStripMenuItem,
            this.科目ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1009, 25);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 工具ToolStripMenuItem
            // 
            this.工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReplaceImg,
            this.tsmiLook4Topic,
            this.tsmiUsers,
            this.tsmiGraphicCalc});
            this.工具ToolStripMenuItem.Name = "工具ToolStripMenuItem";
            this.工具ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.工具ToolStripMenuItem.Text = "工具";
            // 
            // tsmiReplaceImg
            // 
            this.tsmiReplaceImg.Name = "tsmiReplaceImg";
            this.tsmiReplaceImg.Size = new System.Drawing.Size(148, 22);
            this.tsmiReplaceImg.Text = "替换宝典图片";
            this.tsmiReplaceImg.Click += new System.EventHandler(this.tsmiReplaceImg_Click);
            // 
            // tsmiLook4Topic
            // 
            this.tsmiLook4Topic.Name = "tsmiLook4Topic";
            this.tsmiLook4Topic.Size = new System.Drawing.Size(148, 22);
            this.tsmiLook4Topic.Text = "找题目";
            this.tsmiLook4Topic.Click += new System.EventHandler(this.tsmiLook4Topic_Click);
            // 
            // tsmiUsers
            // 
            this.tsmiUsers.Name = "tsmiUsers";
            this.tsmiUsers.Size = new System.Drawing.Size(148, 22);
            this.tsmiUsers.Text = "采集所有用户";
            this.tsmiUsers.Click += new System.EventHandler(this.tsmiUsers_Click);
            // 
            // tsmiGraphicCalc
            // 
            this.tsmiGraphicCalc.Name = "tsmiGraphicCalc";
            this.tsmiGraphicCalc.Size = new System.Drawing.Size(148, 22);
            this.tsmiGraphicCalc.Text = "图例计算";
            this.tsmiGraphicCalc.Click += new System.EventHandler(this.tsmiGraphicCalc_Click);
            // 
            // 科目ToolStripMenuItem
            // 
            this.科目ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAddSubject});
            this.科目ToolStripMenuItem.Name = "科目ToolStripMenuItem";
            this.科目ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.科目ToolStripMenuItem.Text = "科目";
            // 
            // tsmiAddSubject
            // 
            this.tsmiAddSubject.Name = "tsmiAddSubject";
            this.tsmiAddSubject.Size = new System.Drawing.Size(124, 22);
            this.tsmiAddSubject.Text = "添加科目";
            this.tsmiAddSubject.Click += new System.EventHandler(this.tsmiAddSubject_Click);
            // 
            // cboSubject
            // 
            this.cboSubject.FormattingEnabled = true;
            this.cboSubject.Location = new System.Drawing.Point(75, 100);
            this.cboSubject.Name = "cboSubject";
            this.cboSubject.Size = new System.Drawing.Size(195, 20);
            this.cboSubject.TabIndex = 13;
            this.cboSubject.SelectedIndexChanged += new System.EventHandler(this.cboSubject_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "不筛选字符";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "科目";
            // 
            // cboChapter
            // 
            this.cboChapter.FormattingEnabled = true;
            this.cboChapter.Location = new System.Drawing.Point(75, 135);
            this.cboChapter.Name = "cboChapter";
            this.cboChapter.Size = new System.Drawing.Size(195, 20);
            this.cboChapter.TabIndex = 12;
            this.cboChapter.SelectedIndexChanged += new System.EventHandler(this.cboChapter_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "章";
            // 
            // cboSection
            // 
            this.cboSection.FormattingEnabled = true;
            this.cboSection.Location = new System.Drawing.Point(75, 166);
            this.cboSection.Name = "cboSection";
            this.cboSection.Size = new System.Drawing.Size(195, 20);
            this.cboSection.TabIndex = 11;
            this.cboSection.SelectedIndexChanged += new System.EventHandler(this.cboSection_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "节";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.txtFliter);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(707, 270);
            this.splitContainer2.SplitterDistance = 46;
            this.splitContainer2.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "考期";
            // 
            // txtIssue
            // 
            this.txtIssue.Location = new System.Drawing.Point(75, 65);
            this.txtIssue.Name = "txtIssue";
            this.txtIssue.ReadOnly = true;
            this.txtIssue.Size = new System.Drawing.Size(195, 21);
            this.txtIssue.TabIndex = 14;
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(290, 63);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(75, 23);
            this.btnReload.TabIndex = 0;
            this.btnReload.Text = "重新加载";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(13, 207);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(268, 376);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Title";
            this.Column1.HeaderText = "标题";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "CreateDate";
            this.Column3.HeaderText = "创建时间";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(100, 22);
            this.tsmiDelete.Text = "删除";
            this.tsmiDelete.Click += new System.EventHandler(this.tsmiDelete_Click);
            // 
            // chkCurSubject
            // 
            this.chkCurSubject.AutoSize = true;
            this.chkCurSubject.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCurSubject.Location = new System.Drawing.Point(75, 36);
            this.chkCurSubject.Name = "chkCurSubject";
            this.chkCurSubject.Size = new System.Drawing.Size(96, 16);
            this.chkCurSubject.TabIndex = 16;
            this.chkCurSubject.Text = "当前科目所有";
            this.chkCurSubject.UseVisualStyleBackColor = true;
            this.chkCurSubject.CheckedChanged += new System.EventHandler(this.chkCurSubject_CheckedChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(371, 64);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(875, 66);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 0;
            this.btnCompare.Text = "比较";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer3.Location = new System.Drawing.Point(290, 100);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer3.Size = new System.Drawing.Size(707, 483);
            this.splitContainer3.SplitterDistance = 270;
            this.splitContainer3.TabIndex = 17;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(707, 209);
            this.webBrowser1.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 596);
            this.Controls.Add(this.splitContainer3);
            this.Controls.Add(this.chkCurSubject);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtIssue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboSection);
            this.Controls.Add(this.cboChapter);
            this.Controls.Add(this.cboSubject);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnExceptSpecial);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSource);
            this.Controls.Add(this.btnX3);
            this.Controls.Add(this.btnX2);
            this.Controls.Add(this.btnX1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "认真、专注——追求100分";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnX1;
        private System.Windows.Forms.Button btnX2;
        private System.Windows.Forms.TextBox txtFliter;
        private System.Windows.Forms.TextBox txtC;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txtMyText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnX3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnExceptSpecial;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiReplaceImg;
        private System.Windows.Forms.ToolStripMenuItem 科目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiAddSubject;
        private System.Windows.Forms.ComboBox cboSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboChapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSection;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIssue;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStripMenuItem tsmiLook4Topic;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsers;
        private System.Windows.Forms.CheckBox chkCurSubject;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiGraphicCalc;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}
