using System;

public class Solution {
    public int solution(int n) {
        int m = (n+1)/2;
        if(n % 2 == 1)
            return m*m;
        else
            return 2*m*(m+1)*(2*m+1)/3;
    }
}