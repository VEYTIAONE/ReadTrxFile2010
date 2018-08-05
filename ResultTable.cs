using System;
using System.IO;
using System.Data;
using System.Xml.Serialization;

namespace ReadTrxFile
{
    public class ResultTable
    {
        public DataTable CreateTestResultTable()
        {
            // Define the new datatable
            DataTable dt = new DataTable();
            DataColumn dc;
            dc = new DataColumn(Constant.PROCESSEDFILENAME);
            dt.Columns.Add(dc);
            dc = new DataColumn(Constant.TESTID);
            dt.Columns.Add(dc);
            dc = new DataColumn(Constant.TESTNAME);
            dt.Columns.Add(dc);
            dc = new DataColumn(Constant.TESTOUTCOME);
            dt.Columns.Add(dc);
            dc = new DataColumn(Constant.ERRORMESSAGE);
            dt.Columns.Add(dc);
            return dt;
        }
        public DataTable GetTestResultData()
        {
            string fileName;
            DataTable testResultTable = null;
            try
            {
                // Construct DirectoryInfo for the folder path passed in as an argument
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //baseDirectory = baseDirectory.Substring(0, baseDirectory.IndexOf("bin"));
                DirectoryInfo di = new DirectoryInfo(baseDirectory);
                ResultTable resultTable = new ResultTable();
                testResultTable = resultTable.CreateTestResultTable();
                // For each .trx file in the given folder process it
                foreach (FileInfo file in di.GetFiles("*.trx"))
                {
                    fileName = file.Name;
                    // Deserialize TestRunType object from the trx file
                    StreamReader fileStreamReader = new StreamReader(file.FullName);
                    XmlSerializer xmlSer = new XmlSerializer(typeof(TestRunType));
                    TestRunType testRunType = (TestRunType)xmlSer.Deserialize(fileStreamReader);
                    // Navigate to UnitTestResultType object and update the sheet with test result information
                    foreach (object itob1 in testRunType.Items)
                    {
                        ResultsType resultsType = itob1 as ResultsType;
                        if (resultsType != null)
                        {
                            foreach (object itob2 in resultsType.Items)
                            {
                                UnitTestResultType unitTestResultType = itob2 as UnitTestResultType;
                                if (unitTestResultType != null)
                                {
                                    DataRow row = testResultTable.NewRow();
                                    row[Constant.PROCESSEDFILENAME] = fileName;
                                    row[Constant.TESTID] = unitTestResultType.testId;
                                    row[Constant.TESTNAME] = unitTestResultType.testName;
                                    row[Constant.TESTOUTCOME] = unitTestResultType.outcome;
                                    row[Constant.ERRORMESSAGE] = ((System.Xml.XmlNode[])(((OutputType)(((TestResultType)(unitTestResultType)).Items[0])).ErrorInfo.Message))[0].Value;
                                    testResultTable.Rows.Add(row);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
               
            }
            return testResultTable;
        }
    }
}