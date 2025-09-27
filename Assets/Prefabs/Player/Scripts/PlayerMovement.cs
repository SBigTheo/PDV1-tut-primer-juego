// PlayerMovement.cs
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private Vector3 fuerzaAAplicar;
    private float tiempoEntreUltimasFuerzas;
    private float tiempoIntervalo;

    private float speed;
    private IMovementStrategy movementStrategy;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        fuerzaAAplicar = new Vector3(0f, 0f, 300f);
        tiempoEntreUltimasFuerzas = 0f;
        tiempoIntervalo = 2f;

        speed = 5f;
        SetMovementStrategy(new SmoothMovement());
    }

    public void SetMovementStrategy(IMovementStrategy movementStrategy)
    {
        this.movementStrategy = movementStrategy;
    }

    private void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        if (movementStrategy != null)
            movementStrategy.Move(transform, speed);
    }

    private void FixedUpdate()
    {
        tiempoEntreUltimasFuerzas += Time.fixedDeltaTime;
        if (tiempoEntreUltimasFuerzas >= tiempoIntervalo)
        {
            rb.AddForce(fuerzaAAplicar);
            tiempoEntreUltimasFuerzas = 0f;
        }
    }
}
