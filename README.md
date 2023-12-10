# [WIP !] Operation result boilerplate in C#
This is an operation result pattern boilerplate tailored for use in different scenarios.
## What is the operation result pattern?
This pattern is useful when you need to handle unsuccessful outcomes within your code in any other way than throwing an exception and catching it in one place. If you want to have some logic around tackling errors at different levels of your architecture or you build a library which may me used in different kinds of architectures the operation result pattern is probably the best versatile way for interfacing with your library. On the other hand, this pattern complicates the code the result operations.
## How to use it
* If your method resulted with success return `Result.Success()`
* If your method resulted unsuccessfully but it is **an expected error** like the bad request in HTTP then return `Result.Failure()`
* If your method resulted unsuccessfully but it is **an unexpected error** like the internal server error in HTTP then throw an exception because everything has fallen down and we need to know about that by any means.

## Work in progress...
