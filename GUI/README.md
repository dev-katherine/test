
```
Author: [Katherine Jang & Chloe Shin]
Partner:    [Katherine Jang & Chloe Shin]
Date:       3-Nov-2025
Course:     CS 3500, University of Utah, ECE
GitHub ID:  [dev-katherine, purp1ish]
Repo:       https://github.com/Habtamu-Fall2025-CS3500/assignment-six-spreadsheet-gui-khloe
Commit #:  33633702fe2d59d959689f637dd63e806131414a
Ssolution:   Spreadsheet
Copyright:  CS 3500, Katherine Jang, and Chloe Shin - This work may not be copied for use in Academic Coursework.
```

# Comments to Evaluators:
    Spreadsheet Class which is a subclass of Abstractspreadsheet class
    The Spreadsheet class manages cells, their contents and manage dependcies between cells by using a dependency graph.  It makes to support recalculation of the cell
    This project has Formula project, and DependencyGraph project as reference.
    GUI is a project of spreadsheet which includes the GUI codes.
    The GUI manages View part of the spread sheets which makes user can use the spreadsheet without understanding internal logic.
    This project has  SpreadsheetPanel project as reference.

# Assignment Specific Topics
    1. Fixing Spreadsheet Model from Assignment 5 
    2. Cell grid display
    3. Implementing Cell selection and editing
    4. Implementing File menu function -> new, open, save, close
    5. Warning box appears in some specific cases
    6. Error message appears in invalid format
    7. Help menu appears with message box

### 👯‍♀️ Partnership
*   Chloe Shin, Kahterine Jang
*   Contrbutions: All the teammates contributed equally
*   Our team worked together on the GUI part that needed to be implemented in Assignment 6. Since the existing Model logic(Spreadsheet) did not pass couple tests, we also worked on fixing the bugs. Previously, we had written our own codes separately, so we adopted a method of modifying the codes by comparing them with each other. We fixed the bug by checking the differences in each codes and checking which logic can pass the test. In the case of GUI, we cross checked the parts that each could not fill out the requirements and the parts that could logically cause errors in the code.  There was a limit to the schedule to do 100% fair programming together, we collaborated using GitHub for some parts.

### Additional Features
* We additionally implemented cell color highlighting
* Cells would be colored depend on their values.
*  **Green**: Positive numbers
- **Yellow**: Zero values
- **Red**: Negative numbers
- **Orange**: Formula errors
- **White**: Text values
* Color is determined in the method `DetermineCellColor()`
* Custom paint event handler is used for rendering color backgrounds


### Branching History
*   bugs/fixAS5 : fix bugs of Assignment 5 Model by using given test codes
*   feat/gui : Added features(Spreadsheet GUI) corresponding to assignment 62
*   feat/colorHighlight : Added additional feature => color highlighting
*   dev/: to test everything works properly before merge to the main brance
*   master: Main branch 


### ⚙️ Design Decisions & Features

# My Software Project
    1. create a function for consistantly repeated logic
    2. contains the purpose of the function  when naming the helper function
    3. test the codes simultaneously with function implementation to ensure that the function works properly

# Consulted Peers:
Chloe Shin - Discussed effective way to implement Spreadsheets.

# Time Expenditures:
    AS6: Predicted Hours:          20        Actual Hours:      16

# References:

    1. C# Hashcode - https://learn.microsoft.com/en-us/dotnet/api/system.hashcode?view=net-9.0
    2. C# lookup - https://learn.microsoft.com/en-us/dotnet/api/system.linq.lookup-2?view=net-9.0
    3. C# IEnumerable - https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=net-9.0
    4. C# Exceptions - https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/
    5.XML:  https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/recommended-tags
    6. XML Writer -  https://learn.microsoft.com/en-us/dotnet/api/system.xml.xmlwriter?view=net-9.0