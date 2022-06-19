using Chess.Execptions;
namespace tabuleiro
{
    public class Tabuleiro
    {
        public int Linhas_tab {get; set;}
        public int Colunas_tab {get; set;}
        private Peca[,] pecas_tab;

        public Tabuleiro()
        {
        }

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas_tab= linhas;
            Colunas_tab= colunas;
            pecas_tab= new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas_tab[linha, coluna];
        }

        public Peca peca(Posicao p)
        {
            return pecas_tab[p.Linha, p.Coluna];
        }
        
        public bool ExistePeca(Posicao p)
        {   
            ExceptionPosicao(p);
            return peca(p) != null;
        }
        public bool ValidaPosicao(Posicao p)
        {
            if (p.Linha < 0 || p.Linha >= Linhas_tab || p.Coluna<0 || p.Coluna >= Colunas_tab)
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
            pecas_tab[posicion.Linha, posicion.Coluna] = p;
            p.Posicao_peca= posicion;
        }
    }
}