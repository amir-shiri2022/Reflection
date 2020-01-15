using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection01
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public void GetFullName() { }
        private void GetId(int id,string name) { }
    }
}
