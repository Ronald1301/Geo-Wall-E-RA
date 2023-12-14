

using grafic_RA;
using System;

namespace Logic_RA
{
    class Program_Logic
    {
        internal static void Compile(string codigo)
        {
            //  App.Presentation();

            //string line  = "let x=10 , y=5 in x+y;";
            //string line = "print(sin(2 * PI) ^ 2 + cos(3 * PI / log(5)));";
            //string line = "let a=\"te quedó \" in print(let b=5 in if(b>=3) a @ \"bien\" else a @ \"mal\");";
            // string line = " let a=(let b=2 in b) in a+2;";
            //string line = " let a=5 in (let b=6 in b) + a;";
            // string line= " \"hello\"@ \" world\";";
            /*
            while(true){
        
                string test= Console.ReadLine()!;
                if(test==""){
                 break;
                } else line+=test;
                
            }
            */


            var result = Parser.L(LexicalAnalyzer.Tokenize(codigo.ToLower()), 0);
            //var ok = result.Item2.CheckSemantic();
            if (result.Item2 == null) Console.WriteLine (0);
            else
            {
                Console.WriteLine(result.Item2.Evaluate());
            }



        }

    }
}