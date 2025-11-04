/// <summary>
/// /// Author:    Katherine Jang
/// Partner:   None 
/// Date:      26/10/2025
/// Course:    CS 3500, University of Utah, School of Computing 
/// Copyright: CS 3500 and Katherine Jang - This work may not be copied for use in Academic Coursework. 
/// 
/// I, Katherine Jang , certify that I wrote this code from scratch and did not copy it in part or whole from
/// another source.  All references used in the completion of the assignment are cited in my README file. 
/// 
/// 
/// SpreadsheetTests has purpose of testing Spreadsheet class by using MS UnitTesting.
/// 
/// 

/// </summary>

using SS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using SpreadsheetUtilities;
using System.Diagnostics.CodeAnalysis;


// namespace SpreadsheetTests
// {

// /// <summary>
// /// class for testing spreadsheet 
// /// </summary>
//     [TestClass]
//     public class SpreadsheetTests
//     {
//         /// <summary>
//         /// Constructor Test
//         /// </summary>
//         [TestMethod]
//         public void ConstructorTest()
//         {
//             Spreadsheet spreadsheet = new Spreadsheet();
//             int num = spreadsheet.GetNamesOfAllNonemptyCells().Count();

//             Assert.AreEqual(0, num);
//             Assert.IsFalse(spreadsheet.Changed);
//         }

//         ///<summary>
//         /// Constructor Test
//         /// </summary>
//         [TestMethod]
//         public void ConstructorTest_Param()
//         {
//             Spreadsheet spreadsheet = new Spreadsheet(s => true, s => s.ToUpper(), "v1.0");

//             Assert.AreEqual("v1.0", spreadsheet.Version);
//             Assert.IsFalse(spreadsheet.Changed);
//         }

//         ///<summary>
//         /// Constructor Test
//         /// </summary>
//         [TestMethod]
//         public void ConstructorTest_Normalizer()
//         {
//             Spreadsheet spreadsheet = new Spreadsheet(s => true, s => s.ToUpper(), "v1.0");
//             spreadsheet.SetContentsOfCell("a1", "5");

//             Assert.IsTrue(spreadsheet.GetNamesOfAllNonemptyCells().Contains("A1"));
//             Assert.AreEqual(5.0, spreadsheet.GetCellValue("a1"));
//         }

//         ///<summary>
//         /// Constructor Test
//         /// </summary>
//         [TestMethod]
//         [ExpectedException(typeof(InvalidNameException))]
//         public void ConstructorTest_Valid()
//         {
//             Spreadsheet spreadsheet = new Spreadsheet(s => s.StartsWith("A"), s => s, "v1.0");
//             spreadsheet.SetContentsOfCell("C2", "51");
//         }

//         /// <summary>
//         /// GetNamesOfAllNoneEMptyCells Test with empty sheets
//         /// </summary>
//         [TestMethod]
//         public void GetNamesOfAllNoneEMptyCellsTest_EmptySheet()
//         {
//             Spreadsheet s = new Spreadsheet();
//             int num = s.GetNamesOfAllNonemptyCells().Count();

//             Assert.AreEqual(0, num);
//         }

        
//         /// <summary>
//         /// SetContettsOfCellTest with Double
//         /// </summary>
//         [TestMethod]
//         public void SetContettsOfCellTest_Double()
//         {
//             Spreadsheet s = new Spreadsheet();
//             var result = s.SetContentsOfCell("A2", "42.42");

//             Assert.AreEqual(42.42, s.GetCellContents("A2"));
//             Assert.AreEqual(42.42, s.GetCellValue("A2"));
//             Assert.IsTrue(s.Changed);
//         }

//         /// <summary>
//         /// SetContettsOfCellTest with Double
//         /// </summary>
//         [TestMethod]
//         public void SetContettsOfCellTest_Double_Negative()
//         {
//             Spreadsheet s = new Spreadsheet();
//             var result = s.SetContentsOfCell("A2", "-42.42");

//             Assert.AreEqual(-42.42, s.GetCellContents("A2"));
//             Assert.AreEqual(-42.42, s.GetCellValue("A2"));
//             Assert.IsTrue(s.Changed);
//         }

//         /// <summary>
//         /// SetContettsOfCellTest with String
//         /// </summary>
//         [TestMethod]
//         public void SetContettsOfCellTest_String()
//         {
//             Spreadsheet s = new Spreadsheet();
//             var result = s.SetContentsOfCell("C1", "Hello World");

//             Assert.AreEqual("Hello World", s.GetCellContents("C1"));
//             Assert.AreEqual("Hello World", s.GetCellValue("C1"));
//             Assert.IsTrue(result.Contains("C1"));
//         }

//         /// <summary>
//         /// SetContettsOfCellTest with String - Empty
//         /// </summary>
//         [TestMethod]
//         public void SetContettsOfCellTest_String_Empty()
//         {
//             Spreadsheet s = new Spreadsheet();
//             var result = s.SetContentsOfCell("C1", "Hello");
//             s.SetContentsOfCell("C1", "");

//             Assert.AreEqual("", s.GetCellContents("C1"));
//             Assert.AreEqual(0, s.GetNamesOfAllNonemptyCells().Count());
//         }

//         /// <summary>
//         /// SetContettsOfCellTest with Formula
//         /// </summary>
//         [TestMethod]
//         public void SetContettsOfCellTest_Formula()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("X1", "123");
//             s.SetContentsOfCell("Y1", "321");
//             s.SetContentsOfCell("Z1", "=X1+Y1");

//             Assert.AreEqual(444.0, s.GetCellValue("Z1"));
//             Assert.IsTrue(s.GetCellContents("Z1") is Formula);
//         }

//         /// <summary>
//         /// SetContettsOfCellTest with Formula
//         /// </summary>
//         [TestMethod]
//         public void SetContettsOfCellTest_Formula2()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("X1", "44.4");
//             s.SetContentsOfCell("Y1", "-11.1");
//             s.SetContentsOfCell("Z1", "= X1 + Y1 * 2");

//             Assert.AreEqual(22.2, s.GetCellValue("Z1"));
//             Assert.IsTrue(s.GetCellContents("Z1") is Formula);
//         }

