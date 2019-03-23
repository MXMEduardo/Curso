using System;
using System.Collections.Generic;
using ExercicioAvancadoOO_ExercicioCompleto.Dominios;
using ExercicioAvancadoOO_ExercicioCompleto.Enumerados;
using System.IO;

namespace ExercicioAvancadoOO_ExercicioCompleto {
    class Program {
        static void Main(string[] args) {

            #region populando dados
            List<Marca> marcas = new List<Marca>();
            Util.IncluiMarcas(marcas);
            #endregion

            Console.WriteLine("Sistema de Controle de Carros");
            Tela tela = new Tela();
            tela.MostrarMenu();

            try {
                while (tela.Opcao > 0) {
                    int caseSwitch = tela.Opcao;
                    switch (caseSwitch) {
                        case 1:
                            Console.WriteLine();
                            Console.Write("Deseja uma listagem detalhada ? (S/N) :");
                            char det = char.Parse(Console.ReadLine());
                            if (det == 'N') {
                                tela.ListasMarcas(marcas);
                            }
                            else {
                                tela.ListasMarcasDetail(marcas);
                            }
                            break;
                        case 2:
                            tela.ListaCarrosOrdenadamente(marcas);
                            break;
                        case 3:
                            tela.CadastrarMarca(marcas);
                            break;
                        case 4:
                            tela.CadastrarCarro(marcas);
                            break;
                        case 5:
                            tela.CadastrarAcessorio(marcas);
                            break;
                        case 6:
                            tela.ListaAcessorios(marcas);
                            break;
                        case 7:
                            tela.EstudodeArquivos(FileTests.Teste_de_FileStream_Ex3);
                            break;
                        case 8:
                            tela.EstudodeArquivos(FileTests.Teste_de_StreanWriter);
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("Não existe essa opção de menu.");
                            break;
                    }
                    tela.MostrarMenu();
                }

            }
            catch (IOException e) {
                Console.WriteLine("deu erro na bagaça " + e.Message);
            }
            catch (Exception e) {
                Console.WriteLine("Erro inesperado: " + e.Message);
            }
            Console.ReadLine();
        }
    }
}
