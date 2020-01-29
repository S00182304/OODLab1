using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet1
{
    public class PopBand :Band
    {
        string PopBandType;

        public PopBand(string bandName, int bandYearFormed, string bandMembers, string popBandType)
            : base(bandName, bandYearFormed, bandMembers)
        {
            PopBandType = popBandType;
        }

        public override string ToString()
        {
            return string.Format($"{BandName}, {BandYearFormed}, {BandMembers} {PopBandType}");
        }
    }
}
