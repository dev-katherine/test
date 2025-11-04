```
Author: [Katherine Jang]
Partner:    None
Date:       30-Sep-2025
Course:     CS 3500, University of Utah Asia Campus, ECE
GitHub ID:  [dev-katherine]
Repo:       https://github.com/Habtamu-Fall2025-CS3500/spreadsheet-dev-katherine
Commit #:  ae39ecb66d25e78c23b2db3193085dbf937b6841
Solution:   Spreadsheet
Promect:   Formula
Copyright:  CS 3500 and Katherine Jang - This work may not be copied for use in Academic Coursework.
```

# Comments to Evaluators:
     Formula Evaluator receives a infix notation. 
     Make sure the infix expression is not empty and tokenize the expression by number and operator. 
     Tokens are pushed to OperatorStck or perform operations based on their respective priorities and roles.
     Numbers are pushed to ValueStck or entered into the stack after the operation has been performed.
     If the order of the operator and the number determines that the infix expression does not fit, and if unacceptable characters come in, the error is thrown.
     If only one element is left in the ValueStck, and all the operation evaluated, return the result value.

# Assignment Specific Topics

The library calculates the expressions expressed in the infix expression.
This library is implemented a middle evaluator using the stack and applied a method to handle exceptions such as parentheses and operator priorities.  In this version, formula with variables are now available. 

# Consulted Peers:
Chloe Shin - Discussed effective reference search and utilzation & solved github branching issues.

# Time Expenditures:
    Predicted Hours:          12        Actual Hours:       7.5


# References:

    1. C# Hashcode - https://learn.microsoft.com/en-us/dotnet/api/system.hashcode?view=net-9.0
    2. C# lookup - https://learn.microsoft.com/en-us/dotnet/api/system.linq.lookup-2?view=net-9.0
    3. C# IEnumerable - https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable?view=net-9.0