namespace GoldDiggerGUI
{
    partial class GameBoard
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
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.PolicyValueIterationPanel = new System.Windows.Forms.Panel();
            this.qLearningPanel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.qTable = new System.Windows.Forms.Panel();
            this.PolicyValueIterationPanel.SuspendLayout();
            this.qLearningPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "policy iteration";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 61);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(81, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "show policy";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "value iteration";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Policy/Value Iteration",
            "Q Learning"});
            this.comboBox1.Location = new System.Drawing.Point(563, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(172, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "Policy/Value Iteration";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // PolicyValueIterationPanel
            // 
            this.PolicyValueIterationPanel.Controls.Add(this.button1);
            this.PolicyValueIterationPanel.Controls.Add(this.button2);
            this.PolicyValueIterationPanel.Controls.Add(this.checkBox1);
            this.PolicyValueIterationPanel.Location = new System.Drawing.Point(563, 63);
            this.PolicyValueIterationPanel.Name = "PolicyValueIterationPanel";
            this.PolicyValueIterationPanel.Size = new System.Drawing.Size(200, 115);
            this.PolicyValueIterationPanel.TabIndex = 4;
            // 
            // qLearningPanel
            // 
            this.qLearningPanel.Controls.Add(this.qTable);
            this.qLearningPanel.Controls.Add(this.button3);
            this.qLearningPanel.Location = new System.Drawing.Point(563, 66);
            this.qLearningPanel.Name = "qLearningPanel";
            this.qLearningPanel.Size = new System.Drawing.Size(200, 359);
            this.qLearningPanel.TabIndex = 5;
            this.qLearningPanel.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "Q learning acttion";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // qTable
            // 
            this.qTable.AutoScroll = true;
            this.qTable.Location = new System.Drawing.Point(12, 32);
            this.qTable.Name = "qTable";
            this.qTable.Size = new System.Drawing.Size(160, 311);
            this.qTable.TabIndex = 1;
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.qLearningPanel);
            this.Controls.Add(this.PolicyValueIterationPanel);
            this.Controls.Add(this.comboBox1);
            this.Name = "GameBoard";
            this.Text = "GameBoard";
            this.Load += new System.EventHandler(this.GameBoard_Load);
            this.PolicyValueIterationPanel.ResumeLayout(false);
            this.PolicyValueIterationPanel.PerformLayout();
            this.qLearningPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Panel PolicyValueIterationPanel;
        private System.Windows.Forms.Panel qLearningPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel qTable;
    }
}