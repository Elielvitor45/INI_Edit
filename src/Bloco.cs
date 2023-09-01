using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniEdit.src
{
    public class Bloco:Relogio
    {
        public Bloco(byte headerType, byte ArchiveType, byte FormatType):base(headerType, ArchiveType, FormatType)
        {
        }
        protected override void ReadArchive()
        {
            if (_formatType == 2)
            {
                archive = "";
            }
            else 
            {
                base.ReadArchive();
            }
        }
        protected override void ReadFormat() {
            if (_formatType == 2)
            {
                format = "FORMATO=AUTO";
            }
            else { 
                base.ReadFormat(); 
            }
        }
        protected override void ReadHeader()
        {
            if (_headerType == 2)
            {
                header = "[BLOCO COMERCIAL]";
                diretory = "MAPAS";
                type = "Mapa";

            }
            else if (_headerType == 3)
            {
                header = "[BLOCO MUSICAL]";
                diretory = "GRADES";
                type = "Grade";

            }
        }
    }
}
