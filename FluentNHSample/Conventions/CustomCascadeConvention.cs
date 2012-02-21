using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace FluentNHSample.Conventions {
    public class CustomCascadeConvention: IHasManyConvention {
        public void Apply(IOneToManyCollectionInstance instance) {
            instance.Cascade.All();
        }
    }
}
