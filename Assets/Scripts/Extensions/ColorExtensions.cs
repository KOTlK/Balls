﻿using UnityEngine;

namespace Extensions
{
    public static class ColorExtensions
    {
        public static Color GetRandomColor(this Color color)
        {
            float r = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);

            return new Color(r, g, b, 1);
        }
        
    }
}