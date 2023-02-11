using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSProspectorInfoMerger
{
    [Serializable]
    internal class PIDataBlock
    {
        public int X { get; set; }
        public int Z { get; set; }
        public IList<PIDataBlockValue> Values { get; set; }
        public string? Message { get; set; }
        PIDataBlock()
        {
            Values = new List<PIDataBlockValue>();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public bool Equals(PIDataBlock? obj)
        {
            if (obj == null)
            {
                return false;
            }

            foreach (PIDataBlockValue dbv in obj.Values)
            {
                if (Values.ToList().Find(x => { return dbv.Equals(x); }) == null)
                {
                    return false;
                }
            }

            return obj.X == X && obj.Z == Z && obj.Message == Message;
        }
    }

    [Serializable]
    internal class PIDataBlockValue
    {
        public string? Name { get; set; }
        public string? PageCode { get; set; }
        public int RelativeDensity { get; set; }
        public float AbsoluteDensity { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public bool Equals(PIDataBlockValue? obj)
        {
            if (obj == null)
            {
                return false;
            }

            return obj.Name == Name && obj.PageCode == PageCode && obj.RelativeDensity == RelativeDensity && obj.AbsoluteDensity == AbsoluteDensity;
        }
    }
}
