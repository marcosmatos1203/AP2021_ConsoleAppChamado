using System;

namespace ConsoleAppChamado
{
    class Program
    {
        #region Requisito 1.1 [OK]
        //Como funcionário, Junior quer ter a possibilidade de registrar equipamentos
        // •  Deve ter um nome com no mínimo 6 caracteres;  
        // •  Deve ter um preço de aquisição;  
        // •  Deve ter um número de série;  
        // •  Deve ter uma data de fabricação;  
        // •  Deve ter uma fabricante;
        #endregion
        #region Requisito 1.2 [OK]
        //Como funcionário, Junior quer ter a possibilidade de visualizar todos os equipamentos registrados em seu inventário.
        // •  Deve mostrar o nome;  
        // •  Deve mostrar o número de série;  
        // •  Deve mostrar a fabricante;
        #endregion
        #region Requisito 1.3 [OK]
        //Como funcionário, Junior quer ter a possibilidade de editar um equipamento, sendo que ele possa editar todos os campos.
        // •  Deve ter os mesmos critérios que o Requisito 1. 
        #endregion
        #region Requisito 1.4 [OK]
        //Como funcionário, Junior quer ter a possibilidade de excluir um equipamento que esteja registrado.
        // •  A lista de equipamentos deve ser atualizada  
        #endregion

        static void Main(string[] args)
        {
            EquipamentoMetodo manipulaEquipamento = new EquipamentoMetodo();
            ChamadoMetodo manipulaChamado = new ChamadoMetodo();
            string opcao = "", opcaoMenu;
            while (true)
            {
                Console.Clear();
                ApresentaMenuPrincipal();
                opcaoMenu = Console.ReadLine().ToUpper();
                if (EhOpcaoMenuPrincipalInvalida(opcaoMenu))
                {
                    manipulaEquipamento.ApresentaMenssagem("Opção inválida Tente novamente");
                    continue;
                }
                if (opcaoMenu == "1")
                {
                    while (true)
                    {

                        MostraMenu();
                        opcao = Console.ReadLine().ToUpper();
                        if (EhOpcaoInvalida(opcao))
                        {
                            manipulaEquipamento.ApresentaMenssagem("Opção inválida Tente novamente");
                            continue;
                        }
                        if (opcao == "1")
                        {
                            manipulaEquipamento.CadastraEquipamento();
                            continue;
                        }
                        if (opcao == "2")
                        {
                            if (manipulaEquipamento.EhListaVazia())
                            {
                                manipulaEquipamento.ApresentaMenssagem("Nenhum equipamento cadastrado");
                            }
                            else
                            {
                                manipulaEquipamento.ApresentaTodosEquipamento();
                            }
                            Console.ReadLine();
                            Console.Clear();

                            continue;
                        }
                        if (opcao == "3")
                        {
                            if (manipulaEquipamento.EhListaVazia())
                            {
                                manipulaEquipamento.ApresentaMenssagem("Nenhum equipamento cadastrado");
                            }
                            else
                            {
                                AtualizaEquipamento(manipulaEquipamento);
                                continue;
                            }
                        }
                        if (opcao == "4")
                        {
                            if (manipulaEquipamento.EhListaVazia())
                            {
                                manipulaEquipamento.ApresentaMenssagem("Nenhum equipamento cadastrado");
                            }
                            else
                            {
                                ExcluirEquipamento(manipulaEquipamento);
                                continue;
                            }
                        }
                        if (opcao == "S")
                        {
                            break;
                        }

                    }


                }
                if (opcaoMenu == "2")
                {
                    while (true)
                    {

                        MostraMenuChamado();
                        opcao = Console.ReadLine().ToUpper();
                        if (EhOpcaoInvalida(opcao))
                        {
                            manipulaEquipamento.ApresentaMenssagem("Opção inválida Tente novamente");
                            continue;
                        }
                        if(opcao=="1")
                        {
                            manipulaChamado.cadastraChamado();
                            continue;
                        }
                        if (opcao =="2")
                        {
                            manipulaChamado.ApresentaTodosChamados();
                            continue;
                        }
                        if (opcao == "3")
                        {
                            EditarChamado(manipulaChamado);
                            continue;
                        }
                        if (opcao == "4")
                        {
                            ExcluirChamado(manipulaChamado);
                            continue;
                        }
                        if (opcao == "S")
                        {
                            break;
                        }

                    }
                }
                if (opcao == "S")
                    break;
                Console.ReadLine();


            }
        }

        private static void EditarChamado(ChamadoMetodo manipulaChamado)
        {
            manipulaChamado.ApresentaTodosChamados();
            Console.WriteLine("Digite o ID do Chamado para editar");
            int idChamado = Convert.ToInt32(Console.ReadLine());
            manipulaChamado.EditarChamado(idChamado);
        }

        private static void ExcluirChamado(ChamadoMetodo manipulaChamado)
        {
            Console.WriteLine("Digite o ID do Chamado para excluir");
            int idChamado = Convert.ToInt32(Console.ReadLine());
            manipulaChamado.ExcluirChamado(idChamado);
        }

        private static void AtualizaEquipamento(EquipamentoMetodo manipulaEquipamento)
        {
            int id;
            manipulaEquipamento.ApresentaTodosEquipamento();
            Console.WriteLine("Digite o ID do equipamento que deseja atualizar");
            id = Convert.ToInt32(Console.ReadLine());
            manipulaEquipamento.EditarEquipamento(id);
        }

        private static void ApresentaMenuPrincipal()
        {
            Console.WriteLine("1 - Equipamentos");
            Console.WriteLine("2 - Chamados");
            Console.WriteLine("S - Sair");
        }
        private static void ExcluirEquipamento(EquipamentoMetodo manipulaEquipamento)
        {
            int id;
            manipulaEquipamento.ApresentaTodosEquipamento();
            Console.WriteLine("Digite o ID do equipamento que deseja Excluir");
            id = Convert.ToInt32(Console.ReadLine());
            manipulaEquipamento.ExcluirEquipamento(id);
        }
        private static bool EhOpcaoInvalida(string opcao)
        {
            return opcao != "S" && opcao != "1" && opcao != "2" && opcao != "3" && opcao != "4";
        }
        private static bool EhOpcaoMenuPrincipalInvalida(string opcao)
        {
            return opcao != "S" && opcao != "1" && opcao != "2";
        }
        private static void MostraMenu()
        {
            Console.Clear();
            Console.WriteLine("-----MENU EQUIPAMENTOS-----");
            Console.WriteLine("1 - Cadastro de Equipamento");
            Console.WriteLine("2 - Lista de Equipamentos");
            Console.WriteLine("3 - Editar Equipamentos");
            Console.WriteLine("4 - Excluir Equipamentos");
            Console.WriteLine("S - Sair");
        }
        private static void MostraMenuChamado()
        {
            Console.Clear();
            Console.WriteLine("-----MENU CHAMADOS-----");
            Console.WriteLine("1 - Cadastro de chamado");
            Console.WriteLine("2 - Lista de chamados");
            Console.WriteLine("3 - Editar chamado");
            Console.WriteLine("4 - Excluir chamado");
            Console.WriteLine("S - Sair");
        }

    }


}
