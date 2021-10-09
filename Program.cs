using System;

namespace exer
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
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        DeletarSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.WriteLine();
                        break;
                    case "X":
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();

            }
            Console.WriteLine("Obrigado por utilizar nosso serviço");
            Console.ReadLine();
        }
        public static void ListarSeries()
        {
            Console.WriteLine("Lista de Series!");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma serie cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                Console.Write("#ID: {0}: - {1}", serie.RetornaId(), serie.RetornaTitulo());
            }

        }
        private static void InserirSerie()
        {
            Console.WriteLine("Insira Serie");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero: ");
            int genero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o titulo: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite a descrição: ");
            string descricao = Console.ReadLine();
            Console.WriteLine("Digite o ano de inicio");
            int ano = int.Parse(Console.ReadLine());
            Series novaSerie = new Series(
                id: repositorio.ProximoId(),
                genero: (Genero)genero,
                titulo: titulo,
                descricao: descricao,
                ano: ano);
            repositorio.Inserte(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o Id da serie que quer atualizar: ");
            int id = int.Parse(Console.ReadLine());
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o genero: ");
            int genero = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o titulo: ");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite a descrição: ");
            string descricao = Console.ReadLine();
            Console.WriteLine("Digite o ano de inicio");
            int ano = int.Parse(Console.ReadLine());
            Series novaSerie = new Series(
                id: id,
                genero: (Genero)genero,
                titulo: titulo,
                descricao: descricao,
                ano: ano);
            repositorio.Atualiza(id, novaSerie);

        }

        private static void DeletarSerie()
        {
            Console.WriteLine("Digite o id da serie que deseja excluir");
            int id = int.Parse(Console.ReadLine());
            repositorio.Exclui(id);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Digite o Id da serie");
            int id = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(id);
            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Series!!!");
            Console.WriteLine("Opções: ");
            Console.WriteLine("1 - Listar series");
            Console.WriteLine("2 - Inserir serie");
            Console.WriteLine("3 - Atualizar serie");
            Console.WriteLine("4 - Deletar Serie");
            Console.WriteLine("5 - Visualizar Serie");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine("");
            return opcaoUsuario;

        }
    }
}
