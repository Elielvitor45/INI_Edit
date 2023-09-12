using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniEdit.src
{
    public class PlaylistIni
    {
        public string _path { get; set; }
        public Afiliadas afiliadas { get; set; }
        public Relogio relogio { get; set; }
        public Bloco bloco { get; set; }
        public PlaylistIni(string path)
        {
            if (path != null)
            {
                _path = path;
                _path += @"\PLAYLIST.ini";
                List<string> linhas;
                if (File.Exists(_path))
                {
                    linhas = File.ReadAllLines(_path).ToList();
                    if (linhas.Count > 0)
                    {
                        afiliadas = new Afiliadas(linhas);
                        relogio = new Relogio(linhas);
                        bloco = new Bloco(linhas);
                    }
                    else
                    {
                        Console.WriteLine("Playlist.Ini não existe");
                    }
                }
                
            }
        }
        public void Save() {
            List<string> linhas = new List<string>
            {
                relogio.getComercial(),
                relogio.getMusical(),
                bloco.getComercial(),
                bloco.getMusical(),
                afiliadas.getAfiliadas()
            };
            File.WriteAllLines(_path, linhas);
        }
        public override string ToString()
        {
            string parseString = "PlaylistIni------------------------------\n";
            parseString += relogio.getComercial();
            parseString += relogio.getMusical();
            parseString += bloco.getComercial();
            parseString += bloco.getMusical();
            parseString += afiliadas.getAfiliadas();
            parseString += "-----------------------------------------";
            return parseString;
        }
    }
}
