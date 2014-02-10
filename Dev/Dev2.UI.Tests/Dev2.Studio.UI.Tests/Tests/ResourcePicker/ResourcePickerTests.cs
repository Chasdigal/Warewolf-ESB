﻿using System.Windows.Forms;
using Dev2.Studio.UI.Tests.Enums;
using Dev2.Studio.UI.Tests.UIMaps.Activities;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dev2.Studio.UI.Tests.Tests.ResourcePicker
{
    /// <summary>
    /// Summary description for DbServiceTests
    /// </summary>
    [CodedUITest]
    public class ResourcePickerTests : UIMapBase
    {
        #region Fields


        #endregion

        #region Setup
        [ClassInitialize]
        public static void ClassInit(TestContext tctx)
        {
            Playback.Initialize();
            Playback.PlaybackSettings.ContinueOnError = true;
            Playback.PlaybackSettings.ShouldSearchFailFast = true;
            Playback.PlaybackSettings.SmartMatchOptions = SmartMatchOptions.None;
            Playback.PlaybackSettings.MatchExactHierarchy = true;
            Playback.PlaybackSettings.DelayBetweenActions = 1;

            // make the mouse quick ;)
            Mouse.MouseMoveSpeed = 10000;
            Mouse.MouseDragSpeed = 10000;
        }

        #endregion

        #region Cleanup
        [TestCleanup]
        public void MyTestCleanup()
        {
            TabManagerUIMap.CloseAllTabs();
        }
        #endregion

        [TestMethod]
        [Owner("Massimo Guerrera")]
        [TestCategory("ResourcePickerTests_CodedUI")]
        public void ResourcePickerTests_CodedUI_DropWorkflowFromToolbox_ExpectResourcePickerToBehaveCorrectly()
        {
            DsfActivityUiMap dsfActivityUiMap = new DsfActivityUiMap();
            dsfActivityUiMap.DragToolOntoDesigner(ToolType.Workflow);

            #region Checking Ok Button enabled property

            Assert.IsFalse(ActivityDropUIMap.IsOkButtonEnabled());

            ActivityDropUIMap.SingleClickFirstWorkflow();

            Assert.IsTrue(ActivityDropUIMap.IsOkButtonEnabled());

            ActivityDropUIMap.SingleClickAFolder();

            Assert.IsFalse(ActivityDropUIMap.IsOkButtonEnabled());

            #endregion

            #region Checking the double click of a resource puts it on the design surface

            //Select a resource in the explorer view
            ActivityDropUIMap.DoubleClickAResource();

            // Check if it exists on the designer
            Assert.IsTrue(WorkflowDesignerUIMap.DoesControlExistOnWorkflowDesigner(dsfActivityUiMap.TheTab, "ServiceDesigner"));
            SendKeys.SendWait("{DELETE}");

            #endregion

            #region Checking the click of the Cacnel button doesnt Adds the resource to the design surface

            // And drag it onto the point
            dsfActivityUiMap.DragToolOntoDesigner(ToolType.Workflow);

            // Single click a folder in the tree
            ActivityDropUIMap.SingleClickFirstWorkflow();

            // Click the Ok button on the window
            ActivityDropUIMap.ClickOkButton();

            // Check if it exists on the designer
            Assert.IsFalse(WorkflowDesignerUIMap.DoesControlExistOnWorkflowDesigner(dsfActivityUiMap.TheTab, "fileTest"));

            #endregion
        }
    }
}