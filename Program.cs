using System;

namespace Dio.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;

                    case "2":
                        InserirSeries();
                        break;

                    case "3":
                        atualizarSeries();
                        break;

                    case "4":
                        ExcluirSeries();
                        break;
                    case "5":
                          ExibirSeries();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
               
                opcaoUsuario = ObterOpcaoUsuario();
                
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();

            static void InserirSeries()
            {
                
                Console.WriteLine("Inserir nova Serie");

                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }

            Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Serie novaSerie = new Serie (Id: repositorio.ProximoId(),
                               genero: (Genero)entradaGenero,
                               Titulo: entradaTitulo,
                               Ano: entradaAno,
                               Descricao: entradaDescricao
                               );

			repositorio.Insere(novaSerie);
            }

            static void ListarSeries()
            {
                Console.WriteLine("Listar Series");

                var lista = repositorio.Lista();

                if (lista.Count == 0)
                {
                    Console.WriteLine("Nenhuma serie encontrada");
                    return;
                }

                foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
                    Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
                }

                
            }

            static string ObterOpcaoUsuario()
            {

                Console.WriteLine();
                Console.WriteLine("Bem vindo ao Catalogo de Series");
                Console.WriteLine("Informe a opção desejada!!!");

                Console.WriteLine("1- Listar Series");
                Console.WriteLine("2- Inserir Nova Serie");
                Console.WriteLine("3- Atualizar Serie");
                Console.WriteLine("4- Excluir Serie");
                Console.WriteLine("5- Exibir Serie");
                Console.WriteLine("C- Limpar Tela");
                Console.WriteLine("X- Sair");
                Console.WriteLine();

                string opcaoUsuario = Console.ReadLine().ToUpper();
                Console.WriteLine();
                return opcaoUsuario;
            }
        }

        private static void ExibirSeries()
        {
            Console.Write("Digite o id da serie:");
            int indiceSerie=int.Parse(Console.ReadLine());

            var serie= repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static void ExcluirSeries()
        {
            Console.Write("Digite o id da serie:");
            int indiceSerie=int.Parse(Console.ReadLine());
            repositorio.Exclui(indiceSerie);
        }

        private static void atualizarSeries()
        {
            Console.WriteLine("Digite o Id da serie: ");
            int indiceSerie= int.Parse(Console.ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }

            Console.WriteLine("Digite o genero entre as opcoes acima: ");
            int entradaGenero= int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Titulo da Serie: ");
            string entradaTitulo= Console.ReadLine();
            Console.WriteLine("Digite o Ano: ");
            int entradaAno= int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o genero entre as opcoes acima: ");
            string entradaDescricao= Console.ReadLine();

            Serie atualizaSerie= new Serie (Id: indiceSerie,
                        genero: (Genero)entradaGenero,
                        Titulo: entradaTitulo,
                        Ano: entradaAno,
                        Descricao: entradaDescricao);
            
            repositorio.Atualiza(indiceSerie, atualizaSerie);

            
        }
    }
}


