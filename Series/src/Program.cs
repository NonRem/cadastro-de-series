// See https://aka.ms/new-console-template for more information

using System;
using Series.Entities;
using Series.Enum;

namespace Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcao();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VizualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcao();
            }
            Console.WriteLine("Serviço finalizado.");
        }

        static string ObterOpcao()
        {
            Console.WriteLine("Serviço de registro de séries: ");
            Console.WriteLine("Escolha um serviço da lista abaixo: ");
            
            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir série");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Vizualizar série");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries: ");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine($"ID {serie.RetornaId()}: {serie.RetornaTitulo()} {(excluido ? "Excluído" : "")}");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir uma nova série: ");

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            
            Console.WriteLine("Escolha o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            
            Console.WriteLine("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Serie novaSerie = new Serie(id: repositorio.ProximoId(), 
                                                                    genero: (Genero)entradaGenero, 
                                                                    titulo: entradaTitulo, 
                                                                    descricao: entradaDescricao, 
                                                                    ano: entradaAno);
            
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar uma série: ");
            
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            
            Console.WriteLine("Escolha o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();
            
            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();
            
            Console.WriteLine("Digite o ano de lançamento da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Serie serieAtualizada = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero, 
                                            titulo: entradaTitulo, 
                                            descricao: entradaDescricao, 
                                            ano: entradaAno);
                                        
            repositorio.Atualiza(indiceSerie,serieAtualizada);
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Digite o id da série que deseja excluir: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var lista = repositorio.Lista();
            
            Console.WriteLine($"Tem certeza que deseja excluir a série {lista[indiceSerie].RetornaTitulo()}? (S/N)");
            string escolhaExcluir = Console.ReadLine();
            if (escolhaExcluir.ToUpper() == "S")
            {
                repositorio.Exclui(indiceSerie);
                Console.WriteLine("Série excluída.");
            }

        }

        private static void VizualizarSerie()
        {
            Console.WriteLine("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

    }
}
    

