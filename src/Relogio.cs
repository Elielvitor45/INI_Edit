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
        protected string headerMusical { get; set; }
        protected string headerComercial { get; set; }
        protected string type { get; set; }
        protected string diretory { get; set; }
        protected Relogio() { } 
        public Relogio(List<string> playlistini)
        {
            loadMusical(playlistini,"[RELOGIO MUSICAL]");
            loadComercial(playlistini,"[RELOGIO COMERCIAL]");
            cheking(playlistini);
        }
        public override string ToString()
        {
            string parseString = "---------------------------------------------\n";
            parseString += headerMusical + "\n";
            parseString += headerComercial;
            parseString += "---------------------------------------------";
            return parseString;
        }
        public string getMusical() {
            if (!string.IsNullOrEmpty(headerMusical))
            {
                return headerMusical+"\n";
            }
            else
            {
                return "";
            }
        }
        public string getComercial() {
            if (!string.IsNullOrEmpty(headerComercial))
            {
                return headerComercial+"\n";
            }
            else
            {
                return "";
            }
        }
        public void change(byte headerType, byte ArchiveType, byte FormatType) {
            _headerType = headerType;
            _archiveType = ArchiveType;
            _formatType = FormatType;
            change();
        }
        protected virtual void change()
        {
            if (_headerType == 0)
            {
                if (string.IsNullOrEmpty(ReadHeader()))
                {
                    Console.WriteLine("ERRO");
                    return;
                }
                headerComercial = ReadHeader()+"\n";
                headerComercial += ReadFormat()+"\n";
                headerComercial += ReadArchive()+"\n";
            }
            else if (_headerType == 1)
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
        protected virtual void loadComercial(List<string> _playlistIni,string header)
        {
            var contain = _playlistIni.FirstOrDefault(x => x.Contains(header));
            if (!string.IsNullOrEmpty(contain))
            {
                for (int i = 0; i < _playlistIni.Count; i++)
                {
                    if (_playlistIni[i].Equals(contain))
                    {
                        headerComercial = _playlistIni[i]+"\n";
                        headerComercial += _playlistIni[i + 1]+"\n";
                        if (_playlistIni.Count > i+2)
                        {
                            headerComercial += _playlistIni[i + 2]+"\n";
                        }
                    }
                }
            }
            else
            {
            }
        }
        protected virtual void loadMusical(List<string> _playlistIni,string header)
        {
            var contain = _playlistIni.FirstOrDefault(x => x.Contains(header));
            bool condition = false;
            if (!string.IsNullOrEmpty(contain))
            {
                for (int i = 0; i < _playlistIni.Count; i++)
                {
                    if (_playlistIni[i].Equals(contain))
                    {
                        headerMusical = _playlistIni[i] + "\n";
                        headerMusical += _playlistIni[i + 1] + "\n";
                        if (_playlistIni.Count > i + 2)
                        {
                            headerMusical += _playlistIni[i + 2] + "\n";
                        }
                    }
                }
            }
            else
            {
            }
        }
        protected virtual string chekingFormat(string format)
        {
            if (format.EndsWith("TXT1"))
            {
                return "0@";
            }
            else if (format.EndsWith("DBF"))
            {
                return "1@";
            }
            else
            {
                return "3@";
            }
        }
        protected string chekingArchive(string archive)
        {
            if (archive.EndsWith("a.txt"))
            {
                return "0@";
            }
            else if (archive.EndsWith("%d-%m-%Y.txt"))
            {
                return "2@";
            }
            else if (archive.EndsWith("%d-%m-%y.txt"))
            {
                return "3@";
            }
            else if (archive.EndsWith("%w.txt"))
            {
                return "4@";
            }
            else if (archive.EndsWith(""))
            {
                return "-1@";
            }
            else
            {
                return "1@";
            }
        }
        protected string cheking(List<string> _playlistIni,string header) { 
            var contain = _playlistIni.FirstOrDefault(x => x.Contains(header));
            string cheking = "1@";
            if (string.IsNullOrEmpty(contain))
            {
                cheking = string.Empty;
            }
            else
            {
                for (int i = 0; i < _playlistIni.Count; i++)
                {
                    if (_playlistIni[i].Equals(contain))
                    {
                        cheking += chekingFormat(_playlistIni[i+1]);
                        if (_playlistIni.Count <= i+2)
                        {
                            _playlistIni.Add("");
                        }
                        cheking += chekingArchive(_playlistIni[i + 2]);
                        break;
                    }
                }
            }
            return cheking;
        }
        public virtual string cheking(List<string> _playlistIni)
        {
            string check ="";
            check += cheking(_playlistIni,"[RELOGIO COMERCIAL]");
            check += cheking(_playlistIni,"[RELOGIO MUSICAL]");
            return check;
        }
        protected virtual string ReadArchive() {
            if (_archiveType == 0)
            {
                return $"ARQUIVO={diretory}\\{type}%a.txt";
            } else if (_archiveType == 1) 
            {
                return $"ARQUIVO={diretory}\\{type}.txt";
            }
            else if (_archiveType == 2)
            {
                return $"ARQUIVO={diretory}\\{type}%d-%m-%Y.txt";
            }
            else if (_archiveType == 3)
            {
                return $"ARQUIVO={diretory}\\{type}%d-%m-%y.txt";
            }
            else if (_archiveType == 4)
            {
                return $"ARQUIVO={diretory}\\{type}%w.txt";
            }
            return "";
        }
        protected virtual string ReadFormat()
        {
            if (_formatType == 0)
            {
                return "FORMATO=TXT1";
            }
            else if (_formatType == 1)
            {
                return "FORMATO=DBF";
            }
            return "";
        }
        protected virtual string ReadHeader()
        {
            if (_headerType == 0)
            {
                diretory = "MAPAS";
                type = "Relogio";
                return "[RELOGIO COMERCIAL]";
            }
            else if (_headerType == 1)
            {
                diretory = "GRADES";
                type = "Relogio";
                return "[RELOGIO MUSICAL]";
            }
            return "";
        }
    }
}
