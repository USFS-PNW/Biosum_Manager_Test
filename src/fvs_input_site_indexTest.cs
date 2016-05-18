using FIA_Biosum_Manager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Biosum_Manager_Test
{
    
    
    /// <summary>
    ///This is a test class for fvs_input_site_indexTest and is intended
    ///to contain all fvs_input_site_indexTest Unit Tests
    ///</summary>
    [TestClass()]
    public class fvs_input_site_indexTest
    {


        private TestContext testContextInstance;
        private string testDirectory = "C:\\Docs\\Lesley\\fia_biosum\\Docs\\Site Index";

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
        ///A test for zALRU3
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FIA_Biosum_Manager.exe")]
        public void zALRU3Test()
        {
            fvs_input_Accessor.site_index target = new fvs_input_Accessor.site_index(); // TODO: Initialize to an appropriate value
            int p_intSIDiaAge = 50; // TODO: Initialize to an appropriate value
            int p_intSIHtFt = 75; // TODO: Initialize to an appropriate value
            double expected = 99.1890625; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.zALRU3(p_intSIDiaAge, p_intSIHtFt);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PSME11
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FIA_Biosum_Manager.exe")]
        public void PSME11Test()
        {
            fvs_input_Accessor.site_index target = new fvs_input_Accessor.site_index(); // TODO: Initialize to an appropriate value
            int p_intSIDiaAge = 100; // TODO: Initialize to an appropriate value
            int p_intSIHtFt = 100; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.PSME11(p_intSIDiaAge, p_intSIHtFt);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SI_LP5
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FIA_Biosum_Manager.exe")]
        public void SI_LP5Test()
        {
            fvs_input_Accessor.site_index target = new fvs_input_Accessor.site_index(); // TODO: Initialize to an appropriate value
            int p_intSIDiaAge = 100; 
            int p_intSIHtFt = 49;
            double p_dblBasalArea = 50; // TODO: Initialize to an appropriate value
            double p_dblAvgDbh = 60; // TODO: Initialize to an appropriate value
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.SI_LP5(p_intSIDiaAge, p_intSIHtFt, p_dblBasalArea, p_dblAvgDbh);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SI_AS1
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FIA_Biosum_Manager.exe")]
        public void SI_AS1Test()
        {
            fvs_input_Accessor.site_index target = new fvs_input_Accessor.site_index(); // TODO: Initialize to an appropriate value
            int p_intSIDiaAge = 100;
            int p_intSIHtFt = 49;
            double expected = 0F; // TODO: Initialize to an appropriate value
            double actual;
            actual = target.SI_AS1(p_intSIDiaAge, p_intSIHtFt);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for site tree equations
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FIA_Biosum_Manager.exe")]
        public void SiteTreesTest()
        {
            string databaseName = "Eqn_28_testing.accdb";
            ado_data_access oAdo = new ado_data_access();

            //open the project db file; db name is hard-coded
            oAdo.OpenConnection(oAdo.getMDBConnString(testDirectory.Trim() +
                "\\" + databaseName, "", ""));

            string biosumPlotId = "120033002010450082329000";
            string condId = "1200";
            string strSQL = "SELECT s.biosum_plot_id," +
            "s.condid," +
            "s.tree," +
            "s.spcd," +
            "s.dia," +
            "s.ht," +
            "s.agedia," +
            "s.subp," +
            "s.method," +
            "s.validcd " +
            "FROM SITETREE s " +
            "WHERE s.biosum_plot_id = '" + biosumPlotId + "' " +
            "AND (s.condlist IS NULL OR " +
            "INSTR('" + condId + "',CSTR(condlist)) > 0)";

            oAdo.SqlQueryReader(oAdo.m_OleDbConnection, strSQL);
            int y;
            if (oAdo.m_OleDbDataReader.HasRows)
            {
                while (oAdo.m_OleDbDataReader.Read())
                {
                    //int intCurFIASpecies = Convert.ToInt32(oAdo.m_DataSet.Tables["GetSiteIndex"].Rows[y]["spcd"]);
                    int intCurAgeDia = Convert.ToInt32(oAdo.m_OleDbDataReader["agedia"]);
                    int intCurHtFt = Convert.ToInt32(oAdo.m_OleDbDataReader["ht"]);
                    int intCondId = Convert.ToInt32(oAdo.m_OleDbDataReader["condid"]);

                }
            }
            
            oAdo.CloseConnection(oAdo.m_OleDbConnection);

            oAdo = null;
        }
    }
}
