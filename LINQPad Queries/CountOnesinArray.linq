<Query Kind="Program" />

void Main()
{
	//1. You have an array of 0s and 1s
	//Find the longest sequence of 1s in the array
	//
	//Return the length and position
	//
	//
	//2. What if we allow at most one 0 in the middle of the sequence of 1s?
	//3. What if we allow at most K 0s in the middle of the sequence of 1s
	//
	//
	//000101110001111
	//
	//000110001100000 k = 3
	//0001100010 k = 3
	
	// what if there are only 0s?
	// what if there are 2 or more the same sequences which to return?
	
	// Test cases:
	//var array = new int[]{0,0,0,1,0,1,1,1,0,0,1,1,1,1,0,1};
	//var array = new int[]{1,1,1,1,0,1,1,1,0,0,1,1,1,1,0,1};
	var array = new int[]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	
	int k = 3;
	
	int startIndex = 0;
	int sequence = 0;
	int sequenceSum = 0;
	
	int pivot = 0;
	int endPivot = 0;
	int sum = 0;
	
	int index = 0;
	while(index < array.Length)
	{
	    var prevSum = sum; 
		sum += array[index]; 
		
		if(sum  > prevSum )
		{
			if(prevSum == 0)
			{
				//this is first 1s in sequence
				pivot = index;
			}
			
			// set end pivot only for last faced 1s
		    endPivot = index;
			index++;
			continue;
		}
		
		if(sum == 0)
		{
			// step over 0s, we haven't faced any 1s yet 
			index++;
			continue;
		}
			
		int expectedSum = index - pivot + 1;	
		if(expectedSum - sum <= k)
		{
			index++;
			continue;
		}
			
		if(sequenceSum <= sum)
	   	{
			startIndex = pivot;
			sequence = endPivot - pivot + 1;
			sequenceSum = sum;
		}
		
		sum = 0;
		
		index++;
	}
	
	if(sequenceSum <= sum)
	{
		startIndex = pivot;
		sequence = endPivot - pivot + 1;
		sequenceSum = sum;
	}
	
	if(sequenceSum == 0)
	{
		// No 1s in array
		startIndex = -1;
		sequence = 0;
	}
		
	Console.WriteLine("startIndex: " + startIndex);
	Console.WriteLine("sequence: " + sequence);
	Console.WriteLine("sum: " + sequenceSum);
}

// Define other methods and classes here
