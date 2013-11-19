﻿using System;
using System.Activities;
using System.Activities.Expressions;
using System.Activities.Presentation;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using ActivityUnitTests;
using Dev2.Common;
using Dev2.Data.Decision;
using Dev2.Data.Decisions.Operations;
using Dev2.Data.SystemTemplates.Models;
using Dev2.DataList.Contract;
using Dev2.Diagnostics;
using Dev2.Utilities;
using Microsoft.CSharp.Activities;
using Microsoft.VisualBasic.Activities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unlimited.Applications.BusinessDesignStudio.Activities;

namespace Dev2.Tests.Activities.ActivityTests
{
    /// <summary>
    /// Summary description for DateTimeDifferenceTests
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DsfFlowNodeTests : BaseActivityUnitTest
    {
        #region Decision Tests

        // 2013.02.13: Ashley Lewis - Bug 8725, Task 8913
        // 2013.03.03 : Travis - Refactored to properly test logic required
        [TestMethod]
        public void DecisionWithQuotesInScalarExpectedNoUnhandledExceptions()
        {

            Dev2DecisionStack dds = new Dev2DecisionStack { TheStack = new List<Dev2Decision>(), Mode = Dev2DecisionMode.AND };
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();
            dds.AddModelItem(new Dev2Decision { Col1 = "[[var]]", Col2 = "\"", EvaluationFn = enDecisionType.IsEqual });

            string modelData = dds.ToVBPersistableModel();

            CurrentDl = "<ADL><var/></ADL>";
            TestData = "<root><var>\"</var></root>";
            ErrorResultTO errors;
            Guid exeID = compiler.ConvertTo(DataListFormat.CreateFormat(GlobalConstants._XML), TestData, CurrentDl, out errors);

            IList<string> getDatalistID = new List<string> { exeID.ToString() };

            var res = new Dev2DataListDecisionHandler().ExecuteDecisionStack(modelData, getDatalistID);

            // remove test datalist ;)
            DataListRemoval(exeID);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void DecisionWithQuotesInDataExpectedNoUnhandledExceptions()
        {

            Dev2DecisionStack dds = new Dev2DecisionStack { TheStack = new List<Dev2Decision>(), Mode = Dev2DecisionMode.AND };
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();
            dds.AddModelItem(new Dev2Decision { Col1 = "[[var]]", Col2 = "[[var]]", EvaluationFn = enDecisionType.IsEqual });

            string modelData = dds.ToVBPersistableModel();

            CurrentDl = "<ADL><var/></ADL>";
            TestData = "<root><var>\"something \"data\" \"</var></root>";
            ErrorResultTO errors;
            Guid exeID = compiler.ConvertTo(DataListFormat.CreateFormat(GlobalConstants._XML), TestData, CurrentDl, out errors);

            IList<string> getDatalistID = new List<string> { exeID.ToString() };

            var res = new Dev2DataListDecisionHandler().ExecuteDecisionStack(modelData, getDatalistID);

            // remove test datalist ;)
            DataListRemoval(exeID);

            Assert.IsTrue(res);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("Dev2DataListDecisionHandler_ExecuteDecisionStack")]
        public void Dev2DataListDecisionHandler_ExecuteDecisionStack_WithRecordSetIndexed_EvalutesDecisionCorrectly()
        {

            Dev2DecisionStack dds = new Dev2DecisionStack { TheStack = new List<Dev2Decision>(), Mode = Dev2DecisionMode.AND };
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();
            dds.AddModelItem(new Dev2Decision { Col1 = "[[vars(1).var]]", Col2 = "[[vars(2).var]]", EvaluationFn = enDecisionType.IsEqual });

            string modelData = dds.ToVBPersistableModel();

            CurrentDl = "<ADL><vars><var></var></vars></ADL>";
            TestData = "<root><vars><var>\"something \"data\" \"</var></vars><vars><var>\"somthing \"data\" \"</var></vars></root>";
            ErrorResultTO errors;
            Guid exeID = compiler.ConvertTo(DataListFormat.CreateFormat(GlobalConstants._XML), TestData, CurrentDl, out errors);

            IList<string> getDatalistID = new List<string> { exeID.ToString() };

            var res = new Dev2DataListDecisionHandler().ExecuteDecisionStack(modelData, getDatalistID);

            // remove test datalist ;)
            DataListRemoval(exeID);

            Assert.IsFalse(res);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("Dev2DataListDecisionHandler_ExecuteDecisionStack")]
        public void Dev2DataListDecisionHandler_ExecuteDecisionStack_WithRecordSetBlank_EvalutesDecisionCorrectlyFalse()
        {

            Dev2DecisionStack dds = new Dev2DecisionStack { TheStack = new List<Dev2Decision>(), Mode = Dev2DecisionMode.AND };
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();
            dds.AddModelItem(new Dev2Decision { Col1 = "[[vars(1).var]]", Col2 = "[[vars().var]]", EvaluationFn = enDecisionType.IsEqual });

            string modelData = dds.ToVBPersistableModel();

            CurrentDl = "<ADL><vars><var></var></vars></ADL>";
            TestData = "<root><vars><var>\"something \"data\" \"</var></vars><vars><var>\"somthing \"data\" \"</var></vars></root>";
            ErrorResultTO errors;
            Guid exeID = compiler.ConvertTo(DataListFormat.CreateFormat(GlobalConstants._XML), TestData, CurrentDl, out errors);

            IList<string> getDatalistID = new List<string> { exeID.ToString() };

            var res = new Dev2DataListDecisionHandler().ExecuteDecisionStack(modelData, getDatalistID);

            // remove test datalist ;)
            DataListRemoval(exeID);

            Assert.IsFalse(res);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("Dev2DataListDecisionHandler_ExecuteDecisionStack")]
        public void Dev2DataListDecisionHandler_ExecuteDecisionStack_WithRecordSetBlank_EvalutesDecisionCorrectlyTrue()
        {

            Dev2DecisionStack dds = new Dev2DecisionStack { TheStack = new List<Dev2Decision>(), Mode = Dev2DecisionMode.AND };
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();
            dds.AddModelItem(new Dev2Decision { Col1 = "[[vars(1).var]]", Col2 = "[[vars().var]]", EvaluationFn = enDecisionType.IsEqual });

            string modelData = dds.ToVBPersistableModel();

            CurrentDl = "<ADL><vars><var></var></vars></ADL>";
            TestData = "<root><vars><var>\"something \"data\" \"</var></vars><vars><var>\"something \"data\" \"</var></vars></root>";
            ErrorResultTO errors;
            Guid exeID = compiler.ConvertTo(DataListFormat.CreateFormat(GlobalConstants._XML), TestData, CurrentDl, out errors);

            IList<string> getDatalistID = new List<string> { exeID.ToString() };

            var res = new Dev2DataListDecisionHandler().ExecuteDecisionStack(modelData, getDatalistID);

            // remove test datalist ;)
            DataListRemoval(exeID);

            Assert.IsTrue(res);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("Dev2DataListDecisionHandler_ExecuteDecisionStack")]
        public void Dev2DataListDecisionHandler_ExecuteDecisionStack_WithRecordStar_EvalutesDecisionCorrectly()
        {

            Dev2DecisionStack dds = new Dev2DecisionStack { TheStack = new List<Dev2Decision>(), Mode = Dev2DecisionMode.AND };
            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();
            dds.AddModelItem(new Dev2Decision { Col1 = "[[vars(*).var]]", Col2 = @"something ""data""", EvaluationFn = enDecisionType.IsEqual });

            string modelData = dds.ToVBPersistableModel();

            CurrentDl = "<ADL><vars><var></var></vars></ADL>";
            TestData = "<root><vars><var>something \"data\"</var></vars><vars><var>something \"data\"</var></vars></root>";
            ErrorResultTO errors;
            Guid exeID = compiler.ConvertTo(DataListFormat.CreateFormat(GlobalConstants._XML), TestData, CurrentDl, out errors);

            IList<string> getDatalistID = new List<string> { exeID.ToString() };

            var res = new Dev2DataListDecisionHandler().ExecuteDecisionStack(modelData, getDatalistID);

            // remove test datalist ;)
            DataListRemoval(exeID);

            Assert.IsTrue(res);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("Dev2DataListDecisionHandler_ExecuteDecisionStack")]
        [Ignore] // This is still an issue as the model data is being changed somewhere before the DecisionHandler.
        public void Dev2DataListDecisionHandler_ExecuteDecisionStack_SlashInVariable_CanDeserialize()
        {
            CurrentDl = "<ADL><resul><t/></resul></ADL>";
            TestData = @"<root><resul><t>1234</t></resul><resul><t>1234</t></resul><resul><t>1/2\3/4\</t></resul><resul><t>1\n2\n3\n4\n</t></resul><resul><t>1 2   3   4   5   </t></resul></root>";
            ErrorResultTO errors;

            IDataListCompiler compiler = DataListFactory.CreateDataListCompiler();
            Guid exeID = compiler.ConvertTo(DataListFormat.CreateFormat(GlobalConstants._XML), TestData, CurrentDl, out errors);
            IList<string> getDatalistID = new List<string> { exeID.ToString() };

            var dev2DataListDecisionHandler = new Dev2DataListDecisionHandler();

            //------------Execute Test---------------------------
            var res = dev2DataListDecisionHandler.ExecuteDecisionStack(@"{""TheStack"":[{""Col1"":""[[resul(1).t]]"",""Col2"":""1234"",""Col3"":"""",""PopulatedColumnCount"":2,""EvaluationFn"":""IsEqual""},{""Col1"":""[[resul(2).t]]"",""Col2"":""1234"",""Col3"":"""",""PopulatedColumnCount"":2,""EvaluationFn"":""IsEqual""},{""Col1"":""[[resul(3).t]]"",""Col2"":""1/2\\3/4\\"",""Col3"":"""",""PopulatedColumnCount"":2,""EvaluationFn"":""IsEqual""},{""Col1"":""[[resul(4).t]]"",""Col2"":""1\n2\n3\n4\n"",""Col3"":"""",""PopulatedColumnCount"":2,""EvaluationFn"":""IsEqual""},{""Col1"":""[[resul(5).t]]"",""Col2"":""1  2   3   4   5   "",""Col3"":"""",""PopulatedColumnCount"":2,""EvaluationFn"":""IsEqual""}],""TotalDecisions"":5,""ModelName"":""Dev2DecisionStack"",""Mode"":""AND"",""TrueArmText"":""True"",""FalseArmText"":""False"",""DisplayText"":""Decision""}", getDatalistID);

            // Assert Can Deserialize
            Assert.IsTrue(res);

            DataListRemoval(exeID);
        }
        #endregion Decision Tests

        #region GetDebugInputs/Outputs

        #region Decision tests

        [TestMethod]
        // ReSharper disable InconsistentNaming
        //Bug 8104
        public void FileRead_Get_Debug_Input_Output_With_Recordset_Expected_Pass()
        // ReSharper restore InconsistentNaming
        {
            DsfFlowDecisionActivity act = new DsfFlowDecisionActivity();
            Dev2DecisionStack dds = new Dev2DecisionStack { TheStack = new List<Dev2Decision>(), Mode = Dev2DecisionMode.OR };

            dds.AddModelItem(new Dev2Decision { Col1 = "[[Customers(1).FirstName]]", Col2 = string.Empty, Col3 = "b", EvaluationFn = enDecisionType.IsContains });

            string modelData = dds.ToVBPersistableModel();
            act.ExpressionText = string.Join("", GlobalConstants.InjectedDecisionHandler, "(\"", modelData, "\",", GlobalConstants.InjectedDecisionDataListVariable, ")");

            List<DebugItem> inRes;
            List<DebugItem> outRes;

            var result = CheckPathOperationActivityDebugInputOutput(act, ActivityStrings.DebugDataListShape,
                                                                ActivityStrings.DebugDataListWithData, out inRes, out outRes);

            // remove test datalist ;)
            DataListRemoval(result.DataListID);

            Assert.AreEqual(2, inRes.Count);
            Assert.AreEqual(3, inRes[0].FetchResultsList().Count);
            Assert.AreEqual(3, inRes[1].FetchResultsList().Count);

            Assert.AreEqual(1, outRes.Count);
            Assert.AreEqual(1, outRes[0].FetchResultsList().Count);
        }

        //2013.06.06: Ashley Lewis for PBI 9460 - Debug output for starred indexed recordsets
        [TestMethod]
        public void DecisionGetDebugInputOutputWithStarredIndexedRecordsetAndOnePopulatedColumnExpectedCorrectOutput()
        {
            DsfFlowDecisionActivity act = new DsfFlowDecisionActivity();
            Dev2DecisionStack dds = new Dev2DecisionStack { TheStack = new List<Dev2Decision>(), Mode = Dev2DecisionMode.AND, TrueArmText = "Passed Test" };

            dds.AddModelItem(new Dev2Decision { Col1 = "[[Customers(*).FirstName]]", EvaluationFn = enDecisionType.IsText });

            string modelData = dds.ToVBPersistableModel();
            act.ExpressionText = string.Join("", GlobalConstants.InjectedDecisionHandler, "(\"", modelData, "\",", GlobalConstants.InjectedDecisionDataListVariable, ")");

            List<DebugItem> inRes;
            List<DebugItem> outRes;

            var result = CheckPathOperationActivityDebugInputOutput(act, ActivityStrings.DebugDataListShape,
                                                                ActivityStrings.DebugDataListWithData, out inRes, out outRes);

            // remove test datalist ;)
            DataListRemoval(result.DataListID);

            Assert.AreEqual(2, inRes.Count);
            Assert.AreEqual(30, inRes[0].FetchResultsList().Count);
            Assert.AreEqual("Wallis", inRes[0].ResultsList[2].Value);
            Assert.AreEqual("Barney", inRes[0].ResultsList[5].Value);
            Assert.AreEqual("Trevor", inRes[0].ResultsList[8].Value);
            Assert.AreEqual("Travis", inRes[0].ResultsList[11].Value);
            Assert.AreEqual("If Wallis Is Text AND Barney Is Text AND Trevor Is Text AND Travis Is Text AND Jurie Is Text AND Bre", inRes[1].ResultsList[2].Value);

            Assert.AreEqual(1, outRes.Count);
            Assert.AreEqual(1, outRes[0].FetchResultsList().Count);
            Assert.AreEqual("Passed Test", outRes[0].ResultsList[0].Value);
        }
        [TestMethod]
        public void DecisionGetDebugInputOutputWithStarredIndexedRecordsetAndTwoPopulatedColumnsExpectedCorrectOutput()
        {
            DsfFlowDecisionActivity act = new DsfFlowDecisionActivity();
            Dev2DecisionStack dds = new Dev2DecisionStack { TheStack = new List<Dev2Decision>(), Mode = Dev2DecisionMode.OR, FalseArmText = "Passed Test" };

            dds.AddModelItem(new Dev2Decision { Col1 = "[[Customers(*).FirstName]]", Col2 = "b", EvaluationFn = enDecisionType.IsContains });

            string modelData = dds.ToVBPersistableModel();
            act.ExpressionText = string.Join("", GlobalConstants.InjectedDecisionHandler, "(\"", modelData, "\",", GlobalConstants.InjectedDecisionDataListVariable, ")");

            List<DebugItem> inRes;
            List<DebugItem> outRes;

            var result = CheckPathOperationActivityDebugInputOutput(act, ActivityStrings.DebugDataListShape,
                                                                ActivityStrings.DebugDataListWithData, out inRes, out outRes);

            // remove test datalist ;)
            DataListRemoval(result.DataListID);

            Assert.AreEqual(2, inRes.Count);
            Assert.AreEqual(30, inRes[0].FetchResultsList().Count);
            Assert.AreEqual("Wallis", inRes[0].ResultsList[2].Value);
            Assert.AreEqual("Barney", inRes[0].ResultsList[5].Value);
            Assert.AreEqual("Trevor", inRes[0].ResultsList[8].Value);
            Assert.AreEqual("Travis", inRes[0].ResultsList[11].Value);
            Assert.AreEqual("If Wallis Contains b OR Barney Contains b OR Trevor Contains b OR Travis Contains b OR Jurie Contain", inRes[1].ResultsList[2].Value);

            Assert.AreEqual(1, outRes.Count);
            Assert.AreEqual(1, outRes[0].FetchResultsList().Count);
            Assert.AreEqual("Passed Test", outRes[0].ResultsList[0].Value);
        }
        [TestMethod]
        public void DecisionGetDebugInputOutputWithTwoPopulatedColumnsAndSecondColumnIsStarredIndexedRecordsetExpectedCorrectOutput()
        {
            DsfFlowDecisionActivity act = new DsfFlowDecisionActivity();
            Dev2DecisionStack dds = new Dev2DecisionStack { TheStack = new List<Dev2Decision>(), Mode = Dev2DecisionMode.OR, FalseArmText = "Passed Test" };

            dds.AddModelItem(new Dev2Decision { Col1 = "b", Col2 = "[[Customers(*).FirstName]]", EvaluationFn = enDecisionType.IsContains });

            string modelData = dds.ToVBPersistableModel();
            act.ExpressionText = string.Join("", GlobalConstants.InjectedDecisionHandler, "(\"", modelData, "\",", GlobalConstants.InjectedDecisionDataListVariable, ")");

            List<DebugItem> inRes;
            List<DebugItem> outRes;

            var result = CheckPathOperationActivityDebugInputOutput(act, ActivityStrings.DebugDataListShape,
                                                                ActivityStrings.DebugDataListWithData, out inRes, out outRes);

            // remove test datalist ;)
            DataListRemoval(result.DataListID);

            Assert.AreEqual(2, inRes.Count);
            Assert.AreEqual(30, inRes[0].FetchResultsList().Count);
            Assert.AreEqual("Wallis", inRes[0].ResultsList[2].Value);
            Assert.AreEqual("Barney", inRes[0].ResultsList[5].Value);
            Assert.AreEqual("Trevor", inRes[0].ResultsList[8].Value);
            Assert.AreEqual("Travis", inRes[0].ResultsList[11].Value);
            Assert.AreEqual("If b Contains Wallis OR b Contains Barney OR b Contains Trevor OR b Contains Travis OR b Contains Ju", inRes[1].ResultsList[2].Value);

            Assert.AreEqual(1, outRes.Count);
            Assert.AreEqual(1, outRes[0].FetchResultsList().Count);
            Assert.AreEqual("Passed Test", outRes[0].ResultsList[0].Value);
        }

        [TestMethod]
        public void DecisionGetDebugInputOutputWithTwoPopulatedColumnsBothOfThemStarredIndexedRecordsetsExpectedCorrectOutput()
        {
            DsfFlowDecisionActivity act = new DsfFlowDecisionActivity();
            Dev2DecisionStack dds = new Dev2DecisionStack { TheStack = new List<Dev2Decision>(), Mode = Dev2DecisionMode.OR, FalseArmText = "Passed Test" };

            dds.AddModelItem(new Dev2Decision { Col1 = "[[Customers(*).FirstName]]", Col2 = "[[Customers(*).LastName]]", EvaluationFn = enDecisionType.IsEqual });

            string modelData = dds.ToVBPersistableModel();
            act.ExpressionText = string.Join("", GlobalConstants.InjectedDecisionHandler, "(\"", modelData, "\",", GlobalConstants.InjectedDecisionDataListVariable, ")");

            List<DebugItem> inRes;
            List<DebugItem> outRes;

            var result = CheckPathOperationActivityDebugInputOutput(act, ActivityStrings.DebugDataListShape,
                                                                ActivityStrings.DebugDataListWithData, out inRes, out outRes);

            // remove test datalist ;)
            DataListRemoval(result.DataListID);

            Assert.AreEqual(3, inRes.Count);
            Assert.AreEqual(30, inRes[0].FetchResultsList().Count);
            Assert.AreEqual(30, inRes[1].FetchResultsList().Count);

            Assert.AreEqual("Wallis", inRes[0].ResultsList[2].Value);
            Assert.AreEqual("Barney", inRes[0].ResultsList[5].Value);
            Assert.AreEqual("Trevor", inRes[0].ResultsList[8].Value);
            Assert.AreEqual("Travis", inRes[0].ResultsList[11].Value);

            Assert.AreEqual("Buchan", inRes[1].ResultsList[2].Value);
            Assert.AreEqual("Buchan", inRes[1].ResultsList[5].Value);
            Assert.AreEqual("Williams-Ros", inRes[1].ResultsList[8].Value);
            Assert.AreEqual("Frisigner", inRes[1].ResultsList[11].Value);

            Assert.AreEqual("If Wallis Is Equal Buchan OR Barney Is Equal Buchan OR Trevor Is Equal Williams-Ros OR Travis Is Equ", inRes[2].ResultsList[2].Value);

            Assert.AreEqual(1, outRes.Count);
            Assert.AreEqual(1, outRes[0].FetchResultsList().Count);
            Assert.AreEqual("Passed Test", outRes[0].ResultsList[0].Value);
        }

        [TestMethod]
        public void DecisionGetDebugInputOutputWithTwoStarredIndexedRecordsetsExpectedValidOutput()
        {
            DsfFlowDecisionActivity act = new DsfFlowDecisionActivity();
            Dev2DecisionStack dds = new Dev2DecisionStack { TheStack = new List<Dev2Decision>(), Mode = Dev2DecisionMode.OR, FalseArmText = "Passed Test" };

            dds.AddModelItem(new Dev2Decision { Col1 = "[[Customers(*).FirstName]]", Col2 = "[[Customers(*).LastName]]", EvaluationFn = enDecisionType.IsEqual });

            string modelData = dds.ToVBPersistableModel();
            act.ExpressionText = string.Join("", GlobalConstants.InjectedDecisionHandler, "(\"", modelData, "\",", GlobalConstants.InjectedDecisionDataListVariable, ")");

            List<DebugItem> inRes;
            List<DebugItem> outRes;

            var result = CheckPathOperationActivityDebugInputOutput(act, ActivityStrings.DebugDataListShape,
                                                                ActivityStrings.DebugDataListWithData, out inRes, out outRes);

            // remove test datalist ;)
            DataListRemoval(result.DataListID);

            Assert.AreEqual(3, inRes.Count);
            Assert.AreEqual(30, inRes[0].FetchResultsList().Count);
            Assert.AreEqual(30, inRes[1].FetchResultsList().Count);

            Assert.AreEqual("Wallis", inRes[0].ResultsList[2].Value);
            Assert.AreEqual("Barney", inRes[0].ResultsList[5].Value);
            Assert.AreEqual("Trevor", inRes[0].ResultsList[8].Value);
            Assert.AreEqual("Travis", inRes[0].ResultsList[11].Value);

            Assert.AreEqual("Buchan", inRes[1].ResultsList[2].Value);
            Assert.AreEqual("Buchan", inRes[1].ResultsList[5].Value);
            Assert.AreEqual("Williams-Ros", inRes[1].ResultsList[8].Value);
            Assert.AreEqual("Frisigner", inRes[1].ResultsList[11].Value);

            Assert.AreEqual("If Wallis Is Equal Buchan OR Barney Is Equal Buchan OR Trevor Is Equal Williams-Ros OR Travis Is Equ", inRes[2].ResultsList[2].Value);

            Assert.AreEqual(1, outRes.Count);
            Assert.AreEqual(1, outRes[0].FetchResultsList().Count);
            Assert.AreEqual("Passed Test", outRes[0].ResultsList[0].Value);
        }

        #endregion

        #endregion

        #region FlowNodeExpression

        [TestMethod]
        public void FlowNodeExpressionExpectedIsCSharpValue()
        {
            // BUG 9304 - 2013.05.08 - TWR - designer/runtime error can be removed by converting the underlying expression to a CSharpValue

            var flowNode = new TestFlowNodeActivity<string>();
            var expected = typeof(CSharpValue<string>);
            var actual = flowNode.GetTheExpression().GetType();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FlowNodeWithValidDecisionExpressionExpectedExpressionIsEvaluatedCorrectly()
        {
            // BUG 9304 - 2013.05.08 - TWR - designer/runtime error can be removed by converting the underlying expression to a CSharpValue

            const string shape = "<DataList><A/><B/><C/></DataList>";
            const string data = "<DataList><A>5</A><B>3</B><C>abc</C></DataList>";

            RunActivity(shape, data, "True", new DsfFlowDecisionActivity
            {
                ExpressionText = "Dev2.Data.Decision.Dev2DataListDecisionHandler.Instance.ExecuteDecisionStack(\"{'TheStack':[{'Col1':'[[A]]','Col2':'[[B]]','Col3':'','PopulatedColumnCount':2,'EvaluationFn':'IsGreaterThan'}],'TotalDecisions':1,'ModelName':'Dev2DecisionStack','Mode':'AND','TrueArmText':'True','FalseArmText':'False','DisplayText':'If [[A]] Is Greater Than [[B]]'}\",AmbientDataList)"
            });

            RunActivity(shape, data, "False", new VisualBasicValue<bool>
            {
                ExpressionText = "Dev2DecisionHandler.Instance.ExecuteDecisionStack(\"{!TheStack!:[{!Col1!:![[C]]!,!Col2!:!!,!Col3!:!!,!PopulatedColumnCount!:1,!EvaluationFn!:!IsNumeric!}],!TotalDecisions!:1,!Mode!:!AND!,!TrueArmText!:!True!,!FalseArmText!:!False!}\",AmbientDataList)"
            });
        }

        [TestMethod]
        public void FlowNodeWithValidSwitchExpressionExpectedExpressionIsEvaluatedCorrectly()
        {
            // BUG 9304 - 2013.05.08 - TWR - designer/runtime error can be removed by converting the underlying expression to a CSharpValue

            const string expectedValue = "5";
            const string shape = "<DataList><A/><B/><C/></DataList>";
            const string data = "<DataList><A>" + expectedValue + "</A><B>3</B><C>2</C></DataList>";

            RunActivity(shape, data, expectedValue, new DsfFlowSwitchActivity
            {
                ExpressionText = "Dev2.Data.Decision.Dev2DataListDecisionHandler.Instance.FetchSwitchData(\"[[A]]\",AmbientDataList)"
            });
        }

        #endregion

        #region DecisionFlowNodeExpressionWithNulls
        //2013.05.14: Ashley Lewis for bug 9339 - allow blanks in expression

        [TestMethod]
        public void FlowNodeWithBlankIsEqualToBlankExpectedExpressionEvaluatesToTrue()
        {
            const string dl = "<DataList></DataList>";

            RunActivity(dl, dl, "True", new DsfFlowDecisionActivity
            {
                ExpressionText = "Dev2.Data.Decision.Dev2DataListDecisionHandler.Instance.ExecuteDecisionStack(\"{'TheStack':[{'Col1':'','Col2':'','Col3':'','PopulatedColumnCount':2,'EvaluationFn':'IsEqual'}],'TotalDecisions':1,'ModelName':'Dev2DecisionStack','Mode':'AND','TrueArmText':'True','FalseArmText':'False','DisplayText':'If null Is Equal To null'}\",AmbientDataList)"
            });
        }

        [TestMethod]
        public void FlowNodeWithBlankIsBinaryExpectedExpressionEvaluatesToFalse()
        {
            const string dl = "<DataList></DataList>";

            RunActivity(dl, dl, "False", new DsfFlowDecisionActivity
            {
                ExpressionText = "Dev2.Data.Decision.Dev2DataListDecisionHandler.Instance.ExecuteDecisionStack(\"{'TheStack':[{'Col1':'','Col2':'','Col3':'','PopulatedColumnCount':2,'EvaluationFn':'IsBinary'}],'TotalDecisions':1,'ModelName':'Dev2DecisionStack','Mode':'AND','TrueArmText':'True','FalseArmText':'False','DisplayText':'If null Is Binary'}\",AmbientDataList)"
            });
        }

        [TestMethod]
        public void FlowNodeWithIsBlankAnEmailExpectedExpressionEvaluatesToFalse()
        {
            const string dl = "<DataList></DataList>";

            RunActivity(dl, dl, "False", new DsfFlowDecisionActivity
            {
                ExpressionText = "Dev2.Data.Decision.Dev2DataListDecisionHandler.Instance.ExecuteDecisionStack(\"{'TheStack':[{'Col1':'','Col2':'','Col3':'','PopulatedColumnCount':2,'EvaluationFn':'IsEmail'}],'TotalDecisions':1,'ModelName':'Dev2DecisionStack','Mode':'AND','TrueArmText':'True','FalseArmText':'False','DisplayText':'If null Is Email'}\",AmbientDataList)"
            });
        }

        [TestMethod]
        public void FlowNodeWithIsBlankGreaterThanBlankExpectedExpressionEvaluatesToFalse()
        {
            const string dl = "<DataList></DataList>";

            RunActivity(dl, dl, "False", new DsfFlowDecisionActivity
            {
                ExpressionText = "Dev2.Data.Decision.Dev2DataListDecisionHandler.Instance.ExecuteDecisionStack(\"{'TheStack':[{'Col1':'','Col2':'','Col3':'','PopulatedColumnCount':2,'EvaluationFn':'IsGreaterThan'}],'TotalDecisions':1,'ModelName':'Dev2DecisionStack','Mode':'AND','TrueArmText':'True','FalseArmText':'False','DisplayText':'If null Is Greater Than null'}\",AmbientDataList)"
            });
        }

        #endregion

        [TestMethod]
        [TestCategory("DsfFlowNodeActivity_IActivityTemplateFactory")]
        [Description("DsfFlowNodeActivity IActivityTemplateFactory implementation must return itself.")]
        [Owner("Trevor Williams-Ros")]
        public void DsfFlowNodeActivity_UnitTest_IActivityTemplateFactoryCreate_ReturnsThis()
        {
            var expected = new TestFlowNodeActivity<string>();

            var atf = expected as IActivityTemplateFactory;
            Assert.IsNotNull(atf, "DsfFlowNodeActivity does not implement interface IActivityTemplateFactory.");

            var actual = expected.Create(null);
            Assert.AreSame(expected, actual, "DsfFlowNodeActivity Create did not return itself.");
        }

        #region RunActivity

        void RunActivity<TResult>(string shape, string data, string expectedValue, Activity<TResult> activity)
        {
            const string outputResultKey = "Result";

            #region Create workflow activity

            // This setup MUST mimick the way we setup workflows - WorkflowHelper.CreateWorkflow() !!
            var flowchart = new Flowchart
            {
                StartNode = new FlowStep
                {
                    Action = new Assign<TResult>
                    {
                        To = new ArgumentReference<TResult> { ArgumentName = outputResultKey },
                        Value = new InArgument<TResult>(activity)
                    }
                }
            };
            var workflow = new DynamicActivity<TResult>
            {
                Name = new WorkflowHelper().ToNamespaceTypeString(activity.GetType()),
                Implementation = () => flowchart
            };

            new WorkflowHelper().SetProperties(workflow.Properties);
            new WorkflowHelper().SetVariables(flowchart.Variables);

            #endregion

            var dataObject = NativeActivityTest.CreateDataObject(false, false);
            var compiler = DataListFactory.CreateDataListCompiler();

            ErrorResultTO errors;
            dataObject.DataListID = compiler.ConvertTo(DataListFormat.CreateFormat(GlobalConstants._XML), data, shape, out errors);

            // we need to set this now ;)
            dataObject.ParentThreadID = 1;

            new WorkflowHelper().CompileExpressions(workflow);

            var actual = string.Empty;
            var reset = new AutoResetEvent(false);

            var inputArgs = new Dictionary<string, object> { { "AmbientDataList", new List<string> { dataObject.DataListID.ToString() } } };

            NativeActivityTest.Run(workflow, dataObject, inputArgs,
                (ex, outputs) =>
                {
                    if(ex != null)
                    {
                        reset.Set();
                        throw ex;
                    }
                    actual = outputs[outputResultKey].ToString();
                    reset.Set();
                });

            reset.WaitOne();

            // remove test datalist ;)
            DataListRemoval(dataObject.DataListID);

            Assert.AreEqual(expectedValue, actual);
        }

        #endregion
    }
}
