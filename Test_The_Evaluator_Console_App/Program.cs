// using FormulaEvaluator;

// namespace Test_The_Evaluator_Console_App
// {
//     internal class Program

//     {
//         static void Main(string[] args)
//         {
//             try
//             {
//                 Evaluator.Evaluate("3/0", null);
//             }
//             catch (ArgumentException ex)
//             {
//                 Console.WriteLine("division by zero");
//             }
//             try
//             {
//                 Evaluator.Evaluate("1+2)", null);
//             }
//             catch (ArgumentException ex)
//             {
//                 Console.WriteLine("mismatched parenthesis");
//             }
//             try
//             {
//                 Evaluator.Evaluate("", null);
//             }
//             catch
//             {
//                 Console.WriteLine("stack is empty");
//             }

//             string expression = "(1+4*2-1/2)";
//             int result = Evaluator.Evaluate(expression, null);
//             if(result == 4)
//             {
//                 Console.WriteLine("passed");
//             }
//             else
//             {
//                 Console.WriteLine("failed");
//             }

//             string expression1 = "1+8";
//             int result1 = Evaluator.Evaluate(expression1, null);
//             if (result1 == 9)
//             {
//                 Console.WriteLine("passed");
//             }
//             else
//             {
//                 Console.WriteLine("failed");
//             }

//             string expression2 = "(1+3*2)-2";
//             int result2 = Evaluator.Evaluate(expression2, null);
//             if (result2 == 5)
//             {
//                 Console.WriteLine("passed");
//             }
//             else
//             {
//                 Console.WriteLine("failed");
//             }

//             string expression3 = "2*4/2";
//             int result3 = Evaluator.Evaluate(expression3, null);
//             if (result3 == 2)
//             {
//                 Console.WriteLine("passed");
//             }
//             else
//             {
//                 Console.WriteLine("failed");
//             }

//             string expression4 = "5/5+2";
//             int result4 = Evaluator.Evaluate(expression4, null);
//             if (result4 == 3)
//             {
//                 Console.WriteLine("passed");
//             }
//             else
//             {
//                 Console.WriteLine("failed");
//             }

               
//         }


      
//     }
// }