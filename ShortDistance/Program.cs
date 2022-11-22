//You have a large text file containing words. Given any two words,
//find the shortest distance (in terms of number of words) between them in the file.
//If the operation will be repeated many times for the same file (but different pairs of words),
//can you optimize your solution?

//txt
//word1 we
//word2 to
//we
//have
//this
//to
//as parem and we need to find best and shortest way


//we 0 => 2
//to 10 => 2

//

public static class Program
{
    static Dictionary<string, int> dic = new Dictionary<string, int>();
    public static void Main()
    {
        string txtTest1 = "x a x x a x x b x a";
        string word1Test1 = "a";
        string word2Test1 = "b";
        int result1Test1 =  clacDistance(txtTest1, word1Test1, word2Test1);
        Console.WriteLine($"Min distance is: {result1Test1}");

        string txtTest2 = "we have this to as parem and we need to find best and shortest way";
        string word1Test2 = "we";
        string word2Test2 = "to";
        int result1Test2 = clacDistance(txtTest2, word1Test2, word2Test2);
        Console.WriteLine($"Min distance is: {result1Test2}");

        string txtTest3 = "this a test number 3 of b by match a and b";
        string word1Test3 = "a";
        string word2Test3 = "b";
        int result1Test3 = clacDistance(txtTest3, word1Test3, word2Test3);
        Console.WriteLine($"Min distance is: {result1Test3}");

        string txtTest4 = "word1 word2 short path between word1 and word2";
        string word1Test4 = "word1";
        string word2Test4 = "word2";
        int result1Test4 = clacDistance(txtTest4, word1Test4, word2Test4);
        Console.WriteLine($"Min distance is: {result1Test4}");

    }
    public static int clacDistance(string txt, string word1, string word2)
    {
        
        if (string.IsNullOrEmpty(txt))
            return -1;

        if (string.IsNullOrEmpty(word1) || string.IsNullOrEmpty(word2))
            return -1;

        string hashKey = $"{txt}_{word1}_{word2}";
        if(dic.ContainsKey(hashKey))
            return dic[hashKey];

        int minDistance = int.MaxValue;
        Stack<string> stackKeys = new Stack<string>();

        //we have this to as parem and we need to find best and shortest way
        var arrWords = txt.Split(' ');
        int index = 1;
        for (int i = 0; i < arrWords.Length; i++)
        {
            if(arrWords[i] == word1)
            {
                if(stackKeys.Count > 0 && stackKeys.Peek() == word2)
                {
                    var distance = index;
                    if(distance < minDistance)
                        minDistance = distance;
                    index = 1;
                    stackKeys.Pop();
                    stackKeys.Push(word1);
                }
                else
                {
                    if (stackKeys.Count > 0)
                    {
                        stackKeys.Pop();
                        index = 1;
                    }
                    stackKeys.Push(word1);
                }
            }
            else if (arrWords[i] == word2)
            {
                if (stackKeys.Count > 0 && stackKeys.Peek() == word1)
                {
                    if (index < minDistance)
                        minDistance = index;
                    index = 1;
                    stackKeys.Pop();
                    stackKeys.Push(word2);
                }
                else
                {
                    if (stackKeys.Count > 0)
                    {
                        stackKeys.Pop();
                        index = 1;
                    }
                        
                    stackKeys.Push(word2);
                }
            }
            else
            {
                if(stackKeys.Count > 0)
                    index += arrWords[i].Length + 1;
            }
        }

        dic[hashKey] = minDistance;

        return minDistance;
    }
}