# BackgroundCheckApp
REQUIREMENTS 
Build a service with an API for ordering background checks that accepts a first name, last name, date of birth and SSN number and returns a check results back. 

FUNCTIONAL REQUIREMENTS
Result should contain a simple model with first name, last name, date of birth, SSN number and list of 4 criminal records (just plain text eg crim rec 1, crim rec 2).
If the requested last name ends with “Clear”, the result shouldn’t contain criminal records.

DATA REQUIREMENTS
Validation
Background check is available for people age 18 or older.
Names can contain only letters.
Classification - SSN number is sensitive information. In results return masked SSN number(show just last 4 numbers)

TECHNICAL REQUIREMENTS
Use the language/framework  which you are most comfortable in (C#/ASP.NET Core is preferable)
Cover requirements with unit tests
