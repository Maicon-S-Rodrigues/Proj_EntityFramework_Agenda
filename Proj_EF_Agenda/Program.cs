using Proj_EF_Agenda.Context;
using Proj_EF_Agenda.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_EF_Agenda
{
    internal class Program
    {
        static void Menu()
        {
            int opc;
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("\n Agenda");
                    Console.WriteLine(" Escolha a Opção desejada:");
                    Console.WriteLine(" 1 - Adicionar Contato");
                    Console.WriteLine(" 2 - Ver Todos Contatos");
                    Console.WriteLine(" 3 - Procurar um Contato pelo Nome");
                    Console.WriteLine(" 4 - Editar ou Excluir um Contato");
                    Console.WriteLine(" 0 - Sair");
                    opc = int.Parse(Console.ReadLine());

                    switch (opc)
                    {
                        case 1:
                            InsertContact();
                            break;

                        case 2:
                            Console.Clear();
                            if (new PersonContext().Persons.ToList().Count == 0) Console.WriteLine("\n\nNão há Contatos Salvos!\n");

                            //se a lista não esta vazia, imprime todos
                            else new PersonContext().Persons.ToList().ForEach(x => Console.WriteLine(x));
                            Pause();
                            break;

                        case 3:
                            SearchContact();
                            break;

                        case 4:
                            EditContact();
                            break;

                        case 0:
                            Console.WriteLine("\n Encerrando...");
                            Pause();
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("\n Escolha uma opção valida...");
                            Pause();
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("\n\nErro: <<<" + e + ">>> \n\n");
                    Pause();
                    throw;
                }
            } while (true);
        }

        static void InsertContact()
        {
            try
            {
                Console.Clear();
                Console.Write("\n Informe o Nome que deseja salvar este Contato: ");
                string name = Console.ReadLine();
                if (new PersonContext().Persons.FirstOrDefault(f => f.Name == name) == null)
                {
                    Console.Write("\n Celular: ");
                    string mobile = Console.ReadLine();
                    Console.Write("\n Telefone: ");
                    string homePhone = Console.ReadLine();
                    Console.Write("\n E-mail: ");
                    string mail = Console.ReadLine();

                    Person contact = new Person(name, new Numbers(mobile, homePhone), mail);

                    using (var context = new PersonContext())
                    {
                        context.Persons.Add(contact);
                        context.SaveChanges();
                    }
                    Console.Write("\nContato Adicionado!");
                    Pause();
                }
                else
                {
                    Console.WriteLine("Este Nome já está cadastrado na sua lista de Contatos!");
                    Pause();
                    return;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n\nErro: <<<" + e + ">>> \n\n");
                Pause();
                throw;
            }
        }

        static void SearchContact()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n Por qual Nome deseja procurar?");
                string searchName = Console.ReadLine();
                if (new PersonContext().Persons.FirstOrDefault(search => search.Name == searchName) == null)
                {
                    Console.Write("\n Não foi encontrado nenhum contato com este Nome...");
                    Pause();
                    return;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Contato:\n");
                    Console.WriteLine(new PersonContext().Persons.First(finded => finded.Name == searchName).ToString());
                    Console.WriteLine();
                    Pause();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n\nErro: <<<" + e + ">>> \n\n");
                Pause();
                throw;
            }
        }

        static void EditContact()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("\n Qual o Nome do Contato que deseja Editar?");
                string searchName = Console.ReadLine();
                if (new PersonContext().Persons.FirstOrDefault(search => search.Name == searchName) == null)//procura pelo nome
                {
                    Console.Write("\n Não foi encontrado nenhum contato com este Nome...");
                    Pause();
                    return;
                }
                else
                {
                    bool end = false;
                    int opc;
                    Person contact = new PersonContext().Persons.First(finded => finded.Name == searchName);//mapeia o contato para um objeto
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Contato:");

                        Console.WriteLine(contact.ToString());//imprime na tela o contato




                        Console.WriteLine("\n O que deseja Fazer?\n");
                        Console.WriteLine(" 1 - Editar Nome");
                        Console.WriteLine(" 2 - Editar Telefone");
                        Console.WriteLine(" 3 - Editar Celular");
                        Console.WriteLine(" 4 - Editar E-mail");
                        Console.WriteLine(" 5 - Excluir Contato");
                        Console.WriteLine(" 0 - Sair");
                        opc = int.Parse(Console.ReadLine());

                        switch (opc)
                        {
                            case 1:
                                Console.Write("\n Informe o novo Nome a ser Gravado: ");
                                contact.Name = Console.ReadLine();
                                using (var context = new PersonContext())
                                {
                                    context.Entry(contact).State = EntityState.Modified;
                                    context.SaveChanges();
                                }
                                Console.WriteLine("\n Nome Aleterado!");
                                Pause();
                                break;

                            case 2:
                                Console.Write("\n Informe o novo Telefone a ser Gravado: ");
                                contact.PhoneNumbers.Home = Console.ReadLine();
                                using (var context = new PersonContext())
                                {
                                    context.Entry(contact).State = EntityState.Modified;
                                    context.SaveChanges();
                                }
                                Console.WriteLine("\n Telefone Aleterado!");
                                Pause();
                                break;

                            case 3:
                                Console.Write("\n Informe o novo Celular a ser Gravado: ");
                                contact.PhoneNumbers.Mobile = Console.ReadLine();
                                using (var context = new PersonContext())
                                {
                                    context.Entry(contact).State = EntityState.Modified;
                                    context.SaveChanges();
                                }
                                Console.WriteLine("\n Celular Aleterado!");
                                Pause();
                                break;

                            case 4:
                                Console.Write("\n Informe o novo E-Mail a ser Gravado: ");
                                contact.Mail = Console.ReadLine();
                                using (var context = new PersonContext())
                                {
                                    context.Entry(contact).State = EntityState.Modified;
                                    context.SaveChanges();
                                }
                                Console.WriteLine("\n E-mail Aleterado!");
                                Pause();
                                break;

                            case 5:
                                bool flag = false;
                                string confirm;
                                Console.WriteLine("\n Você tem certeza de que deseja Excluir este Contato?");
                                do
                                {
                                    Console.WriteLine("\n Pressione [-- S --]-> Sim");
                                    Console.WriteLine(" Pressione [-- N --]-> Não");
                                    confirm = Console.ReadLine().ToUpper();

                                    switch (confirm)
                                    {
                                        case "S":
                                            using (var context = new PersonContext())
                                            {
                                                context.Entry(contact).State = EntityState.Deleted;
                                                context.Persons.Remove(contact);
                                                context.SaveChanges();
                                            }
                                            Console.Clear();
                                            Console.WriteLine("\n Contato Excluído!");
                                            Pause();
                                            flag = true;
                                            end = true;
                                            break;

                                        case "N":
                                            flag = true;
                                            break;

                                        default:
                                            Console.WriteLine("\n Opção Inválida!");
                                            break;
                                    }
                                } while (flag == false);
                                break;


                            case 0:
                                end = true;
                                break;

                            default:
                                Console.WriteLine("\n Escolha uma opção valida...");
                                Pause();
                                break;
                        }

                    } while (end == false);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("\n\nErro: <<<" + e + ">>> \n\n");
                Pause();
                throw;
            }
        }
        static void Pause()
        {
            Console.WriteLine("\n Aperte [-- ENTER --] para Continuar...");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
