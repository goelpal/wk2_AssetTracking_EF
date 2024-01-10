using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wk2_AssetTracking_EF
{
    internal class Office
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Asset> OfficeAssetList { get; set; }
    }
}
