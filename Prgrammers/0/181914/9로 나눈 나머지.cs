using System;

public class Solution {
    public int solution(string number) {
        int num = 0;
        for(int i=0; i < number.Length; i++)
            num += int.Parse(number[i].ToString());
        return num % 9;
    }
}

/* 람다를 사용한 풀이
using System;
using System.Linq;

public class Solution {
    public int solution(string number) {
        return number.Select(s => s - '0').Sum() % 9;
    }
}
 
 */