using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet1
{
    public class RockBand : Band
    {
        string RockBandType;

        public RockBand(string bandName, int bandYearFormed, string bandMembers, string rockBandType)
            : base(bandName, bandYearFormed, bandMembers)
        {
            RockBandType = rockBandType;
        }

        public override string ToString()
        {
            return string.Format($"{BandName}, {BandYearFormed}, {BandMembers} {RockBandType}");
        }
    }
}
