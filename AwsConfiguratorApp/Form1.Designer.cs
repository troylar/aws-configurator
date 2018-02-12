namespace AwsConfiguratorApp
{
    partial class mainForm
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
            Syncfusion.Windows.Forms.Tools.TreeNodeAdvStyleInfo treeNodeAdvStyleInfo2 = new Syncfusion.Windows.Forms.Tools.TreeNodeAdvStyleInfo();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.profileNameListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.awsKeyTextBox = new System.Windows.Forms.TextBox();
            this.awsSecretAccessKeyIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.regionComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkSoftwareVersion = new System.Windows.Forms.Button();
            this.installedVersionLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.latestVersionLabel = new System.Windows.Forms.Label();
            this.installButton = new System.Windows.Forms.Button();
            this.uninstallButton = new System.Windows.Forms.Button();
            this.lastCheckedLabel = new System.Windows.Forms.Label();
            this.pollyTreeView = new Syncfusion.Windows.Forms.Tools.TreeViewAdv();
            this.previewText = new System.Windows.Forms.TextBox();
            this.playSampleButton = new System.Windows.Forms.Button();
            this.nowPlayingText = new System.Windows.Forms.Label();
            this.selectedVoiceLabel = new System.Windows.Forms.Label();
            this.toggleVoiceButton = new System.Windows.Forms.Button();
            this.removeAllButton = new System.Windows.Forms.Button();
            this.addAllVoicesButton = new System.Windows.Forms.Button();
            this.applyChangesButton = new System.Windows.Forms.Button();
            this.resetSelectionsButton = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pollyTreeView)).BeginInit();
            this.SuspendLayout();
            // 
            // profileNameListBox
            // 
            this.profileNameListBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileNameListBox.FormattingEnabled = true;
            this.profileNameListBox.ItemHeight = 19;
            this.profileNameListBox.Location = new System.Drawing.Point(15, 25);
            this.profileNameListBox.Name = "profileNameListBox";
            this.profileNameListBox.Size = new System.Drawing.Size(197, 194);
            this.profileNameListBox.TabIndex = 0;
            this.profileNameListBox.SelectedIndexChanged += new System.EventHandler(this.profileNameListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(215, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "AWS Key:";
            // 
            // awsKeyTextBox
            // 
            this.awsKeyTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.awsKeyTextBox.Location = new System.Drawing.Point(218, 46);
            this.awsKeyTextBox.Name = "awsKeyTextBox";
            this.awsKeyTextBox.Size = new System.Drawing.Size(226, 27);
            this.awsKeyTextBox.TabIndex = 2;
            // 
            // awsSecretAccessKeyIdTextBox
            // 
            this.awsSecretAccessKeyIdTextBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.awsSecretAccessKeyIdTextBox.Location = new System.Drawing.Point(218, 106);
            this.awsSecretAccessKeyIdTextBox.Name = "awsSecretAccessKeyIdTextBox";
            this.awsSecretAccessKeyIdTextBox.Size = new System.Drawing.Size(337, 27);
            this.awsSecretAccessKeyIdTextBox.TabIndex = 4;
            this.awsSecretAccessKeyIdTextBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(215, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "AWS Secret Access Key Id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(215, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Region:";
            // 
            // regionComboBox
            // 
            this.regionComboBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.regionComboBox.FormattingEnabled = true;
            this.regionComboBox.Items.AddRange(new object[] {
            "No Region Specified",
            "us-east-1 - US East (N. Virginia)",
            "us-east-2 - US East (Ohio)",
            "us-west-1 - US West (N. California)",
            "us-west-2 - US West (Oregon)",
            "ca-central-1 - Canada (Central)",
            "eu-central-1 - EU (Frankfurt)",
            "eu-west-1 - EU (Ireland)",
            "eu-west-2 - EU (London)",
            "eu-west-3 - EU (Paris)",
            "ap-northeast-1 - Asia Pacific (Tokyo)",
            "ap-northeast-2 - Asia Pacific (Seoul)",
            "ap-southeast-1 - Asia Pacific (Singapore)",
            "ap-southeast-2 - Asia Pacific (Sydney)",
            "ap-south-1 - Asia Pacific (Mumbai)",
            "sa-east-1 - South America (São Paulo)"});
            this.regionComboBox.Location = new System.Drawing.Point(218, 165);
            this.regionComboBox.Name = "regionComboBox";
            this.regionComboBox.Size = new System.Drawing.Size(337, 27);
            this.regionComboBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(330, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Installed Version:";
            // 
            // checkSoftwareVersion
            // 
            this.checkSoftwareVersion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkSoftwareVersion.Location = new System.Drawing.Point(240, 265);
            this.checkSoftwareVersion.Name = "checkSoftwareVersion";
            this.checkSoftwareVersion.Size = new System.Drawing.Size(146, 29);
            this.checkSoftwareVersion.TabIndex = 8;
            this.checkSoftwareVersion.Text = "Check Software";
            this.checkSoftwareVersion.UseVisualStyleBackColor = true;
            this.checkSoftwareVersion.Click += new System.EventHandler(this.checkSoftwareVersion_Click);
            // 
            // installedVersionLabel
            // 
            this.installedVersionLabel.AutoSize = true;
            this.installedVersionLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installedVersionLabel.Location = new System.Drawing.Point(452, 219);
            this.installedVersionLabel.Name = "installedVersionLabel";
            this.installedVersionLabel.Size = new System.Drawing.Size(92, 19);
            this.installedVersionLabel.TabIndex = 9;
            this.installedVersionLabel.Text = "Not installed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(330, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "Latest Version:";
            // 
            // latestVersionLabel
            // 
            this.latestVersionLabel.AutoSize = true;
            this.latestVersionLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.latestVersionLabel.Location = new System.Drawing.Point(452, 240);
            this.latestVersionLabel.Name = "latestVersionLabel";
            this.latestVersionLabel.Size = new System.Drawing.Size(33, 19);
            this.latestVersionLabel.TabIndex = 11;
            this.latestVersionLabel.Text = "N/A";
            // 
            // installButton
            // 
            this.installButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installButton.Location = new System.Drawing.Point(392, 265);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(146, 29);
            this.installButton.TabIndex = 12;
            this.installButton.Text = "Upgrade";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // uninstallButton
            // 
            this.uninstallButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uninstallButton.Location = new System.Drawing.Point(544, 265);
            this.uninstallButton.Name = "uninstallButton";
            this.uninstallButton.Size = new System.Drawing.Size(146, 29);
            this.uninstallButton.TabIndex = 13;
            this.uninstallButton.Text = "Uninstall";
            this.uninstallButton.UseVisualStyleBackColor = true;
            this.uninstallButton.Click += new System.EventHandler(this.uninstallButton_Click);
            // 
            // lastCheckedLabel
            // 
            this.lastCheckedLabel.AutoSize = true;
            this.lastCheckedLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastCheckedLabel.Location = new System.Drawing.Point(237, 297);
            this.lastCheckedLabel.Name = "lastCheckedLabel";
            this.lastCheckedLabel.Size = new System.Drawing.Size(137, 19);
            this.lastCheckedLabel.TabIndex = 14;
            this.lastCheckedLabel.Text = "Last checked: Never";
            // 
            // pollyTreeView
            // 
            treeNodeAdvStyleInfo2.EnsureDefaultOptionedChild = true;
            treeNodeAdvStyleInfo2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNodeAdvStyleInfo2.InteractiveCheckBox = true;
            treeNodeAdvStyleInfo2.ShowCheckBox = true;
            this.pollyTreeView.BaseStylePairs.AddRange(new Syncfusion.Windows.Forms.Tools.StyleNamePair[] {
            new Syncfusion.Windows.Forms.Tools.StyleNamePair("Standard", treeNodeAdvStyleInfo2)});
            this.pollyTreeView.BeforeTouchSize = new System.Drawing.Size(200, 360);
            this.pollyTreeView.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // 
            // 
            this.pollyTreeView.HelpTextControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pollyTreeView.HelpTextControl.Location = new System.Drawing.Point(0, 0);
            this.pollyTreeView.HelpTextControl.Name = "helpText";
            this.pollyTreeView.HelpTextControl.Size = new System.Drawing.Size(49, 15);
            this.pollyTreeView.HelpTextControl.TabIndex = 0;
            this.pollyTreeView.HelpTextControl.Text = "help text";
            this.pollyTreeView.InactiveSelectedNodeForeColor = System.Drawing.SystemColors.ControlText;
            this.pollyTreeView.InteractiveCheckBoxes = true;
            this.pollyTreeView.Location = new System.Drawing.Point(12, 343);
            this.pollyTreeView.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.pollyTreeView.Name = "pollyTreeView";
            this.pollyTreeView.SelectedNodeForeColor = System.Drawing.SystemColors.HighlightText;
            this.pollyTreeView.SelectionMode = Syncfusion.Windows.Forms.Tools.TreeSelectionMode.MultiSelectAll;
            this.pollyTreeView.SelectOnCollapse = false;
            this.pollyTreeView.ShowCheckBoxes = true;
            this.pollyTreeView.Size = new System.Drawing.Size(200, 360);
            this.pollyTreeView.SortWithChildNodes = true;
            this.pollyTreeView.TabIndex = 15;
            this.pollyTreeView.Text = "pollyTreeViewAdv";
            // 
            // 
            // 
            this.pollyTreeView.ToolTipControl.BackColor = System.Drawing.SystemColors.Info;
            this.pollyTreeView.ToolTipControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pollyTreeView.ToolTipControl.Location = new System.Drawing.Point(0, 0);
            this.pollyTreeView.ToolTipControl.Name = "toolTip";
            this.pollyTreeView.ToolTipControl.Size = new System.Drawing.Size(41, 15);
            this.pollyTreeView.ToolTipControl.TabIndex = 1;
            this.pollyTreeView.ToolTipControl.Text = "toolTip";
            this.pollyTreeView.Click += new System.EventHandler(this.pollyTreeView_Click);
            // 
            // previewText
            // 
            this.previewText.Enabled = false;
            this.previewText.Location = new System.Drawing.Point(218, 390);
            this.previewText.Multiline = true;
            this.previewText.Name = "previewText";
            this.previewText.Size = new System.Drawing.Size(471, 114);
            this.previewText.TabIndex = 16;
            // 
            // playSampleButton
            // 
            this.playSampleButton.Enabled = false;
            this.playSampleButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playSampleButton.Location = new System.Drawing.Point(543, 510);
            this.playSampleButton.Name = "playSampleButton";
            this.playSampleButton.Size = new System.Drawing.Size(146, 29);
            this.playSampleButton.TabIndex = 17;
            this.playSampleButton.Text = "Play Sample";
            this.playSampleButton.UseVisualStyleBackColor = true;
            this.playSampleButton.Click += new System.EventHandler(this.playSampleButton_Click);
            // 
            // nowPlayingText
            // 
            this.nowPlayingText.AutoSize = true;
            this.nowPlayingText.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nowPlayingText.Location = new System.Drawing.Point(223, 364);
            this.nowPlayingText.Name = "nowPlayingText";
            this.nowPlayingText.Size = new System.Drawing.Size(107, 19);
            this.nowPlayingText.TabIndex = 18;
            this.nowPlayingText.Text = "Selected Voice:";
            // 
            // selectedVoiceLabel
            // 
            this.selectedVoiceLabel.AutoSize = true;
            this.selectedVoiceLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedVoiceLabel.Location = new System.Drawing.Point(330, 364);
            this.selectedVoiceLabel.Name = "selectedVoiceLabel";
            this.selectedVoiceLabel.Size = new System.Drawing.Size(46, 19);
            this.selectedVoiceLabel.TabIndex = 19;
            this.selectedVoiceLabel.Text = "None";
            // 
            // toggleVoiceButton
            // 
            this.toggleVoiceButton.Enabled = false;
            this.toggleVoiceButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleVoiceButton.Location = new System.Drawing.Point(219, 510);
            this.toggleVoiceButton.Name = "toggleVoiceButton";
            this.toggleVoiceButton.Size = new System.Drawing.Size(146, 29);
            this.toggleVoiceButton.TabIndex = 20;
            this.toggleVoiceButton.Text = "I Want This Voice";
            this.toggleVoiceButton.UseVisualStyleBackColor = true;
            this.toggleVoiceButton.Click += new System.EventHandler(this.toggleVoiceButton_Click);
            // 
            // removeAllButton
            // 
            this.removeAllButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeAllButton.Location = new System.Drawing.Point(218, 616);
            this.removeAllButton.Name = "removeAllButton";
            this.removeAllButton.Size = new System.Drawing.Size(146, 29);
            this.removeAllButton.TabIndex = 21;
            this.removeAllButton.Text = Resources.Resources.HideAllVoices;
            this.removeAllButton.UseVisualStyleBackColor = true;
            this.removeAllButton.Click += new System.EventHandler(this.removeAllButton_Click);
            // 
            // addAllVoicesButton
            // 
            this.addAllVoicesButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAllVoicesButton.Location = new System.Drawing.Point(218, 581);
            this.addAllVoicesButton.Name = "addAllVoicesButton";
            this.addAllVoicesButton.Size = new System.Drawing.Size(146, 29);
            this.addAllVoicesButton.TabIndex = 22;
            this.addAllVoicesButton.Text = Resources.Resources.ShowAllVoices;
            this.addAllVoicesButton.UseVisualStyleBackColor = true;
            this.addAllVoicesButton.Click += new System.EventHandler(this.addAllVoicesButton_Click);
            // 
            // applyChangesButton
            // 
            this.applyChangesButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyChangesButton.Location = new System.Drawing.Point(392, 616);
            this.applyChangesButton.Name = "applyChangesButton";
            this.applyChangesButton.Size = new System.Drawing.Size(298, 29);
            this.applyChangesButton.TabIndex = 23;
            this.applyChangesButton.Text = "Apply Changes";
            this.applyChangesButton.UseVisualStyleBackColor = true;
            this.applyChangesButton.Click += new System.EventHandler(this.applyChangesButton_Click);
            // 
            // resetSelectionsButton
            // 
            this.resetSelectionsButton.Enabled = false;
            this.resetSelectionsButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetSelectionsButton.Location = new System.Drawing.Point(219, 651);
            this.resetSelectionsButton.Name = "resetSelectionsButton";
            this.resetSelectionsButton.Size = new System.Drawing.Size(146, 29);
            this.resetSelectionsButton.TabIndex = 24;
            this.resetSelectionsButton.Text = "Reset Selections";
            this.resetSelectionsButton.UseVisualStyleBackColor = true;
            this.resetSelectionsButton.Click += new System.EventHandler(this.resetSelectionsButton_Click);
            // 
            // versionLabel
            // 
            this.versionLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(544, 705);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(153, 15);
            this.versionLabel.TabIndex = 25;
            this.versionLabel.Text = "N/A";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 729);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.resetSelectionsButton);
            this.Controls.Add(this.applyChangesButton);
            this.Controls.Add(this.addAllVoicesButton);
            this.Controls.Add(this.removeAllButton);
            this.Controls.Add(this.toggleVoiceButton);
            this.Controls.Add(this.selectedVoiceLabel);
            this.Controls.Add(this.nowPlayingText);
            this.Controls.Add(this.playSampleButton);
            this.Controls.Add(this.previewText);
            this.Controls.Add(this.pollyTreeView);
            this.Controls.Add(this.profileNameListBox);
            this.Controls.Add(this.lastCheckedLabel);
            this.Controls.Add(this.uninstallButton);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.latestVersionLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.installedVersionLabel);
            this.Controls.Add(this.checkSoftwareVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.regionComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.awsSecretAccessKeyIdTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.awsKeyTextBox);
            this.Controls.Add(this.label1);
            this.Name = "mainForm";
            this.Text = "AWS Polly EZ Config";
            this.Load += new System.EventHandler(this.mainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pollyTreeView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox profileNameListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox awsKeyTextBox;
        private System.Windows.Forms.TextBox awsSecretAccessKeyIdTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox regionComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button checkSoftwareVersion;
        private System.Windows.Forms.Label installedVersionLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label latestVersionLabel;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button uninstallButton;
        private System.Windows.Forms.Label lastCheckedLabel;
        private Syncfusion.Windows.Forms.Tools.TreeViewAdv pollyTreeView;
        private System.Windows.Forms.TextBox previewText;
        private System.Windows.Forms.Button playSampleButton;
        private System.Windows.Forms.Label nowPlayingText;
        private System.Windows.Forms.Label selectedVoiceLabel;
        private System.Windows.Forms.Button toggleVoiceButton;
        private System.Windows.Forms.Button removeAllButton;
        private System.Windows.Forms.Button addAllVoicesButton;
        private System.Windows.Forms.Button applyChangesButton;
        private System.Windows.Forms.Button resetSelectionsButton;
        private System.Windows.Forms.Label versionLabel;
    }
}

