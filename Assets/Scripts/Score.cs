using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Score : MonoBehaviour
{
    private List<int> scores = new List<int>();
    private int currentScore = 0;
    [SerializeField]
    private UnityEvent<int> onScoreChanged;
    [SerializeField]
    private UnityEvent<int> onSetScore;
    [SerializeField]
    private UnityEvent<int> onSetFinalScore;

    public void Initialize()
    {
        currentScore = 0;
        scores.Clear();
    }
    public void SetScore(int score)
    {
        currentScore = score;
        onScoreChanged?.Invoke(currentScore);
    }

    public void PlayerLose()
    {
        scores.Add(currentScore);
        onSetScore?.Invoke(currentScore);
        currentScore = 0;
    }

    public void SetFinalScore()
    {
        int finalScore = 0;
        foreach (int score in scores)
        {
            finalScore += score;
        }
        onSetFinalScore?.Invoke(finalScore);
        scores.Clear();
    }



}
