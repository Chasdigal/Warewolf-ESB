﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Studio.UI.Specs.DeployUISpecs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute()]
    public partial class DeployFeatureFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DeployUISpec.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "DeployFeature", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
                    "wo numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "DeployFeature")))
            {
                Dev2.Studio.UI.Specs.DeployUISpecs.DeployFeatureFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("IsDeployButtonEnabledWithNothingToDeploy_Expected_DeployButtonIsDisabled12")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "DeployFeature")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("DeployTab")]
        public virtual void IsDeployButtonEnabledWithNothingToDeploy_Expected_DeployButtonIsDisabled12()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("IsDeployButtonEnabledWithNothingToDeploy_Expected_DeployButtonIsDisabled12", new string[] {
                        "DeployTab"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
    testRunner.Given("I have Warewolf running", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
    testRunner.And("all tabs are closed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
    testRunner.Given("I click \"RIBBONDEPLOY\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 12
    testRunner.Given("\"DEPLOYERROR\" is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
    testRunner.Given("\"DEPLOYBUTTON\" is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 16
    testRunner.Given("I click \"DEPLOYSOURCE,UI_SourceServer_UI_Integration Test Resources_AutoID_AutoID" +
                    ",UI_SourceServer_UI_Decision Testing_AutoID_AutoID,UI_CheckBoxDecision Testing_A" +
                    "utoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
    testRunner.Given("\"DEPLOYBUTTON\" is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
    testRunner.Given("I click \"DEPLOYSOURCE,UI_SourceServer_UI_Integration Test Resources_AutoID_AutoID" +
                    ",Expander\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
    testRunner.Given("I click \"DEPLOYSOURCE,UI_SourceServer_UI_Integration Test Resources_AutoID_AutoID" +
                    ",UI_SourceServer_UI_Decision Testing_AutoID_AutoID,UI_CheckBoxDecision Testing_A" +
                    "utoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 21
       testRunner.Given("I click \"ACTIVETAB,DeployUserControl,UI_DestinationServercbx_AutoID,U_UI_Destinat" +
                    "ionServercbx_AutoID_Azure Public\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 23
    testRunner.Given("I click \"DEPLOYSOURCE,UI_SourceServer_UI_Integration Test Resources_AutoID_AutoID" +
                    ",UI_SourceServer_UI_Decision Testing_AutoID_AutoID,UI_CheckBoxDecision Testing_A" +
                    "utoID\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
       testRunner.Given("\"DEPLOYBUTTON\" is disabled", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
