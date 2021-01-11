using System;

namespace Ado.netForAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            /////////////===========  CRUDEoperations cRUDEoperations = new CRUDEoperations();
            //cRUDEoperations.RetriveDetails();
            // cRUDEoperations.RetrievUsingDataTable();
            // cRUDEoperations.RetriveDatabyUSING();
            //cRUDEoperations.insertRecords();
            //cRUDEoperations.updateRecords();
            // cRUDEoperations.deleterecords();
            /////////////Crudewithsp crudewithsp = new Crudewithsp();
            //crudewithsp.InsrtUSINGsp();
            // errorhandling errorhandling = new errorhandling();
            //errorhandling.errorhandlingMethod();
            datasetAnddataADAPTER datasetAnddataADAPTER = new datasetAnddataADAPTER();
            datasetAnddataADAPTER.Execute();
        }
    }
}
