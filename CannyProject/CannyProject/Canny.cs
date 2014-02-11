using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;

namespace CannyProject
{
    public class Canny
    {
        public Bitmap ObjInputImage;
        public int[,] GreyImage;

        //Gaussian Kernel Data
        private readonly int _kernelSize = 5;
        private readonly float _sigma = 1;   // for N=2 Sigma =0.85  N=5 Sigma =1, N=9 Sigma = 2    2*Sigma = (int)N/2
        //Canny Edge Detection Parameters
        private float _maxHysteresisThresh, _minHysteresisThresh;
        public int[,] GaussianFilterImage;
        public float[,] Gradient;
        public float[,] NonMax;
        public int[,] PostHysteresis;
        private int[,] _edgePoints;
        public float[,] GNH;
        public float[,] GNL;
        public int[,] EdgeMap;
        public int[,] VisitedMap;
        public float[,] SpecialMatrix;
        public float[,] SpecialMatrix2;
        private int _size;
        private int _shift;
        private float _koefficient1;
        private float _koefficient2;
        private float _koefficient3;

        public Canny(Bitmap inputImage, float maxHysteresisThresh, float minHysteresisThresh, int gaussianMaskSize, float sigmaforGaussianKernel,
            int shift, int shiftSize, float koefficient1, float koefficient2, float koefficient3)
        {
            _koefficient1 = koefficient1;
            _koefficient2 = koefficient2;
            _koefficient3 = koefficient3;
            _shift = shift;
            _size = shiftSize;
            _kernelSize = gaussianMaskSize;
            _sigma = sigmaforGaussianKernel;
            SetGaussianAndCannyParameters(inputImage, maxHysteresisThresh, minHysteresisThresh);
            ReadImage();
            DetectCannyEdges();
        }

        private void SetGaussianAndCannyParameters(Bitmap inputImage, float maxHysteresisThresh, float minHysteresisThresh)
        {
            _maxHysteresisThresh = maxHysteresisThresh;
            _minHysteresisThresh = minHysteresisThresh;
            ObjInputImage = inputImage;
            EdgeMap = new int[ObjInputImage.Width, ObjInputImage.Height];
            VisitedMap = new int[ObjInputImage.Width, ObjInputImage.Height];
        }

        public Bitmap GetDisplayedImage(int[,] greyImage)
        {
            int width = greyImage.GetLength(0);
            int height = greyImage.GetLength(1);
            return GetDisplayedImage(greyImage, width, height);
        }

