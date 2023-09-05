using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniEdit.src
{
    public class Bloco:Relogio
    {
        public Bloco():base() { }
        public Bloco(byte headerType, byte ArchiveType, byte FormatType):base(headerType, ArchiveType, FormatType)
        {
        }
        public override string cheking(List<string> _playlistIni)
        {
            string check = "";
            check += cheking(_playlistIni,"[BLOCO COMERCIAL]");
            check += cheking(_playlistIni,"[BLOCO MUSICAL]");
            return check;
        }
        protected override string chekingFormat(string format) {
            if (format.EndsWith("AUTO"))
            {
                return "2@";
            }
            else
            {
                return base.chekingFormat(format);
            }
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
