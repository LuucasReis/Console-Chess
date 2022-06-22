using tabuleiro;
namespace Xadrez
{
    public class Peao : Peca
    {
        private PartidaXadrez Partida;
        public Peao(Tabuleiro tab, Cor cor, PartidaXadrez partida): base(tab, cor)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool existeInimigo(Posicao pos) {
            Peca p = Tab_peca.peca(pos);
            return p != null && p.Cor_peca != Cor_peca;
        }

        private bool livre(Posicao pos) {
            return Tab_peca.peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab_peca.Linhas_tab, Tab_peca.Colunas_tab];

            Posicao pos = new Posicao(0, 0);

            if (Cor_peca == Cor.Branca) 
            {
                pos.DefinirValores(Posicao_peca.Linha - 1, Posicao_peca.Coluna);
                if (Tab_peca.ValidaPosicao(pos) && livre(pos)) 
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                
                pos.DefinirValores(Posicao_peca.Linha - 2, Posicao_peca.Coluna);
                Posicao p2 = new Posicao(Posicao_peca.Linha - 1, Posicao_peca.Coluna);
                if (Tab_peca.ValidaPosicao(p2) && livre(p2) && Tab_peca.ValidaPosicao(pos) && livre(pos) && QuantidadeMov == 0) 
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao_peca.Linha - 1, Posicao_peca.Coluna - 1);
                if (Tab_peca.ValidaPosicao(pos) && existeInimigo(pos)) 
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao_peca.Linha - 1, Posicao_peca.Coluna + 1);
                if (Tab_peca.ValidaPosicao(pos) && existeInimigo(pos)) 
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //Jogada Especial - En Passant (Brancas)
                if (Posicao_peca.Linha == 3)
                {
                    Posicao esquerda_peao = new Posicao(Posicao_peca.Linha, Posicao_peca.Coluna -1 );
                    if (Tab_peca.ValidaPosicao(esquerda_peao) && existeInimigo(esquerda_peao) && Tab_peca.peca(esquerda_peao) == Partida.PossivelEnPassant)
                    {
                        mat[esquerda_peao.Linha -1, esquerda_peao.Coluna] = true;
                    }

                     Posicao direita_peao = new Posicao(Posicao_peca.Linha, Posicao_peca.Coluna +1 );
                    if (Tab_peca.ValidaPosicao(direita_peao) && existeInimigo(direita_peao) && Tab_peca.peca(direita_peao) == Partida.PossivelEnPassant)
                    {
                        mat[direita_peao.Linha -1, direita_peao.Coluna] = true;
                    }
                }
            }
            else 
            {
                pos.DefinirValores(Posicao_peca.Linha + 1, Posicao_peca.Coluna);
                if (Tab_peca.ValidaPosicao(pos) && livre(pos)) 
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao_peca.Linha + 2, Posicao_peca.Coluna);
                Posicao p2 = new Posicao(Posicao_peca.Linha + 1, Posicao_peca.Coluna);
                if (Tab_peca.ValidaPosicao(p2) && livre(p2) && Tab_peca.ValidaPosicao(pos) && livre(pos) && QuantidadeMov == 0) 
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao_peca.Linha + 1, Posicao_peca.Coluna - 1);
                if (Tab_peca.ValidaPosicao(pos) && existeInimigo(pos)) 
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao_peca.Linha + 1, Posicao_peca.Coluna + 1);
                if (Tab_peca.ValidaPosicao(pos) && existeInimigo(pos)) 
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //Jogada Especial - En Passant (Pretas)
                if (Posicao_peca.Linha == 4)
                {
                    Posicao esquerda_peao = new Posicao(Posicao_peca.Linha, Posicao_peca.Coluna -1 );
                    if (Tab_peca.ValidaPosicao(esquerda_peao) && existeInimigo(esquerda_peao) && Tab_peca.peca(esquerda_peao) == Partida.PossivelEnPassant)
                    {
                        mat[esquerda_peao.Linha +1, esquerda_peao.Coluna] = true;
                    }

                     Posicao direita_peao = new Posicao(Posicao_peca.Linha, Posicao_peca.Coluna +1 );
                    if (Tab_peca.ValidaPosicao(direita_peao) && existeInimigo(direita_peao) && Tab_peca.peca(direita_peao) == Partida.PossivelEnPassant)
                    {
                        mat[direita_peao.Linha +1, direita_peao.Coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}
        