using System;
using System.Text;

public class Solution {
    public string solution(string my_string, int[] index_list) {
        StringBuilder result = new StringBuilder();
        
        foreach(int index in index_list)
            result.Append(my_string[index]);
        
        return result.ToString();
    }
}