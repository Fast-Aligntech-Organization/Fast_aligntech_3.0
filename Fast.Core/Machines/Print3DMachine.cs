using Fast.Core.Enumerations;
using System;

namespace Fast.Core.Machines
{
    /// <summary>
    /// Representa una maquina 3D con sus estados, progresos etc.
    /// </summary>
    public class Print3DMachine
    {
        public string Name { get; set; }

        public string Model { get; set; }

        public string NameCurrentWork { get; set; }

        public float? BedTemperature { get; set; }

        public float? BedTemperatureTarget { get; set; }

        public float? ExtrusorTemperature { get; set; }

        public float? ExtrusorTemperatureTarget { get; set; }

        public bool? LazerSupport { get; set; }

        public bool? IsAllInHome { get; set; }

        public bool? IsAxisXHome { get; set; }

        public bool? IsAxisYHome { get; set; }

        public bool? IsAxisZHome { get; set; }

        public MachineEstate MachineState { get; set; }

        public OperationEstate OperationState { get; set; }

        public float? LayersForPrint { get; set; }

        public float? LayersPrinted { get; set; }

        public TimeSpan? PrintDurationTime { get; set; }

        public TimeSpan? PrintTimeCurrent { get; set; }


        public bool IsReady()
        {
            bool isReady = true;

            if (BedTemperature.Value == BedTemperatureTarget.Value)
            {

            }

            return isReady;
        }





    }
}
