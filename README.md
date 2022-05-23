# Research

Fastest way to read a text file.
https://cc.davelozinski.com/c-sharp/fastest-way-to-read-text-files

# #Assumptions

- I have filtered panctuation marks out to make problem simpler. Pantuation marks lose context after filtering anyway.

# #Notes

- Introduces readonly variables for delimiters, punctuation marks and wovels. It maybe a better idea to use repository pattersn for such static data and keep the values in the DB. This will enable runtime changes when needed.
- I have tested "reading the file" with different input files. Logic of filters is unit tested.
- Focus in this solution is given to the memory complexity. Computaion can be enhanced by dividing parallel processing the different part of the file in parallel. This will be achieved by starting to read the file from different indexes.
- Passing the filters in as a Predicate list enables us to choose filters at runtime.
- This solution can be enhanced. Development is left at this state due to time restriction.
