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
/*
삼항 연산자 사용한 풀이
n이 짝수라면 n이 0 이상인 동안 n*n을 더해가며 2씩 감소
n이 짝수라면 n이 0 이상인 동안 n을 더해가며 2씩 감소
while(n >=0)
{
    answer += n%2 == 0 ? n*n : n;            
    n -= 2;
}
return answer;
*/
