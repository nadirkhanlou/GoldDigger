namespace GoldDiggerGUI
{
    partial class Menu
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
            this.InputBrowserBtn = new System.Windows.Forms.Button();
            this.GameBoardCreatorBtn = new System.Windows.Forms.Button();
            this.selectedFileLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InputBrowserBtn
            // 
            this.InputBrowserBtn.Location = new System.Drawing.Point(48, 79);
            this.InputBrowserBtn.Name = "InputBrowserBtn";
            this.InputBrowserBtn.Size = new System.Drawing.Size(149, 28);
            this.InputBrowserBtn.TabIndex = 4;
            this.InputBrowserBtn.Text = "Browse File";
            this.InputBrowserBtn.UseVisualStyleBackColor = true;
            this.InputBrowserBtn.Click += new System.EventHandler(this.InputBrowserBtn_Click);
            // 
            // GameBoardCreatorBtn
            // 
            this.GameBoardCreatorBtn.Enabled = false;
            this.GameBoardCreatorBtn.Location = new System.Drawing.Point(48, 113);
            this.GameBoardCreatorBtn.Name = "GameBoardCreatorBtn";
            this.GameBoardCreatorBtn.Size = new System.Drawing.Size(149, 28);
            this.GameBoardCreatorBtn.TabIndex = 0;
            this.GameBoardCreatorBtn.Text = "Create The Game Board";
            this.GameBoardCreatorBtn.UseVisualStyleBackColor = true;
            this.GameBoardCreatorBtn.Click += new System.EventHandler(this.GameBoardCreatorBtn_Click);
            // 
            // selectedFileLabel
            // 
            this.selectedFileLabel.AutoSize = true;
            this.selectedFileLabel.Location = new System.Drawing.Point(54, 47);
            this.selectedFileLabel.Name = "selectedFileLabel";
            this.selectedFileLabel.Size = new System.Drawing.Size(0, 13);
            this.selectedFileLabel.TabIndex = 5;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 176);
            this.Controls.Add(this.selectedFileLabel);
            this.Controls.Add(this.InputBrowserBtn);
            this.Controls.Add(this.GameBoardCreatorBtn);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button InputBrowserBtn;
        private System.Windows.Forms.Button GameBoardCreatorBtn;
        private System.Windows.Forms.Label selectedFileLabel;
    }
}