using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Buffers;

using Microsoft.Azure.Kinect.Sensor;
using Microsoft.Azure.Kinect.BodyTracking;

using Image = Microsoft.Azure.Kinect.Sensor.Image;
using BitmapData = System.Drawing.Imaging.BitmapData;



namespace AzureKineticTest_1
{
    public partial class Form1 : Form
    {
        private Device kinectDevice;
        private DeviceConfiguration deviceConfiguration;

        private Bitmap colorBitmap;
        private Bitmap depthBitmap;

        private bool isActive;

        private Tracker tracker;

        private List<Dictionary<JointId, Joint>> jointData; 
        


        public Form1()
        {
            InitializeComponent();

            InitKinect();

        }
        ~Form1()
        {
            kinectDevice.StopCameras();
            kinectDevice.Dispose();

            tracker.Dispose();

            isActive = false;
        }

        private async Task CalculateColor()
        {
            while (isActive)
            {
                using (Microsoft.Azure.Kinect.Sensor.Capture capture = await Task.Run(() => kinectDevice.GetCapture()).ConfigureAwait(true))
                {
                    unsafe
                    {
                        Image colorImage = capture.Color;

                        using (MemoryHandle pin = colorImage.Memory.Pin())
                        {
                            colorBitmap = new Bitmap(colorImage.WidthPixels, colorImage.HeightPixels, colorImage.StrideBytes, System.Drawing.Imaging.PixelFormat.Format32bppArgb, (IntPtr)pin.Pointer);
                        }

                        pictureBox_Color.Image = colorBitmap;
                    }

                    Update();
                }
            }

            return;
        }
        private async Task CalculateDepth()
        {
            while(isActive)
            {
                using (Capture capture = await Task.Run(() => kinectDevice.GetCapture()).ConfigureAwait(true))
                {
                    unsafe
                    {
                        Image depthImage = capture.Depth;

                        ushort[] depthArr = depthImage.GetPixels<ushort>().ToArray();
                        BitmapData bitmapData = depthBitmap.LockBits(new Rectangle(0, 0, depthBitmap.Width, depthBitmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);


                        byte* pixels = (byte*)bitmapData.Scan0;
                        
                        int depth = 0;
                        int tempIndex = 0;

                        for (int index = 0; index < depthArr.Length; index++)
                        {
                            depth = (int)(255 * (depthArr[index]) / 5000.0);

                            if (depth < 0 || depth > 255)
                            {
                                depth = 0;
                            }

                            tempIndex = index * 4;
                            pixels[tempIndex++] = (byte)depth;
                            pixels[tempIndex++] = (byte)depth;
                            pixels[tempIndex++] = (byte)depth;
                            pixels[tempIndex++] = 255;
                        }

                        depthBitmap.UnlockBits(bitmapData);


                        pictureBox_Depth.Image = depthBitmap;
                    }

                    Update();
                }
            }

            return;
        }
        private async Task CalcuateBodyTracking()
        {
            var calibration = kinectDevice.GetCalibration(deviceConfiguration.DepthMode, deviceConfiguration.ColorResolution);

            TrackerConfiguration trackerConfiguration = new TrackerConfiguration()
            {
                ProcessingMode = TrackerProcessingMode.Gpu,
                SensorOrientation = SensorOrientation.Default
            };

            tracker = Tracker.Create(
                calibration,
                new TrackerConfiguration
                {
                    SensorOrientation = SensorOrientation.Default,
                    ProcessingMode = TrackerProcessingMode.Gpu
                }
            );


            while (isActive)
            {
                using (Capture capture = await Task.Run(() => { return kinectDevice.GetCapture(); }))
                {
                    tracker.EnqueueCapture(capture);

                    using (Frame frame = tracker.PopResult())
                    using (Image color_image = frame.Capture.Color)
                    {
                        textBox_BodyTracking.Text = null;

                        jointData.Clear();

                        for (uint bodyIndex = 0; bodyIndex < frame.NumberOfBodies; bodyIndex++)
                        {
                            Skeleton skeleton = frame.GetBodySkeleton(bodyIndex);
                            uint id = frame.GetBodyId(bodyIndex);

                            if(bodyIndex >= 1)
                            {
                                textBox_BodyTracking.Text += Environment.NewLine + "------------------------------------------------------" + Environment.NewLine;
                            }

                            textBox_BodyTracking.Text += "Person Index : " + bodyIndex + Environment.NewLine;

                            jointData.Add(new Dictionary<JointId, Joint>());

                            for (int jointIndex = 0; jointIndex < (int)JointId.Count; jointIndex++)
                            {
                                Joint joint = skeleton.GetJoint(jointIndex);

                                textBox_BodyTracking.Text += "Joint Index : " + jointIndex + "   -   X : " + joint.Position.X + " / Y : " + joint.Position.Y + " / Z : " + joint.Position.Z + Environment.NewLine;

                                jointData[(int)bodyIndex].Add((JointId)jointIndex, joint);
                            }
                        }
                    }
                }
            }

            return;
        }

        private void InitBitMap()
        {
            int colorWidth = kinectDevice.GetCalibration().ColorCameraCalibration.ResolutionWidth;
            int colorHeight = kinectDevice.GetCalibration().ColorCameraCalibration.ResolutionHeight;

            int depthWidth = kinectDevice.GetCalibration().DepthCameraCalibration.ResolutionWidth;
            int depthheight = kinectDevice.GetCalibration().DepthCameraCalibration.ResolutionHeight;


            colorBitmap = new Bitmap(colorWidth, colorHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            depthBitmap = new Bitmap(depthWidth, depthheight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        private void InitKinect()
        {
            try
            {
                kinectDevice = Device.Open(0);

                deviceConfiguration = new DeviceConfiguration()
                {
                    ColorFormat = ImageFormat.ColorBGRA32,
                    ColorResolution = ColorResolution.R720p,
                    DepthMode = DepthMode.NFOV_2x2Binned,
                    CameraFPS = FPS.FPS15,
                    SynchronizedImagesOnly = true
                };
            }
            catch (AzureKinectException ex)
            {
                textBox_Error.Text += "1> Exception is occur during open kinect device" + Environment.NewLine + "1> Please check your device connection" + Environment.NewLine;
                textBox_Error.Text += ex.ToString() + Environment.NewLine;
            }
        }

        private void button_CameraCapture_Click(object sender, EventArgs e)
        {
            if(!isActive)
            {
                

                try
                {
                    kinectDevice.StartCameras(deviceConfiguration);
                }
                catch(AzureKinectException ex)
                {
                    textBox_Error.Text += "1> Exception is occur during start kinect device" + Environment.NewLine + "1> Please check your device connection" + Environment.NewLine;
                    textBox_Error.Text += ex.ToString() + Environment.NewLine;
                }


                isActive = true;

                InitBitMap();

                bool flag = true;
                if (checkBox_Color.Checked)
                {
                    flag = false;

                    CalculateColor();
                }
                if(checkBox_Depth.Checked)
                {
                    flag = false;

                    CalculateDepth();
                }
                if(checkBox_BodyTracking.Checked)
                {
                    flag = false;

                    CalcuateBodyTracking();

                    if(jointData == null)
                    {
                        jointData = new List<Dictionary<JointId, Joint>>();
                    }
                }
                
                if(flag)
                {
                    textBox_Error.Text += "=== No check box selected ===" + Environment.NewLine;
                    textBox_Error.Text += "[" + System.DateTime.Now.ToString("hh-mm-ss") + "] > Capture fail time" + Environment.NewLine;
                }
                else
                {
                    textBox_Error.Text += "=== Capture start ===" + Environment.NewLine;
                    textBox_Error.Text += "[" + System.DateTime.Now.ToString("hh-mm-ss") + "] > Capture start time" + Environment.NewLine;
                }
            }
            else
            {
                isActive = false;

                kinectDevice.StopCameras();
                tracker.Dispose();

                colorBitmap.Dispose();
                depthBitmap.Dispose();

                textBox_Error.Text += "=== Capture end ===" + Environment.NewLine;
                textBox_Error.Text += "[" + System.DateTime.Now.ToString("hh-mm-ss") + "] > Capture end time" + Environment.NewLine + Environment.NewLine;
            }
        }
        private void button_SaveToTxt_Click(object sender, EventArgs e)
        {
            if(checkBox_BodyTracking.Checked)
            {
                string path = System.IO.Path.Combine(@textBox_Path.Text, "BodyTrakingData_" + System.DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss"));
                bool flag = false;

                try
                {
                    var fileStream = System.IO.File.Create(path);
                    fileStream.Close();

                    lock (jointData)
                    {
                        System.IO.File.WriteAllText(path, Newtonsoft.Json.JsonConvert.SerializeObject(jointData));
                    }
                }
                catch (Exception ex)
                {
                    flag = true;

                    textBox_Error.Text += "1> Exception is occur during save body traking data" + Environment.NewLine;
                    textBox_Error.Text += ex.ToString() + Environment.NewLine;
                }

                if (!flag)
                {
                    textBox_Error.Text += "[" + System.DateTime.Now.ToString("hh-mm-ss") + "] > Body traking data is saved in : " + path + Environment.NewLine;
                }
            }
        }
        private void button_SetFPS5_Click(object sender, EventArgs e)
        {
            if(!isActive)
            {
                deviceConfiguration.CameraFPS = FPS.FPS5;
            }
        }
        private void button_SetFPS15_Click(object sender, EventArgs e)
        {
            if (!isActive)
            {
                deviceConfiguration.CameraFPS = FPS.FPS15;
            }
        }
        private void button_SetFPS30_Click(object sender, EventArgs e)
        {
            if (!isActive)
            {
                deviceConfiguration.CameraFPS = FPS.FPS30;
            }
        }
    }
}