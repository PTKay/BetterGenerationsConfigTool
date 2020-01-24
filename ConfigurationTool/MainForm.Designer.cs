using Generations_Launcher_Front.Properties;

namespace Generations_Launcher_Front
{
	public partial class MainForm : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
        {
            this.Icon = Resources.SystemTray;
			this.TabWindow = new global::System.Windows.Forms.TabControl();
			this.tabPage1 = new global::System.Windows.Forms.TabPage();
			this.tabPage2 = new global::System.Windows.Forms.TabPage();
			this.tabPage3 = new global::System.Windows.Forms.TabPage();
			this.LaunchButton = new global::System.Windows.Forms.Button();
			this.SaveButton = new global::System.Windows.Forms.Button();
			this.CancelConfigButton = new global::System.Windows.Forms.Button();
			this.InputConfig = new global::System.Windows.Forms.TabPage();
			this.TabWindow.SuspendLayout();
			base.SuspendLayout();
			this.TabWindow.Controls.Add(this.InputConfig);
			this.TabWindow.Controls.Add(this.tabPage1);
			this.TabWindow.Controls.Add(this.tabPage2);
			this.TabWindow.Controls.Add(this.tabPage3);
			this.TabWindow.Location = new global::System.Drawing.Point(12, 12);
			this.TabWindow.Name = "TabWindow";
			this.TabWindow.SelectedIndex = 0;
			this.TabWindow.Size = new global::System.Drawing.Size(854, 486);
			this.TabWindow.TabIndex = 0;
			this.tabPage1.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new global::System.Drawing.Size(846, 460);
			this.tabPage1.TabIndex = 1;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage1.Click += new global::System.EventHandler(this.tabPage1_Click);
			this.tabPage2.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new global::System.Drawing.Size(846, 460);
			this.tabPage2.TabIndex = 2;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.tabPage2.Click += new global::System.EventHandler(this.tabPage2_Click);
			this.tabPage3.Location = new global::System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new global::System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new global::System.Drawing.Size(846, 460);
			this.tabPage3.TabIndex = 3;
			this.tabPage3.Text = "tabPage3";
			this.tabPage3.UseVisualStyleBackColor = true;
			this.LaunchButton.Location = new global::System.Drawing.Point(239, 510);
			this.LaunchButton.Name = "LaunchButton";
			this.LaunchButton.Size = new global::System.Drawing.Size(400, 56);
			this.LaunchButton.TabIndex = 1;
			this.LaunchButton.Text = "Save and Quit";
			this.LaunchButton.UseVisualStyleBackColor = true;
			this.LaunchButton.Click += new global::System.EventHandler(this.LaunchButton_Click);
			this.SaveButton.Location = new global::System.Drawing.Point(16, 510);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new global::System.Drawing.Size(217, 56);
			this.SaveButton.TabIndex = 2;
			this.SaveButton.Text = "Save";
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new global::System.EventHandler(this.SaveButton_Click);
			this.CancelConfigButton.Location = new global::System.Drawing.Point(645, 510);
			this.CancelConfigButton.Name = "CancelConfigButton";
			this.CancelConfigButton.Size = new global::System.Drawing.Size(217, 56);
			this.CancelConfigButton.TabIndex = 3;
			this.CancelConfigButton.Text = "Cancel";
			this.CancelConfigButton.UseVisualStyleBackColor = true;
			this.CancelConfigButton.Click += new global::System.EventHandler(this.CancelButton_Click);
			this.InputConfig.AutoScroll = true;
			this.InputConfig.Location = new global::System.Drawing.Point(4, 22);
			this.InputConfig.Name = "InputConfig";
			this.InputConfig.Padding = new global::System.Windows.Forms.Padding(3);
			this.InputConfig.Size = new global::System.Drawing.Size(846, 460);
			this.InputConfig.TabIndex = 0;
			this.InputConfig.Text = "tabPage1";
			this.InputConfig.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			base.ClientSize = new global::System.Drawing.Size(878, 578);
			base.Controls.Add(this.CancelConfigButton);
			base.Controls.Add(this.SaveButton);
			base.Controls.Add(this.LaunchButton);
			base.Controls.Add(this.TabWindow);
			base.Name = "MainForm";
			this.Text = "MainForm";
			base.Load += new global::System.EventHandler(this.MainForm_Load);
			this.TabWindow.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.TabControl TabWindow;

		private global::System.Windows.Forms.TabPage tabPage1;

		private global::System.Windows.Forms.Button LaunchButton;

		private global::System.Windows.Forms.Button SaveButton;

		private global::System.Windows.Forms.TabPage tabPage2;

		private global::System.Windows.Forms.Button CancelConfigButton;

		private global::System.Windows.Forms.TabPage tabPage3;

		private global::System.Windows.Forms.TabPage InputConfig;
	}
}
