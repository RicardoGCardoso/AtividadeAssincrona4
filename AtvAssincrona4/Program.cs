using System;
using System.Diagnostics;

namespace AtvAssincrona4
{
    class Program
    {
        static void Main(string[] args)
        {
            ArvoreAVL AVL = new ArvoreAVL();

            AVL.Inserir('A');
            AVL.Inserir('B');
            AVL.Inserir('C');
            AVL.Inserir('D');
            AVL.Inserir('E');
            AVL.Inserir('F');
            AVL.Inserir('G');
            AVL.Inserir('H');
            AVL.Inserir('I');
            AVL.Inserir('J');
            AVL.Inserir('L');
            AVL.Inserir('M');
            AVL.Inserir('N');
            AVL.Inserir('O');
            AVL.Inserir('P');
            AVL.Inserir('Q');
            AVL.Inserir('R');
            AVL.Inserir('S');
            AVL.Inserir('T');
            AVL.Inserir('U');
            AVL.Inserir('V');
            AVL.Inserir('X');
            AVL.Inserir('Z');

            AVL.Exibir();
            Console.WriteLine("-------------------------------------------------------------");

            // PARA O CASO DE BUSCAS EM ARVORES O USO DO ALGORITMO DE PERCORRER EM ORDEM SERÁ UTILIZADO PARA
            // REALIZA A BUSCA DE ITENS SOBRE OS NÓS. 
            // NO MELHOR CASO TEREMOS UMA COMPLEXIDADE O(1), QUANDO O NÓ BUSCADO SEJA O RAIZ, ENTRETANTO QND
            // O NÓ ESTÁ EM UMA EXTREMIDADE DA ARVORE DEPENDENDO DO TIPO DE BUSCA ELE PODE SER O ÚLTIMO A SER
            // PERCORRIDO ENTÃO TEMOS UMA COMPLEXIDADE O(LOG N)

            const int TotalTempos = 10000;
            double TempoMedio = 0;
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i <= TotalTempos; i++)
            {
                stopwatch.Restart();
                AVL.buscarTeste('Z');
                stopwatch.Stop();
                if (i != 0)
                    TempoMedio += stopwatch.Elapsed.TotalMilliseconds;
            }
            Console.WriteLine("Tempo Total: " + (TempoMedio / 1000));

            TempoMedio = TempoMedio / TotalTempos;
            Console.WriteLine("Tempo Médio: " + TempoMedio);

            ArvoreBinariaTesteBusca ArvBina = new ArvoreBinariaTesteBusca();

            ArvBina.Inserir('A');
            ArvBina.Inserir('B');
            ArvBina.Inserir('C');
            ArvBina.Inserir('D');
            ArvBina.Inserir('E');
            ArvBina.Inserir('F');
            ArvBina.Inserir('G');
            ArvBina.Inserir('H');
            ArvBina.Inserir('I');
            ArvBina.Inserir('J');
            ArvBina.Inserir('L');
            ArvBina.Inserir('M');
            ArvBina.Inserir('N');
            ArvBina.Inserir('O');
            ArvBina.Inserir('P');
            ArvBina.Inserir('Q');
            ArvBina.Inserir('R');
            ArvBina.Inserir('S');
            ArvBina.Inserir('T');
            ArvBina.Inserir('U');
            ArvBina.Inserir('V');
            ArvBina.Inserir('X');
            ArvBina.Inserir('Z');


            TempoMedio = 0;
            stopwatch = Stopwatch.StartNew();
            for (int i = 0; i <= TotalTempos; i++)
            {
                stopwatch.Restart();
                ArvBina.buscarTeste('Z');
                stopwatch.Stop();
                if (i != 0)
                    TempoMedio += stopwatch.Elapsed.TotalMilliseconds;
            }

            Console.WriteLine("Tempo Total: " + (TempoMedio / 1000));
            TempoMedio = TempoMedio / TotalTempos;
            Console.WriteLine("Tempo Médio: " + TempoMedio);

            ArvBina.Exibir();
            Console.ReadLine();

            //---------------------------------------------------------------------------
        }
    }
}
