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

    private void Update()
    {
        MovePlayer();
        ChangeMovementStrategy();
    }

    public void MovePlayer()
    {
        movementStrategy?.Move(transform, speed);
    }

    private void FixedUpdate()
    {
        tiempoEntreUltimasFuerzas += Time.fixedDeltaTime;
        if (tiempoEntreUltimasFuerzas >= tiempoIntervalo)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(fuerzaAAplicar);
            tiempoEntreUltimasFuerzas = 0f;
        }
    }

    private void ChangeMovementStrategy()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetMovementStrategy(new SmoothMovement());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetMovementStrategy(new AcelerateMovement());
        }
    }
}