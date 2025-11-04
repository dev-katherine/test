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
/// This file implements the Spreadsheet Class which is a subclass of Abstractspreadsheet class
/// The Spreadsheet class manages cells, their contents and manage dependcies between cells by using
/// a dependency graph. It makes to support recalculation of the cell
/// 

/// </summary>

using System;
using System.Collections;
using System.Collections.Generic;
using SS;
using SpreadsheetUtilities;
using System.Data;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Xml;
using System.Xml.Schema;
using System.Linq;
using System.Text;
using System.ComponentModel.Design;
using System.Reflection.Metadata;
using System.Xml.Serialization;



namespace SS
{

    /// <summary>
    /// class to store the content and the actual value of the cell
    /// </summary>
    internal class Cell
    {
        object contents;
        object value;

        public object Contents { get; set; }
        public object Value { get; set; }

        /// <summary>
        /// paramatize constructor
        /// </summary>
        /// <param name="content"></param>
        /// <param name="value"></param>
        internal Cell(object content, object value)
        {
            this.contents = content;
            this.value = value;
        }

        /// <summary>
        /// default constructor
        /// </summary>
        internal Cell()
        {
            contents = "";
            value = "";
        }

    }

    /// <summary>
    /// The Spreadsheet class manages spreadsheet cells, dependencies between cells and support
    /// cell contentent with auto recalculation
    /// </summary>
    public class Spreadsheet : AbstractSpreadsheet
    {
        private Dictionary<string, Cell> cellDict;
        private DependencyGraph dependencies;
        private bool changed;


        // private Func<string, bool> IsValid;
        // private Func<string, string> Normalize;
        private string version;

        /// <summary>
        /// default constructor of spreadsheet class
        /// </summary>
        public Spreadsheet() : base(s => true, s => s, "default")
        {
            this.cellDict = new Dictionary<string, Cell>();
            this.dependencies = new DependencyGraph();
            this.changed = false;
            this.version = version;
        }


          /// <summary>
        /// parametrize Contructor with isValid, normalize function delegate, without version
        /// </summary>
        public Spreadsheet(Func<string, bool> isValid, Func<string, string> normalize, string version)
        : base(isValid, normalize, version)
        {
            this.cellDict = new Dictionary<string, Cell>();
            this.dependencies = new DependencyGraph();
            this.version = "default";
            this.changed = false;
        }

        /// <summary>
        /// parametrize Contructor with isValid, normalize function delegate, and version
        /// </summary>
        public Spreadsheet(string filename, Func<string, bool> isValid, Func<string, string> normalize, string version)
        : base(isValid, normalize, version)
        {
            this.cellDict = new Dictionary<string, Cell>();
            this.dependencies = new DependencyGraph();
            this.changed = false;
            this.version = version;

            string fileVersion = GetSavedVersion(filename);

            if (version != fileVersion)
                throw new SpreadsheetReadWriteException("Invalid version");

            try
            {
                XmlReader reader;

                using (reader = XmlReader.Create(filename))
                {
                    string currName = null;
                    string currContents = null;

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                        {
                             if (reader.Name == "name")
                                {
                                    reader.Read();
                                    currName = reader.Value;
                                }
                                else if (reader.Name == "contents")
                                {
                                    reader.Read();
                                    currContents = reader.Value;
                                
                                if (!string.IsNullOrEmpty(currName) && currContents != null)
                                    {
                                    System.Console.WriteLine(currContents);
                                    SetContentsOfCell(currName, currContents);
                                    currName = null;
                                    currContents = null;
                                }
                            }
                        }
                    }
                }
                changed = false;
            }
            catch (Exception e)
            {
                throw new SpreadsheetReadWriteException(e.Message);
            }
        }


        /// <summary>
        /// True if this spreadsheet has been modified since it was created or saved                  
        /// (whichever happened most recently); false otherwise.
        /// </summary>
        public override bool Changed
        {
            get => changed;
            protected set => changed = value;
        }

        /// <summary>
        /// Enumerates the names of all the non-empty cells in the spreadsheet.
        /// </summary>

        public override IEnumerable<string> GetNamesOfAllNonemptyCells()
        {
            foreach (var cellName in cellDict.Keys)
            {
                if (cellDict[cellName].Contents is string s && s == "")
                    continue;
                yield return cellName;
            }
        }

