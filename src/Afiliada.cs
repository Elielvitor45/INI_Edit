using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniEdit.src
{
    public class Afiliada
    {
        private string _ipAfiliada { get; set; }
        private string _nameAfiliada { get; set; }
        public string getNameAfiliada() {
            return _nameAfiliada;
        }
        public Afiliada(string nameAfiliada,string ipAfiliada)
        {
            _ipAfiliada = ipAfiliada;
            _nameAfiliada= nameAfiliada;
        }
        public override string ToString() {
            string parseString;
            parseString = (_nameAfiliada+"="+_ipAfiliada);
            return parseString;
        }

    }
}
