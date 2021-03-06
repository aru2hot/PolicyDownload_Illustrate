﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 14.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace DownloadXML_Beta
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using MainApp;
    using Models;
    using System.Diagnostics;
    using System.Threading;
    using System.Linq;

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public partial class UIMap
    {

        /// <summary>
        /// RecordedMethod1 - Use 'RecordedMethod1Params' to pass parameters into this method.
        /// </summary>
        public void RecordedMethod1()
        {

            #region Variable Declarations
            WinComboBox uIOpenComboBox = this.UIRunWindow.UIItemWindow.UIOpenComboBox;
            WinEdit uIOpenEdit = this.UIRunWindow.UIItemWindow1.UIOpenEdit;
            WinTitleBar uIWinLegacyTitleBar = this.UIWinLegacyWindow.UIWinLegacyTitleBar;
            WinMenuItem uIFindCaseMenuItem = this.UIWinLegacyWindow.UI_mainMenuStripMenuBar.UIFileMenuItem.UIFindCaseMenuItem;
            WinEdit uITextBoxSearchTermEdit = this.UIFindCaseWindow.UITextBoxSearchTermWindow.UITextBoxSearchTermEdit;
            WinButton uIOKButton = this.UIUnabletoCreateIllustWindow.UIOKWindow.UIOKButton;
            WinButton uICloseButton = this.UIFindCaseWindow.UICloseWindow.UICloseButton;
            WinTitleBar uIFindCaseTitleBar = this.UIFindCaseWindow.UIFindCaseTitleBar;

            WinComboBox uIFilenameComboBox = this.UISaveAsWindow.UIDetailsPanePane.UIFilenameComboBox;
            WinButton uISaveButton = this.UISaveAsWindow.UISaveWindow.UISaveButton;

            WinTitleBar uIUnabletoCreateIllustTitleBar = this.UIUnabletoCreateIllustWindow.UIUnabletoCreateIllustTitleBar;

           
            bool shows_validation_error = false;
            #endregion
            List<PolicyDownloadModel> Policies = new List<PolicyDownloadModel>();
            Utlities util = new Utlities();
            Policies = util.fetchPolicyNo_FromInput();

            ConfigModel config = new ConfigModel();
            config = util.Getconfig();

            string illustratedPolicyDownloadLocation;
            if(ConfigModel.iscurrentRun)
            {
                illustratedPolicyDownloadLocation = config.policyIllustratedPath_New;
            }
            else
            {
                illustratedPolicyDownloadLocation = config.policyIllustratedPath_Old;
            }
            

            //   IEnumerable<PolicyDownloadModel> result = Policies.Where(obj => obj.distribution == "BrightHouse");

            // Press keyboard shortcut keys 'Windows + r'
            Keyboard.SendKeys(this.RecordedMethod1Params.SendKeys, ModifierKeys.Windows);

            // Select 'C:\Program Files (x86)\MetLife\WinLegacy\WinLegacy.exe' in 'Open:' combo box
            uIOpenComboBox.EditableItem = this.RecordedMethod1Params.UIOpenComboBoxEditableItem;

            // Type '{Enter}' in 'Open:' text box
            Keyboard.SendKeys(uIOpenEdit, this.RecordedMethod1Params.UIOpenEditSendKeys, ModifierKeys.None);


            foreach (PolicyDownloadModel policy in Policies)
            {
                WinListItem uIItem200067024PRListItem = this.UIFindCaseWindow.UIListViewCasesWindow.UIItem200067024PRListItem_ID(policy.policyNo);
                WinMenuItem uIInforceIllustrationMenuItem = this.UIWinLegacyWindow_ID(policy.policyNo).UI_mainMenuStripMenuBar.UIReportsMenuItem_ID(policy.policyNo).UIInforceIllustrationMenuItem_ID(policy.policyNo);
                WinEdit uIAlertProtectionFailuEdit = this.UIWinLegacyWindow_ID(policy.policyNo).UIAlertProtectionFailuEdit_ID(policy.policyNo);
                // Click 'WinLegacy' title bar
                Mouse.Click(uIWinLegacyTitleBar, new Point(157, 7));

                // Click 'File' -> 'Find Case...' menu item
                Mouse.Click(uIFindCaseMenuItem, new Point(29, 7));

                // Type '200067024PR' in 'textBoxSearchTerm' text box
                uITextBoxSearchTermEdit.Text = policy.policyNo.Trim();
                try
                {
                    // Double-Click '200067024PR' list item
                    Mouse.DoubleClick(uIItem200067024PRListItem, new Point(203, 11));

                    // Click 'Reports' -> 'Inforce Illustration' menu item
                    Mouse.Click(uIInforceIllustrationMenuItem, new Point(39, 6));

                    try
                    {
                        // Click 'Alert: Protection Failure' text box
                        //  Mouse.Click(uIAlertProtectionFailuEdit, new Point(140, 201));
                        Mouse.Click(new Point(140, 201));
                        //   Mouse.Click(uIAlertProtectionFailuEdit, new Point(140, 201));

                        // Type 'Control, Shift + s' in 'Alert: Protection Failure' text box
                        Keyboard.SendKeys(uIAlertProtectionFailuEdit, this.RecordedMethod1Params.UIAlertProtectionFailuEditSendKeys, (ModifierKeys.Control | ModifierKeys.Shift));

                        // Select 'Changethename' in 'File name:' combo box
                        //  uIFilenameComboBox.EditableItem = this.RecordedMethod1Params.UIFilenameComboBoxEditableItem + policy.policyNo;
                        string filename =  policy.policyNo.Trim() + "_" + DateTime.Now.ToString().Replace('/', ' ').Replace(':', ' ').Replace(" ", "");
                        uIFilenameComboBox.EditableItem = illustratedPolicyDownloadLocation +  filename;
                        
                        // Click '&Save' button
                        Mouse.Click(uISaveButton, new Point(33, 8));
                        uIAlertProtectionFailuEdit = null;
                        if(ConfigModel.iscurrentRun)
                        {
                            policy.OlderVersionFileName = filename;
                        }
                        else

                        {
                            policy.NewVersionFileName = filename;
                        }

                        policy.status = policy.status + " Illustration of the Policy : SUCCESSFULLY DOWNLOADED AS PDF";
                    }
                    catch (Exception e)
                    {

                        // Click 'Unable to Create Illustration' title bar
                        Mouse.Click(uIUnabletoCreateIllustTitleBar, new Point(167, 9));

                        // Click 'OK' button
                        Mouse.Click(uIOKButton, new Point(16, 15));

                        // Log the error stating that the Illustration has some Validation Error messages

                        shows_validation_error = true;

                        policy.additional_Comments = "Unable to Illustrate the Policy due to Validation Error. Please Note that, only policies which do not have any validation errors would be illustrated.,";
                        policy.status = policy.status + " Illustration of the Policy : FAILED TO ILLUSTRATE DUE TO VALIDATION ERRORS";
                        
                    }
                }
                catch ( Exception es)
                {
                    policy.additional_Comments = "Policy Not present in WinLegacy App to Illustrate.";
                    policy.status = policy.status + " Illustration of the Policy : FAILED TO ILLUSTRATE AS POLICY IS NOT PRESENT IN WINLEGACY APP";

                    // Click 'Find Case' title bar
                    Mouse.Click(uIFindCaseTitleBar, new Point(386, 9));

                    // Click 'Close' button
                    Mouse.Click(uICloseButton, new Point(27, 13));
                }
                
                
            }

            bool isupdated = util.SaveLog(Policies);

            Thread.Sleep(2000);
            foreach (Process proc in Process.GetProcessesByName("WINLEGACY"))
            {
                proc.Kill();
            }
        }

        #region Properties
        public virtual RecordedMethod1Params RecordedMethod1Params
        {
            get
            {
                if ((this.mRecordedMethod1Params == null))
                {
                    this.mRecordedMethod1Params = new RecordedMethod1Params();
                }
                return this.mRecordedMethod1Params;
            }
        }

        public UIUnabletoCreateIllustWindow UIUnabletoCreateIllustWindow
        {
            get
            {
                if ((this.mUIUnabletoCreateIllustWindow == null))
                {
                    this.mUIUnabletoCreateIllustWindow = new UIUnabletoCreateIllustWindow();
                }
                return this.mUIUnabletoCreateIllustWindow;
            }
        }
        public UIRunWindow UIRunWindow
        {
            get
            {
                if ((this.mUIRunWindow == null))
                {
                    this.mUIRunWindow = new UIRunWindow();
                }
                return this.mUIRunWindow;
            }
        }

        public UIWinLegacyWindow UIWinLegacyWindow
        {
            get
            {
                if ((this.mUIWinLegacyWindow == null))
                {
                    this.mUIWinLegacyWindow = new UIWinLegacyWindow();
                }
                return this.mUIWinLegacyWindow;
            }
        }
        public UIWinLegacyWindow UIWinLegacyWindow_ID(string name)
        {

            if ((this.mUIWinLegacyWindow == null))
            {
                this.mUIWinLegacyWindow = new UIWinLegacyWindow(name);
            }
            return this.mUIWinLegacyWindow;

        }

        public UIFindCaseWindow UIFindCaseWindow
        {
            get
            {
                if ((this.mUIFindCaseWindow == null))
                {
                    this.mUIFindCaseWindow = new UIFindCaseWindow();
                }
                return this.mUIFindCaseWindow;
            }
        }

        public UISaveAsWindow UISaveAsWindow
        {
            get
            {
                if ((this.mUISaveAsWindow == null))
                {
                    this.mUISaveAsWindow = new UISaveAsWindow();
                }
                return this.mUISaveAsWindow;
            }
        }
        #endregion

        #region Fields
        private RecordedMethod1Params mRecordedMethod1Params;

        private UIRunWindow mUIRunWindow;

        private UIWinLegacyWindow mUIWinLegacyWindow;

        private UIFindCaseWindow mUIFindCaseWindow;

        private UISaveAsWindow mUISaveAsWindow;

        private UIUnabletoCreateIllustWindow mUIUnabletoCreateIllustWindow;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIOKWindow : WinWindow
    {

        public UIOKWindow(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
          ///  this.SearchProperties[WinWindow.PropertyNames.ControlId] = "2";
            this.WindowTitles.Add("Unable to Create Illustration");
            #endregion
        }

        #region Properties
        public WinButton UIOKButton
        {
            get
            {
                if ((this.mUIOKButton == null))
                {
                    this.mUIOKButton = new WinButton(this);
                    #region Search Criteria
                    this.mUIOKButton.SearchProperties[WinButton.PropertyNames.Name] = "OK";
                    this.mUIOKButton.WindowTitles.Add("Unable to Create Illustration");
                    #endregion
                }
                return this.mUIOKButton;
            }
        }
        #endregion

        #region Fields
        private WinButton mUIOKButton;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIUnabletoCreateIllustWindow : WinWindow
    {

        public UIUnabletoCreateIllustWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Unable to Create Illustration";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "#32770";
            this.WindowTitles.Add("Unable to Create Illustration");
            #endregion
        }

        #region Properties
        public WinTitleBar UIUnabletoCreateIllustTitleBar
        {
            get
            {
                if ((this.mUIUnabletoCreateIllustTitleBar == null))
                {
                    this.mUIUnabletoCreateIllustTitleBar = new WinTitleBar(this);
                    #region Search Criteria
                    this.mUIUnabletoCreateIllustTitleBar.WindowTitles.Add("Unable to Create Illustration");
                    #endregion
                }
                return this.mUIUnabletoCreateIllustTitleBar;
            }
        }

        public UIOKWindow UIOKWindow
        {
            get
            {
                if ((this.mUIOKWindow == null))
                {
                    this.mUIOKWindow = new UIOKWindow(this);
                }
                return this.mUIOKWindow;
            }
        }
        #endregion

        #region Fields
        private WinTitleBar mUIUnabletoCreateIllustTitleBar;

        private UIOKWindow mUIOKWindow;
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'RecordedMethod1'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class RecordedMethod1Params
    {

        #region Fields
        /// <summary>
        /// Press keyboard shortcut keys 'Windows + r'
        /// </summary>
        public string SendKeys = "r";

        /// <summary>
        /// Select 'C:\Program Files (x86)\MetLife\WinLegacy\WinLegacy.exe' in 'Open:' combo box
        /// </summary>
        public string UIOpenComboBoxEditableItem = "C:\\Program Files (x86)\\MetLife\\WinLegacy\\WinLegacy.exe";

        /// <summary>
        /// Type '{Enter}' in 'Open:' text box
        /// </summary>
        public string UIOpenEditSendKeys = "{Enter}";

        /// <summary>
        /// Type '200067024PR' in 'textBoxSearchTerm' text box
        /// </summary>
        public string UITextBoxSearchTermEditText = "200067024PR";

        /// <summary>
        /// Type 'Control, Shift + s' in 'Alert: Protection Failure' text box
        /// </summary>
        public string UIAlertProtectionFailuEditSendKeys = "s";

        /// <summary>
        /// Select 'Changethename' in 'File name:' combo box
        /// </summary>
        public string UIFilenameComboBoxEditableItem = "Changethename";
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIRunWindow : WinWindow
    {

        public UIRunWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Run";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "#32770";
            this.WindowTitles.Add("Run");
            #endregion
        }

        #region Properties
        public UIItemWindow UIItemWindow
        {
            get
            {
                if ((this.mUIItemWindow == null))
                {
                    this.mUIItemWindow = new UIItemWindow(this);
                }
                return this.mUIItemWindow;
            }
        }

        public UIItemWindow1 UIItemWindow1
        {
            get
            {
                if ((this.mUIItemWindow1 == null))
                {
                    this.mUIItemWindow1 = new UIItemWindow1(this);
                }
                return this.mUIItemWindow1;
            }
        }
        #endregion

        #region Fields
        private UIItemWindow mUIItemWindow;

        private UIItemWindow1 mUIItemWindow1;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIItemWindow : WinWindow
    {

        public UIItemWindow(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlId] = "12298";
            this.WindowTitles.Add("Run");
            #endregion
        }

        #region Properties
        public WinComboBox UIOpenComboBox
        {
            get
            {
                if ((this.mUIOpenComboBox == null))
                {
                    this.mUIOpenComboBox = new WinComboBox(this);
                    #region Search Criteria
                    this.mUIOpenComboBox.SearchProperties[WinComboBox.PropertyNames.Name] = "Open:";
                    this.mUIOpenComboBox.WindowTitles.Add("Run");
                    #endregion
                }
                return this.mUIOpenComboBox;
            }
        }
        #endregion

        #region Fields
        private WinComboBox mUIOpenComboBox;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIItemWindow1 : WinWindow
    {

        public UIItemWindow1(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlId] = "1001";
            this.WindowTitles.Add("Run");
            #endregion
        }

        #region Properties
        public WinEdit UIOpenEdit
        {
            get
            {
                if ((this.mUIOpenEdit == null))
                {
                    this.mUIOpenEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUIOpenEdit.SearchProperties[WinEdit.PropertyNames.Name] = "Open:";
                    this.mUIOpenEdit.WindowTitles.Add("Run");
                    #endregion
                }
                return this.mUIOpenEdit;
            }
        }
        #endregion

        #region Fields
        private WinEdit mUIOpenEdit;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIWinLegacyWindow : WinWindow
    {

        public UIWinLegacyWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "WinLegacy";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("WinLegacy");
            this.WindowTitles.Add("WinLegacy - [200067024PR   - As-Is Illustration]");
            #endregion
        }
        public UIWinLegacyWindow(string name)
        {
            #region Search Criteria
            //this.SearchProperties[WinWindow.PropertyNames.Name] = "WinLegacy - [" + name + " - As-Is Illustration]";
            this.SearchProperties[WinWindow.PropertyNames.Name] = "WinLegacy ";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            //   this.WindowTitles.Add("WinLegacy - [" + name +" - As-Is Illustration]");
            #endregion
        }

        #region Properties
        public WinTitleBar UIWinLegacyTitleBar
        {
            get
            {
                if ((this.mUIWinLegacyTitleBar == null))
                {
                    this.mUIWinLegacyTitleBar = new WinTitleBar(this);
                    #region Search Criteria
                    this.mUIWinLegacyTitleBar.WindowTitles.Add("WinLegacy");
                    #endregion
                }
                return this.mUIWinLegacyTitleBar;
            }
        }

        public UI_mainMenuStripMenuBar UI_mainMenuStripMenuBar
        {
            get
            {
                if ((this.mUI_mainMenuStripMenuBar == null))
                {
                    this.mUI_mainMenuStripMenuBar = new UI_mainMenuStripMenuBar(this);
                }
                return this.mUI_mainMenuStripMenuBar;
            }
        }
        public UI_mainMenuStripMenuBar UI_mainMenuStripMenuBar_ID(string name)
        {

            if ((this.mUI_mainMenuStripMenuBar == null))
            {
                this.mUI_mainMenuStripMenuBar = new UI_mainMenuStripMenuBar(this, name);
            }
            return this.mUI_mainMenuStripMenuBar;

        }

        public WinEdit UIAlertProtectionFailuEdit
        {
            get
            {
                if ((this.mUIAlertProtectionFailuEdit == null))
                {
                    this.mUIAlertProtectionFailuEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUIAlertProtectionFailuEdit.SearchProperties[WinEdit.PropertyNames.Name] = "Alert: Protection Failure";
                    this.mUIAlertProtectionFailuEdit.WindowTitles.Add("WinLegacy - [200067024PR   - As-Is Illustration]");
                    #endregion
                }
                return this.mUIAlertProtectionFailuEdit;
            }
        }

        public WinEdit UIAlertProtectionFailuEdit_ID(string name)
        {

            if ((this.mUIAlertProtectionFailuEdit == null))
            {
                this.mUIAlertProtectionFailuEdit = new WinEdit(this);
                #region Search Criteria
                this.mUIAlertProtectionFailuEdit.SearchProperties[WinEdit.PropertyNames.Name] = "Alert: Protection Failure";
                //      this.mUIAlertProtectionFailuEdit.WindowTitles.Add("WinLegacy - [" + name +" - As-Is Illustration]");
                #endregion
            }
            return this.mUIAlertProtectionFailuEdit;

        }
        #endregion

        #region Fields
        private WinTitleBar mUIWinLegacyTitleBar;

        private UI_mainMenuStripMenuBar mUI_mainMenuStripMenuBar;

        private WinEdit mUIAlertProtectionFailuEdit;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UI_mainMenuStripMenuBar : WinMenuBar
    {

        public UI_mainMenuStripMenuBar(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinMenu.PropertyNames.Name] = "menuStrip1";
            this.WindowTitles.Add("WinLegacy");
            this.WindowTitles.Add("WinLegacy - [200067024PR   - As-Is Illustration]");
            #endregion
        }
        public UI_mainMenuStripMenuBar(UITestControl searchLimitContainer, string name) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinMenu.PropertyNames.Name] = "menuStrip1";
            this.WindowTitles.Add("WinLegacy");
            this.WindowTitles.Add("WinLegacy - [" + name + " - As-Is Illustration]");
            #endregion
        }

        #region Properties
        public UIFileMenuItem UIFileMenuItem
        {
            get
            {
                if ((this.mUIFileMenuItem == null))
                {
                    this.mUIFileMenuItem = new UIFileMenuItem(this);
                }
                return this.mUIFileMenuItem;
            }
        }

        public UIReportsMenuItem UIReportsMenuItem
        {
            get
            {
                if ((this.mUIReportsMenuItem == null))
                {
                    this.mUIReportsMenuItem = new UIReportsMenuItem(this);
                }
                return this.mUIReportsMenuItem;
            }
        }

        public UIReportsMenuItem UIReportsMenuItem_ID(string name)
        {

            if ((this.mUIReportsMenuItem == null))
            {
                this.mUIReportsMenuItem = new UIReportsMenuItem(this, name);
            }
            return this.mUIReportsMenuItem;

        }
        #endregion

        #region Fields
        private UIFileMenuItem mUIFileMenuItem;

        private UIReportsMenuItem mUIReportsMenuItem;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIFileMenuItem : WinMenuItem
    {

        public UIFileMenuItem(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinMenuItem.PropertyNames.Name] = "File";
            this.WindowTitles.Add("WinLegacy");
            this.WindowTitles.Add("WinLegacy - [200067024PR   - As-Is Illustration]");
            #endregion
        }

        #region Properties
        public WinMenuItem UIFindCaseMenuItem
        {
            get
            {
                if ((this.mUIFindCaseMenuItem == null))
                {
                    this.mUIFindCaseMenuItem = new WinMenuItem(this);
                    #region Search Criteria
                    this.mUIFindCaseMenuItem.SearchProperties[WinMenuItem.PropertyNames.Name] = "Find Case...";
                    this.mUIFindCaseMenuItem.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    this.mUIFindCaseMenuItem.WindowTitles.Add("WinLegacy");
                    this.mUIFindCaseMenuItem.WindowTitles.Add("WinLegacy - [200067024PR   - As-Is Illustration]");
                    #endregion
                }
                return this.mUIFindCaseMenuItem;
            }
        }
        #endregion

        #region Fields
        private WinMenuItem mUIFindCaseMenuItem;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIReportsMenuItem : WinMenuItem
    {

        public UIReportsMenuItem(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinMenuItem.PropertyNames.Name] = "Reports";
            this.WindowTitles.Add("WinLegacy - [200067024PR   - As-Is Illustration]");
            #endregion
        }
        public UIReportsMenuItem(UITestControl searchLimitContainer, string name) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinMenuItem.PropertyNames.Name] = "Reports";
            //    this.WindowTitles.Add("WinLegacy - [" + name + " - As-Is Illustration]");
            #endregion
        }

        #region Properties
        public WinMenuItem UIInforceIllustrationMenuItem
        {
            get
            {
                if ((this.mUIInforceIllustrationMenuItem == null))
                {
                    this.mUIInforceIllustrationMenuItem = new WinMenuItem(this);
                    #region Search Criteria
                    this.mUIInforceIllustrationMenuItem.SearchProperties[WinMenuItem.PropertyNames.Name] = "Inforce Illustration";
                    this.mUIInforceIllustrationMenuItem.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                    this.mUIInforceIllustrationMenuItem.WindowTitles.Add("WinLegacy - [200067024PR   - As-Is Illustration]");
                    #endregion
                }
                return this.mUIInforceIllustrationMenuItem;
            }
        }

        public WinMenuItem UIInforceIllustrationMenuItem_ID(string name)
        {

            if ((this.mUIInforceIllustrationMenuItem == null))
            {
                this.mUIInforceIllustrationMenuItem = new WinMenuItem(this);
                #region Search Criteria
                this.mUIInforceIllustrationMenuItem.SearchProperties[WinMenuItem.PropertyNames.Name] = "Inforce Illustration";
                this.mUIInforceIllustrationMenuItem.SearchConfigurations.Add(SearchConfiguration.ExpandWhileSearching);
                //          this.mUIInforceIllustrationMenuItem.WindowTitles.Add("WinLegacy - [" + name + " - As-Is Illustration]");
                #endregion
            }
            return this.mUIInforceIllustrationMenuItem;

        }
        #endregion

        #region Fields
        private WinMenuItem mUIInforceIllustrationMenuItem;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIFindCaseWindow : WinWindow
    {

        public UIFindCaseWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Find Case";
            this.SearchProperties.Add(new PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Find Case");
            #endregion
        }

        #region Properties
        public UITextBoxSearchTermWindow UITextBoxSearchTermWindow
        {
            get
            {
                if ((this.mUITextBoxSearchTermWindow == null))
                {
                    this.mUITextBoxSearchTermWindow = new UITextBoxSearchTermWindow(this);
                }
                return this.mUITextBoxSearchTermWindow;
            }
        }
        public WinTitleBar UIFindCaseTitleBar
        {
            get
            {
                if ((this.mUIFindCaseTitleBar == null))
                {
                    this.mUIFindCaseTitleBar = new WinTitleBar(this);
                    #region Search Criteria
                    this.mUIFindCaseTitleBar.WindowTitles.Add("Find Case");
                    #endregion
                }
                return this.mUIFindCaseTitleBar;
            }
        }
        public UICloseWindow UICloseWindow
        {
            get
            {
                if ((this.mUICloseWindow == null))
                {
                    this.mUICloseWindow = new UICloseWindow(this);
                }
                return this.mUICloseWindow;
            }
        }
        public UIListViewCasesWindow UIListViewCasesWindow
        {
            get
            {
                if ((this.mUIListViewCasesWindow == null))
                {
                    this.mUIListViewCasesWindow = new UIListViewCasesWindow(this);
                }
                return this.mUIListViewCasesWindow;
            }
        }
        #endregion

        #region Fields
        private UITextBoxSearchTermWindow mUITextBoxSearchTermWindow;

        private UIListViewCasesWindow mUIListViewCasesWindow;

        private UICloseWindow mUICloseWindow;

        private WinTitleBar mUIFindCaseTitleBar;

        #endregion
    }
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UICloseWindow : WinWindow
    {

        public UICloseWindow(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "btnCancel";
            this.WindowTitles.Add("Find Case");
            #endregion
        }

        #region Properties
        public WinButton UICloseButton
        {
            get
            {
                if ((this.mUICloseButton == null))
                {
                    this.mUICloseButton = new WinButton(this);
                    #region Search Criteria
                    this.mUICloseButton.SearchProperties[WinButton.PropertyNames.Name] = "Close";
                    this.mUICloseButton.WindowTitles.Add("Find Case");
                    #endregion
                }
                return this.mUICloseButton;
            }
        }
        #endregion

        #region Fields
        private WinButton mUICloseButton;
        #endregion
    }
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UITextBoxSearchTermWindow : WinWindow
    {

        public UITextBoxSearchTermWindow(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "textBoxSearchTerm";
            this.WindowTitles.Add("Find Case");
            #endregion
        }

        #region Properties
        public WinEdit UITextBoxSearchTermEdit
        {
            get
            {
                if ((this.mUITextBoxSearchTermEdit == null))
                {
                    this.mUITextBoxSearchTermEdit = new WinEdit(this);
                    #region Search Criteria
                    this.mUITextBoxSearchTermEdit.WindowTitles.Add("Find Case");
                    #endregion
                }
                return this.mUITextBoxSearchTermEdit;
            }
        }
        #endregion

        #region Fields
        private WinEdit mUITextBoxSearchTermEdit;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIListViewCasesWindow : WinWindow
    {

        public UIListViewCasesWindow(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlName] = "listViewCases";
            this.WindowTitles.Add("Find Case");
            #endregion
        }

        #region Properties
        public WinListItem UIItem200067024PRListItem
        {
            get
            {
                if ((this.mUIItem200067024PRListItem == null))
                {
                    this.mUIItem200067024PRListItem = new WinListItem(this);
                    #region Search Criteria
                    this.mUIItem200067024PRListItem.SearchProperties[WinListItem.PropertyNames.Name] = "200067024PR  ";
                    this.mUIItem200067024PRListItem.WindowTitles.Add("Find Case");
                    #endregion
                }
                return this.mUIItem200067024PRListItem;
            }
        }
        public WinListItem UIItem200067024PRListItem_ID(string name)
        {

            if ((this.mUIItem200067024PRListItem == null))
            {
                this.mUIItem200067024PRListItem = new WinListItem(this);
                #region Search Criteria
                //        this.mUIItem200067024PRListItem.SearchProperties[WinListItem.PropertyNames.Name] = name;
                this.mUIItem200067024PRListItem.WindowTitles.Add("Find Case");
                #endregion
            }
            return this.mUIItem200067024PRListItem;

        }
        #endregion

        #region Fields
        private WinListItem mUIItem200067024PRListItem;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UISaveAsWindow : WinWindow
    {

        public UISaveAsWindow()
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.Name] = "Save As";
            this.SearchProperties[WinWindow.PropertyNames.ClassName] = "#32770";
            this.WindowTitles.Add("Save As");
            #endregion
        }

        #region Properties
        public UIDetailsPanePane UIDetailsPanePane
        {
            get
            {
                if ((this.mUIDetailsPanePane == null))
                {
                    this.mUIDetailsPanePane = new UIDetailsPanePane(this);
                }
                return this.mUIDetailsPanePane;
            }
        }

        public UISaveWindow UISaveWindow
        {
            get
            {
                if ((this.mUISaveWindow == null))
                {
                    this.mUISaveWindow = new UISaveWindow(this);
                }
                return this.mUISaveWindow;
            }
        }
        #endregion

        #region Fields
        private UIDetailsPanePane mUIDetailsPanePane;

        private UISaveWindow mUISaveWindow;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIDetailsPanePane : WinPane
    {

        public UIDetailsPanePane(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinControl.PropertyNames.Name] = "Details Pane";
            this.WindowTitles.Add("Save As");
            #endregion
        }

        #region Properties
        public WinComboBox UIFilenameComboBox
        {
            get
            {
                if ((this.mUIFilenameComboBox == null))
                {
                    this.mUIFilenameComboBox = new WinComboBox(this);
                    #region Search Criteria
                    this.mUIFilenameComboBox.SearchProperties[WinComboBox.PropertyNames.Name] = "File name:";
                    this.mUIFilenameComboBox.WindowTitles.Add("Save As");
                    #endregion
                }
                return this.mUIFilenameComboBox;
            }
        }
        #endregion

        #region Fields
        private WinComboBox mUIFilenameComboBox;
        #endregion
    }

    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UISaveWindow : WinWindow
    {

        public UISaveWindow(UITestControl searchLimitContainer) :
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WinWindow.PropertyNames.ControlId] = "1";
            this.WindowTitles.Add("Save As");
            #endregion
        }

        #region Properties
        public WinButton UISaveButton
        {
            get
            {
                if ((this.mUISaveButton == null))
                {
                    this.mUISaveButton = new WinButton(this);
                    #region Search Criteria
                    this.mUISaveButton.SearchProperties[WinButton.PropertyNames.Name] = "Save";
                    this.mUISaveButton.WindowTitles.Add("Save As");
                    #endregion
                }
                return this.mUISaveButton;
            }
        }
        #endregion

        #region Fields
        private WinButton mUISaveButton;
        #endregion
    }
}