        /// <summary>
        /// If name is null or invalid, throws an InvalidNameException.
        /// 
        /// Otherwise, returns the contents (as opposed to the value) of the named cell.  The return
        /// value should be either a string, a double, or a Formula.
        /// </summary>
        public override object GetCellContents(string name)
        {
            name = Normalize(name);
            IsValidName(name);

            if (cellDict.ContainsKey(name))
                return cellDict[name].Contents;
            return "";
        }

        /// <summary>
        /// If name is null or invalid, throws an InvalidNameException.
        /// 
        /// Otherwise, the contents of the named cell becomes number.  The method returns a
        /// list consisting of name plus the names of all other cells whose value depends, 
        /// directly or indirectly, on the named cell.
        /// 
        /// For example, if name is A1, B1 contains A1*2, and C1 contains B1+A1, the
        /// list {A1, B1, C1} is returned.
        /// </summary>

        protected override IList<string> SetCellContents(string name, double number)
        {
            name = Normalize(name);
            IsValidName(name);

            dependencies.ReplaceDependees(name, new HashSet<string>());
            setContent(name, number);

            return new List<string>(GetCellsToRecalculate(name));
        }

        /// <summary>
        /// If text is null, throws an ArgumentNullException.
        /// 
        /// Otherwise, if name is null or invalid, throws an InvalidNameException.
        /// 
        /// Otherwise, the contents of the named cell becomes text.  The method returns a
        /// list consisting of name plus the names of all other cells whose value depends, 
        /// directly or indirectly, on the named cell.
        /// 
        /// For example, if name is A1, B1 contains A1*2, and C1 contains B1+A1, the
        /// list {A1, B1, C1} is returned.
        /// </summary>
        protected override IList<string> SetCellContents(string name, string text)
        {
            name = Normalize(name);
            IsValidName(name);

            if (text == null)
                throw new ArgumentNullException();

            dependencies.ReplaceDependees(name, new HashSet<string>());

            if (text == "")
            {
                setContent(name, "");
            }
            else
            {
                setContent(name, text);
            }

            return new List<string>(GetCellsToRecalculate(name));
        }


        /// <summary>
        /// If the formula parameter is null, throws an ArgumentNullException.
        /// 
        /// Otherwise, if name is null or invalid, throws an InvalidNameException.
        /// 
        /// Otherwise, if changing the contents of the named cell to be the formula would cause a 
        /// circular dependency, throws a CircularException, and no change is made to the spreadsheet.
        /// 
        /// Otherwise, the contents of the named cell becomes formula.  The method returns a
        /// list consisting of name plus the names of all other cells whose value depends,
        /// directly or indirectly, on the named cell.
        /// 
        /// For example, if name is A1, B1 contains A1*2, and C1 contains B1+A1, the
        /// list {A1, B1, C1} is returned.
        /// </summary>
        protected override IList<string> SetCellContents(string name, Formula formula)
        {
            name = Normalize(name);
            IsValidName(name);

            if (formula == null)
                throw new ArgumentNullException(nameof(formula));

            // IEnumerable<string> variables = formula.GetVariables();
            IEnumerable<string> prevDependees = dependencies.GetDependees(name);
            // object prevContents = cellDict.ContainsKey(name) ? cellDict[name].Contents : "";
            // object prevValue = cellDict.ContainsKey(name) ? cellDict[name].Value : "";
            object prevCell = cellDict.ContainsKey(name) ? cellDict[name] : null;

            dependencies.ReplaceDependees(name, formula.GetVariables());
            try
            {
                var recalculateCell = new List<string>(GetCellsToRecalculate(name));
                // if (!cellDict.ContainsKey(name))
                //     cellDict[name] = new Cell();
                // cellDict[name].Contents = formula;
                // cellDict[name].Value = formula;
                if (!cellDict.ContainsKey(name))
                    cellDict[name] = new Cell();
                cellDict[name].Contents = formula;
                cellDict[name].Value = EvaluateFormula(formula);

                return recalculateCell;
            }
            catch (CircularException)
            {
                dependencies.ReplaceDependees(name, prevDependees);
                if (prevCell != null)
                    setContent(name, prevCell);
                // setContent(name, prevContents, prevValue);
                throw new CircularException();
            }
        }

        /// <summary>
        /// Returns an enumeration, without duplicates, of the names of all cells whose
        /// values depend directly on the value of the named cell.  In other words, returns
        /// an enumeration, without duplicates, of the names of all cells that contain
        /// formulas containing name.
        /// 
        /// For example, suppose that
        /// A1 contains 3
        /// B1 contains the formula A1 * A1
        /// C1 contains the formula B1 + A1
        /// D1 contains the formula B1 - C1
        /// The direct dependents of A1 are B1 and C1
        /// </summary>
        protected override IEnumerable<string> GetDirectDependents(string name)
        {
            name = Normalize(name);
            IsValidName(name);
            return dependencies.GetDependents(name);
        }


