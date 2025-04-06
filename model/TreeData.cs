using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datacapture.model
{
    public class TreeData
    {
        public int TreeId { get; set; }



        // Store the image as a byte array (BLOB)
        public byte[] ImageData { get; set; }

        

        // Store the variety (e.g., category or type)
        public string? CustomData{ get; set; }
    }
}
