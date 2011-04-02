using System;

namespace Rovidi.Blocks.App.Arguments
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AppArgument : Attribute
    {

        #region Properties

        public string Name { get; set; }

        public string Description { get; set; }

        public Type Type { get; set; }

        public object Value { get; set; }

        public bool IsRequired { get; set; }

        #endregion


        #region Constructors

        public AppArgument()
        {

        }

        #endregion

    }
}
