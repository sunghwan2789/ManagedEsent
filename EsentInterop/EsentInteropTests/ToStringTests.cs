﻿//-----------------------------------------------------------------------
// <copyright file="ToStringTests.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.
// </copyright>
//-----------------------------------------------------------------------

namespace InteropApiTests
{
    using System;
    using Microsoft.Isam.Esent.Interop;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Testing the ToString methods of the basic types.
    /// </summary>
    [TestClass]
    public class ToStringTests
    {
        /// <summary>
        /// Test JET_INSTANCE.ToString()
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void JetInstanceToString()
        {
            var instance = new JET_INSTANCE() { Value = (IntPtr)0x123ABC };
            Assert.AreEqual("JET_INSTANCE(0x123abc)", instance.ToString());
        }

        /// <summary>
        /// Test JET_SESID.ToString()
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void JetSesidToString()
        {
            var sesid = new JET_SESID() { Value = (IntPtr)0x123ABC };
            Assert.AreEqual("JET_SESID(0x123abc)", sesid.ToString());
        }

        /// <summary>
        /// Test JET_DBID.ToString()
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void JetDbidToString()
        {
            var dbid = new JET_DBID() { Value = 23 };
            Assert.AreEqual("JET_DBID(23)", dbid.ToString());
        }

        /// <summary>
        /// Test JET_TABLEID.ToString()
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void JetTableidToString()
        {
            var tableid = new JET_TABLEID() { Value = (IntPtr)0x123ABC };
            Assert.AreEqual("JET_TABLEID(0x123abc)", tableid.ToString());
        }

        /// <summary>
        /// Test JET_COLUMNID.ToString()
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void JetColumnidToString()
        {
            var columnid = new JET_COLUMNID() { Value = 0x12EC };
            Assert.AreEqual("JET_COLUMNID(0x12ec)", columnid.ToString());
        }

        /// <summary>
        /// Test JET_OSSNAPID.ToString()
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void JetOsSnapidToString()
        {
            var ossnapid = new JET_OSSNAPID { Value = (IntPtr)0x123ABC };
            Assert.AreEqual("JET_OSSNAPID(0x123abc)", ossnapid.ToString());
        }
    }
}