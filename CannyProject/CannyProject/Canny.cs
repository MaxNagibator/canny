using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using CannyProject.KoeeficientClasses;

namespace CannyProject
{
    public class Canny
    {
        public Bitmap ObjInputImage;
        public int[,] GreyImage;

        //Gaussian Kernel Data
        //Canny Edge Detection Parameters
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
        public int[,] DeffirentBeetweenTwoImagesMatrix;
        private readonly MainKoeefficient _mainKoeefficient;
        private readonly ClearEdgeMapHomeAlonePointKoeefficient _clearEdgeMapHomeAlonePointKoeefficient;
        private readonly ClearGradientIfOtherNeighborhoodKoeefficient _clearGradientIfOtherNeighborhoodKoeefficient;
        private readonly ColorKoeefficient _colorKoeefficient;
        private readonly Bitmap _twoInputImage;

        public Canny(Bitmap inputImage, Bitmap twoInputImage,
                    MainKoeefficient mainKoeefficient,
                     ClearGradientIfOtherNeighborhoodKoeefficient clearGradientIfOtherNeighborhoodKoeefficient,
                     ClearEdgeMapHomeAlonePointKoeefficient clearEdgeMapHomeAlonePointKoeefficient,
                     ColorKoeefficient colorKoeefficient)
        {
            _twoInputImage = twoInputImage;
            _clearEdgeMapHomeAlonePointKoeefficient = clearEdgeMapHomeAlonePointKoeefficient;
            _clearGradientIfOtherNeighborhoodKoeefficient = clearGradientIfOtherNeighborhoodKoeefficient;
            _mainKoeefficient = mainKoeefficient;
            _colorKoeefficient = colorKoeefficient;
            ObjInputImage = inputImage;
            Execute();
        }

        private void Execute()
        {
            var edgeMap = MyTestColorExecute(ObjInputImage);
            EdgeMap = edgeMap;
        }

        private int[,] MyTestColorExecute(Bitmap objInputImage)
        {
            if (_colorKoeefficient.IsNeedApply && _twoInputImage == null)
            {
                var outEdgeMap = new int[objInputImage.Width, objInputImage.Height];
                var edgeMap1 = new int[objInputImage.Width, objInputImage.Height];
                var edgeMap2 = new int[objInputImage.Width, objInputImage.Height];
                var edgeMap3 = new int[objInputImage.Width, objInputImage.Height];
                if (_colorKoeefficient.IsNeedRed)
                {
                    var greyImage1 = ChangeColor(objInputImage, true, false, false);
                    var readImage = ReadImage(greyImage1, 1);
                    edgeMap1 = DetectCannyEdges(readImage);
                }
                if (_colorKoeefficient.IsNeedGreen)
                {
                    var greyImage2 = ChangeColor(objInputImage, false, true, false);
                    var readImage = ReadImage(greyImage2, 1);
                    edgeMap2 = DetectCannyEdges(readImage);
                }
                if (_colorKoeefficient.IsNeedBlue)
                {
                    var greyImage3 = ChangeColor(objInputImage, false, false, true);
                    var readImage = ReadImage(greyImage3,1);
                    edgeMap3 = DetectCannyEdges(readImage);
                }
                for (int i = 0; i < objInputImage.Width; i++)
                {
                    for (int j = 0; j < objInputImage.Height; j++)
                    {
                        var sum = edgeMap1[i, j] + edgeMap2[i, j] + edgeMap3[i, j];
                        outEdgeMap[i, j] = sum > 0 ? 255 : 0;
                    }
                }
                return outEdgeMap;
            }
            if (_twoInputImage != null)
            {
                DeffirentBeetweenTwoImagesMatrix = new int[objInputImage.Width,ObjInputImage.Height];
                for (int i = 0; i < objInputImage.Width; i++)
                {
                    for (int j = 0; j < objInputImage.Height; j++)
                    {
                        if (objInputImage.GetPixel(i, j) != _twoInputImage.GetPixel(i, j))
                        {
                            DeffirentBeetweenTwoImagesMatrix[i, j] = 255;
                        }
                    }
                }
            }
            var greyImage = ReadImage(objInputImage);
            return DetectCannyEdges(greyImage);
        }

