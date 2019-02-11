using System;
using tabuleiro;
using xadrez;

namespace JogoXadrez
{
    class Program
    {
        static void Main(string[] args)
        {            
            try
            {
                Tabuleiro tab = new Tabuleiro(8, 8);



                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(1, 0));
                tab.ColocarPeca(new Rei(tab, Cor.Branca), new Posicao(4, 4));

                Tela.ImprimirTabuleiro(tab);

            }catch(TabuleiroExcpetion e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
