namespace Group10_Cho_Ainidinov_QGame
{
    partial class Group10_Cho_Ainidinov_QGame
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
            buttonDesign = new Button();
            buttonPlay = new Button();
            buttonExit = new Button();
            labelTitle = new Label();
            SuspendLayout();
            // 
            // buttonDesign
            // 
            buttonDesign.BackColor = Color.Blue;
            buttonDesign.Font = new Font("MS Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonDesign.ForeColor = Color.FromArgb(128, 255, 255);
            buttonDesign.Location = new Point(107, 256);
            buttonDesign.Name = "buttonDesign";
            buttonDesign.Size = new Size(226, 128);
            buttonDesign.TabIndex = 0;
            buttonDesign.Text = "Design";
            buttonDesign.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonDesign.UseVisualStyleBackColor = false;
            buttonDesign.Click += buttonDesign_Click;
            // 
            // buttonPlay
            // 
            buttonPlay.BackColor = Color.Red;
            buttonPlay.Font = new Font("MS Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonPlay.ForeColor = Color.Yellow;
            buttonPlay.Location = new Point(594, 256);
            buttonPlay.Name = "buttonPlay";
            buttonPlay.Size = new Size(226, 128);
            buttonPlay.TabIndex = 1;
            buttonPlay.Text = "Play";
            buttonPlay.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonPlay.UseVisualStyleBackColor = false;
            buttonPlay.Click += buttonPlay_Click;
            // 
            // buttonExit
            // 
            buttonExit.Font = new Font("MS Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExit.Location = new Point(353, 425);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(226, 128);
            buttonExit.TabIndex = 2;
            buttonExit.Text = "Exit";
            buttonExit.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // labelTitle
            // 
            labelTitle.BackColor = Color.Black;
            labelTitle.Font = new Font("Bernard MT Condensed", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.ForeColor = Color.FromArgb(0, 192, 0);
            labelTitle.Location = new Point(206, 52);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(521, 104);
            labelTitle.TabIndex = 3;
            labelTitle.Text = "QGAME";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Group10_Cho_Ainidinov_QGame
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Resource.i_stock_1287493837_1;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(958, 595);
            Controls.Add(labelTitle);
            Controls.Add(buttonExit);
            Controls.Add(buttonPlay);
            Controls.Add(buttonDesign);
            Name = "Group10_Cho_Ainidinov_QGame";
            Text = "Group10_Cho_Ainidinov_QGame";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonDesign;
        private Button buttonPlay;
        private Button buttonExit;
        private Label labelTitle;
    }
}
