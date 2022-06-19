using tabuleiro;
using Chess.Execptions;
namespace Xadrez
{
    public class PartidaXadrez
    {
        public Tabuleiro Tab_pt {get; private set;}
        public int Turno {get; private set;}
        public Cor JogadorAtual {get; private set;}

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

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoOrigem(Posicao p)
        {
            if (Tab_pt.peca(p) == null)
            {
                throw new DomainException ("Não existe peça na posição escolhida");
            }

            if (JogadorAtual != Tab_pt.peca(p).Cor_peca)
            {
                throw new DomainException ($"O turno é de peças {JogadorAtual}s");
            }

            if (!Tab_pt.peca(p).ExisteMovimentosPossiveis())
            {
                throw new DomainException ("Não existe movimentos possiveis para essa peça");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab_pt.peca(origem).PodeMoverpara(destino))
            {
                throw new DomainException("Posição de destino inválida!!");
            }
        }

        private void MudaJogador()
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }

        }

        public void ColocarPecas()
        {
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Branca),new PosicaoXadrez('c',2).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Branca),new PosicaoXadrez('c',1).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Branca),new PosicaoXadrez('d',2).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Branca),new PosicaoXadrez('e',2).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Branca),new PosicaoXadrez('e',1).ConverterPosicao());
            Tab_pt.ColocarPeca(new Rei(Tab_pt, Cor.Branca),new PosicaoXadrez('d',1).ConverterPosicao());
            

            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Preta),new PosicaoXadrez('c',7).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Preta),new PosicaoXadrez('c',8).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Preta),new PosicaoXadrez('d',7).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Preta),new PosicaoXadrez('e',7).ConverterPosicao());
            Tab_pt.ColocarPeca(new Torre(Tab_pt, Cor.Preta),new PosicaoXadrez('e',8).ConverterPosicao());
            Tab_pt.ColocarPeca(new Rei(Tab_pt, Cor.Preta),new PosicaoXadrez('d',8).ConverterPosicao());
            
        }
    }
}