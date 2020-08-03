using System;
using System.Collections.Generic;
using Config.Net;

namespace Config.Net.TypeParsers
{
    class DictionaryParser: ITypeParser
    {
        public IEnumerable<Type> SupportedTypes => new[] {typeof(Dictionary<string,bool>)};

        public string ToRawString(object value) {
            if (value == null) return null;

            return value.ToString();
        }

        public bool TryParse(string value, Type t, out object result) {
            if (value == null){
                result = null;
                return false;
            }

            if (t == typeof(Dictionary<string, bool>)){
                Dictionary<string, bool> dictionary     = new Dictionary<string, bool>();
                var                      splitWithBrace = value.Split(new[] {'{', '}'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (var s in splitWithBrace){
                    var element = s.Split(':');
                    dictionary.Add(element[0], Convert.ToBoolean(element[1]));
                }

                result = dictionary;
                return true;
            }

            result = null;
            return false;
        }
    }
}
