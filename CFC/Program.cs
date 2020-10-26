using System;
using CFC.Entities;

namespace CFC
{
    class Program
    {
        static void Main(string[] args)
        {
            Grafo grafo = new Grafo();

            Vertice A = new Vertice("A");
            Vertice B = new Vertice("B");
            Vertice C = new Vertice("C");
            Vertice D = new Vertice("D");
            Vertice E = new Vertice("E");
            Vertice F = new Vertice("F");
            Vertice G = new Vertice("G");
            Vertice H = new Vertice("H");
            Vertice I = new Vertice("I");
            Vertice J = new Vertice("J");
            Vertice K = new Vertice("K");

            grafo.Adicionar_Vertice(A);
            grafo.Adicionar_Vertice(B);
            grafo.Adicionar_Vertice(C);
            grafo.Adicionar_Vertice(D);
            grafo.Adicionar_Vertice(E);
            grafo.Adicionar_Vertice(F);
            grafo.Adicionar_Vertice(G);
            grafo.Adicionar_Vertice(H);
            grafo.Adicionar_Vertice(I);
            grafo.Adicionar_Vertice(J);
            grafo.Adicionar_Vertice(K);

            A.Adicionar_Vizinhos(B);
            A.Adicionar_Vizinhos(H);

            B.Adicionar_Vizinhos(C);
            B.Adicionar_Vizinhos(H);

            C.Adicionar_Vizinhos(I);

            D.Adicionar_Vizinhos(C);
            D.Adicionar_Vizinhos(I);

            E.Adicionar_Vizinhos(F);

            F.Adicionar_Vizinhos(K);

            G.Adicionar_Vizinhos(A);
            G.Adicionar_Vizinhos(B);
            G.Adicionar_Vizinhos(E);

            H.Adicionar_Vizinhos(G);
            H.Adicionar_Vizinhos(I);

            I.Adicionar_Vizinhos(J);

            J.Adicionar_Vizinhos(C);
            J.Adicionar_Vizinhos(D);
            J.Adicionar_Vizinhos(F);

            K.Adicionar_Vizinhos(E);

            Busca_CFC cfc = new Busca_CFC(grafo);

            cfc.ExecutarCFC();
            cfc.Mostrar();
            Console.WriteLine();
        }
    }
}
