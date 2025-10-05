using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 fuerzaAAplicar;
    private float tiempoEntreUltimasFuerzas;
    private float tiempoIntervalo;

    private float speed;
    private IMovementStrategy movementStrategy;

    private void Start()
    {
        fuerzaAAplicar = new Vector3(0, 0, 300);
        tiempoEntreUltimasFuerzas = 0f;
        tiempoIntervalo = 2f;

        speed = 5f;

        SetMovementStrategy(new SmoothMovement());
    }

    public void SetMovementStrategy(IMovementStrategy movementStrategy)
    {
        this.movementStrategy = movementStrategy;
    }

    public void MovePlayer(float direction)
    {
        movementStrategy?.Move(transform, speed, direction);
    }

    private void FixedUpdate()
    {

        tiempoEntreUltimasFuerzas += Time.fixedDeltaTime;
        if (tiempoEntreUltimasFuerzas >= tiempoIntervalo)
        {
            var rb = gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(fuerzaAAplicar);
            }
            tiempoEntreUltimasFuerzas = 0f;
        }
    }

}