        /// <summary>
        /// check if name is valid or not
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="InvalidNameException"></exception>
        private bool IsValidName(string name)
        {
            if (name == null)
                throw new InvalidNameException();

            if (!Regex.IsMatch(name, @"^[a-zA-Z]+[0-9]+$"))
                throw new InvalidNameException();

            if (!IsValid(name))
                throw new InvalidNameException();
            return true;
        }

        /// <summary>
        /// return the value of given variable
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        /// <exception cref="FormulaFormatException"></exception>
        private double LookupValue(string variable)
        {
            variable = Normalize(variable);
            if (cellDict.ContainsKey(variable) && cellDict[variable].Value is double d)
                return d;
            throw new FormulaFormatException("Invalid Formula");
        }

        /// <summary>
        /// call evaluate function from formula class with lookup value 
        /// </summary>
        /// <param name="formula"></param>
        /// <returns></returns>
        private object EvaluateFormula(Formula formula)
        {
            return formula.Evaluate(LookupValue);
        }

        /// <summary>
        /// set value and content of the cell class with given key name
        /// </summary>
        /// <param name="name"></param>
        /// <param name="obj"></param>
        private void setContent(string name, object obj)
        {
            if (!cellDict.ContainsKey(name))
                cellDict[name] = new Cell();
            cellDict[name].Contents = obj;
            cellDict[name].Value = obj;
        }

 /// <summary>
        ///   <para>Sets the contents of the named cell to the appropriate value. </para>
        ///   <para>
        ///       First, if the content parses as a double, the contents of the named
        ///       cell becomes that double.
        ///   </para>
        ///
        ///   <para>
        ///       Otherwise, if content begins with the character '=', an attempt is made
        ///       to parse the remainder of content into a Formula.  
        ///       There are then three possible outcomes:
        ///   </para>
        ///
        ///   <list type="number">
        ///       <item>
        ///           If the remainder of content cannot be parsed into a Formula, a 
        ///           SpreadsheetUtilities.FormulaFormatException is thrown.
        ///       </item>
        /// 
        ///       <item>
        ///           If changing the contents of the named cell to be f
        ///           would cause a circular dependency, a CircularException is thrown,
        ///           and no change is made to the spreadsheet.
        ///       </item>
        ///
        ///       <item>
        ///           Otherwise, the contents of the named cell becomes f.
        ///       </item>
        ///   </list>
        ///
        ///   <para>
        ///       Finally, if the content is a string that is not a double and does not
        ///       begin with an "=" (equal sign), save the content as a string.
        ///   </para>
        /// </summary>
        ///
        /// <exception cref="InvalidNameException"> 
        ///   If the name parameter is null or invalid, throw an InvalidNameException
        /// </exception>
        /// 
        /// <exception cref="SpreadsheetUtilities.FormulaFormatException"> 
        ///   If the content is "=XYZ" where XYZ is an invalid formula, throw a FormulaFormatException.
        /// </exception>
        /// 
        /// <exception cref="CircularException"> 
        ///   If changing the contents of the named cell to be the formula would 
        ///   cause a circular dependency, throw a CircularException.  
        ///   (NOTE: No change is made to the spreadsheet.)
        /// </exception>
        /// 
        /// <param name="name"> The cell name that is being changed</param>
        /// <param name="content"> The new content of the cell</param>
        /// 
        /// <returns>
        ///       <para>
        ///           This method returns a list consisting of the passed in cell name,
        ///           followed by the names of all other cells whose value depends, directly
        ///           or indirectly, on the named cell. The order of the list MUST BE any
        ///           order such that if cells are re-evaluated in that order, their dependencies 
        ///           are satisfied by the time they are evaluated.
        ///       </para>
        ///
        ///       <para>
        ///           For example, if name is A1, B1 contains A1*2, and C1 contains B1+A1, the
        ///           list {A1, B1, C1} is returned.  If the cells are then evaluate din the order:
        ///           A1, then B1, then C1, the integrity of the Spreadsheet is maintained.
        ///       </para>
        /// </returns>
        public override IList<string> SetContentsOfCell(string name, string content)
        {

            name = Normalize(name);
            IsValidName(name);

            if (content == null)
                throw new ArgumentNullException();

            IList<string> recalculateCells;

            if (double.TryParse(content, out double d))
                recalculateCells = SetCellContents(name, d);
            else if (content.StartsWith("=") && content.Length > 0)
            {
                Formula f = new Formula(content.Substring(1), Normalize, IsValid);
                recalculateCells = SetCellContents(name, f);
            }
            else
                recalculateCells = SetCellContents(name, content);

            foreach (string cell in recalculateCells)
            {
                if (cellDict.ContainsKey(cell) && cellDict[cell].Contents is Formula cellFormula)
                {
                    object val = EvaluateFormula(cellFormula);
                    cellDict[cell].Value = val;
                }
            }

            changed = true;

            return recalculateCells;

        }



