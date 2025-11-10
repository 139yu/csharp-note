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

namespace ImageMatch
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        HObject image;
        private void btn_openImg_Click(object sender, EventArgs e)
        {
            fileDialog.Filter = "图片文件 (*.jpg, *.png)|*.jpg;*.png";
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                HOperatorSet.ReadImage(out image,filePath);
                HOperatorSet.GetImageSize(image, out HTuple width, out HTuple height);
                hWindow.ImagePart = new Rectangle(0,0,width,height);
                HOperatorSet.DispImage(image, hWindow.HalconWindow);
            }
        }

        private void btn_createModel_Click(object sender, EventArgs e)
        {
            
            HOperatorSet.DrawCircle(hWindow.HalconWindow,out HTuple row,out HTuple column,out HTuple radius);
            HOperatorSet.GenCircle(out HObject circle,row,column,radius);
            HOperatorSet.ReduceDomain(image, circle, out HObject region);
            HOperatorSet.CropDomain(region, out HObject imagePart);
            HOperatorSet.WriteImage(imagePart, "png", 0, "roi");
            pic_model.Image = Image.FromFile("roi.png");
        }

        private void btn_shapeModelMatch_Click(object sender, EventArgs e)
        {
            HOperatorSet.ReadImage(out HObject reduceImage, "region.png");
            // 创建形状模型
            HOperatorSet.CreateShapeModel(reduceImage, 2, new HTuple(0).TupleRad()
                , new HTuple(360).TupleRad(), new HTuple(7.04).TupleRad(), new HTuple("none").TupleConcat(
                "no_pregeneration"), "use_polarity", (new HTuple(54).TupleConcat(86)).TupleConcat(
                6), 6, out HTuple modelID);

            HOperatorSet.FindShapeModel(image, modelID, new HTuple(0).TupleRad(),
                new HTuple(360).TupleRad(), 0.79, 5, 0.5, "least_squares", new HTuple(2).TupleConcat(
                1), 0.9, out HTuple hv_Row, out HTuple hv_Column, out HTuple hv_Angle, out HTuple hv_ModelScore);
            // 获取形状模型轮廓对象
            HOperatorSet.GetShapeModelContours(out HObject modelContours, modelID, 1);
            list_matchInfos.Items.Clear();
            for (int i = 0;i <= hv_ModelScore.TupleLength() - 1;  i++)
            {
                list_matchInfos.Items.Add($"匹配目标{i + 1}-->row：{hv_Row.TupleSelect(i)}，column：{hv_Column.TupleSelect(i)}，angle：{hv_Angle.TupleSelect(i)}，score：{hv_ModelScore.TupleSelect(i)}");
                HOperatorSet.HomMat2dIdentity(out HTuple hv_HomMat);
                // 旋转
                HOperatorSet.HomMat2dRotate(hv_HomMat, hv_Angle.TupleSelect(i), 0, 0,
                    out HTuple ExpTmpOutVar_0);
                hv_HomMat.Dispose();
                hv_HomMat = ExpTmpOutVar_0;
                // 平移
                HOperatorSet.HomMat2dTranslate(hv_HomMat, hv_Row.TupleSelect(i), hv_Column.TupleSelect(i), out ExpTmpOutVar_0);
                hv_HomMat.Dispose();
                hv_HomMat = ExpTmpOutVar_0;
          
                HOperatorSet.AffineTransContourXld(modelContours, out HObject ho_ContoursAffineTrans,
                hv_HomMat);
                HOperatorSet.DispObj(ho_ContoursAffineTrans, hWindow.HalconWindow);
            }
        }

        private void btn_createRegionROI_Click(object sender, EventArgs e)
        {
            if(image == null)
            {
                MessageBox.Show("未选择图片", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HOperatorSet.ClearWindow(hWindow.HalconWindow);
            HOperatorSet.DispImage(image, hWindow.HalconWindow);
            var btn = (sender  as Button);
            var roiType = btn.Tag as string;
            DrawROI(roiType);
        }

        private void DrawROI(string roiType)
        {
            HOperatorSet.SetDraw(hWindow.HalconWindow, "margin");
            HOperatorSet.SetColor(hWindow.HalconWindow, "red");
            // 获取焦点
            hWindow.Focus();
            HObject region;
            if (roiType == "circle1")
            {
                HOperatorSet.DrawCircle(hWindow.HalconWindow, out HTuple row, out HTuple column, out HTuple radius);
                HOperatorSet.GenCircle(out region, row, column, radius);
            }
            else if (roiType == "circle2")
            {
                HOperatorSet.DrawEllipse(hWindow.HalconWindow, out HTuple row, out HTuple column, out HTuple phi, out HTuple radius1, out HTuple radius2);
                HOperatorSet.GenEllipse(out region, row, column, phi, radius1, radius2);
            }
            else if (roiType == "rectangle1")
            {
                HOperatorSet.DrawRectangle1(hWindow.HalconWindow, out HTuple row, out HTuple column, out HTuple width, out HTuple height);
                HOperatorSet.GenRectangle1(out region, row, column, width, height);
            }
            else if (roiType == "rectangle2")
            {
                HOperatorSet.DrawRectangle2(hWindow.HalconWindow, out HTuple row, out HTuple column, out HTuple phi, out HTuple width, out HTuple height);
                HOperatorSet.GenRectangle2(out region, row, column, phi, width, height);
            }
            else if (roiType == "region")
            {
                HOperatorSet.DrawRegion(out region, hWindow.HalconWindow);
            }
            else
            {
                MessageBox.Show("未知ROI类型", "参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            HOperatorSet.ReduceDomain(image, region, out HObject reduceImage);
            HOperatorSet.WriteImage(reduceImage, "png", 0, "region");

            pic_model.Image = Image.FromFile("region.png");
        }

        private void btn_nccModelMatch_Click(object sender, EventArgs e)
        {
            HOperatorSet.ReadImage(out HObject reduceImage, "region.png");
            HOperatorSet.Rgb1ToGray(reduceImage, out HObject grayReduceImage);
            reduceImage.Dispose();
            reduceImage = grayReduceImage;
            HOperatorSet.Rgb1ToGray(image, out HObject grayImage);
            image.Dispose();
            image = grayImage;
            HOperatorSet.CreateNccModel(reduceImage, "auto", 0, 0, "auto", "use_polarity",
           out HTuple modelID);

            HOperatorSet.Threshold(reduceImage, out HObject ho_Region, 0, 100);

            HOperatorSet.DilationCircle(ho_Region, out HObject ho_RegionDilation, 5.5);
            // 将区域转成轮廓对象
            HOperatorSet.GenContourRegionXld(ho_Region, out HObject ho_Contours, "border");

            // 使用圆对轮廓进行填充
            HOperatorSet.FitCircleContourXld(ho_Contours, "algebraic", -1, 0, 0, 3, 2, out  HTuple hv_Row1,out HTuple hv_Column1, out HTuple hv_Radius1, out HTuple hv_StartPhi1, out HTuple hv_EndPhi1, out HTuple hv_PointOrder1);
            HOperatorSet.GenCircle(out HObject circle, hv_Row1, hv_Column1, hv_Radius1);
            HOperatorSet.DispObj(circle, hWindow.HalconWindow);
            HOperatorSet.FindNccModel(image, modelID, 0, 0, 0.5, 5, 0.5, "true",
            new HTuple(4).TupleConcat(1), out HTuple hv_Row, out HTuple hv_Column, out HTuple hv_Angle,
            out HTuple hv_Score);
            HOperatorSet.AreaCenter(reduceImage,out HTuple area,out HTuple row,out HTuple column);
            for (int index = 0; index <= hv_Score.TupleLength() - 1; index++)
            {
                HOperatorSet.VectorAngleToRigid(row, column, 0, hv_Row.TupleSelect(
                    index), hv_Column.TupleSelect(index), 0, out HTuple hv_HomMat2D);

                HOperatorSet.AffineTransRegion(reduceImage, out HObject ho_RegionAffineTrans, hv_HomMat2D,"nearest_neighbor");

                HOperatorSet.DispObj(ho_RegionAffineTrans, hWindow.HalconWindow);

                HOperatorSet.GenCrossContourXld(out HObject ho_Cross, hv_Row.TupleSelect(index),
                    hv_Column.TupleSelect(index), 12, hv_Angle.TupleSelect(index));
                HOperatorSet.DispObj(ho_Cross, hWindow.HalconWindow);
            }
        }
    }
}
