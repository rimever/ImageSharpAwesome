using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Primitives;

namespace ImageSharpAwesome
{
    class Program
    {
        static void Main(string[] args)
        {
            const int chipSize = 16;
            Size size = new Size(60,30);
            using (var image = new Image<Rgba32>(size.Width * chipSize,size.Height * chipSize))
            {
                using (var chipImage = Image.Load<Rgba32>("Resources/field.png"))
                {
                    for (int x = 0; x < size.Width; x++)
                    {
                        for (int y = 0; y < size.Height; y++)
                        {
                            var chipPoint = GetChipPoint(size, x, y);
                            for (int cx = 0; cx < chipSize; cx++)
                            {
                                for (int cy = 0; cy < chipSize; cy++)
                                {
                                    image[x * chipSize + cx, y * chipSize + cy] = chipImage[chipPoint.X * chipSize + cx,
                                        chipPoint.Y * chipSize + cy];
                                }
                            }
                        }
                    }
                    image.Save("create.png");
                }
            }
        }

        private static Point GetChipPoint(Size size, int x, int y)
        {
            Point chipPoint = new Point();
            if (x == 0)
            {
                chipPoint.X = 0;
            }
            else if (x == size.Width - 1)
            {
                chipPoint.X = 2;
            }
            else
            {
                chipPoint.X = 1;
            }

            if (y == 0)
            {
                chipPoint.Y = 0;
            }
            else if (y == size.Height - 1)
            {
                chipPoint.Y = 2;
            }
            else
            {
                chipPoint.Y = 1;
            }

            return chipPoint;
        }
    }
}
