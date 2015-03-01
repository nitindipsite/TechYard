using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    interface IMyInterfaceCompression
    {
        void Compress(string targetFileName, string[] fileList);
        void Uncompress(string compressedFileName, string targetdirectoryName);
    }

    /*
     *  1. POLYMORPHISM - Different methods are called on compression object.
        IMyInterfaceCompression compression = new ZipCompression();
        compression.Compress("", null);
        compression = new RarCompression();
     *  compression.Compress("", null);

     */
    public class ZipCompression : IMyInterfaceCompression
    {
        public virtual void Compress(string targetFileName, string[] fileList)
        {
            Console.WriteLine("Zip.Compress");
        }

        public void Uncompress(string compressedFileName, string targetdirectoryName)
        {
            Console.WriteLine("Zip.Uncompress");
        }
    }

    public class RarCompression : IMyInterfaceCompression
    {
        public void Compress(string targetFileName, string[] fileList)
        {
            Console.WriteLine("Rar.Compress");
        }

        // Explicit implementation - must be invoked by casting object to interface.
        void IMyInterfaceCompression.Uncompress(string compressedFileName, string targetdirectoryName)
        {
            Console.WriteLine("Rar.Uncompress");
        }

        // Because above is an explicit implementation, we can have another method() with same name and params.
        public void Uncompress(string compressedFileName, string targetdirectoryName)
        {
            Console.WriteLine("Rar.Uncompress");
        }

    }

    public class Zip7Compression : ZipCompression
    {
        public override void Compress(string targetFileName, string[] fileList)
        {
            Console.WriteLine("Rar.Compress");
        }

        public new void Uncompress(string compressedFileName, string targetdirectoryName)
        {
            Console.WriteLine("Rar.Uncompress");

        }
    }






}
