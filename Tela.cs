using tabuleiro;
using Xadrez;
using System.Collections.Generic;
namespace Chess_Console
{
    public class Tela
    {   
        public static void ImprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Peças Capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.SepararPecasCapturadas(Cor.Branca));
            Console.Write(" Pretas: ");
            ImprimirConjunto(partida.SepararPecasCapturadas(Cor.Preta));
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca p in conjunto)
            {
                Console.Write(p + ",");
            }
            Console.Write("]");
        }
        public static void DisplayTela(Tabuleiro tab)
        {
            for (int i=0; i < tab.Linhas_tab; i++)
            {
                Console.Write(tab.Linhas_tab - i + " ");
                for (int j=0; j< tab.Colunas_tab; j++)
                {
                    ImprimirPecas(tab.peca(i,j));
                }
                
                Console.WriteLine();
            }

            Console.Write("  ");
            char letra = 'a';
            for (int i=0 ; i < tab.Colunas_tab; i++)
            {
                Console.Write((char)(letra + i)+ " ");
            }
        }

        public static void DisplayTela(Tabuleiro tab, bool[,]displayposicoes)
        {
            ConsoleColor fundo_original = Console.BackgroundColor;
            ConsoleColor fundo_alterado = ConsoleColor.DarkGray;
            for (int i=0; i < tab.Linhas_tab; i++)
            {
                Console.Write(tab.Linhas_tab - i + " ");
                for (int j=0; j< tab.Colunas_tab; j++)
                {
                    if (displayposicoes[i,j])
                    {
                        Console.BackgroundColor = fundo_alterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundo_original;
                    }
                    ImprimirPecas(tab.peca(i,j));
                    
                }
                
                Console.WriteLine();
                Console.BackgroundColor = fundo_original;
            }

            Console.Write("  ");
            char letra = 'a';
            for (int i=0 ; i < tab.Colunas_tab; i++)
            {
                Console.Write((char)(letra + i)+ " ");
            }
        }
        public static void ImprimirPecas(Peca peca)
        {   
            if (peca == null)
            {
                Console.Write("- ");
            }

            else
            {
                if (peca.Cor_peca == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor padrao = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = padrao;
                }
                Console.Write(" ");
            }
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string mov = Console.ReadLine();
            char Coluna_mov = mov[0];
            int linha_mov = int.Parse(mov[1]+ "");
            return new PosicaoXadrez(Coluna_mov, linha_mov);
        }    
    }
}