        private Bitmap GetDisplayedImage(int[,] greyImage, int width, int height)
        {
            var image = new Bitmap(width, height);
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, width, height),
                                     ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                var imagePointer1 = (byte*)bitmapData1.Scan0;
                for (var i = 0; i < bitmapData1.Height; i++)
                {
                    for (var j = 0; j < bitmapData1.Width; j++)
                    {
                        imagePointer1[0] = (byte)greyImage[j, i];
                        imagePointer1[1] = (byte)greyImage[j, i];
                        imagePointer1[2] = (byte)greyImage[j, i];
                        imagePointer1[3] = 255;
                        imagePointer1 += 4;
                    }
                    imagePointer1 += (bitmapData1.Stride - (bitmapData1.Width * 4));
                }
            }
            image.UnlockBits(bitmapData1);
            return image;
        }

        public Bitmap GetDisplayedImage(float[,] greyImage)
        {
            int width = greyImage.GetLength(0);
            int height = greyImage.GetLength(1);
            return GetDisplayedImage(greyImage, width, height);
        }

        private Bitmap GetDisplayedImage(float[,] greyImage, int width, int height)
        {
            var image = new Bitmap(width, height);
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, width, height),
                                     ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                var imagePointer1 = (byte*)bitmapData1.Scan0;
                for (var i = 0; i < bitmapData1.Height; i++)
                {
                    for (var j = 0; j < bitmapData1.Width; j++)
                    {
                        imagePointer1[0] = (byte)greyImage[j, i];
                        imagePointer1[1] = (byte)greyImage[j, i];
                        imagePointer1[2] = (byte)greyImage[j, i];
                        imagePointer1[3] = 255;
                        imagePointer1 += 4;
                    }
                    imagePointer1 += (bitmapData1.Stride - (bitmapData1.Width * 4));
                }
            }
            image.UnlockBits(bitmapData1);
            return image;
        }

        private void ReadImage()
        {
            GreyImage = new int[ObjInputImage.Width,ObjInputImage.Height]; //[Row,Column]
            Bitmap image = ObjInputImage;
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* imagePointer1 = (byte*) bitmapData1.Scan0;
                for (var i = 0; i < bitmapData1.Height; i++)
                {
                    for (var j = 0; j < bitmapData1.Width; j++)
                    {
                        GreyImage[j, i] = (int) ((imagePointer1[0] + imagePointer1[1] + imagePointer1[2])/3.0);
                        imagePointer1 += 4;
                    }
                    imagePointer1 += bitmapData1.Stride - (bitmapData1.Width*4);
                }
            }
            image.UnlockBits(bitmapData1);
        }

        private void DetectCannyEdges()
        {
            PostHysteresis = new int[ObjInputImage.Width, ObjInputImage.Height];
            GaussianFilterImage = GetGaussianFilterImage();
            float[,] derivativeX = GetDifferentiateX(GaussianFilterImage);
            float[,] derivativeY = GetDifferentiateY(GaussianFilterImage);
            Gradient = ComputeGradientByDerivativesXY(derivativeX, derivativeY);
            NonMax = PerformNonMaximumSuppression(Gradient);


            int limit = _kernelSize / 2;
            SetNonMaxZero(limit, derivativeX,derivativeY);
            SetPostHysretesisFromNonMax(limit);

            //Find Max and Min in Post Hysterisis
            float min = 999;
            float max = 0;
            for (var r = limit; r <= (ObjInputImage.Width - limit) - 1; r++)
            {
                for (var c = limit; c <= (ObjInputImage.Height - limit) - 1; c++)
                {
                    if (PostHysteresis[r, c] > max)
                    {
                        max = PostHysteresis[r, c];
                    }

                    if ((PostHysteresis[r, c] < min) && (PostHysteresis[r, c] > 0))
                    {
                        min = PostHysteresis[r, c];
                    }
                }
            }

            SetGnhGnlEdgePoints(limit);
            HysterisisThresholding(_edgePoints);
            SetEdgeMap255();
        }

        private int[,] GetGaussianFilterImage()
        {
            int kernelWeight;
            var gaussianKernel = GetGaussianKernel(_kernelSize, _sigma, out kernelWeight);
            int limit = _kernelSize / 2;
            int[,] output = GreyImage;

            for (var i = limit; i <= ((ObjInputImage.Width - 1) - limit); i++)
            {
                for (var j = limit; j <= ((ObjInputImage.Height - 1) - limit); j++)
                {
                    float sum = 0;
                    for (var k = -limit; k < limit; k++)
                    {
                        for (var l = -limit; l < limit; l++)
                        {
                            sum = sum + ((float)GreyImage[i + k, j + l] * gaussianKernel[limit + k, limit + l]);
                        }
                    }
                    output[i, j] = (int)(Math.Round(sum / kernelWeight));
                }
            }
            return output;
        }

        private int[,] GetGaussianKernel(int kernelSize, float sigma, out int Weight)
        {
            float pi;
            pi = (float)Math.PI;

            var kernel = new float[kernelSize, kernelSize];
            var gaussianKernel = new int[kernelSize, kernelSize];

            float d1 = 1 / (2 * pi * sigma * sigma);
            float d2 = 2 * sigma * sigma;

            float min = 1000;

            for (var i = -kernelSize / 2; i < kernelSize / 2; i++)
            {
                for (var j = -kernelSize / 2; j < kernelSize / 2; j++)
                {
                    kernel[kernelSize / 2 + i, kernelSize / 2 + j] = ((1 / d1) * (float)Math.Exp(-(i * i + j * j) / d2));
                    if (kernel[kernelSize / 2 + i, kernelSize / 2 + j] < min)
                        min = kernel[kernelSize / 2 + i, kernelSize / 2 + j];

                }
            }
            int mult = (int)(1 / min);
            int sum = 0;
            if ((min > 0) && (min < 1))
            {
                for (var i = -kernelSize / 2; i < kernelSize / 2; i++)
                {
                    for (var j = -kernelSize / 2; j < kernelSize / 2; j++)
                    {
                        kernel[kernelSize / 2 + i, kernelSize / 2 + j] = (float)Math.Round(kernel[kernelSize / 2 + i, kernelSize / 2 + j] * mult, 0);
                        gaussianKernel[kernelSize / 2 + i, kernelSize / 2 + j] = (int)kernel[kernelSize / 2 + i, kernelSize / 2 + j];
                        sum = sum + gaussianKernel[kernelSize / 2 + i, kernelSize / 2 + j];
                    }
                }
            }
            else
            {
                sum = 0;
                for (var i = -kernelSize / 2; i < kernelSize / 2; i++)
                {
                    for (var j = -kernelSize / 2; j < kernelSize / 2; j++)
                    {
                        kernel[kernelSize / 2 + i, kernelSize / 2 + j] = (float)Math.Round(kernel[kernelSize / 2 + i, kernelSize / 2 + j], 0);
                        gaussianKernel[kernelSize / 2 + i, kernelSize / 2 + j] = (int)kernel[kernelSize / 2 + i, kernelSize / 2 + j];
                        sum = sum + gaussianKernel[kernelSize / 2 + i, kernelSize / 2 + j];
                    }
                }
            }
            //Normalizing kernel Weight
            Weight = sum;

            return gaussianKernel;
        }

        private float[,] GetDifferentiateX(int[,] gaussianFilterImage)
        {
            int[,] sobelMasksDx =
                {
                    {1, 0, -1},
                    {2, 0, -2},
                    {1, 0, -1}
                };
            return Differentiate(gaussianFilterImage, sobelMasksDx);
        }

        private float[,] GetDifferentiateY(int[,] gaussianFilterImage)
        {
            int[,] sobelMasksDy =
                {
                    {1, 2, 1},
                    {0, 0, 0},
                    {-1, -2, -1}
                };
            return Differentiate(gaussianFilterImage, sobelMasksDy);
        }

        private float[,] Differentiate(int[,] data, int[,] filter)
        {
            var filterWidth = filter.GetLength(0);
            var filterHeight = filter.GetLength(1);
            var output = new float[ObjInputImage.Width,ObjInputImage.Height];

            for (var i = filterWidth/2; i <= (ObjInputImage.Width - filterWidth/2) - 1; i++)
            {
                for (var j = filterHeight/2; j <= (ObjInputImage.Height - filterHeight/2) - 1; j++)
                {
                    float sum = 0;
                    for (var k = -filterWidth/2; k <= filterWidth/2; k++)
                    {
                        for (var l = -filterHeight/2; l <= filterHeight/2; l++)
                        {
                            sum = sum + data[i + k, j + l]*filter[filterWidth/2 + k, filterHeight/2 + l];
                        }
                    }
                    output[i, j] = sum;
                }
            }
            return output;
        }

        private float[,] ComputeGradientByDerivativesXY(float[,] derivativeX, float[,] derivativeY)
        {
            var gradient = new float[ObjInputImage.Width, ObjInputImage.Height];
            for (var i = 0; i <= (ObjInputImage.Width - 1); i++)
            {
                for (var j = 0; j <= (ObjInputImage.Height - 1); j++)
                {
                    gradient[i, j] = (float)Math.Sqrt((derivativeX[i, j] * derivativeX[i, j]) + (derivativeY[i, j] * derivativeY[i, j]));
                }
            }
            gradient = MyTestChangeGradient(gradient);
            return gradient;
        }

        private float[,] MyTestChangeGradient(float[,] gradient)
        {
            SpecialMatrix = new float[ObjInputImage.Width,ObjInputImage.Height];
            SpecialMatrix2 = new float[ObjInputImage.Width, ObjInputImage.Height];
            var specWidth = _size;
            var specHeight = _size;
            var specStep = _shift;
            for (var i = 0; i <= (ObjInputImage.Width - 1) - specWidth; i += specStep)
            {
                for (var j = 0; j <= (ObjInputImage.Height - 1) - specHeight; j += specStep)
                {
                    float total = 0;
                    for (var si = i; si <= i+specWidth; si++)
                    {
                        for (var sj = j; sj <= j+specHeight; sj++)
                        {
                            total += gradient[si, sj];
                        }
                    }
                    var avg = total/(specWidth*specHeight);
                    for (var si = 0; si <= specWidth; si++)
                    {
                        for (var sj = 0; sj <= specHeight; sj++)
                        {
                            SpecialMatrix[i + si, j + sj] += avg;
                            SpecialMatrix2[i + si, j + sj] += 1;
                        }
                    }
                }
            }
            for (var i = 0; i <= (ObjInputImage.Width - 1); i++)
            {
                for (var j = 0; j <= (ObjInputImage.Height - 1); j++)
                {
                    //if (SpecialMatrix[i, j] > 14)
                    {
                        SpecialMatrix[i, j] = SpecialMatrix[i, j] / SpecialMatrix2[i, j];
                    }
                }
            }

            for (var i = 0; i <= (ObjInputImage.Width - 1); i++)
            {
                for (var j = 0; j <= (ObjInputImage.Height - 1); j++)
                {
                    if (gradient[i, j] < (SpecialMatrix[i, j] * _koefficient1))
                    {
                        gradient[i, j] = 0;
                    }
                }
            }
            return gradient;
        }
        private float[,] PerformNonMaximumSuppression(float[,] gradient)
        {
            // NonMax = Gradient; ?? ^_^
            var nonMax = new float[ObjInputImage.Width, ObjInputImage.Height];
            for (var i = 0; i <= (ObjInputImage.Width - 1); i++)
            {
                for (var j = 0; j <= (ObjInputImage.Height - 1); j++)
                {
                    nonMax[i, j] = gradient[i, j];
                }
            }
            return nonMax;
        }

        private void SetNonMaxZero(int limit, float[,] derivativeX, float[,] derivativeY)
        {
            for (var i = limit; i <= (ObjInputImage.Width - limit) - 1; i++)
            {
                for (var j = limit; j <= (ObjInputImage.Height - limit) - 1; j++)
                {
                    float tangent = derivativeX[i, j] == 0 ? 90F
                                        : (float)(Math.Atan(derivativeY[i, j] / derivativeX[i, j]) * 180 / Math.PI); //сомнительная херня, увеличивает производительность?

                    //Horizontal Edge
                    if (((-22.5 < tangent) && (tangent <= 22.5)) || ((157.5 < tangent) && (tangent <= -157.5)))
                    {
                        if ((Gradient[i, j] < Gradient[i, j + 1]) || (Gradient[i, j] < Gradient[i, j - 1]))
                            NonMax[i, j] = 0;
                    }


                    //Vertical Edge
                    if (((-112.5 < tangent) && (tangent <= -67.5)) || ((67.5 < tangent) && (tangent <= 112.5)))
                    {
                        if ((Gradient[i, j] < Gradient[i + 1, j]) || (Gradient[i, j] < Gradient[i - 1, j]))
                            NonMax[i, j] = 0;
                    }

                    //+45 Degree Edge
                    if (((-67.5 < tangent) && (tangent <= -22.5)) || ((112.5 < tangent) && (tangent <= 157.5)))
                    {
                        if ((Gradient[i, j] < Gradient[i + 1, j - 1]) || (Gradient[i, j] < Gradient[i - 1, j + 1]))
                            NonMax[i, j] = 0;
                    }

                    //-45 Degree Edge
                    if (((-157.5 < tangent) && (tangent <= -112.5)) || ((67.5 < tangent) && (tangent <= 22.5)))
                    {
                        if ((Gradient[i, j] < Gradient[i + 1, j + 1]) || (Gradient[i, j] < Gradient[i - 1, j - 1]))
                            NonMax[i, j] = 0;
                    }
                }
            }
        }

        private void SetPostHysretesisFromNonMax(int limit)
        {
            //PostHysteresis = NonMax;
            for (var r = limit; r <= (ObjInputImage.Width - limit) - 1; r++)
            {
                for (var c = limit; c <= (ObjInputImage.Height - limit) - 1; c++)
                {
                    PostHysteresis[r, c] = (int)NonMax[r, c];
                }

            }
        }

        private void SetGnhGnlEdgePoints(int limit)
        {
            GNH = new float[ObjInputImage.Width, ObjInputImage.Height];
            GNL = new float[ObjInputImage.Width, ObjInputImage.Height];
            _edgePoints = new int[ObjInputImage.Width, ObjInputImage.Height];

            for (var i = limit; i <= (ObjInputImage.Width - limit) - 1; i++)
            {
                for (var j = limit; j <= (ObjInputImage.Height - limit) - 1; j++)
                {
                    if (PostHysteresis[i, j] >= _maxHysteresisThresh)
                    {
                        _edgePoints[i, j] = 1;
                        GNH[i, j] = 255;
                    }
                    if ((PostHysteresis[i, j] < _maxHysteresisThresh) && (PostHysteresis[i, j] >= _minHysteresisThresh))
                    {
                        _edgePoints[i, j] = 2;
                        GNL[i, j] = 255;
                    }
                }
            }
        }

        private void HysterisisThresholding(int[,] edges)
        {
            int limit = _kernelSize / 2;
            for (var i = limit; i <= (ObjInputImage.Width - 1) - limit; i++)
            {
                for (var j = limit; j <= (ObjInputImage.Height - 1) - limit; j++)
                {
                    if (edges[i, j] == 1)
                    {
                        EdgeMap[i, j] = 1;
                        Travers(i, j);
                        VisitedMap[i, j] = 1;
                    }
                }
            }
        }

        private void SetEdgeMap255()
        {
            for (var i = 0; i <= (ObjInputImage.Width - 1); i++)
            {
                for (var j = 0; j <= (ObjInputImage.Height - 1); j++)
                {
                    EdgeMap[i, j] = EdgeMap[i, j] * 255;
                }
            }
        }


        private void Travers(int X, int Y)
        {

            if (VisitedMap[X, Y] == 1)
            {
                return;
            }

            //1
            if (_edgePoints[X + 1, Y] == 2)
            {
                EdgeMap[X + 1, Y] = 1;
                VisitedMap[X + 1, Y] = 1;
                Travers(X + 1, Y);
                return;
            }
            //2
            if (_edgePoints[X + 1, Y - 1] == 2)
            {
                EdgeMap[X + 1, Y - 1] = 1;
                VisitedMap[X + 1, Y - 1] = 1;
                Travers(X + 1, Y - 1);
                return;
            }

            //3

            if (_edgePoints[X, Y - 1] == 2)
            {
                EdgeMap[X, Y - 1] = 1;
                VisitedMap[X, Y - 1] = 1;
                Travers(X, Y - 1);
                return;
            }

            //4

            if (_edgePoints[X - 1, Y - 1] == 2)
            {
                EdgeMap[X - 1, Y - 1] = 1;
                VisitedMap[X - 1, Y - 1] = 1;
                Travers(X - 1, Y - 1);
                return;
            }
            //5
            if (_edgePoints[X - 1, Y] == 2)
            {
                EdgeMap[X - 1, Y] = 1;
                VisitedMap[X - 1, Y] = 1;
                Travers(X - 1, Y);
                return;
            }
            //6
            if (_edgePoints[X - 1, Y + 1] == 2)
            {
                EdgeMap[X - 1, Y + 1] = 1;
                VisitedMap[X - 1, Y + 1] = 1;
                Travers(X - 1, Y + 1);
                return;
            }
            //7
            if (_edgePoints[X, Y + 1] == 2)
            {
                EdgeMap[X, Y + 1] = 1;
                VisitedMap[X, Y + 1] = 1;
                Travers(X, Y + 1);
                return;
            }
            //8

            if (_edgePoints[X + 1, Y + 1] == 2)
            {
                EdgeMap[X + 1, Y + 1] = 1;
                VisitedMap[X + 1, Y + 1] = 1;
                Travers(X + 1, Y + 1);
                return;
            }

            //VisitedMap[X, Y] = 1;
            return;
        }

        public Image GetGradientImage(float[,] gradient)
        {
            throw new NotImplementedException();
        }
    }
}
