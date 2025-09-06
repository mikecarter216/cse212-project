using System.Text.Json;

public static class SetsAndMaps
{
    // ---------- Problem 1: FindPairs ----------
    public static string[] FindPairs(string[] words)
    {
        var result = new List<string>();
        var wordSet = new HashSet<string>(words);

        foreach (var word in words)
        {
            if (word[0] == word[1]) continue; // skip duplicates like "aa"

            var reversed = new string(word.Reverse().ToArray());
            if (wordSet.Contains(reversed))
            {
                var pair = $"{word} & {reversed}";
                var reversePair = $"{reversed} & {word}";
                if (!result.Contains(pair) && !result.Contains(reversePair))
                {
                    result.Add(pair);
                }
            }
        }

        return result.ToArray();
    }

    // ---------- Problem 2: SummarizeDegrees ----------
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            if (fields.Length < 4) continue;

            var degree = fields[3].Trim();
            if (degree.Length == 0) continue;

            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    // ---------- Problem 3: IsAnagram ----------
    public static bool IsAnagram(string word1, string word2)
    {
        string Normalize(string s) =>
            new string(s.ToLower().Replace(" ", "").ToCharArray());

        var w1 = Normalize(word1);
        var w2 = Normalize(word2);

        if (w1.Length != w2.Length) return false;

        var dict = new Dictionary<char, int>();

        foreach (var c in w1)
        {
            if (dict.ContainsKey(c)) dict[c]++;
            else dict[c] = 1;
        }

        foreach (var c in w2)
        {
            if (!dict.ContainsKey(c)) return false;
            dict[c]--;
            if (dict[c] < 0) return false;
        }

        return dict.Values.All(v => v == 0);
    }

    // ---------- Problem 5: EarthquakeDailySummary ----------
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        if (featureCollection?.Features == null) return Array.Empty<string>();

        var results = new List<string>();
        foreach (var feature in featureCollection.Features)
        {
            var place = feature.Properties?.Place ?? "Unknown location";
            var mag = feature.Properties?.Mag ?? 0.0;
            results.Add($"{place} - Mag {mag}");
        }

        return results.ToArray();
    }
}
