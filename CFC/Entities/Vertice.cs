using System;
using System.Collections.Generic;
using System.Text;

namespace CFC.Entities
{
    class Vertice
    {
        public string Nome { get; set; }
        public List<Vertice> Lista_Vizinhos { get; set; }
        public List<Vertice> Lista_Vizinhos_Invertida { get; set; }
        public int Tempo_Descoberta { get; set; }
        public int Tempo_Fechamento { get; set; }
        public Vertice V_Pai { get; set; }
        public enum State { nothing, fresh, visiting, visited };
        public State Estado { get; set; }

        public Vertice()
        {
            
        }
        public Vertice(string nome)
        {
            Lista_Vizinhos = new List<Vertice>();
            Lista_Vizinhos_Invertida = new List<Vertice>();
            Nome = nome;
        }

        public void Adicionar_Vizinhos(Vertice vizinho)
        {
            Lista_Vizinhos.Add(vizinho);
        }

        public override string ToString()
        {
            return ($"Vertice: {Nome}");
        }
    }
}
