# StringCalculator

# How to use

1. Download or clone the repository
1. Open the StringCalculator.sln file using Visual Studio
1. Run the StringCalculator.UI application
1. Happy calculations. See below for basic examples

# Examples

- '1,2,3' will give a result of 6 - The default delimiter is ','
- Custom delimiter: '//;\n1;2' will give a result of 3
- Custom long delimiter: '//[%%%]\n1%%%2' will give a result of 3
- Multiple delimiters: '//[^^^][&]\n1^^^2&3' will give a result of 6

# Important Notes
- New line ('\n') is always used as a delimiter whether you specify custom delimiter(s) or not
