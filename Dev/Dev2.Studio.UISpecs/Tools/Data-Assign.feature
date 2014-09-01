﻿Feature: Data-Assign
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@Assign
Scenario: AssignCheckVariableAddBadVariableLargeViewValidationErrorSmallViewNoDrillDownInForEach
	Given I have Warewolf running
	And all tabs are closed
	And I click "RIBBONNEWENDPOINT"
	And I double click "TOOLBOX,PART_SearchBox"
	And I send "Assign" to ""
	And I drag "TOOLMULTIASSIGN" onto "WORKSURFACE,StartSymbol"
	And "WORKSURFACE,Assign (1)(MultiAssignDesigner),SmallViewContent,SmallDataGrid,UI_ActivityGrid_Row_0_AutoID,UI__Row1_FieldName_AutoID" is visible within "1" seconds
	#CheckVariableAdd
	And I type "myvar" in "WORKSURFACE,Assign (1)(MultiAssignDesigner),SmallViewContent,SmallDataGrid,UI_ActivityGrid_Row_0_AutoID,UI__Row1_FieldName_AutoID"
	And I send "{TAB}" to ""
	And "VARIABLESCALAR,UI_Variable_myvar_AutoID" is visible within "1" seconds
	And I send "=[[rec(1).set]]+1" to ""
	And I send "{TAB}" to ""
	And I send "5{TAB}" to ""
	And I send "[[5]]{TAB}" to ""
	#BadVariable
	And "VARIABLESCALAR,UI_Variable_5_AutoID" is invisible within "1" seconds
	And "VARIABLERECORDSET,UI_RecordSet_rec_AutoID,UI_Field_rec().set_AutoID" is visible within "1" seconds
	#LargeView
	When I double click point "5,5" on "WORKSURFACE,Assign (2)(MultiAssignDesigner)"
	#ValidationError
	When I click "WORKSURFACE,Assign (2)(MultiAssignDesigner),DoneButton"
	Then "WORKSURFACE,UI_ErrorsTextBlock_AutoID" is visible
	When I click point "20,30" on "WORKSURFACE,UI_ErrorsTextBlock_AutoID"
	And I send "{DELETE}{DELETE}{DELETE}{DELETE}{DELETE}" to ""
	And I send "newvar{TAB}" to ""
	And I send "{DELETE}{DELETE}{DELETE}{DELETE}{DELETE}" to ""
	And I send "newvar{TAB}" to ""
	#SmallView
	Then "VARIABLESCALAR,UI_Variable_newvar_AutoID" is visible within "1" seconds
	When I click "WORKSURFACE,Assign (2)(MultiAssignDesigner),DoneButton"
	Then "WORKSURFACE,Assign (2)(MultiAssignDesigner),SmallViewContent" is visible
	#NoDrillDownInForEach [Check that after drop Start is still visible ]
	And I double click "TOOLBOX,PART_SearchBox"
	And I send "for Each" to ""
	When I drag "TOOLFOREACH" onto "WORKSURFACE,Assign (2)(MultiAssignDesigner)"
	And I drag "WORKSURFACE,Assign (2)(MultiAssignDesigner)" to point "130,80" on "WORKSURFACE,For Each(ForeachDesigner)"
	Then "WORKSURFACE,StartSymbol" is visible within "1" seconds
		