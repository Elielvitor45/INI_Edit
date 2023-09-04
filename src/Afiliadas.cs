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
