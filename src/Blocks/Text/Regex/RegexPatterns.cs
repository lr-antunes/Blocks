using System;

namespace Rovidi.Blocks.Text.Regex
{
    public class RegexPatterns
    {

        #region Static Fields

        public static readonly string AppArgumentName = @"(?<name>[a-zA-Z0-9\-_]+)";
        public static readonly string AppArgumentValue = @"(?<value>.+)";

        #endregion

    }
}
