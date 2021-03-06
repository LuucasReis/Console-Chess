using tabuleiro;
using Chess.Execptions;
using System.Collections.Generic;
using Chess_Console;
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
        public bool Xeque {get; private set;}

        public Peca PossivelEnPassant {get; private set;}

        
        public PartidaXadrez()
        {
            Tab_pt = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            PartidaTerminada = false;
            Xeque = false;
            PossivelEnPassant = null; 
            pecas_partida = new HashSet<Peca>();
            pecas_capturadas = new HashSet<Peca>();
           
            ColocarPecas();
        }

        public  Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca peca_mov =Tab_pt.RetirarPeca(origem);
            peca_mov.Movimentou();
            Peca peca_capturada = Tab_pt.RetirarPeca(destino);
            Tab_pt.ColocarPeca(peca_mov, destino);
            if (peca_capturada != null)
            {
                pecas_capturadas.Add(peca_capturada);
            }
            
            //Jogada especial - Roque Pequeno
            if (peca_mov is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemT = new Posicao(origem.Linha , origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha , origem.Coluna + 1);
                Peca T = Tab_pt.RetirarPeca(origemT);
                T.Movimentou();
                Tab_pt.ColocarPeca(T,destinoT);
            }
            
            //Roque Grande
            if (peca_mov is Rei && destino.Coluna == origem.Coluna - 2) 
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tab_pt.RetirarPeca(origemT);
                T.Movimentou();
                Tab_pt.ColocarPeca(T, destinoT);
            }

            //Jogada especial - EnPassant
            if (peca_mov is Peao )
            {
                if (origem.Coluna != destino.Coluna && peca_capturada == null)
                {
                    Posicao posP;
                    if(peca_mov.Cor_peca == Cor.Branca)
                    {
                        posP = new Posicao(destino.Linha + 1, destino.Coluna);
                    }
                    
                    else
                    {
                        posP = new Posicao (destino.Linha - 1, destino.Coluna);
                    }
                    peca_capturada = Tab_pt.RetirarPeca(posP);
                    pecas_capturadas.Add(peca_capturada);
                }
            }

        return peca_capturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca peca_capturada)
        {
            Peca p = Tab_pt.RetirarPeca(destino);
            p.Decrementou();
            if (peca_capturada != null)
            {
                Tab_pt.ColocarPeca(peca_capturada, destino);
                pecas_capturadas.Remove(peca_capturada);
            }
            Tab_pt.ColocarPeca(p,origem);

            //Jogada especial - Roque Pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemT = new Posicao(origem.Linha , origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha , origem.Coluna + 1);
                Peca T = Tab_pt.RetirarPeca(destinoT);
                T.Decrementou();
                Tab_pt.ColocarPeca(T,origemT);
            }
            
            //Roque Grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2) 
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tab_pt.RetirarPeca(destinoT);
                T.Decrementou();
                Tab_pt.ColocarPeca(T, origemT);
            }

            //Jogada especial EnPassant
            if(p is Peao)
            {
                if (origem.Coluna != destino.Coluna && peca_capturada == PossivelEnPassant)
                {
                    Peca peao = Tab_pt.RetirarPeca(destino);
                    Posicao posP;

                    if(p.Cor_peca == Cor.Branca)
                    {
                        posP = new Posicao(3, destino.Coluna);
                    }

                    else
                    {
                        posP = new Posicao(4, destino.Coluna);
                    }

                    Tab_pt.ColocarPeca(peao, posP);
                }
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca peca_capturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, peca_capturada);
                throw new DomainException("Voc?? n??o pode se colocar em xeque!!");
            }

            Peca p = Tab_pt.peca(destino);

            //Jogada Especial - Promocao
            if (p is Peao)
            {
                if((p.Cor_peca == Cor.Branca && destino.Linha == 0) || (p.Cor_peca == Cor.Preta && destino.Linha == 7))
                {
                    p = Tab_pt.RetirarPeca(destino);
                    pecas_partida.Remove(p);
                    Peca Dama = new Dama(Tab_pt, p.Cor_peca);
                    Tab_pt.ColocarPeca(Dama, destino);
                    pecas_partida.Add(Dama);
                }
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }
            if (testeXequemate(Adversaria(JogadorAtual))) 
            {
                PartidaTerminada = true;
            }
            else {
                Turno++;
                MudaJogador();
            }

            //Jogada Especial - En passant
            if (p is Peao && (destino.Linha == origem.Linha + 2 || destino.Linha == origem.Linha - 2))
            {
                PossivelEnPassant = p;
            }
            else
            {
                PossivelEnPassant = null;
            }
            
        }

        public void ValidarPosicaoOrigem(Posicao p)
        {
            if (Tab_pt.peca(p) == null)
            {
                throw new DomainException ("N??o existe pe??a na posi????o escolhida");
            }

            if (JogadorAtual != Tab_pt.peca(p).Cor_peca)
            {
                throw new DomainException ($"O turno ?? de pe??as {JogadorAtual}s");
            }

            if (!Tab_pt.peca(p).ExisteMovimentosPossiveis())
            {
                throw new DomainException ("N??o existe movimentos possiveis para essa pe??a");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!Tab_pt.peca(origem).PodeMoverpara(destino))
            {
                throw new DomainException("Posi????o de destino inv??lida!!");
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

        private Cor Adversaria (Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca ReiEmJogo(Cor cor)
        {
            foreach (Peca p in PecasEmJogo(cor))
            {
                if (p is Rei)
                {
                    return p;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca R = ReiEmJogo(cor);
            if (R == null)
            {
                throw new DomainException("N??o Existe um Rei na partida!!");
            }
            foreach (Peca p in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat= p.MovimentosPossiveis();
                if (mat[R.Posicao_peca.Linha, R.Posicao_peca.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testeXequemate(Cor cor) {
            if (!EstaEmXeque(cor)) {
                return false;
            }
            foreach (Peca x in PecasEmJogo(cor)) {
                bool[,] mat = x.MovimentosPossiveis();
                for (int i=0; i<Tab_pt.Linhas_tab; i++) {
                    for (int j=0; j<Tab_pt.Colunas_tab; j++) 
                    {
                        if (mat[i, j]) 
                        {
                            Posicao origem = x.Posicao_peca;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            
                            if (!testeXeque) 
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
           Tab_pt.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ConverterPosicao());
           pecas_partida.Add(peca);
        }
        public void ColocarPecas()
        {   
            ColocarNovaPeca('a', 1, new Torre(Tab_pt, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(Tab_pt, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(Tab_pt, Cor.Branca));
            ColocarNovaPeca('d', 1, new Dama(Tab_pt, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(Tab_pt, Cor.Branca, this));
            ColocarNovaPeca('f', 1, new Bispo(Tab_pt, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(Tab_pt, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(Tab_pt, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(Tab_pt, Cor.Branca, this));
            ColocarNovaPeca('b', 2, new Peao(Tab_pt, Cor.Branca, this));
            ColocarNovaPeca('c', 2, new Peao(Tab_pt, Cor.Branca, this));
            ColocarNovaPeca('d', 2, new Peao(Tab_pt, Cor.Branca, this));
            ColocarNovaPeca('e', 2, new Peao(Tab_pt, Cor.Branca, this));
            ColocarNovaPeca('f', 2, new Peao(Tab_pt, Cor.Branca, this));
            ColocarNovaPeca('g', 2, new Peao(Tab_pt, Cor.Branca, this));
            ColocarNovaPeca('h', 2, new Peao(Tab_pt, Cor.Branca, this));

            ColocarNovaPeca('a', 8, new Torre(Tab_pt, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(Tab_pt, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(Tab_pt, Cor.Preta));
            ColocarNovaPeca('d', 8, new Dama(Tab_pt, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(Tab_pt, Cor.Preta, this));
            ColocarNovaPeca('f', 8, new Bispo(Tab_pt, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(Tab_pt, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(Tab_pt, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(Tab_pt, Cor.Preta, this));
            ColocarNovaPeca('b', 7, new Peao(Tab_pt, Cor.Preta, this));
            ColocarNovaPeca('c', 7, new Peao(Tab_pt, Cor.Preta, this));
            ColocarNovaPeca('d', 7, new Peao(Tab_pt, Cor.Preta, this));
            ColocarNovaPeca('e', 7, new Peao(Tab_pt, Cor.Preta, this));
            ColocarNovaPeca('f', 7, new Peao(Tab_pt, Cor.Preta, this));
            ColocarNovaPeca('g', 7, new Peao(Tab_pt, Cor.Preta, this));
            ColocarNovaPeca('h', 7, new Peao(Tab_pt, Cor.Preta, this));
        }
    }
}

          