        /// <summary>
        ///   Look up the version information in the given file. If there are any problems opening, reading, 
        ///   or closing the file, the method should throw a SpreadsheetReadWriteException with an explanatory message.
        /// </summary>
        /// 
        /// <remarks>
        ///   In an ideal world, this method would be marked static as it does not rely on an existing SpreadSheet
        ///   object to work; indeed it should simply open a file, lookup the version, and return it.  Because
        ///   C# does not support this syntax, we abused the system and simply create a "regular" method to
        ///   be implemented by the base class.
        /// </remarks>
        /// 
        /// <exception cref="SpreadsheetReadWriteException"> 
        ///   Thrown if any problem occurs while reading the file or looking up the version information.
        /// </exception>
        /// 
        /// <param name="filename"> The name of the file (including path, if necessary)</param>
        /// <returns>Returns the version information of the spreadsheet saved in the named file.</returns>
        public override string GetSavedVersion(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                throw new SpreadsheetReadWriteException("Invalid filename");
            try
            {
                XmlReader reader;
                using (reader = XmlReader.Create(filename))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "spreadsheet")
                        {
                            string ver = reader.GetAttribute("version");
                            if (ver == null)
                                throw new SpreadsheetReadWriteException("Invalid version");
                            return ver;
                        }
                    }
                }
                throw new SpreadsheetReadWriteException("Invalid file");
            }
            catch (Exception e)
            {
                throw new SpreadsheetReadWriteException(e.Message);
            }
        }

       /// <summary>
        /// Writes the contents of this spreadsheet to the named file using an XML format.
        /// The XML elements should be structured as follows:
        /// 
        /// <spreadsheet version="version information goes here">
        /// 
        /// <cell>
        /// <name>cell name goes here</name>
        /// <contents>cell contents goes here</contents>    
        /// </cell>
        /// 
        /// </spreadsheet>
        /// 
        /// There should be one cell element for each non-empty cell in the spreadsheet.  
        /// If the cell contains a string, it should be written as the contents.  
        /// If the cell contains a double d, d.ToString() should be written as the contents.  
        /// If the cell contains a Formula f, f.ToString() with "=" prepended should be written as the contents.
        /// 
        /// If there are any problems opening, writing, or closing the file, the method should throw a
        /// SpreadsheetReadWriteException with an explanatory message.
        /// </summary>
        public override void Save(string filename)
        {
            XmlWriter writer;
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  "
            };

            try
            {
                using (writer = XmlWriter.Create(filename))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("spreadsheet");
                    writer.WriteAttributeString("version", Version);

                    foreach (string name in GetNamesOfAllNonemptyCells())
                    {
                        writer.WriteStartElement("cell");
                        writer.WriteElementString("name", name);

                        object contents = GetCellContents(name);

                        if (contents is Formula f)
                            writer.WriteElementString("contents", "=" + f.ToString());
                        else
                            writer.WriteElementString("contents", contents.ToString());
                        writer.WriteEndElement();

                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();

                }
                changed = false;
            }
            catch (Exception e)
            {
                throw new SpreadsheetReadWriteException(e.Message);
            }

        }

     /// <summary>
        /// If name is invalid, throws an InvalidNameException.
        /// </summary>
        ///
        /// <exception cref="InvalidNameException"> 
        ///   If the name is invalid, throw an InvalidNameException
        /// </exception>
        /// 
        /// <param name="name"> The name of the cell that we want the value of (will be normalized)</param>
        /// 
        /// <returns>
        ///   Returns the value (as opposed to the contents) of the named cell.  The return
        ///   value should be either a string, a double, or a SpreadsheetUtilities.FormulaError.
        /// </returns>
        public override object GetCellValue(string name)
        {
            name = Normalize(name);
            IsValidName(name);

            if (cellDict.ContainsKey(name))
                return cellDict[name].Value;
            return "";
        }

    }
}