using System;
using System.Collections.Generic;
using System.Text;

namespace CFC.Entities
{
    class Grafo
    {
        public List<Vertice> Lista_Vertices { get; set; }

        public Grafo()
        {
            Lista_Vertices = new List<Vertice>();
        }
        public void Adicionar_Vertice(Vertice vertice)
        {        
            Lista_Vertices.Add(vertice);
        }
    }
}