//         /// <summary>
//         /// SetContettsOfCellTest with formula replacing
//         /// </summary>
//         [TestMethod]
//         public void ReplaceFormulaTest()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "44.4");
//             s.SetContentsOfCell("Y1", "=A1 + 10.1");
//             s.SetContentsOfCell("Y1", "123.1");

//             Assert.AreEqual(123.1, s.GetCellContents("Y1"));
//             Assert.IsFalse(s.GetCellContents("Y1") is Formula);
//         }

        
//         /// <summary>
//         /// GetCellValue - Empty
//         /// </summary>
//         [TestMethod]
//         public void GetCellValueTest()
//         {
//             Spreadsheet s = new Spreadsheet();
//             Assert.AreEqual("", s.GetCellValue("A1"));
//         }



//         /// <summary>
//         /// GetCellValue - Double
//         /// </summary>
//         [TestMethod]
//         public void GetCellValueTest_Double()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "123.1");
//             Assert.AreEqual(123.1, s.GetCellValue("A1"));
//         }


//         /// <summary>
//         /// GetCellValue - String
//         /// </summary>
//         [TestMethod]
//         public void GetCellValueTest_String()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "Test");
//             Assert.AreEqual("Test", s.GetCellValue("A1"));
//         }
        
        
//     /// <summary>
//         /// GetCellValue - Formula
//         /// </summary>
//         [TestMethod]
//         public void GetCellValueTest_Formula()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "10.0");
//             s.SetContentsOfCell("F1", "=A1 * 10");
//             Assert.AreEqual(100.0, s.GetCellValue("F1"));
//         }

//         ///<summary>
//         /// GetCellValue - Invalid
//         /// </summary>
//         [TestMethod]
//         [ExpectedException(typeof(InvalidNameException))]
//         public void GetCellValueTest_Invalid()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.GetCellValue("1234");
//         }
   
//          /// <summary>
//         /// Changed property test
//         /// </summary>
//         [TestMethod]
//         public void Changed_Test1()
//         {
//             Spreadsheet s = new Spreadsheet();
//             Assert.IsFalse(s.Changed);
//         }


//         /// <summary>
//         /// Changed property test
//         /// </summary>
//         [TestMethod]
//         public void Changed_Test2()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "123");
//             Assert.IsTrue(s.Changed);
//         }

//         /// <summary>
//         /// Changed property test
//         /// </summary>
//         [TestMethod]
//         public void Changed_Test3()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "123");
//             Assert.IsTrue(s.Changed);
//         }

//         /// <summary>
//         /// Changed property test
//         /// </summary>
//         [TestMethod]
//         public void Changed_Test4()
//         {
//             string filename = "changed_test4.xml";
//             try
//             {
//                 Spreadsheet s = new Spreadsheet();
//                 s.SetContentsOfCell("A1", "123");
//                 Assert.IsTrue(s.Changed);

//                 s.Save(filename);
//                 Assert.IsFalse(s.Changed);
//             }
//             catch (Exception e)
//             {
//                 if (File.Exists(filename))
//                     File.Delete(filename);
//             }
//         }


//         /// <summary>
//         /// Save Test
//         /// </summary>
//         [TestMethod]
//         public void Save_Test()
//         {
//             string filename = "save_test.xml";
//             try
//             {
//                 Spreadsheet s = new Spreadsheet();
//                 s.SetContentsOfCell("A1", "10.0");
//                 s.SetContentsOfCell("F1", "=A1 * 10");

//                 s.Save(filename);
//                 Assert.IsTrue(File.Exists(filename));
//             }
//             catch (Exception e)
//             {
//                 if (File.Exists(filename))
//                     File.Delete(filename);
//             }
//         }
        
//         /// <summary>
//         /// Save Test
//         /// </summary>
//         [TestMethod]
//         public void Save_Test2()
//         {
//             string filename = "save_test.xml";
//             try
//             {
//                 Spreadsheet s = new Spreadsheet();
//                 s.SetContentsOfCell("A1", "10.0");
//                 s.SetContentsOfCell("F1", "=A1 * 10");
//                 s.Save(filename);

//                 Spreadsheet s2 = new Spreadsheet(filename, s => true, s => s, "default");

//                 Assert.AreEqual(10.0, s2.GetCellValue("A1"));
//                  Assert.AreEqual(100.0, s2.GetCellValue("F1"));

//             }
//             catch (Exception e)
//             {
//                 if (File.Exists(filename))
//                     File.Delete(filename);
//             }
//         }


//         /// <summary>
//         /// Invalid File Test
//         /// </summary>
//         [TestMethod]
//         [ExpectedException(typeof(SpreadsheetReadWriteException))]
//         public void SaveTest_Invalid()
//         {
//             string filename = "save_test.xml";
//             try
//             {
//                 Spreadsheet s = new Spreadsheet(s => true, s => s, "v1.0");
//                 s.SetContentsOfCell("A1", "10.0");
//                 s.SetContentsOfCell("F1", "=A1 * 10");
//                 s.Save(filename);

//                 Spreadsheet s2 = new Spreadsheet(filename, s => true, s => s, "version10");


//             }
//          finally
//             {
//                 if (File.Exists(filename))
//                     File.Delete(filename);
//             }
//         }
        

//         /// <summary>
//         /// Invalid File Test
//         /// </summary>
//         [TestMethod]
//         [ExpectedException(typeof(SpreadsheetReadWriteException))]
//         public void SaveTest_EmptyFile()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.GetSavedVersion("");
//         }




//         /// <summary>
//         /// GetNamesOfAllNoneEMptyCells Test with empty sheets
//         /// </summary>
//         [TestMethod]
//         public void GetNamesOfAllNoneEMptyCellsTest_EmptyString()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "");
//             s.SetContentsOfCell("A2", "");
//             int num = s.GetNamesOfAllNonemptyCells().Count();

//             Assert.AreEqual(0, num);
//         }

//         /// <summary>
//         /// GetNamesOfAllNoneEMptyCells Test with empty strings
//         /// </summary>
//         [TestMethod]
//         public void GetNamesOfAllNoneEMptyCellsTest_doubleParam()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "12.3");
//             s.SetContentsOfCell("A2", "2.4");
//             int num = s.GetNamesOfAllNonemptyCells().Count();

