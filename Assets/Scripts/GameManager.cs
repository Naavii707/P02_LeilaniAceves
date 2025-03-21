using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private UnityEvent onGameStart;

    [SerializeField]
    private UnityEvent onRespawnGame;

    [SerializeField]
    private float secondsToRestart = 3f;

    [SerializeField]
    private UnityEvent onFinishGame;

    [SerializeField]
    private float finalSecondsToRestart;

    
    void Start()
    {
        onGameStart.Invoke();
    }

    public void RespawnGame()
    {
        Invoke("RestartGame", secondsToRestart);
    }


    public void FinishGame()
    {
        onFinishGame?.Invoke();
        Invoke("Start", finalSecondsToRestart);
        Invoke("RestartGame", finalSecondsToRestart);
        
    }

    public void RestartGame()
    {
        onRespawnGame?.Invoke();
    }
}
