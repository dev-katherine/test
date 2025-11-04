
/// Author:    Katherine Jang
/// Partner:   None 
/// Date:      20/9/2025
/// Course:    CS 3500, University of Utah, School of Computing 
/// Copyright: CS 3500 and Katherine Jang - This work may not be copied for use in Academic Coursework. 
/// 
/// I, Katherine Jang , certify that I wrote this code from scratch and did not copy it in part or whole from
/// another source.  All references used in the completion of the assignment are cited in my README file. 
/// 
/// 
/// FormulaEvaluator calculates the expressions expressed in the infix expression.
///  FormulaEvaluator is implemented a middle evaluator using the stack and applied a method to handle exceptions such as parentheses and operator priorities. 
/// Tried to distinguish between cases to be ignored and cases to be error-throwed.
/// 


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Linq;
using System.Text.RegularExpressions;

using Microsoft.VisualBasic;

namespace FormulaEvaluator
{

    public delegate int Lookup(string variable_name);

    /// <summary>
    ///  Evaluator class calculates the expressions expressed in the infix expression.
    /// </summar>
    public static class Evaluator
    {
        public static Stack<string> OperatorStck = new Stack<string>();
        public static Stack<int> ValueStck = new Stack<int>();

        /// <summary>
        /// Evaluate the infix expression.
        /// </summary>
        /// <param name="expression">integer arithmetic expressions with standard infix notation</param>
        /// <returns> result from the evaluated expression</returns>
        public static int Evaluate(string expression, Lookup variableEvaluator)
        {
            string? prevToken = null;
            string delimiters = "(\\()|(\\))|(-)|(\\+)|(\\*)|(/)";

            OperatorStck.Clear();
            ValueStck.Clear();

            if (string.IsNullOrEmpty(expression))
            {
                throw new ArgumentException(expression, "Expression Empty");
            }

            string[] tokens = Regex.Split(expression, delimiters);


            foreach (string token in tokens)
            {
                string trimmedToken = token.Trim();

                if (string.IsNullOrEmpty(trimmedToken))
                    continue;

                // if (trimmedToken == "-" && (prevToken == null || prevToken == "(" || isValidOperator(prevToken)))
                //     throw new ArgumentException("Unary Minus not allowed");

                ProcessToken(trimmedToken);
                prevToken = trimmedToken;
            }
            while (OperatorStck.Count != 0 && isValidOperator(OperatorStck.Peek()))
            {
                if (ValueStck.Count < 2)
                    throw new ArgumentException("Invalid Expression");

                int a = ValueStck.Pop();
                int b = ValueStck.Pop();
                string op = OperatorStck.Pop();

                ValueStck.Push(Operate(op, a, b));
            }

            if (ValueStck.Count == 1 && OperatorStck.Count == 0)
            {
                return ValueStck.Pop();
            }
            else
            {
                throw new ArgumentException("Invalid Expression");
            }
        }

        /// <summary>
        /// Process a token from the expression and updates the stacks
        /// </summary>
        /// <param name="token">a single token from the infix expression</param>
        /// <exception cref="ArgumentException">
        /// throw when the token is invalid (undefined expression token)
        /// </exception>
        /// <returns> void </returns>
        static void ProcessToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new ArgumentException("Invalid Argument");


            if (int.TryParse(token, out int numb))
                ValueStck.Push(int.Parse(token));

            else if (token == "(" || token == "*" || token == "/")
                OperatorStck.Push(token);

            else if (token == ")")
            {
                while (OperatorStck.Count > 0 && OperatorStck.Peek() != "(")
                {
                    if (ValueStck.Count < 2)
                        throw new ArgumentException("Invalid Expression");

                    int a = ValueStck.Pop();
                    int b = ValueStck.Pop();
                    string op = OperatorStck.Pop();

                    ValueStck.Push(Operate(op, a, b));
                }
                if (OperatorStck.Count == 0 || OperatorStck.Peek() != "(")
                    throw new ArgumentException("Invalid Expression");

                OperatorStck.Pop();

            }
            else if (token == "+" || token == "-")
            {
                while (OperatorStck.Count != 0 && OperatorStck.Peek() != "(" && precedence(token) <= precedence(OperatorStck.Peek()))
                {
                    if (ValueStck.Count < 2)
                        throw new ArgumentException("Invalid Expression");

                    string op = OperatorStck.Pop();
                    int a = ValueStck.Pop();
                    int b = ValueStck.Pop();

                    ValueStck.Push(Operate(op, a, b));
                }
                OperatorStck.Push(token);
            }
            else
            {
                throw new ArgumentException("Invalid Token");
            }

        }

        /// <summary>
        /// Execute the specified operator
        /// </summary>
        /// <param name="op">operator symbol as string</param>
        /// <param name="a"> left hand operand</param>
        /// <param name="b"> right hand operand</param>
        /// <returns> the result of the operation to <param name="a"> and <paramref name="b"/> </returns>
        /// <exception cref="ArgumentException"> when the op is not accepted operator </exception>
        /// 
        static int Operate(string op, int b, int a)
        {
            switch (op)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    if (b == 0)
                        throw new ArgumentException("Invalid Exrpession");
                    return a / b;
                default:
                    throw new ArgumentException("Invalid Exrpession");

            }
        }

        /// <summary>
        /// Evaluate precedence level of given operator
        /// </summary>
        /// <param name="s">operator symbol as string</param>
        /// <returns> a number representing the precedence
        /// 1 -> "+" , "-"
        /// 2 -> "*", "/"
        /// 0 -> default
        ///  </returns>
        /// 
        static int precedence(string s)
        {
            switch (s)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                default:
                    return 0;
            }
        }


        /// <summary>
        /// Determines if the operator is valid or not
        /// </summary>
        /// <param name="s">operator symbol as string</param>
        /// <returns> bool
        /// +, -, *, / => <c>true</c>
        /// otherwise =? <c>false</c>
        ///  </returns>
        static bool isValidOperator(string s)
        {
            return s == "+" || s == "-" || s == "*" || s == "/";
        }

 

    }
    
}
