﻿using Common.Values;

namespace Compendium.API
{
    public class UserId : IGetValue<string>
    {
        public string Value { get; }

        public static UserId Get(string userId)
        {

        }
    }
}