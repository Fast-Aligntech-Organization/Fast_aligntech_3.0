using System.Collections.Generic;

namespace Fast.Core.InternalModels
{


    public class Label
    {
        public string Text
        {
            get; set;
        }
        public string IntentName
        {
            get; set;
        }
        public List<Entitylabel> EntityLabels
        {
            get; set;
        } = new List<Entitylabel>();
    }

    public class Entitylabel
    {
        public string EntityName
        {
            get; set;
        }
        public int StartCharIndex
        {
            get; set;
        }
        public int EndCharIndex
        {
            get; set;
        }
    }


}
