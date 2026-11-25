using AutoCompleteServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AutoCompleteServer.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EmployeeController : ApiController
    {
        public EmployeeController()
        {

        }

        /*
            Get:	http://localhost:56871/api/Employee/Get
            Headers
            Content-Type:application/json         
         */
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<string[]> _employeeList = new List<string[]>();
            _employeeList.Add(new string[] { "Airi", "Satou", "Accountant", "Tokyo", "28th Nov 08", "$162,700" });
            _employeeList.Add(new string[] { "Angelica", "Ramos", "Chief Executive Officer (CEO)", "London", "9th Oct 09", "$1,200,000" });
            _employeeList.Add(new string[] { "Ashton", "Cox", "Junior Technical Author", "San Francisco", "12th Jan 09", "$86,000" });
            _employeeList.Add(new string[] { "Bradley", "Greer", "Software Engineer", "London", "13th Oct 12", "$132,000" });
            _employeeList.Add(new string[] { "Brenden", "Wagner", "Software Engineer", "San Francisco", "7th Jun 11", "$206,850" });
            _employeeList.Add(new string[] { "Brielle", "Williamson", "Integration Specialist", "New York", "2nd Dec 12", "$372,000" });
            _employeeList.Add(new string[] { "Bruno", "Nash", "Software Engineer", "London", "3rd May 11", "$163,500" });
            _employeeList.Add(new string[] { "Caesar", "Vance", "Pre-Sales Support", "New York", "12th Dec 11", "$106,450" });
            _employeeList.Add(new string[] { "Cara", "Stevens", "Sales Assistant", "New York", "6th Dec 11", "$145,600" });
            _employeeList.Add(new string[] { "Cedric", "Kelly", "Senior Javascript Developer", "Edinburgh", "29th Mar 12", "$433,060" });
            EmployeeListInfo eli = new EmployeeListInfo();
            
            eli.draw = 1;
            eli.recordsTotal = 57;
            eli.recordsFiltered = 57;
            eli.data = _employeeList;

            return Ok(eli);
        }

        /*
            Get:	http://localhost:56871/api/getEmployee2
            Headers
            Content-Type:application/json         
         */
        [HttpGet]
        [Route("api/getEmployee2")]
        public IHttpActionResult Get2()
        {
            List<Employee2> _employeeList = new List<Employee2>();
            _employeeList.Add(new Employee2 { DT_RowId = "row_5", first_name = "Airi", last_name = "Satou", position = "Accountant", office = "Tokyo", start_date = new DateTime(2008, 11, 28), salary = 162700 });
            _employeeList.Add(new Employee2 { DT_RowId = "row_25", first_name = "Angelica", last_name = "Ramos", position = "Chief Executive Officer (CEO)", office = "London", start_date = new DateTime(2009, 10, 09), salary = 1200000 });
            _employeeList.Add(new Employee2 { DT_RowId = "row_3", first_name = "Ashton", last_name = "Cox", position = "Junior Technical Author", office = "San Francisco", start_date = new DateTime(2009, 01, 12), salary = 86000 });
            _employeeList.Add(new Employee2 { DT_RowId = "row_19", first_name = "Bradley", last_name = "Greer", position = "Software Engineer", office = "London", start_date = new DateTime(2012, 10, 13), salary = 132000 });
            _employeeList.Add(new Employee2 { DT_RowId = "row_28", first_name = "Brenden", last_name = "Wagner", position = "Software Engineer", office = "San Francisco", start_date = new DateTime(2011, 06, 07), salary = 206850 });
            _employeeList.Add(new Employee2 { DT_RowId = "row_6", first_name = "Brielle", last_name = "Williamson", position = "Integration Specialist", office = "New York", start_date = new DateTime(2012, 12, 02), salary = 372000 });
            _employeeList.Add(new Employee2 { DT_RowId = "row_43", first_name = "Bruno", last_name = "Nash", position = "Software Engineer", office = "London", start_date = new DateTime(2011, 05, 03), salary = 163500 });
            _employeeList.Add(new Employee2 { DT_RowId = "row_23", first_name = "Caesar", last_name = "Vance", position = "Pre-Sales Support", office = "New York", start_date = new DateTime(2011, 12, 12), salary = 106450 });
            _employeeList.Add(new Employee2 { DT_RowId = "row_51", first_name = "Cara", last_name = "Stevens", position = "Sales Assistant", office = "New York", start_date = new DateTime(2011, 12, 06), salary = 145600 });
            _employeeList.Add(new Employee2 { DT_RowId = "row_4", first_name = "Cedric", last_name = "Kelly", position = "Senior Javascript Developer", office = "Edinburgh", start_date = new DateTime(2012, 03, 29), salary = 433060 });
            EmployeeListInfo3 eli = new EmployeeListInfo3();

            eli.draw = 1;
            eli.recordsTotal = 57;
            eli.recordsFiltered = 57;
            eli.data = _employeeList;

            return Ok(eli);
        }

        /*
            Get:	http://localhost:56871/api/getEmployee3
            Headers
            Content-Type:application/json         
         */
        [HttpGet]
        [Route("api/getEmployee3")]
        public IHttpActionResult Get3()
        {
            List<Dictionary<string,string>> _employeeList = new List<Dictionary<string, string>>();
            _employeeList.Add(new Dictionary<string, string> { { "0", "Airi" }, { "1", "Satou" }, { "2", "Accountant" }, { "3", "Tokyo" }, { "4", "28th Nov 08" }, { "5", "$162,700" }, { "DT_RowId", "row_5" } });
            _employeeList.Add(new Dictionary<string, string> { { "0", "Angelica" }, { "1", "Ramos" }, { "2", "Chief Executive Officer (CEO)" }, { "3", "London" }, { "4", "28th Nov 08" }, { "5", "$1,200,000" }, { "DT_RowId", "row_25" } });
            _employeeList.Add(new Dictionary<string, string> { { "0", "Ashton" }, { "1", "Cox" }, { "2", "Junior Technical Author" }, { "3", "San Francisco" }, { "4", "9th Oct 09" }, { "5", "$86,000" }, { "DT_RowId", "row_3" } });
            _employeeList.Add(new Dictionary<string, string> { { "0", "Bradley" }, { "1", "Greer" }, { "2", "Software Engineer" }, { "3", "London" }, { "4", "12th Jan 09" }, { "5", "$132,000" }, { "DT_RowId", "row_19" } });
            _employeeList.Add(new Dictionary<string, string> { { "0", "Brenden" }, { "1", "Wagner" }, { "2", "Software Engineer" }, { "3", "San Francisco" }, { "4", "13th Oct 12" }, { "5", "$206,850" }, { "DT_RowId", "row_28" } });
            _employeeList.Add(new Dictionary<string, string> { { "0", "Brielle" }, { "1", "Williamson" }, { "2", "Integration Specialist" }, { "3", "New York" }, { "4", "7th Jun 11" }, { "5", "$372,000" }, { "DT_RowId", "row_6" } });
            _employeeList.Add(new Dictionary<string, string> { { "0", "Bruno" }, { "1", "Nash" }, { "2", "Software Engineer" }, { "3", "London" }, { "4", "2nd Dec 12" }, { "5", "$163,500" }, { "DT_RowId", "row_43" } });
            _employeeList.Add(new Dictionary<string, string> { { "0", "Caesar" }, { "1", "Vance" }, { "2", "Pre-Sales Support" }, { "3", "New York" }, { "4", "3rd May 11" }, { "5", "$106,450" }, { "DT_RowId", "row_23" } });
            _employeeList.Add(new Dictionary<string, string> { { "0", "Cara" }, { "1", "Stevens" }, { "2", "Sales Assistant" }, { "3", "New York" }, { "4", "12th Dec 11" }, { "5", "$145,600" }, { "DT_RowId", "row_51" } });
            _employeeList.Add(new Dictionary<string, string> { { "0", "Cedric" }, { "1", "Kelly" }, { "2", "Senior Javascript Developer" }, { "3", "Edinburgh" }, { "4", "6th Dec 11" }, { "5", "$433,060" }, { "DT_RowId", "row_4" } });                  
            EmployeeListInfo4 eli = new EmployeeListInfo4();

            eli.draw = 1;
            eli.recordsTotal = 57;
            eli.recordsFiltered = 57;
            eli.data = _employeeList;

            return Ok(eli);
        }

        /*
            Post:	http://localhost:56871/api/Employee/Post
            Headers
            Content-Type:application/json         
         */
        // POST api/values
        public IHttpActionResult Post()
        {
            List<Employee> _employeeList = new List<Employee>();
            _employeeList.Add(new Employee { first_name = "Airi", last_name = "Satou", position = "Accountant", office = "Tokyo", start_date = new DateTime(2008, 11, 28), salary = 162700 });
            _employeeList.Add(new Employee { first_name = "Angelica", last_name = "Ramos", position = "Chief Executive Officer (CEO)", office = "London", start_date = new DateTime(2009, 10, 09), salary = 1200000 });
            _employeeList.Add(new Employee { first_name = "Ashton", last_name = "Cox", position = "Junior Technical Author", office = "San Francisco", start_date = new DateTime(2009, 01, 12), salary = 86000 });
            _employeeList.Add(new Employee { first_name = "Bradley", last_name = "Greer", position = "Software Engineer", office = "London", start_date = new DateTime(2012, 10, 13), salary = 132000 });
            _employeeList.Add(new Employee { first_name = "Brenden", last_name = "Wagner", position = "Software Engineer", office = "San Francisco", start_date = new DateTime(2011, 06, 07), salary = 206850 });
            _employeeList.Add(new Employee { first_name = "Brielle", last_name = "Williamson", position = "Integration Specialist", office = "New York", start_date = new DateTime(2012, 12, 02), salary = 372000 });
            _employeeList.Add(new Employee { first_name = "Bruno", last_name = "Nash", position = "Software Engineer", office = "London", start_date = new DateTime(2011, 05, 03), salary = 163500 });
            _employeeList.Add(new Employee { first_name = "Caesar", last_name = "Vance", position = "Pre-Sales Support", office = "New York", start_date = new DateTime(2011, 12, 12), salary = 106450 });
            _employeeList.Add(new Employee { first_name = "Cara", last_name = "Stevens", position = "Sales Assistant", office = "New York", start_date = new DateTime(2011, 12, 06), salary = 145600 });
            _employeeList.Add(new Employee { first_name = "Cedric", last_name = "Kelly", position = "Senior Javascript Developer", office = "Edinburgh", start_date = new DateTime(2012, 03, 29), salary = 433060 });
            EmployeeListInfo2 eli = new EmployeeListInfo2();

            eli.draw = 1;
            eli.recordsTotal = 57;
            eli.recordsFiltered = 57;
            eli.data = _employeeList;

            return Ok(eli);
        }
    }
}
