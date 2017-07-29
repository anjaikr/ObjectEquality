using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectEquality
{

    public class A
    {
        public A()
        {
            Console.WriteLine("Constructor A called");
        }
    }
    public class B : A
    {
        public B()
        {
            Console.WriteLine("Constructor B called");
        }
    }

    public class C : B
    {
        public C()
        {
            Console.WriteLine("Constructor C called");
        }
    }

    class D
    {
        static D()
        {
            Console.WriteLine("Static Constructor in D");
        }



    }


    public class Person
    {
        private string personName;

        public Person(string name)
        {
            this.personName = name;
        }

        public override string ToString()
        {
            return this.personName;
        }
    }


    // Define a value type that does not override Equals.
    public struct PersonStruct
    {
        private string personName;


        //public PersonStruct()
        //{ }

        public PersonStruct(string name)
        {
            this.personName = name;
        }

        public override string ToString()
        {
            return this.personName;
        }
    }

    class Program
    {
        static void Main()
        {
            //If the current instance is a reference type, the Equals(Object)
            //method tests for reference equality, and a call to the Equals(Object) method
            //is equivalent to a call to the ReferenceEquals method.Reference equality means

            //that the object variables that are compared refer to the same object.
            //The following example illustrates the result of such a comparison.
            //It defines a Person class, which is a reference type, and calls the Person class
            //constructor to instantiate two new Person objects, person1a and person2,
            //which have the same value.It also assigns person1a to another object variable,
            //person1b.As the output from the example shows, person1a and person1b are equal
            //because they reference the same object. However, person1a and person2 are not equal,
            //although they have the same value.

            var person1a = new Person("John");
            var person1b = person1a;
            var person2 = new Person(person1a.ToString());

            Console.WriteLine("Calling Equals:");
            Console.WriteLine("person1a and person1b: {0}", person1a.Equals(person1b));
            Console.WriteLine("person1a and person2: {0}", person1a.Equals(person2));

            Console.WriteLine("\nCasting to an Object and calling Equals:");
            Console.WriteLine("person1a and person1b: {0}", ((object)person1a).Equals((object)person1b));
            Console.WriteLine("person1a and person2: {0}", ((object)person1a).Equals((object)person2));

            //The values of the public and private fields of the two objects are equal.
            //The following example tests for value equality.It defines a Person structure,
            //which is a value type, and calls the Person class constructor to instantiate two new Person objects,
            //person1 and person2, which have the same value.As the output from the example shows,
            //although the two object variables refer to different objects, person1 and person2 are equal
            //because they have the same value for the private personName field.

            var person1struct = new PersonStruct("John");
            var person2struct = new PersonStruct("John");

            Console.WriteLine("Calling Equals:");
            Console.WriteLine(person1struct.Equals(person2struct));

            Console.WriteLine("\nCasting to an Object and calling Equals:");
            Console.WriteLine(((object)person1struct).Equals((object)person2struct));


            var objC = new C();
            var objProgram = new Program();
            objProgram.NonStaticMethod();

            D objD = new D();
            objD.ToString();


            Console.ReadLine();
        }

        public void NonStaticMethod()
        {
            Console.WriteLine("\nNon Static method called");
        }
    }
}
