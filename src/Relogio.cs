using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniEdit.src
{
    public class Relogio
    {
        public string _relogio { get; set; }
        private byte _headerType { get; set; }
        private byte _archiveType { get; set; }
        private byte _formatType { get; set; }
        public Relogio(byte relogioType, byte ArchiveType, byte FormatType)
        {
            _headerType = relogioType;
            _archiveType = ArchiveType;
            _formatType = FormatType;
        }
        public List<string> UpdatePlaylist_Ini(List<string> _playlist_Ini) {
            string header = GetHeader().Split('%')[0];
            var condicion = _playlist_Ini.FirstOrDefault(x => x.Contains(header));
            if (!string.IsNullOrEmpty(condicion))
            {
                for (int i = 0; i < _playlist_Ini.Count; i++)
                {
                    if (_playlist_Ini[i].Equals(header))
                    {
                        _playlist_Ini[i] = header;
                        _playlist_Ini[i + 1] = GetFormat();
                        if (_playlist_Ini.Count <= i+2 )
                        {
                            _playlist_Ini.Add("");
                        }
                        _playlist_Ini[i + 2] = GetArchive();
                        break;
                    }
                }
                return _playlist_Ini;
            }
            else
            {
                //vai adicionar um espaco vazio, mas fica feio, pois caso ja tenha um espaco atrapalha, entao resolver isso com uma condicao
                _playlist_Ini.Add("");
                _playlist_Ini.Add(header);
                _playlist_Ini.Add(GetFormat());
                _playlist_Ini.Add(GetArchive());
                return _playlist_Ini;
            }   
        }
        protected string GetArchive() {
            string header = GetHeader().Split('%')[1];
            if (_archiveType == 0)
            {
                return $"ARQUIVO={header}\\Relogio%a.txt";
            } else if (_archiveType == 1) 
            {
                return $"ARQUIVO={header}\\Relogio.txt";
            }
            else if (_archiveType == 2)
            {
                return $"ARQUIVO={header}\\Relogio%d-%m-%Y.txt";
            }
            else if (_archiveType == 3)
            {
                return $"ARQUIVO={header}\\%w.txt";
            }
            else
            {
                return null;
            }
        }
        protected string GetFormat()
        {
            if (_formatType == 0)
            {
                return "FORMATO=TXT1";
            }
            else if (_formatType == 1)
            {
                return "FORMATO=DBF";
            }
            else
            {
                return null;
            }
        }
        protected string GetHeader()
        {
            //Arranjar uma solucao, pois nao fica legal ter essas duas coisas na mesma string
            if (_headerType == 0)
            {
                return "[RELOGIO COMERCIAL]%MAPAS";
            }
            else if (_headerType == 1)
            {
                return "[RELOGIO MUSICAL]%GRADES";
            }
            else { return null; }
        }
    }
}
