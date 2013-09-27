using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace CannyProject
{
    public class Canny
    {
        private const int KERNEL_SIZE = 9;
        private const float SIGMA = 1;
        // for N=2 Sigma =0.85  N=5 Sigma =1, N=9 Sigma = 2    2*Sigma = (int)N/2

        private static int[,] ReadImage(Bitmap input)
        {
            var greyImage = new int[input.Width,input.Height]; //[Row,Column]
            Bitmap image = input;
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                var imagePointer1 = (byte*) bitmapData1.Scan0;

                for (int i = 0; i < bitmapData1.Height; i++)
                {
                    for (int j = 0; j < bitmapData1.Width; j++)
                    {
                        greyImage[j, i] = (int) ((imagePointer1[0] + imagePointer1[1] + imagePointer1[2])/3.0);
                        //4 bytes per pixel
                        imagePointer1 += 4;
                    }
                    imagePointer1 += bitmapData1.Stride - (bitmapData1.Width*4);
                }
            }
            image.UnlockBits(bitmapData1);
            return greyImage;
        }

        public static Bitmap GetGaussianFilteredImmage(Image image)
        {
            var b = ReadImage((Bitmap)image);
            var a = GaussianFilter(b, image.Width, image.Height);
            var c = DisplayImage(a);
            return c;
        }

        private static Bitmap DisplayImage(int[,] greyImage)
        {
            int width = greyImage.GetLength(0);
            int height = greyImage.GetLength(1);
            var image = new Bitmap(width, height);
            BitmapData bitmapData1 = image.LockBits(new Rectangle(0, 0, width, height),
                                     ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            unsafe
            {
                var imagePointer1 = (byte*)bitmapData1.Scan0;
                for (int i = 0; i < bitmapData1.Height; i++)
                {
                    for (int j = 0; j < bitmapData1.Width; j++)
                    {
                        // write the logic implementation here
                        imagePointer1[0] = (byte)greyImage[j, i];
                        imagePointer1[1] = (byte)greyImage[j, i];
                        imagePointer1[2] = (byte)greyImage[j, i];
                        imagePointer1[3] = 255;
                        //4 bytes per pixel
                        imagePointer1 += 4;
                    } 
                    //4 bytes per pixel
                    imagePointer1 += (bitmapData1.Stride - (bitmapData1.Width * 4));
                }
            }
            image.UnlockBits(bitmapData1);
            return image;
        }

        private static int[,] GaussianFilter(int[,] data, int width, int height)
        {
            int kernelWeight;
            var gaussianKernel = GenerateGaussianKernel(KERNEL_SIZE, SIGMA, out kernelWeight);

            const int limit = KERNEL_SIZE / 2;
            int[,] output = data;

            for (int i = limit; i <= ((width - 1) - limit); i++)
            {
                for (int j = limit; j <= ((height - 1) - limit); j++)
                {
                    float sum = 0;
                    for (int k = -limit; k <= limit; k++)
                    {
                        for (int l = -limit; l <= limit; l++)
                        {
                            sum = sum + ((float)data[i + k, j + l] * gaussianKernel[limit + k, limit + l]);
                        }
                    }
                    output[i, j] = (int)(Math.Round(sum / kernelWeight));
                }
            }
            return output;
        }

        private static int[,] GenerateGaussianKernel(int kernelSize, float sigma, out int kernelWeight)
        {
            const float pi = (float)Math.PI;
            int i, j;

            var kernel = new float[kernelSize, kernelSize];
            var gaussianKernel = new int[kernelSize, kernelSize];


            float d1 = 1 / (2 * pi * sigma * sigma);
            float d2 = 2 * sigma * sigma;

            float min = 1000;

            for (i = -kernelSize / 2; i <= kernelSize / 2; i++)
            {
                for (j = -kernelSize / 2; j <= kernelSize / 2; j++)
                {
                    kernel[kernelSize / 2 + i, kernelSize / 2 + j] = ((1 / d1) * (float)Math.Exp(-(i * i + j * j) / d2));
                    if (kernel[kernelSize / 2 + i, kernelSize / 2 + j] < min)
                        min = kernel[kernelSize / 2 + i, kernelSize / 2 + j];

                }
            }
            var mult = (int)(1 / min);
            int sum = 0;
            if ((min > 0) && (min < 1))
            {

                for (i = -kernelSize / 2; i <= kernelSize / 2; i++)
                {
                    for (j = -kernelSize / 2; j <= kernelSize / 2; j++)
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
                for (i = -kernelSize / 2; i <= kernelSize / 2; i++)
                {
                    for (j = -kernelSize / 2; j <= kernelSize / 2; j++)
                    {
                        kernel[kernelSize / 2 + i, kernelSize / 2 + j] = (float)Math.Round(kernel[kernelSize / 2 + i, kernelSize / 2 + j], 0);
                        gaussianKernel[kernelSize / 2 + i, kernelSize / 2 + j] = (int)kernel[kernelSize / 2 + i, kernelSize / 2 + j];
                        sum = sum + gaussianKernel[kernelSize / 2 + i, kernelSize / 2 + j];
                    }

                }

            }
            //Normalizing kernel Weight
            kernelWeight = sum;

            return gaussianKernel;
        }

    }
}
