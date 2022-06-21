using tabuleiro;
namespace Xadrez
{
    public class Rei: Peca
    {
        public Rei(Tabuleiro tab, Cor cor): base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab_peca.peca(pos);
            return p== null || p.Cor_peca != Cor_peca;
        }
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tab_peca.Linhas_tab, Tab_peca.Colunas_tab];

            Posicao mov_posicao = new Posicao(0,0);

            //acima
            mov_posicao.DefinirValores(Posicao_peca.Linha - 1, Posicao_peca.Coluna);
            if (Tab_peca.ValidaPosicao(mov_posicao) && PodeMover(mov_posicao))
            {
                matriz[mov_posicao.Linha, mov_posicao.Coluna] = true;
            }

            //nordeste
            mov_posicao.DefinirValores(Posicao_peca.Linha - 1, Posicao_peca.Coluna+1);
            if (Tab_peca.ValidaPosicao(mov_posicao) && PodeMover(mov_posicao))
            {
                matriz[mov_posicao.Linha, mov_posicao.Coluna] = true;
            }

            //direita
            mov_posicao.DefinirValores(Posicao_peca.Linha , Posicao_peca.Coluna + 1);
            if (Tab_peca.ValidaPosicao(mov_posicao) && PodeMover(mov_posicao))
            {
                matriz[mov_posicao.Linha, mov_posicao.Coluna] = true;
            }

            //sudeste
            mov_posicao.DefinirValores(Posicao_peca.Linha + 1, Posicao_peca.Coluna + 1);
            if (Tab_peca.ValidaPosicao(mov_posicao) && PodeMover(mov_posicao))
            {
                matriz[mov_posicao.Linha, mov_posicao.Coluna] = true;
            }

            //abaixo
            mov_posicao.DefinirValores(Posicao_peca.Linha + 1, Posicao_peca.Coluna);
            if (Tab_peca.ValidaPosicao(mov_posicao) && PodeMover(mov_posicao))
            {
                matriz[mov_posicao.Linha, mov_posicao.Coluna] = true;
            }

            //sudoeste
            mov_posicao.DefinirValores(Posicao_peca.Linha + 1, Posicao_peca.Coluna - 1);
            if (Tab_peca.ValidaPosicao(mov_posicao) && PodeMover(mov_posicao))
            {
                matriz[mov_posicao.Linha, mov_posicao.Coluna] = true;
            }

            //esquerda
            mov_posicao.DefinirValores(Posicao_peca.Linha, Posicao_peca.Coluna -1);
            if (Tab_peca.ValidaPosicao(mov_posicao) && PodeMover(mov_posicao))
            {
                matriz[mov_posicao.Linha, mov_posicao.Coluna] = true;
            }

            //noroeste
            mov_posicao.DefinirValores(Posicao_peca.Linha - 1, Posicao_peca.Coluna -1);
            if (Tab_peca.ValidaPosicao(mov_posicao) && PodeMover(mov_posicao))
            {
                matriz[mov_posicao.Linha, mov_posicao.Coluna] = true;
            }

            
            return matriz;
        }
    }
}