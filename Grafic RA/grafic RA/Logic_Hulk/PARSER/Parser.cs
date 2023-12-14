using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;

namespace Logic_RA
{
    public static class Parser
    {
        public static (int, Expressions) L(List<Token> tokens, int actual)
        {
            //Ronald
            if(tokens.Count == 0)return (0,null);
            var result = M(tokens, actual);
            if (result.Item1 == tokens.Count - 1 && tokens[result.Item1].Type == Token.TokenType.EndLine) return result;
            Error error = new TypeError(ErrorCode.SyntacticError, " Where is ; ?");
            App.Error(error.Text());
            return (0, null);

            /* Amaranto
            var result = M(tokens, actual);

            while (tokens[result.Item1+1].Type != Token.TokenType.EndLine)
            {
                result = M(tokens, result.Item1);
            }
            return result;
            // Error error = new TypeError(ErrorCode.SyntacticError, " Where is ; ?");
            //App.Error(error.Text());
            // return (0, null)!;
            */
        }
        public static (int, Expressions) M(List<Token> tokens, int actual, Expressions last = null)
        {

            if (tokens[actual].Type == Token.TokenType.Token_Point)
            {
                if (tokens[actual + 1].Type == Token.TokenType.Identifier)
                {
                    Point point_expression = new Point(tokens[actual], Utils.Coordenadas());
                    Utils.Dictionary_Value.Add(tokens[actual + 1], Point.GetArgument(point_expression));
                    Utils.Dictionary_Type.Add(tokens[actual + 1], Token.TokenType.Token_Point);
                    return (actual + 2, point_expression);
                }
            }
            if (tokens[actual].Type == Token.TokenType.Token_Draw)
            {
                if (tokens[actual + 1].Type == Token.TokenType.Identifier)
                {
                    //esto es lo q da error en los 2   
                    Utils.Result_Dictionary.Add(Utils.Dictionary_Type[tokens[actual + 1]], Utils.Dictionary_Value[tokens[actual + 1]]);
                }
            }


            if (tokens[actual].Type == Token.TokenType.Print)
            {
                if (tokens[actual + 1].Type == Token.TokenType.Open_Paren)
                {
                    var result = M(tokens, actual + 2, last);
                    if (tokens[result.Item1].Type == Token.TokenType.Close_Paren)
                    {
                        return (result.Item1 + 1, result.Item2);
                    }
                    Error error_paren = new TypeError(ErrorCode.SyntacticError, " Where is ) ?");
                    App.Error(error_paren.Text());
                }
                Error error = new TypeError(ErrorCode.SyntacticError, " Where is ( ?");
                App.Error(error.Text());
            }
            if (tokens[actual].Type == Token.TokenType.Token_If)
            {
                if (tokens[actual + 1].Type == Token.TokenType.Open_Paren)
                {
                    var if_part = M(tokens, actual + 2, last);
                    //  var body = M(tokens, if_part.Item1, last);
                    if (tokens[if_part.Item1].Type == Token.TokenType.Close_Paren)
                    {
                        var body = M(tokens, if_part.Item1 + 1);
                        if (tokens[body.Item1].Type == Token.TokenType.Token_Else)
                        {
                            var else_part = M(tokens, body.Item1 + 1);
                            return (else_part.Item1, new ConditionalExpresions(if_part.Item2, body.Item2, else_part.Item2));
                        }
                        Error error = new TypeError(ErrorCode.SyntacticError, " The Conditional needs a else part");
                        App.Error(error.Text());
                    }
                    Error error_close_paren = new TypeError(ErrorCode.SyntacticError, " Where is ) ?");
                    App.Error(error_close_paren.Text());
                }
                Error error_open_paren = new TypeError(ErrorCode.SyntacticError, " Where is ( ?");
                App.Error(error_open_paren.Text());
            }
            if (tokens[actual].Type == Token.TokenType.Token_Let)
            {
                if (tokens[actual + 1].Type == Token.TokenType.Identifier)
                {
                    if (tokens[actual + 2].Type == Token.TokenType.Token_Equal)
                    {
                        var result_let = M(tokens, actual + 3);
                        Expressions id = new Assignment(tokens[actual + 1], result_let.Item2);

                        if (tokens[result_let.Item1].Type == Token.TokenType.Comma)
                        {
                            tokens.Insert(result_let.Item1 + 1, new Token(Token.TokenType.Token_Let, "let"));
                            return M(tokens, result_let.Item1 + 1);
                            //Expressions id2 = new Assignment(tokens[actual + 1], result.Item2);
                            // Expressions second=new LetExpresions(id,result.Item2);
                            //return (result.Item1, second);
                        }
                        if (tokens[result_let.Item1].Type == Token.TokenType.Token_In)
                        {
                            var result_in = M(tokens, result_let.Item1 + 1);
                            Expressions second = new LetExpresions(id, result_in.Item2);
                            return (result_in.Item1, second);
                        }
                        Error error_in_comma = new TypeError(ErrorCode.SyntacticError, " The part needs a in or comma");
                        App.Error(error_in_comma.Text());
                    }
                    Error error_equal = new TypeError(ErrorCode.SyntacticError, " Where is = ?");
                    App.Error(error_equal.Text());
                }
                Error error = new TypeError(ErrorCode.SyntacticError, " Where is identifier ?");
                App.Error(error.Text());
            }

            return A(tokens, actual, last);
        }



