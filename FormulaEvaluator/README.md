
```
Author: [Katherine Jang]
Partner:    None
Date:       4-Sep-2025
Course:     CS 3500, University of Utah, ECE
GitHub ID:  [dev-katherine]
Repo:       https://github.com/Habtamu-Fall2025-CS3500/spreadsheet-dev-katherine
Solution:   Spreadsheet
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
This library is implemented a middle evaluator using the stack and applied a method to handle exceptions such as parentheses and operator priorities. 
Tried to distinguish between cases to be ignored and cases to be error-throwed.

# Consulted Peers:
Chole Shin

# References:

    1. C# exceptions - https://learn.microsoft.com/en-us/dotnet/api/system.exception?view=net-9.0