using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // Composite pattern is a specialization of Decorator pattern.
    public interface IComponent
    {
        void SayMyName();
    }

    public class MenuItemComponent : IComponent
    {
        private readonly string _menuName;

        public MenuItemComponent(string menuName)
        {
            _menuName = menuName;
        }

        public void SayMyName()
        {
            Console.WriteLine(string.Format("My name is {0}", _menuName));
        }
    }

    public class MenuCompositeComponent : IComponent
    {
        private List<MenuItemComponent> children;

        public MenuCompositeComponent()
        {
            children = new List<MenuItemComponent>();
        }

        public void AddComponent(MenuItemComponent childMenuItem)
        {
            children.Add(childMenuItem);
        }

        public void RemoveComponent(MenuItemComponent childMenuItem)
        {
            children.Remove(childMenuItem);
        }

        public void SayMyName()
        {
            foreach (MenuItemComponent childMenuItem in children)
            {
                childMenuItem.SayMyName();
            }
        }

        public static void TestCompositePattern()
        {
            var menuComposite = new MenuCompositeComponent();
            menuComposite.AddComponent(new MenuItemComponent("Save"));
            menuComposite.AddComponent(new MenuItemComponent("Save As")); 
            menuComposite.AddComponent(new MenuItemComponent("Delete"));

            IComponent component = menuComposite;

            component.SayMyName();
        }
    }

    

}
