namespace OpenPlantCommandConsole
{
    partial class TabPageCommandListView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CommandListViewControl = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // CommandListViewControl
            // 
            this.CommandListViewControl.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.CommandListViewControl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.CommandListViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommandListViewControl.HoverSelection = true;
            this.CommandListViewControl.Location = new System.Drawing.Point(0, 0);
            this.CommandListViewControl.MultiSelect = false;
            this.CommandListViewControl.Name = "CommandListViewControl";
            this.CommandListViewControl.ShowItemToolTips = true;
            this.CommandListViewControl.Size = new System.Drawing.Size(150, 150);
            this.CommandListViewControl.TabIndex = 0;
            this.CommandListViewControl.UseCompatibleStateImageBehavior = false;
            this.CommandListViewControl.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.CommandListViewControl_HelpRequested);
            // 
            // TabPageCommandListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CommandListViewControl);
            this.Name = "TabPageCommandListView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView CommandListViewControl;
    }
}
