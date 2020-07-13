namespace SimpleTaskManagmentSystem.Domain.Models.Tasks
{
    using Common;

    public class Type : Enumeration
    {
        public static readonly Type Task = new Type(1, nameof(Task));
        public static readonly Type Bug = new Type(2, nameof(Bug));
        public static readonly Type Improvement = new Type(3, nameof(Improvement));

        public Type(int value)
            : this(value, FromValue<Status>(value).Name)
        {
        }
        private Type(int value, string name)
            : base(value, name)
        {
        }

    }
}
