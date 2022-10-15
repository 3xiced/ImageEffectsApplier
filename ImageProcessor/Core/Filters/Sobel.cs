using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ImageProcessor.Core.Filters;

public class Sobel : IFilter
{
    public Task<Bitmap> ApplyFilterAsync(FilterSettings filterSettings) => Task.Run(() => ApplyFilter(filterSettings));

    public Bitmap ApplyFilter(FilterSettings filterSettings)
    {
        Bitmap Image = (Bitmap)filterSettings.Image.Clone();
        Bitmap Image2 = new Bitmap(Image.Width, Image.Height);
        BitmapData ImageData, ImageData2;
        byte[] buffer, buffer2;
        int b, g, r, r_x, g_x, b_x, r_y, g_y, b_y, grayscale, location, location2;
        sbyte weight_x, weight_y;
        sbyte[,] weights_x = new sbyte[,] { { 1, 0, -1 }, { 2, 0, -2 }, { 1, 0, -1 } }; ;
        sbyte[,] weights_y = new sbyte[,] { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } }; ;
        IntPtr pointer, pointer2;
        ImageData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        ImageData2 = Image2.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
        buffer = new byte[ImageData.Stride * Image.Height];
        buffer2 = new byte[ImageData.Stride * Image.Height];
        pointer = ImageData.Scan0;
        pointer2 = ImageData2.Scan0;
        Marshal.Copy(pointer, buffer, 0, buffer.Length);
        for (int y = 0; y < Image.Height; y++)
        {
            for (int x = 0; x < Image.Width * 3; x += 3)
            {
                r_x = g_x = b_x = 0; //reset the gradients in x-direcion values
                r_y = g_y = b_y = 0; //reset the gradients in y-direction values
                location = x + y * ImageData.Stride; //to get the location of any pixel >> location = x + y * Stride
                for (int yy = -(int)Math.Floor(weights_y.GetLength(0) / 2.0d), yyy = 0; yy <= (int)Math.Floor(weights_y.GetLength(0) / 2.0d); yy++, yyy++)
                {
                    if (y + yy >= 0 && y + yy < Image.Height) //to prevent crossing the bounds of the array
                    {
                        for (int xx = -(int)Math.Floor(weights_x.GetLength(1) / 2.0d) * 3, xxx = 0; xx <= (int)Math.Floor(weights_x.GetLength(1) / 2.0d) * 3; xx += 3, xxx++)
                        {
                            if (x + xx >= 0 && x + xx <= Image.Width * 3 - 3) //to prevent crossing the bounds of the array
                            {
                                location2 = x + xx + (yy + y) * ImageData.Stride; //to get the location of any pixel >> location = x + y * Stride
                                weight_x = weights_x[yyy, xxx];
                                weight_y = weights_y[yyy, xxx];
                                //applying the same weight to all channels
                                b_x += buffer[location2] * weight_x;
                                g_x += buffer[location2 + 1] * weight_x; //G_X
                                r_x += buffer[location2 + 2] * weight_x;
                                b_y += buffer[location2] * weight_y;
                                g_y += buffer[location2 + 1] * weight_y;//G_Y
                                r_y += buffer[location2 + 2] * weight_y;
                            }
                        }
                    }
                }
                //getting the magnitude for each channel
                b = (int)Math.Sqrt(Math.Pow(b_x, 2) + Math.Pow(b_y, 2));
                g = (int)Math.Sqrt(Math.Pow(g_x, 2) + Math.Pow(g_y, 2));//G
                r = (int)Math.Sqrt(Math.Pow(r_x, 2) + Math.Pow(r_y, 2));

                if (b > 255) b = 255;
                if (g > 255) g = 255;
                if (r > 255) r = 255;

                //getting grayscale value
                grayscale = (b + g + r) / 3;

                //thresholding to clean up the background
                //if (grayscale < 80) grayscale = 0;
                buffer2[location] = (byte)grayscale;
                buffer2[location + 1] = (byte)grayscale;
                buffer2[location + 2] = (byte)grayscale;
                //thresholding to clean up the background
                //if (b < 100) b = 0;
                //if (g < 100) g = 0;
                //if (r < 100) r = 0;

                //buffer2[location] = (byte)b;
                //buffer2[location + 1] = (byte)g;
                //buffer2[location + 2] = (byte)r;
            }
        }
        Marshal.Copy(buffer2, 0, pointer2, buffer.Length);
        Image.UnlockBits(ImageData);
        Image2.UnlockBits(ImageData2);
        return Image2;
    }
}

