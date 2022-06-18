using tabuleiro;
using Xadrez;
namespace Chess_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Tabuleiro x = new Tabuleiro(8,8);
            
            x.ColocarPeca(new Rei(x, Cor.Preta),new Posicao(0,0));
            x.ColocarPeca(new Torre(x, Cor.Preta),new Posicao(1,3));
            x.ColocarPeca(new Torre(x, Cor.Preta),new Posicao(2,4));

            Tela.DisplayTela(x);
            Console.ReadLine();
        }
    }
}