using System.Windows.Forms;
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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources =
				new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.TabWindow = new System.Windows.Forms.TabControl();
			this.InputConfig = new System.Windows.Forms.TabPage();
			this.GraphicsConfig = new System.Windows.Forms.TabPage();
			this.StatsConfig = new System.Windows.Forms.TabPage();
			this.AudioConfig = new System.Windows.Forms.TabPage();
			this.AdvancedConfig = new System.Windows.Forms.TabPage();
			this.LaunchButton = new System.Windows.Forms.Button();
			this.SaveButton = new System.Windows.Forms.Button();
			this.QuitConfigButton = new System.Windows.Forms.Button();
			this.TabWindow.SuspendLayout();
			this.SuspendLayout();
			// 
			// TabWindow
			// 
			this.TabWindow.Controls.Add(this.InputConfig);
			this.TabWindow.Controls.Add(this.GraphicsConfig);
			this.TabWindow.Controls.Add(this.StatsConfig);
			this.TabWindow.Controls.Add(this.AudioConfig);
			this.TabWindow.Controls.Add(this.AdvancedConfig);
			this.TabWindow.Location = new System.Drawing.Point(14, 14);
			this.TabWindow.Name = "TabWindow";
			this.TabWindow.SelectedIndex = 0;
			this.TabWindow.Size = new System.Drawing.Size(996, 561);
			this.TabWindow.TabIndex = 0;
			// 
			// InputConfig
			// 
			this.InputConfig.AutoScroll = true;
			this.InputConfig.Location = new System.Drawing.Point(4, 24);
			this.InputConfig.Name = "InputConfig";
			this.InputConfig.Padding = new System.Windows.Forms.Padding(3);
			this.InputConfig.Size = new System.Drawing.Size(988, 533);
			this.InputConfig.TabIndex = 0;
			this.InputConfig.Text = "tabPage1";
			this.InputConfig.UseVisualStyleBackColor = true;
			// 
			// GraphicsConfig
			// 
			this.GraphicsConfig.Location = new System.Drawing.Point(4, 22);
			this.GraphicsConfig.Name = "GraphicsConfig";
			this.GraphicsConfig.Padding = new System.Windows.Forms.Padding(3);
			this.GraphicsConfig.Size = new System.Drawing.Size(988, 535);
			this.GraphicsConfig.TabIndex = 1;
			this.GraphicsConfig.Text = "tabPage2";
			this.GraphicsConfig.UseVisualStyleBackColor = true;
			// 
			// StatsConfig
			// 
			this.StatsConfig.Location = new System.Drawing.Point(4, 22);
			this.StatsConfig.Name = "StatsConfig";
			this.StatsConfig.Padding = new System.Windows.Forms.Padding(3);
			this.StatsConfig.Size = new System.Drawing.Size(988, 535);
			this.StatsConfig.TabIndex = 2;
			this.StatsConfig.Text = "tabPage3";
			this.StatsConfig.UseVisualStyleBackColor = true;
			// 
			// AudioConfig
			// 
			this.AudioConfig.Location = new System.Drawing.Point(4, 22);
			this.AudioConfig.Name = "AudioConfig";
			this.AudioConfig.Padding = new System.Windows.Forms.Padding(3);
			this.AudioConfig.Size = new System.Drawing.Size(988, 535);
			this.AudioConfig.TabIndex = 3;
			this.AudioConfig.Text = "tabPage4";
			this.AudioConfig.UseVisualStyleBackColor = true;
			// 
			// AdvancedConfig
			// 
			this.AdvancedConfig.Location = new System.Drawing.Point(4, 22);
			this.AdvancedConfig.Name = "AdvancedConfig";
			this.AdvancedConfig.Padding = new System.Windows.Forms.Padding(3);
			this.AdvancedConfig.Size = new System.Drawing.Size(988, 535);
			this.AdvancedConfig.TabIndex = 4;
			this.AdvancedConfig.Text = "tabPage5";
			this.AdvancedConfig.UseVisualStyleBackColor = true;
			// 
			// LaunchButton
			// 
			this.LaunchButton.Location = new System.Drawing.Point(279, 588);
			this.LaunchButton.Name = "LaunchButton";
			this.LaunchButton.Size = new System.Drawing.Size(467, 65);
			this.LaunchButton.TabIndex = 1;
			this.LaunchButton.UseVisualStyleBackColor = true;
			this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
			// 
			// SaveButton
			// 
			this.SaveButton.Location = new System.Drawing.Point(19, 588);
			this.SaveButton.Name = "SaveButton";
			this.SaveButton.Size = new System.Drawing.Size(253, 65);
			this.SaveButton.TabIndex = 2;
			this.SaveButton.UseVisualStyleBackColor = true;
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			// 
			// QuitConfigButton
			// 
			this.QuitConfigButton.Location = new System.Drawing.Point(752, 588);
			this.QuitConfigButton.Name = "QuitConfigButton";
			this.QuitConfigButton.Size = new System.Drawing.Size(253, 65);
			this.QuitConfigButton.TabIndex = 3;
			this.QuitConfigButton.UseVisualStyleBackColor = true;
			this.QuitConfigButton.Click += new System.EventHandler(this.QuitButton_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1024, 667);
			this.Controls.Add(this.QuitConfigButton);
			this.Controls.Add(this.SaveButton);
			this.Controls.Add(this.LaunchButton);
			this.Controls.Add(this.TabWindow);
			this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.TabWindow.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		private global::System.ComponentModel.IContainer components;
		private System.Windows.Forms.TabPage InputConfig;
		private System.Windows.Forms.TabPage AdvancedConfig;
		private System.Windows.Forms.TabPage AudioConfig;
		private System.Windows.Forms.Button QuitConfigButton;
		private System.Windows.Forms.TabPage StatsConfig;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button LaunchButton;
		private System.Windows.Forms.TabPage GraphicsConfig;
		private System.Windows.Forms.TabControl TabWindow;
	}
}
