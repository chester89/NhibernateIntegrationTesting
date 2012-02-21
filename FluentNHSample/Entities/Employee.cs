using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentNHSample.Entities {
    public class Employee {
        public virtual Int32 Id { get; private set; }
        public virtual String FirstName { get; set; }
        public virtual String LastName { get; set; }
        public virtual Store Store { get; set; }

        public override Boolean Equals(Object obj) {
            Employee second = obj as Employee;
            if (this.Id == second.Id && this.FirstName == second.FirstName
                && this.LastName == second.LastName && this.Store.Equals(second.Store))
                return true;
            return false;
        }
    }
}
