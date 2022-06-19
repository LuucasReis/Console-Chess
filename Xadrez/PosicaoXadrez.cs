using tabuleiro;
namespace Xadrez
{
    public class PosicaoXadrez
    {
        public char Coluna_pxadrez {get; set;}
        public int Linha_pxadrez {get; set;}

        public PosicaoXadrez()
        {
        }

        public PosicaoXadrez(char coluna, int linha)
        {
            Coluna_pxadrez = coluna;
            Linha_pxadrez = linha;
        }

        public Posicao ConverterPosicao()
        {
            return new Posicao(8 - Linha_pxadrez, Coluna_pxadrez - 'a');
        }

        public override string ToString()
        {
            return ""+ Coluna_pxadrez+ Linha_pxadrez;
        }
    }
}