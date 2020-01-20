# Calculator

Example:
string expression = "(2+2)"; 
double result = Parser.Start(expression); // 4

ParserFunction.AddFunction("pi", new PiFunction());
string expression2 = "pi"; 
double result = Parser.Start(expression); // 3.14