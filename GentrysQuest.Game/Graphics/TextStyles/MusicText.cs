using osu.Framework.Graphics;
using osu.Framework.Graphics.Sprites;

namespace GentrysQuest.Game.Graphics.TextStyles
{
    public sealed partial class MusicText : SpriteText
    {
        public MusicText(string artistName, string songName)
        {
            Text = $"{artistName} - {songName}";
            Origin = Anchor.TopRight;
            Anchor = Anchor.TopRight;
            Colour = Colour4.White;
            Alpha = 0f;

            this.FadeIn(500)
                .Then()
                .Delay(500)
                .Then()
                .FadeOut(500)
                .Finally(_ => Dispose());
        }
    }
}
