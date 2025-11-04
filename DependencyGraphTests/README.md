```
Author:    Chloe Shin
Partner:    None
Date:       20-Sep-2025
Course:     CS 3500,  UAC,ECE
GitHub ID:  purp1ish
Repo:       https://github.com/Habtamu-Fall2025-CS3500/spreadsheet-purp1ish
Commit #:   a0acf008da3764ca315dae4581c0cbeedd686855
Project:    Dependency Graph
Copyright:  CS 3500 and Chloe Shin - This work may not be copied for use in Academic Coursework.
```

# Comments to DependencyGraphTest:

The test project validates the functionality of the DependencyGraph class by ensuring that all required operations behave as expected.
The tests cover adding and removing dependencies, replacing dependents and dependees, enumerating relationships, handling edge cases such as duplicates and self-dependencies, and stress-testing with large datasets.
Additional tests were added to confirm that exceptions are thrown for invalid inputs (null or empty strings) and to verify consistency between dependents and dependees.
Together, this test suite provides strong coverage of the library and helps assure correctness through automated validation.

# Assignment Specific Topics

This assignment highlights the role of unit testing in software development, especially in Test-Driven Development (TDD).
By writing tests first, developers can better understand the expected behavior of their library and immediately catch mistakes during implementation.
The DependencyGraph structure models ordered pairs (s, t) representing dependency relationships and provides operations to query, update, and replace these relationships.
Through the test suite, key topics such as exception handling, collection manipulation, data consistency, and code coverage are demonstrated, reinforcing the importance of testing as part of the development cycle.

# References:

    1. Microsoft - How to use Unit Test in C# - https://learn.microsoft.com/ko-kr/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2022
    2. Microsoft - How to use MS test in C# - https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest 
