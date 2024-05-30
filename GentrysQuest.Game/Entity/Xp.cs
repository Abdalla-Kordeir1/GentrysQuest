﻿using System;
using osu.Framework.Bindables;

namespace GentrysQuest.Game.Entity
{
    /// <summary>
    /// Xp management class
    /// </summary>
    public class Xp(int current = 0)
    {
        public Bindable<int> Current { get; private set; } = new Bindable<int>(current);
        public Bindable<int> Requirement = new();
        public double Progress { get; private set; }

        public bool add_xp(ref int amount)
        {
            if (Current.Value + amount >= Requirement.Value)
            {
                amount -= (Requirement.Value - Current.Value);
                Current.Value = 0;
                return true;
            }

            Current.Value += amount;

            if (Requirement.Value > 0) Progress = MathF.Round((float)Current.Value / Requirement.Value * 100);
            else Progress = 100;
            return false;
        }

        public void CalculateRequirement(int level, int starRating)
        {
            int difficulty = 1 + (level / 20);
            int starRatingExperience = starRating * 25;
            int levelExperience = level * 10;

            Requirement.Value = level * difficulty * difficulty * 100 + levelExperience + starRatingExperience;
        }

        public override string ToString()
        {
            return $"{Current.Value}/{Requirement.Value} ({Progress}%)";
        }
    }
}
