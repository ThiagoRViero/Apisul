using Newtonsoft.Json;
using ProvaAdmissionalCSharpApisul;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteApisul.Serialization;

namespace TesteApisul.Class
{
    internal class ElevadorService : IElevadorService
    {
        public List<int> andarMenosUtilizado()
        {
            //pega todas as respostas e pega apenas o necessário para o método
            List<Resposta> respostas = pegaRespostas();
            int[] andares = new int[respostas.Count];

            for (int i = 0; i < andares.Length; i++)
            {
                andares[i] = respostas[i].andar;
            }

            int qntdAndares = 15;
            var andarMenosUtilizado = new List<int>();
            int ocorrenciaTemp = 0;
            int menorOcorrencia = -1;

            //Percorre todos andares, a quantidade de andares deve ser informada na variável qntdAndares
            for (int i = 0; i <= qntdAndares; i++)
            {
                foreach (int a in andares)
                {
                    if (i == a)
                    {
                        ocorrenciaTemp++;
                    }
                }
                if(menorOcorrencia < 0 )
                {
                    menorOcorrencia = ocorrenciaTemp;
                }
                if (ocorrenciaTemp <= menorOcorrencia)
                {
                    if (!(andarMenosUtilizado.IndexOf(i) >= 0))
                    {
                        if (ocorrenciaTemp < menorOcorrencia)
                        {
                            andarMenosUtilizado.Clear();
                        }

                        andarMenosUtilizado.Add(i);
                        menorOcorrencia = ocorrenciaTemp;
                    }
                }
                ocorrenciaTemp = 0;
            }
            return andarMenosUtilizado;
        }

