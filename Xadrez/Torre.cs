using tabuleiro;
namespace Xadrez
{
    public class Torre: Peca
    {
        public Torre(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }
        
        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matriz = new bool[Tab_peca.Linhas_tab, Tab_peca.Colunas_tab];

            Posicao mov_posicao = new Posicao(0,0);

            //acima
            mov_posicao.DefinirValores(Posicao_peca.Linha -1 , Posicao_peca.Coluna);
            while (Tab_peca.ValidaPosicao(mov_posicao) && PodeMover(mov_posicao))
            {
                matriz[mov_posicao.Linha, mov_posicao.Coluna] = true;
                if (Tab_peca.peca(mov_posicao) !=  null && Tab_peca.peca(mov_posicao).Cor_peca != Cor_peca)
                {
                    break;
                }
                mov_posicao.Linha --;
            }
            

            //abaixo
            mov_posicao.DefinirValores(Posicao_peca.Linha +1 , Posicao_peca.Coluna);
            while (Tab_peca.ValidaPosicao(mov_posicao) && PodeMover(mov_posicao))
            {
                matriz[mov_posicao.Linha, mov_posicao.Coluna] = true;
                if (Tab_peca.peca(mov_posicao) !=  null && Tab_peca.peca(mov_posicao).Cor_peca != Cor_peca)
                {
                    break;
                }
                mov_posicao.Linha ++;
            }

            //Direita
            mov_posicao.DefinirValores(Posicao_peca.Linha , Posicao_peca.Coluna +1);
            while (Tab_peca.ValidaPosicao(mov_posicao) && PodeMover(mov_posicao))
            {
                matriz[mov_posicao.Linha, mov_posicao.Coluna] = true;
                if (Tab_peca.peca(mov_posicao) !=  null && Tab_peca.peca(mov_posicao).Cor_peca != Cor_peca)
                {
                    break;
                }
                mov_posicao.Coluna ++;
            }

             //Direita
            mov_posicao.DefinirValores(Posicao_peca.Linha , Posicao_peca.Coluna -1);
            while (Tab_peca.ValidaPosicao(mov_posicao) && PodeMover(mov_posicao))
            {
                matriz[mov_posicao.Linha, mov_posicao.Coluna] = true;
                if (Tab_peca.peca(mov_posicao) !=  null && Tab_peca.peca(mov_posicao).Cor_peca != Cor_peca)
                {
                    break;
                }
                mov_posicao.Coluna --;
            }
            
            return matriz;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}