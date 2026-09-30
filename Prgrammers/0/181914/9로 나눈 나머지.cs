using System;

public class Solution {
    public int solution(string number) {
        int num = 0;
        for(int i=0; i < number.Length; i++)
            num += int.Parse(number[i].ToString());
        return num % 9;
    }
}