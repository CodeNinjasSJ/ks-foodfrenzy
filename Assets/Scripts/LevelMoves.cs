using System.Collections;

public class LevelMoves : Level
{
    public enum LevelType
    {
        TIMER,
        OBSTACLE,
        MOVES,
    };
    public HUD hud;

    public int numMoves;
    public int targetScore;

    private int movesUsed = 0;

    // Start is called before the first frame update.

    void Start()
    {
        hud.SetScore(currentScore);
        type = Level.LevelType.MOVES;

        hud.SetLevelType(type);
        hud.SetScore(currentScore);
        hud.SetTarget(targetScore);
        hud.SetRemaining(numMoves);
    }


    public override void OnMove()
    {
        base.OnMove();

        movesUsed++;
        hud.SetRemaining(numMoves - movesUsed);
        if(numMoves - movesUsed == 0)
        {
            if(currentScore >= targetScore)
            {
                GameWin();
            }
            else
            {
                GameLose();
            }
        }
    }
    protected override IEnumerator WaitForGridFill()
    {
        while (grid.IsFilling)
        {
            yield return 0;
        }
        if (didWin && !grid.IsFilling)
        {
            hud.OnGameWin(currentScore);
        }
        else
        {
            hud.OnGameLose();
        }
    }
    public override void OnPieceCleared(GamePiece piece)
    {
        currentScore += piece.score;
        hud.SetScore(currentScore);
    }
}
