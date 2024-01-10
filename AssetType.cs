using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wk2_AssetTracking_EF
{
    internal class AssetType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public List<Asset> TypeAssetList { get; set; }//An Asset Type can be associated with multiple Assets
    }
}
