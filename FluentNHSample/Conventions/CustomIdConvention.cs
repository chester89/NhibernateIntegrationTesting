using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace FluentNHSample.Conventions {
    public class CustomIdConvention: IIdConvention {
        public void Apply(IIdentityInstance instance) {
            instance.Column("Id");
        }
    }
}
