﻿//-----------------------------------------------------------------------
// <copyright file="UnicodePathTests.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation.
// </copyright>
//-----------------------------------------------------------------------

namespace InteropApiTests
{
    using System;
    using System.IO;
    using Microsoft.Isam.Esent.Interop;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Test files with Unicode paths (if ESENT supports them)
    /// </summary>
    [TestClass]
    public class UnicodePathTests
    {
        /// <summary>
        /// Unicode directory to contain files.
        /// </summary>
        private string directory;

        /// <summary>
        /// Unicode database name.
        /// </summary>
        private string database;

        /// <summary>
        /// Test setup
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            this.directory = "字会意";
            this.database = Path.Combine(this.directory, "한글.edb");
        }

        /// <summary>
        /// Delete the test directory, if it was created.
        /// </summary>
        [TestCleanup]
        public void Teardown()
        {
            if (Directory.Exists(this.directory))
            {
                Cleanup.DeleteDirectoryWithRetry(this.directory);
            }
        }

        /// <summary>
        /// When a string can't be converted to ASCII for an API call
        /// an exception should be generated. If this code is converted
        /// to use the Unicode version of all APIs this test should
        /// start failing.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        [ExpectedException(typeof(ArgumentException))]
        public void ApiThrowsArgumentExceptionOnUnmappableChar()
        {
            JET_INSTANCE instance;
            Api.JetCreateInstance(out instance, "한글");
        }

        /// <summary>
        /// Set the system path.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void SetAndGetUnicodeSystemPath()
        {
            if (!EsentVersion.SupportsUnicodePaths)
            {
                return;
            }

            using (var instance = new Instance("unicode"))
            {
                instance.Parameters.SystemDirectory = this.directory;
                Assert.IsTrue(instance.Parameters.SystemDirectory.Contains(this.directory));
            }
        }

        /// <summary>
        /// Set the logfile path.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void SetAndGetUnicodeLogPath()
        {
            if (!EsentVersion.SupportsUnicodePaths)
            {
                return;
            }

            using (var instance = new Instance("unicode"))
            {
                instance.Parameters.LogFileDirectory = this.directory;
                Assert.IsTrue(instance.Parameters.LogFileDirectory.Contains(this.directory));
            }
        }

        /// <summary>
        /// Set the temp database path.
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void SetAndGetUnicodeTempDbPath()
        {
            if (!EsentVersion.SupportsUnicodePaths)
            {
                return;
            }

            using (var instance = new Instance("unicode"))
            {
                instance.Parameters.TempDirectory = this.directory;
                Assert.IsTrue(instance.Parameters.TempDirectory.Contains(this.directory));
            }
        }

        /// <summary>
        /// Create a database with a unicode path.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void CreateDatabaseWithUnicodePath()
        {
            if (!EsentVersion.SupportsUnicodePaths)
            {
                return;
            }

            using (var instance = new Instance("unicode"))
            {
                SetupHelper.SetLightweightConfiguration(instance);
                instance.Parameters.CreatePathIfNotExist = true;
                instance.Init();
                using (var session = new Session(instance))
                {
                    JET_DBID dbid;
                    Api.JetCreateDatabase(session, this.database, String.Empty, out dbid, CreateDatabaseGrbit.None);
                    Assert.IsTrue(File.Exists(this.database));
                }
            }
        }

        /// <summary>
        /// Detach a database with a unicode path.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void DetachDatabaseWithUnicodePath()
        {
            if (!EsentVersion.SupportsUnicodePaths)
            {
                return;
            }

            using (var instance = new Instance("unicode"))
            {
                SetupHelper.SetLightweightConfiguration(instance);
                instance.Parameters.CreatePathIfNotExist = true;
                instance.Init();
                using (var session = new Session(instance))
                {
                    JET_DBID dbid;
                    Api.JetCreateDatabase(session, this.database, String.Empty, out dbid, CreateDatabaseGrbit.None);
                    Api.JetCloseDatabase(session, dbid, CloseDatabaseGrbit.None);
                    Api.JetDetachDatabase(session, this.database);
                }
            }
        }

