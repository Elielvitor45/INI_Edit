namespace IniEdit.src
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Playlist_Ini Playlist = new Playlist_Ini(@"C:\Playlist\pgm",0,2,0); 
            Playlist.SavePlaylist_Ini();


        }
    }
}