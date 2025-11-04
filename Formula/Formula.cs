// Skeleton written by Joe Zachary for CS 3500, September 2013
// Read the entire skeleton carefully and completely before you
// do anything else!

// Version 1.1 (9/22/13 11:45 a.m.)

// Change log:
//  (Version 1.1) Repaired mistake in GetTokens
//  (Version 1.1) Changed specification of second constructor to
//                clarify description of how validation works

// (Daniel Kopta) 
// Version 1.2 (9/10/17) 

// Change log:
//  (Version 1.2) Changed the definition of equality with regards
//                to numeric tokens

/// <summary>
/// /// Author:    Katherine Jang
/// Partner:   None 
/// Date:      30/9/2025
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

/// </summary>

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace SpreadsheetUtilities
{
  /// <summary>
  /// Represents formulas written in standard infix notation using standard precedence
  /// rules.  The allowed symbols are non-negative numbers written using double-precision 
  /// floating-point syntax (without unary preceeding '-' or '+'); 
  /// variables that consist of a letter or underscore followed by 
  /// zero or more letters, underscores, or digits; parentheses; and the four operator 
  /// symbols +, -, *, and /.  
  /// 
  /// Spaces are significant only insofar that they delimit tokens.  For example, "xy" is
  /// a single variable, "x y" consists of two variables "x" and y; "x23" is a single variable; 
  /// and "x 23" consists of a variable "x" and a number "23".
  /// 
  /// Associated with every formula are two delegates:  a normalizer and a validator.  The
  /// normalizer is used to convert variables into a canonical form, and the validator is used
  /// to add extra restrictions on the validity of a variable (beyond the standard requirement 
  /// that it consist of a letter or underscore followed by zero or more letters, underscores,
  /// or digits.)  Their use is described in detail in the constructor and method comments.
  /// </summary>
  public class Formula
  {
    // stores tokens of the given formula
    private IEnumerable<string> formulaTokens = new List<string>();

    /// <summary>
    /// Creates a Formula from a string that consists of an infix expression written as
    /// described in the class comment.  If the expression is syntactically invalid,
    /// throws a FormulaFormatException with an explanatory Message.
    /// 
    /// The associated normalizer is the identity function, and the associated validator
    /// maps every string to true.  
    /// </summary>
    public Formula(String formula) :
        this(formula, s => s, s => true)
    {
      // formulaTokens = GetTokens(formula);
    }

    /// <summary>
    /// Creates a Formula from a string that consists of an infix expression written as
    /// described in the class comment.  If the expression is syntactically incorrect,
    /// throws a FormulaFormatException with an explanatory Message.
    /// 
    /// The associated normalizer and validator are the second and third parameters,
    /// respectively.  
    /// 
    /// If the formula contains a variable v such that normalize(v) is not a legal variable, 
    /// throws a FormulaFormatException with an explanatory message. 
    /// 
    /// If the formula contains a variable v such that isValid(normalize(v)) is false,
    /// throws a FormulaFormatException with an explanatory message.
    /// 
    /// Suppose that N is a method that converts all the letters in a string to upper case, and
    /// that V is a method that returns true only if a string consists of one letter followed
    /// by one digit.  Then:
    /// 
    /// new Formula("x2+y3", N, V) should succeed
    /// new Formula("x+y3", N, V) should throw an exception, since V(N("x")) is false
    /// new Formula("2x+y3", N, V) should throw an exception, since "2x+y3" is syntactically incorrect.
    /// </summary>
    public Formula(String formula, Func<string, string> normalize, Func<string, bool> isValid)
    {
      HashSet<string> operators = new HashSet<string> { "-", "+", "*", "/", "(", ")" };
      List<string> parsedToken = new List<string>();

      if (string.IsNullOrEmpty(formula))
        throw new FormulaFormatException("Formula can't be null or empty");

      formulaTokens = GetTokens(formula);

      if (!IsValidStartingToken(formulaTokens.First()))
        throw new FormulaFormatException($"[FirstToken = {formulaTokens.First()}] \nThe first token of an expression must be a number, a variable, or an opening parenthesis.");
      if (!IsValidEndingToken(formulaTokens.Last()))
        throw new FormulaFormatException($"[LastToken = {formulaTokens.Last()}] \nThe last token of an expression must be a number, a variable, or a closing parenthesis.");


      string prevToken = String.Empty;
      int parenthesesCount = 0;

      foreach (string token in formulaTokens)
      {
        if (!IsValidToken(token))
          throw new FormulaFormatException($"Invalid Token: {token}");

        string processedToken = token;
        if (IsVariable(token))
        {
          processedToken = normalize(token);

          if (!IsVariable(processedToken))
            throw new FormulaFormatException($"Normalized variable '{processedToken}' is not a valid variable.");

          if (!isValid(processedToken))
            throw new FormulaFormatException($"Variable '{processedToken}' failed validation.");
        }


        if (prevToken == String.Empty)
        {
          parsedToken.Add(normalize(token));
          prevToken = token;
          if (token == "(")
            parenthesesCount++;
          continue;
        }

        if (prevToken == "(" || IsValidOperator(prevToken))
        {
          if (!double.TryParse(token, out double n) && !IsVariable(token) && token != "(")
            throw new FormulaFormatException($"[prevToken = {prevToken}, Token = {token}] \nAny token that immediately follows an opening parenthesis or an operator must be either a number, a variable, or an opening parenthesis.");
          if (token == "(")
            parenthesesCount++;
          parsedToken.Add(normalize(token));
        }

        else if (prevToken == ")" || IsVariable(prevToken) || double.TryParse(prevToken, out double num))
        {
          if (!IsValidOperator(token) && token != ")")
            throw new FormulaFormatException($"[prevToken = {prevToken}, Token = {token}] \nAny token that immediately follows a number, a variable, or a closing parenthesis must be either an operator or a closing parenthesis.");
          if (token == ")")
            parenthesesCount--;
          parsedToken.Add(normalize(token));
        }
        prevToken = token;

        if (parenthesesCount < 0)
          throw new FormulaFormatException($"[parenthesesCount = {parenthesesCount}] \n The total number of opening parentheses must equal the total number of closing parentheses.");

      }

      if (parenthesesCount != 0)
        throw new FormulaFormatException($"[parenthesesCount = {parenthesesCount}] \n The total number of opening parentheses must equal the total number of closing parentheses.");

      formulaTokens = parsedToken;

    }

    /// <summary>
    /// determine if the given token statisfy the starting token rule 
    /// </summary>
    private bool IsValidStartingToken(string token)
    {
      if (IsVariable(token) || double.TryParse(token, out double num) || (token == "("))
        return true;
      return false;
    }
    /// <summary>
    /// determine if the given token statisfy the ending token rule 
    /// </summary>
    private bool IsValidEndingToken(string token)
    {
      if (IsVariable(token) || double.TryParse(token, out double num) || (token == ")"))
        return true;
      return false;
    }

    /// <summary>
    /// determine if the given token is valid 
    /// </summary>
    public bool IsValidToken(string token)
    {
      if (IsVariable(token) || double.TryParse(token, out double num) || "+-*/()".Contains(token))
        return true;
      return false;
    }

    /// <summary>
    /// Determines if the operator is valid or not
    /// </summary>
    /// <param name="s">operator symbol as string</param>
    /// <returns> bool
    /// +, -, *, / => <c>true</c>
    /// otherwise =? <c>false</c>
    ///  </returns>
    private bool IsValidOperator(string s)
    {
      return s == "+" || s == "-" || s == "*" || s == "/";
    }

    /// <summary>
    /// determine whether a given string(s) is acceptable variable.
    /// </summary>
    public static bool IsVariable(string s)
    {
      // if (char.IsLetter(s[0]))
      // {
      //   for (int i = 1; i < s.Length; i++)
      //   {
      //     if (!char.IsDigit(s[i]))
      //       return false;
      //   }
      //   return true;
      // }
      // return false;
      if (string.IsNullOrEmpty(s)) return false;
      if (!char.IsLetter(s[0]) && s[0] != '_') return false;

      for (int i = 1; i < s.Length; i++)
      {
        if (!char.IsLetterOrDigit(s[i]) && s[i] != '_')
          return false;
      }
      return true;
  
    }

    /// <summary>
    /// Evaluates this Formula, using the lookup delegate to determine the values of
    /// variables.  When a variable symbol v needs to be determined, it should be looked up
    /// via lookup(normalize(v)). (Here, normalize is the normalizer that was passed to 
    /// the constructor.)
    /// 
    /// For example, if L("x") is 2, L("X") is 4, and N is a method that converts all the letters 
    /// in a string to upper case:
    /// 
    /// new Formula("x+7", N, s => true).Evaluate(L) is 11
    /// new Formula("x+7").Evaluate(L) is 9
    /// 
    /// Given a variable symbol as its parameter, lookup returns the variable's value 
    /// (if it has one) or throws an ArgumentException (otherwise).
    /// 
    /// If no undefined variables or divisions by zero are encountered when evaluating 
    /// this Formula, the value is returned.  Otherwise, a FormulaError is returned.  
    /// The Reason property of the FormulaError should have a meaningful explanation.
    ///
    /// This method should never throw an exception.
    /// </summary>
    public object Evaluate(Func<string, double> lookup)
    {
      Stack<string> OperatorStck = new Stack<string>();
      Stack<double> ValueStck = new Stack<double>();

      foreach (string token in formulaTokens)
      {
        if ((token == "(") || (token == "*") || (token == "/"))
        {
          OperatorStck.Push(token);
        }
        else if (token == "+" || token == "-")
        {
          while (OperatorStck.Count != 0 && OperatorStck.Peek() != "(" && precedence(token) <= precedence(OperatorStck.Peek()))
          {
            if (ValueStck.Count < 2)
              return new FormulaError("Invalid Formula");

            string op = OperatorStck.Pop();
            double a = ValueStck.Pop();
            double b = ValueStck.Pop();

            if(op == "/" && a == 0.0)
              return new FormulaError("Divided by zero");

            ValueStck.Push(Operate(op, b, a));
          }
          OperatorStck.Push(token);
        }
        else if (token == ")")
        {
          while (OperatorStck.Count > 0 && OperatorStck.Peek() != "(")
          {
            if (ValueStck.Count < 2)
              return new FormulaError("Invalid Formula");

            double a = ValueStck.Pop();
            double b = ValueStck.Pop();
            string op = OperatorStck.Pop();

            if(op == "/" && a == 0.0)
              return new FormulaError("Divided by zero");

            ValueStck.Push(Operate(op, b, a));
          }
          if (OperatorStck.Count == 0 || OperatorStck.Peek() != "(")
            return new FormulaError("Invalid Formula");

          OperatorStck.Pop();

        }
        else if (double.TryParse(token, out double num))
        {
          if (OperatorStck.Count > 0 && (OperatorStck.Peek() == "*" || OperatorStck.Peek() == "/"))
          {
            string op = OperatorStck.Pop();
            double a = ValueStck.Pop();

            if (num == 0.0 && op == "/")
              return new FormulaError("Divided by zero");
            ValueStck.Push(Operate(op, a, num));
          }
          else
          {
            ValueStck.Push(num);
          }

        }
        else
        {
          double variable;
          try
          {
            variable = lookup(token);
          }
          catch (Exception)
          {
            return new FormulaError("Variable Convertion Unavailble.");
          }
          if (OperatorStck.Count > 0 && (OperatorStck.Peek() == "*" || OperatorStck.Peek() == "/"))
          {
            string op = OperatorStck.Pop();
            double a = ValueStck.Pop();

            if (variable == 0.0 && op == "/")
              return new FormulaError("Divided by zero");
            ValueStck.Push(Operate(op, a, variable));
          }
          else
          {
            ValueStck.Push(variable);
          }
        }
      }

      while (OperatorStck.Count != 0 && IsValidOperator(OperatorStck.Peek()))
      {
        if (ValueStck.Count < 2)
          return new FormulaError("Invalid Expression");

        double a = ValueStck.Pop();
        double b = ValueStck.Pop();
        string op = OperatorStck.Pop();

        if (a == 0.0 && op == "/")
            return new FormulaError("Divided by zero");
            
        ValueStck.Push(Operate(op, b, a));
      }
      if (ValueStck.Count == 1 && OperatorStck.Count == 0)
      {
        return ValueStck.Pop();
      }
      else
      {
        return new FormulaError("Invalid Expression");
      }      
    }

    /// <summary>
    /// Enumerates the normalized versions of all of the variables that occur in this 
    /// formula.  No normalization may appear more than once in the enumeration, even 
    /// if it appears more than once in this Formula.
    /// 
    /// For example, if N is a method that converts all the letters in a string to upper case:
    /// 
    /// new Formula("x+y*z", N, s => true).GetVariables() should enumerate "X", "Y", and "Z"
    /// new Formula("x+X*z", N, s => true).GetVariables() should enumerate "X" and "Z".
    /// new Formula("x+X*z").GetVariables() should enumerate "x", "X", and "z".
    /// </summary>
    public IEnumerable<String> GetVariables()
    {
      HashSet<string> variables = new HashSet<string>();

      foreach (string token in formulaTokens)
      {
        if (IsVariable(token))
          variables.Add(token);
      }
      return variables;
    }

    /// <summary>
    /// Returns a string containing no spaces which, if passed to the Formula
    /// constructor, will produce a Formula f such that this.Equals(f).  All of the
    /// variables in the string should be normalized.
    /// 
    /// For example, if N is a method that converts all the letters in a string to upper case:
    /// 
    /// new Formula("x + y", N, s => true).ToString() should return "X+Y"
    /// new Formula("x + Y").ToString() should return "x+Y"
    /// </summary>
    public override string ToString()
    {
      string str = String.Empty;

      foreach (string token in formulaTokens)
        str += token;

      return str;
    }

    /// <summary>
    ///  <change> make object nullable </change>
    ///
    /// If obj is null or obj is not a Formula, returns false.  Otherwise, reports
    /// whether or not this Formula and obj are equal.
    /// 
    /// Two Formulae are considered equal if they consist of the same tokens in the
    /// same order.  To determine token equality, all tokens are compared as strings 
    /// except for numeric tokens and variable tokens.
    /// Numeric tokens are considered equal if they are equal after being "normalized" 
    /// by C#'s standard conversion from string to double, then back to string. This 
    /// eliminates any inconsistencies due to limited floating point precision.
    /// Variable tokens are considered equal if their normalized forms are equal, as 
    /// defined by the provided normalizer.
    /// 
    /// For example, if N is a method that converts all the letters in a string to upper case:
    ///  
    /// new Formula("x1+y2", N, s => true).Equals(new Formula("X1  +  Y2")) is true
    /// new Formula("x1+y2").Equals(new Formula("X1+Y2")) is false
    /// new Formula("x1+y2").Equals(new Formula("y2+x1")) is false
    /// new Formula("2.0 + x7").Equals(new Formula("2.000 + x7")) is true
    /// </summary>
    public override bool Equals(object? obj)
    {
      if (obj == null || obj.GetType() != typeof(Formula))
        return false;

      Formula diffObj = (Formula)obj;
      string[] diffTokens = diffObj.formulaTokens.ToArray();
      string[] tokensArr = formulaTokens.ToArray();

      if (diffObj.formulaTokens.Count() != formulaTokens.Count())
        return false;

      for (int i = 0; i < formulaTokens.Count(); i++)
      {
        if (double.TryParse(diffTokens[i], out double num) && double.TryParse(tokensArr[i], out double num2))
        {
          if (num != num2)
            return false;
        }
        else
        {
          if (diffTokens[i] != tokensArr[i])
            return false;
        }
      }

      return true;
    }

    /// <summary>
    ///   <change> We are now using Non-Nullable objects.  Thus neither f1 nor f2 can be null!</change>
    /// Reports whether f1 == f2, using the notion of equality from the Equals method.
    /// 
    /// </summary>
    public static bool operator ==(Formula f1, Formula f2)
    {
      return f1.Equals(f2);
    }

    /// <summary>
    ///   <change> We are now using Non-Nullable objects.  Thus neither f1 nor f2 can be null!</change>
    ///   <change> Note: != should almost always be not ==, if you get my meaning </change>
    ///   Reports whether f1 != f2, using the notion of equality from the Equals method.
    /// </summary>
    public static bool operator !=(Formula f1, Formula f2)
    {
      return (!f1.Equals(f2));
    }

    /// <summary>
    /// Returns a hash code for this Formula.  If f1.Equals(f2), then it must be the
    /// case that f1.GetHashCode() == f2.GetHashCode().  Ideally, the probability that two 
    /// randomly-generated unequal Formulae have the same hash code should be extremely small.
    /// </summary>
    public override int GetHashCode()
    {
      int hash = 17;
      foreach (string token in formulaTokens)
      {
        if (double.TryParse(token, out double num))
        {
          hash = hash * 31 + num.GetHashCode();
        }
        else
        {
          hash = hash * 31 + token.GetHashCode();
        }
      }
      return hash;
    }


    /// <summary>
    /// Given an expression, enumerates the tokens that compose it.  Tokens are left paren;
    /// right paren; one of the four operator symbols; a string consisting of a letter or underscore
    /// followed by zero or more letters, digits, or underscores; a double literal; and anything that doesn't
    /// match one of those patterns.  There are no empty tokens, and no token contains white space.
    /// </summary>
    private static IEnumerable<string> GetTokens(String formula)
    {
      // Patterns for individual tokens
      String lpPattern = @"\(";
      String rpPattern = @"\)";
      String opPattern = @"[\+\-*/]";
      String varPattern = @"[a-zA-Z_](?: [a-zA-Z_]|\d)*";
      String doublePattern = @"(?: \d+\.\d* | \d*\.\d+ | \d+ ) (?: [eE][\+-]?\d+)?";
      String spacePattern = @"\s+";

      // Overall pattern
      String pattern = String.Format("({0}) | ({1}) | ({2}) | ({3}) | ({4}) | ({5})",
                                      lpPattern, rpPattern, opPattern, varPattern, doublePattern, spacePattern);

      // Enumerate matching tokens that don't consist solely of white space.
      foreach (String s in Regex.Split(formula, pattern, RegexOptions.IgnorePatternWhitespace))
      {
        if (!Regex.IsMatch(s, @"^\s*$", RegexOptions.Singleline))
        {
          yield return s;
        }
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
    static double Operate(string op, double a, double b)
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
          return a / b;
        default:
          return 0;
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
        
  }

  /// <summary>
  /// Used to report syntactic errors in the argument to the Formula constructor.
  /// </summary>
  public class FormulaFormatException : Exception
  {
    /// <summary>
    /// Constructs a FormulaFormatException containing the explanatory message.
    /// </summary>
    public FormulaFormatException(String message)
        : base(message)
    {
    }
  }

  /// <summary>
  /// Used as a possible return value of the Formula.Evaluate method.
  /// </summary>
  public struct FormulaError
  {
    /// <summary>
    /// Constructs a FormulaError containing the explanatory reason.
    /// </summary>
    /// <param name="reason"></param>
    public FormulaError(String reason)
        : this()
    {
      Reason = reason;
    }

    /// <summary>
    ///  The reason why this FormulaError was created.
    /// </summary>
    public string Reason { get; private set; }
      

  }

  
}


// <change>
//   If you are using Extension methods to deal with common stack operations (e.g., checking for
//   an empty stack before peeking) you will find that the Non-Nullable checking is "biting" you.
//
//   To fix this, you have to use a little special syntax like the following:
//
//       public static bool OnTop<T>(this Stack<T> stack, T element1, T element2) where T : notnull
//
//   Notice that the "where T : notnull" tells the compiler that the Stack can contain any object
//   as long as it doesn't allow nulls!
// </change>
