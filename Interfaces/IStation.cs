namespace AutoFilesAcceptence.Interfaces
{

    public interface IStation
    {
        bool IsLocked { get; set; }
        void UnLock();
        void Lock();
    }
}
