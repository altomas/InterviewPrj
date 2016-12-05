
5.12.2016

Applicant: Oleksand Zaslon
Position .Net developer

Deployment:

1) Build the project
2) Run UnitTests
3) See output of "TestAgainstFileDataSet" unit test to see reporting against file based input


Description:

- Design was taken based on considiration that most of values will be stored and should be tested once more and more during input operation...
That is why it will be better to compute hash of each input and store it, so the input operation is a little bit longer 
and depends on a logic of hash computing but lookup is very fast O(1) cause utilising Dictionary as a storage, the same for Add operation it is roughly O(1) 
except cases where dictionary capacity is not enough to accomodate new value, then new collection is created and values are copied 
what take O(m) where m is ammount of items in collection.  

Time Complexity fro current implementation of storage provider:
GetHash operation is the most time consuming evrething else is comparably innoticible and can be taken out of considiration 
	
 - Complexity: O(log(N)*N) where N is amount of values in entering set. 

Basically this is complexity of quick sort or merge sort operation during hash preparation