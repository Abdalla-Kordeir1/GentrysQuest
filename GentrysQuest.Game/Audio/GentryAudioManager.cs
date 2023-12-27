﻿using System;
using GentrysQuest.Game.Graphics.TextStyles;
using JetBrains.Annotations;
using osu.Framework.Audio;
using osu.Framework.Graphics.Audio;
using osu.Framework.Logging;

namespace GentrysQuest.Game.Audio
{
    public static class GentryAudioManager
    {
        private static Volume gameVolume = new Volume(1);
        private static Volume musicVolume = new Volume(1);
        private static Volume soundVolume = new Volume(1);
        private static MusicText musicText;

        [CanBeNull]
        private static DrawableTrack gameMusic;

        private static int fadeTime = 5000;

        public static void ChangeMusic(DrawableTrack track, string ArtistName, string SongName)
        {
            track.Looping = true;

            Action modifyTrack = () =>
            {
                gameMusic = track;
                new MusicText(ArtistName, SongName);
                gameMusic.Start();
                gameMusic.VolumeTo(musicVolume.Amount, fadeTime);
            };

            Logger.Log($"music volume is {musicVolume.Amount}");

            if (gameMusic == null)
            {
                gameMusic = track;
                gameMusic.VolumeTo(0);
                gameMusic.Start();
                gameMusic.VolumeTo(musicVolume.Amount, fadeTime);
            }
            else
            {
                gameMusic.VolumeTo(0, fadeTime).Then().Finally(_ => modifyTrack());
            }
        }

        public static void ChangeMusicVolume(int percent) { musicVolume.Amount = (double)percent / 100 / gameVolume.Amount; }

        private static void adjustMusicVolume() { ChangeMusicVolume((int)musicVolume.Amount * 100); }

        public static void ChangeSoundVolume(int percent) { soundVolume.Amount = (double)percent / 100 / gameVolume.Amount; }

        private static void adjustSoundVolume() { ChangeSoundVolume((int)soundVolume.Amount * 100); }

        public static void ChangeGameVolume(int percent)
        {
            gameVolume.Amount = (double)percent / 100;
            adjustMusicVolume();
            adjustSoundVolume();
        }
    }
}
