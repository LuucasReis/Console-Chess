using tabuleiro;
namespace Chess_Console
{
    public class Tela
    {
        public static void DisplayTela(Tabuleiro tab)
        {
            for (int i=0; i < tab.Linhas_tab; i++)
            {
                for (int j=0; j< tab.Colunas_tab; j++)
                {
                    if (tab.peca(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tab.peca(i,j) + " ");
                    }
                }
                Console.WriteLine();
            }
        
        }
    }
}