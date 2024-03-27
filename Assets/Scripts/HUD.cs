using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum LevelType
    {
        TIMER,
        OBSTACLE,
        MOVES,
    };
    public Level level;
    public GameOver gameOver;

    public Text RemainingText;
    public Text RemainingSubtext;
    public Text targetText;
    public Text targetSubText;
    public Text scoreText;

    public Image[] stars;

    private int starIndex;
    private bool isGameOver;

    private void Start()
    {
        UpdateStars();
    }
    public void UpdateStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (i == starIndex)
            {
                stars[i].enabled = true;
            } else
            {
                stars[i].enabled = false;
            }
        }
    }
    public void SetScore(int score)
    {
        scoreText.text = score.ToString();

          int visibleStar = 0;

        if (score >= level.score1Star && score < level.score2Star)
        {
            visibleStar = 1;
        }
        else if (score >= level.score2Star && score < level.score3Star)
        {
            visibleStar = 2;
        }else if (score >= level.score3Star)
        {
            visibleStar = 3;
        }

        starIndex = visibleStar;

        UpdateStars();

    }
    public void SetTarget(int target)
    {
        targetText.text = target.ToString();
    }
    public void SetRemaining(int remaining)
    {
        RemainingText.text = remaining.ToString();
    }
    public void SetRemaining(string remaining)
    {
        RemainingText.text = remaining;
    }
    public void SetLevelType(Level.LevelType type)
    {
        switch (type)
        {
            case Level.LevelType.MOVES:
                RemainingSubtext.text = "Moves Remaining";
                    targetSubText.text = "Target Score";
                    break;
            case Level.LevelType.OBSTACLE:
                RemainingSubtext.text = "Moves Remaining";
                targetSubText.text = "Dishes Remaining";
                break;
            case Level.LevelType.TIMER:
                RemainingSubtext.text = "Time Remaining";
                targetSubText.text = "Target Score";
                break;

        }
    }
    public void OnGameWin(int score)
    {
        isGameOver = true;
        gameOver.ShowWin(score, starIndex);
    }

    public void OnGameLose()
    {
        gameOver.ShowLose();
    }
}
