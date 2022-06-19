namespace tabuleiro
{
    public class Peca
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

        public void Movimentou()
        {
            QuantidadeMov++;
        }
    }
}