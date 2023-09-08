namespace IniEdit.src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path;
            byte menu,menu2;
            Console.WriteLine("Adicione o caminho da pasta Playlist");
            path = Console.ReadLine();
            Console.Clear();
            PlaylistIni Playlist = new(@path);
            do
            {
                Console.WriteLine("Menu-------------------------------------");
                Console.WriteLine("Sair: (0)");
                Console.WriteLine("Bloco: (1)");
                Console.WriteLine("Relogio: (2)");
                Console.WriteLine("Afiliada: (3)");
                Console.WriteLine("Imprimir PlaylistIni: (4)");
                Console.WriteLine("-----------------------------------------");
                menu = byte.Parse(Console.ReadLine());
                Console.Clear();
                if (menu == 1)
                {
                    Console.WriteLine("Adicionar Bloco Comercial: (1)");
                    Console.WriteLine("Adicionar Bloco Musical: (2)");
                    Console.WriteLine("Imprimir Blocos: (3)");
                    menu2 = byte.Parse(Console.ReadLine());
                    Console.Clear();
                    if (menu2 == 1)
                    {
                        byte archiveType=5, formatType;
                        Console.WriteLine("Digite o formato-----------------");
                        Console.WriteLine("TXT1: (0) ");
                        Console.WriteLine("DBF: (1)");
                        Console.WriteLine("AUTO: (2)");
                        Console.WriteLine("---------------------------------");
                        formatType = byte.Parse(Console.ReadLine());
                        Console.Clear();
                        if (formatType != 2)
                        {
                            Console.WriteLine("Digite o Arquivo-----------------");
                            Console.WriteLine("Semanal: (0)");
                            Console.WriteLine("Arquivo: (1)");
                            Console.WriteLine("Data completa(Ano 4 digitos): (2)");
                            Console.WriteLine("Data completa(Ano 2 digitos): (3)");
                            Console.WriteLine("Numerico(seg=1,ter=2...): (4)");
                            Console.WriteLine("---------------------------------");
                            archiveType = byte.Parse(Console.ReadLine());
                            Console.Clear();
                        }
                        
                        Playlist.bloco.change(2,archiveType,formatType);
                        Console.WriteLine("Modificação Concluida!");;
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (menu2 == 2)
                    {
                        byte archiveType = 5, formatType;
                        Console.WriteLine("Digite o formato-----------------");
                        Console.WriteLine("TXT1: (0) ");
                        Console.WriteLine("DBF: (1)");
                        Console.WriteLine("AUTO: (2)");
                        Console.WriteLine("---------------------------------");
                        formatType = byte.Parse(Console.ReadLine());
                        Console.Clear();
                        if (formatType != 2)
                        {
                            Console.WriteLine("Digite o Arquivo-----------------");
                            Console.WriteLine("Semanal: (0)");
                            Console.WriteLine("Arquivo: (1)");
                            Console.WriteLine("Data completa(Ano 4 digitos): (2)");
                            Console.WriteLine("Data completa(Ano 2 digitos): (3)");
                            Console.WriteLine("Numerico(seg=1,ter=2...): (4)");
                            Console.WriteLine("---------------------------------");
                            archiveType = byte.Parse(Console.ReadLine());
                            Console.Clear();
                        }
                        Playlist.bloco.change(3, archiveType, formatType);
                        Console.WriteLine("Modificação Concluida!"); ;
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (menu2 == 3)
                    {
                        Console.WriteLine(Playlist.bloco.ToString());
                        Console.ReadKey();
                        Console.Clear();
                    }

                }
                else if (menu == 2)
                {
                    Console.WriteLine("Adicionar Relogio Comercial: (1)");
                    Console.WriteLine("Adicionar Relogio Musical: (2)");
                    Console.WriteLine("Imprimir Relogios: (3)");
                    menu2 = byte.Parse(Console.ReadLine());
                    Console.Clear();
                    if (menu2==1)
                    {
                        byte archiveType = 5, formatType;
                        Console.WriteLine("Digite o formato-----------------");
                        Console.WriteLine("TXT1: (0) ");
                        Console.WriteLine("DBF: (1)");
                        Console.WriteLine("---------------------------------");
                        formatType = byte.Parse(Console.ReadLine());
                        Console.Clear();
                        if (formatType != 2)
                        {
                            Console.WriteLine("Digite o Arquivo-----------------");
                            Console.WriteLine("Semanal: (0)");
                            Console.WriteLine("Arquivo: (1)");
                            Console.WriteLine("Data completa(Ano 4 digitos): (2)");
                            Console.WriteLine("Data completa(Ano 2 digitos): (3)");
                            Console.WriteLine("Numerico(seg=1,ter=2...): (4)");
                            Console.WriteLine("---------------------------------");
                            archiveType = byte.Parse(Console.ReadLine());
                            Console.Clear();
                        }

                        Playlist.relogio.change(0, archiveType, formatType);
                        Console.WriteLine("Modificação Concluida!"); ;
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (menu2 == 2)
                    {
                        byte archiveType = 5, formatType;
                        Console.WriteLine("Digite o formato-----------------");
                        Console.WriteLine("TXT1: (0) ");
                        Console.WriteLine("DBF: (1)");
                        Console.WriteLine("---------------------------------");
                        formatType = byte.Parse(Console.ReadLine());
                        Console.Clear();
                        if (formatType != 2)
                        {
                            Console.WriteLine("Digite o Arquivo-----------------");
                            Console.WriteLine("Semanal: (0)");
                            Console.WriteLine("Arquivo: (1)");
                            Console.WriteLine("Data completa(Ano 4 digitos): (2)");
                            Console.WriteLine("Data completa(Ano 2 digitos): (3)");
                            Console.WriteLine("Numerico(seg=1,ter=2...): (4)");
                            Console.WriteLine("---------------------------------");
                            archiveType = byte.Parse(Console.ReadLine());
                            Console.Clear();
                        }

                        Playlist.relogio.change(1, archiveType, formatType);
                        Console.WriteLine("Modificação Concluida!"); ;
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (menu2 == 3)
                    {
                        Console.WriteLine(Playlist.relogio.ToString());
                        Console.ReadKey();
                        Console.Clear();
                    }
                } 
                else if (menu == 3)
                {
                    Console.WriteLine("Adicionar Afiliada: (1)");
                    Console.WriteLine("Adicionar Afiliadas: (2)");
                    Console.WriteLine("Deletar Afiliada: (3)");
                    Console.WriteLine("Deletar Afiliadas: (4)");
                    Console.WriteLine("Imprimir Afiliadas: (5)");
                    menu2 = byte.Parse(Console.ReadLine());
                    Console.Clear();
                    if (menu2 == 1)
                    {
                        string nameAfiliada,ipafiliada;
                        Console.WriteLine("Digite o nome da Afiliada: ");
                        nameAfiliada= Console.ReadLine();
                        Console.WriteLine("Digite o ip da Afiliada: ");
                        ipafiliada= Console.ReadLine();
                        Playlist.afiliadas.Add(nameAfiliada,ipafiliada);
                        Console.WriteLine("Adição Feita com sucesso!");
                        Console.Clear();
                    }
                    else if (menu2 == 2)
                    {
                        int count=1;
                        do
                        {
                            string nameAfiliada, ipafiliada;
                            Console.WriteLine("Digite o nome da Afiliada: ");
                            nameAfiliada = Console.ReadLine();
                            Console.WriteLine("Digite o ip da Afiliada: ");
                            ipafiliada = Console.ReadLine();
                            Playlist.afiliadas.Add(nameAfiliada, ipafiliada);
                            Console.WriteLine("Adição Feita com sucesso!");
                            Console.Clear();
                            Console.WriteLine("Continuar Adicionando?: (1)");
                            count = int.Parse(Console.ReadLine());
                            Console.Clear();
                        } while (count==1);




                    }
                    else if (menu2 == 3)
                    {

                    }
                    else if (menu2 == 4)
                    {

                    }
                    else if (menu == 5)
                    {

                    }


                }
                else if (menu == 4)
                {
                    Console.WriteLine(Playlist.ToString());
                    Console.ReadKey();
                    Console.Clear();
                }
            } while (menu!=0);
        }
    }
}