//             Assert.AreEqual(2, num);
//         }

//         /// <summary>
//         /// GetNamesOfAllNoneEMptyCells Test with doubles
//         /// </summary>
//         [TestMethod]
//         public void GetNamesOfAllNoneEMptyCellsTest_doubleParam2()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("B1", "1.2");
//             s.SetContentsOfCell("A1", "3.4");

//             var cellNames = s.GetNamesOfAllNonemptyCells();
//             Assert.IsTrue(cellNames.Contains("A1"));
//         }

//         /// <summary>
//         /// GetNamesOfAllNoneEMptyCells Test with strings
//         /// </summary>
//         [TestMethod]
//         public void GetNamesOfAllNoneEMptyCellsTest_stringParam()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("B1", "Test");
//             s.SetContentsOfCell("A1", "Spreadsheet");

//             var cellNames = s.GetNamesOfAllNonemptyCells();
//             Assert.IsTrue(cellNames.Contains("B1"));
//         }

//         /// <summary>
//         /// GetNamesOfAllNoneEMptyCells Test with formulas
//         /// </summary>
//         [TestMethod]
//         public void GetNamesOfAllNoneEMptyCellsTest_formulaParam()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("C1","=1 + 2");
//             s.SetContentsOfCell("D1", "=2 * 34 + 1");

//             var cellNames = s.GetNamesOfAllNonemptyCells();
//             Assert.IsTrue(cellNames.Contains("C1"));
//         }

//         /// <summary>
//         /// GetCellContents Test with empty cell
//         /// </summary>
//         [TestMethod]
//         public void GetCellContentsTest_EmptyCell()
//         {
//             Spreadsheet s = new Spreadsheet();

//             Assert.AreEqual(s.GetCellContents("A1"), "");
//         }

//         /// <summary>
//         //// GetCellContents Test with double
//         /// </summary>
//         [TestMethod]
//         public void GetCellContentsTest_Double()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "42.4");
//             var value = s.GetCellContents("A1");

//             Assert.IsTrue(value is double d);
//         }

//         /// <summary>
//         /// GetCellContents Test with stringl
//         /// </summary>
//         [TestMethod]
//         public void GetCellContentsTest_String()
//         {
//             Spreadsheet s = new Spreadsheet();

//             s.SetContentsOfCell("A1", "CS3500");
//             var content = s.GetCellContents("A1");

//             Assert.AreEqual(content, "CS3500");
//         }


//         /// <summary>
//         /// GetCellContents Test with formula
//         /// </summary>
//         [TestMethod]
//         public void GetCellContentsTest_Formula()
//         {
//             Spreadsheet s = new Spreadsheet();

//             s.SetContentsOfCell("A1", "=3.4 + (5 * 2)");
//             var value = s.GetCellValue("A1");

//             Assert.AreEqual(value,13.4);
//         }

//         /// <summary>
//         /// SetCellContent Test with _Double
//         /// </summary>
//         [TestMethod]
//         public void SetContentsOfCellTest_double()
//         {
//             Spreadsheet s = new Spreadsheet();
//             var retValue = s.SetContentsOfCell("X2", "1234.1234");
//             var content = s.GetCellContents("X2");

//             Assert.AreEqual((double)s.GetCellValue("X2"), 1234.1234);
//         }



//         /// <summary>
//         /// SetCellContent Test with _Double
//         /// </summary>
//         [TestMethod]
//         public void SetContentsOfCellTest_double2()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("X2", "1234.1234");
//             s.SetContentsOfCell("X2", "123.123");
//             var content = s.GetCellValue("X2");

//             Assert.AreEqual(123.123, content);
//         }

//         /// <summary>
//         /// MultipleFormula_Teset
//         /// </summary>
//         [TestMethod]
//         public void MultipleFormula_Teset()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "20");
//             s.SetContentsOfCell("B1", "10");
//             s.SetContentsOfCell("H1", "10");
//             s.SetContentsOfCell("R3", "=A1+B1 * H1");

//             Assert.AreEqual(120.0, s.GetCellValue("R3"));
//         }


//         /// <summary>
//         /// Test Multiple formula with normalizing
//         /// </summary>
//         [TestMethod]
//         public void Normalizing_Multiple_Formula_Test()
//         {
//             Spreadsheet s = new Spreadsheet(s=>true, s=>s.ToUpper(), "V1");
//             s.SetContentsOfCell("a1", "20");
//             s.SetContentsOfCell("b1", "10");
//             s.SetContentsOfCell("h1", "10");
//             s.SetContentsOfCell("r3", "=a1+b1 * h1");

//             Assert.AreEqual(120.0, (double)s.GetCellValue("r3"));
//             Assert.AreEqual(120.0, (double)s.GetCellValue("R3"));
//         }


//         /// <summary>
//         /// Test Circular Exception
//         /// </summary>
//         [TestMethod]
//         [ExpectedException(typeof(CircularException))]
//         public void CircularException_Test()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "20");
//             s.SetContentsOfCell("B1", "=A1 + 10");

//              s.SetContentsOfCell("A1", "=B1");
//         }



//         /// <summary>
//         /// Test Argument Null
//         /// </summary>
//         [TestMethod]
//         [ExpectedException(typeof(ArgumentNullException))]
//         public void InvalidArgument_Test()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", null);
//         }


//         /// <summary>
//         /// Test Invalid Argument
//         /// </summary>
//         [TestMethod]
//         [ExpectedException(typeof(InvalidNameException))]
//         public void InvalidArgument_Tes2t()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("1A", "123");
//         }
        
//           /// <summary>
//         /// Test Invalid Name
//         /// </summary>
//         [TestMethod]
//         [ExpectedException(typeof(InvalidNameException))]
//         public void InvalidName_Test()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.GetCellValue("1A");
//         }
        


//         // /// <summary>
//         // /// SetCellContent Test with formula
//         // /// </summary>
//         // [TestMethod]
//         // public void SetContentsOfCellTest_formula()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("X2", "=1 + 2 * 15");
//         //     s.SetContentsOfCell("X2", "=33 + 2 * 10");
//         //     var content = s.GetCellContents("X2");

