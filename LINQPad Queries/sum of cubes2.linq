<Query Kind="Program" />

void Main()
{
	var n = 100;
	HashSet<string> table = new HashSet<string>();
	List<Tuple<int,int,int,int>> res = new List<Tuple<int,int,int,int>>();
	for(var a = 1; a <n ; a++)
	{
		for(var b = 1; b < n ; b++)
		{
			for(var c = 1; c < n ; c++)
			{
				for(var d = 1; d <n ; d++)
				{
				
					if(a==b || c==d)
					{
						var key = ""+a+";"+b+";"+c+";"+d;
						if(table.Contains(key))
						{
						  continue;	
						}
						
						table.Add(key);
					}
					
					var sum = Cube(a) - Cube(c) + Cube(b) - Cube(d);
										
					if(sum == 0)
					{
						var t = new Tuple<int,int,int,int>(a, b, c, d);
					  res.Add(t);
					  break;
					}
					
					
				}
			}
		}
	}
	
	Console.WriteLine(res.Count());
}

int Cube(int val){
return val * val * val;
}