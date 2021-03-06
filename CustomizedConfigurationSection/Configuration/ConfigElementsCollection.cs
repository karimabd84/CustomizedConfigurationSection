﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomizedConfigurationSection.Configuration
{
    [ConfigurationCollection(typeof(ConfigElement), AddItemName = "ConfigElement")]
    public class ConfigElementsCollection : ConfigurationElementCollection, IEnumerable<ConfigElement>
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            var l_configElement = element as ConfigElement;
            if (l_configElement != null)
                return l_configElement.Key;
            else
                return null;
        }

        public ConfigElement this[int index]
        {
            get
            {
                return BaseGet(index) as ConfigElement;
            }
        }

        #region IEnumerable<ConfigElement> Members

        IEnumerator<ConfigElement> IEnumerable<ConfigElement>.GetEnumerator()
        {
            return (from i in Enumerable.Range(0, this.Count)
                    select this[i])
                    .GetEnumerator();
        }

        #endregion
    }

}
