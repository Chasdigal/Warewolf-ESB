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
namespace Warewolf.AcceptanceTesting.Explorer
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ExplorerFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Explorer.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Explorer", "In order to manage my service\r\nAs a Warewolf User\r\nI want explorer view of my res" +
                    "ources with management options", ProgrammingLanguage.CSharp, new string[] {
                        "Explorer"});
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Explorer")))
            {
                Warewolf.AcceptanceTesting.Explorer.ExplorerFeature.FeatureSetup(null);
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
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Connected to localhost server")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void ConnectedToLocalhostServer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Connected to localhost server", ((string[])(null)));
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("the explorer is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("I open \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("I should see \"5\" folders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Expand a folder")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void ExpandAFolder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Expand a folder", ((string[])(null)));
#line 12
this.ScenarioSetup(scenarioInfo);
#line 13
 testRunner.Given("the explorer is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 14
 testRunner.And("I open \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.When("I open \"Folder 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.Then("I should see \"18\" children for \"Folder 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Rename folder")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void RenameFolder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Rename folder", ((string[])(null)));
#line 18
this.ScenarioSetup(scenarioInfo);
#line 19
 testRunner.Given("the explorer is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 20
 testRunner.And("I open \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.When("I rename \"Folder 2\" to \"Folder New\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 22
 testRunner.Then("I should see \"18\" children for \"Folder New\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 23
 testRunner.And("I should not see \"Folder 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Search explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void SearchExplorer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Search explorer", ((string[])(null)));
#line 25
this.ScenarioSetup(scenarioInfo);
#line 26
 testRunner.Given("the explorer is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
 testRunner.And("I open \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 28
 testRunner.When("I search for \"Folder 3\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 29
 testRunner.Then("I should see \"Folder 3\" only", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 30
 testRunner.And("I should not see \"Folder 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("I should not see \"Folder 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("I should not see \"Folder 4\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("I should not see \"Folder 5\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating And Deleting Folder in localhost")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void CreatingAndDeletingFolderInLocalhost()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating And Deleting Folder in localhost", ((string[])(null)));
#line 35
this.ScenarioSetup(scenarioInfo);
#line 37
   testRunner.Given("the explorer is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 38
   testRunner.When("I open \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
   testRunner.Then("I should see \"5\" folders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 40
   testRunner.When("I create \"New Folder\" in \"localhost\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 41
   testRunner.Then("I should see \"New Folder\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 42
   testRunner.And("I should see \"6\" folders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
   testRunner.When("I delete \"New Folder\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 45
   testRunner.Then("I should see \"5\" folders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 46
   testRunner.And("I should not see \"New Folder\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
   testRunner.When("I open \"Folder 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
   testRunner.Then("I should see \"18\" children for \"Folder 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
   testRunner.When("I create \"New Folder\" in \"Folder 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 51
   testRunner.Then("I should see \"19\" children for \"Folder 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 52
   testRunner.And("I should see \"New Folder\" in \"Folder 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
   testRunner.When("I delete \"New Folder\" in \"Folder 2\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
   testRunner.Then("I should see \"18\" children for \"Folder 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 56
   testRunner.And("I should not see \"New Folder\" in \"Folder 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Opening Versions in Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void OpeningVersionsInExplorer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Opening Versions in Explorer", ((string[])(null)));
#line 60
this.ScenarioSetup(scenarioInfo);
#line 61
   testRunner.Given("the explorer is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
   testRunner.When("I open \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
   testRunner.Then("I should see \"5\" folders", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
   testRunner.When("I open \"Folder 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
   testRunner.Then("I should see \"2\" workflows with \"View,Execute\" Icons", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 67
   testRunner.And("I should see \"2\" DB Services with \"View,Execute\" Icons", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
   testRunner.And("I should see \"2\" Web Services with \"View,Execute\" Icons", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
   testRunner.And("I should see \"2\" Plugin Services with \"View,Execute\" Icons", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 70
   testRunner.When("I open \"WF1\" in \"Folder 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 71
   testRunner.Then("\"WF1\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 73
   testRunner.When("I Show Version History for \"WF1\" in \"Folder 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 74
   testRunner.Then("I should see \"3\" versions with \"View\" Icons", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 75
   testRunner.And("I should not see \"3\" versions with \"View,Execute\" Icons", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
   testRunner.When("I open \"v.1\" of \"WF1\" in \"Folder 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
   testRunner.Then("\"v.1\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 78
   testRunner.When("I Make \"v.1\" the current version of \"WF1\" in \"Folder 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 79
   testRunner.Then("I should see \"4\" versions with \"View\" Icons", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
   testRunner.Then("I should see \"OldVersion\" in \"Folder 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 82
   testRunner.When("I Delete Version \"v.2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 83
   testRunner.Then("I should not see \"v.2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
   testRunner.And("I should see \"3\" versions with \"View\" Icons", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating Services Under Localhost")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void CreatingServicesUnderLocalhost()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating Services Under Localhost", ((string[])(null)));
#line 87
this.ScenarioSetup(scenarioInfo);
#line 88
 testRunner.Given("the explorer is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
 testRunner.When("I open \"New Service\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 90
 testRunner.Then("\"Unsavesd1\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 91
 testRunner.When("I open \"New Database Connector\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 92
 testRunner.Then("\"New Database Service\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 93
 testRunner.When("I open \"New Plugin Connector\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 94
 testRunner.Then("\"New Plugin Service\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 95
 testRunner.When("I open \"New Web Service Connector\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 96
 testRunner.Then("\"New Web Service\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 97
 testRunner.When("I open \"New Remote Warewolf Source\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
 testRunner.Then("\"New Server\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 99
 testRunner.When("I open \"New Plugin Source\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 100
 testRunner.Then("\"New Plugin Source\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
 testRunner.When("I open \"New Web Source\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 102
 testRunner.Then("\"New Web Source\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 103
 testRunner.When("I open \"New Email Source\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 104
 testRunner.Then("\"New Email Source\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 105
 testRunner.When("I open \"New Dropbox Source\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 106
 testRunner.Then("\"Dropbox Source\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating Services Under Explorer Folder")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void CreatingServicesUnderExplorerFolder()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating Services Under Explorer Folder", ((string[])(null)));
#line 109
this.ScenarioSetup(scenarioInfo);
#line 110
 testRunner.Given("the explorer is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 111
 testRunner.When("I open \"New Service\" for \"Folder1\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 112
 testRunner.Then("\"Unsavesd1\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 113
 testRunner.When("I open \"New Database Connector\" for \"Folder1\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 114
 testRunner.Then("\"New Database Service\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 115
 testRunner.When("I open \"New Plugin Connector\" for \"Folder1\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 116
 testRunner.Then("\"New Plugin Service\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 117
 testRunner.When("I open \"New Web Service Connector\" for \"Folder1\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 118
 testRunner.Then("\"New Web Service\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 119
 testRunner.When("I open \"New Remote Warewolf Source\" for \"Folder1\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 120
 testRunner.Then("\"New Server\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 121
 testRunner.When("I open \"New Plugin Source\" for \"Folder1\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 122
 testRunner.Then("\"New Plugin Source\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 123
 testRunner.When("I open \"New Web Source\" for \"Folder1\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 124
 testRunner.Then("\"New Web Source\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 125
 testRunner.When("I open \"New Email Source\" for \"Folder1\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 126
 testRunner.Then("\"New Email Source\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 127
 testRunner.When("I open \"New Dropbox Source\" for \"Folder1\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 128
 testRunner.Then("\"Dropbox Source\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 129
 testRunner.When("I Deploy \"Folder 1\" of \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 130
 testRunner.Then("\"Deploy\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Opening Dependencies Of All Services In Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void OpeningDependenciesOfAllServicesInExplorer()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Opening Dependencies Of All Services In Explorer", ((string[])(null)));
#line 133
this.ScenarioSetup(scenarioInfo);
#line 134
    testRunner.Given("the explorer is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 135
 testRunner.When("I open Show Dependencies of \"WF1\" in \"Folder1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 136
 testRunner.Then("\"WF1 Dependents\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 137
 testRunner.When("I open Show Dependencies of \"WebServ1\" in \"Folder1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 138
 testRunner.Then("\"WebServ1 Dependents\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 139
 testRunner.When("I open Show Dependencies of \"DB Service1\" in \"Folder1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 140
 testRunner.Then("\"DB Service1 Dependents\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 141
 testRunner.When("I open Show Dependencies of \"PluginServ1\" in \"Folder1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 142
 testRunner.Then("\"PluginServ1 Dependents\" is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Renaming Folder And Workflow Service")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void RenamingFolderAndWorkflowService()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Renaming Folder And Workflow Service", ((string[])(null)));
#line 146
this.ScenarioSetup(scenarioInfo);
#line 147
 testRunner.Given("the explorer is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 148
 testRunner.And("I open \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 149
 testRunner.When("I rename \"Folder 2\" to \"Folder New\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 150
 testRunner.Then("I should see \"18\" children for \"Folder New\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 151
 testRunner.And("I should not see \"Folder 2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 152
 testRunner.Given("I rename \"WF1\" of \"Follder 1\" to \"WorkFlow1\" in \"Localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 153
 testRunner.Then("I should see \"WorkFlow1\" of \"Folder1\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 154
 testRunner.And("I should not see \"WF1\" in \"Folder1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 155
 testRunner.Given("I rename \"WF2\" of \"Follder 1\" to \"WorkFlow1\" in \"Localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 156
 testRunner.Then("Conflict message is occured", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Renaming Workflow Service Is Creating Version In Version History")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Explorer")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("Explorer")]
        public virtual void RenamingWorkflowServiceIsCreatingVersionInVersionHistory()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Renaming Workflow Service Is Creating Version In Version History", ((string[])(null)));
#line 159
this.ScenarioSetup(scenarioInfo);
#line 160
 testRunner.Given("the explorer is visible", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 161
 testRunner.And("I open \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 162
 testRunner.Given("I rename \"WF2\" of \"Follder 1\" to \"WorkFlow2\" in \"Localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 163
 testRunner.Then("I should see \"WorkFlow2\" of \"Folder1\" in \"localhost\" server", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 164
 testRunner.And("I should not see \"WF2\" in \"Folder1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 165
 testRunner.When("I Show Version History for \"WF2\" in \"Folder 1\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 166
    testRunner.Then("I should see \"1\" versions with \"View\" Icons", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion