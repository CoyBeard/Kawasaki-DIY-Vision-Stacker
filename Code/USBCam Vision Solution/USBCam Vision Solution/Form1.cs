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
using Emgu.CV.UI;
using System.IO;
using DirectShowLib;
using System.IO.Ports;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Threading;
using Emgu.CV.Util;
using System.Diagnostics;


/**7-9-23
 * Adjust brightness and contrast not working Mul not recognised 
 * Snaped image needs to be grayscalled
 */

/*7-10-23
 * Zoom Works but it needs to be a crop not zoom 
 */

/*7-11-23
 * Refine Find contures
 * Ability to find angled rectangles
 * binerize?
 * GUI Controls?
 */

/*7-25-23
 * Conveyor at setting 2 runs at 3.3in/s
 * 
 */

/*test Pick robot Pos: -570, 650, -80, -32, 180, -77,
 * 294mm from end of camera to start of pick area 
 * 
 * 
 */


namespace USBCam_Vision_Solution
{
    public partial class Form1 : Form
    {
        //--GLOBAL VARS--//
        ///////////////////
        VideoCapture capture;
        private List<DsDevice> cameraList;

        private List<Point[]> rectangles;

        //Brightness, Contrast, Zoom
        int Brightness, Contrast, AngleThresh, BinaryThresh, MinLength, MaxLength;

        string CamCalibrateFilePath = @"..\..\calibration_values.txt"; //setup your own path of the file calibration_values.txt
                                                                                                                                                                                                             // Initialize the 3x3 float matrix to store the camera matrix
        Matrix<float> cameraMatrix = new Matrix<float>(3, 3);
        Emgu.CV.Matrix<float> distortionCoeffs;

        double PixelsToMM = 0.9765; //One pixel equals how many MMs 
        double ConveyorSpeed = 83.82; //Conveyor Speed in MM/s 

        //List<VectorOfPoint> BoardBuffer = new List<VectorOfPoint>();
        long[] FoundBoardTimes = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        int[] BoardBuffer = {0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                             0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };

        // Create a new instance of Stopwatch
        Stopwatch ProgramTimer = new Stopwatch();

        //new Image<Bgr, byte> adjustedImage;
        Mat ElipsedBinary;

        private SerialPort _serialPort;

        bool RobotReady = false;
        int BoardCount;
        double PickAreaYDistance = 294;//distance in mm from end of camera view to start of robot pick area
        int DumpAreaYDistance = 800;//distance in mm from end of camera view to start of dump area (end of conveyor belt)
        double MaterialThickness = 24;//Thickness of boards (mm)
        double PickXOfset = 0;//Ofset from center of pick position and the board X axis (mm) (Perpindicular with conveyors), pos = robot right, neg = robot left
        double PickYOfset = 0;//Ofset from center of pick position and the board Y axis (mm) (Parallel with conveyors), pos = ferther from robot base, neg = closer to robot base
        double PickZOfset = 20;//Ofset from center of pick position and the board Z axis (mm) (Up and down), pos = higher, neg = lower
        double PickGripperSquishDistance = 20;//how far the gripper pushes into the part (mm)

        double RobotXAtCameraZero = -240;//the robots x cordinate value when the center of the robots manipulator is aligned with the cameras x = 0 pixel columb  
        double RobotYAtPickAreaStart = 760;//the robots y cordinate value when the center of the robots manipulator is aligned with pick area start line 
        double RobotZOnConveyor = -135;//the robots z cordinate value when the end of the tool is tuching the conveyor

        double RadiansToDegrees = (180.0 / Math.PI);//multiply with this to get degrees 

        double RobotTravelToPartTime = 1.7;//Seconds

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize the list of available cameras
            cameraList = GetAvailableCameras();

            // Populate the combo box with available cameras
            foreach (var camera in cameraList)
            {
                CbCameraSelect.Items.Add(camera.Name);
            }

            Brightness = trackBarBrightness.Value;
            Contrast = trackBarContrast.Value;
            AngleThresh = trackBarAngleThresh.Value;
            BinaryThresh = trackBarBinaryThresh.Value;
            int.TryParse(textBoxMinLength.Text, out MinLength);
            int.TryParse(textBoxMaxLength.Text, out MaxLength);
            checkBoxLoadUndistortPeram.Checked = true;
            checkBoxCamCalMode.Checked = false;
            if (checkBoxSendPickPos.Checked == false)
            {
                RobotReady = true;
            }
            BoardBuffer[0] = 0;

            // Populate the combo box with available COM ports
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                comboBoxCOMPorts.Items.Add(port);
            }

