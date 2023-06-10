namespace TweetsOnThisDay.Extensions;
internal static class StreamExtensions
{
	public static async Task<byte[]> ReadFully(this Stream input)
	{
		await using var ms = new MemoryStream();
		await input.CopyToAsync(ms);
		return ms.ToArray();
	}
}
