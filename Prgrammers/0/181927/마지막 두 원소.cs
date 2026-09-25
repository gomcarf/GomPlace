using System;

public class Solution {
    public int[] solution(int[] num_list) {
        int[] answer = new int[num_list.Length+1];
        
        Array.Copy(num_list, answer, num_list.Length);
        
        int last = num_list[num_list.Length - 1];
        int prev = num_list[num_list.Length - 2];
        
        if(last > prev)
            answer[num_list.Length] = last - prev;
        else
            answer[num_list.Length] = last * 2;
        
        return answer;
    }
}

/* 리스트를 이용한 풀이
 using System;
 using System.Collections.Generic;

public class Solution {
    public int[] solution(int[] num_list) {
        List<int> answer = new List<int>();
        answer.AddRange(num_list);
        
        int last = num_list[num_list.Length - 1];
        int prev = num_list[num_list.Length - 2];
        
        if(last > prev)
            answer.Add(last - prev);
        else
            answer.Add(last * 2);
        
        return answer.ToArray();
    }
}
*/