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
        /// km
        /// </summary>
        public int Distance { get; set; } = 10;
        /// <summary>
        /// number of item 
        /// </summary>
        private int Count { get; set; } = 5;
        public Location CurrentLocation { get; set; }
    }

}
