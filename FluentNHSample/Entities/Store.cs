using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHSample.Entities {
    public class Store {
        public virtual Int32 Id { get; private set; }
        public virtual String Name { get; set; }
        public virtual IList<Product> Products { get; set; }
        public virtual IList<Employee> Staff { get; set; }

        public Store() {
            Products = new List<Product>();
            Staff = new List<Employee>();
        }

        public virtual void addProduct(Product product) {
            product.StoresStockedIn.Add(this);
            Products.Add(product);
        }

        public virtual void addEmployee(Employee employee) {
            employee.Store = this;
            Staff.Add(employee);
        }

        public override Boolean Equals(Object obj) {
            Store secondStore = null;
            try {
                secondStore = obj as Store;
            }
            catch (InvalidCastException e) {
                Console.WriteLine(e.Message);
                return false;
            }
            if (this.Id == secondStore.Id && this.Name == secondStore.Name) {
                if (this.Products.Count == secondStore.Products.Count && this.Staff.Count == secondStore.Staff.Count) {
                    List<Product> products1 = new List<Product>();
                    List<Product> products2 = new List<Product>();
                    foreach (var item in this.Products) {
                        products1.Add(item);
                    }
                    foreach (var it in secondStore.Products) {
                        products2.Add(it);
	                }
                    products1 = products1.OrderBy(p => p.Id).ToList();
                    products2 = products2.OrderBy(p => p.Id).ToList();
                    for (int i = 0; i < products2.Count; i++) {
                        if(!products1[i].Equals(products2[i]))
                            return false;
                    }
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
