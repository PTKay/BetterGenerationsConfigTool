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
            this.TabWindow = new System.Windows.Forms.TabControl();
            this.InputConfig = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.QuitConfigButton = new System.Windows.Forms.Button();
            this.TabWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabWindow
            // 
            this.TabWindow.Controls.Add(this.InputConfig);
            this.TabWindow.Controls.Add(this.tabPage1);
            this.TabWindow.Controls.Add(this.tabPage2);
            this.TabWindow.Controls.Add(this.tabPage3);
            this.TabWindow.Controls.Add(this.tabPage4);
            this.TabWindow.Location = new System.Drawing.Point(12, 12);
            this.TabWindow.Name = "TabWindow";
            this.TabWindow.SelectedIndex = 0;
            this.TabWindow.Size = new System.Drawing.Size(854, 486);
            this.TabWindow.TabIndex = 0;
            // 
            // InputConfig
            // 
            this.InputConfig.AutoScroll = true;
            this.InputConfig.Location = new System.Drawing.Point(4, 22);
            this.InputConfig.Name = "InputConfig";
            this.InputConfig.Padding = new System.Windows.Forms.Padding(3);
            this.InputConfig.Size = new System.Drawing.Size(846, 460);
            this.InputConfig.TabIndex = 0;
            this.InputConfig.Text = "tabPage1";
            this.InputConfig.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(846, 460);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(846, 460);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(846, 460);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage3";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(846, 460);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // LaunchButton
            // 
            this.LaunchButton.Location = new System.Drawing.Point(239, 510);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(400, 56);
            this.LaunchButton.TabIndex = 1;
            this.LaunchButton.UseVisualStyleBackColor = true;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(16, 510);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(217, 56);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelConfigButton
            // 
            this.QuitConfigButton.Location = new System.Drawing.Point(645, 510);
            this.QuitConfigButton.Name = "QuitConfigButton";
            this.QuitConfigButton.Size = new System.Drawing.Size(217, 56);
            this.QuitConfigButton.TabIndex = 3;
            this.QuitConfigButton.UseVisualStyleBackColor = true;
            this.QuitConfigButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(878, 578);
            this.Controls.Add(this.QuitConfigButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.TabWindow);
            this.Icon = global::Generations_Launcher_Front.Properties.Resources.SystemTray;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabWindow.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		private global::System.ComponentModel.IContainer components;

		private global::System.Windows.Forms.TabControl TabWindow;

		private global::System.Windows.Forms.TabPage tabPage1;

		private global::System.Windows.Forms.Button LaunchButton;

		private global::System.Windows.Forms.Button SaveButton;

		private global::System.Windows.Forms.TabPage tabPage2;

		private global::System.Windows.Forms.Button QuitConfigButton;

		private global::System.Windows.Forms.TabPage tabPage3;

		private global::System.Windows.Forms.TabPage tabPage4;
		
		private global::System.Windows.Forms.TabPage InputConfig;
	}
}
