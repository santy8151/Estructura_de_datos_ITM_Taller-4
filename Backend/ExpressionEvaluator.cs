using System;
using System.Collections.Generic;
using System.Text;

namespace Backend;

public static class ExpressionEvaluator
{
    public static double Evalute(string infix) => EvalutePostfix(ToPostfix(infix));

    private static List<string> ToPostfix(string infix)
    {
        var posfix = new List<string>();
        var stack = new Stack<char>();
        var tokens = GetTokens(infix);
        
        // Shunting-yard algorithm to convert infix tokens to postfix notation
        foreach (var item in tokens)
        {
            if (item.Length == 1 && IsOperator(item[0]))
            {
                char op = item[0];
                if (op == ')')
                {
                    var ope = stack.Pop();
                    while(ope != '(')
                    {
                        posfix.Add(ope.ToString());
                        ope = stack.Pop();
                    }
                }
                else
                {
                    if (stack.Count == 0 || op == '(')
                    {
                        stack.Push(op);
                    }
                    else
                    {
                        if (PriorityInfix(op) > PriorityStack(stack.Peek()))
                        {
                            stack.Push(op);
                        }
                        else
                        {
                            while (stack.Count > 0 && PriorityInfix(op) <= PriorityStack(stack.Peek()))
                            {
                                posfix.Add(stack.Pop().ToString());
                            }
                            stack.Push(op);
                        }
                    }
                }
            }
            else
            {
                posfix.Add(item);
            }
        }

        while (stack.Count != 0)
        {
            posfix.Add(stack.Pop().ToString());
        }

        return posfix;
    }

    private static List<string> GetTokens(string infix)
    {
        var tokens = new List<string>();
        var currentNumber = new StringBuilder();
        
        // Parses the raw string into numbers (including decimals/negatives) and operators
        for (int i = 0; i < infix.Length; i++)
        {
            char c = infix[i];
            
            if (char.IsDigit(c) || c == '.' || c == ',')
            {
                if (c == ',') c = '.';
                currentNumber.Append(c);
            }
            else if (IsOperator(c))
            {
                if (currentNumber.Length > 0)
                {
                    tokens.Add(currentNumber.ToString());
                    currentNumber.Clear();
                }
                
                // Identify unary minus vs subtraction
                if (c == '-' && (i == 0 || IsOperator(infix[i - 1]) && infix[i - 1] != ')'))
                {
                    currentNumber.Append('-');
                }
                else
                {
                    tokens.Add(c.ToString());
                }
            }
            else if (!char.IsWhiteSpace(c))
            {
                currentNumber.Append(c);
            }
        }
        
        if (currentNumber.Length > 0)
        {
            tokens.Add(currentNumber.ToString());
        }
        
        return tokens;
    }

    private static int PriorityStack(char op) => op switch
    {
        '^' => 3,
        '*' => 2,
        '/' => 2,
        '+' => 1,
        '-' => 1,
        '(' => 0,
        _ => throw new Exception("Invalid expression."),
    };

    private static int PriorityInfix(char op) => op switch
    {
        '^' => 4,
        '*' => 2,
        '/' => 2,
        '+' => 1,
        '-' => 1,
        '(' => 5,
        _ => throw new Exception("Invalid expression."),
    };

    private static bool IsOperator(char item) => item == '^' || item == '*' || item == '/' || item == '+' || item == '-' || item == '(' || item == ')';

    private static double EvalutePostfix(List<string> postfix)
    {
        var stack = new Stack<double>();

        // Process postfix tokens to compute the final numeric result
        foreach (var item in postfix)
        {
            if (item.Length == 1 && IsOperator(item[0]))
            {
                var ope2 = stack.Pop();
                var ope1 = stack.Pop();
                stack.Push(Calculate(ope1, ope2, item[0]));
            }
            else
            {
                if (double.TryParse(item, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double num))
                {
                    stack.Push(num);
                }
                else
                {
                    throw new Exception("Invalid number format.");
                }
            }
        }
        return stack.Pop();
    }

    private static double Calculate(double ope1, double ope2, char item) => item switch
    {
        '*' => ope1 * ope2,
        '/' => ope1 / ope2,
        '+' => ope1 + ope2,
        '-' => ope1 - ope2,
        '^' => Math.Pow(ope1, ope2),
        _ => throw new Exception("Invalid expression."),
    };
}
