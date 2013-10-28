﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using ActivityUnitTests;
using Dev2.DataList.Contract.Binary_Objects;
using Dev2.Diagnostics;
using Dev2.PathOperations;
using Microsoft.VisualStudio.TestTools.UnitTesting;using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using Unlimited.Applications.BusinessDesignStudio.Activities;
using Unlimited.Applications.BusinessDesignStudio.Activities.Utilities;

namespace Dev2.Tests.Activities.ActivityTests
{
    /// <summary>
    /// Summary description for DateTimeDifferenceTests
    /// </summary>
    [TestClass][ExcludeFromCodeCoverage]
    public class PathMoveTests : BaseActivityUnitTest
    {
        static string _tempFile;
        const string _newFileName = "MovedTempFile";

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="DsfPathMove" /> is overwrite.
        /// </summary> 
        [Inputs("Overwrite")]
        public bool Overwrite
        {
            get;
            set;
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes
        
        //
        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void MyClassCleanup()
        {
            if (_tempFile != null)
            {
                try
                {
                    File.Delete(_tempFile);
                }
                catch (Exception e)
                {
                    if (e.GetType() != typeof(FileNotFoundException))// file not found is fine cos we're deleting
                    {
                        throw;
                    }
                }

                try
                {
                    File.Delete(Path.GetTempPath() + _newFileName);
                }
                catch (Exception e)
                {
                    if (e.GetType() != typeof(FileNotFoundException))// file not found is fine cos we're deleting
                    {
                        throw;
                    }
                }
            }
        }

        #endregion

        #region Get Input/Output Tests

        [TestMethod]
        public void PathMoveActivity_GetInputs_Expected_Six_Input()
        {
            DsfPathMove testAct = new DsfPathMove();

            IBinaryDataList inputs = testAct.GetInputs();

            var res = inputs.FetchAllEntries().Count;

            // remove test datalist ;)
            DataListRemoval(inputs.UID);

            Assert.AreEqual(6,res);
        }

        [TestMethod]
        public void PathMoveActivity_GetOutputs_Expected_One_Output()
        {
            DsfPathMove testAct = new DsfPathMove();

            IBinaryDataList outputs = testAct.GetOutputs();

            var res = outputs.FetchAllEntries().Count;

            // remove test datalist ;)
            DataListRemoval(outputs.UID);

            Assert.AreEqual(1,res);
        }

        #endregion Get Input/Output Tests

        #region GetDebugInputs/Outputs

        /// <summary>
        /// Author : Massimo Guerrera Bug 8104 
        /// </summary>
        [TestMethod]
        // ReSharper disable InconsistentNaming
        public void Move_Get_Debug_Input_Output_With_Scalar_Expected_Pass()
        // ReSharper restore InconsistentNaming
        {
            List<string> fileNames = new List<string>
            {
                Path.Combine(TestContext.TestRunDirectory, "NewFileFolder\\Dev2.txt")
            };

            List<string> directoryNames = new List<string>();
            directoryNames.Add(Path.Combine(TestContext.TestRunDirectory, "NewFileFolder"));
            directoryNames.Add(Path.Combine(TestContext.TestRunDirectory, "NewFileFolder2"));

            foreach (string directoryName in directoryNames)
            {
                Directory.CreateDirectory(directoryName);
            }

            foreach (string fileName in fileNames)
            {
                File.WriteAllText(fileName, @"TestData");
            }

            DsfPathMove act = new DsfPathMove { InputPath = Path.Combine(TestContext.TestRunDirectory, "NewFileFolder", "[[CompanyName]].txt"), OutputPath = Path.Combine(TestContext.TestRunDirectory, "NewFileFolder2", "[[CompanyName]].txt"), Result = "[[res]]" };

            List<DebugItem> inRes;
            List<DebugItem> outRes;

            var result = CheckPathOperationActivityDebugInputOutput(act, ActivityStrings.DebugDataListShape,
                                                                ActivityStrings.DebugDataListWithData, out inRes, out outRes);

            // remove test datalist ;)
            DataListRemoval(result.DataListID);

            Assert.AreEqual(4, inRes.Count);
            Assert.AreEqual(4, inRes[0].FetchResultsList().Count);
            Assert.AreEqual(4, inRes[1].FetchResultsList().Count);
            Assert.AreEqual(1, inRes[2].FetchResultsList().Count);
            Assert.AreEqual(1, inRes[3].FetchResultsList().Count);            

            Assert.AreEqual(1, outRes.Count);
            Assert.AreEqual(3, outRes[0].FetchResultsList().Count);
        }

        /// <summary>
        /// Author : Massimo Guerrera Bug 8104 
        /// </summary>
        [TestMethod]
        // ReSharper disable InconsistentNaming
        public void Move_Get_Debug_Input_Output_With_Recordset_Using_Star_Notation_Expected_Pass()
        // ReSharper restore InconsistentNaming
        {
            List<string> fileNames = new List<string>();
            fileNames.Add(Path.Combine(TestContext.TestRunDirectory, "NewFileFolder", Guid.NewGuid() + ".txt"));
            fileNames.Add(Path.Combine(TestContext.TestRunDirectory, "NewFileFolder", Guid.NewGuid() + ".txt"));            

            List<string> directoryNames = new List<string>();
            directoryNames.Add(Path.Combine(TestContext.TestRunDirectory, "NewFileFolder"));
            directoryNames.Add(Path.Combine(TestContext.TestRunDirectory, "NewFileFolder2"));

            foreach (string directoryName in directoryNames)
            {
                Directory.CreateDirectory(directoryName);
            }

            foreach (string fileName in fileNames)
            {
                File.WriteAllText(fileName, @"TestData");
            }

            string dataListWithData;
            string dataListShape;

            CreateDataListWithRecsetAndCreateShape(fileNames, "FileNames", "Name", out dataListShape, out dataListWithData);

            DsfPathMove act = new DsfPathMove { InputPath = "[[FileNames(*).Name]]", OutputPath = Path.Combine(TestContext.TestRunDirectory, "NewFileFolder2", Guid.NewGuid() + ".txt"), Result = "[[res]]" };

            List<DebugItem> inRes;
            List<DebugItem> outRes;

            var result = CheckPathOperationActivityDebugInputOutput(act, dataListShape,
                                                                dataListWithData, out inRes, out outRes);

            // remove test datalist ;)
            DataListRemoval(result.DataListID);

            Assert.AreEqual(4, inRes.Count);
            Assert.AreEqual(7, inRes[0].FetchResultsList().Count);
            Assert.AreEqual(2, inRes[1].FetchResultsList().Count);
            Assert.AreEqual(1, inRes[2].FetchResultsList().Count);
            Assert.AreEqual(1, inRes[3].FetchResultsList().Count);            

            Assert.AreEqual(1, outRes.Count);
            Assert.AreEqual(3, outRes[0].FetchResultsList().Count);
        }

        #endregion

        #region Blank Output Test

        //2013.05.29: Ashley Lewis for bug 9507 - null output defaults to input
        [TestMethod]
        public void MoveFileWithBlankOutputPathExpectedDefaultstoInputPath()
        {
            _tempFile = Path.GetTempFileName();
            IActivityIOOperationsEndPoint scrEndPoint = ActivityIOFactory.CreateOperationEndPointFromIOPath(ActivityIOFactory.CreatePathFromString(_tempFile, string.Empty, null, true));
            IActivityIOOperationsEndPoint dstEndPoint = ActivityIOFactory.CreateOperationEndPointFromIOPath(ActivityIOFactory.CreatePathFromString(_newFileName, string.Empty, null, true));

            var moveTO = new Dev2CRUDOperationTO(Overwrite);
            ActivityIOFactory.CreateOperationsBroker().Move(scrEndPoint, dstEndPoint, moveTO);
            Assert.IsTrue(File.Exists(Path.GetTempPath() + _newFileName));
        }

        #endregion

        // ReSharper disable InconsistentNaming

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfPathMove_UpdateForEachInputs")]
        public void DsfPathMove_UpdateForEachInputs_NullUpdates_DoesNothing()
        {
            //------------Setup for test--------------------------
            var newGuid = Guid.NewGuid();
            var inputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]].txt");
            var outputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]]2.txt");
            var act = new DsfPathMove { InputPath = inputPath, OutputPath = outputPath, Result = "[[CompanyName]]" };

            //------------Execute Test---------------------------
            act.UpdateForEachInputs(null, null);
            //------------Assert Results-------------------------
            Assert.AreEqual(inputPath, act.InputPath);
            Assert.AreEqual(outputPath, act.OutputPath);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfPathMove_UpdateForEachInputs")]
        public void DsfPathMove_UpdateForEachInputs_MoreThan1Updates_Updates()
        {
            //------------Setup for test--------------------------
            var newGuid = Guid.NewGuid();
            var inputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]].txt");
            var outputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]]2.txt");
            var act = new DsfPathMove { InputPath = inputPath, OutputPath = outputPath, Result = "[[CompanyName]]" };

            var tuple1 = new Tuple<string, string>(outputPath, "Test");
            var tuple2 = new Tuple<string, string>(inputPath, "Test2");
            //------------Execute Test---------------------------
            act.UpdateForEachInputs(new List<Tuple<string, string>> { tuple1, tuple2 }, null);
            //------------Assert Results-------------------------
            Assert.AreEqual("Test2", act.InputPath);
            Assert.AreEqual("Test", act.OutputPath);
        }


        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfPathMove_UpdateForEachOutputs")]
        public void DsfPathMove_UpdateForEachOutputs_NullUpdates_DoesNothing()
        {
            //------------Setup for test--------------------------
            var newGuid = Guid.NewGuid();
            const string result = "[[CompanyName]]";
            var act = new DsfPathMove { InputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]].txt"), OutputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]]2.txt"), Result = result };

            act.UpdateForEachOutputs(null, null);
            //------------Assert Results-------------------------
            Assert.AreEqual(result, act.Result);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfPathMove_UpdateForEachOutputs")]
        public void DsfPathMove_UpdateForEachOutputs_MoreThan1Updates_DoesNothing()
        {
            //------------Setup for test--------------------------
            var newGuid = Guid.NewGuid();
            const string result = "[[CompanyName]]";
            var act = new DsfPathMove { InputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]].txt"), OutputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]]2.txt"), Result = result };

            var tuple1 = new Tuple<string, string>("Test", "Test");
            var tuple2 = new Tuple<string, string>("Test2", "Test2");
            //------------Execute Test---------------------------
            act.UpdateForEachOutputs(new List<Tuple<string, string>> { tuple1, tuple2 }, null);
            //------------Assert Results-------------------------
            Assert.AreEqual(result, act.Result);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfPathMove_UpdateForEachOutputs")]
        public void DsfPathMove_UpdateForEachOutputs_1Updates_UpdateResult()
        {
            //------------Setup for test--------------------------
            var newGuid = Guid.NewGuid();
            var inputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]].txt");
            var outputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]]2.txt");
            var act = new DsfPathMove { InputPath = inputPath, OutputPath = outputPath, Result = "[[CompanyName]]" };

            var tuple1 = new Tuple<string, string>("Test", "Test");
            //------------Execute Test---------------------------
            act.UpdateForEachOutputs(new List<Tuple<string, string>> { tuple1 }, null);
            //------------Assert Results-------------------------
            Assert.AreEqual("Test", act.Result);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfPathMove_GetForEachInputs")]
        public void DsfPathMove_GetForEachInputs_WhenHasExpression_ReturnsInputList()
        {
            //------------Setup for test--------------------------
            var newGuid = Guid.NewGuid();
            var inputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]].txt");
            var outputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]]2.txt");
            var act = new DsfPathMove { InputPath = inputPath, OutputPath = outputPath, Result = "[[CompanyName]]" };

            //------------Execute Test---------------------------
            var dsfForEachItems = act.GetForEachInputs();
            //------------Assert Results-------------------------
            Assert.AreEqual(2, dsfForEachItems.Count);
            Assert.AreEqual(inputPath, dsfForEachItems[0].Name);
            Assert.AreEqual(inputPath, dsfForEachItems[0].Value);
            Assert.AreEqual(outputPath, dsfForEachItems[1].Name);
            Assert.AreEqual(outputPath, dsfForEachItems[1].Value);
        }

        [TestMethod]
        [Owner("Hagashen Naidu")]
        [TestCategory("DsfPathMove_GetForEachOutputs")]
        public void DsfPathMove_GetForEachOutputs_WhenHasResult_ReturnsOutputList()
        {
            //------------Setup for test--------------------------
            var newGuid = Guid.NewGuid();
            const string result = "[[CompanyName]]";
            var act = new DsfPathMove { InputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]].txt"), OutputPath = string.Concat(TestContext.TestRunDirectory, "\\", newGuid + "[[CompanyName]]2.txt"), Result = result };

            //------------Execute Test---------------------------
            var dsfForEachItems = act.GetForEachOutputs();
            //------------Assert Results-------------------------
            Assert.AreEqual(1, dsfForEachItems.Count);
            Assert.AreEqual(result, dsfForEachItems[0].Name);
            Assert.AreEqual(result, dsfForEachItems[0].Value);
        }

    }
}
