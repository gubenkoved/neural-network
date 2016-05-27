using System;
using System.Windows.Forms;
using System.Drawing;

namespace NeuroNet.Desktop
{
    public class PaintBoard : PictureBox
    {
        private double[,] _intensityMap;
        private Graphics _graphics;

        private int _xResolution;
        private int _yResolution;

        public int XResolution
        {
            get { return _xResolution; }
            set
            {
                _xResolution = value;

                _intensityMap = null;

                RecreateGraphics();
                RedrawBinaryImage();

            }
        }

        public int YResolution
        {
            get { return _yResolution; }
            set
            {
                _yResolution = value;
                _intensityMap = null;

                RecreateGraphics();
                RedrawBinaryImage();

            }
        }

        public int BrushRadius { get; set; }

        public double[,] IntensityMap
        { 
            get
            {
                if (_intensityMap == null)
                {
                    _intensityMap = new double[XResolution, YResolution];
                }

                return _intensityMap;
            }}

        public double[] ImageAsVector
        {
            get
            {
                var vector = new double[XResolution * YResolution];
                int n = 0;

                for (int i = 0; i < XResolution; i++)
                {
                    for (int j = 0; j < YResolution; j++)
                    {
                        vector[n] = IntensityMap[i, j];

                        ++n;
                    }
                }
                return vector;
            }
        }

        private void RecreateGraphics()
        {
            Image = new Bitmap(Size.Width, Size.Height);

            _graphics = Graphics.FromImage(Image);
        }

        private void RedrawBinaryImage()
        {
            float blockWidth = Width / (float) XResolution;
            float blockHeight = Height / (float) YResolution;

            for (int i = 0; i < XResolution; i++)
            {
                for (int j = 0; j < YResolution; j++)
                {
                    int rgb = (int) (IntensityMap[i, j] * 255);

                    Color color = Color.FromArgb(255, rgb, rgb, rgb);

                    _graphics.FillRectangle(new SolidBrush(color), i * blockWidth, j * blockHeight, blockWidth,
                                            blockHeight);
                }
            }

            Invalidate();
        }

        private void PutPointOn(float x, float y, bool value = true)
        {
            int i = (int)((x / Width) * XResolution);
            int j = (int)((y / Height) * YResolution);

            if (i < 0 || i >= XResolution)
                return;

            if (j < 0 || j >= YResolution)
                return;

            for (int k = Math.Max(0, i - BrushRadius); k <= Math.Min(XResolution - 1, i + BrushRadius); k++)
            {
                for (int l = Math.Max(0, j - BrushRadius); l <= Math.Min(YResolution - 1, j + BrushRadius); l++)
                {
                    int dI = k - i;
                    int dJ = l - j;

                    double dist = Math.Sqrt(dI * dI + dJ * dJ);
                    double intensity = value ? 1.0 / Math.Sqrt(dist + 1.0) : 0.0;

                    if (dist <= BrushRadius)
                    {
                        if (value)
                            IntensityMap[k, l] = Math.Max(IntensityMap[k, l], intensity);
                        else
                            IntensityMap[k, l] = intensity;
                    }
                }
            }

            RedrawBinaryImage();
        }

        private bool _leftMouseButtonPressed;
        private bool _rightMouseButtonPressed;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _leftMouseButtonPressed = true;
                
                PutPointOn(e.X, e.Y);
            }
            else if (e.Button == MouseButtons.Right)
            {
                _rightMouseButtonPressed = true;
                
                PutPointOn(e.X, e.Y, false);
            }

             base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _leftMouseButtonPressed = false;
            }
            else if (e.Button == MouseButtons.Right)
            {
                _rightMouseButtonPressed = false;
            }

            if (RecognizeRequest != null)
                RecognizeRequest(this);

            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_leftMouseButtonPressed)
            {
                PutPointOn(e.X, e.Y);
            }
            else if (_rightMouseButtonPressed)
            {
                PutPointOn(e.X, e.Y, false);
            }

            base.OnMouseMove(e);
        }
    
        protected override void OnClientSizeChanged(System.EventArgs e)
        {
            base.OnClientSizeChanged(e);

             RecreateGraphics();
             RedrawBinaryImage();
        }

        public delegate void RecognizeRequestHandler(object sender);

        public event RecognizeRequestHandler RecognizeRequest;
    }
}
