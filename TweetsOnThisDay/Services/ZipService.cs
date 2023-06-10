using System.IO.Compression;
using TweetsOnThisDay.Extensions;
using TweetsOnThisDay.Models;

namespace TweetsOnThisDay.Services;
internal class ZipService
{
	public static async Task<List<ZipEntry>> ExtractFiles(Stream fileData)
	{
		await using var ms = new MemoryStream();
		await fileData.CopyToAsync(ms);

		using var archive = new ZipArchive(ms);

		var entries = new List<ZipEntry>();

		foreach (var entry in archive.Entries.Where(x => x.FullName is "data/tweets.js" or "data/account.js" || (x.FullName.Contains("data/profile_media") && !x.Name.Equals(string.Empty))))
		{
			await using var fileStream = entry.Open();
			var fileBytes = await fileStream.ReadFully();

			entries.Add(new ZipEntry { Name = entry.FullName, IsImage = entry.Name.EndsWith(".jpg"), FileBytes = fileBytes });
		}

		return entries;
	}
}
