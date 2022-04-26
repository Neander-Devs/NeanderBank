using NeanderBank.Business.Config;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NeanderBank.Business.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }

        /// <summary>
        /// Checks if entity has any property with a null value
        /// </summary>
        /// <param name="exceptPropNames">Properties to exclude from list (allow null)</param>
        /// <returns>True if there's any null value, False if not</returns>
        public string[] GetNullValues(params string[] exceptPropNames)
        {
            if(exceptPropNames == null) exceptPropNames = new string[0];
            var props = this.GetType().GetProperties().Where(p => !exceptPropNames.Contains(p.Name));
            List<string> nullProps = new List<string>();
            foreach (var prop in props)
            {
                if (prop.GetValue(this) == null)
                    nullProps.Add(prop.Name);
            }
            return nullProps.ToArray();
        }

        public string[] GetTruncatedStrings()
        {
            var props = this.GetType().GetProperties().Where(p => p.PropertyType.Equals(typeof(string)));
            var types = props.Select(p => p.PropertyType).ToArray();
            List<string> truncated = new List<string>();
            foreach (var prop in props)
            {
                string value = (string)prop.GetValue(this);
                int max = AppSettings.StringLengths[this.GetType()][prop.Name];
                if (value.Length > max)
                    truncated.Add($"{prop.Name},{value.Length},{max}");
            }
            return truncated.ToArray();
        }
    }
}