using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(string[] intStrs, int k, int s, int l) {
        string[] sub = new string[intStrs.Length];
        List<int> answer = new List<int>();
        int i = 0;
        foreach(string str in intStrs)
        {
            sub[i] = str.Substring(s, l);
            i++;
        }
        foreach(string ans in sub)
        {
            if(int.Parse(ans) > k)
                answer.Add(int.Parse(ans));
        }
        
        return answer.ToArray();
    }
}