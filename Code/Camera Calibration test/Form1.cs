using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.IO;
//using Emgu.CV.CalibrateCamera;

namespace Camera_Calibration_test
{
    public partial class Form1 : Form
    {
        private string calibrationImagesDirectory = @"..\..\Checkerboard Image Calibration\Images"; // Set your default directory here  

        private List<Image<Bgr, byte>> calibrationImages = new List<Image<Bgr, byte>>();
        private int displayImageIndex = 0;
        private Timer imageDisplayTimer = new Timer();
        private MCvPoint3D32f[][] cornersObjectPoints;
        private PointF[][] cornersImagePoints;
        private Mat cameraMatrix = new Mat();
        private Mat distCoeffs = new Mat();
        private Size patternSize = new Size(10, 7);
        private Size imageSize;

        Image<Bgr, byte> FilteredImg;

        public Form1()
        {
            InitializeComponent();
            imageDisplayTimer.Interval = 100; // Display each image for 1 second
            imageDisplayTimer.Tick += ImageDisplayTimer_Tick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ImageDisplayTimer_Tick(object sender, EventArgs e)
        {
            displayImageIndex++;
            UpdateStatusLabel(displayImageIndex.ToString());

            if (displayImageIndex >= calibrationImages.Count)
            {
                displayImageIndex = 0;
                imageDisplayTimer.Stop();
                UpdateStatusLabel("Calibration Completed");
            }
            else
            {
                pictureBoxFoundCorners.Image = calibrationImages[displayImageIndex].ToBitmap();
                FindCornersAndUpdateImage(calibrationImages[displayImageIndex].Convert<Gray, byte>(), displayImageIndex);
            }
        }

        private void buttonStartCal_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                folderBrowser.SelectedPath = calibrationImagesDirectory; // Set your default folder path

                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string[] imagePaths = Directory.GetFiles(folderBrowser.SelectedPath, "*.jpg");
                    foreach (string imagePath in imagePaths)
                    {
                        Image<Bgr, byte> image = new Image<Bgr, byte>(imagePath);
                        calibrationImages.Add(image);
                    }

                    if (calibrationImages.Count > 0)
                    {
                        //pictureBoxFoundCorners.Image = calibrationImages[0].ToBitmap();
                        //FindCornersAndUpdateImage(calibrationImages[0]);

                        displayImageIndex = 0;
                        imageDisplayTimer.Start();
                        UpdateStatusLabel();
                    }
                }
            }
        }

        private void FindCornersAndUpdateImage(Image<Gray, byte> image, int index)
        {
            Image<Bgr, byte> outImg = calibrationImages[index].Clone();

            VectorOfPointF corners = new VectorOfPointF(patternSize.Width * patternSize.Height);
            CvInvoke.FindChessboardCorners(image, patternSize, corners, CalibCbType.AdaptiveThresh);
            if (corners != null)
            {
                CvInvoke.CornerSubPix(image, corners, new Size(11, 11), new Size(-1, -1), new MCvTermCriteria(30, 0.1));
                CvInvoke.DrawChessboardCorners(outImg, patternSize, corners, true);
            }

            pictureBoxFoundCorners.Image = outImg.ToBitmap();
        }

        static PointF[][] ConvertListTo2DArray(List<VectorOfPointF> listOfVectors)
        {
            int rowCount = listOfVectors.Count;
            PointF[][] resultArray = new PointF[rowCount][];

            for (int i = 0; i < rowCount; i++)
            {
                resultArray[i] = listOfVectors[i].ToArray();
            }

            return resultArray;
        }

        private MCvPoint3D32f[] CreateObjectPoints()
        {
            List<MCvPoint3D32f> objectPoints = new List<MCvPoint3D32f>();
            for (int i = 0; i < patternSize.Height; i++)
            {
                for (int j = 0; j < patternSize.Width; j++)
                {
                    objectPoints.Add(new MCvPoint3D32f(j, i, 0));
                }
            }
            return objectPoints.ToArray();
        } 

        private void UpdateStatusLabel(string message = "")
        {
            toolStripStatusLabel.Text = message;
        }

        private void checkBoxShowPreFilter_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPreFilter.Checked)
            {
                pictureBoxUndistorted.Image = calibrationImages[0].ToBitmap();
            }
            if (!checkBoxShowPreFilter.Checked)
            {
                pictureBoxUndistorted.Image = FilteredImg.ToBitmap();
            }
        }

        private void buttonLoadCalVals_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using (FileStorage fs = new FileStorage(filePath, FileStorage.Mode.Read))
                {
                    fs.GetNode("cameraMatrix").ReadMat(cameraMatrix); //fs.Read("cameraMatrix", out cameraMatrix);
                    fs.GetNode("distCoeffs").ReadMat(distCoeffs);
                }

                MessageBox.Show("Calibration parameters loaded from file.");
            }

            Console.WriteLine(cameraMatrix);
            Console.WriteLine(distCoeffs);

        }

        private void BtnRunCalibration_Click(object sender, EventArgs e)
        {
            calibrationImages.Clear();
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                folderBrowser.SelectedPath = calibrationImagesDirectory; // Set your default folder path

                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string[] imagePaths = Directory.GetFiles(folderBrowser.SelectedPath, "*.jpg");
                    foreach (string imagePath in imagePaths)
                    {
                        Image<Bgr, byte> image = new Image<Bgr, byte>(imagePath);
                        calibrationImages.Add(image);
                    }
                }
            }
            // Ensure you've captured enough images for calibration
            if (calibrationImages.Count < 10)
            {
                UpdateStatusLabel("At least 10 images are required for calibration.");
                return;
            }

            imageSize = calibrationImages[0].Size;
            List<MCvPoint3D32f[]> objectPointsList = new List<MCvPoint3D32f[]>();
            List<VectorOfPointF> imagePointsList = new List<VectorOfPointF>();

            for (int i = 0; i < calibrationImages.Count; i++)
            {
                VectorOfPointF corners = new VectorOfPointF(patternSize.Width * patternSize.Height);

                CvInvoke.FindChessboardCorners(calibrationImages[i].Convert<Gray, byte>(), patternSize, corners, CalibCbType.AdaptiveThresh);

                if (corners == null)
                {
                    UpdateStatusLabel("Failed to find corners in one of the images.");
                    return;
                }

                CvInvoke.CornerSubPix(calibrationImages[i].Convert<Gray, byte>(), corners, new Size(11, 11), new Size(-1, -1), new MCvTermCriteria(30, 0.1));
                objectPointsList.Add(CreateObjectPoints());
                imagePointsList.Add(corners);
            }

            cornersObjectPoints = objectPointsList.ToArray();
            cornersImagePoints = ConvertListTo2DArray(imagePointsList);

            Mat[] rvecs, tvecs;
            //Mat cameraMatrix = new Mat();
            //Mat distCoeffs = new Mat();

            CvInvoke.CalibrateCamera(
                cornersObjectPoints,
                cornersImagePoints,
                imageSize,
                cameraMatrix,
                distCoeffs,
                CalibType.RationalModel,
                new MCvTermCriteria(30, 0.1),
                out rvecs,
                out tvecs
            );

            Image<Bgr, byte> inpImg = calibrationImages[0].Clone();
            CvInvoke.Undistort(calibrationImages[0], inpImg, cameraMatrix, distCoeffs);

            FilteredImg = inpImg;
            pictureBoxUndistorted.Image = FilteredImg.ToBitmap();

            /*Save Camera Calibration Stats 
            string outputFileName = "calibration_results.xml";
            CameraCalibration.StoreCameraParams(outputFileName, imageSize, cameraMatrix, distCoeffs, rvecs, tvecs);

            UpdateStatusLabel("Calibration results saved to " + outputFileName);*/
        }

        private void buttonSaveCalVals_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                using (FileStorage fs = new FileStorage(filePath, FileStorage.Mode.Write))
                {
                    fs.Write(cameraMatrix, "cameraMatrix");
                    fs.Write(distCoeffs, "distCoeffs");
                }

                MessageBox.Show("Calibration parameters saved to file.");
            }
            Console.WriteLine(cameraMatrix);
            Console.WriteLine(distCoeffs);
        }
    }
}
