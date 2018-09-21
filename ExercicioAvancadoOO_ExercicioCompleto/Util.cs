using System;
using System.Collections.Generic;
using ExercicioAvancadoOO_ExercicioCompleto.Dominios;

namespace ExercicioAvancadoOO_ExercicioCompleto {
    class Util {
        public static void IncluiMarcas(List<Marca> marca) {
            Marca itMarca = new Marca(1001, "Volkswagem", "Alemanha");
            marca.Add(itMarca);
                marca[0].AddCarro(new Carro(101, "Fusca", 1982, 5000.00, marca[0]));
                marca[0].AddCarro(new Carro(102, "Golf", 2016, 60000.00, marca[0]));
                marca[0].AddCarro(new Carro(103, "Fox", 2017, 30000.00, marca[0]));

            marca.Add(new Marca(1002, "General Motors", "EUA"));
                marca[1].AddCarro(new Carro(104, "Cruze", 2016, 30000.00, marca[0]));
                marca[1].AddCarro(new Carro(105, "Cobalt", 2015, 25000.00, marca[0]));
                    marca[1].carros[0].acessorios.Add(new Pneu("Godyear", 200.00, 40, marca[1].carros[0]));
                    marca[1].carros[0].acessorios.Add(new Motor("Antena", 100.00, marca[1].carros[0]));
                    marca[1].carros[0].acessorios.Add(new Motor("Vidro", 300.00, marca[1].carros[0]));

            marca[1].AddCarro(new Carro(106, "Cobalt", 2017, 35000.00, marca[0]));
        }
    }
}
