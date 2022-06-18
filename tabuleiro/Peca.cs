namespace tabuleiro
{
    public class Peca
    {
        public Posicao Posicao {get; set;}
        public Cor Cor {get; protected set;}
        public int QuantidadeMov {get; protected set;}
        public Tabuleiro Tab {get; protected set;}

        public Peca()
        {
        }

        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Cor = cor;
            Tab = tab;
            QuantidadeMov = 0;
        }
    }
}