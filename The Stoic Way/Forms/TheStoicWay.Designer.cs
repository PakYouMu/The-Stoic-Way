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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheStoicWay));
            TimerButton = new PictureBox();
            QuoteLabel = new Label();
            ResetButton = new PictureBox();
            PauseButton = new PictureBox();
            WorkTimer = new MaskedTextBox();
            RestButton = new PictureBox();
            RestTimer = new MaskedTextBox();
            WorkTimeLabel = new Label();
            RestTimeLabel = new Label();
            WorkTime = new Label();
            RestTime = new Label();
            ((System.ComponentModel.ISupportInitialize)TimerButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ResetButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PauseButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RestButton).BeginInit();
            SuspendLayout();
            // 
            // TimerButton
            // 
            resources.ApplyResources(TimerButton, "TimerButton");
            TimerButton.BackColor = Color.Transparent;
            TimerButton.BackgroundImage = Properties.Resources.alarm_clock__1_;
            TimerButton.Name = "TimerButton";
            TimerButton.TabStop = false;
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
            // 
            // WorkTimer
            // 
            resources.ApplyResources(WorkTimer, "WorkTimer");
            WorkTimer.Name = "WorkTimer";
            // 
            // RestButton
            // 
            resources.ApplyResources(RestButton, "RestButton");
            RestButton.BackgroundImage = Properties.Resources.dancing;
            RestButton.Name = "RestButton";
            RestButton.TabStop = false;
            // 
            // RestTimer
            // 
            resources.ApplyResources(RestTimer, "RestTimer");
            RestTimer.Name = "RestTimer";
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
            // WorkTime
            // 
            resources.ApplyResources(WorkTime, "WorkTime");
            WorkTime.Name = "WorkTime";
            // 
            // RestTime
            // 
            resources.ApplyResources(RestTime, "RestTime");
            RestTime.Name = "RestTime";
            // 
            // TheStoicWay
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(147, 159, 135);
            Controls.Add(RestTime);
            Controls.Add(WorkTime);
            Controls.Add(RestTimeLabel);
            Controls.Add(WorkTimeLabel);
            Controls.Add(RestTimer);
            Controls.Add(RestButton);
            Controls.Add(WorkTimer);
            Controls.Add(PauseButton);
            Controls.Add(ResetButton);
            Controls.Add(QuoteLabel);
            Controls.Add(TimerButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "TheStoicWay";
            SizeGripStyle = SizeGripStyle.Show;
            FormClosing += TheStoicWay_FormClosing;
            Load += TheStoicWay_Load;
            ((System.ComponentModel.ISupportInitialize)TimerButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)ResetButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)PauseButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)RestButton).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox TimerButton;
        private Label QuoteLabel;
        private PictureBox ResetButton;
        private PictureBox PauseButton;
        private MaskedTextBox WorkTimer;
        private PictureBox RestButton;
        private MaskedTextBox RestTimer;
        private Label WorkTimeLabel;
        private Label RestTimeLabel;
        private Label WorkTime;
        private Label RestTime;
    }
}