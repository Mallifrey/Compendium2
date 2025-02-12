﻿using UnityEngine;

namespace Compendium.API.Utilities
{
    public struct ClientRotation
    {
        public readonly ushort HorizontalAxis;
        public readonly ushort VerticalAxis;

        public ClientRotation(ushort horizontal, ushort vertical)
        {
            HorizontalAxis = horizontal;
            VerticalAxis = vertical;
        }

        public ClientRotation(Quaternion rotation)
        {
            if (rotation.eulerAngles.z != 0f)
                rotation = Quaternion.LookRotation(rotation * Vector3.forward, Vector3.up);

            var outfHorizontal = rotation.eulerAngles.y;
            var outfVertical = -rotation.eulerAngles.x;

            if (outfVertical < -90f)
                outfVertical += 360f;
            else if (outfVertical > 270f)
                outfVertical -= 360f;

            HorizontalAxis = (ushort)Mathf.RoundToInt(Mathf.Clamp(outfHorizontal, 0f, 360f) * (65535f / 360f));
            VerticalAxis = (ushort)Mathf.RoundToInt((Mathf.Clamp(outfVertical, -88f, 88f) + 88f) * (65535 / 176f));
        }

        public ClientRotation(Vector3 rotation)
            : this(new Quaternion(rotation.x, rotation.y, rotation.z, 0f)) { }
    }
}