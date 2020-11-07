# How to contribute

If you're interested in contributing to this project, you should be aware of the following rules though.
Please take the time to review this guide and understand how we work. 


## Bugs

If you found a bug, please open an issue.


## Improvement

Before submitting changes, please open an issue an let's talk about it.


### Testing

The functionality of all new features *must* be checked by unit tests.


### Submitting changes

Please create a merge request on the [GitHub project page] with a clear description of what you've done. Please follow
our coding conventions (below) and make sure all of your commits are atomic.

Always write a clear log message for your commits. One-line messages are fine for small changes, but bigger changes
should look like this:

    $ git commit -m "A brief summary of the commit
    > 
    > A paragraph describing what changed and its impact."


### Coding conventions

Start reading our code and you'll get the hang of it. 

The core aspects can be boiled down to these few topics:

* We use four (4) spaces for indentation (soft tabs)
* A single line in a source file shall not be longer than 120 characters
* All files must be encoded in the UTF-8 format
* All public interfaces must be properly documented with comments parseable by Doxygen
* All binary operators (except „.“ and „->“) shall be separated from their operands by a single space.
* ...
