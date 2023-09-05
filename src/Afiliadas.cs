using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace IniEdit.src
{
    public class Afiliadas
    {
        
        public Afiliadas()
        {
        }
        public List<Afiliada> listAfiliada;
        public void Add(string nameAfiliada,string ipAfiliada)
        {
            listAfiliada = new List<Afiliada>();
            Afiliada afiliada = new(nameAfiliada, ipAfiliada);
            listAfiliada.Add(afiliada);
        }
        public string affiliateTable(List<string> _playlistIni)
        {
            var contain = _playlistIni.FirstOrDefault(x => x.Contains("[AFILIADAS]"));
            int cont = 0;
            string table="Afiliadas------------------------------------\n";
            if (!string.IsNullOrEmpty(contain))
            {
                for (int i = 0; i < _playlistIni.Count; i++)
                {
                    if (_playlistIni[i].Equals(contain) || cont == 1)
                    {
                        cont = 1;
                        if (_playlistIni.Count <= i+1)
                        {
                            table += "---------------------------------------------";
                            break;
                        }
                        else if (!_playlistIni[i+1].StartsWith("["))
                        {
                            table += _playlistIni[i+1]+"\n";
                        }
                        else
                        {
                            table += "---------------------------------------------";
                            break;
                        }
                    }
                }
                return table;
            }
            else
            {
                return "Não existe afiliadas";

            }
        }
        public void AddRange(List<string> nameAfiliada,List<string> ipAfiliada)
        {
            listAfiliada = new List<Afiliada>();
            for (int i = 0; i < nameAfiliada.Count; i++)
            {
                Afiliada afiliada = new(nameAfiliada[i], ipAfiliada[i]);
                listAfiliada.Add(afiliada);
            }
        }
    }
}
