using System;

public class Solution {
    public string solution(string my_string, int[,] queries) {
        char[] answer = my_string.ToCharArray();
        
        for(int i = 0; i < queries.GetLength(0); i++){
            int prev = queries[i,0];
            int last = queries[i,1];
            
            Array.Reverse(answer, prev, last - prev + 1);
        }
        return new string(answer);
    }
}