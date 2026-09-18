using System;

public class Solution {
    public int solution(int a, int b) {
        int answer = 0;
        int x, y;
        string ab = a.ToString() + b.ToString();
        string ba = b.ToString() + a.ToString();
        
        if(int.Parse(ab) > int.Parse(ba))
            answer = int.Parse(ab);
        else
            answer = int.Parse(ba);
                
        return answer;
    }
}