        public List<char> elevadorMaisFrequentado() //OK
        {
            //pega todas as respostas e pega apenas o necessário para o método
            List<Resposta> respostas = pegaRespostas();
            char[] elevadores = new char[respostas.Count];

            for (int i = 0; i < elevadores.Length; i++)
            {
                elevadores[i] = respostas[i].elevador;
            }

            //Esta variavel armazenará os elevadores testados diminuindo o processamento
            var elevadorTestados = new List<char>();
            var elevadorMaisFrequentado = new List<char>();
            int ocorrenciaTemp = 0;
            int ocorrenciaResp = -1;

            //Percorre a lista de elevadores, dentro do for existe outro para efetuar a conta de ocorréncias a lista de elevadores testados impedem o retrabalho
            for (int i = 0; i < elevadores.Length; i++)
            {
                if (!(elevadorTestados.IndexOf(elevadores[i]) >= 0))
                {
                    for (int c = 0; c < elevadores.Length; c++)
                    {
                        if (elevadores[i] == elevadores[c])
                        {
                            ocorrenciaTemp++;
                        }
                    }
                    if (ocorrenciaResp < ocorrenciaTemp)
                    {

                        elevadorMaisFrequentado.Clear();
                        elevadorMaisFrequentado.Add(elevadores[i]);
                        ocorrenciaResp = ocorrenciaTemp;
                    }
                    if (ocorrenciaResp == ocorrenciaTemp)
                    {
                        if (!(elevadorMaisFrequentado.IndexOf(elevadores[i]) >= 0))
                        {
                            elevadorMaisFrequentado.Add(elevadores[i]);
                            ocorrenciaResp = ocorrenciaTemp;
                        }
                    }
                    ocorrenciaTemp = 0;
                }
                elevadorTestados.Add(elevadores[i]);
            }
            return elevadorMaisFrequentado;
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado() //ok
        {
            //pega todas as respostas e pega apenas o necessário para o método
            List<Resposta> respostas = pegaRespostas();

            List<char> elevadorMaisFrequentados = elevadorMaisFrequentado();
            List<char> turnosMaiorFluxo = new List<char>();
            List<char> turnos = new List<char>();
            List<char> listaElevadorComMaiorFrequencia = new List<char>();
            int ocorrenciaTemp = 0;
            int ocorrenciaResp = -1;

            
            foreach (char elevador in elevadorMaisFrequentados)
            {
                foreach (Resposta resp in respostas)
                {
                    if (elevador == resp.elevador)
                    {
                        turnos.Add(resp.turno);
                    }
                }
                for (int c = 0; c < turnos.Count; c++)
                {
                    if (turnosMaiorFluxo.IndexOf(turnos[c]) >= 0)
                    {
                        continue;
                    }

                    foreach (char t in turnos)
                    {
                        if (turnos[c] == t)
                        {
                            ocorrenciaTemp++;
                        }   
                    }

                    if (ocorrenciaTemp >= ocorrenciaResp)
                    {
                        if (ocorrenciaTemp < ocorrenciaResp)
                        {
                            turnosMaiorFluxo.Clear();
                        }
                        turnosMaiorFluxo.Add(turnos[c]);
                        ocorrenciaResp = ocorrenciaTemp;
                    }
                    ocorrenciaTemp = 0;
                }
                turnosMaiorFluxo.Insert(0, elevador);
                turnosMaiorFluxo.Add(',');
                listaElevadorComMaiorFrequencia.AddRange(turnosMaiorFluxo);
                turnosMaiorFluxo.Clear();
                ocorrenciaTemp = 0;
                ocorrenciaResp = -1;
                turnos.Clear();
            }

            return listaElevadorComMaiorFrequencia;
        }


        public List<char> elevadorMenosFrequentado() //ok
        {
            //pega todas as respostas e pega apenas o necessário para o método
            List<Resposta> respostas = pegaRespostas();
            char[] elevadores = new char[respostas.Count];

            for (int i = 0; i < elevadores.Length; i++)
            {
                elevadores[i] = respostas[i].elevador;
            }

            //Variavel armazenará os elevadores testados diminuindo o processamento
            char[] listaElevadores = { 'A', 'B', 'C', 'D', 'E' };
            var elevadorMenosFrequentado = new List<char>();
            int ocorrenciaTemp = 0;
            int ocorrenciaResp = -1;

            foreach (char c in listaElevadores){
                foreach (char c2 in elevadores)
                {
                    if(c == c2)
                    {
                        ocorrenciaTemp++;
                    }
                }
                if (ocorrenciaResp < 0)
                {
                    ocorrenciaResp = ocorrenciaTemp;
                }
                if(ocorrenciaTemp <= ocorrenciaResp)
                {
                    if (ocorrenciaTemp < ocorrenciaResp)
                    {
                        elevadorMenosFrequentado.Clear();
                    }
                    elevadorMenosFrequentado.Add(c);
                    ocorrenciaResp = ocorrenciaTemp;
                }
                ocorrenciaTemp= 0;
            }

            return elevadorMenosFrequentado;
        }
        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            //pega todas as respostas e pega apenas o necessário para o método
            List<Resposta> respostas = pegaRespostas();
            char[] listaTurnos = { 'V', 'M', 'N'};

            List<char> elevadorMenosFrequentados = elevadorMenosFrequentado();//
            List<char> turnosMenorFluxo = new List<char>();
            List<char> turnos = new List<char>();//
            List<char> listaElevadorComMenorFrequencia = new List<char>();
            int ocorrenciaTemp = 0;
            int menorOcorrencia = -1;

            foreach (char elevador in elevadorMenosFrequentados)
            {
                //Pega todos os turnos deste elevador
                foreach (Resposta resp in respostas)
                {
                    if (elevador == resp.elevador)
                    {
                        turnos.Add(resp.turno);
                    }
                }

                for(int i = 0; i < listaTurnos.Length; i++)
                {
                    //Verifica a existência do turno dentro da lista de saída evitando reprocessamento
                    if (turnosMenorFluxo.IndexOf(listaTurnos[i]) >= 0)
                    {
                        continue;
                    }

                    foreach (char t in turnos)
                    {
                        if (listaTurnos[i] == t)
                        {
                            ocorrenciaTemp++;
                        }

                    }

                    if (menorOcorrencia < 0)
                    {
                        menorOcorrencia = ocorrenciaTemp;
                    }

                    if( ocorrenciaTemp <= menorOcorrencia)
                        
                    {
                        if(ocorrenciaTemp < menorOcorrencia)
                        {
                            turnosMenorFluxo.Clear();
                        }
                        turnosMenorFluxo.Add(listaTurnos[i]);
                        menorOcorrencia = ocorrenciaTemp;
                    }
                    ocorrenciaTemp = 0;
                }
                turnosMenorFluxo.Insert(0, elevador);
                turnosMenorFluxo.Add(',');
                listaElevadorComMenorFrequencia.AddRange(turnosMenorFluxo);
                turnosMenorFluxo.Clear();
                ocorrenciaTemp = 0;
                menorOcorrencia = -1;
                turnos.Clear();
            }

            return listaElevadorComMenorFrequencia;
        }
        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            //pega todas as respostas e pega apenas o necessário para o método
            List<Resposta> respostas = pegaRespostas();
            char[] turnos = new char[respostas.Count];

            for (int i = 0; i < turnos.Length; i++)
            {
                turnos[i] = respostas[i].turno;
            }

            //Variavel armazenará os elevadores testados diminuindo o processamento
            var turnoTestados = new List<char>();
            var turnoMaisFrequentado = new List<char>();
            int ocorrenciaTemp = 0;
            int ocorrenciaResp = -1;

