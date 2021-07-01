using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Buffers;

using Microsoft.Azure.Kinect.Sensor;
using Microsoft.Azure.Kinect.BodyTracking;

using Image = Microsoft.Azure.Kinect.Sensor.Image;
using BitmapData = System.Drawing.Imaging.BitmapData;

using K4A = Microsoft.Azure.Kinect.Sensor;
using K4ABT = Microsoft.Azure.Kinect.BodyTracking;



namespace AzureKineticTest_1
{
    public partial class Form1 : Form
    {
        private Device kinectForColorDepth;
        //private Device kinectForBodtTraking;
        private DeviceConfiguration deviceConfigurationForColorDepth, deviceConfigurationForBodyTraking;

        private Bitmap colorBitmap;
        private Bitmap depthBitmap;

        private bool isLoop;

        private Tracker tracker;
        



        public Form1()
        {
            InitializeComponent();

            InitKinect();
            InitBitMap();

            isLoop = true;
            CalculateColor();
            CalculateDepth();
            CalcuateBodyTraking();

        }
        ~Form1()
        {
            kinectForColorDepth.StopCameras();
            isLoop = false;
        }

        private async Task CalculateColor()
        {
            while (isLoop)
            {
                using (Microsoft.Azure.Kinect.Sensor.Capture capture = await Task.Run(() => kinectForColorDepth.GetCapture()).ConfigureAwait(true))
                {
                    unsafe
                    {
                        Image colorImage = capture.Color;

                        using (MemoryHandle pin = colorImage.Memory.Pin())
                        {
                            colorBitmap = new Bitmap(colorImage.WidthPixels, colorImage.HeightPixels, colorImage.StrideBytes, System.Drawing.Imaging.PixelFormat.Format32bppArgb, (IntPtr)pin.Pointer);
                            //depthBitmap = new Bitmap(depthImage.WidthPixels, depthImage.HeightPixels, colorImage.StrideBytes, System.Drawing.Imaging.PixelFormat.Format32bppArgb, (IntPtr)pin.Pointer);
                        }

                        pictureBox_Color.Image = colorBitmap;
                    }

                    Update();
                }
            }
        }
        private async Task CalculateDepth()
        {
            while(isLoop)
            {
                using (Microsoft.Azure.Kinect.Sensor.Capture capture = await Task.Run(() => kinectForColorDepth.GetCapture()).ConfigureAwait(true))
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
        }
        private async Task CalcuateBodyTraking()
        {
            var calibration = kinectForColorDepth.GetCalibration(deviceConfigurationForColorDepth.DepthMode, deviceConfigurationForColorDepth.ColorResolution);

            TrackerConfiguration trackerConfiguration = new TrackerConfiguration()
            {
                ProcessingMode = TrackerProcessingMode.Gpu,
                SensorOrientation = SensorOrientation.Default
            };

            tracker = K4ABT.Tracker.Create(
                calibration,
                new K4ABT.TrackerConfiguration
                {
                    SensorOrientation = K4ABT.SensorOrientation.Default,
                    ProcessingMode = K4ABT.TrackerProcessingMode.Gpu
                }
            );

            //System.Numerics.Vector2?[] vectors = new System.Numerics.Vector2?[31];

            while (isLoop)
            {
                //using (var traker = Tracker.Create(calibration, trackerConfiguration))
                //{
                //    while(isLoop)
                //    {
                //        using(Microsoft.Azure.Kinect.Sensor.Capture capture = kinectForBodtTraking.GetCapture())
                //        {
                //            traker.EnqueueCapture(capture);
                //        }

                //        using(Frame frame = traker.PopResult(TimeSpan.Zero, false))
                //        {
                //            if(frame != null && frame.NumberOfBodies > 0)
                //            {
                //                Skeleton skeleton = frame.GetBodySkeleton(0);
                //                Joint joint = skeleton.GetJoint(JointId.Head);
                //                textBox1.Text = "X : " + joint.Position.X + " / Y : " + joint.Position.Y + " / Z : " + joint.Position.Z;
                //            }
                //        }
                //    }
                //}
                using (K4A.Capture capture = await Task.Run(() => { return kinectForColorDepth.GetCapture(); }))
                {
                    // Enque Capture
                    tracker.EnqueueCapture(capture);

                    // Pop Result
                    using (K4ABT.Frame frame = tracker.PopResult())
                    // Get Color Image
                    using (K4A.Image color_image = frame.Capture.Color)
                    {
                        //// Get Color Buffer and Write Bitmap
                        //byte[] color_buffer = color_image.Memory.ToArray();
                        //color_bitmap.WritePixels(color_rect, color_buffer, color_stride, 0, 0);

                        //// Clear All Ellipse from Canvas
                        //Canvas_Body.Children.Clear();

                        textBox1.Text = null;

                        // Draw Skeleton
                        for (uint body_index = 0; body_index < frame.NumberOfBodies; body_index++)
                        {
                            // Get Skeleton and ID
                            K4ABT.Skeleton skeleton = frame.GetBodySkeleton(body_index);
                            uint id = frame.GetBodyId(body_index);

                            if(body_index >= 1)
                            {
                                textBox1.Text += Environment.NewLine + "------------------------------------------------------" + Environment.NewLine;
                            }

                            textBox1.Text += "Person Index : " + body_index + Environment.NewLine;

                            // Draw Joints
                            for (int joint_index = 0; joint_index < (int)K4ABT.JointId.Count; joint_index++)
                            {
                                // Get Joint and Position
                                K4ABT.Joint joint = skeleton.GetJoint(joint_index);
                                //System.Numerics.Vector2? position = calibration.TransformTo2D(joint.Position, K4A.CalibrationDeviceType.Depth, K4A.CalibrationDeviceType.Color);

                                //if (!position.HasValue)
                                //{
                                //    continue;
                                //}

                                //// Create Ellipse
                                //const int radius = 10;
                                //SolidColorBrush stroke_color = new SolidColorBrush(colors[id % colors.Length]);
                                //SolidColorBrush fill_color = new SolidColorBrush((joint.ConfidenceLevel >= K4ABT.JointConfidenceLevel.Medium) ? colors[id % colors.Length] : Colors.Transparent);
                                //Ellipse ellipse = new Ellipse() { Width = radius, Height = radius, StrokeThickness = 1, Stroke = stroke_color, Fill = fill_color };

                                //// Add Ellipse to Canvas
                                //Canvas.SetLeft(ellipse, position.Value.X - (radius / 2));
                                //Canvas.SetTop(ellipse, position.Value.Y - (radius / 2));
                                //Canvas_Body.Children.Add(ellipse);

                                //vectors[joint_index] = position;

                                textBox1.Text += "Joint Index : " + joint_index + "   -   X : " + joint.Position.X + " / Y : " + joint.Position.Y + " / Z : " + joint.Position.Z + Environment.NewLine;
                            }
                        }
                    }
                }
            }
        }
        private void InitBitMap()
        {
            int colorWidth = kinectForColorDepth.GetCalibration().ColorCameraCalibration.ResolutionWidth;
            int colorHeight = kinectForColorDepth.GetCalibration().ColorCameraCalibration.ResolutionHeight;

            int depthWidth = kinectForColorDepth.GetCalibration().DepthCameraCalibration.ResolutionWidth;
            int depthheight = kinectForColorDepth.GetCalibration().DepthCameraCalibration.ResolutionHeight;



            colorBitmap = new Bitmap(colorWidth, colorHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            depthBitmap = new Bitmap(depthWidth, depthheight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        }
        private void InitKinect()
        {
            kinectForColorDepth = Device.Open(0);
            //kinectForBodtTraking = Device.Open(0);

            deviceConfigurationForColorDepth = new DeviceConfiguration()
            {
                ColorFormat = ImageFormat.ColorBGRA32,
                ColorResolution = ColorResolution.R720p,
                DepthMode = DepthMode.NFOV_2x2Binned,
                SynchronizedImagesOnly = true
            };
            //deviceConfigurationForBodyTraking = new DeviceConfiguration()
            //{
            //    ColorResolution = ColorResolution.Off,
            //    DepthMode = DepthMode.NFOV_2x2Binned
            //};
            kinectForColorDepth.StartCameras(deviceConfigurationForColorDepth);
            //kinectForBodtTraking.StartCameras(deviceConfigurationForColorDepth);
        }
    }
}
