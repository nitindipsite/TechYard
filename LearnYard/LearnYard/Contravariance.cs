namespace LearnYard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Contravariance
    {
    }

    internal class EntityComparer
    {
        public virtual bool CompareEntities(Entity left, Entity right)
        {
            return left.Id == right.Id;
        }
    }

    /*
     * C# is not contravariant on incoming parameters. So we can't define the method like below.
     * 
     */
    /*
    internal class UserComparer : EntityComparer
    {
        public override bool CompareEntities(User left, User right)
        {
            return base.CompareEntities(left, right);
        }
    }
     */

    internal interface IEqualityComparer<in TEntity>
        where TEntity : Entity
    {
        bool Equals(TEntity left, TEntity right);
    }

    internal class EntityEqualityComparer : IEqualityComparer<Entity>
    {
        public bool Equals(Entity left, Entity right)
        {
            return left.Id == right.Id;
        }
    }

    internal static class ContravariantTestHarness
    {
        public static bool UserCanBeComparedWithEntityComparer()
        {
            /*
             * Normally in polymorphism, more derived is assigned to less derived type and at run time, more derived type's implementation gets called.
             * See what's happening here:
             * We are creating a more specific comparer by assigning it a generic comparer, thus class hierarchies are in a sense inverted.
             */
            IEqualityComparer<User> entityComparer = new EntityEqualityComparer();
            var user1 = new User();
            var user2 = new User();
            return entityComparer.Equals(user1, user2);
        }
    }
}
