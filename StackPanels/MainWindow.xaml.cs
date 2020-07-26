using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace StackPanels
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    // Create a StackPanel with a custom AutomationPeer, in order for 
    // it to be exposed through the Control view of the UIA tree.
    public class AccessibleStackPanel : StackPanel
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new AccessibleStackPanelAutomationPeer(this);
        }
    }

    public class AccessibleStackPanelAutomationPeer : FrameworkElementAutomationPeer
    {
        public AccessibleStackPanelAutomationPeer(AccessibleStackPanel owner) :
            base(owner)
        {
        }

        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            // This control is logically a container for a group of other control.
            return AutomationControlType.Group;
        }
    }

}