        public static (int, Expressions) A(List<Token> tokens, int actual, Expressions last)
        {
            (int, Expressions) result_z;
            if (tokens[actual].Type == Token.TokenType.Token_Not)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions not_expression = new Unary(result_B.Item2, Unary.Operators.Not);
                result_z = Z(tokens, result_B.Item1, not_expression);
            }
            else
            {
                var result_B = B(tokens, actual, last);
                result_z = Z(tokens, result_B.Item1, result_B.Item2);
            }
            return result_z;
        }
        public static (int, Expressions) Z(List<Token> tokens, int actual, Expressions last)
        {
            if (tokens[actual].Type == Token.TokenType.Token_And)
            {
                var result_A = A(tokens, actual + 1, last);
                Expressions and_expresions = new BoolExpresions(last, result_A.Item2, BoolExpresions.OperatorsLogic.And);
                return (result_A.Item1, and_expresions);
            }
            if (tokens[actual].Type == Token.TokenType.Token_Or)
            {
                var result_A = A(tokens, actual + 1, last);
                Expressions or_expresions = new BoolExpresions(last, result_A.Item2, BoolExpresions.OperatorsLogic.Or);
                return (result_A.Item1, or_expresions);
            }
            return (actual, last);
        }
        public static (int, Expressions) B(List<Token> tokens, int actual, Expressions last)
        {
            var result_W = W(tokens, actual, last);
            var result_E = E(tokens, result_W.Item1, result_W.Item2);
            return result_E;
        }
        public static (int, Expressions) E(List<Token> tokens, int actual, Expressions last)
        {
            if (tokens[actual].Type == Token.TokenType.Token_DoubleEqual)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions double_equal_expresions = new BoolExpresions(last, result_B.Item2, BoolExpresions.OperatorsComparison.DoubleEqual);
                return (result_B.Item1, double_equal_expresions);
            }

