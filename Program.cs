using tabuleiro;
using Xadrez;
using Chess.Execptions;
namespace Chess_Console
{
    public class Program
    {
        static void Main(string[] args)
        {   
            try
            {   
                Tabuleiro x = new Tabuleiro(8,8);
            
                x.ColocarPeca(new Rei(x, Cor.Preta),new Posicao(0,0));
                x.ColocarPeca(new Torre(x, Cor.Preta),new Posicao(1,3));
                x.ColocarPeca(new Torre(x, Cor.Preta),new Posicao(0,2));

                x.ColocarPeca(new Torre(x, Cor.Branca), new Posicao(0,1));
                x.ColocarPeca(new Torre(x, Cor.Branca),new Posicao(1,4));
                x.ColocarPeca(new Torre(x, Cor.Branca),new Posicao(0,3));


                Tela.DisplayTela(x);
                Console.ReadLine();
            }

            catch(DomainException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}