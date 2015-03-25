using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnYard
{
    internal class Entity
    {
        public Guid Id { get;  set; }
        public string Name { get; set; }
    }

    internal class User : Entity
    {
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    internal class EntityRepository
    {
        public virtual Entity GetById(Guid id)
        {
            return new Entity();
        }
    }

    internal class UserRepository1 : EntityRepository
    {
        /*
            C# is not CoVariant on Return Types, so we can't define the method like so.
         *  Even though [User] can be implicitly cast to [Entity]. So we are forced to return the type as Entity which means the clients will have to down cast it or sniff it.
         *  
         * public override User GetById(Guid id)
            {
                return new User();
            }
         */
        public override Entity GetById(Guid id)
        {
            return new User();
        }

    }

    /*
        Enters Generics and Covariance
     *  We are going to make EntityRepository a generic class that requires the Entity type it intends to operate on via a generic type argument.
     *  Declaring TEntity as "out" thus covariant - We can now return the derived type.
     */

    internal interface IEntityRepository<out TEntity> where TEntity : Entity
    {
        TEntity GetById(Guid id);
    }

    internal class UserRepository : IEntityRepository<User>
    {
        public User GetById(Guid id)
        {
            return new User();
        }
    }
}
