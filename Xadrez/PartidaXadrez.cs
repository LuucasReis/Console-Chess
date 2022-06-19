using tabuleiro;
namespace Xadrez
{
    public class PartidaXadrez
    {
        public Tabuleiro Tab_pt {get; private set;}
        public int Turno {get; set;}
        public Cor JogadorAtual {get; set;}

        public bool PartidaTerminada {get; private set;}

        
        public PartidaXadrez()
        {
            Tab_pt = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            ColocarPecas();
            PartidaTerminada = false;
        }

        public  void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca_mov =Tab_pt.RetirarPeca(origem);
            peca_mov.Movimentou();
            Peca peca_capturada = Tab_pt.RetirarPeca(destino);
            Tab_pt.ColocarPeca(peca_mov, destino);
        }

        public void ColocarPecas()
        {
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Preta),new PosicaoXadrez('c',1).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Preta),new PosicaoXadrez('c',2).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Preta),new PosicaoXadrez('d',2).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Preta),new PosicaoXadrez('e',2).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Preta),new PosicaoXadrez('e',1).ConverterPosicao());
            Tab_pt.ColocarPeca(new Rei(Tab_pt, Cor.Preta),new PosicaoXadrez('d',1).ConverterPosicao());

            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Branca),new PosicaoXadrez('c',7).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Branca),new PosicaoXadrez('c',8).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Branca),new PosicaoXadrez('d',7).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Branca),new PosicaoXadrez('e',7).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Branca),new PosicaoXadrez('e',8).ConverterPosicao());
            Tab_pt.ColocarPeca(new Rei(Tab_pt, Cor.Branca),new PosicaoXadrez('d',8).ConverterPosicao());
            
        }
    }
}