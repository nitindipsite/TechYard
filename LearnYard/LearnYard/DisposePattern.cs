using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    public class DisposePattern : IDisposable
    {
        private IntPtr someIntPtr;

        public DisposePattern()
        {
            someIntPtr = IntPtr.Zero;
        }

        ~DisposePattern()
        {
           Dispose(false);
        }

        // Public availability - this allows consumers to deterministically call Dispose() 
        public void Dispose()
        {
            Dispose(true);
            // Because we have already clean up the object, we are suggesting to the compiler that it doesn't need to 
            // call finalizer on the object.
            GC.SuppressFinalize(this);
        }

        // This gets called by public Dispose() with isDisposing == true , so free up managed resources. 
        // When it gets called non deterministically from destructor, it only frees up unmanaged resources.
        protected virtual void Dispose(bool isDisposing)
        {
            // Dispose managed resources.
            if (isDisposing == true)
            {
                someIntPtr = IntPtr.Zero;
            }

            //Dispose unmanaged objects here.
        }


    }
}
