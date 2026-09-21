using System;

public class Solution {
    public int solution(string ineq, string eq, int n, int m) {
        string ie = ineq + eq;
        if(ie == ">=") return n >= m ? 1 : 0;
        if(ie == "<=") return n <= m ? 1 : 0;
        if(ie == ">!") return n > m ? 1 : 0;
        if(ie == "<!") return n < m ? 1 : 0;
        return 0;
    }
}