using ExercicioAvancadoOO_ExercicioCompleto.Dominios;

namespace ExercicioAvancadoOO_ExercicioCompleto.MetodosAbstratos {
    abstract class Acessorio {

        public string nome { get; set; }
        public double preco { get; set; }
        public Carro carro { get; set; }

        public Acessorio(string nome, double preco, Carro carro) {
            this.nome = nome;
            this.preco = preco;
            this.carro = carro;
        }
    }
}
