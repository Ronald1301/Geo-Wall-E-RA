namespace Hulk;
public static class Utils
{
 public static Dictionary<Token.TokenType,object> Result_Dictionary =new Dictionary<Token.TokenType, object>();
    public static object Coordenas()
    {
        var a = new Random().Next(1, 5);
        var b = new Random().Next(1, 5);
        return (a, b);
    }

    public static Dictionary<Token, object> Diccionary_Value = new Dictionary<Token, object>();
    public static Dictionary<Token, Token.TokenType> Diccionary_Type = new Dictionary<Token, Token.TokenType>();
}