namespace IniEdit.src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlaylistIni Playlist = new(@"C:\Playlist\pgm");
            // area para testes
            string name;
            string ip;
            int num = 1;
            int menu;
            int quantidadedeafiliadas;
            List<string> names = new List<string>();
            List<string> ips = new List<string>();
            Console.WriteLine("Adicionar Afiliada");
            do
            {
                Console.WriteLine("Adicionar uma afiliada (0)");
                Console.WriteLine("Adicionar varias afiliadas(1)");
                Console.WriteLine("Deletar Afiliada (2):");
                menu = int.Parse(Console.ReadLine());
                if (menu == 0)
                {
                    Console.WriteLine("Name: ");
                    name = Console.ReadLine();
                    Console.WriteLine("IP:");
                    ip = Console.ReadLine();
                    Playlist.addAfiliada(name, ip);
                }
                else if (menu == 1)
                {
                    Console.WriteLine("Quantas afiliadas vai adicionar:");
                    quantidadedeafiliadas = int.Parse(Console.ReadLine());
                    for (int i = 0; i < quantidadedeafiliadas; i++) 
                    {
                        Console.WriteLine("Name: ");
                        names.Add(Console.ReadLine());
                        Console.WriteLine("Ip: ");
                        ips.Add(Console.ReadLine());
                    }
                    Playlist.addRangeAfiliada(names,ips);
                }
                else if (menu == 2)
                {
                    Console.WriteLine("Name: ");
                    name = Console.ReadLine();
                    Playlist.deleteAfiliada(name);

                }
                Console.WriteLine("Sair: 0");
                num = int.Parse(Console.ReadLine());
            } while (num != 0);
            Playlist.Save();
        }
    }
}