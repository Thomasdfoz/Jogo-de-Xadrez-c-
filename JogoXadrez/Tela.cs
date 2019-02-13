using System;
using tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace JogoXadrez
{
    class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine($"Aguardando jogada: " + partida.JogadorAtual);
            if (partida.xeque)
            {
                Console.WriteLine("XEQUE!!!");
            }
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas: ");
            Console.Write("Brancas: ");
            Console.Write("[");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.Write("]");
            Console.WriteLine();
            Console.Write("pretas: ");
            Console.Write("[");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Black;
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.ForegroundColor = aux;  
            Console.Write("]");
            Console.WriteLine();

        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            foreach (Peca x in conjunto)
            {
                Console.Write(" " + x + " ");
            }
        }

        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++)
            {
                ConsoleColor aux2 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(8 - i + (" "));
                Console.ForegroundColor = aux2;

                for (int j = 0; j < tab.colunas; j++)
                {
                    ImprimrPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  A B C D E F G H");
            Console.ForegroundColor = aux;

            Console.WriteLine();
        }
        public static void ImprimirTabuleiro(Tabuleiro tab, bool[,] posicoesPosiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                ConsoleColor aux2 = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write(8 - i + (" "));
                Console.ForegroundColor = aux2;

                for (int j = 0; j < tab.colunas; j++)
                {
                    if (posicoesPosiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }

                    ImprimrPeca(tab.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;

                }
                Console.WriteLine();
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("  A B C D E F G H");
            Console.ForegroundColor = aux;
            Console.BackgroundColor = fundoOriginal;

            Console.WriteLine();
        }
        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }
        public static void ImprimrPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
