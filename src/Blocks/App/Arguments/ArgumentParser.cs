using System;
using System.Collections.Generic;
using Rovidi.Blocks.Core;
using System.Text.RegularExpressions;
using Rovidi.Blocks.Text.Regex;
using Rovidi.Blocks.Development;
using System.Reflection;


namespace Rovidi.Blocks.App.Arguments
{
    public class ArgumentParser
    {

        #region Fields

        private const string DEFAULT_ARG_PREFIX = "-";
        private const string DEFAULT_ARG_VALUE_SEPARATOR = ":";

        #endregion


        #region Public Methods

        // *******************************************************
        // Get this out of here!!!!!!!
        public List<KeyValuePair<T, PropertyInfo>> GetPropsWithAttributesList<T>(object obj) where T : Attribute
        {
            // Check
            if (obj == null) return new List<KeyValuePair<T, PropertyInfo>>();
            List<KeyValuePair<T, PropertyInfo>> map = new List<KeyValuePair<T, PropertyInfo>>();

            PropertyInfo[] props = obj.GetType().GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(typeof(T), true);
                if (attrs != null && attrs.Length > 0)
                    map.Add(new KeyValuePair<T, PropertyInfo>(attrs[0] as T, prop));
            }
            return map;
        }
        //**********************************************************



        /// <summary>
        /// Do the parse of the arguments to a object that represent them...
        /// That object must be annotated to perform the argument match.
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public IResult Parse(ref object argRepresentation, List<AppArgument> arguments)
        {
            IResult result = null;
            Assert.IsNotNull(argRepresentation);

            if (arguments == null || arguments.Count == 0)
                return result;

            // Get all the properties from the object with attributes we want :)
            List<KeyValuePair<AppArgument, PropertyInfo>> args = this.GetPropsWithAttributesList<AppArgument>(argRepresentation);


            return result;
        }

        /// <summary>
        /// Do the parse of the arguments to a bag of data...
        /// Arguments can be defined as: (in Regex Patterns...)
        ///     $prefix$<name>
        ///     $prefix$<name>$separator$<value>
        ///     
        ///   $prefix$ is optional...
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public IResult Parse(ref IDictionary<string, object> argValues, string[] arguments, string argSeparator, string argPrefix)
        {
            IResult result = null;

            if (arguments == null || arguments.Length == 0)
                return result;

            if (argValues == null)
                argValues = new Dictionary<string, object>();

            try
            {
                //TODO: Validate the prefix & separator before include them in the pattern ???

                foreach (var arg in arguments)
                {
                    Match isNameValueType = Regex.Match(arg, argPrefix + RegexPatterns.AppArgumentName + argSeparator + RegexPatterns.AppArgumentValue);
                    Match isNameType = Regex.Match(arg, argPrefix + RegexPatterns.AppArgumentName);

                    if (isNameValueType != null && isNameValueType.Success)
                    {
                        string name = isNameValueType.Groups["name"].Value;
                        string val = isNameValueType.Groups["value"].Value;

                        argValues.Add(name, val);
                    }
                    else if (isNameType != null && isNameType.Success)
                    {
                        string name = isNameType.Groups["name"].Value;
                        argValues.Add(name, true);
                    }
                    else
                    {
                        // Unnamed Arguemts
                    }
                }

                result = new Result(1);
            }
            catch (Exception exc)
            {
                result = new Result(exc, "");
            }

            return result;
        }

        #endregion

    }
}
