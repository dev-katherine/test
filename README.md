# Spreadsheet

```
Author: [Katherine Jang & Chloe Shin]
Partner:    None
Date:       3-Nov-2025
Course:     CS 3500, University of Utah, ECE
GitHub ID:  [dev-katherine, purp1ish]
Repo:       https://github.com/Habtamu-Fall2025-CS3500/assignment-six-spreadsheet-gui-khloe
Commit #:  33633702fe2d59d959689f637dd63e806131414a
Ssolution:   Spreadsheet
Copyright:  CS 3500, Katherine Jang, and Chloe Shin - This work may not be copied for use in Academic Coursework.
```

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


 ## Git Commit Conventions
    To maintain a clean and understandable Git history, I(we) follow commit convention.

### Naming
*   commit message must be all lowercase
*   Prefixes must be used to categorize the commit's purpose:
    *   **`feat/`** for new functionality (e.g., `feature/user-profile`).
    *   **`fix/`** for bug fixes (e.g., `fix/incorrect-tax-calculation`).
    *   **`hotfix/`** for critical production fixes (e.g., `hotfix/emergency-api-patch`).
    *   **`docs/`** for documentation changes (e.g., `docs/update-installation-steps`).
    *   **`release/`** for release version (e.g., `release/v1.0.0`).
<!-- *   If a branch is associated with a ticket, include the ticket number (e.g., `bugfix/JIRA-1444-button-fix`). -->

### Merging - Branch
*   All feature and bugfix branches must be merged into the `master` or `develop` branch via a Pull Request (PR).
*   All PRs require at least one code review and must pass all continuous integration (CI) checks before merging.
*   Once a branch is merged, please delete it from the remote repository.


# Overview of the Spreadsheet functionality

The Spreadsheet program is capable of evaluating infix notation without variable and throw an exception when the expression is invalid. 
+The Spreadsheet program is capable of managing dependencies between two or more variables. It determine the computation order of the variables.
Future extensions are evaluating infix expression with variables based on dependency.

In V2, the spreadsheet, original FormulaEvaluator has been updated as Project & class. Formulas with variables can be evaluated. 

In V3(Assignment4), the spreadsheet implement manages cell contents and dependencies, variable names, supports text, numeric, and formulas with auto recalculation


In V4(Assignement5), the spreadsheet is now available for calculate Formula and save cells(value, content) into the file.

# Time Expenditures:

    1. Assignment One:   Predicted Hours:          12        Actual Hours:       13

    2. Assignment Two:   Predicted Hours:          11        Actual Hours:       7

    3. Assignment Three:   Predicted Hours:          12        Actual Hours:       7.5

    4. Assignment Four:   Predicted Hours:          14        Actual Hours:       9
    5. Assignment Five:   Predicted Hours:          16        Actual Hours:       11
    6. Assignment Six:   Predicted Hours:          16        Actual Hours:       11
