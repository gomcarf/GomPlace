using System;

public class Solution1 {
    public string solution1(string my_string, string overwrite_string, int s) {
        string answer = "";
        
        for(int i = 0 ; i < my_string.Length; i++)
        {
            if(i>=s && i < s + overwrite_string.Length)
                answer += overwrite_string[i-s];
            else
                answer += my_string[i];
        }
        
        return answer;
    }
    
    public string solution2(string my_string, string overwrite_string, int s)
    {
        string answer = "";

        string prestr = my_string.Substring(0, s);
        string poststr = my_string.Substring(s + overwrite_string.Length);

        answer = prestr + overwrite_string + poststr;

        return answer;
    }
}