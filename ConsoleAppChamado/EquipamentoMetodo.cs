using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppChamado
{
    class EquipamentoMetodo
    {
        public static EquipamentoDados[] listaEquipamento = new EquipamentoDados[100];
        int controlaIdEquipamento = 0;
        string dataInformada;
        internal EquipamentoDados[] ListaEquipamento { get => listaEquipamento; set => listaEquipamento = value; }
        public int ControlaIdEquipamento { get => controlaIdEquipamento; set => controlaIdEquipamento = value; }

        public void EditarEquipamento(int idEquipamento)
        {
            Console.WriteLine();
            Console.Clear();
            EquipamentoDados equipamento = ListaEquipamento[idEquipamento];
            Console.WriteLine("Editar Equipamento");
            Console.WriteLine();
            ApresentaEquipamentoParaEditar(equipamento);
            string opcao = "";
            while (true)
            {
                MostraMenuEditor();
                opcao = Console.ReadLine().ToUpper();
                if (EhOpcaoDeAtualizacaoInvalida(opcao))
                {
                    ApresentaMenssagem("Opção inválida Tente novamente");
                    continue;
                }
                if (opcao == "S")
                {
                    SalvaAtualizacao(idEquipamento, equipamento); break;
                }

                int numCaracter = 0;
                switch (opcao)
                {
                    case "1":
                        numCaracter = ValidaNome(equipamento); break;
                    case "2":
                        {
                            AtualizaPreco(equipamento); break;
                        }
                    case "3":
                        {
                            AtualizaSerie(equipamento); break;
                        }
                    case "4":
                        {
                            AtualizaData(equipamento); break;
                        }
                    case "5":
                        {
                            AtualizaFabricante(equipamento); break;
                        }




                    default:
                        break;
                }
            }


        }

        public bool EhListaVazia()
        {
            int numeroElementos = 0;
            for (int i = 0; i < ListaEquipamento.Length; i++)
            {
                if (ListaEquipamento[i] == null) { }
                else
                    numeroElementos++;
            }

            return numeroElementos==0;
        }
        private void SalvaAtualizacao(int idEquipamento, EquipamentoDados equipamento)
        {
            ListaEquipamento[idEquipamento] = equipamento;
            ApresentaMenssagem("Equipamento atualizado");
            Console.ReadLine();
        }

        private static void AtualizaFabricante(EquipamentoDados equipamento)
        {
            Console.WriteLine("Digite o nome do fabricante");
            equipamento.NomeFabricante = Console.ReadLine();
        }

        private void AtualizaData(EquipamentoDados equipamento)
        {
            EhDataInvalida();
            equipamento.DataFabricacao = DateTime.ParseExact(dataInformada, "dd/mm/yyyy", null);
        }

        private static void AtualizaSerie(EquipamentoDados equipamento)
        {
            Console.WriteLine("Digite o número de série");
            equipamento.SerieEquipamento = Console.ReadLine();
        }

        private static void AtualizaPreco(EquipamentoDados equipamento)
        {
            Console.WriteLine("Digite o preço de aquisição");
            equipamento.PrecoAquisicao = Convert.ToInt32(Console.ReadLine());
        }

        public void EhDataInvalida()
        {
            bool flag;
            do
            {
                Console.WriteLine("Digite data de fabricação: dd/mm/yyyy");
                dataInformada = Console.ReadLine();

                try
                {
                    DateTime datavalidad = DateTime.ParseExact(dataInformada, "dd/mm/yyyy", null);
                    flag = false;
                }
                catch (Exception)
                {
                    ApresentaMenssagem("Data inválida");
                    flag = true;
                }
            } while (flag == true);

        }

        private static bool EhOpcaoDeAtualizacaoInvalida(string opcao)
        {
            return opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4" && opcao != "5" && opcao != "S";
        }

        public void ApresentaMenssagem(string menssagem)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(menssagem);
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
        }
        private static void MostraMenuEditor()
        {
            Console.WriteLine();
            Console.WriteLine("1 - Alterar nome do equipamento");
            Console.WriteLine("2 - Alterar preço de aquisição");
            Console.WriteLine("3 - Alterar número de série");
            Console.WriteLine("4 - Alterar data de fabricação");
            Console.WriteLine("5 - Alterar nome do fabricante");
            Console.WriteLine("S - Salvar e sair");
        }
        private static void ApresentaEquipamentoParaEditar(EquipamentoDados equipamento)
        {
            Console.WriteLine($"Nome:               {equipamento.NomeEquipamento}");
            Console.WriteLine($"preço:              {equipamento.PrecoAquisicao}");
            Console.WriteLine($"número de série:    {equipamento.SerieEquipamento}");
            Console.WriteLine($"Data fabricação:    {equipamento.DataFabricacao}");
            Console.WriteLine($"Nome do fabricante: {equipamento.NomeFabricante}");
        }
        public void ExcluirEquipamento(int idEquipamento)
        {
            ListaEquipamento[idEquipamento] = null;
            ApresentaMenssagem("Equipamento Excluido");
        }
        public void CadastraEquipamento()
        {
            Console.Clear();
            EquipamentoDados equipamento = new EquipamentoDados();
            Console.WriteLine("Cadastro de Equipamento");
            Console.WriteLine();
            equipamento.IdEquipamento = ControlaIdEquipamento;
            int numCaracter = 0;
            numCaracter = ValidaNome(equipamento);

            Console.WriteLine("Digite o preço de aquisição");
            equipamento.PrecoAquisicao = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o número de série");
            equipamento.SerieEquipamento = Console.ReadLine();

            EhDataInvalida();
            equipamento.DataFabricacao = DateTime.ParseExact(dataInformada, "dd/mm/yyyy", null);

            Console.WriteLine("Digite o nome do fabricante");
            equipamento.NomeFabricante = Console.ReadLine();
            Console.Clear();
            ListaEquipamento[equipamento.IdEquipamento] = equipamento;
            ControlaIdEquipamento++;
        }

        private static int ValidaNome(EquipamentoDados equipamento)
        {
            int numCaracter;
            do
            {
                Console.WriteLine("Digite o nome do equipamento");
                equipamento.NomeEquipamento = Console.ReadLine();
                numCaracter = equipamento.NomeEquipamento.Length;
                if (numCaracter < 6)
                {
                    Console.WriteLine("O nome deve conter mais de 6 caracteres");
                    Console.ReadLine();
                }


            } while (numCaracter < 6);
            return numCaracter;
        }
        public void ApresentaEquipamentoChamado()
        {
            Console.Clear();
            for (int i = 0; i < ListaEquipamento.Length; i++)
            {
                if (ListaEquipamento[i] != null)
                {
                    Console.WriteLine($"ID equipamento:     {ListaEquipamento[i].IdEquipamento}");
                    Console.WriteLine($"Nome equipamento:   {ListaEquipamento[i].NomeEquipamento}");
                    Console.WriteLine("-----------------------------------------------------");

                }
            }
        }
        public void ApresentaTodosEquipamento()
        {
            Console.Clear();
            for (int i = 0; i < ListaEquipamento.Length; i++)
            {
                if (ListaEquipamento[i] != null)
                {
                    Console.WriteLine($"ID equipamento:     {ListaEquipamento[i].IdEquipamento}");
                    Console.WriteLine($"Nome equipamento:   {ListaEquipamento[i].NomeEquipamento}");
                    Console.WriteLine($"Numero de série:    {ListaEquipamento[i].SerieEquipamento}");
                    Console.WriteLine($"Nome do fabricante: {ListaEquipamento[i].NomeFabricante}");
                    Console.WriteLine("-----------------------------------------------------");

                }
            }
        }
    }
}
