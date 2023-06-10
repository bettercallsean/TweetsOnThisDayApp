namespace TweetsOnThisDay.Models;
internal record ZipEntry
{
	public string Name { get; init; }
	public bool IsImage { get; set; }
	public byte[] FileBytes { get; set; }
}