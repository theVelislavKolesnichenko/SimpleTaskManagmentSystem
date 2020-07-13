namespace SimpleTaskManagmentSystem.Domain.Models.Tasks
{
    using Common;
    public class Status : Enumeration
    {
        public static readonly Status Open = new Status(1, nameof(Open));
        public static readonly Status InProgress = new Status(2, nameof(InProgress));
        public static readonly Status Closed = new Status(3, nameof(Closed));

        public Status(int value)
            : this(value, FromValue<Status>(value).Name)
        {
        }
        private Status(int value, string name)
            : base(value, name)
        {
        }

    }
}
