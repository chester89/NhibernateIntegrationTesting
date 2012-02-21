using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHSample.Entities {
    public class Product {
        public virtual Int32 Id { get; private set; }
        public virtual String Name { get; set; }
        public virtual Double Price { get; set; }
        public virtual IList<Store> StoresStockedIn { get; set; }

        public Product() {
            StoresStockedIn = new List<Store>();
        }

        public override Boolean Equals(Object obj) {
            Product second = obj as Product;
            if (this.Id == second.Id && this.Name == this.Name && this.Price
                == second.Price && this.StoresStockedIn.Count == second.StoresStockedIn.Count) {
                List<Store> stores1 = new List<Store>();
                List<Store> stores2 = new List<Store>();
                foreach (var item in this.StoresStockedIn) {
                    stores1.Add(item);
                }
                foreach (var it in second.StoresStockedIn) {
                    stores2.Add(it);
                }
                for (int i = 0; i < stores2.Count; i++) {
                    if (!stores1[i].Equals(stores2[i]))
                        return false;
                }
                return true;
            }
            return false;
        }
    }
}
