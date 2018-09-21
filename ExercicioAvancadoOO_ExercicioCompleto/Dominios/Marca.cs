using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExercicioAvancadoOO_ExercicioCompleto.Dominios {
    class Marca {
        public int codigo { get; set; }
        public string nome { get; set; }
        public string pais { get; set; }
        public List<Carro> carros { get; set; }


        public Marca(int codigo, string nome, string pais) {
            this.codigo = codigo;
            this.nome = nome;
            this.pais = pais;

            carros = new List<Carro>();
        }

        public void AddCarro(Carro carro) {
            carros.Add(carro);
            //carros.Sort();
        }

        public override string ToString() {
            return codigo + " - " + nome + " - " + pais + " - Numero de carros :" + carros.Count;
        }
    }
}