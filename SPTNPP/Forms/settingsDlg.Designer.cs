namespace Kbg.NppPluginNET
{
    partial class settingsDlg
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
			this.label1 = new System.Windows.Forms.Label();
			this.ffTip = new System.Windows.Forms.ToolTip(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.commandBox = new System.Windows.Forms.TextBox();
			this.tickBox = new System.Windows.Forms.NumericUpDown();
			this.portBox = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.commandTip = new System.Windows.Forms.ToolTip(this.components);
			this.saveChangesButton = new System.Windows.Forms.Button();
			this.deleteChangesButton = new System.Windows.Forms.Button();
			this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.tickBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.portBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "FF tick";
			this.commandTip.SetToolTip(this.label1, "Fast forward to X ticks before the end of the demo, -1 for no fast forward");
			// 
			// ffTip
			// 
			this.ffTip.AutoPopDelay = 10000;
			this.ffTip.InitialDelay = 500;
			this.ffTip.ReshowDelay = 100;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Custom command";
			this.commandTip.SetToolTip(this.label2, "Command to run in custom command action");
			// 
			// commandBox
			// 
			this.commandBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.commandBox.Location = new System.Drawing.Point(12, 98);
			this.commandBox.Name = "commandBox";
			this.commandBox.Size = new System.Drawing.Size(177, 20);
			this.commandBox.TabIndex = 3;
			// 
			// tickBox
			// 
			this.tickBox.Location = new System.Drawing.Point(12, 20);
			this.tickBox.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.tickBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
			this.tickBox.Name = "tickBox";
			this.tickBox.Size = new System.Drawing.Size(120, 20);
			this.tickBox.TabIndex = 4;
			// 
			// portBox
			// 
			this.portBox.Location = new System.Drawing.Point(12, 59);
			this.portBox.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
			this.portBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.portBox.Name = "portBox";
			this.portBox.Size = new System.Drawing.Size(120, 20);
			this.portBox.TabIndex = 6;
			this.portBox.Value = new decimal(new int[] {
            27182,
            0,
            0,
            0});
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 43);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(45, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "IPC port";
			// 
			// commandTip
			// 
			this.commandTip.AutoPopDelay = 10000;
			this.commandTip.InitialDelay = 500;
			this.commandTip.ReshowDelay = 100;
			// 
			// saveChangesButton
			// 
			this.saveChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.saveChangesButton.Location = new System.Drawing.Point(13, 432);
			this.saveChangesButton.Name = "saveChangesButton";
			this.saveChangesButton.Size = new System.Drawing.Size(87, 23);
			this.saveChangesButton.TabIndex = 7;
			this.saveChangesButton.Text = "Save ";
			this.saveChangesButton.UseVisualStyleBackColor = true;
			this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
			// 
			// deleteChangesButton
			// 
			this.deleteChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.deleteChangesButton.Location = new System.Drawing.Point(101, 432);
			this.deleteChangesButton.Name = "deleteChangesButton";
			this.deleteChangesButton.Size = new System.Drawing.Size(88, 23);
			this.deleteChangesButton.TabIndex = 8;
			this.deleteChangesButton.Text = "Discard";
			this.deleteChangesButton.UseVisualStyleBackColor = true;
			this.deleteChangesButton.Click += new System.EventHandler(this.deleteChangesButton_Click);
			// 
			// settingsDlg
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(201, 467);
			this.Controls.Add(this.deleteChangesButton);
			this.Controls.Add(this.saveChangesButton);
			this.Controls.Add(this.portBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tickBox);
			this.Controls.Add(this.commandBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "settingsDlg";
			this.Text = "SPTNPP Settings";
			((System.ComponentModel.ISupportInitialize)(this.tickBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.portBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolTip ffTip;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox commandBox;
		private System.Windows.Forms.NumericUpDown tickBox;
		private System.Windows.Forms.NumericUpDown portBox;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolTip commandTip;
		private System.Windows.Forms.Button saveChangesButton;
		private System.Windows.Forms.Button deleteChangesButton;
		private System.Windows.Forms.BindingSource bindingSource1;
	}
}