using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ExercicioAvancadoOO_ExercicioCompleto.Enumerados;

namespace ExercicioAvancadoOO_ExercicioCompleto.Dominios {
    public class ExerciciosComArquivos {

        public ExerciciosComArquivos() {

        }

        public void TrabalhandoComArquivos(int teste) {

            string arq1 = @"c:\Temp\teste.txt";
            string arq2 = @"c:\Temp\teste2.txt";

            switch (teste) {
                case 0:
                    // Exercicio de Arquivos usando File
                    File.Copy(arq1, arq2);
                    string[] files = File.ReadAllLines(arq1);
                    foreach (string x in files) {
                        Console.WriteLine(x);
                    }
                    break;
                case 1:
                    // Exercicio de Arquivos usando FileInfo
                    FileInfo filesinfo = new FileInfo(arq1);
                    filesinfo.CopyTo(arq2);
                    string[] line = File.ReadAllLines(arq1);
                    foreach (string s in line) {
                        Console.WriteLine(s);
                    }
                    break;
                case 2:
                    // Exercicio de Arquivos usando FileStream básico
                    FileStream filesstream = null;
                    StreamReader streamreader = null;
                    try {
                        filesstream = new FileStream(arq1, FileMode.Open);
                        streamreader = new StreamReader(filesstream);
                        string s = streamreader.ReadLine();
                        Console.WriteLine(s);
                    }
                    finally {
                        if (filesstream != null) filesstream.Close();
                        if (streamreader != null) streamreader.Close();
                        streamreader.Close();
                    }
                    break;
                case 3:
                    // Exercicio de Arquivos usando FileStream usando o File para instanciar
                    StreamReader streamreader_2 = null;
                    try {
                        streamreader_2 = File.OpenText(arq1);
                        while (!streamreader_2.EndOfStream) {
                            string s = streamreader_2.ReadLine();
                            Console.WriteLine(s);
                        }
                    }
                    finally {
                        if (streamreader_2 != null) streamreader_2.Close();
                    }
                    break;
                case 4:
                    // Exercicio de Arquivos usando FileStream com Using
                    //using (FileStream filescream3 = new FileStream(arq1, FileMode.Open)) {
                    //using (StreamReader streamreader_3 = new StreamReader(filescream3)) {
                    // Exercicio de Arquivos usando FileStream com Using e File para instanciar
                    using (StreamReader streamreader_3 = File.OpenText(arq1)) {
                        while (!streamreader_3.EndOfStream) {
                            string s = streamreader_3.ReadLine();
                            Console.WriteLine(s);
                        }
                        // }
                        break;
                    }
                case 5:
                    // Exercicio de Arquivos usando StreanWriter
                    string[] linhas = File.ReadAllLines(arq1);
                    using (StreamWriter swFile = File.AppendText(arq2)) {
                        foreach (string s in linhas) {
                            swFile.WriteLine(s.ToUpper());
                        }
                    }
                    break;
            }

        }
    }
}
