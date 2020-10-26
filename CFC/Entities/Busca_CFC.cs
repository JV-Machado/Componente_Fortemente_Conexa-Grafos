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
        public Stack<Vertice> Pilha { get; set; }
        public List<List<Vertice>> Componentes { get; set; }
        public List<Vertice> Sublista_Componentes { get; set; }

        public Busca_CFC(Grafo g)
        {
            Componentes = new List<List<Vertice>>();
            Pilha = new Stack<Vertice>();
            G = g;
        }

        public void DFS_Marcacao_Fresh()
        {
            foreach (Vertice V in G.Lista_Vertices)
            {
                V.Estado = State.fresh;             
            }
            Tempo = 0;
            if(Pilha.Count == 0)
            {
                foreach (Vertice V in G.Lista_Vertices)
                {
                    if (V.Estado == State.fresh)
                    {
                        DFS_Visita(V, -1);
                    }
                }
            }
            else
            {
                int i = 0;
                while(Pilha.Count > 0)
                {
                    Vertice v = Pilha.Pop();
                    if (v.Estado == State.fresh)
                    {
                        Sublista_Componentes = new List<Vertice>();
                        DFS_Visita(v,i);
                        i++;
                        Componentes.Add(Sublista_Componentes);
                    }
                }
            }
            
        }

        public void DFS_Visita(Vertice V, int i)
        {
            V.Estado = State.visiting;
            Tempo++;
            V.Tempo_Descoberta = Tempo;
           
            foreach (Vertice s in V.Lista_Vizinhos)
            {
                if (s.Estado == State.fresh)
                {
                    s.V_Pai = V;

                    DFS_Visita(s, i);                 
                }
                
            }
            
            V.Estado = State.visited;
            V.Tempo_Fechamento = ++Tempo;
            if(i == -1)
            {
                PreenchePilha(V);
            }
            else
            {
                Sublista_Componentes.Add(V);    
            }
        }
        
        public void PreenchePilha(Vertice v)
        {
            Pilha.Push(v);     
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

        public void ExecutarCFC()
        {
            DFS_Marcacao_Fresh();

            InverterArestas();
            LimparListaVizinhos();
            ReceberListaArestaInvertida();

            DFS_Marcacao_Fresh();       
        }

        public void Mostrar()
        {
            Console.WriteLine("Componentes Fortemente Conexas:");
            Console.WriteLine();
            foreach(var Sublist in Componentes)
            {
                foreach(var value in Sublist)
                {
                    Console.WriteLine(value);
                }
                Console.WriteLine();
            }
        }
        
    }
}
