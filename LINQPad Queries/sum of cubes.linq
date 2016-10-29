<Query Kind="Program" />

//find all positive integer solutions under 1,000 to a3 + b3 = c3 + d3 (page 68).

void Main()
{
	var n = 100;
	List<Tuple<int,int,int,int>> res = new List<Tuple<int,int,int,int>>();
	Dictionary<int, List<Tuple<int,int>>> sums = new Dictionary<int,List<Tuple<int,int>>>();
	
	for(int i = 1; i < n; i++){
		for(int j = i; j < n; j++){
			
			var sum = Cube(i) + Cube(j);
			var examiningPair = new Tuple<int, int>(i, j);
			
			if(!sums.ContainsKey(sum))
			{
				sums.Add(sum, new List<Tuple<int,int>>(){ examiningPair });
				
				var results = GetPairsPermutation(examiningPair, examiningPair);
				res.AddRange(results);
				continue;
			}
						
			foreach(var t in sums[sum])
			{
				var results = GetPairsPermutation(examiningPair, t);
				var results2 = GetPairsPermutation(examiningPair, examiningPair);
				res.AddRange(results);
				res.AddRange(results2);
			}			
			
			sums[sum].Add(examiningPair);
		}
	}
	
	Console.WriteLine("variants: "+ res.Count());
}

int Cube(int val){
	return val * val * val;
}

IEnumerable<Tuple<int,int,int,int>> GetPairsPermutation(Tuple<int, int> pair1, Tuple<int, int> pair2)
{
	var permutationPairs = new List<Tuple<int, int>>();
	permutationPairs.Add(pair1);
	
	if(pair1.Item1 != pair1.Item2)
	{
		permutationPairs.Add(new Tuple<int,int>(pair1.Item2, pair1.Item1));
	}
	
	var permutationPairs2 = new List<Tuple<int, int>>();
	permutationPairs.Add(pair2);
	
	if(pair2.Item1 != pair2.Item2)
	{
		permutationPairs2.Add(new Tuple<int,int>(pair2.Item2, pair2.Item1));
	}
	
	
	foreach(var p in permutationPairs)
	{
		foreach(var p2 in permutationPairs2)
		{
			yield return new Tuple<int, int, int, int>(p.Item1, p.Item2, pair2.Item1, pair2.Item2);
		}
	}
	
	foreach(var p in permutationPairs2)
	{
		foreach(var p2 in permutationPairs)
		{
			yield return new Tuple<int, int, int, int>(p.Item1, p.Item2, pair2.Item1, pair2.Item2);
		}
	}
}

// Define other methods and classes here