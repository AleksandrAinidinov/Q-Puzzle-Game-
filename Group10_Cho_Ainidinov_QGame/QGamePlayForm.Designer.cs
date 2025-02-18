namespace Group10_Cho_Ainidinov_QGame
{
    partial class QGamePlayForm
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
            panel1 = new Panel();
            textBoxNumberOfBoxes = new TextBox();
            textBoxNumberOfMoves = new TextBox();
            buttonLoad = new Button();
            labelNumberOfBoxes = new Label();
            labelNumberOfMoves = new Label();
            label1 = new Label();
            panel2 = new Panel();
            buttonRight = new Button();
            buttonLeft = new Button();
            buttonDown = new Button();
            buttonUp = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBoxNumberOfBoxes);
            panel1.Controls.Add(textBoxNumberOfMoves);
            panel1.Controls.Add(buttonLoad);
            panel1.Controls.Add(labelNumberOfBoxes);
            panel1.Controls.Add(labelNumberOfMoves);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(827, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(211, 379);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // textBoxNumberOfBoxes
            // 
            textBoxNumberOfBoxes.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBoxNumberOfBoxes.Location = new Point(69, 258);
            textBoxNumberOfBoxes.Multiline = true;
            textBoxNumberOfBoxes.Name = "textBoxNumberOfBoxes";
            textBoxNumberOfBoxes.ReadOnly = true;
            textBoxNumberOfBoxes.Size = new Size(75, 32);
            textBoxNumberOfBoxes.TabIndex = 10;
            textBoxNumberOfBoxes.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxNumberOfMoves
            // 
            textBoxNumberOfMoves.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            textBoxNumberOfMoves.Location = new Point(72, 176);
            textBoxNumberOfMoves.Multiline = true;
            textBoxNumberOfMoves.Name = "textBoxNumberOfMoves";
            textBoxNumberOfMoves.ReadOnly = true;
            textBoxNumberOfMoves.Size = new Size(75, 32);
            textBoxNumberOfMoves.TabIndex = 9;
            textBoxNumberOfMoves.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonLoad
            // 
            buttonLoad.ForeColor = SystemColors.WindowText;
            buttonLoad.Location = new Point(69, 45);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(82, 67);
            buttonLoad.TabIndex = 8;
            buttonLoad.Text = "Load";
            buttonLoad.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // labelNumberOfBoxes
            // 
            labelNumberOfBoxes.AutoSize = true;
            labelNumberOfBoxes.BackColor = SystemColors.Window;
            labelNumberOfBoxes.ForeColor = SystemColors.WindowText;
            labelNumberOfBoxes.Location = new Point(56, 240);
            labelNumberOfBoxes.Name = "labelNumberOfBoxes";
            labelNumberOfBoxes.Size = new Size(102, 15);
            labelNumberOfBoxes.TabIndex = 2;
            labelNumberOfBoxes.Text = "Number of Boxes:";
            // 
            // labelNumberOfMoves
            // 
            labelNumberOfMoves.AutoSize = true;
            labelNumberOfMoves.BackColor = SystemColors.Window;
            labelNumberOfMoves.ForeColor = SystemColors.WindowText;
            labelNumberOfMoves.Location = new Point(56, 158);
            labelNumberOfMoves.Name = "labelNumberOfMoves";
            labelNumberOfMoves.Size = new Size(106, 15);
            labelNumberOfMoves.TabIndex = 1;
            labelNumberOfMoves.Text = "Number of Moves:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Window;
            label1.Font = new Font("Segoe UI Black", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.ForeColor = SystemColors.WindowText;
            label1.Location = new Point(41, 7);
            label1.Name = "label1";
            label1.Size = new Size(139, 25);
            label1.TabIndex = 0;
            label1.Text = "Control Panel";
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(buttonRight);
            panel2.Controls.Add(buttonLeft);
            panel2.Controls.Add(buttonDown);
            panel2.Controls.Add(buttonUp);
            panel2.Location = new Point(827, 386);
            panel2.Name = "panel2";
            panel2.Size = new Size(211, 244);
            panel2.TabIndex = 1;
            panel2.Click += buttonRight_Click;
            panel2.Paint += panel2_Paint;
            // 
            // buttonRight
            // 
            buttonRight.Location = new Point(140, 93);
            buttonRight.Name = "buttonRight";
            buttonRight.Size = new Size(50, 50);
            buttonRight.TabIndex = 3;
            buttonRight.UseVisualStyleBackColor = true;
            buttonRight.Click += buttonRight_Click;
            // 
            // buttonLeft
            // 
            buttonLeft.Location = new Point(28, 93);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(50, 50);
            buttonLeft.TabIndex = 2;
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += buttonLeft_Click;
            // 
            // buttonDown
            // 
            buttonDown.Location = new Point(84, 139);
            buttonDown.Name = "buttonDown";
            buttonDown.Size = new Size(50, 50);
            buttonDown.TabIndex = 1;
            buttonDown.UseVisualStyleBackColor = true;
            buttonDown.Click += buttonDown_Click;
            // 
            // buttonUp
            // 
            buttonUp.Location = new Point(84, 47);
            buttonUp.Name = "buttonUp";
            buttonUp.Size = new Size(50, 50);
            buttonUp.TabIndex = 0;
            buttonUp.UseVisualStyleBackColor = true;
            buttonUp.Click += buttonUp_Click;
            // 
            // QGamePlayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowText;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1041, 631);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlLightLight;
            Name = "QGamePlayForm";
            Text = "QGamePlayForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label labelNumberOfBoxes;
        private Label labelNumberOfMoves;
        private Label label1;
        private Panel panel2;
        private TextBox textBoxNumberOfBoxes;
        private TextBox textBoxNumberOfMoves;
        private Button buttonLoad;
        private Button buttonRight;
        private Button buttonLeft;
        private Button buttonDown;
        private Button buttonUp;
    }
}