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
        public List<string> _playlistIni { get; set; }
        public Playlist_Ini(string path,byte headerType,byte archiveType,byte formatType)
        {
            if (path != null)
            {
                _path = path;
                _path += @"\PLAYLIST.ini";
                ReadPlaylist_Ini();
            }
            _headerType = headerType;
            _archiveType = archiveType;
            _formatType = formatType;
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
                relogio.UpdatePlaylist_Ini(_playlistIni);
            }



        }


        public void SavePlaylist_Ini() {
            ReadHeaderType();
            File.WriteAllLines(_path, _playlistIni);
        }
    }
}
