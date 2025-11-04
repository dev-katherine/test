
```
Author: [Katherine Jang]
Partner:    None
Date:       19-Sep-2025
Course:     CS 3500, University of Utah, ECE
GitHub ID:  [dev-katherine]
Repo:       https://github.com/Habtamu-Fall2025-CS3500/spreadsheet-dev-katherine
Solution:   Spreadsheet
Copyright:  CS 3500 and Katherine Jang - This work may not be copied for use in Academic Coursework.
```

# Comments to Evaluatxors:
     This library manages dependencies between variables.  
     The class provides methods to: Add dependencies,  Remove dependencies,  Update dependencies,  Check dependency existence  
     If an invalid variable is passed, an error will be thrown.

# Assignment Specific Topics
The library manages the dependency for calculating variables. 
The dependees must be evaluated first.
The dependents must be evaluated after dependees are evaluated.

The full set of relationship should be contains in the dependees dictionary and the dependents dictionary. Most methods in this library throw an error when the argument is invalid(e.g. null)

# Consulted Peers:
None

# References:

    1. C# exceptions - https://learn.microsoft.com/en-us/dotnet/api/system.exception?view=net-9.0
    2. C# dictionary - https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-8.0
    3. C# IEnumerable - https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=net-9.0