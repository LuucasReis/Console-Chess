using Chess.Execptions;
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

        public Peca peca(Posicao p)
        {
            return pecas[p.Linha, p.Coluna];
        }
        
        public bool ExistePeca(Posicao p)
        {   
            ExceptionPosicao(p);
            return peca(p) != null;
        }
        public bool ValidaPosicao(Posicao p)
        {
            if (p.Linha < 0 || p.Linha >= Linhas || p.Coluna<0 || p.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ExceptionPosicao(Posicao p)
        {
            if (!ValidaPosicao(p))
            {
                throw  new DomainException ("Posição Inválida!!");
            }
        }

        public void ColocarPeca(Peca p, Posicao posicion)
        {   
            if (ExistePeca(posicion))
            {
                throw new DomainException ("Esta posição ja esta ocupada!");
            }
            pecas[posicion.Linha, posicion.Coluna] = p;
            p.Posicao= posicion;
        }
    }
}