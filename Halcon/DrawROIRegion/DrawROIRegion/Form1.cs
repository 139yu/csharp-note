using HalconDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawROIRegion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            halconWindow = win_control.HalconWindow;
        }

        private void menu_openFile_Click(object sender, EventArgs e)
        {
            openFileDialog.AddExtension = true;
            openFileDialog.Filter = "图片文件|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                OpenImage(filePath);
            }
        }
        private HObject imageObj;
        private HWindow halconWindow;
        private void OpenImage(string filePath)
        {
            HOperatorSet.GenEmptyObj(out imageObj);
            imageObj.Dispose();
            HOperatorSet.ReadImage(out imageObj, filePath);
            HOperatorSet.GetImageSize(imageObj, out HTuple width, out HTuple height);
            win_control.Width = width;
            win_control.Height = height;
            HOperatorSet.SetPart(halconWindow, 0, 0, height - 1, width - 1);
            HOperatorSet.DispObj(imageObj, halconWindow);
        }

        private void btn_selectRoiRegion_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            HOperatorSet.SetDraw(halconWindow, "margin");
            HOperatorSet.SetColor(halconWindow, "red");
            HOperatorSet.SetLineWidth(halconWindow, 2);
            // 让图像框获得焦点，不设置绘制roi区域时需要点两次
            win_control.Focus();
            HOperatorSet.DrawRectangle1(halconWindow, out HTuple row1, out HTuple col1, out HTuple row2, out HTuple col2);
            HOperatorSet.GenRectangle1(out HObject rectangleRegion, row1, col1, row2, col2);
            HOperatorSet.DispObj(rectangleRegion, halconWindow);
            HOperatorSet.ReduceDomain(imageObj, rectangleRegion, out HObject reducedImage);
            HOperatorSet.CropDomain(reducedImage, out HObject croppedImage);
            HOperatorSet.WriteImage(croppedImage, "bmp", 0, "cropped_image");
        }

        private void btn_selectDeference_Click(object sender, EventArgs e)
        {

        }
         
    }
}
