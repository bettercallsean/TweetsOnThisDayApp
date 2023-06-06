using System.Globalization;
using System.Text.Json.Serialization;

namespace TweetsOnThisDay.Models;

public record EditInfo
{
	[JsonPropertyName("initial")]
	public Initial Initial { get; set; }
}

public record Entities
{
	[JsonPropertyName("user_mentions")]
	public List<object> UserMentions { get; set; }

	[JsonPropertyName("urls")]
	public List<object> Urls { get; set; }

	[JsonPropertyName("symbols")]
	public List<object> Symbols { get; set; }

	[JsonPropertyName("media")]
	public List<Medium> Media { get; set; }

	[JsonPropertyName("hashtags")]
	public List<object> Hashtags { get; set; }
}

public record ExtendedEntities
{
	[JsonPropertyName("media")]
	public List<Medium> Media { get; set; }
}

public record Initial
{
	[JsonPropertyName("editTweetIds")]
	public List<string> EditTweetIds { get; set; }

	[JsonPropertyName("editableUntil")]
	public DateTime EditableUntil { get; set; }

	[JsonPropertyName("editsRemaining")]
	public string EditsRemaining { get; set; }

	[JsonPropertyName("isEditEligible")]
	public bool IsEditEligible { get; set; }
}

public record Large
{
	[JsonPropertyName("w")]
	public string W { get; set; }

	[JsonPropertyName("h")]
	public string H { get; set; }

	[JsonPropertyName("resize")]
	public string Resize { get; set; }
}

public record Medium
{
	[JsonPropertyName("expanded_url")]
	public string ExpandedUrl { get; set; }

	[JsonPropertyName("indices")]
	public List<string> Indices { get; set; }

	[JsonPropertyName("url")]
	public string Url { get; set; }

	[JsonPropertyName("media_url")]
	public string MediaUrl { get; set; }

	[JsonPropertyName("id_str")]
	public string IdStr { get; set; }

	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("media_url_https")]
	public string MediaUrlHttps { get; set; }

	[JsonPropertyName("sizes")]
	public Sizes Sizes { get; set; }

	[JsonPropertyName("type")]
	public string Type { get; set; }

	[JsonPropertyName("display_url")]
	public string DisplayUrl { get; set; }

	[JsonPropertyName("video_info")]
	public VideoInfo VideoInfo { get; set; }
}

public record Medium2
{
	[JsonPropertyName("w")]
	public string W { get; set; }

	[JsonPropertyName("h")]
	public string H { get; set; }

	[JsonPropertyName("resize")]
	public string Resize { get; set; }
}

public record Root
{
	[JsonPropertyName("tweet")]
	public Tweet Tweet { get; set; }
}

public record Sizes
{
	[JsonPropertyName("medium")]
	public Medium Medium { get; set; }

	[JsonPropertyName("large")]
	public Large Large { get; set; }

	[JsonPropertyName("thumb")]
	public Thumb Thumb { get; set; }

	[JsonPropertyName("small")]
	public Small Small { get; set; }
}

public record Small
{
	[JsonPropertyName("w")]
	public string W { get; set; }

	[JsonPropertyName("h")]
	public string H { get; set; }

	[JsonPropertyName("resize")]
	public string Resize { get; set; }
}

public record Thumb
{
	[JsonPropertyName("w")]
	public string W { get; set; }

	[JsonPropertyName("h")]
	public string H { get; set; }

	[JsonPropertyName("resize")]
	public string Resize { get; set; }
}

public record Tweet
{
	[JsonPropertyName("edit_info")]
	public EditInfo EditInfo { get; set; }

	[JsonPropertyName("retweeted")]
	public bool Retweeted { get; set; }

	[JsonPropertyName("source")]
	public string Source { get; set; }

	[JsonPropertyName("entities")]
	public Entities Entities { get; set; }

	[JsonPropertyName("display_text_range")]
	public List<string> DisplayTextRange { get; set; }

	[JsonPropertyName("favorite_count")]
	public string FavoriteCount { get; set; }

	[JsonPropertyName("id_str")]
	public string IdStr { get; set; }

	[JsonPropertyName("truncated")]
	public bool Truncated { get; set; }

	[JsonPropertyName("retweet_count")]
	public string RetweetCount { get; set; }

	[JsonPropertyName("id")]
	public string Id { get; set; }

	[JsonPropertyName("possibly_sensitive")]
	public bool PossiblySensitive { get; set; }

	[JsonPropertyName("created_at")]
	public string CreatedAtString { get; set; }

	public DateTime CreatedAt =>
		DateTime.ParseExact(CreatedAtString, "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

	[JsonPropertyName("favorited")]
	public bool Favorited { get; set; }

	[JsonPropertyName("full_text")]
	public string FullText { get; set; }

	[JsonPropertyName("lang")]
	public string Lang { get; set; }

	[JsonPropertyName("extended_entities")]
	public ExtendedEntities ExtendedEntities { get; set; }
}

public record Variant
{
	[JsonPropertyName("bitrate")]
	public string Bitrate { get; set; }

	[JsonPropertyName("content_type")]
	public string ContentType { get; set; }

	[JsonPropertyName("url")]
	public string Url { get; set; }
}

public record VideoInfo
{
	[JsonPropertyName("aspect_ratio")]
	public List<string> AspectRatio { get; set; }

	[JsonPropertyName("variants")]
	public List<Variant> Variants { get; set; }
}
