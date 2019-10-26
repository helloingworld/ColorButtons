using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ColorButtons
{

    internal static class ColorUtils
    {

        public static IEnumerable<Color> GetWebColors()
        {
            return Enum.GetValues(typeof(KnownColor))
            .Cast<KnownColor>()
            .Where(k => k > KnownColor.Transparent && k < KnownColor.ButtonFace) // Exclude system colors
            .Select(k => Color.FromKnownColor(k));
        }
    }

}