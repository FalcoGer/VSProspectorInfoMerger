using Newtonsoft.Json;

namespace VSProspectorInfoMerger
{
    /// <summary>
    /// Data block created by the prospector info mod that is used for deserialization
    /// </summary>
    [Serializable]
    internal class PIDataBlock
    {
        /// <summary>
        /// X Position of the chunk corner
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Z Position of the chunk corner
        /// </summary>
        public int Z { get; set; }
        /// <summary>
        /// Ore density values
        /// </summary>
        public IList<PIDataBlockValue> Values { get; set; }
        /// <summary>
        /// Seems to be always null
        /// </summary>
        public string? Message { get; set; }

        /// <summary>
        /// CTOR
        /// </summary>
        PIDataBlock()
        {
            Values = new List<PIDataBlockValue>();
        }

        /// <summary>
        /// Serialize into a JSON string object.
        /// </summary>
        /// <returns>The object as a string.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Checks for equality.
        /// </summary>
        /// <param name="obj">Other object</param>
        /// <returns>True if all values are the same, otherwise false.</returns>
        public bool Equals(PIDataBlock? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.Values.Count != Values.Count)
            {
                return false;
            }

            // Try to find each value block in the foreign object to your own. If any isn't found, it's a missmatch.
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

    /// <summary>
    /// Ore density value, used for deserialization.
    /// </summary>
    [Serializable]
    internal class PIDataBlockValue
    {
        /// <summary>
        /// Name of the ore block in game (ID)
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Name of the ore item in game (ID)
        /// </summary>
        public string? PageCode { get; set; }
        /// <summary>
        /// Value of the relative density (Trace, decent, high , ultra, etc)
        /// </summary>
        public int RelativeDensity { get; set; }
        /// <summary>
        /// Amount of or in the rock in 1/1000
        /// </summary>
        public float AbsoluteDensity { get; set; }

        /// <summary>
        /// Serialize into a JSON string object.
        /// </summary>
        /// <returns>The object as a string.</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Checks for equality.
        /// </summary>
        /// <param name="obj">Other object</param>
        /// <returns>True if all values are the same, otherwise false.</returns>
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
