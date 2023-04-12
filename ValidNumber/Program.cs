#region Problem
/*
A valid number can be split up into these components (in order):

A decimal number or an integer.
(Optional) An 'e' or 'E', followed by an integer.
A decimal number can be split up into these components (in order):

(Optional) A sign character (either '+' or '-').
One of the following formats:
One or more digits, followed by a dot '.'.
One or more digits, followed by a dot '.', followed by one or more digits.
A dot '.', followed by one or more digits.
An integer can be split up into these components (in order):

(Optional) A sign character (either '+' or '-').
One or more digits.
For example, all the following are valid numbers: 
["2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789"], 
while the following are not valid numbers: ["abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53"].

Given a string s, return true if s is a valid number.

LeetCode link: https://leetcode.com/problems/valid-number/
*/
#endregion

#region Solution

Console.WriteLine(IsNumber("-12.34e78"));
static bool IsNumber(string s)
{
    var hasE = false;
    var hasDot = false;

    for (int i = 0; i < s.Length; i++)
    {
        switch (s[i])
        {
            case '+':
            case '-':
                if ((i > 0 && !IsE(s[i - 1])) || i == s.Length - 1)
                    return false;
                break;
            case 'e':
            case 'E':
                if (hasE || 
                    i == 0 || !IsDigitOrDot(s[i - 1])  || 
                    i == s.Length - 1 || !IsDigitOrSign(s[i + 1])
                    ) 
                    return false;
                hasE = true;
                hasDot = true;
                break;
            case '.':
                if (hasDot || (
                    (i == 0 || !IsDigit(s[i - 1])) && 
                    (i == s.Length - 1 || !IsDigit(s[i + 1]))
                    )) 
                    return false;
                hasDot = true;
                break;
            case char c when c >= '0' && c <= '9' :
                break;
            default: 
                return false;
        }

    }

    return true;
}

static bool IsDigitOrSign(char c)
{
    return IsDigit(c) || c == '+' || c == '-';
}

static bool IsDigitOrDot(char c)
{
    return IsDigit(c) || c == '.';
}

static bool IsE(char c)
{
    return c == 'e' || c == 'E';
}

static bool IsDigit(char c)
{
    return c >= '0' && c <= '9';
}

#endregion