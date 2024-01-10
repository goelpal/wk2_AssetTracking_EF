using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wk2_AssetTracking_EF
{
    internal class Asset
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public double PriceInUSD { get; set; }
        public int AssetTypeId { get; set; } //Foreign Key
        public AssetType AssetType { get; set; }//Referencing AssetType that the Asset Belongs

        public int OfficeId { get; set; } //Foreign Key
        public Office Office { get; set; }//Referencing Office that the Asset Belongs

    }
}
