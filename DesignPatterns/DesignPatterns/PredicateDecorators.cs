using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public interface IPredicate
    {
        bool Test();
    }

    public class EvenDayPredicate : IPredicate
    {
        public bool Test()
        {
            return (DateTime.Now.Day%2 == 0);
        }
    }

    class PredicatedComponent : IComponent
    {
        private readonly IPredicate _predicate;
        private readonly IComponent _decoratedComponent;

        public PredicatedComponent(IComponent decoratedComponent, IPredicate predicate)
        {
            _decoratedComponent = decoratedComponent;
            _predicate = predicate;
        }


        public void SayMyName()
        {
            if (_predicate.Test())
            {
                _decoratedComponent.SayMyName();
            }
        }
    
            
        public static void TestPredicateDecorators()
        {
            IComponent component = new PredicatedComponent(new MenuItemComponent("Save"), new EvenDayPredicate());
            component.SayMyName();
        }

    }

}