            for (int i = 0; i < turnos.Length; i++)
            {
                if (!(turnoTestados.IndexOf(turnos[i]) >= 0))
                {
                    for (int c = 0; c < turnos.Length; c++)
                    {
                        if (turnos[i] == turnos[c])
                        {
                            ocorrenciaTemp++;
                        }
                    }
                    if (ocorrenciaResp < ocorrenciaTemp)
                    {

                        turnoMaisFrequentado.Clear();
                        turnoMaisFrequentado.Add(turnos[i]);
                        ocorrenciaResp = ocorrenciaTemp;
                    }
                    if (ocorrenciaResp == ocorrenciaTemp)
                    {
                        if (!(turnoMaisFrequentado.IndexOf(turnos[i]) >= 0))
                        {
                            turnoMaisFrequentado.Add(turnos[i]);
                            ocorrenciaResp = ocorrenciaTemp;
                        }
                    }
                    ocorrenciaTemp = 0;
                }
                turnoTestados.Add(turnos[i]);
            }
            return turnoMaisFrequentado;
        }

        public float percentualDeUsoElevadorA()
        {
            //pega todas as respostas e pega apenas o necessário para o método
            List<Resposta> respostas = pegaRespostas();
            char[] elevadores = new char[respostas.Count];
            char analisar = 'A';
            int contador = 0;
            Decimal porcentagem = 0;

            for (int i = 0; i < elevadores.Length; i++)
            {
                elevadores[i] = respostas[i].elevador;
            }

            foreach (char c in elevadores )
            {
                if(c == analisar)
                {
                    contador++;
                }
            }

            porcentagem = Decimal.Divide(100, elevadores.Length) * contador;
            return float.Parse(porcentagem.ToString("F2"));
        }

        public float percentualDeUsoElevadorB()
        {
            //pega todas as respostas e pega apenas o necessário para o método
            List<Resposta> respostas = pegaRespostas();
            char[] elevadores = new char[respostas.Count];
            char analisar = 'B';
            int contador = 0;
            Decimal porcentagem = 0;

            for (int i = 0; i < elevadores.Length; i++)
            {
                elevadores[i] = respostas[i].elevador;
            }

            foreach (char c in elevadores)
            {
                if (c == analisar)
                {
                    contador++;
                }
            }

            porcentagem = Decimal.Divide(100, elevadores.Length) * contador;
            return float.Parse(porcentagem.ToString("F2"));
        }

        public float percentualDeUsoElevadorC()
        {
            //pega todas as respostas e pega apenas o necessário para o método
            List<Resposta> respostas = pegaRespostas();
            char[] elevadores = new char[respostas.Count];
            char analisar = 'C';
            int contador = 0;
            Decimal porcentagem = 0;

            for (int i = 0; i < elevadores.Length; i++)
            {
                elevadores[i] = respostas[i].elevador;
            }

            foreach (char c in elevadores)
            {
                if (c == analisar)
                {
                    contador++;
                }
            }

            porcentagem = Decimal.Divide(100, elevadores.Length) * contador;
            return float.Parse(porcentagem.ToString("F2"));
        }

        public float percentualDeUsoElevadorD()
        {
            //pega todas as respostas e pega apenas o necessário para o método
            List<Resposta> respostas = pegaRespostas();
            char[] elevadores = new char[respostas.Count];
            char analisar = 'D';
            int contador = 0;
            Decimal porcentagem = 0;

            for (int i = 0; i < elevadores.Length; i++)
            {
                elevadores[i] = respostas[i].elevador;
            }

            foreach (char c in elevadores)
            {
                if (c == analisar)
                {
                    contador++;
                }
            }

            porcentagem = Decimal.Divide(100, elevadores.Length) * contador;
            return float.Parse(porcentagem.ToString("F2"));
        }

        public float percentualDeUsoElevadorE()
        {
            //pega todas as respostas e pega apenas o necessário para o método
            List<Resposta> respostas = pegaRespostas();
            char[] elevadores = new char[respostas.Count];
            char analisar = 'E';
            int contador = 0;
            Decimal porcentagem = 0;

            for (int i = 0; i < elevadores.Length; i++)
            {
                elevadores[i] = respostas[i].elevador;
            }

            foreach (char c in elevadores)
            {
                if (c == analisar)
                {
                    contador++;
                }
            }

            porcentagem = Decimal.Divide(100, elevadores.Length) * contador;
            return float.Parse(porcentagem.ToString("F2"));
        }


        private List<Resposta> pegaRespostas()
        {
            //Pega o caminho principal do projeto para localizar o .JSON
            String caminho = Directory.GetCurrentDirectory();
            if (caminho.IndexOf("Debug") >= 0)
            {
                caminho = caminho.Replace("\\bin\\Debug", "");
            }
            var json = File.ReadAllText(caminho + @"\input.json");
            var respostas = JsonConvert.DeserializeObject<List<Resposta>>(json);
            return respostas;
        }
    }
}
