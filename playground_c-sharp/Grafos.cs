using playground_c_sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace playground_c_sharp
{
    public class Grafo
    {

        public string Nome { get; set; } // Eduarda
        public int Idade {  get; set; } // 20 anos
        public string Profissao { get; set; } // Dr. Nutricionista
        public List<Grafo> ConectedNodes { get; set; } = new List<Grafo>(); // Lista de Clientes



        public Grafo(string nome, int idade, string profissao)
        {
            Nome = nome;
            Idade = idade;
            Profissao = profissao;
        }


        public List<Grafo> AdicionarConexao(Grafo grafo)
        {

            if (!ConectedNodes.Contains(grafo))
            {
                ConectedNodes.Add(grafo);

                if (!grafo.ConectedNodes.Contains(this))
                {
                    grafo.ConectedNodes.Add(this);
                }
            }

            return ConectedNodes;

        }
        

        public List<Grafo> RemoverConexao(Grafo grafo)
        {
            if (ConectedNodes.Contains(grafo))
            {
                ConectedNodes.Remove(grafo);
                grafo.ConectedNodes.Remove(this);
            }

            return ConectedNodes;
        }



        public Grafo? PesquisaLarguraProfissão(string profissao)
        {
            List<Grafo> listaConexoes = new List<Grafo>();

            listaConexoes.AddRange(ConectedNodes);

            int limite = 1000;

            for (int i = 0; i < listaConexoes.Count; i++)
            {
                Grafo item = listaConexoes[i];

                if (item.Profissao == profissao)
                {
                    return item;
                }

                if (item.ConectedNodes.Count > 0)
                {
                    listaConexoes.AddRange(item.ConectedNodes);
                }
                
                
                if(i >= limite)
                {
                    break;
                }
            }

            return null;
           
        }
    }


}

// GRAFO

//public string Nome { get; set; } // Júnior
//public int Idade { get; set; } // 20 anos
//public string Profissao { get; set; } // Pedreiro Digital
//public List<Grafos> ConectedNodes { get; set; } = new List<string>(); // Lista de Clientes