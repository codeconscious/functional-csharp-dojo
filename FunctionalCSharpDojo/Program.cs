using System;
using LanguageExt;
using System.Runtime.CompilerServices;
using static LanguageExt.Prelude;
using static System.Console;

static void PrintWithExpression(object result, [CallerArgumentExpression("result")] string? expression = null)
{
    if (!string.IsNullOrWhiteSpace(expression))
    {
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("＞" + expression);
        ResetColor();
    }

    WriteLine("      " + result);
}

static int EvalWith5ThenAdd2(Func<int, int> fn) => fn(5) + 2;
var square = (int x) => x * x;
PrintWithExpression(EvalWith5ThenAdd2(square));

static Func<int, int> MultipierGenerator(int toMultiply) => x => x * toMultiply;
var multipierBy3 = MultipierGenerator(3);
var multipierBy200 = MultipierGenerator(200);
PrintWithExpression(multipierBy3(2));
PrintWithExpression(multipierBy200(2));
