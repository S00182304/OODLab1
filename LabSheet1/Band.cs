using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet1
{
    public class Band :IComparable
    {
        public string BandName { get; set; }
        public int BandYearFormed { get; set;}
        public string BandMembers { get; set; }

        public Band (string bandName, int bandYearFormed, string bandMembers)
        {
            BandName = bandName;
            BandYearFormed = bandYearFormed;
            BandMembers = bandMembers;
        }

        public override string ToString()
        {
            return string.Format($"{BandName}, {BandYearFormed}, {BandMembers}");
        }

        public int CompareTo(object obj)
        {
            Band that = obj as Band;
            return this.BandName.CompareTo(that.BandName);
        }
    }
}
