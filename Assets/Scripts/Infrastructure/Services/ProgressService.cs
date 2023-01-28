namespace Infrastructure.Services
{
    public interface IProgressService
    {
        PlayerData PlayerData { get; }
    }

    public class ProgressService :  IProgressService
    {
        public PlayerData PlayerData { get; private set; }
    }
}