using TweetsOnThisDay.Models;

namespace TweetsOnThisDay.Services;
internal class ZipService
{

    public static async Task<List<ZipEntry>> ExtractFiles(string zipFilePath)
    {
        var entries = new List<ZipEntry>();

        using var zip = Ionic.Zip.ZipFile.Read(zipFilePath);

        var files = zip.Where(x => x.FileName is "data/tweets.js" or "data/account.js" || (x.FileName.Contains("data/profile_media") && x.FileName.EndsWith(".jpg")));

        foreach (var file in files)
        {
            using var ms = new MemoryStream();

            await using var fileStream = file.OpenReader();
            await fileStream.CopyToAsync(ms);

            entries.Add(new ZipEntry { Name = file.FileName, IsImage = file.FileName.EndsWith(".jpg"), FileBytes = ms.ToArray() });
        }

        return entries;
    }
}