//         //     Assert.AreEqual(new Formula("33 + 2 * 10"), content);
//         // }

//         //   /// <summary>
//         // /// SetCellContent Test  not changed
//         // /// </summary>
//         // [TestMethod]
//         // public void SetContentsOfCellTest_noChanges()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("A1", 123);
//         //     s.SetContentsOfCell("B1", new Formula("A1*10"));
//         //     try
//         //     {
//         //         s.SetContentsOfCell("A1", new Formula("B1"));
//         //         Assert.Fail("Error not thrown");
//         //     }
//         //     catch (CircularException)
//         //     {
//         //         Assert.AreEqual(123.0, s.GetCellContents("A1"));
//         //     }
//         // }

//         // /// <summary>
//         // /// SetCellContent Test dependents
//         // /// </summary>
//         // [TestMethod]
//         // public void SetCellContentsTest_dependents()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("A1","= 1 + 2 + 3");
//         //     s.SetContentsOfCell("B1","= A1*10");

//         //     var res = s.GetCellContents("B1");

//         //     Assert.AreEqual((Formula)res, new Formula("A1*10"));
//         // }

//         // /// <summary>
//         // /// SetCellContent Test dependents
//         // /// </summary>
//         // [TestMethod]
//         // public void SetContentsOfCellTest_dependents2()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("A1", 10);
//         //     s.SetContentsOfCell("B1", new Formula("A1*10"));
//         //     s.SetContentsOfCell("C1", new Formula("B1+A1"));
//         //     var content = s.GetCellContents("A1");

//         //     Assert.AreEqual(10.0, content);
//         // }


//         // /// <summary>
//         // /// IvalidNameException Test
//         // /// </summary>
//         // [TestMethod]
//         // [ExpectedException(typeof(InvalidNameException))]
//         // public void InvalidNameException()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.GetCellContents("1A");
//         // }

//         // /// <summary>
//         // /// IvalidNameException Test
//         // /// </summary>
//         // [TestMethod]
//         // [ExpectedException(typeof(ArgumentNullException))]
//         // public void InvalidArgumentException()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     string str = null;
//         //     s.SetContentsOfCell("A1", str);
//         // }


//         // /// <summary>
//         // /// IvalidNameException Test
//         // /// </summary>
//         // [TestMethod]
//         // [ExpectedException(typeof(InvalidNameException))]
//         // public void InvalidNameException2()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("11", 12);
//         // }

//         // /// <summary>
//         // /// ArgumentNullException Test
//         // /// </summary>
//         // [TestMethod]
//         // [ExpectedException(typeof(ArgumentNullException))]
//         // public void ArgumentNullException()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     string str = null;
//         //     s.SetContentsOfCell("A1", str);
//         // }

//         // /// <summary>
//         // /// SetCellContent Test dependents
//         // /// </summary>
//         // [TestMethod]
//         // public void SetContentsOfCellTest_dependencies()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("A1", 123);
//         //     s.SetContentsOfCell("B1", new Formula("A1*10"));
//         //     s.SetContentsOfCell("C1", new Formula("B1*2"));

//         //     var res = s.GetCellContents("B1");

//         //     Assert.AreEqual((Formula)res, new Formula("A1*10"));
//         // }


//         // /// <summary>
//         // /// CircularException Test
//         // /// </summary>
//         // [TestMethod]
//         // [ExpectedException(typeof(CircularException))]
//         // public void CircularExceptionTest()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("A1", new Formula("A1"));
//         // }



//         // /// <summary>
//         // /// SetCellContent Test  not changed
//         // /// </summary>
//         // [TestMethod]
//         // public void SetContentsOfCellTest_noChanges()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("A1", 123);
//         //     s.SetContentsOfCell("B1", new Formula("A1*10"));
//         //     try
//         //     {
//         //         s.SetContentsOfCell("A1", new Formula("B1"));
//         //         Assert.Fail("Error not thrown");
//         //     }
//         //     catch (CircularException)
//         //     {
//         //         Assert.AreEqual(123.0, s.GetCellContents("A1"));
//         //     }
//         // }


//         // /// <summary>
//         // /// Test Negative
//         // /// </summary>
//         // [TestMethod]
//         // public void SetContentsOfCell_negative()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("A1", -1234);

//         //     Assert.AreEqual(-1234.0, s.GetCellContents("A1"));
//         // }

//         // /// <summary>
//         // /// Test zero
//         // /// </summary>
//         // [TestMethod]
//         // public void SetContentsOfCell_zero()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("A1", 0.0);

//         //     Assert.AreEqual(0.0, s.GetCellContents("A1"));
//         // }


//         // /// <summary>
//         // /// Test valid cell names
//         // /// </summary>
//         // [TestMethod]
//         // public void SetContents_ValidCellNames()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("A1", 2.0);
//         //     s.SetContentsOfCell("Z99", -2.0);
//         //     s.SetContentsOfCell("A141", 12.0);
//         //     s.SetContentsOfCell("K1", 13.0);

//         //     Assert.AreEqual(4, s.GetNamesOfAllNonemptyCells().Count());
//         // }

//         // /// <summary>
//         // /// Test removing Formula
//         // /// </summary>
//         // [TestMethod]
//         // public void SetContents_RemovingFormula()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("A1", 2.0);
//         //     s.SetContentsOfCell("C1", new Formula("A1 * 2"));
//         //     s.SetContentsOfCell("C1", 12.0);
//         //     var result = s.SetContentsOfCell("A1", 13.0);

//         //     Assert.AreEqual(1, result.Count);
//         //     Assert.IsFalse(result.Contains("C1"));
//         // }


//         /// <summary>
//         /// InvalidName_SpecialChar Test
//         /// </summary>
//         [TestMethod]
//         [ExpectedException(typeof(InvalidNameException))]
//         public void InvalidName_SpecialChar()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A$1", "hello");
//         }

//         /// <summary>
//         /// InvalidName_null Test
//         /// </summary>
//         [TestMethod]
//         [ExpectedException(typeof(InvalidNameException))]
//         public void InvalidName_null()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell(null, "A1");
//         }


