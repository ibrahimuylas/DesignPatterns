using System;
using System.Collections.Generic;
using System.IO;

// Singe responsibility principle (SRP)
//     A class should only have one reason to change, meaning that a class should has only one job.
//
//  Below the example 
//      ManagerA provides SRP. Because it uses PdfExportUtil.Export() for exporting. 
//      ManagerB violates SRP. Because it has its own code for exporting. 

namespace DesignPatterns.SOLID
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    internal static class PdfExportUtil
    {
        internal static Stream Export(string content)
        {
            //write some exporting codes here
            throw new NotImplementedException();
        }
    }

    internal class ManagerA
    {
        public void AssignNewPosition(Employee emp, int positionId)
        {
            //assign new position to employee
        }

        public Stream ExportEmployeeListAsPdf(List<Employee> list)
        {
            return PdfExportUtil.Export(renderHtmlForPrinting(list));
        }

        private string renderHtmlForPrinting(List<Employee> list)
        {
            string result = string.Empty;
            //render html

            return result;
        }
    }

    internal class ManagerB
    {
        public void AssignNewPosition(Employee emp, int positionId)
        {
            //assign new position to employee
        }

        public Stream ExportEmployeeListAsPdf(List<Employee> list)
        {
            //writed some exporting codes here
            return new MemoryStream();
        }

        private string renderHtmlForPrinting(List<Employee> list)
        {
            string result = string.Empty;
            //render html

            return result;
        }
    }

}
