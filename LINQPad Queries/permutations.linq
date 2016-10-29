<Query Kind="Program" />

public class Programm
{
void Main()
{
	int[] array = new int[]{1,2,3,4};
	
	//var result = Permutations(array, new int[0]);
	
	
}
IEnumerable<int[]> Permutations(int[] array, int[] prefix){

	var result = new List<int[]>{};
	
	for(int i = 0; i < array.Length; i++)
	{
		var temp = array.Subarray(0, i);
		temp.AddToEnd(array.Subarray(i));
		
		result.AddRange(Permutations(temp, prefix.AddToEnd(new int[]{ array[i] })));
	}
	
	return result;
}

}

public static class Test{

public static void PrintArray<T>(this T[] array)
{
	Console.WriteLine(string.Join(",", array));
}



public static T[] AddToEnd<T>(this T[] array1, T[] array2)
{
	var length1 = array1.Length;
	var length2 = array2.Length;
	Array.Resize(ref array1, length1 + length2);
	for(int i = length1; i < length1 + length2; i++)
	{
		array1[i] = array2[i-length1];
	}
	
	return array1;
}

public static T[] Subarray<T>(this T[] array, int beginIndex)
{
	return array.Subarray(beginIndex, array.Length - 1);
}

public static  T[] Subarray<T>(this T[] array, int beginIndex, int endIndex)
{
	var res = new T[beginIndex - endIndex];
	
	for(int i = beginIndex; i < endIndex; i++)
	{
		res[i - beginIndex] = array[beginIndex];
	}
	
	return res;
}
}