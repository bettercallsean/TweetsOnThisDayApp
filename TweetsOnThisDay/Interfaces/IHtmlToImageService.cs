namespace TweetsOnThisDay.Interfaces;
internal interface IHtmlToImageService
{
	Task<byte[]> GetImageFromHtmlAsync(string html);
}
