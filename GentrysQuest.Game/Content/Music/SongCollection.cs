using System.Collections.Generic;
using GentrysQuest.Game.Audio.Music;

namespace GentrysQuest.Game.Content.Music
{
    public static class SongCollection
    {
        private static List<Song> Songs = new List<Song>
        {
            new("GentrysTheme.mp3", "Bandito", "Classic Gentry's Theme")
        };

        public static Song get_song(string name)
        {
            foreach (var song in Songs)
            {
                if (song.SongName == name) return song;
            }

            return null;
        }
    }
}
