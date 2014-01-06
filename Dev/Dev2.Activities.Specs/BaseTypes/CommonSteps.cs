﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Dev2.Activities.Specs.BaseTypes
{
    [Binding]
    public class CommonSteps
    {
        [Then(@"the execution has ""(.*)"" error")]
        public void ThenTheExecutionHasError(string anError)
        {
            bool expected = anError.Equals("NO");
            var result = ScenarioContext.Current.Get<IDSFDataObject>("result");
            string fetchErrors = RecordSetBases.FetchErrors(result.DataListID);
            bool actual = string.IsNullOrEmpty(fetchErrors);
            string message = string.Format("expected {0} error but it {1}", anError.ToLower(),
                                           actual ? "did not occur" : "did occur" + fetchErrors);
            Assert.IsTrue(expected == actual, message);
        }
    }
}