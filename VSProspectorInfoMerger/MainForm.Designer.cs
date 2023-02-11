namespace VSProspectorInfoMerger
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_outputFile = new System.Windows.Forms.TextBox();
            this.tb_inputFile = new System.Windows.Forms.TextBox();
            this.btn_browseOutputFile = new System.Windows.Forms.Button();
            this.btn_browseInputFile = new System.Windows.Forms.Button();
            this.btn_merge = new System.Windows.Forms.Button();
            this.ofd_fileDialogue = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "Their File:";
            // 
            // tb_outputFile
            // 
            this.tb_outputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_outputFile.Location = new System.Drawing.Point(86, 12);
            this.tb_outputFile.Name = "tb_outputFile";
            this.tb_outputFile.Size = new System.Drawing.Size(655, 23);
            this.tb_outputFile.TabIndex = 2;
            // 
            // tb_inputFile
            // 
            this.tb_inputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_inputFile.Location = new System.Drawing.Point(86, 41);
            this.tb_inputFile.Name = "tb_inputFile";
            this.tb_inputFile.Size = new System.Drawing.Size(655, 23);
            this.tb_inputFile.TabIndex = 3;
            // 
            // btn_browseOutputFile
            // 
            this.btn_browseOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_browseOutputFile.Location = new System.Drawing.Point(747, 12);
            this.btn_browseOutputFile.Name = "btn_browseOutputFile";
            this.btn_browseOutputFile.Size = new System.Drawing.Size(75, 23);
            this.btn_browseOutputFile.TabIndex = 4;
            this.btn_browseOutputFile.Text = "Browse";
            this.btn_browseOutputFile.UseVisualStyleBackColor = true;
            this.btn_browseOutputFile.Click += new System.EventHandler(this.btn_browseOutputFile_Click);
            // 
            // btn_browseInputFile
            // 
            this.btn_browseInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_browseInputFile.Location = new System.Drawing.Point(747, 43);
            this.btn_browseInputFile.Name = "btn_browseInputFile";
            this.btn_browseInputFile.Size = new System.Drawing.Size(75, 23);
            this.btn_browseInputFile.TabIndex = 5;
            this.btn_browseInputFile.Text = "Browse";
            this.btn_browseInputFile.UseVisualStyleBackColor = true;
            this.btn_browseInputFile.Click += new System.EventHandler(this.btn_browseInputFile_Click);
            // 
            // btn_merge
            // 
            this.btn_merge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_merge.Location = new System.Drawing.Point(747, 77);
            this.btn_merge.Name = "btn_merge";
            this.btn_merge.Size = new System.Drawing.Size(75, 23);
            this.btn_merge.TabIndex = 6;
            this.btn_merge.Text = "Merge";
            this.btn_merge.UseVisualStyleBackColor = true;
            this.btn_merge.Click += new System.EventHandler(this.btn_merge_Click);
            // 
            // ofd_fileDialogue
            // 
            this.ofd_fileDialogue.FileOk += new System.ComponentModel.CancelEventHandler(this.ofd_fileDialogue_FileOk);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 103);
            this.Controls.Add(this.btn_merge);
            this.Controls.Add(this.btn_browseInputFile);
            this.Controls.Add(this.btn_browseOutputFile);
            this.Controls.Add(this.tb_inputFile);
            this.Controls.Add(this.tb_outputFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(400, 142);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox tb_outputFile;
        private TextBox tb_inputFile;
        private Button btn_browseOutputFile;
        private Button btn_browseInputFile;
        private Button btn_merge;
        private OpenFileDialog ofd_fileDialogue;
    }
}