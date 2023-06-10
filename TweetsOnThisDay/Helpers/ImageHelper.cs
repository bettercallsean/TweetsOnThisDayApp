#if WINDOWS
using System.Drawing;
#else
using System.Drawing;
using Microsoft.Maui.Graphics.Platform;
#endif

namespace TweetsOnThisDay.Helpers;
internal static class ImageHelper
{
	public static bool IsPictureSquare(byte[] imageBytes)
	{
		var stream = new MemoryStream(imageBytes);
#if WINDOWS

		var image = new Bitmap(stream);

#else
		var image = PlatformImage.FromStream(stream);
#endif

		return image.Width == image.Height;
	}
}
