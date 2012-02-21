using System;
using System.Reflection;
using FluentNHibernate.Conventions;
using FluentNHibernate;

namespace FluentNHSample.Conventions {
    public class CustomForeignKeyConvention: ForeignKeyConvention {
        protected override String GetKeyName(Member property, Type type) {
            return property == null ? type.Name + "Id": property.Name + "Id";
        }
    }
}
