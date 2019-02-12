using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; set; }
        public int qteMovimento { get; protected set; }
        public Tabuleiro tab { get; protected set; }

        public Peca(Cor cor, Tabuleiro tab)
        {
            this.posicao = null;
            this.cor = cor;
            this.tab = tab;
            qteMovimento = 0;
        }
        public void IncrementarQteMovimento()
        {
            qteMovimento++;
        }
        public abstract bool[,] MovimentosPossiveis();
    }
}
