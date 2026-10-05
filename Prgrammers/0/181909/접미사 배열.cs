using System;
using System.Collections.Generic;

public class Solution {
    public string[] solution(string my_string) {
        List<string> answer = new List<string>();
        for(int i = 0; i < my_string.Length; i++)
        {
            answer.Add(my_string.Substring(i));
        }
        answer.Sort();
        
        return answer.ToArray();
    }
}