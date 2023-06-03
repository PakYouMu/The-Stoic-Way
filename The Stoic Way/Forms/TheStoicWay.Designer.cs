namespace The_Stoic_Way
{
    partial class TheStoicWay
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheStoicWay));
            QuoteLabel = new Label();
            ResetButton = new PictureBox();
            PauseButton = new PictureBox();
            WorkTime = new MaskedTextBox();
            RestButton = new PictureBox();
            RestTime = new MaskedTextBox();
            WorkTimeLabel = new Label();
            RestTimeLabel = new Label();
            WorkButton = new PictureBox();
            Logo = new PictureBox();
            WorkTimer = new System.Windows.Forms.Timer(components);
            RestTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)ResetButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PauseButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RestButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WorkButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Logo).BeginInit();
            SuspendLayout();
            // 
            // QuoteLabel
            // 
            resources.ApplyResources(QuoteLabel, "QuoteLabel");
            QuoteLabel.Name = "QuoteLabel";
            // 
            // ResetButton
            // 
            resources.ApplyResources(ResetButton, "ResetButton");
            ResetButton.BackgroundImage = Properties.Resources.undo_circular_arrow;
            ResetButton.Name = "ResetButton";
            ResetButton.TabStop = false;
            ResetButton.Click += ResetButton_Click;
            // 
            // PauseButton
            // 
            resources.ApplyResources(PauseButton, "PauseButton");
            PauseButton.BackgroundImage = Properties.Resources.pause__1_;
            PauseButton.Name = "PauseButton";
            PauseButton.TabStop = false;
            PauseButton.Click += PauseButton_Click;
            // 
            // WorkTime
            // 
            resources.ApplyResources(WorkTime, "WorkTime");
            WorkTime.Name = "WorkTime";
            WorkTime.Validating += WorkTime_Validating;
            // 
            // RestButton
            // 
            resources.ApplyResources(RestButton, "RestButton");
            RestButton.BackgroundImage = Properties.Resources.dancing;
            RestButton.Name = "RestButton";
            RestButton.TabStop = false;
            // 
            // RestTime
            // 
            resources.ApplyResources(RestTime, "RestTime");
            RestTime.Name = "RestTime";
            // 
            // WorkTimeLabel
            // 
            resources.ApplyResources(WorkTimeLabel, "WorkTimeLabel");
            WorkTimeLabel.Name = "WorkTimeLabel";
            // 
            // RestTimeLabel
            // 
            resources.ApplyResources(RestTimeLabel, "RestTimeLabel");
            RestTimeLabel.Name = "RestTimeLabel";
            // 
            // WorkButton
            // 
            resources.ApplyResources(WorkButton, "WorkButton");
            WorkButton.BackgroundImage = Properties.Resources.alarm_clock__1_;
            WorkButton.Name = "WorkButton";
            WorkButton.TabStop = false;
            WorkButton.Click += WorkButton_Click;
            // 
            // Logo
            // 
            resources.ApplyResources(Logo, "Logo");
            Logo.BackgroundImage = Properties.Resources.The_Stoic_Way_Logo;
            Logo.Name = "Logo";
            Logo.TabStop = false;
            Logo.Click += Logo_Click;
            // 
            // WorkTimer
            // 
            WorkTimer.Interval = 1000;
            WorkTimer.Tick += WorkTimer_Tick;
            // 
            // RestTimer
            // 
            RestTimer.Interval = 1000;
            RestTimer.Tick += RestTimer_Tick;
            // 
            // TheStoicWay
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(147, 159, 135);
            Controls.Add(Logo);
            Controls.Add(WorkButton);
            Controls.Add(RestTimeLabel);
            Controls.Add(WorkTimeLabel);
            Controls.Add(RestTime);
            Controls.Add(RestButton);
            Controls.Add(WorkTime);
            Controls.Add(PauseButton);
            Controls.Add(ResetButton);
            Controls.Add(QuoteLabel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "TheStoicWay";
            SizeGripStyle = SizeGripStyle.Show;
            FormClosing += TheStoicWay_FormClosing;
            Load += TheStoicWay_Load;
            ((System.ComponentModel.ISupportInitialize)ResetButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PauseButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)RestButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)WorkButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)Logo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label QuoteLabel;
        private PictureBox ResetButton;
        private PictureBox PauseButton;
        private MaskedTextBox WorkTime;
        private PictureBox RestButton;
        private MaskedTextBox RestTime;
        private Label WorkTimeLabel;
        private Label RestTimeLabel;
        private PictureBox WorkButton;
        private PictureBox Logo;
        private System.Windows.Forms.Timer WorkTimer;
        private System.Windows.Forms.Timer RestTimer;
    }
}