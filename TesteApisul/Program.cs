using System;
using TesteApisul.Serialization;
using TesteApisul.Class;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TesteApisul
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            while (continuar)
            {
                Console.WriteLine("Digite 1 para consultar o andar menos utilizado;");
                Console.WriteLine("Digite 2 para consultar o elevador mais frequentado;");
                Console.WriteLine("Digite 3 para consultar o elevador mais frequentado e o período que se encontra o maior fluxo;"); ;
                Console.WriteLine("Digite 4 para consultar o elevador menos frequentado;");
                Console.WriteLine("Digite 5 para consultar o elevador menos frequentado e o período que se encontra o menor fluxo;");
                Console.WriteLine("Digite 6 para consultar o período de maior utilização do conjunto de elevadores;");
                Console.WriteLine("Digite 7 para consultar o percentual de uso dos elevadores;");
                Console.WriteLine("Digite 0 para sair da aplicação.");
                ElevadorService ServicoElevador = new ElevadorService();
                String opcao = Console.ReadLine();
                Console.Clear();
                switch (opcao)
                {
                    case ("0"):
                        return;
                        break;
                    //Deve retornar uma List contendo o(s) andar(es) menos utilizado(s).
                    case ("1"):
                        List<int> andarMenosUtilizado = ServicoElevador.andarMenosUtilizado();
                        Console.Write("Andar(es) menos utilizado(s): ");
                        foreach (int andares in andarMenosUtilizado)
                        {
                            Console.Write(andares + " ");
                        }
                        Console.WriteLine();
                        break;

                    //Deve retornar uma List contendo o(s) elevador(es) mais frequentado(s)
                    case ("2"):
                        List<char> elevadorMaisFrequentado = ServicoElevador.elevadorMaisFrequentado();
                        Console.Write("Elevador(es) mais frequentado(s): ");
                        foreach (char elevador in elevadorMaisFrequentado)
                        {
                            Console.Write(elevador + " ");
                        }
                        break;

                    //Deve retornar uma List contendo o período de maior fluxo de cada um dos elevadores mais frequentado
                    case ("3"):
                        List<char> elevadorMaisFrequentadoFluxo = ServicoElevador.periodoMaiorFluxoElevadorMaisFrequentado();
                        Console.WriteLine("Lista de elevador(es) mais utilizados com o(s) perídos de maior fluxo:");
                        for (int i = 0; i < elevadorMaisFrequentadoFluxo.Count(); i++)
                        {
                            if (i == 0)
                            {
                                Console.Write("Elevador: " + elevadorMaisFrequentadoFluxo[i] + " | Período: ");
                                continue;
                            }
                            else if (elevadorMaisFrequentadoFluxo[i - 1].Equals(','))
                            {
                                Console.Write("Elevador: " + elevadorMaisFrequentadoFluxo[i] + " | Período: ");
                                continue;
                            }
                            else if (!(elevadorMaisFrequentadoFluxo[i].Equals(',')))
                            {
                                Console.Write(elevadorMaisFrequentadoFluxo[i] + " ");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("");
                                continue;
                            }

                        }

                        break;

                    //Deve retornar uma List contendo o(s) elevador(es) menos frequentado(s).
                    case ("4"):
                        List<char> elevadorMenosFrequentado = ServicoElevador.elevadorMenosFrequentado();
                        Console.Write("Elevador(es) menos frequentado(s): ");
                        foreach (char elevador in elevadorMenosFrequentado)
                        {
                            Console.Write(elevador + " ");
                        }
                        Console.WriteLine();
                        break;

                    //Deve retornar uma List contendo o período de menor fluxo de cada um dos elevadores menos frequentados (se houver mais de um)..
                    case ("5"):
                        List<char> elevadorMenosFrequentadoFluxo = ServicoElevador.periodoMenorFluxoElevadorMenosFrequentado();
                        Console.WriteLine("Lista de elevador(es) menos utilizados com o(s) perídos de menor fluxo:");
                        for (int i = 0; i < elevadorMenosFrequentadoFluxo.Count(); i++)
                        {
                            if (i == 0)
                            {
                                Console.Write("Elevador: " + elevadorMenosFrequentadoFluxo[i] + " | Período: ");
                                continue;
                            }
                            else if (elevadorMenosFrequentadoFluxo[i - 1].Equals(','))
                            {
                                Console.Write("Elevador: " + elevadorMenosFrequentadoFluxo[i] + " | Período: ");
                                continue;
                            }
                            else if (!(elevadorMenosFrequentadoFluxo[i].Equals(',')))
                            {
                                Console.Write(elevadorMenosFrequentadoFluxo[i] + " ");
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("");
                                continue;
                            }

                        }

                        break;

                    //Deve retornar uma List contendo o(s) periodo(s) de maior utilização do conjunto de elevadores.
                    case ("6"):
                        List<char> turnoMaiorUtilizacao = ServicoElevador.periodoMaiorUtilizacaoConjuntoElevadores();
                        Console.Write("Turno(s) de maior utilização do conjunto de elevadores: ");
                        for (int i = 0; i < turnoMaiorUtilizacao.Count(); i++)
                        {
                            Console.Write(turnoMaiorUtilizacao[i] + " ");

                        }
                        break;

                    //Deve retornar um float (duas casas decimais) contendo o percentual de uso do elevador A em relação a todos os serviços prestados.
                    case ("7"):
                        float percentual = ServicoElevador.percentualDeUsoElevadorA();
                        Console.WriteLine("O percentual de uso do elevador A foi de " + percentual +"%");
                        percentual = ServicoElevador.percentualDeUsoElevadorB();
                        Console.WriteLine("O percentual de uso do elevador B foi de " + percentual + "%");
                        percentual = ServicoElevador.percentualDeUsoElevadorC();
                        Console.WriteLine("O percentual de uso do elevador C foi de " + percentual + "%");
                        percentual = ServicoElevador.percentualDeUsoElevadorD();
                        Console.WriteLine("O percentual de uso do elevador D foi de " + percentual + "%");
                        percentual = ServicoElevador.percentualDeUsoElevadorE();
                        Console.WriteLine("O percentual de uso do elevador E foi de " + percentual + "%");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }

        }
    }
}
