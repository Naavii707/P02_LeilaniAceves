using UnityEngine;
using UnityEngine.Events;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onStarGame;

    private void Start()
    {
        onStarGame?.Invoke();
    }

    public void ShowScreen(GameObject screen)
    {
        screen.SetActive(true);
    }

    
    public void HideScreen(GameObject screen)
    {
        screen.SetActive(false);
    }
}
