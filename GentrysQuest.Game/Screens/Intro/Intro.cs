﻿using System.Collections.Generic;
using System.Linq;
using GentrysQuest.Game.Audio;
using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Extensions.IEnumerableExtensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Audio;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;

namespace GentrysQuest.Game.Screens.Intro
{
    public partial class Intro : Screen
    {
        private Sprite logo;
        private TextFlowContainer framework;
        // private readonly Song theme = SongCollection.get_song("Classic Gentry's Theme");
        private DrawableTrack theme;
        private readonly List<ITextPart> osuText = new List<ITextPart>();
        private readonly Screen nextScreen;

        public Intro(Screen nextScreen = null) { this.nextScreen = nextScreen; }

        [BackgroundDependencyLoader]
        private void load(TextureStore textures, ITrackStore trackStore)
        {
            this.theme = new DrawableTrack(trackStore.Get("GentrysTheme.mp3"));
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Colour = Color4.Black,
                    RelativePositionAxes = Axes.Both,
                },
                logo = new Sprite
                {
                    Texture = textures.Get(@"logo"),
                    Alpha = 0,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Size = new Vector2(500, 500)
                },
                framework = new TextFlowContainer
                {
                    Width = 680,
                    Height = 240,
                    Y = -200,
                    Alpha = 0,
                    TextAnchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Anchor = Anchor.Centre,
                }
            };
        }

        public override void OnEntering(ScreenTransitionEvent e)
        {
            GentryAudioManager.ChangeMusic(theme, "Bandito", "Gentrys Classic Theme");
            logo.Delay(1000).Then()
                .FadeInFromZero(1200, Easing.InOutBounce);

            osuText.Add(framework.AddText("osu!", t =>
            {
                t.Font = t.Font.With(size: 60);
                t.Alpha = 0;
                t.Scale = new Vector2(0, 1);
            }));
            framework.AddText("Framework", t =>
            {
                t.Font = t.Font.With(size: 60);
                t.Colour = ColourInfo.GradientVertical(Color4.White, Color4.DarkGray);
            });

            framework.Delay(3000).Then()
                     .FadeInFromZero(400, Easing.InExpo);

            Schedule(() => osuText.SelectMany(t => t.Drawables).ForEach(t =>
            {
                t.Delay(6575).Then()
                 .FadeIn(100)
                 .ScaleTo(new Vector2(1, 1), 100, Easing.OutQuart);
                t.Colour = Color4.LightPink;
            }));

            this.Delay(9500)
                .Then()
                .FadeOut(3600, Easing.Out)
                .Finally(_ =>
                {
                    if (nextScreen != null) this.Push(nextScreen);
                });
        }

        public override void OnSuspending(ScreenTransitionEvent e)
        {
            this.FadeIn(500, Easing.OutQuint);
        }
    }
}
