using System.Collections.Generic;
using FluentNHibernate.Testing;
using FluentNHSample;
using FluentNHSample.Conventions;
using FluentNHSample.Entities;
using FluentNHSample.Mappings;
using NHibernate;
using NUnit.Framework;

namespace PersistenceTests {
    [TestFixture]
    public class PersistenceTests {
        ISessionFactory sessionFactory;
        ISession session;

        [TestFixtureSetUp]
        public void FixtureSetUp() {
            sessionFactory = SessionFactoryBuilder.BuildSessionFactoryFromAppConfig<EmployeeMap, CustomForeignKeyConvention>("DB");
        }

        [TestFixtureTearDown]
        public void FixtureTearDown() {
            if (session.IsOpen)
                session.Close();
            sessionFactory.Close();
        }

        [SetUp]
        public void MethodSetUp() {
            session = sessionFactory.OpenSession();
        }

        [TearDown]
        public void MethodTearDown() {
            if (session.IsOpen)
                session.Close();
        }

        [Test]
        public void CanCorrectlyMapStore() {
            new PersistenceSpecification<Store>(session)
                //.CheckProperty(s => s.Id, 7)
                .CheckProperty(s => s.Name, "Bargin Basin")
                .CheckList(s => s.Staff, new List<Employee>())
                .CheckList(s => s.Products, new List<Product>())
                .VerifyTheMappings();
        }

        [Test]
        public void CanCorrectlyMapProduct() {
            new PersistenceSpecification<Product>(session)
                //.CheckProperty(p => p.Id, 1)
                .CheckProperty(p => p.Name, "Awesome hat")
                .CheckProperty(p => p.Price, 8.00)
                .CheckList(p => p.StoresStockedIn, new List<Store>())
                .VerifyTheMappings();
        }

        [Test] //this one fails
        public void CanCorrectlyMapEmployee() {
            new PersistenceSpecification<Employee>(session)
            .CheckProperty(e => e.FirstName, "John")
            .CheckProperty(e => e.LastName, "Dillinger")
            .CheckReference(e => e.Store, new Store() { Name = "Bank" })
            .VerifyTheMappings();
        }
    }
}
