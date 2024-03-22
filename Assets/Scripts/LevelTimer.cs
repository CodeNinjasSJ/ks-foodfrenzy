using UnityEngine;

public class LevelTimer : Level
{
    public int timeInSeconds;
    public int targetScore;
    public HUD hud;
    private float timer;
    private bool timeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        type = LevelType.TIMER;

        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(targetScore);
        hud.SetRemaining(string.Format("{0}:{1:00}", timeInSeconds / 60, timeInSeconds % 60));
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeOut)
        {
            timer += Time.deltaTime;

            if (timeInSeconds - timer <= 0)
            {
                if (currentScore >= targetScore)
                {
                    GameWin();
                }
                else
                {
                    GameLose();
                }

                timeOut = true;
            }
        }
        hud.SetRemaining(string.Format("{0}:{1:00}", (int)Mathf.Max((timeInSeconds - timer) / 60, 0), (int)Mathf.Max((timeInSeconds - timer) % 60, 0)));
    }
   
}
