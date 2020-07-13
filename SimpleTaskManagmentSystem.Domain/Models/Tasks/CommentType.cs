namespace SimpleTaskManagmentSystem.Domain.Models.Tasks
{
    using Common;
    public class CommentType : Enumeration
    {
        public static readonly CommentType Comment = new CommentType(1, nameof(Comment));
        public static readonly CommentType WorkLog = new CommentType(2, nameof(WorkLog));
        public static readonly CommentType ChangeHistory = new CommentType(3, nameof(ChangeHistory));

        private CommentType(int value)
            : this(value, FromValue<Status>(value).Name)
        {
        }
        private CommentType(int value, string name)
            : base(value, name)
        {
        }
    }
}
