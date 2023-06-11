namespace TweetsOnThisDay.Services;
internal class ZipService
{

	public static async Task<List<Models.ZipEntry>> ExtractFiles(string zipFilePath)
	{
		var entries = new List<Models.ZipEntry>();

		using var zip = Ionic.Zip.ZipFile.Read(zipFilePath);

		var foo = zip.Where(x => x.FileName is "data/tweets.js" or "data/account.js" || (x.FileName.Contains("data/profile_media") && x.FileName.EndsWith(".jpg")));

		foreach (var file in foo)
		{
			using var ms = new MemoryStream();

			await using var fileStream = file.OpenReader();
			await fileStream.CopyToAsync(ms);

			entries.Add(new Models.ZipEntry { Name = file.FileName, IsImage = file.FileName.EndsWith(".jpg"), FileBytes = ms.ToArray() });
		}

		return entries;
	}
}
