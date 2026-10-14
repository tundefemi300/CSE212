```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// Find all symmetric pairs of two-character words.
    /// </summary>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var pairs = new List<string>();

        foreach (var word in words)
        {
            string reverse = $"{word[1]}{word[0]}";

            if (word != reverse &&
                wordSet.Contains(reverse) &&
                string.Compare(word, reverse, StringComparison.Ordinal) < 0)
            {
                pairs.Add($"{word} & {reverse}");
            }
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Count the number of people who earned each degree.
    /// The degree is stored in the fourth column.
    /// </summary>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            string[] fields = line.Split(',');

            if (fields.Length < 4)
            {
                continue;
            }

            string degree = fields[3].Trim();

            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine whether two words are anagrams.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        word1 = word1.Replace(" ", "").ToLowerInvariant();
        word2 = word2.Replace(" ", "").ToLowerInvariant();

        if (word1.Length != word2.Length)
        {
            return false;
        }

        var letters = new Dictionary<char, int>();

        foreach (char letter in word1)
        {
            if (letters.ContainsKey(letter))
            {
                letters[letter]++;
            }
            else
            {
                letters[letter] = 1;
            }
        }

        foreach (char letter in word2)
        {
            if (!letters.ContainsKey(letter))
            {
                return false;
            }

            letters[letter]--;

            if (letters[letter] < 0)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Retrieve daily earthquake data and return the location
    /// and magnitude of each earthquake.
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri =
            "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var response = client.Send(getRequestMessage);

        response.EnsureSuccessStatusCode();

        using var jsonStream = response.Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);

        var json = reader.ReadToEnd();

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var featureCollection =
            JsonSerializer.Deserialize<FeatureCollection>(json, options);

        if (featureCollection?.Features == null)
        {
            return Array.Empty<string>();
        }

        var earthquakes = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            if (feature.Properties != null)
            {
                earthquakes.Add(
                    $"{feature.Properties.Place} - Mag {feature.Properties.Mag}");
            }
        }

        return earthquakes.ToArray();
    }
}
```
