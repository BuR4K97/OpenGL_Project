namespace OpenGL_Project.ProjectAssignment3
{
    partial class CameraControl
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
            this._zoomTrack = new System.Windows.Forms.TrackBar();
            this._rotateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._zoomTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // _zoomTrack
            // 
            this._zoomTrack.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this._zoomTrack.Location = new System.Drawing.Point(3, 13);
            this._zoomTrack.Name = "_zoomTrack";
            this._zoomTrack.Size = new System.Drawing.Size(195, 56);
            this._zoomTrack.TabIndex = 0;
            this._zoomTrack.Value = 5;
            this._zoomTrack.Scroll += new System.EventHandler(this.ZoomTrackScroll);
            // 
            // _rotateButton
            // 
            this._rotateButton.Font = new System.Drawing.Font("Calibri", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this._rotateButton.ForeColor = System.Drawing.Color.Black;
            this._rotateButton.Location = new System.Drawing.Point(3, 75);
            this._rotateButton.Name = "_rotateButton";
            this._rotateButton.Size = new System.Drawing.Size(314, 35);
            this._rotateButton.TabIndex = 1;
            this._rotateButton.Text = "Rotate";
            this._rotateButton.UseVisualStyleBackColor = true;
            this._rotateButton.Click += new System.EventHandler(this.RotateButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(204, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Zoom In/Out";
            // 
            // CameraControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this.label1);
            this.Controls.Add(this._rotateButton);
            this.Controls.Add(this._zoomTrack);
            this.Name = "CameraControl";
            this.Size = new System.Drawing.Size(320, 121);
            ((System.ComponentModel.ISupportInitialize)(this._zoomTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar _zoomTrack;
        private System.Windows.Forms.Button _rotateButton;
        private System.Windows.Forms.Label label1;
    }
}
