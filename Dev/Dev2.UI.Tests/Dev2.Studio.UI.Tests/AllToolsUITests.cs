﻿using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;


namespace Dev2.Studio.UI.Tests
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class AllToolsUITests : UIMapBase
    {

        #region Cleanup

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

        [TestCleanup]
        public void MyTestCleanup()
        {
            TabManagerUIMap.CloseAllTabs();
        }
        #endregion

        [TestMethod]
        [TestCategory("UITest")]
        [Description("Test for 'All Tools' workflow: The workflow is openned. The icons must display. The tab must be able to close again")]
        [Owner("Ashley")]
        public void StudioTooling_StudioToolingUITest_CanToolsDisplay_IconIsVisible()
        {

            ExplorerUIMap.EnterExplorerSearchText("AllTools");

            // Open the Workflow
            ExplorerUIMap.DoubleClickOpenProject("localhost", "WORKFLOWS", "MOCAKE", "AllTools");
            UITestControl theTab = TabManagerUIMap.GetActiveTab();

            // Assert all the icons are visible
            var designer = WorkflowDesignerUIMap.GetFlowchartDesigner(theTab);
            var allTools = designer.GetChildren();

            HashSet<UITestControl> controls = new HashSet<UITestControl>();

            foreach(var child in allTools)
            {
                if(child.ControlType == "Custom" &&
                    child.ClassName != "Uia.ConnectorWithoutStartDot" &&
                    child.ClassName != "Uia.StartSymbol" &&
                    child.ClassName != "Uia.UserControl" &&
                    child.ClassName != "Uia.DsfWebPageActivityDesigner")
                {
                    //Some of the tools on the design surface are out of view, look for them...
                    if(child.BoundingRectangle.Y > 800)
                    {
                        //might already be scrolled
                        var scrollBar = WorkflowDesignerUIMap.ScrollViewer_GetScrollBar(theTab);
                        WpfControl getTop = scrollBar as WpfControl;
                        if(getTop.Top < 200)
                        {
                            //Look low
                            Mouse.StartDragging(scrollBar);
                            Mouse.StopDragging(WorkflowDesignerUIMap.ScrollViewer_GetScrollDown(theTab));
                        }
                    }
                    else
                    {
                        //might already be scrolled
                        var scrollBar = WorkflowDesignerUIMap.ScrollViewer_GetScrollBar(theTab);
                        WpfControl getTop = scrollBar as WpfControl;
                        if(getTop.Top > 200)
                        {
                            //Look high
                            Mouse.StartDragging(scrollBar);
                            Mouse.StopDragging(WorkflowDesignerUIMap.ScrollViewer_GetScrollUp(theTab));
                        }
                    }
                    Assert.IsTrue(WorkflowDesignerUIMap.IsActivityIconVisible(child), child.FriendlyName + " is missing its icon on the design surface");
                    controls.Add(child);
                }
            }

            Assert.AreEqual(25, controls.Count, "Not all tools on the alls tools text workflow can be checked for icons");

            Assert.IsTrue(true, "Studio was terminated or hung while opening and closing the all tools workflow");

        }

        [TestMethod]
        [TestCategory("UITest")]
        [Description("Test for 'All Tools' workflow: The workflow is openned. Large views can be opened and closed again")]
        [Owner("Tshepo Ntlhokoa")]
        // ReSharper disable InconsistentNaming
        public void StudioTooling_StudioToolingUITest_CanOpenLargeView_NoExceptionsThrown()
        // ReSharper restore InconsistentNaming
        {

            var toolsWithLargeView = new List<string>
                {
                    "DsfPathCopy",
                    "DsfPathCreate",
                    "DsfPathDelete",
                    "DsfWebGetRequestActivity",
                    "DsfAssignActivity",
                    "DsfPathRename",
                    "DsfSqlBulkInsertActivity",
                    "DsfPathMove",
                    "DsfFileRead",
                    "DsfFileWrite",
                    "DsfFolderRead ",
                    "DsfUnZip",
                    "DsfZip"
                };

            // Open the Explorer
            ExplorerUIMap.EnterExplorerSearchText("AllTools");

            // Open the Workflow
            ExplorerUIMap.DoubleClickOpenProject("localhost", "WORKFLOWS", "MOCAKE", "AllTools");
            UITestControl theTab = TabManagerUIMap.GetActiveTab();

            var designer = WorkflowDesignerUIMap.GetFlowchartDesigner(theTab);

            var toolsWithLargeViews = designer.GetChildren()
                                                .Where(t => toolsWithLargeView.Contains(t.FriendlyName))
                                                .ToList();

            foreach (var child in toolsWithLargeViews)
            {
                //Some of the tools on the design surface are out of view, look for them...
                WorkflowDesignerUIMap.ScrollControlIntoView(theTab, child);

                Mouse.Move(child, new Point(15, 15));
                Playback.Wait(1000);

                var toggleButton = WorkflowDesignerUIMap.Adorner_GetButton(theTab, child.FriendlyName, "Open Large View") as WpfToggleButton;
                if (toggleButton == null)
                {
                    Assert.Fail("Could not find open large view button");
                }

                Mouse.Click(toggleButton);

                toggleButton =  WorkflowDesignerUIMap.Adorner_GetButton(theTab, child.FriendlyName, "Close Large View") as WpfToggleButton;
                if (toggleButton == null)
                {
                    Assert.Fail("Could not find close large view button");
                }

                Mouse.Click(toggleButton);
            }
        }

        [TestMethod]
        [TestCategory("UITest")]
        [Description("Test for 'All Tools' workflow: The workflow is openned. Select items on grided tools. Open and close QVI. Selected items are preserved")]
        [Owner("Tshepo Ntlhokoa")]
        // ReSharper disable InconsistentNaming
        public void QuickVariableInput_GriddedToolsWithComboboxes_OpenAndCloseQVI_SelectedValueIsPreserved()
        // ReSharper restore InconsistentNaming
        {

            var gridedToolsWithComboboxes = new List<string>
                {
                    "DsfDataMergeActivity",
                    "DsfDataSplitActivity",
                    "DsfBaseConvertActivity",
                    "DsfCaseConvertActivity"
                };

            // Open the Explorer
            ExplorerUIMap.EnterExplorerSearchText("AllTools");

            // Open the Workflow
            ExplorerUIMap.DoubleClickOpenProject("localhost", "WORKFLOWS", "MOCAKE", "AllTools");
            UITestControl theTab = TabManagerUIMap.GetActiveTab();

            var designer = WorkflowDesignerUIMap.GetFlowchartDesigner(theTab);

            var toolsWithLargeViews = designer.GetChildren()
                                                .Where(t => gridedToolsWithComboboxes.Contains(t.FriendlyName))
                                                .ToList();

            foreach (var tool in toolsWithLargeViews)
            {
                //Some of the tools on the design surface are out of view, look for them...
                if (tool.BoundingRectangle.Y > 800)
                {
                    //might already be scrolled
                    var scrollBar = WorkflowDesignerUIMap.ScrollViewer_GetVerticalScrollBar(theTab);
                    WpfControl getTop = scrollBar as WpfControl;
                    if(getTop.Top < 200)
                    {
                        //Look low
                        Mouse.StartDragging(scrollBar);
                        Mouse.StopDragging(WorkflowDesignerUIMap.ScrollViewer_GetScrollDown(theTab));
                    }
                }
                else
                {
                    //might already be scrolled
                    var scrollBar = WorkflowDesignerUIMap.ScrollViewer_GetVerticalScrollBar(theTab);
                    WpfControl getTop = scrollBar as WpfControl;
                    if(getTop.Top > 200)
                    {
                        //Look high
                        Mouse.StartDragging(scrollBar);
                        Mouse.StopDragging(WorkflowDesignerUIMap.ScrollViewer_GetScrollUp(theTab));
                    }
                }
                //
                var selectedItems = SelectItemOnComboBox(tool.FriendlyName, theTab);
                //Get Mappings button
                UITestControl toggleButton = WorkflowDesignerUIMap.Adorner_GetButton(theTab, tool.FriendlyName,
                                                                                        "Open Quick Variable Input") as
                                                WpfToggleButton;
                // Click it
                Mouse.Click(toggleButton);
                //Get Mappings button
                toggleButton = WorkflowDesignerUIMap.Adorner_GetButton(theTab, tool.FriendlyName,
                                                                        "Close Quick Variable Input") as
                                WpfToggleButton;
                // Click it
                Mouse.Click(toggleButton);

                //Assert
                Assert.IsTrue(VerifySelectedItems(tool.FriendlyName, theTab, selectedItems));
            }

        }

        private List<WpfListItem> SelectItemOnComboBox(string autoId, UITestControl theTab)
        {
            var selectedItems = new List<WpfListItem>();
            WpfTable middleBox = WorkflowDesignerUIMap.AssignControl_GetSmallViewTable(theTab, autoId, 0);
            // Get the textbox
            var uiTestControlCollection = middleBox.Rows[0]
                .GetChildren()
                .SelectMany(c => c.GetChildren())
                .Where(c => c.ControlType == ControlType.ComboBox)
                .ToList();

            foreach(WpfComboBox dbDropDownControl in uiTestControlCollection)
            {
                Point pointOnDropDownControl = new Point(dbDropDownControl.BoundingRectangle.X + 25,
                                                         dbDropDownControl.BoundingRectangle.Y + 5);
                Mouse.Click(pointOnDropDownControl);
                Playback.Wait(1000);
                var comboBoxList = dbDropDownControl.Items.Select(i => i as WpfListItem).ToList();
                var selectedItem = comboBoxList[1];
                selectedItems.Add(selectedItem);
                Mouse.Click(selectedItem, new Point(5, 5));
                Playback.Wait(1000);
            }
            return selectedItems;
        }


        private bool VerifySelectedItems(string autoId, UITestControl theTab, List<WpfListItem> selectedItems)
        {
            bool isValid = false;
            WpfTable middleBox = WorkflowDesignerUIMap.AssignControl_GetSmallViewTable(theTab, autoId, 0);
            // Get the textbox
            var uiTestControlCollection = middleBox.Rows[0]
                .GetChildren()
                .SelectMany(c => c.GetChildren())
                .Where(c => c.ControlType == ControlType.ComboBox)
                .ToList();

            foreach(WpfComboBox dbDropDownControl in uiTestControlCollection)
            {
                isValid = selectedItems.Select(i => i.DisplayText).Contains(dbDropDownControl.SelectedItem);
            }

            return isValid;
        }
    }
}
