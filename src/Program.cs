namespace IniEdit.src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Playlist_Ini Playlist = new(@"C:\Playlist\pgm");

            List<string> name = new List<string>();
            List<string> ip = new List<string>();
            List<string> port = new List<string>();

            name.Add("Marcos");
            ip.Add("192.0.168.1.100");
            port.Add("3032");

            name.Add("Pedro");
            ip.Add("192.0.168.1.100");
            port.Add("3032");

            name.Add("Jardine");
            ip.Add("192.0.168.1.100");
            port.Add("3032");

            name.Add("Marquim");
            ip.Add("192.0.168.1.100");
            port.Add("3032");


            Playlist.ReadandSaveAfiliadas(name,ip,port);
            Playlist.SaveBlockPlaylist_Ini();
        }
    }
}