using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CFC.Entities
{
    class Busca_CFC : Vertice
    {
        public int Tempo { get; set; }
        public Grafo G { get; set; }
        
        public Busca_CFC(Grafo g)
        {
            G = g;
        }

        public void DFS_Marcacao_Fresh()
        {
            foreach (Vertice V in G.Lista_Vertices)
            {
                V.Estado = State.fresh;

            }
            Tempo = 0;
            foreach (Vertice V in G.Lista_Vertices)
            {
                if (V.Estado == State.fresh)
                {
                    DFS_Visita(V);
                }

            }
        }

        public void DFS_Visita(Vertice V)
        {
            V.Estado = State.visiting;
            Tempo++;
            V.Tempo_Descoberta = Tempo;
           
            foreach (Vertice s in V.Lista_Vizinhos)
            {
                /*
                if (s.Estado == State.visiting)
                {
                    Console.WriteLine($"{s} Voltou");
                }
                else
                {
                    Console.WriteLine($"{s} Ok");
                }
                */
                if (s.Estado == State.fresh)
                {
                    s.V_Pai = V;

                    DFS_Visita(s);                 
                }
                
            }
            
            V.Estado = State.visited;
            V.Tempo_Fechamento = ++Tempo;
            
        }
        
        public void InverterArestas()
        {
            foreach(Vertice vert in G.Lista_Vertices)
            {
                foreach(Vertice adj in vert.Lista_Vizinhos)
                {                  
                    adj.Lista_Vizinhos_Invertida.Add(vert);                  
                }   
            }
        }
        
        public void LimparListaVizinhos()
        {
            foreach (Vertice vert in G.Lista_Vertices)
            {
                vert.Lista_Vizinhos.Clear();
            }           
        }
        
        public void ReceberListaArestaInvertida()
        {
            foreach (Vertice vert in G.Lista_Vertices)
            {
                foreach (Vertice adj in vert.Lista_Vizinhos_Invertida)
                {
                    vert.Lista_Vizinhos.Add(adj);
                }
            }
        }

        public void Mostrar()
        {
            var order = G.Lista_Vertices.OrderBy(x => x.Tempo_Descoberta);

            foreach (var t in order)
            {
                Console.WriteLine($"Pai {t.V_Pai} --> Vertice: {t.Nome} Descoberta: {t.Tempo_Descoberta} Fechamento: {t.Tempo_Fechamento}");
            }
            Console.WriteLine();
        }
    }
}
