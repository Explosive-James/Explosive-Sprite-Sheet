namespace ExplosiveSpriteSheet
{
    partial class ExplosiveSpriteSheet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplosiveSpriteSheet));
            this.imagesDisplay = new System.Windows.Forms.ListBox();
            this.openFiles = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.gridSizeX = new System.Windows.Forms.TextBox();
            this.gridSizeY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.saveImage = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.removeImage = new System.Windows.Forms.Button();
            this.moveUp = new System.Windows.Forms.Button();
            this.moveDown = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.warningLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // imagesDisplay
            // 
            this.imagesDisplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.imagesDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imagesDisplay.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imagesDisplay.ForeColor = System.Drawing.Color.White;
            this.imagesDisplay.FormattingEnabled = true;
            this.imagesDisplay.ItemHeight = 19;
            this.imagesDisplay.Location = new System.Drawing.Point(12, 12);
            this.imagesDisplay.Name = "imagesDisplay";
            this.imagesDisplay.Size = new System.Drawing.Size(215, 268);
            this.imagesDisplay.TabIndex = 0;
            // 
            // openFiles
            // 
            this.openFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.openFiles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openFiles.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openFiles.ForeColor = System.Drawing.Color.White;
            this.openFiles.Location = new System.Drawing.Point(238, 39);
            this.openFiles.Name = "openFiles";
            this.openFiles.Size = new System.Drawing.Size(162, 30);
            this.openFiles.TabIndex = 1;
            this.openFiles.Text = "Open Images";
            this.openFiles.UseVisualStyleBackColor = false;
            this.openFiles.Click += new System.EventHandler(this.OpenFiles_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            // 
            // gridSizeX
            // 
            this.gridSizeX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridSizeX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridSizeX.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSizeX.ForeColor = System.Drawing.Color.White;
            this.gridSizeX.Location = new System.Drawing.Point(267, 180);
            this.gridSizeX.MaxLength = 4;
            this.gridSizeX.Name = "gridSizeX";
            this.gridSizeX.Size = new System.Drawing.Size(46, 26);
            this.gridSizeX.TabIndex = 2;
            this.gridSizeX.Text = "1";
            this.gridSizeX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gridSizeX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GridSizeX_KeyPress);
            this.gridSizeX.Leave += new System.EventHandler(this.GridSizeX_Leave);
            // 
            // gridSizeY
            // 
            this.gridSizeY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gridSizeY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gridSizeY.Font = new System.Drawing.Font("DejaVu Sans Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSizeY.ForeColor = System.Drawing.Color.White;
            this.gridSizeY.Location = new System.Drawing.Point(352, 180);
            this.gridSizeY.MaxLength = 4;
            this.gridSizeY.Name = "gridSizeY";
            this.gridSizeY.Size = new System.Drawing.Size(46, 26);
            this.gridSizeY.TabIndex = 3;
            this.gridSizeY.Text = "1";
            this.gridSizeY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gridSizeY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GridSizeY_KeyPress);
            this.gridSizeY.Leave += new System.EventHandler(this.GridSizeY_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(234, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Grid Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(234, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(320, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y:";
            // 
            // saveImage
            // 
            this.saveImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.saveImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveImage.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveImage.ForeColor = System.Drawing.Color.White;
            this.saveImage.Location = new System.Drawing.Point(238, 250);
            this.saveImage.Name = "saveImage";
            this.saveImage.Size = new System.Drawing.Size(162, 30);
            this.saveImage.TabIndex = 7;
            this.saveImage.Text = "Save Image";
            this.saveImage.UseVisualStyleBackColor = false;
            this.saveImage.Click += new System.EventHandler(this.SaveImage_Click);
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.Red;
            this.progressBar.Location = new System.Drawing.Point(12, 286);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(388, 23);
            this.progressBar.Step = 1;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 8;
            // 
            // removeImage
            // 
            this.removeImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.removeImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.removeImage.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeImage.ForeColor = System.Drawing.Color.White;
            this.removeImage.Location = new System.Drawing.Point(238, 111);
            this.removeImage.Name = "removeImage";
            this.removeImage.Size = new System.Drawing.Size(162, 30);
            this.removeImage.TabIndex = 9;
            this.removeImage.Text = "Remove Image";
            this.removeImage.UseVisualStyleBackColor = false;
            this.removeImage.Click += new System.EventHandler(this.RemoveImage_Click);
            // 
            // moveUp
            // 
            this.moveUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.moveUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.moveUp.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveUp.ForeColor = System.Drawing.Color.White;
            this.moveUp.Location = new System.Drawing.Point(238, 75);
            this.moveUp.Name = "moveUp";
            this.moveUp.Size = new System.Drawing.Size(75, 30);
            this.moveUp.TabIndex = 10;
            this.moveUp.Text = "Up";
            this.moveUp.UseVisualStyleBackColor = false;
            this.moveUp.Click += new System.EventHandler(this.MoveUp_Click);
            // 
            // moveDown
            // 
            this.moveDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.moveDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.moveDown.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveDown.ForeColor = System.Drawing.Color.White;
            this.moveDown.Location = new System.Drawing.Point(325, 75);
            this.moveDown.Name = "moveDown";
            this.moveDown.Size = new System.Drawing.Size(75, 30);
            this.moveDown.TabIndex = 11;
            this.moveDown.Text = "Down";
            this.moveDown.UseVisualStyleBackColor = false;
            this.moveDown.Click += new System.EventHandler(this.MoveDown_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("DejaVu Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(234, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "Image Settings";
            // 
            // warningLable
            // 
            this.warningLable.AutoSize = true;
            this.warningLable.Font = new System.Drawing.Font("DejaVu Sans", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLable.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.warningLable.Location = new System.Drawing.Point(235, 213);
            this.warningLable.Name = "warningLable";
            this.warningLable.Size = new System.Drawing.Size(73, 15);
            this.warningLable.TabIndex = 13;
            this.warningLable.Text = "Warning:";
            // 
            // ExplosiveSpriteSheet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(412, 317);
            this.Controls.Add(this.warningLable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.moveDown);
            this.Controls.Add(this.moveUp);
            this.Controls.Add(this.removeImage);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.saveImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridSizeY);
            this.Controls.Add(this.gridSizeX);
            this.Controls.Add(this.openFiles);
            this.Controls.Add(this.imagesDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ExplosiveSpriteSheet";
            this.ShowIcon = false;
            this.Text = "Explosive Sprite Sheet";
            this.Load += new System.EventHandler(this.ExplosiveSpriteSheet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox imagesDisplay;
        private System.Windows.Forms.Button openFiles;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox gridSizeX;
        private System.Windows.Forms.TextBox gridSizeY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button saveImage;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button removeImage;
        private System.Windows.Forms.Button moveUp;
        private System.Windows.Forms.Button moveDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label warningLable;
    }
}

