namespace Group10_Cho_Ainidinov_QGame
{
    partial class QGameDesignForm
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
            labelToolBox = new Label();
            panel1 = new Panel();
            buttonSave = new Button();
            buttonLoad = new Button();
            buttonExit = new Button();
            buttonGenerate = new Button();
            comboBoxColumns = new ComboBox();
            labelColumns = new Label();
            comboBoxRows = new ComboBox();
            labelRows = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            buttonBlueBox = new Button();
            buttonGreenBox = new Button();
            buttonRedBox = new Button();
            buttonBlueDoor = new Button();
            buttonGreenDoor = new Button();
            buttonRedDoor = new Button();
            buttonWall = new Button();
            buttonNone = new Button();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // labelToolBox
            // 
            labelToolBox.AutoSize = true;
            labelToolBox.BackColor = Color.White;
            labelToolBox.Location = new Point(29, 16);
            labelToolBox.Name = "labelToolBox";
            labelToolBox.Size = new Size(49, 15);
            labelToolBox.TabIndex = 0;
            labelToolBox.Text = "ToolBox";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(buttonSave);
            panel1.Controls.Add(buttonLoad);
            panel1.Controls.Add(buttonExit);
            panel1.Controls.Add(buttonGenerate);
            panel1.Controls.Add(comboBoxColumns);
            panel1.Controls.Add(labelColumns);
            panel1.Controls.Add(comboBoxRows);
            panel1.Controls.Add(labelRows);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1099, 75);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(607, 3);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(82, 67);
            buttonSave.TabIndex = 8;
            buttonSave.Text = "Save";
            buttonSave.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonLoad
            // 
            buttonLoad.Location = new Point(503, 3);
            buttonLoad.Name = "buttonLoad";
            buttonLoad.Size = new Size(82, 67);
            buttonLoad.TabIndex = 7;
            buttonLoad.Text = "Load";
            buttonLoad.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonLoad.UseVisualStyleBackColor = true;
            buttonLoad.Click += buttonLoad_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(775, 3);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(82, 67);
            buttonExit.TabIndex = 6;
            buttonExit.Text = "Exit";
            buttonExit.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += buttonExit_Click;
            // 
            // buttonGenerate
            // 
            buttonGenerate.BackColor = SystemColors.ControlLightLight;
            buttonGenerate.Location = new Point(317, 3);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(82, 67);
            buttonGenerate.TabIndex = 5;
            buttonGenerate.Text = "Generate";
            buttonGenerate.TextImageRelation = TextImageRelation.ImageAboveText;
            buttonGenerate.UseVisualStyleBackColor = false;
            buttonGenerate.Click += buttonGenerate_Click;
            // 
            // comboBoxColumns
            // 
            comboBoxColumns.FormattingEnabled = true;
            comboBoxColumns.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" });
            comboBoxColumns.Location = new Point(214, 14);
            comboBoxColumns.Name = "comboBoxColumns";
            comboBoxColumns.Size = new Size(61, 23);
            comboBoxColumns.TabIndex = 4;
            comboBoxColumns.SelectedIndexChanged += comboBoxColumns_SelectedIndexChanged;
            // 
            // labelColumns
            // 
            labelColumns.AutoSize = true;
            labelColumns.Location = new Point(150, 17);
            labelColumns.Name = "labelColumns";
            labelColumns.Size = new Size(58, 15);
            labelColumns.TabIndex = 3;
            labelColumns.Text = "Columns:";
            // 
            // comboBoxRows
            // 
            comboBoxRows.FormattingEnabled = true;
            comboBoxRows.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15" });
            comboBoxRows.Location = new Point(56, 14);
            comboBoxRows.Name = "comboBoxRows";
            comboBoxRows.Size = new Size(61, 23);
            comboBoxRows.TabIndex = 2;
            comboBoxRows.SelectedIndexChanged += comboBoxRows_SelectedIndexChanged;
            // 
            // labelRows
            // 
            labelRows.AutoSize = true;
            labelRows.Location = new Point(10, 17);
            labelRows.Name = "labelRows";
            labelRows.Size = new Size(38, 15);
            labelRows.TabIndex = 1;
            labelRows.Text = "Rows:";
            // 
            // panel2
            // 
            panel2.Location = new Point(3, 71);
            panel2.Name = "panel2";
            panel2.Size = new Size(114, 477);
            panel2.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(buttonBlueBox);
            panel3.Controls.Add(buttonGreenBox);
            panel3.Controls.Add(buttonRedBox);
            panel3.Controls.Add(buttonBlueDoor);
            panel3.Controls.Add(buttonGreenDoor);
            panel3.Controls.Add(buttonRedDoor);
            panel3.Controls.Add(buttonWall);
            panel3.Controls.Add(buttonNone);
            panel3.Controls.Add(labelToolBox);
            panel3.Location = new Point(1, 73);
            panel3.Name = "panel3";
            panel3.Size = new Size(123, 673);
            panel3.TabIndex = 2;
            panel3.Paint += panel3_Paint;
            // 
            // buttonBlueBox
            // 
            buttonBlueBox.Location = new Point(10, 426);
            buttonBlueBox.Name = "buttonBlueBox";
            buttonBlueBox.Size = new Size(99, 47);
            buttonBlueBox.TabIndex = 8;
            buttonBlueBox.Text = "Blue Box";
            buttonBlueBox.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonBlueBox.UseVisualStyleBackColor = true;
            buttonBlueBox.Click += buttonBlueBox_Click;
            // 
            // buttonGreenBox
            // 
            buttonGreenBox.Location = new Point(10, 371);
            buttonGreenBox.Name = "buttonGreenBox";
            buttonGreenBox.Size = new Size(99, 47);
            buttonGreenBox.TabIndex = 7;
            buttonGreenBox.Text = "Green Box";
            buttonGreenBox.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonGreenBox.UseVisualStyleBackColor = true;
            buttonGreenBox.Click += buttonGreenBox_Click;
            // 
            // buttonRedBox
            // 
            buttonRedBox.Location = new Point(10, 318);
            buttonRedBox.Name = "buttonRedBox";
            buttonRedBox.Size = new Size(99, 47);
            buttonRedBox.TabIndex = 6;
            buttonRedBox.Text = "Red Box";
            buttonRedBox.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonRedBox.UseVisualStyleBackColor = true;
            buttonRedBox.Click += buttonRedBox_Click;
            // 
            // buttonBlueDoor
            // 
            buttonBlueDoor.Location = new Point(12, 265);
            buttonBlueDoor.Name = "buttonBlueDoor";
            buttonBlueDoor.Size = new Size(99, 47);
            buttonBlueDoor.TabIndex = 5;
            buttonBlueDoor.Text = "Blue Door";
            buttonBlueDoor.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonBlueDoor.UseVisualStyleBackColor = true;
            buttonBlueDoor.Click += buttonBlueDoor_Click;
            // 
            // buttonGreenDoor
            // 
            buttonGreenDoor.Location = new Point(12, 212);
            buttonGreenDoor.Name = "buttonGreenDoor";
            buttonGreenDoor.Size = new Size(99, 47);
            buttonGreenDoor.TabIndex = 4;
            buttonGreenDoor.Text = "Green Door";
            buttonGreenDoor.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonGreenDoor.UseVisualStyleBackColor = true;
            buttonGreenDoor.Click += buttonGreenDoor_Click;
            // 
            // buttonRedDoor
            // 
            buttonRedDoor.Location = new Point(10, 156);
            buttonRedDoor.Name = "buttonRedDoor";
            buttonRedDoor.Size = new Size(99, 47);
            buttonRedDoor.TabIndex = 3;
            buttonRedDoor.Text = "Red Door";
            buttonRedDoor.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonRedDoor.UseVisualStyleBackColor = true;
            buttonRedDoor.Click += buttonRedDoor_Click;
            // 
            // buttonWall
            // 
            buttonWall.Location = new Point(12, 101);
            buttonWall.Name = "buttonWall";
            buttonWall.Size = new Size(99, 47);
            buttonWall.TabIndex = 2;
            buttonWall.Text = "Wall";
            buttonWall.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonWall.UseVisualStyleBackColor = true;
            buttonWall.Click += buttonWall_Click;
            // 
            // buttonNone
            // 
            buttonNone.Location = new Point(10, 47);
            buttonNone.Name = "buttonNone";
            buttonNone.Size = new Size(99, 47);
            buttonNone.TabIndex = 1;
            buttonNone.Text = "None";
            buttonNone.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonNone.UseVisualStyleBackColor = true;
            buttonNone.Click += buttonNone_Click;
            // 
            // QGameDesignForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 749);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "QGameDesignForm";
            Text = "QGameDesignForm";
            Load += QGameDesignForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label labelToolBox;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Button buttonGenerate;
        private ComboBox comboBoxColumns;
        private Label labelColumns;
        private ComboBox comboBoxRows;
        private Label labelRows;
        private Button buttonExit;
        private Button buttonBlueBox;
        private Button buttonGreenBox;
        private Button buttonRedBox;
        private Button buttonBlueDoor;
        private Button buttonGreenDoor;
        private Button buttonRedDoor;
        private Button buttonWall;
        private Button buttonNone;
        private Button buttonSave;
        private Button buttonLoad;
    }
}