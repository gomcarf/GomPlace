using System;

public class Solution {
    public int solution(int n, string control) {
        char[] c = new char[control.Length];
        for(int i = 0; i < control.Length; i++)
        {
            c[i] = control[i];
            switch(control[i]){
                case 'w':
                    n += 1;
                    break;
                case 's':
                    n -= 1;
                    break;
                case 'd':
                    n += 10;
                    break;
                case 'a':
                    n -= 10;
                    break;
                default:
                    break;
            }
        }
        return n;
    }
}