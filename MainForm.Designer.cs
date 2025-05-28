namespace RT_AI_Assistant
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.TextBox ConversationBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.StatusLabel = new System.Windows.Forms.Label();
            this.ConversationBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // StatusLabel
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.StatusLabel.Location = new System.Drawing.Point(12, 15);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(140, 21);
            this.StatusLabel.TabIndex = 0;
            this.StatusLabel.Text = "Status: Not started";

            // ConversationBox
            this.ConversationBox.Location = new System.Drawing.Point(16, 50);
            this.ConversationBox.Multiline = true;
            this.ConversationBox.Name = "ConversationBox";
            this.ConversationBox.ReadOnly = true;
            this.ConversationBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConversationBox.Size = new System.Drawing.Size(600, 300);
            this.ConversationBox.TabIndex = 1;

            // StartButton
            this.StartButton.Location = new System.Drawing.Point(16, 370);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 35);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start Listening";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);

            // StopButton
            this.StopButton.Location = new System.Drawing.Point(130, 370);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(100, 35);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Stop Listening";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 421);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.ConversationBox);
            this.Controls.Add(this.StatusLabel);
            this.Name = "MainForm";
            this.Text = "RT AI Assistant";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
