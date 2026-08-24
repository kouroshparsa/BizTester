using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace BizTester.Helpers
{
    class ColorFromMessageId
    {
        public static Color FromMessageId(string messageId)
        {
            // Hash the message ID
            var sha1 = SHA1.Create();
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(messageId));

            // Use first 2 bytes for hue (0–360)
            int hue = (hash[0] << 8 | hash[1]) % 360;

            // Fixed saturation & lightness for readability
            return FromHsl(hue, 0.65, 0.55);
        }

        private static Color FromHsl(double h, double s, double l)
        {
            double c = (1 - Math.Abs(2 * l - 1)) * s;
            double x = c * (1 - Math.Abs((h / 60) % 2 - 1));
            double m = l - c / 2;

            double r = 0, g = 0, b = 0;

            if (h < 60) { r = c; g = x; }
            else if (h < 120) { r = x; g = c; }
            else if (h < 180) { g = c; b = x; }
            else if (h < 240) { g = x; b = c; }
            else if (h < 300) { r = x; b = c; }
            else { r = c; b = x; }

            return Color.FromArgb(
                (int)((r + m) * 255),
                (int)((g + m) * 255),
                (int)((b + m) * 255)
            );
        }
    }
}
