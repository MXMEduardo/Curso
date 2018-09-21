using System;
using System.Collections.Generic;
using ExercicioAvancadoOO_ExercicioCompleto.Dominios;
using ExercicioAvancadoOO_ExercicioCompleto.MetodosAbstratos;

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

        public void ListasMarcas(List<Marca> marca) {
            Console.WriteLine();
            Console.WriteLine("Marcas:");
            for (int x = 0; x < marca.Count; x++) {
                Console.WriteLine(marca[x]);
            }
            Console.WriteLine();
        }

        public void ListasMarcasDetail(List<Marca> marca) {
            Console.WriteLine();
            Console.WriteLine("Marcas:");
            for (int x = 0; x < marca.Count; x++) {
                Console.WriteLine(marca[x]);

                Console.WriteLine();
                Console.WriteLine("   Carros:");
                for (int y = 0; y < marca[x].carros.Count; y++) {
                    Console.WriteLine("      " + marca[x].carros[y]);
                    if (marca[x].carros[y].acessorios.Count > 0) {
                        Console.WriteLine("      Acessórios:");
                        foreach (Acessorio z in marca[x].carros[y].acessorios) {
                            Console.WriteLine("         " + z);
                        }
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void ListaCarrosOrdenadamente(List<Marca> marca) {
            Console.WriteLine();
            Console.Write("Identifique uma Marca:");

            int CodigoMarca = int.Parse(Console.ReadLine());
            int pos = marca.FindIndex(x => x.codigo == CodigoMarca);

            if (pos == -1) {
                throw new ModelException("Marca não encontrada: " + CodigoMarca);
            }

            Console.WriteLine();
            Console.WriteLine("Carros da Marca:" + marca[pos].nome);
            for (int x = 0; x < marca[pos].carros.Count; x++) {
                Console.WriteLine("   " + marca[pos].carros[x]);
            }
            Console.WriteLine();
        }

        public void CadastrarMarca(List<Marca> marca) {
            Console.WriteLine();
            Console.Write("Digite o código da Marca:");
            int CodigoMarca = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome da Marca:");
            string nomeMarca = Console.ReadLine();

            Console.Write("Digite o país de origem:");
            string paisMarca = Console.ReadLine();

            marca.Add(new Marca(CodigoMarca, nomeMarca, paisMarca));

            Console.WriteLine();
            Console.WriteLine("Marca cadastrada.");
            ListasMarcasDetail(marca);
        }

        public void CadastrarCarro(List<Marca> marca) {
            Console.WriteLine();
            Console.Write("Digite o código da Marca:");
            int CodigoMarca = int.Parse(Console.ReadLine());

            // Achando a Marca
            int posMarca = marca.FindIndex(x => x.codigo == CodigoMarca);
            if (posMarca == -1) {
                throw new ModelException("Marca não encontrada: " + CodigoMarca);
            }

            Console.Write("Digite o código do carro:");
            int codigoCarro = int.Parse(Console.ReadLine());

            Console.Write("Digite o modelo do carro:");
            string modeloCarro = Console.ReadLine();

            Console.Write("Digite o ano do carro:");
            int anoCarro = int.Parse(Console.ReadLine());

            Console.Write("Digite o preço básico do carro:");
            double precoCarro = double.Parse(Console.ReadLine());

            marca[posMarca].AddCarro(new Carro(codigoCarro, modeloCarro, anoCarro, precoCarro, marca[posMarca]));

            Console.WriteLine();
            Console.WriteLine("Carro cadastrado.");
            for (int x = 0; x < marca[posMarca].carros.Count; x++) {
                Console.WriteLine(marca[posMarca].carros[x]);
            }
        }

        public void CadastrarAcessorio(List<Marca> marca) {
            Console.WriteLine();

            // Achando a Marca
            Console.Write("Digite o código da Marca:");
            int CodigoMarca = int.Parse(Console.ReadLine());
            int posMarca = marca.FindIndex(x => x.codigo == CodigoMarca);
            if (posMarca == -1) {
                throw new ModelException("Marca não encontrada: " + CodigoMarca);
            }

            // Achando o Carro
            Console.Write("Digite o código do carro:");
            int codigoCarro = int.Parse(Console.ReadLine());
            int posCarro = marca[posMarca].carros.FindIndex(x => x.codigo == codigoCarro);
            if (posCarro == -1) {
                throw new ModelException("Carro não encontrad0: " + codigoCarro);
            }

            Console.Write("Que tipo de acessório ? (P)nel ou (M)otor :");
            char TipodeAcessorio = char.Parse(Console.ReadLine());
            if (TipodeAcessorio == 'P') {
                Console.Write("Digite a descrição do Pneu:");
                string descricaoAcessorio = Console.ReadLine();

                Console.Write("Digite o aro do Pneu:");
                int aroAcessorio = int.Parse(Console.ReadLine());

                Console.Write("Digite o valor do Pneu:");
                double valorAcessorio = double.Parse(Console.ReadLine());

                marca[posMarca].carros[posCarro].AddAcessorio(new Pneu(descricaoAcessorio, valorAcessorio, aroAcessorio, marca[posMarca].carros[posCarro]));
            }
            else if (TipodeAcessorio == 'M') {
                Console.Write("Digite a descrição do acessório de Motor:");
                string descricaoAcessorio = Console.ReadLine();

                Console.Write("Digite o valor do acessório de Motor:");
                double valorAcessorio = double.Parse(Console.ReadLine());

                marca[posMarca].carros[posCarro].AddAcessorio(new Motor(descricaoAcessorio, valorAcessorio, marca[posMarca].carros[posCarro]));
            }

            Console.WriteLine();
            Console.WriteLine("Acessório cadastrado.");

            foreach (Acessorio acessorio in marca[posMarca].carros[posCarro].acessorios) {
                Console.WriteLine(acessorio);
            }

        }

        public void ListaAcessorios(List<Marca> marca) {
            // Achando o Carro
            Console.Write("Digite o código do carro:");
            int codigoCarro = int.Parse(Console.ReadLine());

            for (int posMarca = 0; posMarca < marca.Count; posMarca++) {
                int posCarro = marca[posMarca].carros.FindIndex(x => x.codigo == codigoCarro);
                if (posCarro > -1) {
                    Console.WriteLine();
                    Console.WriteLine("   Carro:");
                    Console.WriteLine("   " + marca[posMarca].carros[posCarro]);
                    Console.WriteLine("      Acessórios:");
                    foreach (Acessorio x in marca[posMarca].carros[posCarro].acessorios) {
                        Console.WriteLine("      " + x);
                    }
                }
            }
        }
    }
}
