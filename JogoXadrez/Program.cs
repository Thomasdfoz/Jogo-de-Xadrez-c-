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
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao();

                    bool[,] posicoesPossiveis = partida.tab.peca(origem).MovimentosPossiveis();

                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);

                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao();


                    partida.ExecutaMovimento(origem, destino);
                }

                Tela.ImprimirTabuleiro(partida.tab);

            }catch(TabuleiroExcpetion e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
