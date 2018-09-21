﻿using System;
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

        public void ListasMarcas(List<Marca> marca) {
            Console.WriteLine();
            Console.WriteLine("Marcas:");
            Console.WriteLine();
            for (int x = 0; x < marca.Count; x++) {
                Console.WriteLine(marca[x]);
            }
        }

        public void ListasMarcasDetail(List<Marca> marca) {
            Console.WriteLine();
            Console.WriteLine("Marcas:");
            Console.WriteLine();
            for (int x = 0; x < marca.Count; x++) {
                Console.WriteLine(marca[x]);

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

            Console.Write("Digite o nome do carro:");
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
            for (int x=0; x < marca[posMarca].carros.Count; x++) {
                Console.WriteLine(marca[posMarca].carros);
            }
        }

        public void CadastrarAcessorio(List<Marca> marca) {
            Console.WriteLine();

            // Achando a Marca
            Console.Write("Digite o código da Marca:");
            int CodigoMarca = int.Parse(Console.ReadLine());
            int posMarca = marca.FindIndex(x => x.codigo == CodigoMarca);

            // Achando o Carro
            Console.Write("Digite o código do carro:");
            int codigoCarro = int.Parse(Console.ReadLine());
            int posCarro = marca[posMarca].carros.FindIndex(x => x.codigo == codigoCarro);

            Console.Write("Digite a descrição do acessório:");
            string descricaoAcessorio = Console.ReadLine();

            Console.Write("Digite o valor do acessório:");
            double valorAcessorio = double.Parse(Console.ReadLine());

            marca[posMarca].carros[posCarro].AddAcessorio(new Acessorio(descricaoAcessorio, valorAcessorio, marca[posMarca].carros[posCarro]));

            Console.WriteLine();
            Console.WriteLine("Acessório cadastrado.");

            foreach (Acessorio acessorio in marca[posMarca].carros[posCarro].acessorios) {
                Console.WriteLine(acessorio);
            }

        }

        public void ListaAcessorios(List<Marca> marca) {

        }
    }
}
