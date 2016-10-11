﻿using FIA_Biosum_Manager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Biosum_Manager_Test
{
    
    
    /// <summary>
    ///This is a test class for processorTest and is intended
    ///to contain all processorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class processorTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for processor Constructor
        ///</summary>
        [TestMethod()]
        public void processorConstructorTest()
        {
            processor target = new processor("biosum_processor_object_debug.txt", "scenario1");
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for init
        ///</summary>
        [TestMethod()]
        public void initTest()
        {
            processor target = new processor("biosum_processor_object_debug.txt", "scenario1");
            frmMain tempFrmMain = new frmMain();
            tempFrmMain.button_click("CASE STUDY SCENARIO");
            frmMain.g_oFrmMain = tempFrmMain;
            frmMain.g_oFrmMain.frmProject.uc_project1.txtRootDirectory.Text = 
                "C:\\workspace\\BioSum\\biosum_data\\bluemountains";
            target.init();
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for loadTrees
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FIA_Biosum_Manager.exe")]
        public void loadTreesTest()
        {
            // Initialize framework needed to run tests that is normally in the UI
            frmMain tempFrmMain = new frmMain();
            tempFrmMain.button_click("CASE STUDY SCENARIO");
            frmMain.g_oFrmMain = tempFrmMain;
            frmMain.g_oFrmMain.frmProject.uc_project1.txtRootDirectory.Text =
                "C:\\workspace\\BioSum\\biosum_data\\bluemountains";
            frmMain.g_intDebugLevel = 3;
            frmMain.g_bDebug = true;
            processor_Accessor target = new processor_Accessor(frmMain.g_oEnv.strTempDir + "\\biosum_processor_debug.txt", "scenario1");
            Queries p_oQueries = target.init();

            string p_strVariant = "BM";
            string p_strRxPackage = "004";
            target.loadTrees(p_strVariant, p_strRxPackage, p_oQueries.m_strTempDbFile);
            target.updateTrees(p_strVariant, p_strRxPackage, p_oQueries.m_strTempDbFile, true);
            target.createOpcostInput(p_oQueries.m_strTempDbFile);
            target.createTreeVolValWorkTable(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt"), p_oQueries.m_strTempDbFile, true);
            //Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
