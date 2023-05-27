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
            ((System.ComponentModel.ISupportInitialize)TimerButton).BeginInit();
            SuspendLayout();
            // 
            // TimerButton
            // 
            resources.ApplyResources(TimerButton, "TimerButton");
            TimerButton.BackColor = Color.Transparent;
            TimerButton.BackgroundImage = Properties.Resources.wall_clock__1_;
            TimerButton.Name = "TimerButton";
            TimerButton.TabStop = false;
            // 
            // QuoteLabel
            // 
            resources.ApplyResources(QuoteLabel, "QuoteLabel");
            QuoteLabel.Name = "QuoteLabel";
            // 
            // TheStoicWay
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(147, 159, 135);
            Controls.Add(QuoteLabel);
            Controls.Add(TimerButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "TheStoicWay";
            FormClosing += TheStoicWay_FormClosing;
            Load += TheStoicWay_Load;
            ((System.ComponentModel.ISupportInitialize)TimerButton).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox TimerButton;
        private Label QuoteLabel;
    }
}