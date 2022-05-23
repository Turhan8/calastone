# Research

Fastest way to read a text file.
https://cc.davelozinski.com/c-sharp/fastest-way-to-read-text-files

# Assumptions

- It is observed that words are seperated by these delimitters ' ', '.', '?' This will end up removing some quotations from the final text. Ideally we should enforce single space as the only delimitter. This would be the gramatically correct solution.
- Assumed that ASCII code encoding is suffient. Can increase this to Unicode to include non-English characters.

# Notes

- Introduced readonly variables for delimiters, and wovels. We use repository pattersn for such static data and keep the values in the DB. This will enable runtime changes when needed.
- I have tested "reading the file" with different input files. Logic of filters is unit tested.
- Focus in this solution is given to the memory complexity. Computaion can be enhanced by dividing parallel processing the different part of the file in parallel. This will be achieved by starting to read the file from different indexes.
- Passing the filters in as a Predicate list enables us to choose filters at runtime.
- This solution can be enhanced. Development is left at this state due to time restriction.

# Changes

- Took filtering out of file reader for single responsibility principle.
- Brought back quotation marks as specs read to mean leaving them in place. However if they are connected to a filtered word, they are still removed.
- Added more filtering unit tests.
- Changed all filters to remove the word if the word is empty string after trimming whitespace.
