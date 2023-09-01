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
        public void AddRangeAfiliada(List<string> nameAfiliada,List<string> ipAfiliada,List<string>portAfiliada)
        {
            listAfiliada = new List<Afiliada>();
            for (int i = 0; i < nameAfiliada.Count; i++)
            {
                Afiliada afiliada = new(nameAfiliada[i], ipAfiliada[i], portAfiliada[i]);
                listAfiliada.Add(afiliada);
            }
        }
    }
}
