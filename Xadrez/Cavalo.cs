using tabuleiro;

namespace Xadrez {

    public class Cavalo : Peca {

        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor) {
        }

        public override string ToString() {
            return "C";
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] mat = new bool[Tab_peca.Linhas_tab, Tab_peca.Colunas_tab];

            Posicao pos = new Posicao(0, 0);

            pos.DefinirValores(Posicao_peca.Linha - 1, Posicao_peca.Coluna - 2);
            if (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao_peca.Linha - 2, Posicao_peca.Coluna - 1);
            if (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao_peca.Linha - 2, Posicao_peca.Coluna + 1);
            if (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao_peca.Linha - 1, Posicao_peca.Coluna + 2);
            if (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao_peca.Linha + 1, Posicao_peca.Coluna + 2);
            if (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao_peca.Linha + 2, Posicao_peca.Coluna + 1);
            if (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao_peca.Linha + 2, Posicao_peca.Coluna - 1);
            if (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
            }
            pos.DefinirValores(Posicao_peca.Linha + 1, Posicao_peca.Coluna - 2);
            if (Tab_peca.ValidaPosicao(pos) && PodeMover(pos)) 
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }
    }
}