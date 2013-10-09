using System;
using System.Drawing.Imaging;
using System.Drawing;

namespace CannyProject
{
    public class Canny
    {
        public Bitmap ObjInputImage;
        public int[,] GreyImage;

        //Gaussian Kernel Data
        int KernelWeight;
        int KernelSize = 5;
        float Sigma = 1;   // for N=2 Sigma =0.85  N=5 Sigma =1, N=9 Sigma = 2    2*Sigma = (int)N/2
        //Canny Edge Detection Parameters
        float MaxHysteresisThresh, MinHysteresisThresh;
        public int[,] GaussianFilterImage;
        public float[,] Gradient;
        public float[,] NonMax;
        public int[,] PostHysteresis;
        int[,] EdgePoints;
        public float[,] GNH;
        public float[,] GNL;
        public int[,] EdgeMap;
        public int[,] VisitedMap;

        public Canny(Bitmap inputImage)
        {
            const float maxHysteresisThresh = 20F;
            const float minHysteresisThresh = 10F;
            SetGaussianAndCannyParameters(inputImage, maxHysteresisThresh, minHysteresisThresh);
        }

        public Canny(Bitmap inputImage, float maxHysteresisThresh, float minHysteresisThresh)
        {
            SetGaussianAndCannyParameters(inputImage, maxHysteresisThresh, minHysteresisThresh);
        }

        public Canny(Bitmap inputImage, float maxHysteresisThresh, float minHysteresisThresh, int gaussianMaskSize, float sigmaforGaussianKernel)
        {
            KernelSize = gaussianMaskSize;
            Sigma = sigmaforGaussianKernel;
            SetGaussianAndCannyParameters(inputImage, maxHysteresisThresh, minHysteresisThresh);
        }

        private void SetGaussianAndCannyParameters(Bitmap inputImage, float maxHysteresisThresh, float minHysteresisThresh)
        {
            MaxHysteresisThresh = maxHysteresisThresh;
            MinHysteresisThresh = minHysteresisThresh;
            ObjInputImage = inputImage;
            EdgeMap = new int[ObjInputImage.Width, ObjInputImage.Height];
            VisitedMap = new int[ObjInputImage.Width, ObjInputImage.Height];
            ReadImage();
            DetectCannyEdges();
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

            GaussianFilterImage = GetGaussianFilterImage(GreyImage);
            float[,] derivativeX = GetDifferentiateX(GaussianFilterImage);
            float[,] derivativeY = GetDifferentiateY(GaussianFilterImage);
            Gradient = ComputeGradientByDerivativesXY(derivativeX, derivativeY);
            NonMax = PerformNonMaximumSuppression(Gradient);


            int limit = KernelSize / 2;


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


            //PostHysteresis = NonMax;
            for (var r = limit; r <= (ObjInputImage.Width - limit) - 1; r++)
            {
                for (var c = limit; c <= (ObjInputImage.Height - limit) - 1; c++)
                {

                    PostHysteresis[r, c] = (int)NonMax[r, c];
                }

            }

            //Find Max and Min in Post Hysterisis
            float min = 100;
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

            GNH = new float[ObjInputImage.Width, ObjInputImage.Height];
            GNL = new float[ObjInputImage.Width, ObjInputImage.Height];
            EdgePoints = new int[ObjInputImage.Width, ObjInputImage.Height];

            for (var r = limit; r <= (ObjInputImage.Width - limit) - 1; r++)
            {
                for (var c = limit; c <= (ObjInputImage.Height - limit) - 1; c++)
                {
                    if (PostHysteresis[r, c] >= MaxHysteresisThresh)
                    {

                        EdgePoints[r, c] = 1;
                        GNH[r, c] = 255;
                    }
                    if ((PostHysteresis[r, c] < MaxHysteresisThresh) && (PostHysteresis[r, c] >= MinHysteresisThresh))
                    {

                        EdgePoints[r, c] = 2;
                        GNL[r, c] = 255;

                    }

                }

            }

            HysterisisThresholding(EdgePoints);

            for (var i = 0; i <= (ObjInputImage.Width - 1); i++)
            {
                for (var j = 0; j <= (ObjInputImage.Height - 1); j++)
                {
                    EdgeMap[i, j] = EdgeMap[i, j]*255;
                }
            }
        }

        private int[,] GetGaussianFilterImage(int[,] data)
        {
            var gaussianKernel = GenerateGaussianKernel(KernelSize, Sigma, out KernelWeight);
            int limit = KernelSize / 2;
            int[,] output = data;

            for (var i = limit; i <= ((ObjInputImage.Width - 1) - limit); i++)
            {
                for (var j = limit; j <= ((ObjInputImage.Height - 1) - limit); j++)
                {
                    float sum = 0;
                    for (var k = -limit; k < limit; k++)
                    {
                        for (var l = -limit; l < limit; l++)
                        {
                            sum = sum + ((float)data[i + k, j + l] * gaussianKernel[limit + k, limit + l]);
                        }
                    }
                    output[i, j] = (int)(Math.Round(sum / KernelWeight));
                }
            }
            return output;
        }