//         // ///<summary>
//         // /// test lookup values
//         // /// </summary>
//         // [TestMethod]
//         // public void FormulaWith_Variable_Test()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("A1", 2.0);
//         //     s.SetContentsOfCell("B1", 10.0);
//         //     s.SetContentsOfCell("C1", new Formula("A1 + B1"));

//         //     var content = s.GetCellContents("C1");
//         //     Assert.IsTrue(content is Formula);
//         // }

//         // ///<summary>
//         // /// test lookup values
//         // /// </summary>
//         // [TestMethod]
//         // public void FormulaWith_Variable_Test2()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("A1", 2.0);
//         //     s.SetContentsOfCell("B1", 10.0);
//         //     s.SetContentsOfCell("C1", new Formula("A1 + B1"));

//         //     var content = s.GetCellContents("C1");
//         //     Assert.AreEqual(content, new Formula("A1 + B1"));
//         // }



//         // ///<summary>
//         // /// test multiple setup and getname
//         // /// </summary>
//         // [TestMethod]
//         // public void GetNamesOfAllNoneEMptyCells_Tests_MultipleSetup()
//         // {
//         //     Spreadsheet s = new Spreadsheet();
//         //     s.SetContentsOfCell("A1", 2.0);
//         //     s.SetContentsOfCell("B1", 10.0);
//         //     s.SetContentsOfCell("C1", new Formula("A1 + B1"));
//         //     Assert.AreEqual(3, s.GetNamesOfAllNonemptyCells().Count());

//         //     s.SetContentsOfCell("A1", "");
//         //     Assert.AreEqual(2, s.GetNamesOfAllNonemptyCells().Count());
//         // }

//         ///<summary>
//         /// test formula replacing
//         /// </summary>
//         [TestMethod]
//         public void FormulaReplacing_Test()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "2.0");
//             s.SetContentsOfCell("B1", "=A1 + 12");


//             Assert.AreEqual(14.0, s.GetCellValue("B1"));
//         }

//         ///<summary>
//         /// test circular exception with dependencies
//         /// </summary>
//         [TestMethod]
//         public void CircularException_dependencies()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "2.0");
//             s.SetContentsOfCell("B1","=A1");

//             try
//             {
//                 s.SetContentsOfCell("A1", "=B1");
//                 Assert.Fail("error not thrown");
//             }
//             catch (CircularException)
//             {
//                 var result = s.SetContentsOfCell("A1", "123");
//                 Assert.IsTrue(result.Contains("B1"));
//             }

//         }

//         ///<summary>
//         /// test return value
//         /// </summary>      
//         [TestMethod]
//         public void ReturnValue_Test()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("Z1", "10.0");
//             s.SetContentsOfCell("X1", "=Z1");


//             Assert.AreEqual(10.0, s.GetCellValue("X1"));
//         }
        
        
//                 ///<summary>
//         /// test multiple sets
//         /// </summary>      
//         [TestMethod]
//         public void MultipleSets()
//         {
//             Spreadsheet s = new Spreadsheet();
//             s.SetContentsOfCell("A1", "10.0");
//             s.SetContentsOfCell("A1", "10.0");
//             s.SetContentsOfCell("A1", "10.0");
//             s.SetContentsOfCell("A1", "540.0");

//             var res = s.GetCellContents("A1");
//             Assert.IsTrue((double)s.GetCellValue("A1") == 540.0);
//         }
        
//     }
// }



// These tests are for private use only
// Redistributing this file is strictly against SoC policy.

