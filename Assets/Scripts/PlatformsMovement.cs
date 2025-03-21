using System;
using UnityEngine;
using UnityEngine.Events;

public class PlatformsMovement : MonoBehaviour
{
    [SerializeField]
    private float initialSpeed = 2f;
    [SerializeField]
    private float speedIncrease = 1.5f;
    [SerializeField]
    private UnityEvent<int> onScoreChanged;
    [SerializeField]
    private Dash dash;  // Referencia al componente Dash para comprobar si está activo

    private bool canMove = true;
    public bool CanMove { set => canMove = value; }

    private Vector3 startingPosition;
    private float speed;
    private float pastSpeed;
    private Vector3 movedDistance;

    public void SpeedUp(float speedMultiplier)
    {
        pastSpeed = speed;
        speed *= speedMultiplier;
    }

    public void SpeedDown()
    {
        speed = pastSpeed;
    }

    private void Start()
    {
        startingPosition = transform.position;
        speed = initialSpeed;
    }

    private void Update()
    {
        if (canMove)
        {
            MovePlatforms();
        }
    }

    private void MovePlatforms()
    {
        Vector3 distanceToMove = Vector3.left * speed * Time.deltaTime;
        transform.position += distanceToMove;
        movedDistance += distanceToMove;
        onScoreChanged?.Invoke(Math.Abs((int)movedDistance.x));
    }

    // Aumenta la velocidad de la plataforma, pero no durante el dash
    public void IncreaseSpeed()
    {
        // Solo aumenta la velocidad de las plataformas si no está en dash
        if (!dash.GetIsDashing())
        {
            speed += speedIncrease;
        }
    }

    // Detiene el movimiento
    public void StopMovement()
    {
        canMove = false;
    }

    // Inicia el movimiento
    public void StartMovement()
    {
        canMove = true;
    }

    // Reinicia la plataforma
    public void Restart()
    {
        transform.position = startingPosition;
        speed = initialSpeed;
        movedDistance = Vector3.zero;
        StartMovement();
    }

    // Aumenta la velocidad cuando la plataforma deja de ser visible en la cámara
    private void OnBecameInvisible()
    {
        IncreaseSpeed(); // Aumenta la velocidad solo si no estamos en Dash
    }
}

