using System;
using LanguageExt;
using System.Runtime.CompilerServices;
using static LanguageExt.Prelude;
using static System.Console;

static int EvalWith5ThenAdd2(Func<int, int> fn) => fn(5) + 2;
var square = (int x) => x * x;
PrintWithExpression(EvalWith5ThenAdd2(square));

static Func<int, int> MultipierGenerator(int toMultiply) => x => x * toMultiply;
var multiplyBy3 = MultipierGenerator(3);
PrintWithExpression(multiplyBy3(2));
var multiplyBy200 = MultipierGenerator(200);
PrintWithExpression(multiplyBy200(2));
var multiplyBy100000 = MultipierGenerator(multiplyBy200(500));
PrintWithExpression(multiplyBy100000(7));


static void PrintWithExpression(object result, [CallerArgumentExpression("result")] string? expression = null)
{
    if (!string.IsNullOrWhiteSpace(expression))
    {
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("＞" + expression);
        ResetColor();
    }

    string output = result switch
    {
        int i => i.ToString("#,##0"),
        double d => d.ToString("#,##0.#"),
        decimal d => d.ToString("#,##0.#"),
        _ => result?.ToString() ?? "<NULL>"
    };

    WriteLine("      " + output);
}