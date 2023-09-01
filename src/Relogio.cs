using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniEdit.src
{
    public class Relogio
    {
        protected byte _headerType { get; set; }
        protected byte _archiveType { get; set; }
        protected byte _formatType { get; set; }
        public string header { get; set; }
        public string archive { get; set; }
        public string format { get; set; }
        protected string type { get; set; }
        protected string diretory { get; set; }
        public Relogio(byte headerType, byte ArchiveType, byte FormatType)
        {
            _headerType = headerType;
            _archiveType = ArchiveType;
            _formatType = FormatType;
            ReadHeader();
            ReadArchive();
            ReadFormat();
        }
        protected virtual void ReadArchive() {
            if (_archiveType == 0)
            {
                archive = $"ARQUIVO={diretory}\\{type}%a.txt";
            } else if (_archiveType == 1) 
            {
                archive = $"ARQUIVO={diretory}\\{type}.txt";
            }
            else if (_archiveType == 2)
            {
                archive = $"ARQUIVO={diretory}\\{type}%d-%m-%Y.txt";
            }
            else if (_archiveType == 3)
            {
                archive = $"ARQUIVO={diretory}\\{type}%d-%m-%y.txt";
            }
            else if (_archiveType == 4)
            {
                archive = $"ARQUIVO={diretory}\\{type}%w.txt";
            }
        }
        protected virtual void ReadFormat()
        {
            if (_formatType == 0)
            {
                format =  "FORMATO=TXT1";
            }
            else if (_formatType == 1)
            {
                format = "FORMATO=DBF";
            }
        }
        protected virtual void ReadHeader()
        {
            if (_headerType == 0)
            {
                header = "[RELOGIO COMERCIAL]";
                diretory = "MAPAS";
                type = "Relogio";
            }
            else if (_headerType == 1)
            {
                header = "[RELOGIO MUSICAL]";
                diretory = "GRADES";
                type = "Relogio";

            }
        }
    }
}
