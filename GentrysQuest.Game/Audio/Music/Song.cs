namespace GentrysQuest.Game.Audio.Music
{
    public class Song
    {
        private osu.Framework.Audio.AudioManager audioManager;
        public string ArtistName { get; private set; } = "artist name";
        public string SongName { get; private set; } = "song name";
        public string FileName { get; private set; } = "file.mp3";
        public TimingPointsHandler TimingPointsHandler { get; private set; }

        public Song(string filename, string artistName, string songName)
        {
            FileName = filename;
            ArtistName = artistName;
            SongName = songName;
        }
    }
}





// These are quotes my fellow co workers made on this file.

// "benis benis bines" - Payton Schutz
// "my meat is super big= 1v2" - Vitalijs Cameron
// "dont listen to vitsljis, hes got a 3.5 incher" - Payton Schutz
// "Elijah like CBT maximum pain" - Ellijah F (Secret last name)
