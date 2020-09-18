/* 
 * CyberSource Merged Spec
 *
 * All CyberSource API specs merged together. These are available at https://developer.cybersource.com/api/reference/api-reference.html
 *
 * OpenAPI spec version: 0.0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using NUnit.Framework;

using CyberSource.Client;
using CyberSource.Api;
using CyberSource.Model;

namespace CyberSource.Test
{
    /// <summary>
    ///  Class for testing SymmetricKeyManagementApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by Swagger Codegen.
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    [TestFixture]
    public class SymmetricKeyManagementApiTests
    {
        private SymmetricKeyManagementApi instance;

        /// <summary>
        /// Setup before each unit test
        /// </summary>
        [SetUp]
        public void Init()
        {
            instance = new SymmetricKeyManagementApi();
        }

        /// <summary>
        /// Clean up after each unit test
        /// </summary>
        [TearDown]
        public void Cleanup()
        {

        }

        /// <summary>
        /// Test an instance of SymmetricKeyManagementApi
        /// </summary>
        [Test]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsInstanceOfType' SymmetricKeyManagementApi
            //Assert.IsInstanceOfType(typeof(SymmetricKeyManagementApi), instance, "instance is a SymmetricKeyManagementApi");
        }

        
        /// <summary>
        /// Test CreateV2SharedSecretKeys
        /// </summary>
        [Test]
        public void CreateV2SharedSecretKeysTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //CreateSharedSecretKeysRequest createSharedSecretKeysRequest = null;
            //var response = instance.CreateV2SharedSecretKeys(createSharedSecretKeysRequest);
            //Assert.IsInstanceOf<KmsV2KeysSymPost201Response> (response, "response is KmsV2KeysSymPost201Response");
        }
        
        /// <summary>
        /// Test DeleteBulkSymmetricKeys
        /// </summary>
        [Test]
        public void DeleteBulkSymmetricKeysTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //DeleteBulkSymmetricKeysRequest deleteBulkSymmetricKeysRequest = null;
            //var response = instance.DeleteBulkSymmetricKeys(deleteBulkSymmetricKeysRequest);
            //Assert.IsInstanceOf<KmsV2KeysSymDeletesPost200Response> (response, "response is KmsV2KeysSymDeletesPost200Response");
        }
        
        /// <summary>
        /// Test GetKeyDetails
        /// </summary>
        [Test]
        public void GetKeyDetailsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string keyId = null;
            //var response = instance.GetKeyDetails(keyId);
            //Assert.IsInstanceOf<KmsV2KeysSymGet200Response> (response, "response is KmsV2KeysSymGet200Response");
        }
        
    }

}