        private Bitmap ChangeColor(Bitmap image, bool isNeedRed, bool isNeedGreen, bool isNeedBlue)
        {
            var outputImage = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < outputImage.Width; i++)
            {
                for (int j = 0; j < outputImage.Height; j++)
                {
                    //get the pixel from the scrBitmap image

                    var actulaColor = image.GetPixel(i, j);
                    int r = isNeedRed ? actulaColor.R : 0;
                    int g = isNeedGreen ? actulaColor.G : 0;
                    int b = isNeedBlue ? actulaColor.B : 0;
                    outputImage.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }
            return outputImage;
        }

        public Bitmap GetDisplayedImage(int[,] dispImage)
        {
            if(dispImage == null)
            {
                return null;
            }
            int width = dispImage.GetLength(0);
            int height = dispImage.GetLength(1);
            return GetDisplayedImage(dispImage, width, height);
        }

        private Bitmap GetDisplayedImage(int[,] dispImage, int width, int height)
        {
            var image = new Bitmap(width, height);
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, width, height),
                                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                var imagePointer1 = (byte*) bitmapData1.Scan0;
                for (var i = 0; i < bitmapData1.Height; i++)
                {
                    for (var j = 0; j < bitmapData1.Width; j++)
                    {
                        imagePointer1[0] = (byte) dispImage[j, i];
                        imagePointer1[1] = (byte) dispImage[j, i];
                        imagePointer1[2] = (byte) dispImage[j, i];
                        imagePointer1[3] = 255;
                        imagePointer1 += 4;
                    }
                    imagePointer1 += (bitmapData1.Stride - (bitmapData1.Width*4));
                }
            }
            image.UnlockBits(bitmapData1);
            return image;
        }

        public Bitmap GetDisplayedImage(float[,] dispImage)
        {
            if (dispImage == null)
            {
                return null;
            }
            int width = dispImage.GetLength(0);
            int height = dispImage.GetLength(1);
            return GetDisplayedImage(dispImage, width, height);
        }

        private Bitmap GetDisplayedImage(float[,] dispImage, int width, int height)
        {
            var image = new Bitmap(width, height);
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, width, height),
                                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                var imagePointer1 = (byte*) bitmapData1.Scan0;
                for (var i = 0; i < bitmapData1.Height; i++)
                {
                    for (var j = 0; j < bitmapData1.Width; j++)
                    {
                        imagePointer1[0] = (byte) dispImage[j, i];
                        imagePointer1[1] = (byte) dispImage[j, i];
                        imagePointer1[2] = (byte) dispImage[j, i];
                        imagePointer1[3] = 255;
                        imagePointer1 += 4;
                    }
                    imagePointer1 += (bitmapData1.Stride - (bitmapData1.Width*4));
                }
            }
            image.UnlockBits(bitmapData1);
            return image;
        }

        private int[,] ReadImage(Bitmap objInputImage, int colorCount = 3)
        {
            var greyImage = new int[objInputImage.Width, objInputImage.Height];
            BitmapData bitmapData1 = objInputImage.LockBits(new Rectangle(0, 0, objInputImage.Width, objInputImage.Height),
                                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                var imagePointer1 = (byte*)bitmapData1.Scan0;
                for (var i = 0; i < bitmapData1.Height; i++)
                {
                    for (var j = 0; j < bitmapData1.Width; j++)
                    {
                        greyImage[j, i] = (int)((imagePointer1[0] + imagePointer1[1] + imagePointer1[2]) / colorCount);
                        imagePointer1 += 4;
                    }
                    imagePointer1 += bitmapData1.Stride - (bitmapData1.Width * 4);
                }
            }
            objInputImage.UnlockBits(bitmapData1);
            return greyImage;
        }

        private int[,] DetectCannyEdges(int[,] greyImage)
        {
            PostHysteresis = new int[ObjInputImage.Width,ObjInputImage.Height];
            GaussianFilterImage = GetGaussianFilterImage(greyImage);
            float[,] derivativeX = GetDifferentiateX(GaussianFilterImage);
            float[,] derivativeY = GetDifferentiateY(GaussianFilterImage);
            Gradient = ComputeGradientByDerivativesXy(derivativeX, derivativeY);
            if (_twoInputImage != null)
            {
                Gradient = MyTestChangeGradientTwoImage(Gradient);
            }
            SetNonMaxFromGradient(Gradient);
            int limit = _mainKoeefficient.KernelSize / 2;
            SetNonMaxZero(limit, derivativeX, derivativeY);

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
            } // nahuya? o_O

            SetGnhGnlEdgePoints(limit);
            var edgeMap = HysterisisThresholding(_edgePoints);
            edgeMap = SetEdgeMap255(edgeMap);
            edgeMap = ClearEdgeMapHomeAlonePoint(edgeMap);
            return edgeMap;
        }

        private float[,] MyTestChangeGradientTwoImage(float[,] gradient)
        {
            for (int i = 0; i < DeffirentBeetweenTwoImagesMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < DeffirentBeetweenTwoImagesMatrix.GetLength(1); j++)
                {
                    if (DeffirentBeetweenTwoImagesMatrix[i,j] != 0)
                    {
                        gradient[i, j] = gradient[i, j]*3;
                    }
                }
            }
            return gradient;
        }

        private int[,] GetGaussianFilterImage(int[,] greyImage)
        {
            var gaussianKernel = GetGaussianKernel(_mainKoeefficient.KernelSize, _mainKoeefficient.Sigma);
            int limit = _mainKoeefficient.KernelSize/2;
            int[,] output = greyImage;

            for (var i = limit; i <= ((ObjInputImage.Width - 1) - limit); i++)
            {
                for (var j = limit; j <= ((ObjInputImage.Height - 1) - limit); j++)
                {
                    float sum = 0;
                    for (var k = -limit; k < limit; k++)
                    {
                        for (var l = -limit; l < limit; l++)
                        {
                            sum = sum + (greyImage[i + k, j + l] * gaussianKernel[limit + k, limit + l]);
                        }
                    }
                    output[i, j] = (int) (Math.Round(sum));
                }
            }
            return output;
        }

        private float[,] GetGaussianKernel(int kernelSize, float sigma)
        {
            var kernel = new float[kernelSize, kernelSize];
            float d1 = 2*(float) Math.PI*sigma*sigma;
            float d2 = 2*sigma*sigma;
            float min = 1000;
            var shift = kernelSize/2;
            for (var i = 0; i < kernelSize; i++)
            {
                for (var j = 0; j < kernelSize; j++)
                {
                    var x = i - shift;
                    var y = j - shift;
                    kernel[i, j] = ((1/d1)*(float) Math.Exp(-(x*x + y*y)/d2));
                    if (kernel[i, j] < min)
                    {
                        min = kernel[i, j];
                    }
                }
            }
            //var text = "";
            //for (var i = 0; i < kernelSize; i++)
            //{
            //    for (var j = 0; j < kernelSize; j++)
            //    {
            //        text += String.Format("{0,5} ", Math.Round(kernel[i, j], 3));
            //    }
            //    text += Environment.NewLine;
            //} // раскоменти, если хочешь посмотреть ядро гаусса ;)
            return kernel;
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
            var width = ObjInputImage.Width;
            var height = ObjInputImage.Height;
            var output = new float[width, height];

            for (var i = filterWidth/2; i <= (width - filterWidth/2) - 1; i++)
            {
                for (var j = filterHeight/2; j <= (height - filterHeight/2) - 1; j++)
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

        private float[,] ComputeGradientByDerivativesXy(float[,] derivativeX, float[,] derivativeY)
        {
            var gradient = new float[ObjInputImage.Width,ObjInputImage.Height];
            for (var i = 0; i <= (ObjInputImage.Width - 1); i++)
            {
                for (var j = 0; j <= (ObjInputImage.Height - 1); j++)
                {
                    gradient[i, j] =
                        (float) Math.Sqrt((derivativeX[i, j]*derivativeX[i, j]) + (derivativeY[i, j]*derivativeY[i, j]));
                }
            }
            gradient = MyTestChangeGradient(gradient);
            return gradient;
        }

        private float[,] MyTestChangeGradient(float[,] gradient)
        {
            if (!_clearGradientIfOtherNeighborhoodKoeefficient.IsNeedApply)
            {
                return gradient;
            }
            SpecialMatrix = new float[ObjInputImage.Width,ObjInputImage.Height];
            SpecialMatrix2 = new float[ObjInputImage.Width,ObjInputImage.Height];
            var specWidth = _clearGradientIfOtherNeighborhoodKoeefficient.Size;
            var specHeight = _clearGradientIfOtherNeighborhoodKoeefficient.Size;
            var specStep = _clearGradientIfOtherNeighborhoodKoeefficient.Shift;
            var koefficient = _clearGradientIfOtherNeighborhoodKoeefficient.Koefficient1;

            for (var i = 0; i <= (ObjInputImage.Width - 1) - specWidth; i += specStep)
            {
                for (var j = 0; j <= (ObjInputImage.Height - 1) - specHeight; j += specStep)
                {
                    float total = 0;
                    for (var si = i; si <= i + specWidth; si++)
                    {
                        for (var sj = j; sj <= j + specHeight; sj++)
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
                        SpecialMatrix[i, j] = SpecialMatrix[i, j]/SpecialMatrix2[i, j];
                    }
                }
            }

            for (var i = 0; i <= (ObjInputImage.Width - 1); i++)
            {
                for (var j = 0; j <= (ObjInputImage.Height - 1); j++)
                {
                    if (gradient[i, j] < (SpecialMatrix[i, j]*koefficient))
                    {
                        gradient[i, j] = 0;
                    }
                }
            }
            return gradient;
        }

        private void SetNonMaxFromGradient(float[,] gradient)
        {
            // NonMax = Gradient; ?? ^_^
            NonMax = new float[ObjInputImage.Width, ObjInputImage.Height];
            for (var i = 0; i <= (ObjInputImage.Width - 1); i++)
            {
                for (var j = 0; j <= (ObjInputImage.Height - 1); j++)
                {
                    NonMax[i, j] = gradient[i, j];
                }
            }
        }

        private void SetNonMaxZero(int limit, float[,] derivativeX, float[,] derivativeY)
        {
            for (var i = limit; i <= (ObjInputImage.Width - limit) - 1; i++)
            {
                for (var j = limit; j <= (ObjInputImage.Height - limit) - 1; j++)
                {
                    var t = (float) (Math.Atan(derivativeY[i, j]/derivativeX[i, j])*180/Math.PI);
                    //Horizontal Edge
                    if (((-22.5 < t) && (t <= 22.5)) || ((157.5 < t) && (t <= -157.5)))
                    {
                        if ((Gradient[i, j] < Gradient[i, j + 1]) || (Gradient[i, j] < Gradient[i, j - 1]))
                            NonMax[i, j] = 0;
                    }
                    //Vertical Edge
                    if (((-112.5 < t) && (t <= -67.5)) || ((67.5 < t) && (t <= 112.5)))
                    {
                        if ((Gradient[i, j] < Gradient[i + 1, j]) || (Gradient[i, j] < Gradient[i - 1, j]))
                            NonMax[i, j] = 0;
                    }
                    //+45 Degree Edge
                    if (((-67.5 < t) && (t <= -22.5)) || ((112.5 < t) && (t <= 157.5)))
                    {
                        if ((Gradient[i, j] < Gradient[i + 1, j - 1]) || (Gradient[i, j] < Gradient[i - 1, j + 1]))
                            NonMax[i, j] = 0;
                    }
                    //-45 Degree Edge
                    if (((-157.5 < t) && (t <= -112.5)) || ((67.5 < t) && (t <= 22.5)))
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
                    PostHysteresis[r, c] = (int) NonMax[r, c];
                }
            }
        }
        
        private void SetGnhGnlEdgePoints(int limit)
        {
            var max = _mainKoeefficient.MaxHysteresisThresh;
            var min = _mainKoeefficient.MinHysteresisThresh;
            GNH = new float[ObjInputImage.Width,ObjInputImage.Height];
            GNL = new float[ObjInputImage.Width,ObjInputImage.Height];
            _edgePoints = new int[ObjInputImage.Width,ObjInputImage.Height];

            for (var i = limit; i <= (ObjInputImage.Width - limit) - 1; i++)
            {
                for (var j = limit; j <= (ObjInputImage.Height - limit) - 1; j++)
                {
                    if (PostHysteresis[i, j] >= max)
                    {
                        _edgePoints[i, j] = 1;
                        GNH[i, j] = 255;
                    }
                    if ((PostHysteresis[i, j] < max) && (PostHysteresis[i, j] >= min))
                    {
                        _edgePoints[i, j] = 2;
                        GNL[i, j] = 255;
                    }
                }
            }
        }

        private int[,] HysterisisThresholding(int[,] edges)
        {
            int limit = _mainKoeefficient.KernelSize/2;
            var edgeMap = new int[ObjInputImage.Width, ObjInputImage.Height];
            VisitedMap = new int[ObjInputImage.Width, ObjInputImage.Height];
            for (var i = limit; i <= (ObjInputImage.Width - 1) - limit; i++)
            {
                for (var j = limit; j <= (ObjInputImage.Height - 1) - limit; j++)
                {
                    if (edges[i, j] == 1)
                    {
                        edgeMap[i, j] = 1;
                        Travers(edgeMap,i, j);
                        VisitedMap[i, j] = 1;
                    }
                }
            }
            return edgeMap;
        }

        private int[,] SetEdgeMap255(int[,] edgeMap)
        {
            for (var i = 0; i <= (ObjInputImage.Width - 1); i++)
            {
                for (var j = 0; j <= (ObjInputImage.Height - 1); j++)
                {
                    edgeMap[i, j] = edgeMap[i, j] * 255;
                }
            }
            return edgeMap;
        }


        private void Travers(int[,] edgeMap, int X, int Y)
        {

            if (VisitedMap[X, Y] == 1)
            {
                return;
            }

            //1
            if (_edgePoints[X + 1, Y] == 2)
            {
                edgeMap[X + 1, Y] = 1;
                VisitedMap[X + 1, Y] = 1;
                Travers(edgeMap, X + 1, Y);
                return;
            }
            //2
            if (_edgePoints[X + 1, Y - 1] == 2)
            {
                edgeMap[X + 1, Y - 1] = 1;
                VisitedMap[X + 1, Y - 1] = 1;
                Travers(edgeMap, X + 1, Y - 1);
                return;
            }

            //3

            if (_edgePoints[X, Y - 1] == 2)
            {
                edgeMap[X, Y - 1] = 1;
                VisitedMap[X, Y - 1] = 1;
                Travers(edgeMap, X, Y - 1);
                return;
            }

            //4

            if (_edgePoints[X - 1, Y - 1] == 2)
            {
                edgeMap[X - 1, Y - 1] = 1;
                VisitedMap[X - 1, Y - 1] = 1;
                Travers(edgeMap, X - 1, Y - 1);
                return;
            }
            //5
            if (_edgePoints[X - 1, Y] == 2)
            {
                edgeMap[X - 1, Y] = 1;
                VisitedMap[X - 1, Y] = 1;
                Travers(edgeMap, X - 1, Y);
                return;
            }
            //6
            if (_edgePoints[X - 1, Y + 1] == 2)
            {
                edgeMap[X - 1, Y + 1] = 1;
                VisitedMap[X - 1, Y + 1] = 1;
                Travers(edgeMap, X - 1, Y + 1);
                return;
            }
            //7
            if (_edgePoints[X, Y + 1] == 2)
            {
                edgeMap[X, Y + 1] = 1;
                VisitedMap[X, Y + 1] = 1;
                Travers(edgeMap, X, Y + 1);
                return;
            }
            //8

            if (_edgePoints[X + 1, Y + 1] == 2)
            {
                edgeMap[X + 1, Y + 1] = 1;
                VisitedMap[X + 1, Y + 1] = 1;
                Travers(edgeMap, X + 1, Y + 1);
                return;
            }

            //VisitedMap[X, Y] = 1;
            //return edgeMap;
        }

        private int[,] ClearEdgeMapHomeAlonePoint(int[,] edgeMap)
        {
            if (!_clearEdgeMapHomeAlonePointKoeefficient.IsNeedApply)
            {
                return edgeMap;
            }

            var temp = new int[ObjInputImage.Width,ObjInputImage.Height];
            var width = _clearEdgeMapHomeAlonePointKoeefficient.Width;
            var height = _clearEdgeMapHomeAlonePointKoeefficient.Height;
            var step = _clearEdgeMapHomeAlonePointKoeefficient.Step;
            var count = _clearEdgeMapHomeAlonePointKoeefficient.Count;

            for (var i = 0 + width; i <= (edgeMap.GetLength(0) - 1) - width; i += step)
            {
                for (var j = 0 + height; j <= (edgeMap.GetLength(1) - 1) - height; j += step)
                {
                    if (edgeMap[i, j] == 255)
                    {
                        float total = 0;
                        for (var si = i - width; si <= i + width; si++)
                        {
                            for (var sj = j - width; sj <= j + height; sj++)
                            {
                                total += edgeMap[si, sj];
                            }
                        }
                        if (total < 255*count)
                        {
                            temp[i, j] = 1;
                        }
                    }
                }
            }

            for (var i = 0; i <= (temp.GetLength(0) - 1); i++)
            {
                for (var j = 0; j <= (temp.GetLength(1) - 1); j++)
                {
                    if (temp[i, j] == 1)
                    {
                        edgeMap[i, j] = 0;
                    }
                }
            }
            return edgeMap;
        }
    }
}