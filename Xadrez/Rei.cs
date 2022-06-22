using tabuleiro;
namespace Xadrez
{
    public class Rei: Peca
    {
        private PartidaXadrez Partida;
        public Rei(Tabuleiro tab, Cor cor, PartidaXadrez partida): base(tab, cor)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca p = Tab_peca.peca(pos);
            return p!= null && p is Torre && p.Cor_peca == this.Cor_peca && p.QuantidadeMov == 0;
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

            //Jogada Especial - Roque
            if (QuantidadeMov == 0 && !Partida.Xeque)
            {
                //Roque Pequeno
                Posicao posT1 = new Posicao(Posicao_peca.Linha , Posicao_peca.Coluna + 3);
                if (TesteTorreParaRoque(posT1))
                {
                    Posicao p1 = new Posicao (Posicao_peca.Linha , Posicao_peca.Coluna +1);
                    Posicao p2 = new Posicao (Posicao_peca.Linha , Posicao_peca.Coluna +2);
                    if(Tab_peca.peca(p1) == null && Tab_peca.peca(p2)== null)
                    {
                        matriz[Posicao_peca.Linha, Posicao_peca.Coluna + 2] = true;
                    }
                }
            
            
            //Roque Grande
           
                Posicao posT2 = new Posicao(Posicao_peca.Linha, Posicao_peca.Coluna - 4);
                if (TesteTorreParaRoque(posT2)) 
                {
                    Posicao p1 = new Posicao(Posicao_peca.Linha, Posicao_peca.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao_peca.Linha, Posicao_peca.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao_peca.Linha, Posicao_peca.Coluna - 3);
                    if (Tab_peca.peca(p1) == null && Tab_peca.peca(p2) == null && Tab_peca.peca(p3) == null) 
                    {
                        matriz[Posicao_peca.Linha, Posicao_peca.Coluna - 2] = true;
                    }
                }
            }     
            
            return matriz;
        }
    }
}