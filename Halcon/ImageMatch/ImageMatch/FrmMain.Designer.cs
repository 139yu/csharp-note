namespace ImageMatch
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.hWindow = new HalconDotNet.HWindowControl();
            this.pic_model = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_openImg = new System.Windows.Forms.Button();
            this.btn_shapeModelMatch = new System.Windows.Forms.Button();
            this.btn_nccModelMatch = new System.Windows.Forms.Button();
            this.fileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_createCircleROI = new System.Windows.Forms.Button();
            this.btn_createCircle2ROI = new System.Windows.Forms.Button();
            this.btn_createRectangleROI = new System.Windows.Forms.Button();
            this.btn_createRectangle2ROI = new System.Windows.Forms.Button();
            this.btn_createRegionROI = new System.Windows.Forms.Button();
            this.list_matchInfos = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_model)).BeginInit();
            this.SuspendLayout();
            // 
            // hWindow
            // 
            this.hWindow.BackColor = System.Drawing.Color.Black;
            this.hWindow.BorderColor = System.Drawing.Color.Black;
            this.hWindow.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hWindow.Location = new System.Drawing.Point(299, 92);
            this.hWindow.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.hWindow.Name = "hWindow";
            this.hWindow.Size = new System.Drawing.Size(585, 423);
            this.hWindow.TabIndex = 0;
            this.hWindow.WindowSize = new System.Drawing.Size(585, 423);
            // 
            // pic_model
            // 
            this.pic_model.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_model.Location = new System.Drawing.Point(40, 137);
            this.pic_model.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pic_model.Name = "pic_model";
            this.pic_model.Size = new System.Drawing.Size(157, 154);
            this.pic_model.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_model.TabIndex = 1;
            this.pic_model.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 103);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "模板：";
            // 
            // btn_openImg
            // 
            this.btn_openImg.Location = new System.Drawing.Point(299, 565);
            this.btn_openImg.Name = "btn_openImg";
            this.btn_openImg.Size = new System.Drawing.Size(100, 30);
            this.btn_openImg.TabIndex = 3;
            this.btn_openImg.Text = "打开图片";
            this.btn_openImg.UseVisualStyleBackColor = true;
            this.btn_openImg.Click += new System.EventHandler(this.btn_openImg_Click);
            // 
            // btn_shapeModelMatch
            // 
            this.btn_shapeModelMatch.Location = new System.Drawing.Point(546, 565);
            this.btn_shapeModelMatch.Name = "btn_shapeModelMatch";
            this.btn_shapeModelMatch.Size = new System.Drawing.Size(111, 30);
            this.btn_shapeModelMatch.TabIndex = 3;
            this.btn_shapeModelMatch.Text = "形状模型匹配";
            this.btn_shapeModelMatch.UseVisualStyleBackColor = true;
            this.btn_shapeModelMatch.Click += new System.EventHandler(this.btn_shapeModelMatch_Click);
            // 
            // btn_nccModelMatch
            // 
            this.btn_nccModelMatch.Location = new System.Drawing.Point(804, 565);
            this.btn_nccModelMatch.Name = "btn_nccModelMatch";
            this.btn_nccModelMatch.Size = new System.Drawing.Size(100, 30);
            this.btn_nccModelMatch.TabIndex = 3;
            this.btn_nccModelMatch.Text = "NCC匹配";
            this.btn_nccModelMatch.UseVisualStyleBackColor = true;
            this.btn_nccModelMatch.Click += new System.EventHandler(this.btn_nccModelMatch_Click);
            // 
            // fileDialog
            // 
            this.fileDialog.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "制作模板：";
            // 
            // btn_createCircleROI
            // 
            this.btn_createCircleROI.BackgroundImage = global::ImageMatch.Properties.Resources.circle1;
            this.btn_createCircleROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_createCircleROI.Location = new System.Drawing.Point(147, 13);
            this.btn_createCircleROI.Name = "btn_createCircleROI";
            this.btn_createCircleROI.Size = new System.Drawing.Size(50, 50);
            this.btn_createCircleROI.TabIndex = 5;
            this.btn_createCircleROI.Tag = "circle1";
            this.btn_createCircleROI.UseVisualStyleBackColor = true;
            this.btn_createCircleROI.Click += new System.EventHandler(this.btn_createRegionROI_Click);
            // 
            // btn_createCircle2ROI
            // 
            this.btn_createCircle2ROI.BackgroundImage = global::ImageMatch.Properties.Resources.circle2;
            this.btn_createCircle2ROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_createCircle2ROI.Location = new System.Drawing.Point(225, 13);
            this.btn_createCircle2ROI.Name = "btn_createCircle2ROI";
            this.btn_createCircle2ROI.Size = new System.Drawing.Size(50, 50);
            this.btn_createCircle2ROI.TabIndex = 5;
            this.btn_createCircle2ROI.Tag = "circle2";
            this.btn_createCircle2ROI.UseVisualStyleBackColor = true;
            this.btn_createCircle2ROI.Click += new System.EventHandler(this.btn_createRegionROI_Click);
            // 
            // btn_createRectangleROI
            // 
            this.btn_createRectangleROI.BackgroundImage = global::ImageMatch.Properties.Resources.rectangle1;
            this.btn_createRectangleROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_createRectangleROI.Location = new System.Drawing.Point(299, 13);
            this.btn_createRectangleROI.Name = "btn_createRectangleROI";
            this.btn_createRectangleROI.Size = new System.Drawing.Size(50, 50);
            this.btn_createRectangleROI.TabIndex = 5;
            this.btn_createRectangleROI.Tag = "rectangle1";
            this.btn_createRectangleROI.UseVisualStyleBackColor = true;
            this.btn_createRectangleROI.Click += new System.EventHandler(this.btn_createRegionROI_Click);
            // 
            // btn_createRectangle2ROI
            // 
            this.btn_createRectangle2ROI.BackgroundImage = global::ImageMatch.Properties.Resources.region;
            this.btn_createRectangle2ROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_createRectangle2ROI.Location = new System.Drawing.Point(375, 12);
            this.btn_createRectangle2ROI.Name = "btn_createRectangle2ROI";
            this.btn_createRectangle2ROI.Size = new System.Drawing.Size(50, 50);
            this.btn_createRectangle2ROI.TabIndex = 5;
            this.btn_createRectangle2ROI.Tag = "rectangle2";
            this.btn_createRectangle2ROI.UseVisualStyleBackColor = true;
            this.btn_createRectangle2ROI.Click += new System.EventHandler(this.btn_createRegionROI_Click);
            // 
            // btn_createRegionROI
            // 
            this.btn_createRegionROI.BackgroundImage = global::ImageMatch.Properties.Resources.rectangle2;
            this.btn_createRegionROI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_createRegionROI.Location = new System.Drawing.Point(462, 13);
            this.btn_createRegionROI.Name = "btn_createRegionROI";
            this.btn_createRegionROI.Size = new System.Drawing.Size(50, 50);
            this.btn_createRegionROI.TabIndex = 5;
            this.btn_createRegionROI.Tag = "region";
            this.btn_createRegionROI.UseVisualStyleBackColor = true;
            this.btn_createRegionROI.Click += new System.EventHandler(this.btn_createRegionROI_Click);
            // 
            // list_matchInfos
            // 
            this.list_matchInfos.FormattingEnabled = true;
            this.list_matchInfos.HorizontalScrollbar = true;
            this.list_matchInfos.ItemHeight = 20;
            this.list_matchInfos.Location = new System.Drawing.Point(933, 92);
            this.list_matchInfos.Name = "list_matchInfos";
            this.list_matchInfos.Size = new System.Drawing.Size(239, 424);
            this.list_matchInfos.TabIndex = 6;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 640);
            this.ControlBox = false;
            this.Controls.Add(this.list_matchInfos);
            this.Controls.Add(this.btn_createRegionROI);
            this.Controls.Add(this.btn_createRectangle2ROI);
            this.Controls.Add(this.btn_createRectangleROI);
            this.Controls.Add(this.btn_createCircle2ROI);
            this.Controls.Add(this.btn_createCircleROI);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_nccModelMatch);
            this.Controls.Add(this.btn_shapeModelMatch);
            this.Controls.Add(this.btn_openImg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pic_model);
            this.Controls.Add(this.hWindow);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pic_model)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HalconDotNet.HWindowControl hWindow;
        private System.Windows.Forms.PictureBox pic_model;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_openImg;
        private System.Windows.Forms.Button btn_shapeModelMatch;
        private System.Windows.Forms.Button btn_nccModelMatch;
        private System.Windows.Forms.OpenFileDialog fileDialog;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_createCircleROI;
        private System.Windows.Forms.Button btn_createCircle2ROI;
        private System.Windows.Forms.Button btn_createRectangleROI;
        private System.Windows.Forms.Button btn_createRectangle2ROI;
        private System.Windows.Forms.Button btn_createRegionROI;
        private System.Windows.Forms.ListBox list_matchInfos;
    }
}

