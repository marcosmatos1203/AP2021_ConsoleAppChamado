using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppChamado
{
    class ChamadoMetodo
    {
        ChamadoDados[] listaChamado = new ChamadoDados[100];
        EquipamentoMetodo equipamento = new EquipamentoMetodo();
        int controlaIdChamado = 0;
        string dataInformada;

        public int ControlaIdChamado { get => controlaIdChamado; set => controlaIdChamado = value; }
        public string DataInformada { get => dataInformada; set => dataInformada = value; }
        internal ChamadoDados[] ListaChamado { get => listaChamado; set => listaChamado = value; }

        public void cadastraChamado()
        {
            int idEquipamento = 0;
            ChamadoDados chamado = new ChamadoDados();
            
            Console.Clear();
            Console.WriteLine("Cadastro de Chamado");
            Console.WriteLine("Digite o titulo do chamado");
            chamado.TituloChamdo = Console.ReadLine();
            Console.WriteLine("Digite a descrição do chamado");
            chamado.DescricaoChamado = Console.ReadLine();
            Console.Clear();
            equipamento.ApresentaEquipamentoChamado();
            Console.WriteLine();
            Console.WriteLine("Digite o ID do equipamento do chamado");
            int.TryParse(Console.ReadLine(), out idEquipamento);
            chamado.Equipamento = equipamento.ListaEquipamento[idEquipamento];
            EhDataInvalida();
            chamado.DataAbertura = DateTime.ParseExact(dataInformada, "dd/mm/yyyy", null);
            listaChamado[idEquipamento] = chamado;

        }
        public void EhDataInvalida()
        {
            bool flag;
            do
            {
                Console.WriteLine("Digite data de abertura do chamado: dd/mm/yyyy");
                dataInformada = Console.ReadLine();

                try
                {
                    DateTime datavalidad = DateTime.ParseExact(dataInformada, "dd/mm/yyyy", null);
                    flag = false;
                }
                catch (Exception)
                {
                    equipamento.ApresentaMenssagem("Data inválida");
                    flag = true;
                }
            } while (flag == true);

        }
        public void calculaData(DateTime dataAbertura)
        {
            TimeSpan date = DateTime.Now - dataAbertura;
            int totalDias = date.Days;
            Console.WriteLine($"Chamado aberto há {totalDias}");

        }
        public void ApresentaTodosChamados()
        {
            Console.Clear();
            for (int i = 0; i < ListaChamado.Length; i++)
            {
                if (ListaChamado[i] != null)
                {
                    int idEquipamento = ListaChamado[i].Equipamento.IdEquipamento;
                    string nomeEquipamento = ListaChamado[i].Equipamento.NomeEquipamento;
                    Console.WriteLine($"ID Chamado:     {ListaChamado[i].TituloChamdo}");
                    Console.WriteLine($"Titulo do Chamado:     {ListaChamado[i].TituloChamdo}");
                    Console.WriteLine($"Descrição do Chamado:   {ListaChamado[i].DescricaoChamado}");
                    Console.WriteLine($"ID equipamento: {idEquipamento} Nome Equipamento: {nomeEquipamento}");
                    Console.WriteLine($"Data de Abertura: {ListaChamado[i].DataAbertura.ToShortDateString()}");
                    calculaData(ListaChamado[i].DataAbertura);
                    Console.WriteLine("-----------------------------------------------------");

                }
            }
            Console.ReadLine();
        }


        public bool EhListaVazia()
        {
            int numeroElementos = 0;
            for (int i = 0; i < ListaChamado.Length; i++)
            {
                if (ListaChamado[i] == null) { }
                else
                    numeroElementos++;
            }

            return numeroElementos == 0;
        }
    }
}
