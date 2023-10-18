using System.Drawing;
using System.Drawing.Imaging;

Console.Write("Input?> ");
var iFile = Console.ReadLine();

if (!File.Exists(iFile))
{
    Console.Error.WriteLine("No exists");
    Environment.Exit(1);
}

var img = new Bitmap(iFile);

Console.Write("Threshold? (180)>");
var thresholdStr = Console.ReadLine();

int threshold = 180;

if (thresholdStr != "" && !int.TryParse(thresholdStr, out threshold))
{
    Console.Error.WriteLine("Invalid threshold");
    Environment.Exit(1);
}

for (int y = 0; y < img.Height; y++)
    for (int x = 0; x < img.Width; x++)
    {
        var pixel = img.GetPixel(x, y);
        if (pixel.R < threshold && pixel.G < threshold && pixel.B < threshold)
            img.SetPixel(x, y, Color.Black);
        else
            img.SetPixel(x, y, Color.White);
    }

img.Save(iFile + ".linedraw.bmp", ImageFormat.Bmp);