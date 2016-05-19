using FIA_Biosum_Manager;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
        private double conditionClassAverageDia;
        private string TreeTable = "TREE";
        private string SiteTreeTable = "SITETREE";
        private string BiosumPlotId;
        private string databaseName;

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
        ///Unit test for SI_LP5 equation
        ///</summary>
        [TestMethod()]
        [DeploymentItem("FIA_Biosum_Manager.exe")]
        public void SI_LP5Test()
        {
            fvs_input_Accessor.site_index target = new fvs_input_Accessor.site_index();
            databaseName = "Eqn_28_testing.accdb";
            ado_data_access oAdo = new ado_data_access();

            //open the project db file; db name is hard-coded
            oAdo.OpenConnection(oAdo.getMDBConnString(testDirectory.Trim() +
                "\\" + databaseName, "", ""));

            //add column for results if it doesn't exist
            string resultsColumn = "calc_si";
            string basalAreaColumn = "ba_ft2_ac";
            string dbhColumn = "avg_dbh_plot";
            if (!oAdo.ColumnExist(oAdo.m_OleDbConnection, "SITETREE", resultsColumn))
            {
                oAdo.AddColumn(oAdo.m_OleDbConnection, "SITETREE", resultsColumn, "DOUBLE", "");
            }
            if (!oAdo.ColumnExist(oAdo.m_OleDbConnection, "SITETREE", basalAreaColumn))
            {
                oAdo.AddColumn(oAdo.m_OleDbConnection, "SITETREE", basalAreaColumn, "DOUBLE", "");
            }
            if (!oAdo.ColumnExist(oAdo.m_OleDbConnection, "SITETREE", dbhColumn))
            {
                oAdo.AddColumn(oAdo.m_OleDbConnection, "SITETREE", dbhColumn, "DOUBLE", "");
            }

            string strSQL = "SELECT p.biosum_plot_id, c.biosum_cond_id, p.statecd ," + 
					"p.countycd, p.plot, p.fvs_variant, p.measyear," + 
					"c.adforcd,p.elev,c.condid, c.habtypcd1," + 
					"c.stdage,c.slope,c.aspect,c.ground_land_class_pnw," + 
					"c.sisp,p.lat,p.lon,p.idb_plot_id,c.adforcd,c.habtypcd1, " +
                    "p.elev,c.landclcd,c.ba_ft2_ac " + 
					"FROM COND c," + 
                    "PLOT p " + 
					"WHERE p.biosum_plot_id = c.biosum_plot_id;";

            oAdo.SqlQueryReader(oAdo.m_OleDbConnection, strSQL);
            List<List<string>> lstPlotCond = new List<List<string>>();
            Int16 idxPlotId = 0;
            Int16 idxCondId = 1;
            Int16 idxBasalArea = 2;
            while (oAdo.m_OleDbDataReader.Read())
            {
                List<string> lstPlot = new List<string>();
                lstPlot.Add(Convert.ToString(oAdo.m_OleDbDataReader["biosum_plot_id"]).Trim());
                lstPlot.Add(Convert.ToString(oAdo.m_OleDbDataReader["condid"]).Trim());
                lstPlot.Add(Convert.ToString(oAdo.m_OleDbDataReader["ba_ft2_ac"]).Trim());
                lstPlotCond.Add(lstPlot);
            }

            Dictionary<string, string> siteIndexRecords = new Dictionary<string, string>();
            foreach (List<string> lstPlot in lstPlotCond)
            {
                this.BiosumPlotId = lstPlot[idxPlotId];
                string condId = lstPlot[idxCondId];
                strSQL = "SELECT s.biosum_plot_id," +
            "s.condid," +
            "s.tree," +
            "s.spcd," +
            "s.dia," +
            "s.ht," +
            "s.agedia," +
            "s.subp," +
            "s.method," +
            "s.validcd " +
            "FROM " + this.SiteTreeTable + " s " +
            "WHERE s.biosum_plot_id = '" + this.BiosumPlotId + "' " +
                    //"AND (s.condlist IS NULL OR " +
                    //"INSTR('" + condId + "',CSTR(condlist)) > 0)";
                    //"INSTR(CSTR(condlist),'" + condId + "') > 0)";
            "AND s.condid = " + condId; //eliminates duplicate trees; Not the same as fvs_input.cs


                double p_dblBasalArea = Convert.ToDouble(lstPlot[idxBasalArea]);
                getAvgDbhOnPlot(Convert.ToInt32(condId));

                //Console.WriteLine(strSQL);
                oAdo.SqlQueryReader(oAdo.m_OleDbConnection, strSQL);
            if (oAdo.m_OleDbDataReader.HasRows)
            {
                while (oAdo.m_OleDbDataReader.Read())
                {
                    //int intCurFIASpecies = Convert.ToInt32(oAdo.m_DataSet.Tables["GetSiteIndex"].Rows[y]["spcd"]);
                    int intCurAgeDia = Convert.ToInt32(oAdo.m_OleDbDataReader["agedia"]);
                    int intCurHtFt = Convert.ToInt32(oAdo.m_OleDbDataReader["ht"]);
                    int intCondId = Convert.ToInt32(oAdo.m_OleDbDataReader["condid"]);
                    int treeId = Convert.ToInt32(oAdo.m_OleDbDataReader["tree"]);
                    string key = this.BiosumPlotId + "_" + intCondId + "_" + treeId;
                    double siteIndex = target.SI_LP5(intCurAgeDia, intCurHtFt, p_dblBasalArea, this.conditionClassAverageDia);
                    string value = Convert.ToString(this.conditionClassAverageDia) + "_" + Convert.ToString(p_dblBasalArea) + "_" + Convert.ToString(siteIndex);
                    siteIndexRecords.Add(key, value);
                }
            }
            }

            foreach (string key in siteIndexRecords.Keys)
            {
                string[] keyValues = key.Split('_');
                string[] resultValues = siteIndexRecords[key].Split('_');
                oAdo.m_strSQL = "UPDATE " + this.SiteTreeTable + " " +
                    "SET " + resultsColumn + " = " + resultValues[2] + ", " +
                    basalAreaColumn + " = " + resultValues[1] + ", " +
                    dbhColumn + " = " + resultValues[0] + " " +
                    "WHERE biosum_plot_id = '" + keyValues[0] + "' " +
                    "AND condid = " + keyValues[1] + " " +
                    "AND tree = " + keyValues[2];
                oAdo.SqlNonQuery(oAdo.m_OleDbConnection, oAdo.m_strSQL);
            }
            
            oAdo.CloseConnection(oAdo.m_OleDbConnection);

            oAdo = null;
        }

        private void getAvgDbhOnPlot(int p_intCondId)
        {

            this.conditionClassAverageDia = 0;

            ado_data_access _oAdo = new ado_data_access();

            //open the project db file; db name is hard-coded
            _oAdo.OpenConnection(_oAdo.getMDBConnString(testDirectory.Trim() +
                "\\" + databaseName, "", ""));

            _oAdo.m_strSQL = "SELECT AvgDia " +
                "FROM " +
                "(SELECT SUM(IIF(t.tpacurr IS NOT NULL AND t.dia IS NOT NULL," +
                "t.tpacurr * t.dia,0)) AS dividend," +
                "SUM(IIF(t.tpacurr IS NOT NULL and t.dia IS NOT NULL," +
                "t.tpacurr,0)) as divisor," +
                "IIF(dividend > 0 AND divisor > 0," +
                "dividend / divisor,0) AS AvgDia " +
                "FROM " + this.TreeTable + " t " +
                "WHERE biosum_cond_id = '" +
                this.BiosumPlotId + Convert.ToString(p_intCondId).Trim() + "' " +
                "AND t.statuscd=1)";

            this.conditionClassAverageDia = _oAdo.getSingleDoubleValueFromSQLQuery(
                _oAdo.m_OleDbConnection, _oAdo.m_strSQL, "temp");
            _oAdo.CloseConnection(_oAdo.m_OleDbConnection);

            _oAdo = null;
        }

    }
}