        /// <summary>
        /// Attach a database with a unicode path.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void AttachDatabaseWithUnicodePath()
        {
            if (!EsentVersion.SupportsUnicodePaths)
            {
                return;
            }

            using (var instance = new Instance("unicode"))
            {
                SetupHelper.SetLightweightConfiguration(instance);
                instance.Parameters.CreatePathIfNotExist = true;
                instance.Init();
                using (var session = new Session(instance))
                {
                    JET_DBID dbid;
                    Api.JetCreateDatabase(session, this.database, String.Empty, out dbid, CreateDatabaseGrbit.None);
                    Api.JetCloseDatabase(session, dbid, CloseDatabaseGrbit.None);
                    Api.JetDetachDatabase(session, this.database);

                    Api.JetAttachDatabase(session, this.database, AttachDatabaseGrbit.None);
                }
            }
        }

        /// <summary>
        /// Open a database with a unicode path.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void OpenDatabaseWithUnicodePath()
        {
            if (!EsentVersion.SupportsUnicodePaths)
            {
                return;
            }

            using (var instance = new Instance("unicode"))
            {
                SetupHelper.SetLightweightConfiguration(instance);
                instance.Parameters.CreatePathIfNotExist = true;
                instance.Init();
                using (var session = new Session(instance))
                {
                    JET_DBID dbid;
                    Api.JetCreateDatabase(session, this.database, String.Empty, out dbid, CreateDatabaseGrbit.None);
                    Api.JetCloseDatabase(session, dbid, CloseDatabaseGrbit.None);
                    Api.JetDetachDatabase(session, this.database);

                    Api.JetAttachDatabase(session, this.database, AttachDatabaseGrbit.None);
                    Api.JetOpenDatabase(session, this.database, String.Empty, out dbid, OpenDatabaseGrbit.None);
                }
            }
        }

        /// <summary>
        /// Backup and restore a database using unicode paths.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void BackupRestoreDatabaseWithUnicodePath()
        {
            if (!EsentVersion.SupportsUnicodePaths)
            {
                return;
            }

            var test = new DatabaseFileTestHelper(this.directory, "한글", false);
            test.TestBackupRestore();
        }

        /// <summary>
        /// Tests for streaming backup using unicode paths.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void StreamingBackupWithUnicodePath()
        {
            if (!EsentVersion.SupportsUnicodePaths)
            {
                return;
            }

            var test = new DatabaseFileTestHelper(this.directory, "한글", false);
            test.TestStreamingBackup();
        }

        /// <summary>
        /// Tests for streaming backup using unicode paths.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void SnapshotBackupWithUnicodePath()
        {
            if (!EsentVersion.SupportsUnicodePaths)
            {
                return;
            }

            var test = new DatabaseFileTestHelper(this.directory);
            test.TestSnapshotBackup();
        }

        /// <summary>
        /// Backup and restore a database using unicode paths.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void TestJetCompactDatabaseWithUnicodePath()
        {
            if (!EsentVersion.SupportsUnicodePaths)
            {
                return;
            }

            var test = new DatabaseFileTestHelper(this.directory);
            test.TestCompactDatabase();
        }

        /// <summary>
        /// Tests for JetCompactDatabase with a unicode path.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void TestJetSetDatabaseSizeDatabaseWithUnicodePath()
        {
            if (!EsentVersion.SupportsUnicodePaths)
            {
                return;
            }

            var test = new DatabaseFileTestHelper(this.directory);
            test.TestSetDatabaseSize();
        }

        /// <summary>
        /// Test JetGetInstanceInfo with a unicode path.
        /// </summary>
        [TestMethod]
        [Priority(2)]
        public void TestJetGetInstanceInfoWithUnicodePath()
        {
            if (!EsentVersion.SupportsUnicodePaths)
            {
                return;
            }

            const string InstanceName = "MyInstance";
            using (var instance = new Instance(InstanceName))
            {
                instance.Parameters.NoInformationEvent = true;
                instance.Parameters.MaxTemporaryTables = 0;
                instance.Parameters.CreatePathIfNotExist = true;
                instance.Init();
                using (var session = new Session(instance))
                {
                    JET_DBID dbid;
                    Api.JetCreateDatabase(session, this.database, String.Empty, out dbid, CreateDatabaseGrbit.None);
                    int numInstances;
                    JET_INSTANCE_INFO[] instances;
                    Api.JetGetInstanceInfo(out numInstances, out instances);

                    Assert.AreEqual(1, numInstances);
                    Assert.AreEqual(numInstances, instances.Length);
                    Assert.AreEqual(InstanceName, instances[0].szInstanceName);

                    Assert.AreEqual(1, instances[0].cDatabases);
                    Assert.AreEqual(instances[0].cDatabases, instances[0].szDatabaseFileName.Length);
                    Assert.AreEqual(Path.GetFullPath(this.database), instances[0].szDatabaseFileName[0]);
                }
            }
        }
    }
}