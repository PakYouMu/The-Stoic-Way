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
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)TimerButton).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // TimerButton
            // 
            resources.ApplyResources(TimerButton, "TimerButton");
            TimerButton.BackColor = Color.Transparent;
            TimerButton.BackgroundImage = Properties.Resources.wall_clock__1_;
            TimerButton.Name = "TimerButton";
            TimerButton.TabStop = false;
            TimerButton.Click += pictureBox1_Click;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            // 
            // TheStoicWay
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(121, 81, 169);
            Controls.Add(pictureBox1);
            Controls.Add(TimerButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "TheStoicWay";
            FormClosing += TheStoicWay_FormClosing;
            Load += TheStoicWay_Load;
            ((System.ComponentModel.ISupportInitialize)TimerButton).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox TimerButton;
        private PictureBox pictureBox1;
    }
}