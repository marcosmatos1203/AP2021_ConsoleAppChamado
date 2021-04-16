using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppChamado
{
    class ChamadoMetodo
    {
        public static ChamadoDados[] listaChamado = new ChamadoDados[100];
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
            chamado.IdChamado = ControlaIdChamado;
            Console.WriteLine("Cadastro de Chamado");
            Console.WriteLine("Digite o titulo do chamado");
            chamado.TituloChamdo = Console.ReadLine();
            Console.WriteLine("Digite a descrição do chamado");
            chamado.DescricaoChamado = Console.ReadLine();
            Console.Clear();
            equipamento.ApresentaEquipamentoChamado();
            Console.WriteLine();
            Console.WriteLine("Digite o ID do equipamento do chamado");
            idEquipamento = Convert.ToInt32(Console.ReadLine());
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
        public void EditarChamado(int idChamado)
        {
            if(EhListaVazia())
            {
                Console.Clear();
                equipamento.ApresentaMenssagem("Nenhum chamado registrado");
            }
            else
            {
                Console.WriteLine();
                Console.Clear();
                ChamadoDados chamado = ListaChamado[idChamado];
                Console.WriteLine("Editar Chamado");
                Console.WriteLine();
                ApresentaChamadoParaEditar(chamado);
                string opcao = "";
                while (true)
                {
                    MostraMenuEditor();
                    opcao = Console.ReadLine().ToUpper();
                    if (EhOpcaoDeAtualizacaoInvalida(opcao))
                    {
                        equipamento.ApresentaMenssagem("Opção inválida Tente novamente");
                        continue;
                    }
                    if (opcao == "1")
                    {
                        Console.WriteLine("Digite o novo titulo do chamado");
                        chamado.TituloChamdo = Console.ReadLine();
                        continue;
                    }
                    if (opcao == "2")
                    {
                        Console.WriteLine("Digite a descrição do chamado");
                        chamado.DescricaoChamado = Console.ReadLine();
                        continue;
                    }
                    if (opcao == "3")
                    {
                        equipamento.ApresentaEquipamentoChamado();
                        Console.WriteLine();
                        Console.WriteLine("Digite o ID do equipamento do chamado");
                        int idEquipamento = Convert.ToInt32(Console.ReadLine());
                        chamado.Equipamento = equipamento.ListaEquipamento[idEquipamento];
                        continue;
                    }
                    if (opcao == "4")
                    {
                        EhDataInvalida();
                        chamado.DataAbertura = DateTime.ParseExact(dataInformada, "dd/mm/yyyy", null);
                        continue;
                    }
                    if (opcao == "S")
                    {
                        SalvaAtualizacao(idChamado, chamado); break;
                    }
                }
            
            }
        }
        public void SalvaAtualizacao(int idEquipamento, ChamadoDados chamado)
        {
            ListaChamado[idEquipamento] = chamado;
            equipamento.ApresentaMenssagem("Chamado atualizado");
            Console.ReadLine();
        }
        private static bool EhOpcaoDeAtualizacaoInvalida(string opcao)
        {
            return opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "S";
        }
        public void MostraMenuEditor()
        {
            Console.Clear();
            Console.WriteLine("1 - atualizar titulo do chamado");
            Console.WriteLine("2 - atualizar descrição do chamado");
            Console.WriteLine("3 - atualizar equipamento do chamado");
            Console.WriteLine("4 - atualizar data de abertura do chamado");
            Console.WriteLine("5 - Salvar e sair");
        }
        public void ExcluirChamado(int idChamado)
        {
            ListaChamado[idChamado] = null;
            equipamento.ApresentaMenssagem("Chamado Excluido Excluido");
        }
        public void calculaData(DateTime dataAbertura)
        {
            TimeSpan date = DateTime.Now - dataAbertura;
            int totalDias = date.Days;
            Console.WriteLine($"Chamado aberto há {totalDias} dias");

        }
        public void ApresentaChamadoParaEditar(ChamadoDados chamado)
        {
            Console.WriteLine($"Nome:               {chamado.IdChamado}");
            Console.WriteLine($"preço:              {chamado.TituloChamdo}");
            Console.WriteLine($"número de série:    {chamado.DescricaoChamado}");
            Console.WriteLine($"Data fabricação:    {chamado.DataAbertura}");
        }
        public void ApresentaTodosChamados()
        {
            if (EhListaVazia())
            {
                Console.Clear();
                equipamento.ApresentaMenssagem("Nenhum chamado registrado");
            }
            else
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
