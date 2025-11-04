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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpreadsheetUtilities;

namespace FormulaTests
{

    
  /// <summary>
  ///This is a test class for Formula and is intended
  ///to contain all Formula Unit Tests
  ///</summary>
    [TestClass]
    public class FormulaUnitTests
    {
                
        /// <summary>
        /// Testing Constructor
        /// </summary>
        [TestMethod]
        public void ConstructorTest()
        {
            var f = new Formula("x1 + 2.5");
            Assert.IsNotNull(f);
        }

        /// <summary>
        /// Testing Invalid Formula
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FormulaFormatException))]
        public void ConstructorInvalidFormula()
        {
            var f = new Formula("2++3");
        }

        /// <summary>
        /// Testing Simple Addition Evaluation
        /// </summary>
        [TestMethod]
        public void EvaluateAdditionTest()
        {
            var f = new Formula("5  + 12.4");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(17.4, result);
        }

        /// <summary>
        /// Testing Simple Subt Evaluation
        /// </summary>
        [TestMethod]
        public void EvaluateSubtractionTest()
        {
            var f = new Formula("5  - 1.4");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(3.6, result);
        }

        /// <summary>
        /// Testing Simple Mult Evaluation
        /// </summary>
        [TestMethod]
        public void EvaluateMultTest()
        {
            var f = new Formula("5 * 4");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(20.0, result);
        }


        /// <summary>
        /// Testing Divide by zero 
        /// </summary>
        [TestMethod]
        public void EvaluateDivisionByZeroTest()
        {
            var f = new Formula("5 / 0");
            var result = f.Evaluate(s => 0);
            Assert.IsInstanceOfType(result, typeof(FormulaError));
        }

        /// <summary>
        /// Testing undifiended case
        /// </summary>
        [TestMethod]
        public void EvaluateUndifinedTest()
        {
            var f = new Formula("x + 3");
            var result = f.Evaluate(s => { throw new ArgumentException(); });
            Assert.IsInstanceOfType(result, typeof(FormulaError));
        }

        /// <summary>
        /// Testing normalize
        /// </summary>
        [TestMethod]
        public void NormalizeTest()
        {
            Func<string, string> normalize = s => s.ToUpper();
            Func<string, bool> validate = s => s.StartsWith("Y");

            var f = new Formula("y1 + 2", normalize, validate);
            var result = f.ToString();
            Assert.IsTrue(result.Contains("Y1"));
        }

        /// <summary>
        /// Testing formula with same expression
        /// </summary>
        [TestMethod]
        public void SameFormulaTest()
        {
            var f1 = new Formula("y + 13");
            var f2 = new Formula("y + 13");
            Assert.AreEqual(f1, f2);
            Assert.IsTrue(f1 == f2);
            Assert.IsFalse(f1 != f2);
        }

        /// <summary>
        /// Testing formula with different expressions
        /// </summary>
        [TestMethod]
        public void DifferentFormulaTest()
        {
            var f1 = new Formula("x + 2");
            var f2 = new Formula("x + 3");
            Assert.AreNotEqual(f1, f2);
            Assert.IsFalse(f1 == f2);
            Assert.IsTrue(f1 != f2);
        }


        /// <summary>
        /// Testing ToString Test
        /// </summary>
        [TestMethod]
        public void ToStringSameResultTest()
        {
            var f1 = new Formula("X + 2");
            var f2 = new Formula("x + 2", s => s.ToUpper(), s => true);
            Assert.AreEqual(f1.ToString(), f2.ToString());
        }

        /// <summary>
        /// Testing Simple Subtraction 
        /// </summary>
        [TestMethod]
        public void EvaluateSimpleSubtractionTest()
        {
            var f = new Formula("2 - 1.5");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(0.5, result);
        }

        /// <summary>
        /// Testing Simple ScientificNotation Test
        /// </summary>
        [TestMethod]
        public void EvaluateScientificTest()
        {
            var f = new Formula("1e3 + 2");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(1002.0, result);
        }

        /// <summary>
        /// Testing Simple ScientificNotation Test
        /// </summary>
        [TestMethod]
        public void EvaluateScientificTest2()
        {
            var f = new Formula("1e3 - 2");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(998.0, result);
        }

        /// <summary>
        /// Testing expression with white space
        /// </summary>
        [TestMethod]
        public void WithWhiteSpaceTest()
        {
            var f = new Formula("   2  +   2   ");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(4.0, result);
        }


        /// <summary>
        /// Testing expression with white space
        /// </summary>
        [TestMethod]
        public void WithWhiteSpaceTest2()
        {
            var f = new Formula("   2  *   2   ");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(4.0, result);
        }

        
        /// <summary>
        /// Testing expression with parentheses
        /// </summary>

        [TestMethod]
        public void ParenthesesTest()
        {
            var f = new Formula("2 * (3 + 4)");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(14.0, result);
        }

        /// <summary>
        /// Testing expression with parentheses
        /// </summary>
        [TestMethod]
        public void ParenthesesTest2()
        {
            Formula expression = new Formula("(x2 + 5) * (3 * 4)");
            Assert.AreEqual(120.0, expression.Evaluate(x23 => 5));
        }

         /// <summary>
        /// Testing expression with parentheses
        /// </summary>
        [TestMethod]
        public void ParenthesesTest3()
        {
            Formula expression = new Formula("(x2 + 5) / (1+  4)");
            Assert.AreEqual(2.0, expression.Evaluate(x23 => 5));
        }



        /// <summary>
        /// Testing expression with parentheses
        /// </summary>
        [TestMethod]
        public void ParenthesesTest4()
        {
            var f = new Formula("((2+3)*(4+1))");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(25.0, result);
        }

        /// <summary>
        /// Testing lookup
        /// </summary>
        [TestMethod]
        public void LookupTest()
        {
            var f = new Formula("x + y + z");
            var vars = new Dictionary<string, double>
            {
                { "x", 1 }, { "y", 2 }, { "z", 3 }
            };
            var result = f.Evaluate(v => vars[v]);
            Assert.AreEqual(6.0, result);
        }

        /// <summary>
        /// Testing expression with zeros
        /// </summary>
        [TestMethod]
        public void NumberWithZeroTest()
        {
            var f = new Formula("007 + 3");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(10.0, result);
        }

        /// <summary>
        /// Testing expression with zeros
        /// </summary>
        [TestMethod]
        public void NumberWithZeroTest2()
        {
            var f = new Formula("009 / 3");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(3.0, result);
        }

        /// <summary>
        /// Testing expression with large number
        /// </summary>
        [TestMethod]
        public void LargeNumberTest()
        {
            var f = new Formula("1000000000 + 1");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(1000000001.0, result);
        }

        /// <summary>
        /// Testing  Tostring
        /// </summary>
        [TestMethod]
        public void ToStringTest()
        {
            var f = new Formula("x+1");
            var str1 = f.ToString();
            var _ = f.Evaluate(s => 2);
            var str2 = f.ToString();
            Assert.AreEqual(str1, str2);
        }

        /// <summary>
        /// Testing null
        /// </summary>
        [TestMethod]
        public void EqualsTest()
        {
            var f = new Formula("1+1");
            Assert.IsFalse(f.Equals(null));
        }

        /// <summary>
        /// Testing simple Evaluations
        /// </summary>
        [TestMethod]
        public void EvaluationTest()
        {
            var f = new Formula("3 + 4 * 2 / (1 - 5)");
            var result = f.Evaluate(s => 0);
            Assert.AreEqual(1.0, result);
        }

        /// <summary>
            /// Testing evaluate method with zero denominator in parentheses
            /// </summary>
            [TestMethod]
        public void DivisionByZeroTest()
        {
            Formula expression = new Formula("( 5 + 3 ) / ( 4 - 4 )");
            object result = expression.Evaluate(null);

            Assert.IsInstanceOfType(result, typeof(FormulaError));
            Assert.AreEqual("Divided by zero", ((FormulaError)result).Reason);
        }

        /// <summary>
        /// Testing evaluate method 
        /// </summary>
        [TestMethod]
        public void EvaluateTest()
        {
            Formula expression = new Formula("3 * y1 + 10 / 2");
            Assert.AreEqual(14.0, expression.Evaluate(x1 => 3));
        }

        /// <summary>
        /// Testing evaluate devision by zero
        /// </summary>
        [TestMethod]
        public void EvaluateDivisionByZeroTest2()
        {
            Formula expression = new Formula("10 / x4");
            object result = expression.Evaluate(x4 => 0);

            Assert.IsInstanceOfType(result, typeof(FormulaError));
            Assert.AreEqual("Divided by zero", ((FormulaError)result).Reason);
        }

        /// <summary>
        /// Testing evaluate method with zero variable in denominator
        /// </summary>
        [TestMethod]
        public void EvaluateMultipleTest()
        {
            Formula expression = new Formula("5 * x1");
            Assert.AreEqual(-10.0, expression.Evaluate(x1 => -2));
        }

 

        /// <summary>
        /// Testing evaluate method with formula for addition block
        /// </summary>
        [TestMethod]
        public void EvaluateTest2()
        {
            Formula expression = new Formula("5 * x1 + 4 + 2");
            Assert.AreEqual(21.0, expression.Evaluate(x1 => 3));
        }


        /// <summary>
        /// Testing valid variable 
        /// </summary>
        [TestMethod]
        public void IsVariableTest()
        {
            Formula expression = new Formula("x23");
            Assert.AreEqual(12.0, expression.Evaluate(x23 => 12));
        }
        
        /// <summary>
        /// Testing evaluate method with formula for dision by zero 
        /// </summary>
        [TestMethod]
        public void EvaluateTest3()
        {
            Formula expression = new Formula("( 8 * 3 / 0 )/1 * 23");
            object result = expression.Evaluate(null);

            Assert.IsInstanceOfType(result, typeof(FormulaError));
            Assert.AreEqual("Divided by zero", ((FormulaError)result).Reason);
        }
    }
}
