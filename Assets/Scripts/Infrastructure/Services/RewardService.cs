using Infrastructure.Services;

public interface IRewardService
{
    int HighScore { get; }
    void Init();
    void AddScore(int points);
    void SaveScore();
    void ResetCurrentScore();
}

public class RewardService : IService, IRewardService
{
    private readonly ProgressService progressService;
    
    private int currentScore;
    
    public int HighScore { get; private set; }

    public RewardService(ProgressService progressService)
    {
        this.progressService = progressService;
    }
    
    
    public void Init()
    {
        
    }

    
    public void AddScore(int points) => currentScore += points;


    public void SaveScore()
    {
        if (currentScore > progressService.PlayerData.HighScore)
        {
            progressService.PlayerData.HighScore = currentScore;
        }
    }
    

    public void ResetCurrentScore() => currentScore = 0;
}