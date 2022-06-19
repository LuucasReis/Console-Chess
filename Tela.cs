using tabuleiro;
namespace Chess_Console
{
    public class Tela
    {
        public static void DisplayTela(Tabuleiro tab)
        {
            for (int i=0; i < tab.Linhas_tab; i++)
            {
                Console.Write(tab.Linhas_tab - i + " ");
                for (int j=0; j< tab.Colunas_tab; j++)
                {
                    if (tab.peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        ImprimirPecas(tab.peca(i,j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

            Console.Write("  ");
            char letra = 'A';
            for (int i=0 ; i < tab.Colunas_tab; i++)
            {
                Console.Write((char)(letra + i)+ " ");
            }
        }
        public static void ImprimirPecas(Peca peca)
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
        }    
    }
}