using SS;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using SpreadsheetUtilities;
using System.Threading;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpreadsheetTester
{
  /// <summary>
  ///This is a test class for SpreadsheetTest and is intended
  ///to contain all SpreadsheetTest Unit Tests
  ///</summary>
  [TestClass()]
  public class GradingTests
  {

// [TestMethod, Timeout( 2000 )]
//     [TestCategory( "44" )]
//     public void MediumSave()
//     {
//       AbstractSpreadsheet ss = new Spreadsheet();
//       MediumSheet( ss );
//       ss.Save( "save7.txt" );
//       ss = new Spreadsheet( "save7.txt", s => true, s => s, "default" );
//       VV( ss, "A1", 2.0, "A2", 2.0, "A3", 3.0, "A4", 4.0, "B1", 1.0, "B2", 12.0, "C1", 13.0 );
//     }

        // Verifies cells and their values, which must alternate.
        public void VV(AbstractSpreadsheet sheet, params object[] constraints)
        {
            for (int i = 0; i < constraints.Length; i += 2)
            {
                if (constraints[i + 1] is double)
                {
                    Assert.AreEqual((double)constraints[i + 1], (double)sheet.GetCellValue((string)constraints[i]), 1e-9);
                }
                else
                {
                    Assert.AreEqual(constraints[i + 1], sheet.GetCellValue((string)constraints[i]));
                }
            }
        }


    // For setting a spreadsheet cell.
    public IEnumerable<string> Set( AbstractSpreadsheet sheet, string name, string contents )
    {
      List<string> result = new List<string>(sheet.SetContentsOfCell(name, contents));
      return result;
    }

    // Tests IsValid
    [TestMethod, Timeout( 2000 )]
    [TestCategory( "1" )]
    public void IsValidTest1()
    {
      AbstractSpreadsheet s = new Spreadsheet();
      s.SetContentsOfCell( "A1", "x" );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "2" )]
    [ExpectedException( typeof( InvalidNameException ) )]
    public void IsValidTest2()
    {
      AbstractSpreadsheet ss = new Spreadsheet(s => s[0] != 'A', s => s, "");
      ss.SetContentsOfCell( "A1", "x" );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "3" )]
    public void IsValidTest3()
    {
      AbstractSpreadsheet s = new Spreadsheet();
      s.SetContentsOfCell( "B1", "= A1 + C1" );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "4" )]
    [ExpectedException( typeof( FormulaFormatException ) )]
    public void IsValidTest4()
    {
      AbstractSpreadsheet ss = new Spreadsheet(s => s[0] != 'A', s => s, "");
      ss.SetContentsOfCell( "B1", "= A1 + C1" );
    }

    // Tests Normalize
    [TestMethod, Timeout( 2000 )]
    [TestCategory( "5" )]
    public void NormalizeTest1()
    {
      AbstractSpreadsheet s = new Spreadsheet();
      s.SetContentsOfCell( "B1", "hello" );
      Assert.AreEqual( "", s.GetCellContents( "b1" ) );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "6" )]
    public void NormalizeTest2()
    {
      AbstractSpreadsheet ss = new Spreadsheet(s => true, s => s.ToUpper(), "");
      ss.SetContentsOfCell( "B1", "hello" );
      Assert.AreEqual( "hello", ss.GetCellContents( "b1" ) );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "7" )]
    public void NormalizeTest3()
    {
      AbstractSpreadsheet s = new Spreadsheet();
      s.SetContentsOfCell( "a1", "5" );
      s.SetContentsOfCell( "A1", "6" );
      s.SetContentsOfCell( "B1", "= a1" );
      Assert.AreEqual( 5.0, (double) s.GetCellValue( "B1" ), 1e-9 );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "8" )]
    public void NormalizeTest4()
    {
      AbstractSpreadsheet ss = new Spreadsheet(s => true, s => s.ToUpper(), "");
      ss.SetContentsOfCell( "a1", "5" );
      ss.SetContentsOfCell( "A1", "6" );
      ss.SetContentsOfCell( "B1", "= a1" );
      Assert.AreEqual( 6.0, (double) ss.GetCellValue( "B1" ), 1e-9 );
    }

    // Simple tests
    [TestMethod, Timeout( 2000 )]
    [TestCategory( "9" )]
    public void EmptySheet()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      VV( ss, "A1", "" );
    }


    [TestMethod, Timeout( 2000 )]
    [TestCategory( "10" )]
    public void OneString()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      OneString( ss );
    }

    public void OneString( AbstractSpreadsheet ss )
    {
      Set( ss, "B1", "hello" );
      VV( ss, "B1", "hello" );
    }


    [TestMethod, Timeout( 2000 )]
    [TestCategory( "11" )]
    public void OneNumber()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      OneNumber( ss );
    }

    public void OneNumber( AbstractSpreadsheet ss )
    {
      Set( ss, "C1", "17.5" );
      VV( ss, "C1", 17.5 );
    }


    [TestMethod, Timeout( 2000 )]
    [TestCategory( "12" )]
    public void OneFormula()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      OneFormula( ss );
    }

    public void OneFormula( AbstractSpreadsheet ss )
    {
      Set( ss, "A1", "4.1" );
      Set( ss, "B1", "5.2" );
      Set( ss, "C1", "= A1+B1" );
      VV( ss, "A1", 4.1, "B1", 5.2, "C1", 9.3 );
    }


    [TestMethod, Timeout( 2000 )]
    [TestCategory( "13" )]
    public void ChangedAfterModify()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      Assert.IsFalse( ss.Changed );
      Set( ss, "C1", "17.5" );
      Assert.IsTrue( ss.Changed );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "13b" )]
    public void UnChangedAfterSave()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      Set( ss, "C1", "17.5" );
      ss.Save( "changed.txt" );
      Assert.IsFalse( ss.Changed );
    }


    [TestMethod, Timeout( 2000 )]
    [TestCategory( "14" )]
    public void DivisionByZero1()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      DivisionByZero1( ss );
    }

    public void DivisionByZero1( AbstractSpreadsheet ss )
    {
      Set( ss, "A1", "4.1" );
      Set( ss, "B1", "0.0" );
      Set( ss, "C1", "= A1 / B1" );
      Assert.IsInstanceOfType( ss.GetCellValue( "C1" ), typeof( FormulaError ) );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "15" )]
    public void DivisionByZero2()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      DivisionByZero2( ss );
    }

    public void DivisionByZero2( AbstractSpreadsheet ss )
    {
      Set( ss, "A1", "5.0" );
      Set( ss, "A3", "= A1 / 0.0" );
      Assert.IsInstanceOfType( ss.GetCellValue( "A3" ), typeof( FormulaError ) );
    }



    [TestMethod, Timeout( 2000 )]
    [TestCategory( "16" )]
    public void EmptyArgument()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      EmptyArgument( ss );
    }

    public void EmptyArgument( AbstractSpreadsheet ss )
    {
      Set( ss, "A1", "4.1" );
      Set( ss, "C1", "= A1 + B1" );
      Assert.IsInstanceOfType( ss.GetCellValue( "C1" ), typeof( FormulaError ) );
    }


    [TestMethod, Timeout( 2000 )]
    [TestCategory( "17" )]
    public void StringArgument()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      StringArgument( ss );
    }

    public void StringArgument( AbstractSpreadsheet ss )
    {
      Set( ss, "A1", "4.1" );
      Set( ss, "B1", "hello" );
      Set( ss, "C1", "= A1 + B1" );
      Assert.IsInstanceOfType( ss.GetCellValue( "C1" ), typeof( FormulaError ) );
    }


    [TestMethod, Timeout( 2000 )]
    [TestCategory( "18" )]
    public void ErrorArgument()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      ErrorArgument( ss );
    }

    public void ErrorArgument( AbstractSpreadsheet ss )
    {
      Set( ss, "A1", "4.1" );
      Set( ss, "B1", "" );
      Set( ss, "C1", "= A1 + B1" );
      Set( ss, "D1", "= C1" );
      Assert.IsInstanceOfType( ss.GetCellValue( "D1" ), typeof( FormulaError ) );
    }


    [TestMethod, Timeout( 2000 )]
    [TestCategory( "19" )]
    public void NumberFormula1()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      NumberFormula1( ss );
    }

    public void NumberFormula1( AbstractSpreadsheet ss )
    {
      Set( ss, "A1", "4.1" );
      Set( ss, "C1", "= A1 + 4.2" );
      VV( ss, "C1", 8.3 );
    }


    [TestMethod, Timeout( 2000 )]
    [TestCategory( "20" )]
    public void NumberFormula2()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      NumberFormula2( ss );
    }

    public void NumberFormula2( AbstractSpreadsheet ss )
    {
      Set( ss, "A1", "= 4.6" );
      VV( ss, "A1", 4.6 );
    }


    // Repeats the simple tests all together
    [TestMethod, Timeout( 2000 )]
    [TestCategory( "21" )]
    public void RepeatSimpleTests()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      Set( ss, "A1", "17.32" );
      Set( ss, "B1", "This is a test" );
      Set( ss, "C1", "= A1+B1" );
      OneString( ss );
      OneNumber( ss );
      OneFormula( ss );
      DivisionByZero1( ss );
      DivisionByZero2( ss );
      StringArgument( ss );
      ErrorArgument( ss );
      NumberFormula1( ss );
      NumberFormula2( ss );
    }

    // Four kinds of formulas
    [TestMethod, Timeout( 2000 )]
    [TestCategory( "22" )]
    public void Formulas()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      Formulas( ss );
    }

    public void Formulas( AbstractSpreadsheet ss )
    {
      Set( ss, "A1", "4.4" );
      Set( ss, "B1", "2.2" );
      Set( ss, "C1", "= A1 + B1" );
      Set( ss, "D1", "= A1 - B1" );
      Set( ss, "E1", "= A1 * B1" );
      Set( ss, "F1", "= A1 / B1" );
      VV( ss, "C1", 6.6, "D1", 2.2, "E1", 4.4 * 2.2, "F1", 2.0 );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "23" )]
    public void Formulasa()
    {
      Formulas();
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "24" )]
    public void Formulasb()
    {
      Formulas();
    }


    // Are multiple spreadsheets supported?
    [TestMethod, Timeout( 2000 )]
    [TestCategory( "25" )]
    public void Multiple()
    {
      AbstractSpreadsheet s1 = new Spreadsheet();
      AbstractSpreadsheet s2 = new Spreadsheet();
      Set( s1, "X1", "hello" );
      Set( s2, "X1", "goodbye" );
      VV( s1, "X1", "hello" );
      VV( s2, "X1", "goodbye" );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "26" )]
    public void Multiplea()
    {
      Multiple();
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "27" )]
    public void Multipleb()
    {
      Multiple();
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "28" )]
    public void Multiplec()
    {
      Multiple();
    }

    // Reading/writing spreadsheets
    [TestMethod, Timeout( 2000 )]
    [TestCategory( "29" )]
    [ExpectedException( typeof( SpreadsheetReadWriteException ) )]
    public void SaveTest1()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      ss.Save( Path.GetFullPath( "/missing/save.txt" ) );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "30" )]
    [ExpectedException( typeof( SpreadsheetReadWriteException ) )]
    public void SaveTest2()
    {
      AbstractSpreadsheet ss = new Spreadsheet(Path.GetFullPath("/missing/save.txt"), s => true, s => s, "");
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "31" )]
    public void SaveTest3()
    {
      AbstractSpreadsheet s1 = new Spreadsheet();
      Set( s1, "A1", "hello" );
      s1.Save( "save1.txt" );
      s1 = new Spreadsheet( "save1.txt", s => true, s => s, "default" );
      Assert.AreEqual( "hello", s1.GetCellContents( "A1" ) );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "32" )]
    [ExpectedException( typeof( SpreadsheetReadWriteException ) )]
    public void SaveTest4()
    {
      using ( StreamWriter writer = new StreamWriter( "save2.txt" ) )
      {
        writer.WriteLine( "This" );
        writer.WriteLine( "is" );
        writer.WriteLine( "a" );
        writer.WriteLine( "test!" );
      }
      AbstractSpreadsheet ss = new Spreadsheet("save2.txt", s => true, s => s, "");
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "33" )]
    [ExpectedException( typeof( SpreadsheetReadWriteException ) )]
    public void SaveTest5()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      ss.Save( "save3.txt" );
      ss = new Spreadsheet( "save3.txt", s => true, s => s, "version" );
    }


    [TestMethod, Timeout( 2000 )]
    [TestCategory( "35" )]
    public void SaveTest7()
    {
      var sheet = new
      {
        cells = new
        {
          A1 = new {stringForm = "hello"},
          A2 = new {stringForm = "5.0"},
          A3 = new {stringForm = "4.0"},
          A4 = new {stringForm = "= A2 + A3"}
        },
        Version=""
      };

      File.WriteAllText( "save5.txt", JsonConvert.SerializeObject( sheet ) );


      AbstractSpreadsheet ss = new Spreadsheet("save5.txt", s => true, s => s, "");
      VV( ss, "A1", "hello", "A2", 5.0, "A3", 4.0, "A4", 9.0 );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "36" )]
    public void SaveTest8()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      Set( ss, "A1", "hello" );
      Set( ss, "A2", "5.0" );
      Set( ss, "A3", "4.0" );
      Set( ss, "A4", "= A2 + A3" );
      ss.Save( "save6.txt" );

      string fileContents = File.ReadAllText("save6.txt");

      dynamic o = JObject.Parse(fileContents);

      Assert.AreEqual( "default", o.Version.ToString() );
      Assert.AreEqual( "hello", o.cells.A1.stringForm.ToString() );
      Assert.AreEqual( 5.0, double.Parse( o.cells.A2.stringForm.ToString() ), 1e-9 );
      Assert.AreEqual( 4.0, double.Parse( o.cells.A3.stringForm.ToString() ), 1e-9 );
      Assert.AreEqual( "=A2+A3", o.cells.A4.stringForm.ToString().Replace(" ", "" ));
    }


    // Fun with formulas
    [TestMethod, Timeout( 2000 )]
    [TestCategory( "37" )]
    public void Formula1()
    {
      Formula1( new Spreadsheet() );
    }
    public void Formula1( AbstractSpreadsheet ss )
    {
      Set( ss, "a1", "= a2 + a3" );
      Set( ss, "a2", "= b1 + b2" );
      Assert.IsInstanceOfType( ss.GetCellValue( "a1" ), typeof( FormulaError ) );
      Assert.IsInstanceOfType( ss.GetCellValue( "a2" ), typeof( FormulaError ) );
      Set( ss, "a3", "5.0" );
      Set( ss, "b1", "2.0" );
      Set( ss, "b2", "3.0" );
      VV( ss, "a1", 10.0, "a2", 5.0 );
      Set( ss, "b2", "4.0" );
      VV( ss, "a1", 11.0, "a2", 6.0 );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "38" )]
    public void Formula2()
    {
      Formula2( new Spreadsheet() );
    }
    public void Formula2( AbstractSpreadsheet ss )
    {
      Set( ss, "a1", "= a2 + a3" );
      Set( ss, "a2", "= a3" );
      Set( ss, "a3", "6.0" );
      VV( ss, "a1", 12.0, "a2", 6.0, "a3", 6.0 );
      Set( ss, "a3", "5.0" );
      VV( ss, "a1", 10.0, "a2", 5.0, "a3", 5.0 );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "39" )]
    public void Formula3()
    {
      Formula3( new Spreadsheet() );
    }
    public void Formula3( AbstractSpreadsheet ss )
    {
      Set( ss, "a1", "= a3 + a5" );
      Set( ss, "a2", "= a5 + a4" );
      Set( ss, "a3", "= a5" );
      Set( ss, "a4", "= a5" );
      Set( ss, "a5", "9.0" );
      VV( ss, "a1", 18.0 );
      VV( ss, "a2", 18.0 );
      Set( ss, "a5", "8.0" );
      VV( ss, "a1", 16.0 );
      VV( ss, "a2", 16.0 );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "40" )]
    public void Formula4()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      Formula1( ss );
      Formula2( ss );
      Formula3( ss );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "41" )]
    public void Formula4a()
    {
      Formula4();
    }


    [TestMethod, Timeout( 2000 )]
    [TestCategory( "42" )]
    public void MediumSheet()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      MediumSheet( ss );
    }

    public void MediumSheet( AbstractSpreadsheet ss )
    {
      Set( ss, "A1", "1.0" );
      Set( ss, "A2", "2.0" );
      Set( ss, "A3", "3.0" );
      Set( ss, "A4", "4.0" );
      Set( ss, "B1", "= A1 + A2" );
      Set( ss, "B2", "= A3 * A4" );
      Set( ss, "C1", "= B1 + B2" );
      VV( ss, "A1", 1.0, "A2", 2.0, "A3", 3.0, "A4", 4.0, "B1", 3.0, "B2", 12.0, "C1", 15.0 );
      Set( ss, "A1", "2.0" );
      VV( ss, "A1", 2.0, "A2", 2.0, "A3", 3.0, "A4", 4.0, "B1", 4.0, "B2", 12.0, "C1", 16.0 );
      Set( ss, "B1", "= A1 / A2" );
      VV( ss, "A1", 2.0, "A2", 2.0, "A3", 3.0, "A4", 4.0, "B1", 1.0, "B2", 12.0, "C1", 13.0 );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "43" )]
    public void MediumSheeta()
    {
      MediumSheet();
    }


    [TestMethod, Timeout( 2000 )]
    [TestCategory( "44" )]
    public void MediumSave()
    {
      AbstractSpreadsheet ss = new Spreadsheet();
      MediumSheet( ss );
      ss.Save( "save7.txt" );
      ss = new Spreadsheet( "save7.txt", s => true, s => s, "default" );
      VV( ss, "A1", 2.0, "A2", 2.0, "A3", 3.0, "A4", 4.0, "B1", 1.0, "B2", 12.0, "C1", 13.0 );
    }

    [TestMethod, Timeout( 2000 )]
    [TestCategory( "45" )]
    public void MediumSavea()
    {
      MediumSave();
    }


    // A long chained formula. Solutions that re-evaluate 
    // cells on every request, rather than after a cell changes,
    // will timeout on this test.
    // This test is repeated to increase its scoring weight
    [TestMethod, Timeout( 6000 )]
    [TestCategory( "46" )]
    public void LongFormulaTest()
    {
      object result = "";
      LongFormulaHelper( out result );
      Assert.AreEqual( "ok", result );
    }

    [TestMethod, Timeout( 6000 )]
    [TestCategory( "47" )]
    public void LongFormulaTest2()
    {
      object result = "";
      LongFormulaHelper( out result );
      Assert.AreEqual( "ok", result );
    }

    [TestMethod, Timeout( 6000 )]
    [TestCategory( "48" )]
    public void LongFormulaTest3()
    {
      object result = "";
      LongFormulaHelper( out result );
      Assert.AreEqual( "ok", result );
    }

    [TestMethod, Timeout( 6000 )]
    [TestCategory( "49" )]
    public void LongFormulaTest4()
    {
      object result = "";
      LongFormulaHelper( out result );
      Assert.AreEqual( "ok", result );
    }

    [TestMethod, Timeout( 6000 )]
    [TestCategory( "50" )]
    public void LongFormulaTest5()
    {
      object result = "";
      LongFormulaHelper( out result );
      Assert.AreEqual( "ok", result );
    }

    public void LongFormulaHelper( out object result )
    {
      try
      {
        AbstractSpreadsheet s = new Spreadsheet();
        s.SetContentsOfCell( "sum1", "= a1 + a2" );
        int i;
        int depth = 100;
        for ( i = 1; i <= depth * 2; i += 2 )
        {
          s.SetContentsOfCell( "a" + i, "= a" + ( i + 2 ) + " + a" + ( i + 3 ) );
          s.SetContentsOfCell( "a" + ( i + 1 ), "= a" + ( i + 2 ) + "+ a" + ( i + 3 ) );
        }
        s.SetContentsOfCell( "a" + i, "1" );
        s.SetContentsOfCell( "a" + ( i + 1 ), "1" );
        Assert.AreEqual( Math.Pow( 2, depth + 1 ), (double) s.GetCellValue( "sum1" ), 1.0 );
        s.SetContentsOfCell( "a" + i, "0" );
        Assert.AreEqual( Math.Pow( 2, depth ), (double) s.GetCellValue( "sum1" ), 1.0 );
        s.SetContentsOfCell( "a" + ( i + 1 ), "0" );
        Assert.AreEqual( 0.0, (double) s.GetCellValue( "sum1" ), 0.1 );
        result = "ok";
      }
      catch ( Exception e )
      {
        result = e;
      }
    }

  }
}
