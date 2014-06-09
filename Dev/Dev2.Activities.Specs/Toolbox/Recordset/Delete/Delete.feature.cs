﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.18063
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Activities.Specs.Toolbox.Recordset.Delete
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class DeleteFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Delete.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Delete", "In order to delete records\r\nAs a Warewolf user\r\nI want a tool that takes a record" +
                    " set and deletes it", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Delete")))
            {
                Dev2.Activities.Specs.Toolbox.Recordset.Delete.DeleteFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete last record in a recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteLastRecordInARecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete last record in a recordset", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 7
 testRunner.Given("I have the following recordset", ((string)(null)), table1, "Given ");
#line 12
 testRunner.And("I delete a record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then("the delete result should be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table2.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table2.AddRow(new string[] {
                        "rs().row",
                        "2"});
#line 15
 testRunner.And("the recordset \"[[rs().row]]\" will be as follows", ((string)(null)), table2, "And ");
#line 19
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table3.AddRow(new string[] {
                        "[[rs(3).row]] = 3"});
#line 20
 testRunner.And("the debug inputs as", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table4.AddRow(new string[] {
                        "[[result]] = Success"});
#line 23
 testRunner.And("the debug output as", ((string)(null)), table4, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete an invalid recordset (recordset with no fields declared)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteAnInvalidRecordsetRecordsetWithNoFieldsDeclared()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete an invalid recordset (recordset with no fields declared)", ((string[])(null)));
#line 27
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table5.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table5.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table5.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 28
 testRunner.Given("I have the following recordset", ((string)(null)), table5, "Given ");
#line 33
 testRunner.And("I delete a record \"[[GG()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 35
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 36
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table6.AddRow(new string[] {
                        "[[GG()]] ="});
#line 37
 testRunner.And("the debug inputs as", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table7.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 40
 testRunner.And("the debug output as", ((string)(null)), table7, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete the first record in a recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteTheFirstRecordInARecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete the first record in a recordset", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table8.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table8.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table8.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 45
 testRunner.Given("I have the following recordset", ((string)(null)), table8, "Given ");
#line 50
 testRunner.And("I delete a record \"[[rs(1)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.Then("the delete result should be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table9.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table9.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 53
 testRunner.And("the recordset \"[[rs().row]]\" will be as follows", ((string)(null)), table9, "And ");
#line 57
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table10.AddRow(new string[] {
                        "[[rs(1).row]] = 1"});
#line 58
 testRunner.And("the debug inputs as", ((string)(null)), table10, "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table11.AddRow(new string[] {
                        "[[result]] = Success"});
#line 61
 testRunner.And("the debug output as", ((string)(null)), table11, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete a record using an index from a variable")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteARecordUsingAnIndexFromAVariable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record using an index from a variable", ((string[])(null)));
#line 65
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table12.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table12.AddRow(new string[] {
                        "rs().row",
                        "6"});
            table12.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 66
 testRunner.Given("I have the following recordset", ((string)(null)), table12, "Given ");
#line 71
 testRunner.And("an index \"[[index]]\" exists with a value \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And("I delete a record \"[[rs([[index]])]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
 testRunner.Then("the delete result should be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table13.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table13.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 75
 testRunner.And("the recordset \"[[rs().row]]\" will be as follows", ((string)(null)), table13, "And ");
#line 79
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table14.AddRow(new string[] {
                        "[[rs([[index]])]] = 6"});
#line 80
 testRunner.And("the debug inputs as", ((string)(null)), table14, "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table15.AddRow(new string[] {
                        "[[result]] = Success"});
#line 83
 testRunner.And("the debug output as", ((string)(null)), table15, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete a record using a star notation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteARecordUsingAStarNotation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record using a star notation", ((string[])(null)));
#line 87
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table16.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table16.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table16.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 88
 testRunner.Given("I have the following recordset", ((string)(null)), table16, "Given ");
#line 93
 testRunner.And("I delete a record \"[[rs(*)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 95
 testRunner.Then("the delete result should be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
#line 96
 testRunner.And("the recordset \"[[rs().row]]\" will be as follows", ((string)(null)), table17, "And ");
#line 98
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table18.AddRow(new string[] {
                        "[[rs(1).row]] = 1"});
            table18.AddRow(new string[] {
                        "[[rs(2).row]] = 2"});
            table18.AddRow(new string[] {
                        "[[rs(3).row]] = 3"});
#line 99
 testRunner.And("the debug inputs as", ((string)(null)), table18, "And ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table19.AddRow(new string[] {
                        "[[result]] = Success"});
#line 104
 testRunner.And("the debug output as", ((string)(null)), table19, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete a record using a negative integer -1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteARecordUsingANegativeInteger_1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record using a negative integer -1", ((string[])(null)));
#line 108
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table20.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table20.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table20.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 109
 testRunner.Given("I have the following recordset", ((string)(null)), table20, "Given ");
#line 114
 testRunner.And("I delete a record \"[[rs(-1)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 115
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table21.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table21.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table21.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 117
 testRunner.And("the recordset \"[[rs().row]]\" will be as follows", ((string)(null)), table21, "And ");
#line 122
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table22.AddRow(new string[] {
                        "[[rs(-1)]]  ="});
#line 123
 testRunner.And("the debug inputs as", ((string)(null)), table22, "And ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table23.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 126
 testRunner.And("the debug output as", ((string)(null)), table23, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete a record that does not exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteARecordThatDoesNotExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record that does not exist", ((string[])(null)));
#line 130
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table24.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table24.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table24.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 131
 testRunner.Given("I have the following recordset", ((string)(null)), table24, "Given ");
#line 136
 testRunner.And("I delete a record \"[[rs(5)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 137
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 138
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table25.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table25.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table25.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 139
 testRunner.And("the recordset \"[[rs().row]]\" will be as follows", ((string)(null)), table25, "And ");
#line 144
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table26.AddRow(new string[] {
                        "[[rs(5).row]]  ="});
#line 145
 testRunner.And("the debug inputs as", ((string)(null)), table26, "And ");
#line hidden
            TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table27.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 148
 testRunner.And("the debug output as", ((string)(null)), table27, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete a record an empty recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteARecordAnEmptyRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record an empty recordset", ((string[])(null)));
#line 152
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "row"});
#line 153
 testRunner.Given("I have the following recordset", ((string)(null)), table28, "Given ");
#line 155
 testRunner.And("I delete a record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 156
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 157
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "row"});
#line 158
 testRunner.And("the recordset \"[[rs().row]]\" will be as follows", ((string)(null)), table29, "And ");
#line 160
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table30.AddRow(new string[] {
                        "[[rs(1).row]]  ="});
#line 161
 testRunner.And("the debug inputs as", ((string)(null)), table30, "And ");
#line hidden
            TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table31.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 164
 testRunner.And("the debug output as", ((string)(null)), table31, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete a scalar insted of a recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteAScalarInstedOfARecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a scalar insted of a recordset", ((string[])(null)));
#line 168
this.ScenarioSetup(scenarioInfo);
#line 169
 testRunner.Given("I have a delete variable \"[[var]]\" equal to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 170
 testRunner.And("I delete a record \"[[var]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 171
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 172
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 173
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table32.AddRow(new string[] {
                        "[[var]]  ="});
#line 174
 testRunner.And("the debug inputs as", ((string)(null)), table32, "And ");
#line hidden
            TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table33.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 177
 testRunner.And("the debug output as", ((string)(null)), table33, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void DeletingOneRecordsetWithTwoDeleteTools_(string no, string delete1, string delete2, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Deleting one recordset with two Delete tools.", exampleTags);
#line 225
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table34.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table34.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table34.AddRow(new string[] {
                        "rs().row",
                        "3"});
            table34.AddRow(new string[] {
                        "rs().row",
                        "4"});
#line 226
 testRunner.Given("I have the following recordset", ((string)(null)), table34, "Given ");
#line 232
 testRunner.And("I delete a record \'<Delete1>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 233
   testRunner.And("I delete a record \'<Delete2>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 234
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 235
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 236
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "row"});
#line 237
 testRunner.And("the recordset \"[[rs().row]]\" will be as follows", ((string)(null)), table35, "And ");
#line 239
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table36.AddRow(new string[] {
                        "[[rs(1).a]]  = 1"});
#line 240
 testRunner.And("the debug inputs as", ((string)(null)), table36, "And ");
#line hidden
            TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table37.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 243
 testRunner.And("the debug output as", ((string)(null)), table37, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deleting one recordset with two Delete tools.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:no", "1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:delete1", "[[rs(*)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:delete2", "rs(1)]]")]
        public virtual void DeletingOneRecordsetWithTwoDeleteTools__1()
        {
            this.DeletingOneRecordsetWithTwoDeleteTools_("1", "[[rs(*)]]", "rs(1)]]", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deleting one recordset with two Delete tools.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:no", "2")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:delete1", "[[rs(1)]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:delete2", "rs(1)]]")]
        public virtual void DeletingOneRecordsetWithTwoDeleteTools__2()
        {
            this.DeletingOneRecordsetWithTwoDeleteTools_("2", "[[rs(1)]]", "rs(1)]]", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Deleting one recordset with two Delete tools.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:no", "3")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:delete1", "[[rs(1).a]]")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:delete2", "rs(1)]]")]
        public virtual void DeletingOneRecordsetWithTwoDeleteTools__3()
        {
            this.DeletingOneRecordsetWithTwoDeleteTools_("3", "[[rs(1).a]]", "rs(1)]]", ((string[])(null)));
        }
    }
}
#pragma warning restore
#endregion
