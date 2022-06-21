using tabuleiro;

namespace Xadrez {

    public class Dama : Peca 
    {

        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor) 
        {
        }

        public override string ToString() 
        {
            return "D";
        }

        public override bool[,] MovimentosPossiveis() 
        {
            bool[,] mat = new bool[Tab_peca.Linhas_tab, Tab_peca.Colunas_tab];

            Posicao pos = new Posicao(0, 0);

            // esquerda
            pos.DefinirValores(Posicao_peca.Linha, Posicao_peca.Coluna - 1);
            while (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab_peca.peca(pos) != null && Tab_peca.peca(pos).Cor_peca != Cor_peca) 
                {
                    break;
                }
                pos.DefinirValores(pos.Linha, pos.Coluna - 1);
            }

            // direita
            pos.DefinirValores(Posicao_peca.Linha, Posicao_peca.Coluna + 1);
            while (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab_peca.peca(pos) != null && Tab_peca.peca(pos).Cor_peca != Cor_peca) 
                {
                    break;
                }
                pos.DefinirValores(pos.Linha, pos.Coluna + 1);
            }

            // acima
            pos.DefinirValores(Posicao_peca.Linha - 1, Posicao_peca.Coluna);
            while (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab_peca.peca(pos) != null && Tab_peca.peca(pos).Cor_peca != Cor_peca) 
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna);
            }

            // abaixo
            pos.DefinirValores(Posicao_peca.Linha + 1, Posicao_peca.Coluna);
            while (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab_peca.peca(pos) != null && Tab_peca.peca(pos).Cor_peca != Cor_peca) 
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna);
            }

            // NO
            pos.DefinirValores(Posicao_peca.Linha - 1, Posicao_peca.Coluna - 1);
            while (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab_peca.peca(pos) != null && Tab_peca.peca(pos).Cor_peca != Cor_peca) 
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            // NE
            pos.DefinirValores(Posicao_peca.Linha - 1, Posicao_peca.Coluna + 1);
            while (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab_peca.peca(pos) != null && Tab_peca.peca(pos).Cor_peca != Cor_peca) 
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            // SE
            pos.DefinirValores(Posicao_peca.Linha + 1, Posicao_peca.Coluna + 1);
            while (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab_peca.peca(pos) != null && Tab_peca.peca(pos).Cor_peca != Cor_peca) 
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            // SO
            pos.DefinirValores(Posicao_peca.Linha + 1, Posicao_peca.Coluna - 1);
            while (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab_peca.peca(pos) != null && Tab_peca.peca(pos).Cor_peca != Cor_peca) 
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            return mat;
        }
    }
}