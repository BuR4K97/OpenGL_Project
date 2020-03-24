namespace OpenGL_Project.ProjectAssignment3
{
    partial class ModelControl
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
            this._generateModelButton = new System.Windows.Forms.Button();
            this._xScaleTrack = new System.Windows.Forms.TrackBar();
            this._yScaleTrack = new System.Windows.Forms.TrackBar();
            this._zScaleTrack = new System.Windows.Forms.TrackBar();
            this._thetaParamTrack = new System.Windows.Forms.TrackBar();
            this._phiParamTrack = new System.Windows.Forms.TrackBar();
            this._xScaleLabel = new System.Windows.Forms.Label();
            this._yScaleLabel = new System.Windows.Forms.Label();
            this._zScaleLabel = new System.Windows.Forms.Label();
            this._thetaParamLabel = new System.Windows.Forms.Label();
            this._phiParamLabel = new System.Windows.Forms.Label();
            this._modelTypeList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this._xScaleTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._yScaleTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._zScaleTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._thetaParamTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._phiParamTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // _generateModelButton
            // 
            this._generateModelButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this._generateModelButton.Font = new System.Drawing.Font("Calibri", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this._generateModelButton.Location = new System.Drawing.Point(6, 377);
            this._generateModelButton.Name = "_generateModelButton";
            this._generateModelButton.Size = new System.Drawing.Size(307, 40);
            this._generateModelButton.TabIndex = 0;
            this._generateModelButton.Text = "Generate Model";
            this._generateModelButton.UseVisualStyleBackColor = false;
            this._generateModelButton.Click += new System.EventHandler(this.GenerateModelButtonClick);
            // 
            // _xScaleTrack
            // 
            this._xScaleTrack.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this._xScaleTrack.Location = new System.Drawing.Point(6, 67);
            this._xScaleTrack.Maximum = 25;
            this._xScaleTrack.Name = "_xScaleTrack";
            this._xScaleTrack.Size = new System.Drawing.Size(200, 56);
            this._xScaleTrack.TabIndex = 1;
            this._xScaleTrack.Value = 5;
            // 
            // _yScaleTrack
            // 
            this._yScaleTrack.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this._yScaleTrack.Location = new System.Drawing.Point(6, 129);
            this._yScaleTrack.Maximum = 25;
            this._yScaleTrack.Name = "_yScaleTrack";
            this._yScaleTrack.Size = new System.Drawing.Size(200, 56);
            this._yScaleTrack.TabIndex = 2;
            this._yScaleTrack.Value = 5;
            // 
            // _zScaleTrack
            // 
            this._zScaleTrack.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this._zScaleTrack.Location = new System.Drawing.Point(6, 191);
            this._zScaleTrack.Maximum = 25;
            this._zScaleTrack.Name = "_zScaleTrack";
            this._zScaleTrack.Size = new System.Drawing.Size(203, 56);
            this._zScaleTrack.TabIndex = 3;
            this._zScaleTrack.Value = 5;
            // 
            // _thetaParamTrack
            // 
            this._thetaParamTrack.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this._thetaParamTrack.Location = new System.Drawing.Point(6, 253);
            this._thetaParamTrack.Maximum = 25;
            this._thetaParamTrack.Name = "_thetaParamTrack";
            this._thetaParamTrack.Size = new System.Drawing.Size(203, 56);
            this._thetaParamTrack.TabIndex = 4;
            this._thetaParamTrack.Value = 3;
            // 
            // _phiParamTrack
            // 
            this._phiParamTrack.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this._phiParamTrack.Location = new System.Drawing.Point(6, 315);
            this._phiParamTrack.Maximum = 25;
            this._phiParamTrack.Name = "_phiParamTrack";
            this._phiParamTrack.Size = new System.Drawing.Size(203, 56);
            this._phiParamTrack.TabIndex = 5;
            this._phiParamTrack.Value = 1;
            // 
            // _xScaleLabel
            // 
            this._xScaleLabel.AutoSize = true;
            this._xScaleLabel.Font = new System.Drawing.Font("Calibri", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this._xScaleLabel.Location = new System.Drawing.Point(212, 76);
            this._xScaleLabel.Name = "_xScaleLabel";
            this._xScaleLabel.Size = new System.Drawing.Size(59, 21);
            this._xScaleLabel.TabIndex = 6;
            this._xScaleLabel.Text = "X Scale";
            // 
            // _yScaleLabel
            // 
            this._yScaleLabel.AutoSize = true;
            this._yScaleLabel.Font = new System.Drawing.Font("Calibri", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this._yScaleLabel.Location = new System.Drawing.Point(212, 138);
            this._yScaleLabel.Name = "_yScaleLabel";
            this._yScaleLabel.Size = new System.Drawing.Size(59, 21);
            this._yScaleLabel.TabIndex = 7;
            this._yScaleLabel.Text = "Y Scale";
            // 
            // _zScaleLabel
            // 
            this._zScaleLabel.AutoSize = true;
            this._zScaleLabel.Font = new System.Drawing.Font("Calibri", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this._zScaleLabel.Location = new System.Drawing.Point(212, 201);
            this._zScaleLabel.Name = "_zScaleLabel";
            this._zScaleLabel.Size = new System.Drawing.Size(58, 21);
            this._zScaleLabel.TabIndex = 8;
            this._zScaleLabel.Text = "Z Scale";
            // 
            // _thetaParamLabel
            // 
            this._thetaParamLabel.AutoSize = true;
            this._thetaParamLabel.Font = new System.Drawing.Font("Calibri", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this._thetaParamLabel.Location = new System.Drawing.Point(212, 263);
            this._thetaParamLabel.Name = "_thetaParamLabel";
            this._thetaParamLabel.Size = new System.Drawing.Size(101, 21);
            this._thetaParamLabel.TabIndex = 9;
            this._thetaParamLabel.Text = "Theta Param";
            // 
            // _phiParamLabel
            // 
            this._phiParamLabel.AutoSize = true;
            this._phiParamLabel.Font = new System.Drawing.Font("Calibri", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this._phiParamLabel.Location = new System.Drawing.Point(212, 324);
            this._phiParamLabel.Name = "_phiParamLabel";
            this._phiParamLabel.Size = new System.Drawing.Size(83, 21);
            this._phiParamLabel.TabIndex = 10;
            this._phiParamLabel.Text = "Phi Param";
            // 
            // _modelTypeList
            // 
            this._modelTypeList.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this._modelTypeList.Font = new System.Drawing.Font("Calibri", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this._modelTypeList.FormattingEnabled = true;
            this._modelTypeList.ItemHeight = 21;
            this._modelTypeList.Items.AddRange(new object[] {
            OpenGL_Project.ProjectAssignment3.GenerateModelEventArgs.ModelType.SuperquadricToroid,
            OpenGL_Project.ProjectAssignment3.GenerateModelEventArgs.ModelType.SuperquadricHyperboloid});
            this._modelTypeList.SelectedIndex = 0;
            this._modelTypeList.Location = new System.Drawing.Point(6, 12);
            this._modelTypeList.Name = "_modelTypeList";
            this._modelTypeList.Size = new System.Drawing.Size(307, 46);
            this._modelTypeList.TabIndex = 11;
            this._modelTypeList.SelectedValueChanged += new System.EventHandler(this.ModelTypeListValueChange);
            // 
            // ModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Controls.Add(this._modelTypeList);
            this.Controls.Add(this._phiParamLabel);
            this.Controls.Add(this._thetaParamLabel);
            this.Controls.Add(this._zScaleLabel);
            this.Controls.Add(this._yScaleLabel);
            this.Controls.Add(this._xScaleLabel);
            this.Controls.Add(this._phiParamTrack);
            this.Controls.Add(this._thetaParamTrack);
            this.Controls.Add(this._zScaleTrack);
            this.Controls.Add(this._yScaleTrack);
            this.Controls.Add(this._xScaleTrack);
            this.Controls.Add(this._generateModelButton);
            this.Name = "ModelControl";
            this.Size = new System.Drawing.Size(320, 427);
            ((System.ComponentModel.ISupportInitialize)(this._xScaleTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._yScaleTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._zScaleTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._thetaParamTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._phiParamTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _generateModelButton;
        private System.Windows.Forms.TrackBar _xScaleTrack;
        private System.Windows.Forms.TrackBar _yScaleTrack;
        private System.Windows.Forms.TrackBar _zScaleTrack;
        private System.Windows.Forms.TrackBar _thetaParamTrack;
        private System.Windows.Forms.TrackBar _phiParamTrack;
        private System.Windows.Forms.Label _xScaleLabel;
        private System.Windows.Forms.Label _yScaleLabel;
        private System.Windows.Forms.Label _zScaleLabel;
        private System.Windows.Forms.Label _thetaParamLabel;
        private System.Windows.Forms.Label _phiParamLabel;
        private System.Windows.Forms.ListBox _modelTypeList;
    }
}