            // Populate the combo box with common baud rates
            int[] baudRates = { 9600, 19200, 38400, 57600, 115200 };
            foreach (int baudRate in baudRates)
            {
                comboBoxBaudRate.Items.Add(baudRate);
            }
            comboBoxBaudRate.SelectedIndex = 1;

            // Initialize SerialPort settings
            _serialPort = new SerialPort();
            _serialPort.DataBits = 8;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.DataReceived += _serialPort_DataReceived;

            // Start the stopwatch
            ProgramTimer.Start();
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Read received data and update the received text box on the UI thread
            string receivedData = _serialPort.ReadExisting();
            Console.WriteLine("Data Received: " + receivedData);
            //BeginInvoke(new Action(() => textBoxReceived.Text += receivedData));

            if (receivedData.Contains("1"))
            {
                RobotReady = true;
            }
        }

        //--EVENTS--//
        //////////////

        //Live View Camera
        private void BtnCamStart_Click(object sender, EventArgs e)
        {
            // Update the selected camera
            int selectedCameraIndex = CbCameraSelect.SelectedIndex;
            if (selectedCameraIndex >= 0)
            {
                // Dispose the existing video capture if any
                if (capture != null)
                {
                    capture.Dispose();
                    capture = null;
                }
                if (checkBoxLoadUndistortPeram.Checked)
                {
                    CalibrateWarpPeramLoad();
                }

                // Create a new video capture using the selected camera
                capture = new VideoCapture(selectedCameraIndex);

                // Set the event handler for the new frame
                capture.ImageGrabbed += Capture_ImageGrabbed;

                // Start capturing frames from the selected camera
                capture.Start();
            }
        }

        private void BtnCamStop_Click(object sender, EventArgs e)
        {
            // Stop capturing frames from the selected camera
            if (capture != null && capture.IsOpened)
            {
                capture.Stop();
            }
        }
        
        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            // Retrieve the latest frame from the video capture
            Mat frame = new Mat();
            capture.Retrieve(frame);

            Mat undistortedImage = new Mat();
            if (checkBoxLoadUndistortPeram.Checked)
            {
                CvInvoke.Undistort(frame, undistortedImage, cameraMatrix, distortionCoeffs);
                FindRect(BrtCntAdj(undistortedImage.ToImage<Bgr, byte>(), Brightness, Contrast));
            }
            else
            {
                FindRect(BrtCntAdj(frame.ToImage<Bgr, byte>(), Brightness, Contrast));
            }

            //check to see if we can send boards to robot
            for (int i = 0; i < FoundBoardTimes.Length; i++)
            {
                if ((checkBoxSendPickPos.Checked || !checkBoxCamCalMode.Checked) && !RobotReady)
                {
                    return;
                }

                if (BoardCount <= 0)
                {
                    return;
                }

                //Console.WriteLine("i = " + i);
                int pointsInPickArea = 0;

                for (int j = 1; j <= 7; j += 2)
                {
                    //Get the elapsed time in milliseconds
                    long elapsedMilliseconds = ProgramTimer.ElapsedMilliseconds;

                    //Console.WriteLine("Distance Traveled: " + (int)Math.Round(((double)(FoundBoardTimes[i] - elapsedMilliseconds) / 1000) * (ConveyorSpeed / PixelsToMM)));
                    //Console.WriteLine("Current Pos(px) = " + (BoardBuffer[(i * 10) + j] + (int)Math.Round(((double)(FoundBoardTimes[i] - elapsedMilliseconds) / 1000) * (ConveyorSpeed / PixelsToMM))));
                    //Console.WriteLine("Pick Area(px) = " + ((PickAreaYDistance / PixelsToMM) * -1));

                    //if boards all four current Y pos is in the pick area  
                    if ((BoardBuffer[(i * 10) + j] + (int)Math.Round(((double)(FoundBoardTimes[i] - elapsedMilliseconds) / 1000) * (ConveyorSpeed / PixelsToMM))) < (((PickAreaYDistance / PixelsToMM) * -1) + ((double)RobotTravelToPartTime * (ConveyorSpeed / PixelsToMM))) && (BoardBuffer[(i * 10) + j] != 0))
                    {
                        //the point in in the pick area
                        pointsInPickArea += 1;
                    }
                }

                //Console.WriteLine("pointsInPickArea = " + pointsInPickArea);

                //if all points are in pick area
                if (pointsInPickArea == 4)
                {
                    //find center of board by averaging x and y points 
                    //X cneter
                    BoardBuffer[(i * 10) + 8] = (BoardBuffer[(i * 10) + 0] + BoardBuffer[(i * 10) + 2] + BoardBuffer[(i * 10) + 4] + BoardBuffer[(i * 10) + 6]) / 4;
                    //Y cneter
                    //Get the elapsed time in milliseconds
                    long elapsedMilliseconds = ProgramTimer.ElapsedMilliseconds + (long)((double)RobotTravelToPartTime * 1000);
                    BoardBuffer[(i * 10) + 9] = ((BoardBuffer[(i * 10) + 1] + BoardBuffer[(i * 10) + 3] + BoardBuffer[(i * 10) + 5] + BoardBuffer[(i * 10) + 7]) / 4) + (int)Math.Round(((double)(FoundBoardTimes[i] - elapsedMilliseconds) / 1000) * (ConveyorSpeed / PixelsToMM));

                    if (BoardBuffer[(i * 10) + 9] <= ((DumpAreaYDistance / PixelsToMM) * -1))
                    {
                        Console.WriteLine("Board " + i + " Dumped. Y axis center = " + BoardBuffer[(i * 10) + 9] + ", Limmit = " + (DumpAreaYDistance * -1) + "mm beyond end of camera view!");

                        //remove from buffer
                        for (int j = 0; j < 10; j++)
                        {
                            BoardBuffer[(i * 10) + j] = 0;
                        }
                        FoundBoardTimes[i] = 0;
                        //FoundBoardTimes.RemoveAt(i);
                        BoardCount -= 1;

                        ///*
                        //print buffers for debugging
                        for (int k = 0; k < (Math.Round((double)BoardBuffer.Length / 10) - 1); k++)
                        {
                            for (int l = 0; l < 10; l++)
                            {
                                Console.WriteLine("BoardBuffer[" + ((k * 10) + l) + "]: " + BoardBuffer[(k * 10) + l]);
                            }
                        }
                        for (int m = 0; m < FoundBoardTimes.Length; m++)
                        {
                            Console.WriteLine("Found Board Tines: " + FoundBoardTimes[m]);
                        }
                        Console.WriteLine("Board Count: " + BoardCount);

                        return;
                    }

                    //because all four points are not always in the same order we need to find which points make up the longer lines of the board
                    //find all four line's lengths
                    Point pointA = new Point(BoardBuffer[(i * 10) + 0], BoardBuffer[(i * 10) + 1]);
                    Point pointB = new Point(BoardBuffer[(i * 10) + 2], BoardBuffer[(i * 10) + 3]);
                    Point pointC = new Point(BoardBuffer[(i * 10) + 4], BoardBuffer[(i * 10) + 5]);
                    Point pointD = new Point(BoardBuffer[(i * 10) + 6], BoardBuffer[(i * 10) + 7]);

                    // Define the four lines using Point structures
                    Point[] line1 = { pointD, pointA };
                    Point[] line2 = { pointA, pointB };
                    Point[] line3 = { pointB, pointC };
                    Point[] line4 = { pointC, pointD };

                    // Calculate the lengths of the four lines
                    double length1 = CalculateLineLength(line1);
                    double length2 = CalculateLineLength(line2);
                    double length3 = CalculateLineLength(line3);
                    double length4 = CalculateLineLength(line4);

                    // Determine the two longest lines
                    double[] lengths = { length1, length2, length3, length4 };
                    Array.Sort(lengths);
                    double longest1 = lengths[2]; // Second longest
                    double longest2 = lengths[3]; // Longest

                    // Find the points that make up the longest lines
                    Point[] longestPoints1 = FindPointsOfLongestLine(longest1, line1, line2, line3, line4);
                    Point[] longestPoints2 = FindPointsOfLongestLine(longest2, line1, line2, line3, line4);

                    // Print the results
                    //Console.WriteLine($"Longest Line 1: Length = {longest1}, Points = ({longestPoints1[0]}), ({longestPoints1[1]})");
                    //Console.WriteLine($"Longest Line 2: Length = {longest2}, Points = ({longestPoints2[0]}), ({longestPoints2[1]})");

                    //find board angle with found points
                    int RobotSendXPos = (int)Math.Round(RobotXAtCameraZero - ((BoardBuffer[(i * 10) + 8]) * PixelsToMM) + PickXOfset);
                    //Console.WriteLine("(BoardBuffer[(i * 10) + 9]) = " + (BoardBuffer[(i * 10) + 9]));
                    //Console.WriteLine("((BoardBuffer[(i * 10) + 9]) * PixelsToMM) = " + ((BoardBuffer[(i * 10) + 9]) * PixelsToMM));
                    //Console.WriteLine("(((BoardBuffer[(i * 10) + 9]) * PixelsToMM) + PickAreaYDistance) = " + (((BoardBuffer[(i * 10) + 9]) * PixelsToMM) + PickAreaYDistance));
                    //Console.WriteLine("(RobotYAtPickAreaStart + (((BoardBuffer[(i * 10) + 9]) * PixelsToMM) + PickAreaYDistance)) = " + (RobotYAtPickAreaStart + (((BoardBuffer[(i * 10) + 9]) * PixelsToMM) + PickAreaYDistance)));

                    int RobotSendYPos = (int)Math.Round((RobotYAtPickAreaStart + (((BoardBuffer[(i * 10) + 9]) * PixelsToMM) + PickAreaYDistance)) + PickYOfset);
                    int RobotSendZPos = (int)Math.Round(RobotZOnConveyor + MaterialThickness - PickGripperSquishDistance + PickZOfset);
                    int RobotSendWPos = 45 + (int)Math.Round(Math.Atan((((double)longestPoints1[0].Y - (double)longestPoints1[1].Y)) / (((double)longestPoints2[0].X - (double)longestPoints2[1].X))) * RadiansToDegrees);//rotation angle between 134 and -45, 45 being parallel

                    string message = ("," + RobotSendXPos + "," + RobotSendYPos + "," + RobotSendZPos + "," + RobotSendWPos + ",180,0,").Trim();

                    if (checkBoxSendPickPos.Checked)
                    {
                        //Send message
                        if (_serialPort.IsOpen)
                        {
                            _serialPort.WriteLine(message);
                        }
                        else
                        {
                            MessageBox.Show("COM port is not connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        RobotReady = false;
                    }

                    Console.WriteLine("Sending: " + message);

                    //remove from buffer
                    for (int j = 0; j < 10; j++)
                    {
                        BoardBuffer[(i * 10) + j] = 0;
                    }
                    FoundBoardTimes[i] = 0;
                    //FoundBoardTimes.RemoveAt(i);
                    BoardCount -= 1;

                    ///*
                    //print buffers for debugging
                    for (int k = 0; k < (Math.Round((double)BoardBuffer.Length / 10) - 1); k++)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            Console.WriteLine("BoardBuffer[" + ((k * 10) + l) + "]: " + BoardBuffer[(k * 10) + l]);
                        }
                    }
                    for (int m = 0; m < FoundBoardTimes.Length; m++)
                    {
                        Console.WriteLine("Found Board Tines: " + FoundBoardTimes[m]);
                    }
                    Console.WriteLine("Board Count: " + BoardCount);
                }
            }
        }

        static double CalculateLineLength(Point[] line)
        {
            int dx = line[1].X - line[0].X;
            int dy = line[1].Y - line[0].Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        static Point[] FindPointsOfLongestLine(double longestLength, params Point[][] lines)
        {
            foreach (Point[] line in lines)
            {
                double length = CalculateLineLength(line);
                if (length == longestLength)
                {
                    return line;
                }
            }
            return null; // No points found
        }

        private Mat DrawElpses(Mat inpImg, int i, int yOffset, int radius = 25)//private Mat DrawElpses(Mat inpImg, VectorOfPoint circlePoints, int yOffset, int radius = 25)
        {
            for (int j = 0; j <= 7; j+=2)
            {
                //Console.WriteLine("i = " + i + "j = " + j);
                //Console.WriteLine("BoardBuffer[(i * 10) + j] = " + BoardBuffer[(i * 10) + j]);
                //Console.WriteLine("BoardBuffer[(i * 10) + j] = " + BoardBuffer[(i * 10) + j + 1]);

                CvInvoke.Circle(inpImg, new Point(BoardBuffer[(i * 10) + j], BoardBuffer[(i * 10) + j + 1] + yOffset), radius: 10, new MCvScalar(255, 255, 255), thickness: -1);
            }
            return inpImg;
        }

        private Mat DrawPoly(Mat inpImg, int i, int yOffset)//private Mat DrawElpses(Mat inpImg, VectorOfPoint circlePoints, int yOffset, int radius = 25)
        {
            Point[] rectanglePoints = new Point[]
            {
                new Point(BoardBuffer[(i * 10) + 0], BoardBuffer[(i * 10) + 1] + yOffset),
                new Point(BoardBuffer[(i * 10) + 2], BoardBuffer[(i * 10) + 3] + yOffset),
                new Point(BoardBuffer[(i * 10) + 4], BoardBuffer[(i * 10) + 5] + yOffset),
                new Point(BoardBuffer[(i * 10) + 6], BoardBuffer[(i * 10) + 7] + yOffset)
            };

            // Create a VectorOfPoint from the array of points
            VectorOfPoint vectorOfPoints = new VectorOfPoint(rectanglePoints);

            // Create a filled rectangle using the FillConvexPoly method
            CvInvoke.FillConvexPoly(inpImg, vectorOfPoints, new Bgr(0, 0, 0).MCvScalar);

            return inpImg;
        }


        //Image Adjust
        private void trackBarBrightness_Scroll(object sender, EventArgs e)
        {
            Brightness = trackBarBrightness.Value;
            lblBrightnessValue.Text = trackBarBrightness.Value.ToString();
        }

        private void trackBarContrast_Scroll(object sender, EventArgs e)
        {
            Contrast = trackBarContrast.Value;
            lblContrastValue.Text = trackBarContrast.Value.ToString();
        }


        //--ON PROGRAM CLOSE--//
        ////////////////////////
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop capturing and release resources when the form is closing
            if (capture != null && capture.IsOpened)
            {
                capture.Stop();
                capture.Dispose();
                capture = null;
            }
        }


        //--FUNCTIONS--//
        /////////////////

        //Live View Camera
        private List<DsDevice> GetAvailableCameras()
        {
            List<DsDevice> cameras = new List<DsDevice>();

            // Enumerate video input devices using DirectShowLib
            DsDevice[] devices = DsDevice.GetDevicesOfCat(DirectShowLib.FilterCategory.VideoInputDevice);
            foreach (DsDevice device in devices)
            {
                cameras.Add(device);
            }

            return cameras;
        }


        //Image Adjust
        private Image<Bgr, byte> BrtCntAdj (Image<Bgr, byte> adjustedImage, int Brt, int Cnt)
        {
            // Clone the original image for adjustments
            //Image<Bgr,byte> adjustedImage = new Image<Bgr, byte>(InpFilePath);

            // Calculate the coordinates for the top-left corner of the cropped region
            //int x = (adjustedImage.Width - Zom) / 2;
            //int y = (adjustedImage.Height - Zom) / 2;

            // Crop the image using Emgu.CV's ROI (Region of Interest) method
            //Image<Bgr, byte> croppedImage = adjustedImage.Copy(new Rectangle(x, y, Zom, Zom));


            // Adjust the brightness and contrast
            double brightness = (double)Brt / 1;
            double contrast = (double)Cnt / 100.0;
            Image<Bgr, byte> ImgOut = adjustedImage.Mul(contrast) + brightness; 

            return ImgOut;
        }



        //Detection

        private void FindRect(Image<Bgr, byte> image)
        {
            if (image == null)
            {
                MessageBox.Show("Please open an image first.");
                return;
            }

            using (Mat gray = new Mat())
            using (Mat binary = new Mat())
            {
                CvInvoke.CvtColor(image, gray, ColorConversion.Bgr2Gray);
                CvInvoke.GaussianBlur(gray, gray, new Size(5, 5), 0);
                CvInvoke.Threshold(gray, binary, BinaryThresh, 255, ThresholdType.Binary);// | ThresholdType.Otsu

                // Apply Canny edge detection
                //Mat edges = new Mat();
                //CvInvoke.Canny(gray, edges, BinaryThresh, BinaryThresh*2);



                ElipsedBinary = binary;// edges


                //Place black mask over found boards to prevent double takes
                if (checkBoxCamCalMode.Checked == false)
                {
                    //Console.WriteLine("BoardBuffer.Count = " + BoardBuffer.Count);
                    //Console.WriteLine("BoardBuffer.Length = " + BoardBuffer.Length);
                    //Console.WriteLine("BoardBuffer.Length rounded - 1 = " + (Math.Round((double)BoardBuffer.Length / 10) - 1));

                    for (int n = 0; n < FoundBoardTimes.Length; n++)//for (int i = 0; i < BoardBuffer.Count; i++)     <=(Math.Round((double)BoardBuffer.Length / 10) - 1)
                    {
                        //Console.WriteLine("i = " + i);
                        //Console.WriteLine("BoardBuffer[i * 10] = " + BoardBuffer[i * 10]);



                        //Console.WriteLine("Vector Size = " + BoardBuffer[i].Size);
                        if (BoardBuffer[n * 10] != 0)//if (BoardBuffer[i].Size == 4)
                        {
                            //Console.WriteLine("BoardBuffer[i * 10] != 0");

                            //Console.WriteLine("Vector Size = 4");
                            //Console.WriteLine("BoardBuffer[(i*10)] = " + BoardBuffer[(i * 10) + 0]);

                            //Avoid plotting negitive points
                            int NumberOfNegitivYValues = 0;

                            //Console.WriteLine("BoardBuffer[(i*10)+1] = " + BoardBuffer[(i * 10) + 1]);
                            Console.WriteLine("n = " + n);
                            Console.WriteLine("FoundBoardTimes length = " + FoundBoardTimes.Length);
                            Console.WriteLine("BoardBuffer Length = " + BoardBuffer.Length);


                            //Get the elapsed time in milliseconds
                            long elapsedMilliseconds = ProgramTimer.ElapsedMilliseconds;
                            if (BoardBuffer[(n * 10) + 1] + (int)Math.Round(((double)(FoundBoardTimes[n] - elapsedMilliseconds) / 1000) * (ConveyorSpeed / PixelsToMM)) <= -100)//if (BoardBuffer[i][0].Y + (int)Math.Round(((double)(FoundBoardTimes[i] - elapsedMilliseconds) / 1000) * (ConveyorSpeed / PixelsToMM)) <= 0)
                            {
                                NumberOfNegitivYValues++;
                                //BoardBuffer.Clear();
                                //FoundBoardTimes.Clear();
                                //break;
                            }

                            if (NumberOfNegitivYValues == 0)
                            {
                                // Get the elapsed time in milliseconds
                                elapsedMilliseconds = ProgramTimer.ElapsedMilliseconds;//long
                                Console.WriteLine("ElapsedMilliseconds: " + elapsedMilliseconds);

                                //Draw elipses around the corners of already found stick
                                //ElipsedBinary = DrawElpses(binary, BoardBuffer[i], (int)Math.Round(((double)(FoundBoardTimes[i] - elapsedMilliseconds) / 1000) * (ConveyorSpeed / PixelsToMM)));//
                                ElipsedBinary = DrawElpses(binary, n, (int)Math.Round(((double)(FoundBoardTimes[n] - elapsedMilliseconds) / 1000) * (ConveyorSpeed / PixelsToMM)));//
                                ElipsedBinary = DrawPoly(binary, n, (int)Math.Round(((double)(FoundBoardTimes[n] - elapsedMilliseconds) / 1000) * (ConveyorSpeed / PixelsToMM)));
                                Console.WriteLine("Y Ofdet(px) = " + (int)Math.Round(((double)(FoundBoardTimes[n] - elapsedMilliseconds) / 1000) * (ConveyorSpeed / PixelsToMM)));
                                // Draw the rectangle with an offset of travel time and speeds
                                //DrawRectangleWithOffset(BoardBuffer[i], (int)Math.Round(((double)(FoundBoardTimes[i] - elapsedMilliseconds) / 1000) * (ConveyorSpeed / PixelsToMM)));
                            }
                            
                            
                        }
                        //if (BoardBuffer[i].Size != 4 || BoardBuffer[i].Size != 0)
                        //{
                        //    for (int j = 0; j < BoardBuffer[i].Size; j++)
                        //    {
                        //        Console.WriteLine("centerX = " + BoardBuffer[i][j].X);
                        //        Console.WriteLine("centerY = " + BoardBuffer[i][j].Y);
                        //    }
                        //}
                    }
                }
                
                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                CvInvoke.FindContours(ElipsedBinary, contours, null, RetrType.List, ChainApproxMethod.ChainApproxNone);//ElipsedBinary ChainApproxSimple

                //DEBUGGING
                PbBinaryThresh.Image = ElipsedBinary.ToBitmap();

                rectangles = new List<Point[]>();

                for (int i = 0; i < contours.Size; i++)
                {
                    VectorOfPoint contour = contours[i];
                    CvInvoke.ApproxPolyDP(contour, contour, 8, true);

                    if (contour.Size == 4 && IsRectangle(contour.ToArray())) // && !IsInsideOtherRectangle(contour.ToArray()) (Didn't Make A Differance)
                    {
                        rectangles.Add(contour.ToArray());

                        if (checkBoxCamCalMode.Checked == false)
                        {
                            //Add found rectangles to the buffer
                            for (int h = 0; h < BoardCount + 1; h++)//(Math.Round((double)BoardBuffer.Length / 10) - 1)
                            {
                                if (BoardBuffer[h * 10] == 0)
                                {
                                    for (int j = 0; j < 4; j += 1)
                                    {
                                        BoardBuffer[(h * 10) + (j * 2)] = contour[j].X;
                                        BoardBuffer[(h * 10) + (j * 2) + 1] = contour[j].Y;

                                    }

                                    long elapsedMilliseconds = ProgramTimer.ElapsedMilliseconds;
                                    FoundBoardTimes[h] = elapsedMilliseconds;

                                    for (int k = 0; k < BoardCount + 1; k++)//(Math.Round((double)BoardBuffer.Length / 10) - 1)
                                    {
                                        for (int l = 0; l < 10; l++)
                                        {
                                            Console.WriteLine("BoardBuffer[" + ((k * 10) + l) + "]: " + BoardBuffer[(k * 10) + l]);
                                        }
                                        Console.WriteLine("FoundBoardTimes[" + k + "]: " + FoundBoardTimes[k]);
                                    }



                                    BoardCount += 1;
                                    Console.WriteLine("BoardCount = " + BoardCount);

                                    break;
                                }
                            }
                        }
                    }
                }
            }

            PbCamSnip.Image = DrawRectangle(image, rectangles).ToBitmap();
        }

        private bool IsRectangle(Point[] points)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Point p1 = points[i];
                Point p2 = points[(i + 1) % points.Length];
                Point p3 = points[(i + 2) % points.Length];

                double angle = GetAngle(p1, p2, p3);
                double angleDiff = Math.Abs(angle - 90.0);

                if (angleDiff > AngleThresh)
                    return false;
            }

            double minLength = GetMaxLength(points);
            double maxLength = GetMaxLength(points);
            bool isValidLength = minLength >= MinLength && maxLength <= MaxLength;

            if (isValidLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private double GetAngle(Point p1, Point p2, Point p3)
        {
            double dx1 = p1.X - p2.X;
            double dy1 = p1.Y - p2.Y;
            double dx2 = p3.X - p2.X;
            double dy2 = p3.Y - p2.Y;

            double dot = dx1 * dx2 + dy1 * dy2;
            double cross = dx1 * dy2 - dy1 * dx2;

            return Math.Atan2(cross, dot) * (180.0 / Math.PI);
        }

        private void trackBarAngleThresh_Scroll(object sender, EventArgs e)
        {
            AngleThresh = trackBarAngleThresh.Value;
            labelAngleThresh.Text = trackBarAngleThresh.Value.ToString();
        }

        private void trackBarBinaryThresh_Scroll(object sender, EventArgs e)
        {
            BinaryThresh = trackBarBinaryThresh.Value;
            labelBinaryThresh.Text = trackBarBinaryThresh.Value.ToString();
        }

        private void textBoxMinLength_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBoxMinLength.Text, out MinLength);
        }

        private void textBoxMaxLength_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBoxMaxLength.Text, out MaxLength);
        }

        private bool IsInsideOtherRectangle(Point[] points)
        {
            foreach (var rectangle in rectangles)
            {
                if (IsInsideRectangle(points, rectangle))
                    return true;
            }

            return false;
        }

        private void CalibrateWarpPeramLoad()
        {
            //CAMERAMATRIX
            try
            {
                string[] lines = File.ReadAllLines(CamCalibrateFilePath);
                int startIndex = Array.IndexOf(lines, "Camera matrix :");
                if (startIndex == -1 || startIndex + 1 >= lines.Length)
                {
                    Console.WriteLine("Invalid format. The file does not contain the expected content.");
                    return;
                }
                for (int i = startIndex + 1; i < startIndex + 4; i++)
                {
                    string line = lines[i];
                    string[] values = line.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (values.Length != 3)
                    {
                        Console.WriteLine("Invalid format. Each line must contain three values.");
                        return;
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        if (float.TryParse(values[j], out float number))
                        {
                            cameraMatrix[i - startIndex - 1, j] = number;
                        }
                        else
                        {
                            Console.WriteLine($"Error parsing number on line {i + 1}, value {j + 1}.");
                            return;
                        }
                    }
                }
                Console.WriteLine("Camera Matrix:");
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(cameraMatrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }


            //DISTCOEF

            // Read all lines from the text file
            string[] lines2 = File.ReadAllLines(CamCalibrateFilePath);

            // Find the line containing "dist :"
            string distLine = Array.Find(lines2, line => line.Contains("dist :"));

            // Get the index of the line containing "dist :"
            int distLineIndex = Array.IndexOf(lines2, distLine);

            // Extract the matrix values from the next line
            if (distLineIndex + 1 < lines2.Length)
            {
                string matrixValuesString = lines2[distLineIndex + 1];

                // Split the matrix values by commas and convert them to floats
                string[] matrixValuesArray = matrixValuesString.Split(',');
                float[] matrixValues = new float[matrixValuesArray.Length];
                for (int i = 0; i < matrixValuesArray.Length; i++)
                {
                    if (float.TryParse(matrixValuesArray[i], out float value))
                    {
                        matrixValues[i] = value;
                    }
                    else
                    {
                        // Handle parsing error if needed
                        Console.WriteLine($"Error parsing value at index {i}: {matrixValuesArray[i]}");
                        return;
                    }
                }

                // Check if the matrix is 5x1 (optional, depending on your requirements)
                if (matrixValues.Length != 5)
                {
                    Console.WriteLine("The matrix does not have 5 elements.");
                    return;
                }

                // Create a 5x1 float matrix
                distortionCoeffs = new Emgu.CV.Matrix<float>(matrixValues);

                // Print the imported matrix
                Console.WriteLine("Imported Matrix:");
                for (int i = 0; i < distortionCoeffs.Rows; i++)
                {
                    Console.WriteLine(distortionCoeffs[i, 0]);
                }
            }
            else
            {
                Console.WriteLine("Unable to find matrix values after 'dist :'.");
            }
        }

        private void selectCamCalibrationFilePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.Title = "Select a Text Document";
                openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(CamCalibrateFilePath);


                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CamCalibrateFilePath = openFileDialog.FileName;
                }
            }
        }

        private void checkBoxLoadUndistortPeram_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLoadUndistortPeram.Checked)
            {
                CalibrateWarpPeramLoad();
            }
        }

        private void buttonCOMConnect_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
                buttonCOMConnect.Text = "Connect";
                comboBoxCOMPorts.Enabled = true;
                comboBoxBaudRate.Enabled = true;
                textBoxCOMUserInput.Enabled = false;
                buttonCOMManSend.Enabled = false;
            }
            else
            {
                if (comboBoxCOMPorts.SelectedItem != null)
                {
                    _serialPort.PortName = comboBoxCOMPorts.SelectedItem.ToString();
                    _serialPort.BaudRate = (int)comboBoxBaudRate.SelectedItem;
                    try
                    {
                        _serialPort.Open();
                        buttonCOMConnect.Text = "Disconnect";
                        comboBoxCOMPorts.Enabled = false;
                        comboBoxBaudRate.Enabled = false;
                        textBoxCOMUserInput.Enabled = true;
                        buttonCOMManSend.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error connecting to COM port: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a COM port.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCOMManSend_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                string message = textBoxCOMUserInput.Text.Trim();
                _serialPort.WriteLine(message);
            }
            else
            {
                MessageBox.Show("COM port is not connected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsInsideRectangle(Point[] points, Point[] reference)
        {
            for (int i = 0; i < points.Length; i++)
            {
                if (!IsInside(reference, points[i]))
                    return false;
            }

            return true;
        }

        private bool IsInside(Point[] polygon, Point point)
        {
            int j = polygon.Length - 1;
            bool isInside = false;

            for (int i = 0; i < polygon.Length; i++)
            {
                if (polygon[i].Y < point.Y && polygon[j].Y >= point.Y || polygon[j].Y < point.Y && polygon[i].Y >= point.Y)
                {
                    if (polygon[i].X + (point.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < point.X)
                    {
                        isInside = !isInside;
                    }
                }

                j = i;
            }

            return isInside;
        }

        private double GetMinLength(Point[] points)
        {
            double minLength = double.MaxValue;

            for (int i = 0; i < points.Length; i++)
            {
                Point p1 = points[i];
                Point p2 = points[(i + 1) % points.Length];

                double length = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
                minLength = Math.Min(minLength, length);
            }

            return minLength;
        }

        private double GetMaxLength(Point[] points)
        {
            double maxLength = 0;

            for (int i = 0; i < points.Length; i++)
            {
                Point p1 = points[i];
                Point p2 = points[(i + 1) % points.Length];

                double length = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
                maxLength = Math.Max(maxLength, length);
            }

            return maxLength;
        }

        private Image<Bgr, byte> DrawRectangle(Image<Bgr, byte> img, List<Point[]> rectangles)
        {
            //Image<Bgr, byte> result = img.CopyBlank();

            foreach (var rectangle in rectangles)
            {
                for (int i = 0; i < rectangle.Length; i++)
                {
                    Point p1 = rectangle[i];
                    Point p2 = rectangle[(i + 1) % rectangle.Length];

                    CvInvoke.Line(img, p1, p2, new MCvScalar(0, 0, 255), 2);
                    CvInvoke.PutText(img, $"({p1.X}, {p1.Y})", p1, Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.5, new MCvScalar(255, 0, 0), 1);
                }
            }

            return img;
        }

    }
}
