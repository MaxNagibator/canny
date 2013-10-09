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
        public float[,] DerivativeX;
        public float[,] DerivativeY;
        public int[,] FilteredImage;
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
            int i, j;
            GreyImage = new int[ObjInputImage.Width, ObjInputImage.Height];  //[Row,Column]
            Bitmap image = ObjInputImage;
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                     ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                byte* imagePointer1 = (byte*)bitmapData1.Scan0;

                for (i = 0; i < bitmapData1.Height; i++)
                {
                    for (j = 0; j < bitmapData1.Width; j++)
                    {
                        GreyImage[j, i] = (int)((imagePointer1[0] + imagePointer1[1] + imagePointer1[2]) / 3.0);
                        //4 bytes per pixel
                        imagePointer1 += 4;
                    }//end for j
                    //4 bytes per pixel
                    imagePointer1 += bitmapData1.Stride - (bitmapData1.Width * 4);
                }//end for i
            }//end unsafe
            image.UnlockBits(bitmapData1);
            return;
        }

        private int[,] GenerateGaussianKernel(int N, float S, out int Weight)
        {

            float Sigma = S;
            float pi;
            pi = (float)Math.PI;
            int i, j;
            int SizeofKernel = N;

            float[,] Kernel = new float[N, N];
            var gaussianKernel = new int[N, N];
            float[,] OP = new float[N, N];
            float D1, D2;


            D1 = 1 / (2 * pi * Sigma * Sigma);
            D2 = 2 * Sigma * Sigma;

            float min = 1000;

            for (i = -SizeofKernel / 2; i <= SizeofKernel / 2; i++)
            {
                for (j = -SizeofKernel / 2; j <= SizeofKernel / 2; j++)
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

                for (i = -SizeofKernel / 2; i <= SizeofKernel / 2; i++)
                {
                    for (j = -SizeofKernel / 2; j <= SizeofKernel / 2; j++)
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
                for (i = -SizeofKernel / 2; i <= SizeofKernel / 2; i++)
                {
                    for (j = -SizeofKernel / 2; j <= SizeofKernel / 2; j++)
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

        private int[,] GaussianFilter(int[,] Data)
        {
            var gaussianKernel = GenerateGaussianKernel(KernelSize, Sigma, out KernelWeight);

            int[,] Output = new int[ObjInputImage.Width, ObjInputImage.Height];
            int i, j, k, l;
            int Limit = KernelSize / 2;

            float Sum = 0;


            Output = Data; // Removes Unwanted Data Omission due to kernel bias while convolution


            for (i = Limit; i <= ((ObjInputImage.Width - 1) - Limit); i++)
            {
                for (j = Limit; j <= ((ObjInputImage.Height - 1) - Limit); j++)
                {
                    Sum = 0;
                    for (k = -Limit; k <= Limit; k++)
                    {

                        for (l = -Limit; l <= Limit; l++)
                        {
                            Sum = Sum + ((float)Data[i + k, j + l] * gaussianKernel[Limit + k, Limit + l]);

                        }
                    }
                    Output[i, j] = (int)(Math.Round(Sum / KernelWeight));
                }

            }


            return Output;
        }

        private float[,] Differentiate(int[,] Data, int[,] Filter)
        {
            int i, j, k, l, Fh, Fw;

            Fw = Filter.GetLength(0);
            Fh = Filter.GetLength(1);
            float sum = 0;
            float[,] Output = new float[ObjInputImage.Width, ObjInputImage.Height];

            for (i = Fw / 2; i <= (ObjInputImage.Width - Fw / 2) - 1; i++)
            {
                for (j = Fh / 2; j <= (ObjInputImage.Height - Fh / 2) - 1; j++)
                {
                    sum = 0;
                    for (k = -Fw / 2; k <= Fw / 2; k++)
                    {
                        for (l = -Fh / 2; l <= Fh / 2; l++)
                        {
                            sum = sum + Data[i + k, j + l] * Filter[Fw / 2 + k, Fh / 2 + l];


                        }
                    }
                    Output[i, j] = sum;

                }

            }
            return Output;

        }

        private void DetectCannyEdges()
        {
            Gradient = new float[ObjInputImage.Width, ObjInputImage.Height];
            NonMax = new float[ObjInputImage.Width, ObjInputImage.Height];
            PostHysteresis = new int[ObjInputImage.Width, ObjInputImage.Height];

            DerivativeX = new float[ObjInputImage.Width, ObjInputImage.Height];
            DerivativeY = new float[ObjInputImage.Width, ObjInputImage.Height];

            //Gaussian Filter Input Image 

            FilteredImage = GaussianFilter(GreyImage);
            //Sobel Masks
            int[,] Dx = {{1,0,-1},
                         {1,0,-1},
                         {1,0,-1}};

            int[,] Dy = {{1,1,1},
                         {0,0,0},
                         {-1,-1,-1}};


            DerivativeX = Differentiate(FilteredImage, Dx);
            DerivativeY = Differentiate(FilteredImage, Dy);

            int i, j;

            //Compute the gradient magnitude based on derivatives in x and y:
            for (i = 0; i <= (ObjInputImage.Width - 1); i++)
            {
                for (j = 0; j <= (ObjInputImage.Height - 1); j++)
                {
                    Gradient[i, j] = (float)Math.Sqrt((DerivativeX[i, j] * DerivativeX[i, j]) + (DerivativeY[i, j] * DerivativeY[i, j]));

                }

            }
            // Perform Non maximum suppression:
            // NonMax = Gradient;

            for (i = 0; i <= (ObjInputImage.Width - 1); i++)
            {
                for (j = 0; j <= (ObjInputImage.Height - 1); j++)
                {
                    NonMax[i, j] = Gradient[i, j];
                }
            }

            int Limit = KernelSize / 2;
            int r, c;
            float Tangent;


            for (i = Limit; i <= (ObjInputImage.Width - Limit) - 1; i++)
            {
                for (j = Limit; j <= (ObjInputImage.Height - Limit) - 1; j++)
                {

                    if (DerivativeX[i, j] == 0)
                        Tangent = 90F;
                    else
                        Tangent = (float)(Math.Atan(DerivativeY[i, j] / DerivativeX[i, j]) * 180 / Math.PI); //rad to degree



                    //Horizontal Edge
                    if (((-22.5 < Tangent) && (Tangent <= 22.5)) || ((157.5 < Tangent) && (Tangent <= -157.5)))
                    {
                        if ((Gradient[i, j] < Gradient[i, j + 1]) || (Gradient[i, j] < Gradient[i, j - 1]))
                            NonMax[i, j] = 0;
                    }


                    //Vertical Edge
                    if (((-112.5 < Tangent) && (Tangent <= -67.5)) || ((67.5 < Tangent) && (Tangent <= 112.5)))
                    {
                        if ((Gradient[i, j] < Gradient[i + 1, j]) || (Gradient[i, j] < Gradient[i - 1, j]))
                            NonMax[i, j] = 0;
                    }

                    //+45 Degree Edge
                    if (((-67.5 < Tangent) && (Tangent <= -22.5)) || ((112.5 < Tangent) && (Tangent <= 157.5)))
                    {
                        if ((Gradient[i, j] < Gradient[i + 1, j - 1]) || (Gradient[i, j] < Gradient[i - 1, j + 1]))
                            NonMax[i, j] = 0;
                    }

                    //-45 Degree Edge
                    if (((-157.5 < Tangent) && (Tangent <= -112.5)) || ((67.5 < Tangent) && (Tangent <= 22.5)))
                    {
                        if ((Gradient[i, j] < Gradient[i + 1, j + 1]) || (Gradient[i, j] < Gradient[i - 1, j - 1]))
                            NonMax[i, j] = 0;
                    }

                }
            }


            //PostHysteresis = NonMax;
            for (r = Limit; r <= (ObjInputImage.Width - Limit) - 1; r++)
            {
                for (c = Limit; c <= (ObjInputImage.Height - Limit) - 1; c++)
                {

                    PostHysteresis[r, c] = (int)NonMax[r, c];
                }

            }

            //Find Max and Min in Post Hysterisis
            float min, max;
            min = 100;
            max = 0;
            for (r = Limit; r <= (ObjInputImage.Width - Limit) - 1; r++)
                for (c = Limit; c <= (ObjInputImage.Height - Limit) - 1; c++)
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

            GNH = new float[ObjInputImage.Width, ObjInputImage.Height];
            GNL = new float[ObjInputImage.Width, ObjInputImage.Height]; ;
            EdgePoints = new int[ObjInputImage.Width, ObjInputImage.Height];

            for (r = Limit; r <= (ObjInputImage.Width - Limit) - 1; r++)
            {
                for (c = Limit; c <= (ObjInputImage.Height - Limit) - 1; c++)
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

            for (i = 0; i <= (ObjInputImage.Width - 1); i++)
            {
                for (j = 0; j <= (ObjInputImage.Height - 1); j++)
                {
                    EdgeMap[i, j] = EdgeMap[i, j]*255;
                }
            }
        }

        private void HysterisisThresholding(int[,] Edges)
        {

            int i, j;
            int Limit = KernelSize / 2;


            for (i = Limit; i <= (ObjInputImage.Width - 1) - Limit; i++)
            {
                for (j = Limit; j <= (ObjInputImage.Height - 1) - Limit; j++)
                {
                    if (Edges[i, j] == 1)
                    {
                        EdgeMap[i, j] = 1;
                    }
                }
            }

            for (i = Limit; i <= (ObjInputImage.Width - 1) - Limit; i++)
            {
                for (j = Limit; j <= (ObjInputImage.Height - 1) - Limit; j++)
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
