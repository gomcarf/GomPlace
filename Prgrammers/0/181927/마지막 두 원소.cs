using System;
using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] num_list) {
        int[] answer = new int[num_list.Length+1];
        
        for(int i = 0; i<num_list.Length; i++)
            answer[i] = num_list[i];
        
        int last = num_list[num_list.Length - 1];
        int prev = num_list[num_list.Length - 2];
        
        if(last > prev)
            answer[num_list.Length] = last - prev;
        else
            answer[num_list.Length] = last * 2;
        
        return answer;
    }
}