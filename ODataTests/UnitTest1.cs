using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ODataTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // https://blogs.msdn.microsoft.com/odatateam/2014/03/11/tutorial-sample-how-to-use-odata-client-code-generator-to-generate-client-side-proxy-class/

            var db = new ODataTests.Default.Container(new Uri("http://localhost:52507/"));

            var employees = db.Employees.ToList();

            Debug.WriteLine(employees.Count);

        }
    }
}
