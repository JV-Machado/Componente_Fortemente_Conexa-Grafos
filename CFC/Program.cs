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

            grafo.Adicionar_Vertice(A);
            grafo.Adicionar_Vertice(B);
            grafo.Adicionar_Vertice(C);
            grafo.Adicionar_Vertice(D);
            grafo.Adicionar_Vertice(E);
            grafo.Adicionar_Vertice(F);
            grafo.Adicionar_Vertice(G);
            grafo.Adicionar_Vertice(H);

            A.Adicionar_Vizinhos(B);
            A.Adicionar_Vizinhos(G);

            B.Adicionar_Vizinhos(C);
            B.Adicionar_Vizinhos(G);

            C.Adicionar_Vizinhos(H);

            D.Adicionar_Vizinhos(C);
            D.Adicionar_Vizinhos(E);
            D.Adicionar_Vizinhos(H);

            E.Adicionar_Vizinhos(F);
            E.Adicionar_Vizinhos(G);

            F.Adicionar_Vizinhos(A);
            F.Adicionar_Vizinhos(B);

            G.Adicionar_Vizinhos(F);
            G.Adicionar_Vizinhos(H);

            Busca_CFC cfc = new Busca_CFC(grafo);

            cfc.DFS_Marcacao_Fresh();
            cfc.Mostrar();

            cfc.InverterArestas();
            cfc.LimparListaVizinhos();
            cfc.ReceberListaArestaInvertida();

            cfc.DFS_Marcacao_Fresh();
            cfc.Mostrar();
        }
    }
}
