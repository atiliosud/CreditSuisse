# Credit Suisse

## Question 1

Question 1 says:

``` Write a C# console application using object oriented design that classifies all trades in a given portfolio.```

With that explained, I've build this application, which reads from an input file and then convert it to instances of `Trade` class.

This class has a new property called `Risk`, witch outputs the risk of the trade.

## Question 2

Question 2 says

``` A new category was created called PEP (politically exposed person). (...) Describe in at most 1 paragrah what you must to do in your design to account for this new category```

For this, what we need to do is add a new property definition at `ITrade` interface, and then implement it at `Trade` class. After that, we just need to add this new rule at the `Risk` property.
