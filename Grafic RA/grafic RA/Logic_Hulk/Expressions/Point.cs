using System.Linq.Expressions;
namespace Logic_RA;
public class Point : Expressions
{
    public Token token;
    public object argument { get; }
    public Point(Token token, object argument)
    {
        this.token = token;
        this.argument = argument;
    }

    public override Token.DataType CheckSemantic()
    {
        return Token.DataType.point;
    }
     public override object Evaluate()
    {
        Utils.Dictionary_Value.Add(token, argument);

        foreach (var item in Utils.Dictionary_Value.Keys)
        {
            return Utils.Dictionary_Value[item];
        }
        throw new Exception();
    }
    public static object GetArgument(Point point)
    {
        return point.argument;
    }
}