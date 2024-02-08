﻿using GentrysQuest.Game.Entity.Drawables;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Screens;
using osuTK.Graphics;
using GentrysQuest.Game.Entity;


namespace GentrysQuest.Game.Screens.Gameplay
{
    public partial class Gameplay : Screen
    {
        private Bindable<int> score = new(0);
        private DrawablePlayableEntity playerEntity;

        [BackgroundDependencyLoader]
        private void load()
        {
            InternalChildren = new Drawable[]
            {
                new Box
                {
                    Colour = ColourInfo.GradientVertical(Color4.DarkGray, Color4.White),
                    RelativeSizeAxes = Axes.Both
                }
            };
        }

        public void SetUp(Character character)
        {
            AddInternal(playerEntity = new(character));
        }

        public void End()
        {
            RemoveInternal(playerEntity, true);
        }
    }
}

