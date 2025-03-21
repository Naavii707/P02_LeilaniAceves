using UnityEngine;
using UnityEngine.Events;

public class Dash : MonoBehaviour
{
    [SerializeField]
    private float duration = 1.5f;
    [SerializeField]
    private UnityEvent onDash;
    [SerializeField]
    private UnityEvent onDashEnd;
    [SerializeField]
    private float inactiveDuration = 2f;

    private bool canDash = true;
    private bool isDashing;
    public bool IsDashing { get => isDashing; }

    private bool dashEnable = true;

    public void SetDashEnable(bool enabled)
    {
        dashEnable = enabled;
    }

    public void DashAction()
    {
        if (!isDashing && canDash && dashEnable)
        {
            canDash = false;
            onDash?.Invoke();
            isDashing = true;
            Invoke(nameof(StopDash), duration);
        }
    }

    private void StopDash()
    {
        onDashEnd?.Invoke();
        isDashing = false;
        Invoke(nameof(EnableDash), inactiveDuration);
    }

    private void EnableDash()
    {
        canDash = true;
    }

    // Este método permite saber si el dash está activo desde otros scripts
    public bool GetIsDashing()
    {
        return isDashing;
    }
}