        private int[,] GenerateGaussianKernel(int N, float S, out int Weight)
        {

            float Sigma = S;
            float pi;
            pi = (float)Math.PI;
            int SizeofKernel = N;

            float[,] Kernel = new float[N, N];
            var gaussianKernel = new int[N, N];
            float[,] OP = new float[N, N];
            float D1, D2;


            D1 = 1 / (2 * pi * Sigma * Sigma);
            D2 = 2 * Sigma * Sigma;

            float min = 1000;

            for (var i = -SizeofKernel / 2; i < SizeofKernel / 2; i++)
            {
                for (var j = -SizeofKernel / 2; j < SizeofKernel / 2; j++)
                {
                    Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = ((1 / D1) * (float)Math.Exp(-(i * i + j * j) / D2));
                    if (Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] < min)
                        min = Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j];

                }
            }
            int mult = (int)(1 / min);
            int sum = 0;
            if ((min > 0) && (min < 1))
            {

                for (var i = -SizeofKernel / 2; i < SizeofKernel / 2; i++)
                {
                    for (var j = -SizeofKernel / 2; j < SizeofKernel / 2; j++)
                    {
                        Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = (float)Math.Round(Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] * mult, 0);
                        gaussianKernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = (int)Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j];
                        sum = sum + gaussianKernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j];
                    }

                }

            }
            else
            {
                sum = 0;
                for (var i = -SizeofKernel / 2; i < SizeofKernel / 2; i++)
                {
                    for (var j = -SizeofKernel / 2; j < SizeofKernel / 2; j++)
                    {
                        Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = (float)Math.Round(Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j], 0);
                        gaussianKernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j] = (int)Kernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j];
                        sum = sum + gaussianKernel[SizeofKernel / 2 + i, SizeofKernel / 2 + j];
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
                    {1, 0, -1},
                    {1, 0, -1}
                };
            return Differentiate(gaussianFilterImage, sobelMasksDx);
        }

        private float[,] GetDifferentiateY(int[,] gaussianFilterImage)
        {
            int[,] sobelMasksDy =
                {
                    {1, 1, 1},
                    {0, 0, 0},
                    {-1, -1, -1}
                };
            return Differentiate(gaussianFilterImage, sobelMasksDy);
        }

        private float[,] Differentiate(int[,] data, int[,] filter)
        {
            var filterWidth = filter.GetLength(0);
            var filterHeight = filter.GetLength(1);
            var output = new float[ObjInputImage.Width, ObjInputImage.Height];

            for (var i = filterWidth / 2; i <= (ObjInputImage.Width - filterWidth / 2) - 1; i++)
            {
                for (var j = filterHeight / 2; j <= (ObjInputImage.Height - filterHeight / 2) - 1; j++)
                {
                    float sum = 0;
                    for (var k = -filterWidth / 2; k <= filterWidth / 2; k++)
                    {
                        for (var l = -filterHeight / 2; l <= filterHeight / 2; l++)
                        {
                            sum = sum + data[i + k, j + l] * filter[filterWidth / 2 + k, filterHeight / 2 + l];
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

        private void HysterisisThresholding(int[,] Edges)
        {
            int Limit = KernelSize / 2;


            for (var i = Limit; i <= (ObjInputImage.Width - 1) - Limit; i++)
            {
                for (var j = Limit; j <= (ObjInputImage.Height - 1) - Limit; j++)
                {
                    if (Edges[i, j] == 1)
                    {
                        EdgeMap[i, j] = 1;
                    }
                }
            }

            for (var i = Limit; i <= (ObjInputImage.Width - 1) - Limit; i++)
            {
                for (var j = Limit; j <= (ObjInputImage.Height - 1) - Limit; j++)
                {
                    if (Edges[i, j] == 1)
                    {
                        EdgeMap[i, j] = 1;
                        Travers(i, j);
                        VisitedMap[i, j] = 1;
                    }
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
            if (EdgePoints[X + 1, Y] == 2)
            {
                EdgeMap[X + 1, Y] = 1;
                VisitedMap[X + 1, Y] = 1;
                Travers(X + 1, Y);
                return;
            }
            //2
            if (EdgePoints[X + 1, Y - 1] == 2)
            {
                EdgeMap[X + 1, Y - 1] = 1;
                VisitedMap[X + 1, Y - 1] = 1;
                Travers(X + 1, Y - 1);
                return;
            }

            //3

            if (EdgePoints[X, Y - 1] == 2)
            {
                EdgeMap[X, Y - 1] = 1;
                VisitedMap[X, Y - 1] = 1;
                Travers(X, Y - 1);
                return;
            }

            //4

            if (EdgePoints[X - 1, Y - 1] == 2)
            {
                EdgeMap[X - 1, Y - 1] = 1;
                VisitedMap[X - 1, Y - 1] = 1;
                Travers(X - 1, Y - 1);
                return;
            }
            //5
            if (EdgePoints[X - 1, Y] == 2)
            {
                EdgeMap[X - 1, Y] = 1;
                VisitedMap[X - 1, Y] = 1;
                Travers(X - 1, Y);
                return;
            }
            //6
            if (EdgePoints[X - 1, Y + 1] == 2)
            {
                EdgeMap[X - 1, Y + 1] = 1;
                VisitedMap[X - 1, Y + 1] = 1;
                Travers(X - 1, Y + 1);
                return;
            }
            //7
            if (EdgePoints[X, Y + 1] == 2)
            {
                EdgeMap[X, Y + 1] = 1;
                VisitedMap[X, Y + 1] = 1;
                Travers(X, Y + 1);
                return;
            }
            //8

            if (EdgePoints[X + 1, Y + 1] == 2)
            {
                EdgeMap[X + 1, Y + 1] = 1;
                VisitedMap[X + 1, Y + 1] = 1;
                Travers(X + 1, Y + 1);
                return;
            }

            //VisitedMap[X, Y] = 1;
            return;
        }
    }
}
