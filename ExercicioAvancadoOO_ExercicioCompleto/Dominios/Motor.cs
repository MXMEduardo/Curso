using System;
using System.Globalization;
using ExercicioAvancadoOO_ExercicioCompleto.MetodosAbstratos;

namespace ExercicioAvancadoOO_ExercicioCompleto.Dominios {
    class Motor : Acessorio {
        public Motor(string nome, double preco, Carro carro) : base(nome, preco, carro) {
        }

        public override string ToString() {
            return "Motor :" + nome + " - R$" + preco.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
