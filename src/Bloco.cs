using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniEdit.src
{
    public class Bloco:Relogio
    {
  
        public Bloco(List<string> playlistini):base()
        {
            loadMusical(playlistini, "[BLOCO MUSICAL]");
            loadComercial(playlistini,"[BLOCO COMERCIAL]");
            cheking(playlistini);
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
        protected override string ReadArchive()
        {
            if (_formatType == 2)
            {
                return "";
            }
            else 
            {
                return base.ReadArchive();
            }
        }
        protected override string ReadFormat() {
            if (_formatType == 2)
            {
                return"FORMATO=AUTO";
            }
            else { 
                return base.ReadFormat(); 
            }
        }
        protected override string ReadHeader()
        {
            if (_headerType == 2)
            {
                diretory = "MAPAS";
                type = "Mapa";
                return "[BLOCO COMERCIAL]";
            }
            else if (_headerType == 3)
            {
                diretory = "GRADES";
                type = "Grade";
                return "[BLOCO MUSICAL]";
            }
            return "";
        }
        protected override void change()
        {
            if (_headerType == 2)
            {
                if (string.IsNullOrEmpty(ReadHeader()))
                {
                    Console.WriteLine("ERRO");
                    return;
                }
                headerComercial = ReadHeader() + "\n";
                headerComercial += ReadFormat() + "\n";
                headerComercial += ReadArchive() + "\n";
            }
            else if (_headerType == 3)
            {
                if (string.IsNullOrEmpty(ReadHeader()))
                {
                    Console.WriteLine("ERRO");
                    return;
                }
                headerMusical = ReadHeader() + "\n";
                headerMusical += ReadFormat() + "\n";
                headerMusical += ReadArchive() + "\n";
            }
        }
    }
}