            if (tokens[actual].Type == Token.TokenType.Token_LessOrEqual)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions Less_Or_Equal_expresions = new BoolExpresions(last, result_B.Item2, BoolExpresions.OperatorsComparison.LessOrEqual);
                return (result_B.Item1, Less_Or_Equal_expresions);
            }

            if (tokens[actual].Type == Token.TokenType.Token_MoreOrEqual)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions More_Or_Equal_expresions = new BoolExpresions(last, result_B.Item2, BoolExpresions.OperatorsComparison.MoreOrEqual);
                return (result_B.Item1, More_Or_Equal_expresions);
            }

            if (tokens[actual].Type == Token.TokenType.Token_NoEqual)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions No_Equal_expresions = new BoolExpresions(last, result_B.Item2, BoolExpresions.OperatorsComparison.NoEqual);
                return (result_B.Item1, No_Equal_expresions);
            }

            if (tokens[actual].Type == Token.TokenType.Token_Less)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions Less_expresions = new BoolExpresions(last, result_B.Item2, BoolExpresions.OperatorsComparison.Less);
                return (result_B.Item1, Less_expresions);
            }

            if (tokens[actual].Type == Token.TokenType.Token_More)
            {
                var result_B = B(tokens, actual + 1, last);
                Expressions More_expresions = new BoolExpresions(last, result_B.Item2, BoolExpresions.OperatorsComparison.More);
                return (result_B.Item1, More_expresions);
            }
            return (actual, last);
        }
        public static (int, Expressions) W(List<Token> tokens, int actual, Expressions last)
        {
            var result_F = F(tokens, actual, last);
            var result_X = X(tokens, result_F.Item1, result_F.Item2);
            return result_X;
        }
        public static (int, Expressions) X(List<Token> tokens, int actual, Expressions last)
        {
            if (tokens[actual].Type == Token.TokenType.Token_Sum)
            {
                var result_W = W(tokens, actual + 1, last);
                Expressions sum_expresions = new ArithmeticBinary(last, result_W.Item2, ArithmeticBinary.Operators.add);
                return (result_W.Item1, sum_expresions);
            }
            if (tokens[actual].Type == Token.TokenType.Token_Dif)
            {
                var result_W = W(tokens, actual + 1, last);
                Expressions dif_expresions = new ArithmeticBinary(last, result_W.Item2, ArithmeticBinary.Operators.dif);
                return (result_W.Item1, dif_expresions);
            }
            if (tokens[actual].Type == Token.TokenType.Token_Concat)
            {
                var result_W = W(tokens, actual + 1, last);
                Expressions concat_expresions = new ArithmeticBinary(last, result_W.Item2, ArithmeticBinary.Operators.Concat);
                return (result_W.Item1, concat_expresions);
            }
            return (actual, last);
        }
        public static (int, Expressions) F(List<Token> tokens, int actual, Expressions last)
        {
            var result_T = T(tokens, actual, last);
            var result_P = P(tokens, result_T.Item1, result_T.Item2);
            return result_P;
        }
        public static (int, Expressions) P(List<Token> tokens, int actual, Expressions last)
        {
            if (tokens[actual].Type == Token.TokenType.Token_Multi)
            {
                var result_F = F(tokens, actual + 1, last);
                Expressions multi_expresions = new ArithmeticBinary(last, result_F.Item2, ArithmeticBinary.Operators.multi);
                return (result_F.Item1, multi_expresions);
            }
            if (tokens[actual].Type == Token.TokenType.Token_Div)
            {
                var result_F = F(tokens, actual + 1, last);
                Expressions div_expresions = new ArithmeticBinary(last, result_F.Item2, ArithmeticBinary.Operators.div);
                return (result_F.Item1, div_expresions);
            }
            if (tokens[actual].Type == Token.TokenType.Token_Pow)
            {
                var result_F = F(tokens, actual + 1, last);
                Expressions pow_expresions = new ArithmeticBinary(last, result_F.Item2, ArithmeticBinary.Operators.Pow);
                return (result_F.Item1, pow_expresions);
            }
            if (tokens[actual].Type == Token.TokenType.Token_Mod)
            {
                var result_F = F(tokens, actual + 1, last);
                Expressions porcent_expresions = new ArithmeticBinary(last, result_F.Item2, ArithmeticBinary.Operators.Mod);
                return (result_F.Item1, porcent_expresions);
            }
            return (actual, last);
        }
        public static (int, Expressions) T(List<Token> tokens, int actual, Expressions last)
        {
            if (tokens[actual].Type == Token.TokenType.Number_Literal)
            {
                return (actual + 1, new Atomic(tokens[actual]));
            }
            if (tokens[actual].Type == Token.TokenType.Chain_Literals)
            {
                return (actual + 1, new Atomic(tokens[actual]));
            }
            if (tokens[actual].Type == Token.TokenType.Token_False)
            {
                return (actual + 1, new Atomic(tokens[actual]));
            }
            if (tokens[actual].Type == Token.TokenType.Token_True)
            {
                return (actual + 1, new Atomic(tokens[actual]));
            }
            if (tokens[actual].Type == Token.TokenType.Token_PI)
            {
                return (actual + 1, new Atomic(tokens[actual]));
            }
            if (tokens[actual].Type == Token.TokenType.Token_Sen)
            {
                var result_W = W(tokens, actual + 1, last);
                return (result_W.Item1, new Unary(result_W.Item2, Unary.Operators.Sen));
            }
            if (tokens[actual].Type == Token.TokenType.Token_Cos)
            {
                var result_W = W(tokens, actual + 1, last);
                return (result_W.Item1, new Unary(result_W.Item2, Unary.Operators.Cos));
            }
            if (tokens[actual].Type == Token.TokenType.Token_Tan)
            {
                var result_W = W(tokens, actual + 1, last);
                return (result_W.Item1, new Unary(result_W.Item2, Unary.Operators.Tan));
            }
            if (tokens[actual].Type == Token.TokenType.Token_Cot)
            {
                var result_W = W(tokens, actual + 1, last);
                return (result_W.Item1, new Unary(result_W.Item2, Unary.Operators.Cot));
            }
            if (tokens[actual].Type == Token.TokenType.Token_Sqrt)
            {
                var result_W = W(tokens, actual + 1, last);
                return (result_W.Item1, new Unary(result_W.Item2, Unary.Operators.Sqrt));
            }
            if (tokens[actual].Type == Token.TokenType.Token_Log)
            {
                var result_W = W(tokens, actual + 1, last);
                return (result_W.Item1, new Unary(result_W.Item2, Unary.Operators.Log));
            }
            if (tokens[actual].Type == Token.TokenType.Open_Paren)
            {
                var result_M = M(tokens, actual + 1, last);
                if (tokens[result_M.Item1].Type == Token.TokenType.Close_Paren)
                {
                    return (result_M.Item1 + 1, result_M.Item2);
                }
                else throw new System.Exception();
            }
            if (tokens[actual].Type == Token.TokenType.Identifier)
            {
                return (actual + 1, new iDExpresions(tokens[actual]));
            }
            if (tokens[actual].Type == Token.TokenType.Close_Paren)
            {
                return (actual, last);
            }
            if (tokens[actual].Type == Token.TokenType.Token_Point)
            {

            }
            throw new System.Exception();
        }
    }
}