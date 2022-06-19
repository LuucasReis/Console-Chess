using tabuleiro;
using Chess.Execptions;
using System.Collections.Generic;
namespace Xadrez
{
    public class PartidaXadrez
    {
        public Tabuleiro Tab_pt {get; private set;}
        public int Turno {get; private set;}
        public Cor JogadorAtual {get; private set;}

        public bool PartidaTerminada {get; private set;}
        private HashSet<Peca> pecas_partida;
        private HashSet<Peca> pecas_capturadas; 

        
        public PartidaXadrez()
        {
            Tab_pt = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            PartidaTerminada = false; 
            pecas_partida = new HashSet<Peca>();
            pecas_capturadas = new HashSet<Peca>();
           
            ColocarPecas();
        }

        public  void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca_mov =Tab_pt.RetirarPeca(origem);
            peca_mov.Movimentou();
            Peca peca_capturada = Tab_pt.RetirarPeca(destino);
            Tab_pt.ColocarPeca(peca_mov, destino);
            if (peca_capturada != null)
            {
                pecas_capturadas.Add(peca_capturada);
            }
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

        public HashSet<Peca> SepararPecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca p in pecas_capturadas)
            {
                if(p.Cor_peca == cor)
                {
                    aux.Add(p);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca p in pecas_partida)
            {
                if(p.Cor_peca == cor)
                {
                    aux.Add(p);
                }
            }
            aux.ExceptWith(SepararPecasCapturadas(cor));
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
           Tab_pt.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ConverterPosicao());
           pecas_partida.Add(peca);
        }
        public void ColocarPecas()
        {   
            ColocarNovaPeca('c',2, new Torre(Tab_pt, Cor.Branca));
            ColocarNovaPeca('c',1, new Torre(Tab_pt, Cor.Branca));
            ColocarNovaPeca('d',2, new Torre(Tab_pt, Cor.Branca));
            ColocarNovaPeca('e',2, new Torre(Tab_pt, Cor.Branca));
            ColocarNovaPeca('e',1, new Torre(Tab_pt, Cor.Branca));
            ColocarNovaPeca('d',1, new Rei(Tab_pt, Cor.Branca));
            
            ColocarNovaPeca('c',7, new Torre(Tab_pt, Cor.Preta));
            ColocarNovaPeca('c',8, new Torre(Tab_pt, Cor.Preta));
            ColocarNovaPeca('d',7, new Torre(Tab_pt, Cor.Preta));
            ColocarNovaPeca('e',7, new Torre(Tab_pt, Cor.Preta));
            ColocarNovaPeca('e',8, new Torre(Tab_pt, Cor.Preta));
            ColocarNovaPeca('d',8, new Rei(Tab_pt, Cor.Preta));

            
        }
    }
}