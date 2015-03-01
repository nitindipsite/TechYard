using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    public interface IWidget
    {
        IWidget Parent
        {
            get;
        }
    }

    public interface IWindow : IWidget
    {

    }

    public class WidgetHarness
    {
        public IWindow FindWindow(IWidget widget)
        {
            IWindow parent = null;
            // Assigning base type to more derived type. This will thrown an exception because widget not at top level is not a window.
            parent = (IWindow) widget;
            if (parent != null)
            {
                while (parent.Parent != null)
                {
                    parent = (IWindow)parent.Parent;
                    continue;
                }
            }
            return parent;
        }

        // This is the right way to traverse up the parent hierarchy.
        // Start with a widget and the topmost widget would be an IWindow.
        public IWindow FindWindowAgain(IWidget widget)
        {
            IWidget parent = widget;
            if (parent != null)
            {
                while (parent.Parent != null)
                {
                    parent = parent.Parent;
                    continue;
                }
            }
            // Here we are assigning base type to derived type but it is guaranted to be window.
            return (IWindow)parent;
        }
    }

}
