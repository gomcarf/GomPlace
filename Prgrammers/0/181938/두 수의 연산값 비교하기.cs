using System;

public class Solution {
    public int solution(int a, int b) {
        int ab = int.Parse(a.ToString()+b.ToString());
        
        if(ab >= 2*a*b)
            return ab;
        else
            return 2*a*b;
    }
}