namespace AwsConfiguratorApp.Forms
{
    partial class RequirementsForm
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
            this.wizardControl1 = new Syncfusion.Windows.Forms.Tools.WizardControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wizardContainer1 = new Syncfusion.Windows.Forms.Tools.WizardContainer();
            this.wizardControlPage1 = new Syncfusion.Windows.Forms.Tools.WizardControlPage(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1.GridBagLayout)).BeginInit();
            this.wizardControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.wizardContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControlPage1)).BeginInit();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            // 
            // 
            // 
            this.wizardControl1.BackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardControl1.BackButton.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.wizardControl1.BackButton.IsBackStageButton = false;
            this.wizardControl1.BackButton.Location = new System.Drawing.Point(333, 468);
            this.wizardControl1.BackButton.Name = "backButton";
            this.wizardControl1.BackButton.Text = "<< Back";
            this.wizardControl1.Banner = null;
            this.wizardControl1.BannerPanel = this.gradientPanel1;
            // 
            // 
            // 
            this.wizardControl1.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardControl1.CancelButton.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.wizardControl1.CancelButton.IsBackStageButton = false;
            this.wizardControl1.CancelButton.Location = new System.Drawing.Point(488, 468);
            this.wizardControl1.CancelButton.Name = "cancelButton";
            this.wizardControl1.CancelButton.Text = "Cancel";
            this.wizardControl1.Controls.Add(this.wizardContainer1);
            this.wizardControl1.Controls.Add(this.gradientPanel1);
            this.wizardControl1.Description = null;
            // 
            // 
            // 
            this.wizardControl1.FinishButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardControl1.FinishButton.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.wizardControl1.FinishButton.IsBackStageButton = false;
            this.wizardControl1.FinishButton.Location = new System.Drawing.Point(488, 468);
            this.wizardControl1.FinishButton.Name = "finishButton";
            this.wizardControl1.FinishButton.Text = "Finish";
            this.wizardControl1.FinishButton.Visible = false;
            // 
            // 
            // 
            this.wizardControl1.GridBagLayout.ContainerControl = this.wizardControl1;
            // 
            // 
            // 
            this.wizardControl1.HelpButton.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.wizardControl1.HelpButton.IsBackStageButton = false;
            this.wizardControl1.HelpButton.Location = new System.Drawing.Point(568, 468);
            this.wizardControl1.HelpButton.Name = "helpButton";
            this.wizardControl1.HelpButton.Text = "Help";
            this.wizardControl1.Location = new System.Drawing.Point(13, 13);
            this.wizardControl1.Name = "wizardControl1";
            // 
            // 
            // 
            this.wizardControl1.NextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.wizardControl1.NextButton.BeforeTouchSize = new System.Drawing.Size(75, 23);
            this.wizardControl1.NextButton.IsBackStageButton = false;
            this.wizardControl1.NextButton.Location = new System.Drawing.Point(408, 468);
            this.wizardControl1.NextButton.Name = "nextButton";
            this.wizardControl1.NextButton.Text = "Next >>";
            this.wizardControl1.SelectedWizardPage = this.wizardControlPage1;
            this.wizardControl1.Size = new System.Drawing.Size(648, 496);
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Title = null;
            this.wizardControl1.WizardPageContainer = this.wizardContainer1;
            this.wizardControl1.WizardPages = new Syncfusion.Windows.Forms.Tools.WizardControlPage[] {
        this.wizardControlPage1};
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(61, 61);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Controls.Add(this.pictureBox1);
            this.gradientPanel1.Controls.Add(this.label1);
            this.gradientPanel1.Controls.Add(this.label2);
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(648, 70);
            this.gradientPanel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "This is the title of the Wizard Page.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(206, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "This is the description of the Wizard Page.";
            // 
            // wizardContainer1
            // 
            this.wizardContainer1.Controls.Add(this.wizardControlPage1);
            this.wizardContainer1.Location = new System.Drawing.Point(0, 70);
            this.wizardContainer1.Name = "wizardContainer1";
            this.wizardContainer1.Size = new System.Drawing.Size(648, 385);
            this.wizardContainer1.TabIndex = 1;
            // 
            // wizardControlPage1
            // 
            this.wizardControlPage1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wizardControlPage1.Description = "This is the description of the Wizard Page";
            this.wizardControlPage1.FullPage = false;
            this.wizardControlPage1.LayoutName = "Card1";
            this.wizardControlPage1.Location = new System.Drawing.Point(0, 0);
            this.wizardControlPage1.Name = "wizardControlPage1";
            this.wizardControlPage1.NextPage = null;
            this.wizardControlPage1.PreviousPage = null;
            this.wizardControlPage1.Size = new System.Drawing.Size(648, 385);
            this.wizardControlPage1.TabIndex = 0;
            this.wizardControlPage1.Title = "Page Title";
            // 
            // RequirementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 517);
            this.Controls.Add(this.wizardControl1);
            this.Name = "RequirementsForm";
            this.Text = "RequirementsForm";
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1.GridBagLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.wizardControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.gradientPanel1.PerformLayout();
            this.wizardContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControlPage1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.WizardControl wizardControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.WizardContainer wizardContainer1;
        private Syncfusion.Windows.Forms.Tools.WizardControlPage wizardControlPage1;
    }
}