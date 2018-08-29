namespace WindowsFormsApplication1
{
    partial class dlgTopic
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiComplected = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnGather = new System.Windows.Forms.Button();
            this.btnGoto = new System.Windows.Forms.Button();
            this.btnSearchForGood = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtUrl);
            this.splitContainer1.Panel2.Controls.Add(this.txtSearch);
            this.splitContainer1.Panel2.Controls.Add(this.btnGather);
            this.splitContainer1.Panel2.Controls.Add(this.btnGoto);
            this.splitContainer1.Panel2.Controls.Add(this.btnExport);
            this.splitContainer1.Panel2.Controls.Add(this.btnSearchForGood);
            this.splitContainer1.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(1139, 467);
            this.splitContainer1.SplitterDistance = 378;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.dataGridView1.Size = new System.Drawing.Size(378, 467);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.Sorted += new System.EventHandler(this.dataGridView1_Sorted);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiComplected});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // tsmiComplected
            // 
            this.tsmiComplected.Name = "tsmiComplected";
            this.tsmiComplected.Size = new System.Drawing.Size(100, 22);
            this.tsmiComplected.Text = "完成";
            this.tsmiComplected.Click += new System.EventHandler(this.tsmiComplected_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(83, 41);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(661, 21);
            this.txtUrl.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(15, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(221, 21);
            this.txtSearch.TabIndex = 2;
            // 
            // btnGather
            // 
            this.btnGather.Location = new System.Drawing.Point(345, 12);
            this.btnGather.Name = "btnGather";
            this.btnGather.Size = new System.Drawing.Size(97, 23);
            this.btnGather.TabIndex = 1;
            this.btnGather.Text = "采集";
            this.btnGather.UseVisualStyleBackColor = true;
            this.btnGather.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGoto
            // 
            this.btnGoto.Location = new System.Drawing.Point(15, 40);
            this.btnGoto.Name = "btnGoto";
            this.btnGoto.Size = new System.Drawing.Size(59, 23);
            this.btnGoto.TabIndex = 1;
            this.btnGoto.Text = "跳转";
            this.btnGoto.UseVisualStyleBackColor = true;
            this.btnGoto.Click += new System.EventHandler(this.btnGoto_Click);
            // 
            // btnSearchForGood
            // 
            this.btnSearchForGood.Location = new System.Drawing.Point(460, 13);
            this.btnSearchForGood.Name = "btnSearchForGood";
            this.btnSearchForGood.Size = new System.Drawing.Size(97, 23);
            this.btnSearchForGood.TabIndex = 1;
            this.btnSearchForGood.Text = "好人搜";
            this.btnSearchForGood.UseVisualStyleBackColor = true;
            this.btnSearchForGood.Click += new System.EventHandler(this.btnSearchForGood_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(242, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(97, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(4, 71);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(742, 384);
            this.webBrowser1.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(570, 13);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(97, 23);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "导出";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dlgTopic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 467);
            this.Controls.Add(this.splitContainer1);
            this.Name = "dlgTopic";
            this.Text = "dlgTopic";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button btnGather;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiComplected;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnGoto;
        private System.Windows.Forms.Button btnSearchForGood;
        private System.Windows.Forms.Button btnExport;
    }
}