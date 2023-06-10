using System.Text.Json.Serialization;

namespace TweetsOnThisDay.Models;
public record Account
{
	[JsonPropertyName("email")]
	public string Email { get; set; }

	[JsonPropertyName("createdVia")]
	public string CreatedVia { get; set; }

	[JsonPropertyName("username")]
	public string Username { get; set; }

	[JsonPropertyName("accountId")]
	public string AccountId { get; set; }

	[JsonPropertyName("createdAt")]
	public string CreatedAt { get; set; }

	[JsonPropertyName("accountDisplayName")]
	public string AccountDisplayName { get; set; }
}

public record AccountRoot
{
	[JsonPropertyName("account")]
	public Account Account { get; set; }
}
