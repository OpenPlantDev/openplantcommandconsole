namespace OpenPlantCommandConsole
    {
    partial class ProcessManager
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
            if(disposing && (components != null))
                {
                components.Dispose ();
                }
            base.Dispose (disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessManager));
            this.buttonKill = new System.Windows.Forms.Button();
            this.buttonDone = new System.Windows.Forms.Button();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonPop = new System.Windows.Forms.Button();
            this.treeViewProcess = new System.Windows.Forms.TreeView();
            this.buttonMin = new System.Windows.Forms.Button();
            this.buttonRestore = new System.Windows.Forms.Button();
            this.checkBoxPrompt = new System.Windows.Forms.CheckBox();
            this.textBoxTimer = new System.Windows.Forms.TextBox();
            this.checkBoxTimer = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonKill
            // 
            this.buttonKill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonKill.BackColor = System.Drawing.Color.LightGray;
            this.buttonKill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKill.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonKill.Location = new System.Drawing.Point(6, 81);
            this.buttonKill.Name = "buttonKill";
            this.buttonKill.Size = new System.Drawing.Size(45, 28);
            this.buttonKill.TabIndex = 0;
            this.buttonKill.Text = "Kill";
            this.buttonKill.UseVisualStyleBackColor = false;
            this.buttonKill.Click += new System.EventHandler(this.buttonKillAction_Click);
            // 
            // buttonDone
            // 
            this.buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDone.Location = new System.Drawing.Point(296, 81);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(45, 28);
            this.buttonDone.TabIndex = 6;
            this.buttonDone.Text = "Done";
            this.buttonDone.UseVisualStyleBackColor = true;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // buttonSelect
            // 
            this.buttonSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSelect.Location = new System.Drawing.Point(186, 81);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(58, 28);
            this.buttonSelect.TabIndex = 4;
            this.buttonSelect.Text = "Check";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRefresh.Location = new System.Drawing.Point(244, 81);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(52, 28);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonPop
            // 
            this.buttonPop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPop.BackColor = System.Drawing.Color.LightGray;
            this.buttonPop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonPop.Location = new System.Drawing.Point(51, 81);
            this.buttonPop.Name = "buttonPop";
            this.buttonPop.Size = new System.Drawing.Size(45, 28);
            this.buttonPop.TabIndex = 1;
            this.buttonPop.Text = "Pop";
            this.buttonPop.UseVisualStyleBackColor = false;
            this.buttonPop.Click += new System.EventHandler(this.buttonPop_Click);
            // 
            // treeViewProcess
            // 
            this.treeViewProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewProcess.CheckBoxes = true;
            this.treeViewProcess.HideSelection = false;
            this.treeViewProcess.Location = new System.Drawing.Point(1, 11);
            this.treeViewProcess.Name = "treeViewProcess";
            this.treeViewProcess.Size = new System.Drawing.Size(445, 64);
            this.treeViewProcess.TabIndex = 10;
            this.treeViewProcess.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewProcess_AfterCheck);
            this.treeViewProcess.DoubleClick += new System.EventHandler(this.treeViewProcess_DoubleClick);
            // 
            // buttonMin
            // 
            this.buttonMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonMin.BackColor = System.Drawing.Color.LightGray;
            this.buttonMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonMin.Location = new System.Drawing.Point(96, 81);
            this.buttonMin.Name = "buttonMin";
            this.buttonMin.Size = new System.Drawing.Size(45, 28);
            this.buttonMin.TabIndex = 2;
            this.buttonMin.Text = "Min";
            this.buttonMin.UseVisualStyleBackColor = false;
            this.buttonMin.Click += new System.EventHandler(this.buttonMin_Click);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRestore.BackColor = System.Drawing.Color.LightGray;
            this.buttonRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRestore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonRestore.Location = new System.Drawing.Point(141, 81);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(45, 28);
            this.buttonRestore.TabIndex = 3;
            this.buttonRestore.Text = "Back";
            this.buttonRestore.UseVisualStyleBackColor = false;
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            // 
            // checkBoxPrompt
            // 
            this.checkBoxPrompt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxPrompt.AutoSize = true;
            this.checkBoxPrompt.Location = new System.Drawing.Point(356, 81);
            this.checkBoxPrompt.Name = "checkBoxPrompt";
            this.checkBoxPrompt.Size = new System.Drawing.Size(90, 17);
            this.checkBoxPrompt.TabIndex = 7;
            this.checkBoxPrompt.Text = "Prompt for Kill";
            this.checkBoxPrompt.UseVisualStyleBackColor = true;
            // 
            // textBoxTimer
            // 
            this.textBoxTimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxTimer.Location = new System.Drawing.Point(41, 201);
            this.textBoxTimer.Name = "textBoxTimer";
            this.textBoxTimer.Size = new System.Drawing.Size(54, 20);
            this.textBoxTimer.TabIndex = 9;
            this.textBoxTimer.Text = "100000";
            this.textBoxTimer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTimer_KeyDown);
            // 
            // checkBoxTimer
            // 
            this.checkBoxTimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxTimer.AutoSize = true;
            this.checkBoxTimer.Checked = true;
            this.checkBoxTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTimer.Location = new System.Drawing.Point(-63, 201);
            this.checkBoxTimer.Name = "checkBoxTimer";
            this.checkBoxTimer.Size = new System.Drawing.Size(98, 17);
            this.checkBoxTimer.TabIndex = 8;
            this.checkBoxTimer.Text = "Timer Intervals:";
            this.checkBoxTimer.UseVisualStyleBackColor = true;
            // 
            // ProcessManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 118);
            this.Controls.Add(this.checkBoxTimer);
            this.Controls.Add(this.textBoxTimer);
            this.Controls.Add(this.checkBoxPrompt);
            this.Controls.Add(this.buttonRestore);
            this.Controls.Add(this.buttonMin);
            this.Controls.Add(this.treeViewProcess);
            this.Controls.Add(this.buttonPop);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.buttonDone);
            this.Controls.Add(this.buttonKill);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(466, 157);
            this.Name = "ProcessManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cmd Process Manager (Double click to Pop)";
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Button buttonKill;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonPop;
        private System.Windows.Forms.TreeView treeViewProcess;
        private System.Windows.Forms.Button buttonMin;
        private System.Windows.Forms.Button buttonRestore;
        private System.Windows.Forms.CheckBox checkBoxPrompt;
        private System.Windows.Forms.TextBox textBoxTimer;
        private System.Windows.Forms.CheckBox checkBoxTimer;
        }
    }