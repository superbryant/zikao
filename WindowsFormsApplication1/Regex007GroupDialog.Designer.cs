namespace WindowsFormsApplication1
{
    partial class Regex007GroupDialog
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
            this.btnBuildHtml = new System.Windows.Forms.Button();
            this.txtHtml = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnBuildHtml
            // 
            this.btnBuildHtml.Location = new System.Drawing.Point(586, 13);
            this.btnBuildHtml.Name = "btnBuildHtml";
            this.btnBuildHtml.Size = new System.Drawing.Size(107, 23);
            this.btnBuildHtml.TabIndex = 0;
            this.btnBuildHtml.Text = "生成html";
            this.btnBuildHtml.UseVisualStyleBackColor = true;
            this.btnBuildHtml.Click += new System.EventHandler(this.btnBuildHtml_Click);
            // 
            // txtHtml
            // 
            this.txtHtml.Location = new System.Drawing.Point(30, 13);
            this.txtHtml.Name = "txtHtml";
            this.txtHtml.Size = new System.Drawing.Size(550, 21);
            this.txtHtml.TabIndex = 1;
            // 
            // Regex007GroupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 283);
            this.Controls.Add(this.txtHtml);
            this.Controls.Add(this.btnBuildHtml);
            this.Name = "Regex007GroupDialog";
            this.Text = "Regex007GroupDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuildHtml;
        private System.Windows.Forms.TextBox txtHtml;
    }
}