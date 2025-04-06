using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datacapture.model
{
    public class Tree
    {
            public required string TreeId { get; set; }
        public string Variety { get; set; }
            public string RootstockType { get; set; }
            public string PlantAge { get; set; } // Numeric value as string
            public string Location { get; set; }
            public string GPSCoordinates { get; set; }
            public string Region { get; set; }
            public string OrchardName { get; set; }
            public string RowColumnPosition { get; set; }
            public string Ownership { get; set; }
            public string PlantSource { get; set; }
            public string PlantStatus { get; set; }
            public string CanopySize { get; set; } // Numeric value as string
            public string TreeHeight { get; set; } // Numeric value as string
            public string TrunkDiameter { get; set; } // Numeric value as string
            public string SpacingBetweenPlants { get; set; } // Numeric value as string

            // DatePicker Fields
            public DateTime GraftingDate { get; set; }
            public DateTime PlantingDate { get; set; }
        }
    }

