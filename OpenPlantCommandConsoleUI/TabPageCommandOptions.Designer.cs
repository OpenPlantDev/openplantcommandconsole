namespace OpenPlantCommandConsole
    {
    partial class TabPageCommandOptions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
            {
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxAllowSingleClick = new System.Windows.Forms.CheckBox();
            this.groupBoxOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.checkBoxAllowSingleClick);
            this.groupBoxOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxOptions.Location = new System.Drawing.Point(0, 0);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(403, 226);
            this.groupBoxOptions.TabIndex = 0;
            this.groupBoxOptions.TabStop = false;
            // 
            // checkBoxAllowSingleClick
            // 
            this.checkBoxAllowSingleClick.AutoSize = true;
            this.checkBoxAllowSingleClick.Location = new System.Drawing.Point(25, 30);
            this.checkBoxAllowSingleClick.Name = "checkBoxAllowSingleClick";
            this.checkBoxAllowSingleClick.Size = new System.Drawing.Size(131, 17);
            this.checkBoxAllowSingleClick.TabIndex = 0;
            this.checkBoxAllowSingleClick.Text = "Command Single Click";
            this.checkBoxAllowSingleClick.UseVisualStyleBackColor = true;
            // 
            // TabPageCommandOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxOptions);
            this.Name = "TabPageCommandOptions";
            this.Size = new System.Drawing.Size(403, 226);
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox checkBoxAllowSingleClick;
        }
    }
