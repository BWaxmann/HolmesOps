using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScreen : UiView
{
    public TMP_Text currentRound;
    public TMP_Text currentScore;

    public Highscores highScore;

    public override void Show()
    {
        base.Show();
    }
    public override void Hide()
    {
        base.Hide();
    }
    public override void Initialise()
    {
    }

    public void SetData(int round, int score)
    {
        currentRound.text = "Made it to round: " + round.ToString();
        currentScore.text = "Final Score: " + score.ToString();

        highScore.AddScore(score);
    }

    public void NextButton()
    {
        UiSystem.Show<TitleScreen>();
    }
}
