namespace tabuleiro
{
    public abstract class Peca
    {
        public Posicao Posicao_peca {get; set;}
        public Cor Cor_peca {get; protected set;}
        public int QuantidadeMov {get; protected set;}
        public Tabuleiro Tab_peca {get; protected set;}

        public Peca()
        {
        }

        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao_peca = null;
            Cor_peca = cor;
            Tab_peca = tab;
            QuantidadeMov = 0;
        }

        public void Decrementou()
        {
            QuantidadeMov--;
        }
        public void Movimentou()
        {
            QuantidadeMov++;
        }

        protected bool PodeMover(Posicao pos)
        {
            Peca p = Tab_peca.peca(pos);
            return p== null || p.Cor_peca != Cor_peca;
        }

        public bool ExisteMovimentosPossiveis()
        {
            bool[,] mat = MovimentosPossiveis();
            for (int i = 0; i < Tab_peca.Linhas_tab; i++)
            {
                for (int j = 0 ; j < Tab_peca.Colunas_tab; j++ )
                {
                    if (mat[i,j])
                    {
                        
                        return true;
                    }
                }
            }
            
            return false;
        }
        
        public bool PodeMoverpara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }
        public abstract bool[,] MovimentosPossiveis();
        
    }
}