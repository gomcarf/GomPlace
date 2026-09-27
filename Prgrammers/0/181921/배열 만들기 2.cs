using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(int l, int r) {
        List<int> result = new List<int>();
        for(int i = l; i <= r; i++)
        {
            string s = i.ToString();
            if(s.All(c => c == '0' || c == '5'))
                result.Add(i);
        }
        if(result.Count == 0)
        return new int[] {-1};
    
        return result.ToArray();
    }
    
}