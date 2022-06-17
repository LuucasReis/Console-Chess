using tabuleiro;
namespace Chess_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro x = new Tabuleiro(8,8);
            Tela.DisplayTela(x);
        }
    }
}