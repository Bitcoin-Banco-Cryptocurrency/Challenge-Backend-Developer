using System.Collections.Generic;

namespace Repository.Entities
{
    public partial struct StringOrArray
    {
        public string String;
        public List<string> StringArray;

        public static implicit operator StringOrArray(string String) => new StringOrArray { String = String };
        public static implicit operator StringOrArray(List<string> StringArray) => new StringOrArray { StringArray = StringArray };
    }
}