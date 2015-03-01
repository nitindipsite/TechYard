using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IEnumerable;

namespace JunkYard.E
{
    public class Program
    {
        // This is basically a runner class, runs various classes implemented.
        public static void Main(string[] args)
        {
            //var datalist = new StoreData<int>();
            //datalist.Add(1);
            //datalist.Add(2);
            //datalist.Add(3);
            //datalist.Add(4);
            //datalist.Add(5);

            //foreach (var item in datalist)
            //{
            //    Console.WriteLine(item);
            //}

            //var datalist2 = new StoreData<string>();
            //datalist2.Add("If ");
            //datalist2.Add("Only ");
            //datalist2.Add("I ");
            //datalist2.Add("Could ");
            //datalist2.Add("***.");

            //foreach (var item in datalist2)
            //{
            //    Console.Write(item);
            //}
            //Console.ReadLine();


            A dataA = new A() { Data1 = "Hello", Data2 =  "World"};
            // Assigning like this does a "shallow copy".
            A dataB = dataA;
            dataB.Data1 = "Goodbye";
            dataB.Data2 = "City";

            A dataBDistinct = new A(dataA);
            // dataBDistinct should not be affected by changes made to dataA
            dataA.Data1 = "Hello";
            dataA.Data2 = "World";
            
            StructExample someStruct = new StructExample();
            StructExample someOtherStruct = new StructExample(1, 2);

            //FileInfo fi = new FileInfo("ads");
            //fi.Attributes = FileAttributes.ReadOnly | FileAttributes.ReadOnly;

            Type predefineAttribute = typeof (AttributeUsageAttribute);
            Type conditionalAttr = typeof(ConditionalAttribute);
            foreach (Attribute attr in  predefineAttribute.GetCustomAttributes(false))
            {
                Console.WriteLine(attr.ToString());
            }
            foreach (PropertyInfo poperty in predefineAttribute.GetProperties())
            {
                Console.WriteLine(poperty.ToString());
            }

            SomeObsoleteMethod();

            IMyInterfaceCompression compression = new ZipCompression();
            compression.Compress("", null);
            compression = new RarCompression();
            compression.Compress("", null);

            Console.WriteLine("***************Async****************");
            TestAsync();
            // Console.WriteLine("***************Async****************");

            Console.WriteLine("***************LINQ EXAMPLE ****************");
            LinqExample db = new LinqExample();
            var customers = from cust in db.Customers
                            select cust;
            db.AddCustomer(new Customer(){ Name = "NitinAr", Designation = "Technical Fellow", City = "Seattle"});
            foreach (Customer cst in customers)
            {
                Console.Write(cst.Name + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("***************LINQ EXAMPLE ****************");

            Console.WriteLine("*************** DELEGATES, LAMBDAS ****************");
            Func<int, int, bool> comparisonHandler = LessThan;
            comparisonHandler = (a, b) => a < b;
            comparisonHandler = delegate(int a, int b)
            {
                return a < b;
            };
            Console.WriteLine("***************DELEGATES, LAMBDAS****************");

            Console.WriteLine("***************vs EXPRESSIONS****************");
            // Expression tree is a collection of Data and by iterating over data, it is possible to convert
            // data to another type. 
            // Look at the different in calling ToString() on Func<> v/s Expression<>.
            Expression<Func<int, int, bool>> comparisonHandlerExpression;
            comparisonHandlerExpression = (x, y) => x < y;

            Console.WriteLine(comparisonHandler.ToString());
            Console.WriteLine(comparisonHandlerExpression.ToString());
            Console.WriteLine(comparisonHandlerExpression.Body.ToString());
            Console.WriteLine("***************vs EXPRESSIONS****************");

            CloseOverMe closeOverMe = new CloseOverMe();
            Func<int, int> incrementer =  closeOverMe.GetFuncIncrementer();
            Console.WriteLine(incrementer(3));
            Console.WriteLine(incrementer(4));

            Console.ReadLine();
        }

        [Obsolete]
        private static void SomeObsoleteMethod()
        {
        }

        public static bool LessThan(int a, int b)
        {
            return a < b;
        }

        public static async void TestAsync()
        {
            NSync asyncObject = new NSync();
            int pageLength = await asyncObject.AccessTheWebAsync();
            Console.WriteLine("Page url length is {0}", pageLength);
            Console.WriteLine("***************Async****************");
        }

    }

    public class A
    {
        public string Data1 { get; set; }
        public string Data2 { get; set; }

        public A()
        {
        }

        public A(string data1, string data2)
        {
            this.Data1 = data1;
            this.Data2 = data2;
        }

        public A(A previousAObject) : this(previousAObject.Data1, previousAObject.Data2)
        {
        }
    }


}
