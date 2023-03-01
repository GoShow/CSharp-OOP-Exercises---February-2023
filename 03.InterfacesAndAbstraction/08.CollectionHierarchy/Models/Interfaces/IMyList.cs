namespace Models.Interfaces
{
    public interface IMyList : IAddRemoveCollection
    {
        public int Used { get; }
    }
}
