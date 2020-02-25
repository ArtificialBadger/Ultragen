<Query Kind="Program">
  <NuGetReference>Markov</NuGetReference>
  <Namespace>Markov</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


async Task Main()
{
	// Create a chain with letters as the unit of data, basing each letter on the previous 2 letters
	var chain = new MarkovChain<char>(3);
	//chain.

	foreach (var name in await GetCityNames())
	{
		chain.Add(name);
	}
	
	// Randomly generate words that resemble the words in the dictionary.
	var rand = new Random();
	for (int i = 0; i < 100; i++)
	{
		var word = new string(chain.Chain(rand).ToArray());
		Console.WriteLine(word.Trim());
	}
}

public async Task<IEnumerable<string>> GetCityNames()
{	
	var file = new StreamReader(@"---");

	var rawNames = await file.ReadToEndAsync();
	
	return rawNames
		.Split(Environment.NewLine)
		.Select(n => n.Trim())
		.Select(n => n.Replace("(", ""))
		.Select(n => n.Replace(")", ""))
		.Select(n => n.Contains(',') ? String.Join(' ', n.Split(',').Reverse()) : n);
}

// Define other methods, classes and namespaces here
