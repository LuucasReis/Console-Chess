using tabuleiro;

namespace Xadrez {

    class Bispo : Peca {

        public Bispo(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "B";
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab_peca.Linhas_tab, Tab_peca.Colunas_tab];

            Posicao pos = new Posicao(0, 0);

            // Noroeste
            pos.DefinirValores(Posicao_peca.Linha - 1, Posicao_peca.Coluna - 1);
            while (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab_peca.peca(pos) != null && Tab_peca.peca(pos).Cor_peca != Cor_peca) 
                {
                    break;
                }
                pos.DefinirValores(pos.Linha -1, pos.Coluna -1);
            }

            // Nordeste
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

            // Sudeste
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

            // Sudoeste
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