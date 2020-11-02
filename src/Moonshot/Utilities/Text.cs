using System;
using System.Collections.Generic;
using System.Text;

namespace Moonshot.Utilities
{
    public static class Text
    {
        public static int Center(float renderWidth, int textWidth)
        {
            return (int)(renderWidth / 2) - (textWidth / 2);
        }
    }
}
