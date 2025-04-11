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

        public string ImageName { get; set; }

        // Phenological Practices
        public string PhenologicalStage { get; set; }
        public DateTime StageDate { get; set; }
        public string GrowthObservations { get; set; }
        public int? BlossomDensity { get; set; }

        // Management Practices
        public string InputsApplied { get; set; }
        public string PesticideType { get; set; }
        public DateTime? PesticideApplicationDate { get; set; }
        public double? PesticideQuantity { get; set; }
        public string FertilizerType { get; set; }
        public DateTime? FertilizerApplicationDate { get; set; }
        public double? FertilizerQuantity { get; set; }

        // Health and Disease Monitoring
        public string ObservedDisease { get; set; }
        public string DiseaseSeverity { get; set; }
        public string DiseasePhotoPath { get; set; }
        public string PestIncidence { get; set; }
        public string PestSeverity { get; set; }
        public string TreatmentApplied { get; set; }
        public string NutrientDeficiencySymptoms { get; set; }
        public string WeatherDamageReports { get; set; }

        // Yield and Productivity
        public double? FruitSetPercentage { get; set; }
        public DateTime? HarvestDate { get; set; }
        public double? YieldPerTree { get; set; }
        public string FruitQualityParameters { get; set; }
    }
}
