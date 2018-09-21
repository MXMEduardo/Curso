using System;
using System.Collections.Generic;
using ExercicioAvancadoOO_ExercicioCompleto.Dominios;

namespace ExercicioAvancadoOO_ExercicioCompleto {
    class Tela {

        public int Opcao { get; private set; }

        public void MostrarMenu() {
            Console.WriteLine();
            Console.WriteLine("0 – Sair");
            Console.WriteLine("1 – Listar marcas");
            Console.WriteLine("2 – Listar carros de uma marca ordenadamente*");
            Console.WriteLine("3 – Cadastrar marca");
            Console.WriteLine("4 – Cadastrar carro");
            Console.WriteLine("5 – Cadastrar acessório");
            Console.WriteLine("6 – Mostrar detalhes de um carro");
            Console.WriteLine();
            Console.Write("Digite o código da sua opção: ");

            this.Opcao = int.Parse(Console.ReadLine());
        }

        public void ListasMarcas(List<Marca> marca, bool detalhado) {
            Console.WriteLine();
            Console.WriteLine("Marcas:");
            Console.WriteLine();
            for (int x = 0; x < marca.Count; x++) {
                Console.WriteLine(marca[x]);

                if (detalhado) {
                    Console.WriteLine("   Carros:");
                    for (int y = 0; y < marca[x].carros.Count; y++) {
                        Console.WriteLine("      " + marca[x].carros[y]);
                        if (marca[x].carros[y].acessorios.Count > 0) {
                            Console.WriteLine("      Acessórios:");
                            foreach (Acessorio z in marca[x].carros[y].acessorios) {
                                Console.WriteLine("         " + z);
                            }
                        }
                    }
                }
            }
        }

        public void ListaCarrosOrdenadamente(List<Marca> marca) {
            Console.WriteLine();
            Console.Write("Identifique uma Marca:");

            int CodMarca = int.Parse(Console.ReadLine());
            int pos = marca.FindIndex(x => x.codigo == CodMarca);

            if (pos == -1) {
                throw new ModelException("Marca não encontrada: " + CodMarca);
            }

            Console.WriteLine("Carros da Marca:" + marca[pos].nome);
            for (int x = 0; x < marca[pos].carros.Count; x++) {
                Console.WriteLine("   " + marca[pos].carros[x]);
            }
            Console.WriteLine();
        }
    }
}
