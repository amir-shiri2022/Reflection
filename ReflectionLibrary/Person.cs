namespace ReflectionLibrary
{
    public class Person<T>
    {
        public T Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class Student : Person<int>
    {
        public string University { get; set; }
        public override string ToString()
        {
            return $"university:{University}";

        }
    }
}