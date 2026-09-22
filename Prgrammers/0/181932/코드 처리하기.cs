using System;

public class Solution {
    public string solution(string code) {
        int mode = 0;
        string ret = "";
        
        for(int idx = 0; idx < code.Length; idx++){
            if(code[idx] == '1')
                mode = 1 - mode;
            else{
                if(mode == 0 && idx % 2 == 0)
                    ret += code[idx];
                else if(mode ==1 && idx % 2 ==1)
                    ret += code[idx];
            }
        }
        if(string.IsNullOrEmpty(ret))
            return "EMPTY";
        else
            return ret;
    }
}