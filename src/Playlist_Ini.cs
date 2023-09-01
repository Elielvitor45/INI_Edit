using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IniEdit.src
{
    public class Playlist_Ini
    {
        public string _path { get; set; }
        public byte _headerType { get; set; }
        public byte _archiveType { get; set; }
        public byte _formatType { get; set; }
        private List<string> _playlistIni { get; set; }
        public Playlist_Ini(string path)
        {
            if (path != null)
            {
                _path = path;
                _path += @"\PLAYLIST.ini";
                ReadPlaylist_Ini();
            }
        }
        public void ReadandSaveBlock(byte headerType, byte archiveType, byte formatType) {
            _headerType = headerType;
            _archiveType = archiveType;
            _formatType = formatType;
            ReadHeaderType();
        }
        public void ReadandSaveAfiliadas(List<string> nameAfiliada,List<string> ipAfiliada,List<string> portAfiliada) { 
            Afiliadas afiliadas = new Afiliadas();
            afiliadas.AddRangeAfiliada(nameAfiliada, ipAfiliada, portAfiliada);
            UpdatePlaylist_Ini(afiliadas);
        }
        private bool IsAfiliadaDuplicate(Afiliada afiliada) {
            var condicion = _playlistIni.FirstOrDefault(x => x.Contains(afiliada.getNameAfiliada()));
            if (string.IsNullOrEmpty(condicion))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void UpdatePlaylist_Ini(Afiliadas afiliadas) {
            var condicion = _playlistIni.FirstOrDefault(x => x.Contains("[AFILIADAS]"));
            if (string.IsNullOrEmpty(condicion))
            {
                if (!string.IsNullOrEmpty(_playlistIni.Last()))
                {
                    _playlistIni.Add("");
                }
                _playlistIni.Add("[AFILIADAS]");
            }
            if (afiliadas.listAfiliada.Count > 0)
            {
                for (int i = 0; i < afiliadas.listAfiliada.Count; i++)
                {
                    if (IsAfiliadaDuplicate(afiliadas.listAfiliada[i]))
                    {
                        _playlistIni.Add(afiliadas.listAfiliada[i].ToString());
                    }
                    else
                    {
                    }
                }
            }
        }
        private void UpdatePlaylist_Ini(Relogio headers)
        {
            var condicion = _playlistIni.FirstOrDefault(x => x.Contains(headers.header));
            if (!string.IsNullOrEmpty(condicion))
            {
                for (int i = 0; i < _playlistIni.Count; i++)
                {
                    if (_playlistIni[i].Equals(headers.header))
                    {
                        _playlistIni[i] = headers.header;
                        _playlistIni[i + 1] = headers.format;
                        if (_playlistIni.Count <= i + 2)
                        {
                            _playlistIni.Add("");
                        }
                        _playlistIni[i + 2] = headers.archive;
                        break;
                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(_playlistIni[_playlistIni.Count - 1]))
                {
                    _playlistIni.Add("");
                }
                _playlistIni.Add(headers.header);
                _playlistIni.Add(headers.format);
                _playlistIni.Add(headers.archive);
            }
        }
        private bool ReadPlaylist_Ini() {
            _playlistIni = File.ReadAllLines(_path).ToList();
            if (_playlistIni.Count > 0)
            {
                return true;
            } else {
                return false;
            }
        }
        private void ReadHeaderType() {
            if (_headerType == 0 || _headerType == 1)
            {
                Relogio relogio = new Relogio(_headerType, _archiveType, _formatType);
                UpdatePlaylist_Ini(relogio);
            }
            else if (_headerType == 2 || _headerType == 3)
            {
                Bloco bloco = new Bloco(_headerType, _archiveType, _formatType);
                UpdatePlaylist_Ini(bloco);
            }
        }
        public void SaveBlockPlaylist_Ini() { 
            File.WriteAllLines(_path, _playlistIni);
        }
    }
}
