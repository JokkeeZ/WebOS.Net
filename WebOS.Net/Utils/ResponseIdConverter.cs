namespace WebOS.Net.Utils;

/// <summary>
/// Custom JSON converter for converting between string and numeric representations of response IDs.
/// </summary>
public class ResponseIdConverter : JsonConverter<string>
{
	/// <inheritdoc />
	public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
	reader.TokenType switch
	{
		JsonTokenType.String => reader.GetString(),
		JsonTokenType.Number when reader.TryGetInt32(out var i) => i.ToString(),
		_ => throw new JsonException($"Unexpected token type {reader.TokenType} when parsing id.")
	};

	/// <inheritdoc />
	public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
		=> writer.WriteStringValue(value);
}
