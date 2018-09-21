using System;
using System.Globalization;
using ExercicioAvancadoOO_ExercicioCompleto.MetodosAbstratos;

namespace ExercicioAvancadoOO_ExercicioCompleto.Dominios {
    class Pneu : Acessorio {

        public int aro { get; set; }


        public Pneu(string nome, double preco, int aro, Carro carro) : base(nome, preco, carro) {
            this.aro = aro;
        }

        public override string ToString() {
            return "Pneu :" + nome + " - aro " + aro + " - R$" + preco.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
