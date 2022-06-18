namespace tabuleiro
{
    public class Tabuleiro
    {
        public int Linhas {get; set;}
        public int Colunas {get; set;}
        private Peca[,] pecas;

        public Tabuleiro()
        {
        }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas= linhas;
            Colunas= colunas;
            pecas= new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public void ColocarPeca(Peca p, Posicao posicion)
        {
            pecas[posicion.Linha, posicion.Coluna] = p;
            p.Posicao= posicion;
        }
    }
}