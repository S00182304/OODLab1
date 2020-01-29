using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet1
{
    public class IndieBand : Band
    {
        string IndieBandType;

        public IndieBand(string bandName, int bandYearFormed, string bandMembers, string indieBandType) 
            : base(bandName, bandYearFormed, bandMembers)
        {
            IndieBandType = indieBandType;
        }
        public override string ToString()
        {
            return string.Format($"{BandName}, {BandYearFormed}, {BandMembers} {IndieBandType}");
        }

    }
}
