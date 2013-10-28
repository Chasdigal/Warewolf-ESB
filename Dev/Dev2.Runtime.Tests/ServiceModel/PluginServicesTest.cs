﻿using System;
using System.Diagnostics.CodeAnalysis;
using Dev2.Common;
using Dev2.Data.ServiceModel;
using Dev2.DynamicServices.Test.XML;
using Dev2.Runtime.ServiceModel;
using Dev2.Runtime.ServiceModel.Data;
using Dev2.Tests.Runtime.ServiceModel.Data;
using DummyNamespaceForTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;using System.Diagnostics.CodeAnalysis;

namespace Dev2.Tests.Runtime.ServiceModel
{
    // BUG 9500 - 2013.05.31 - TWR - Created
    [TestClass][ExcludeFromCodeCoverage]
    public class PluginServicesTest
    {

        #region CTOR

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PluginServicesContructorWithNullResourceCatalogExpectedThrowsArgumentNullException()
        {
            var services = new PluginServices(null);
        }

        #endregion

        #region DeserializeService

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PluginServicesDeserializeServiceWithNullJsonExpectedThrowsArgumentNullException()
        {
            var services = new PluginServicesMock();
            var result = services.DeserializeService(null);
        }

        [TestMethod]
        public void PluginServicesDeserializeServiceWithInvalidJsonExpectedReturnsNewPluginService()
        {
            var services = new PluginServicesMock();
            var result = services.DeserializeService("{'root' : 'hello' }");
            Assert.AreEqual(result.ResourceID, Guid.Empty);
        }

        [TestMethod]
        public void PluginServicesDeserializeServiceWithValidJsonExpectedReturnsPluginService()
        {
            var xml = XmlResource.Fetch("PluginService");
            var service = new PluginService(xml);

            var services = new PluginServicesMock();
            var result = services.DeserializeService(service.ToString());

            PluginServiceTests.VerifyEmbeddedPluginService(result as PluginService);
        }

        [TestMethod]
        public void PluginServicesDeserializeServiceWithNullXmlExpectedReturnsNewPluginService()
        {
            var services = new PluginServicesMock();
            var result = services.DeserializeService(null, ResourceType.PluginService);

            Assert.AreEqual(result.ResourceID, Guid.Empty);
        }

        [TestMethod]
        public void PluginServicesDeserializeServiceWithValidXmlExpectedReturnsPluginService()
        {
            var xml = XmlResource.Fetch("PluginService");

            var services = new PluginServicesMock();
            var result = services.DeserializeService(xml, ResourceType.PluginService);

            PluginServiceTests.VerifyEmbeddedPluginService(result as PluginService);
        }

        #endregion

        #region Namespaces

        [TestMethod]
        public void PluginServicesNamespacesWithNullArgsExpectedReturnsEmptyList()
        {
            var services = new PluginServices();
            var result = services.Namespaces(null, Guid.Empty, Guid.Empty);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void PluginServicesNamespacesWithInvalidArgsExpectedReturnsEmptyList()
        {
            var services = new PluginServices();
            var result = services.Namespaces("xxxx", Guid.Empty, Guid.Empty);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void PluginServicesNamespacesWithValidArgsExpectedReturnsList()
        {
            var source = CreatePluginSource();
            var args = source.ToString();
            var workspaceID = Guid.NewGuid();

            EnvironmentVariables.GetWorkspacePath(workspaceID);

            var services = new PluginServices();
            var result = services.Namespaces(args, workspaceID, Guid.Empty);

            // DO NOT assert equality on Count as this will 
            // change as new namespaces are added to this assembly!
            Assert.IsTrue(result.Count > 0);
        }

        #endregion

        #region Methods

        [TestMethod]
        public void PluginServicesMethodsWithNullArgsExpectedReturnsEmptyList()
        {
            var services = new PluginServices();
            var result = services.Methods(null, Guid.Empty, Guid.Empty);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void PluginServicesMethodsWithInvalidArgsExpectedReturnsEmptyList()
        {
            var services = new PluginServices();
            var result = services.Methods("xxxx", Guid.Empty, Guid.Empty);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void PluginServicesMethodsWithValidArgsExpectedReturnsList()
        {
            var service = CreatePluginService();
            var args = service.ToString();
            var workspaceID = Guid.NewGuid();

            EnvironmentVariables.GetWorkspacePath(workspaceID);

            var services = new PluginServices();
            var result = services.Methods(args, workspaceID, Guid.Empty);

            Assert.AreEqual(9, result.Count);
        }

        #endregion

        #region Test

        [TestMethod]
        public void PluginServicesTestWithNullArgsExpectedReturnsRecordsetWithError()
        {
            //------------Setup for test--------------------------
            var services = new PluginServicesMock();
            //------------Execute Test---------------------------
            var result = services.Test(null, Guid.Empty, Guid.Empty);
            //------------Assert Results-------------------------
            Assert.IsTrue(result[0].HasErrors);
        }

        [TestMethod]
        public void PluginServicesTestWithInvalidArgsExpectedReturnsRecordsetWithError()
        {
            //------------Setup for test--------------------------
            var services = new PluginServicesMock();
            //------------Execute Test---------------------------
            var result = services.Test("xxx", Guid.Empty, Guid.Empty);
            //------------Assert Results-------------------------
            Assert.IsTrue(result[0].HasErrors);
        }

        [TestMethod]
        public void PluginServicesTestWithValidArgsExpectedAddsRecordsetFields()
        {
            //------------Setup for test--------------------------
            var svc = CreatePluginService();
            var args = svc.ToString();
            var workspaceID = Guid.NewGuid();
            //------------Execute Test---------------------------
            var services = new PluginServicesMock();
            var result = services.Test(args, workspaceID, Guid.Empty);
            ////------------Assert Results-------------------------
            Assert.IsTrue(services.FetchRecordsetAddFields);
            Assert.AreEqual(1, result[0].Fields.Count);
        }

        [TestMethod]
        public void PluginServicesTestWithValidArgsExpectedFetchesRecordset()
        {
            //------------Setup for test--------------------------
            var svc = CreatePluginService();
            var args = svc.ToString();
            var workspaceID = Guid.NewGuid();
            //------------Execute Test---------------------------
            var services = new PluginServicesMock();
            var result = services.Test(args, workspaceID, Guid.Empty);
            //------------Assert Results-------------------------
            Assert.AreEqual(1, services.FetchRecordsetHitCount);
            Assert.AreEqual(1, result.Count);
        }

        #endregion

        #region CreatePluginService

        public static PluginService CreatePluginService()
        {
            return CreatePluginService(new ServiceMethod
            {
                Name = "DummyMethod"
            });
        }

        public static PluginService CreatePluginService(ServiceMethod method)
        {
            var type = typeof(DummyClassForPluginTest);

            var source = CreatePluginSource();
            var service = new PluginService
            {
                ResourceID = Guid.NewGuid(),
                ResourceName = "DummyPluginService",
                ResourceType = ResourceType.PluginService,
                ResourcePath = "Tests",
                Namespace = type.FullName,
                Method = method,
                Source = source
            };
            return service;
        }

        #endregion

        #region CreatePluginSource

        static PluginSource CreatePluginSource()
        {
            var type = typeof(DummyClassForPluginTest);
            var assembly = type.Assembly;
            return new PluginSource
            {
                AssemblyLocation = assembly.Location,
                ResourceID = Guid.NewGuid(),
                ResourceName = "Dummy",
                ResourceType = ResourceType.PluginSource,
                ResourcePath = "Test",
            };
        }

        #endregion
    }
}
