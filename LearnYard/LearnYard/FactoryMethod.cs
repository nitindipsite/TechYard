using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    // Abstract product type
    internal abstract class Page
    {
    }

    // Concrete product types.
    internal class IntroductionPage : Page
    {
    }

    internal class ExperiencePage : Page
    {
    }

    internal class SkillsPage : Page
    {
    }

    internal class EducationPage : Page
    {
    }

    // Abstract creator - Defines an interface for creating an object but lets subclasses decide which objects to instantiate. 
    // So Factory method defers instantiation to subclasses.
    internal abstract  class Document
    {
        public Document()
        {
            this.CreatePages();
        }

        private List<Page> _pages; 
        internal List<Page> Pages
        {
            get { return _pages; }
        }
        // Factory method - This will be overridden by derived classes. 
        public abstract void CreatePages();
    }

    // Concrete creator - Returns concrete product or products.
    internal class Resume : Document
    {
        public override void CreatePages()
        {
           Pages.Add(new ExperiencePage());
           Pages.Add(new SkillsPage());
           Pages.Add(new EducationPage());
        }
    }

    internal class CoverLetter : Document
    {
        public override void CreatePages()
        {
             Pages.Add(new IntroductionPage());
        }
    }

    internal static class TestHarness
    {
        public static void Run()
        {
            ICollection<Document> documents = new Collection<Document>();
            documents.Add(new Resume());
            documents.Add(new CoverLetter());
        }
    }
}
