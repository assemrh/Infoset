using Infoset.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoset.Application.Branches
{
    public class BrancheParams
    {
        /// <summary>
        /// Max distance in km
        /// </summary>
        public int MaxDistance { get; set; } = 10;
        /// <summary>
        /// number of items 
        /// </summary>
        public int Count { get; set; } = 5;
        public Location CurrentLocation { get; set; }
    }

}
