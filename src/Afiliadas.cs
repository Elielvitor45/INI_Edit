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
        public Afiliadas(List<string> playlistini)
        {
            load(playlistini);
        }
        private List<Afiliada> listAfiliada { get; set; } = new List<Afiliada>();
        public override string ToString()
        {
            string parseString = "Lista de Afiliadas----------------------------------\n";
            for (int i = 0; i < listAfiliada.Count;i++)
            {
                if (listAfiliada.Count == 0)
                {
                    parseString += "Não tem Afiliada";
                }
                else
                {
                    parseString += $"({i})-Afiliada -> {listAfiliada[i]}\n";
                }
            }
            parseString += "----------------------------------------------------";
            return parseString;
        }
        public string getAfiliadas() {
            if (listAfiliada.Count==0)
            {
                return "";
            }
            string afiliada= "[AFILIADAS]\n";
            for (int i = 0; i < listAfiliada.Count; i++)
            {
                afiliada += listAfiliada[i].ToString()+"\n";
            }
            return afiliada;
        }
        public bool Add(string nameAfiliada,string ipAfiliada)
        {
            if (ipAfiliada.Contains(":"))
            {
                int index = ipAfiliada.IndexOf(":");
                int port;
                if (int.TryParse(ipAfiliada.Substring(index+1),out port))
                {
                    if (port >= 1 && port < 65535 )
                    {
                        Afiliada afiliada = new(nameAfiliada, ipAfiliada);
                        listAfiliada.Add(afiliada);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Porta Invalida!");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Porta Invalida!");
                    return false;
                }
            }
            Console.WriteLine("Ip digitado Incorreto!");
            return false;
        }
        public bool delete(string nameAfiliada)
        {
            if (string.IsNullOrEmpty(nameAfiliada))
            {
                return false;
            }
            foreach (var item in listAfiliada)
            {
                if (item.getNameAfiliada().Equals(nameAfiliada))
                {
                    listAfiliada.Remove(item);
                    return true;
                }
            }
            return false;
        }
        public bool delete(byte index) {
            if (index<listAfiliada.Count)
            {
               listAfiliada.RemoveAt(index);
                Console.WriteLine("Exclusão Realizada com sucesso!");
                return true;
            }
            else
            {
                Console.WriteLine("Index Invalido!");
                return false;
            }
        }
        public bool deleteAfiliadas(List<byte> index) {
            for (int i = 0; i < listAfiliada.Count; i++)
            {
                if (index[i]<listAfiliada.Count)
                {
                    listAfiliada.RemoveAt(index[i]);

                }
                else
                {
                    Console.WriteLine("Index Invalido!");
                    return false;
                }
            }
            Console.WriteLine("Exclusão Realizada com sucesso!");
            return true;
        }
        private void load(List<string> _playlistIni)
        {
            var contain = _playlistIni.FirstOrDefault(x => x.Contains("[AFILIADAS]"));
            bool condition = false;
            if (!string.IsNullOrEmpty(contain))
            {
                for (int i = 0; i < _playlistIni.Count; i++)
                {
                    if (_playlistIni[i].Equals(contain) || condition)
                    {
                        condition = true;
                        if (_playlistIni.Count <= i+1)
                        {
                            break;
                        }
                        else if (!_playlistIni[i+1].StartsWith("[") && !string.IsNullOrEmpty(_playlistIni[i + 1]) )
                        {
                            Add(_playlistIni[i + 1].Split('=')[0], _playlistIni[i + 1].Split('=')[1]);                         
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
            }
        }
        public void AddRange(List<string> nameAfiliada,List<string> ipAfiliada)
        {
            if (nameAfiliada.Count > 0 && ipAfiliada.Count > 0)
            {
               for (int i = 0; i < nameAfiliada.Count; i++)
               {
                    Afiliada afiliada = new(nameAfiliada[i], ipAfiliada[i]);
                   listAfiliada.Add(afiliada);
               }

            }
        }
    }
}
