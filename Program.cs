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
                PartidaXadrez partida = new PartidaXadrez();

                while (!partida.PartidaTerminada)
                {   
                    try{
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.Write("Escolha a peça que quer movimentar pela posicao: ");
                        Posicao Origem = Tela.LerPosicaoXadrez().ConverterPosicao();
                        partida.ValidarPosicaoOrigem(Origem);
                        bool[,] posicoespossiveis = partida.Tab_pt.peca(Origem).MovimentosPossiveis();
                        
                        Console.Clear();
                        Tela.DisplayTela(partida.Tab_pt, posicoespossiveis, partida);
                        

                        Console.WriteLine();
                        Console.Write("Escolha a posição de destino: ");
                        Posicao Destino = Tela.LerPosicaoXadrez().ConverterPosicao();
                        partida.ValidarPosicaoDestino(Origem,Destino);
                        partida.RealizaJogada(Origem, Destino);
                        
                        
                        }
                    catch(DomainException e){
                        
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }
                Console.Clear();
                Tela.ImprimirPartida(partida);
                
            }

            catch(DomainException e)
            {
                
                Console.WriteLine(e.Message);
            }
        }
    }
}