using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExercicioAvancadoOO_ExercicioCompleto.Dominios {
    class Carro {
        public int codigo { get; set; }
        public string modelo { get; set; }
        public int ano { get; set; }
        public double preco { get; set; }
        public Marca marca { get; private set; }
        public HashSet<Acessorio> acessorios { get; private set; }


        public Carro(int codigo, string modelo, int ano, double preco, Marca marca) {
            this.codigo = codigo;
            this.modelo = modelo;
            this.ano = ano;
            this.preco = preco;
            this.marca = marca;

            acessorios = new HashSet<Acessorio>();
        }

        public void AddAcessorio(Acessorio acessorio) {
            acessorios.Add(acessorio);
        }

        public double PrecoTotal() {
            double AcessoriosPreco = 0;
            foreach (Acessorio acessorio in acessorios) {
                AcessoriosPreco += acessorio.preco;
            }

            return this.preco + AcessoriosPreco;
        }

        public override string ToString() {
            return codigo +" - " + modelo + " - "+ ano + "  - R$"+ preco.ToString("F2", CultureInfo.InvariantCulture) + " - " + marca;
        }
    }
}
