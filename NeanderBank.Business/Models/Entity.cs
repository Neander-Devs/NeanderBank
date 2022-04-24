using System;
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
        public bool HasNullValue(string[] exceptPropNames = null)
        {
            if(exceptPropNames == null) exceptPropNames = new string[0];
            var props = this.GetType().GetProperties().Where(p => !exceptPropNames.Contains(p.Name));
            foreach (var prop in props)
            {
                if (prop.GetValue(this) == null)
                    return true;
            }
            return false;
        }
    }
}