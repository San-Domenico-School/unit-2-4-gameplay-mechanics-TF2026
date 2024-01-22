using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private SphereCollider playerCollider;
    private Light powerUpIndicator;
    private PlayerInputActions InputAction;
    private Transform focalpoint;
    private float moveForceMagnitude;
    private float moveDirection;
    public bool hasPowerUp { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        InputAction = new PlayerInputActions();
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        playerRB = GetComponent<Rigidbody>();
        playerCollider = GetComponent<SphereCollider>();
        powerUpIndicator = GetComponent<Light>();
        playerCollider.material.bounciness = 0.0f;
        powerUpIndicator.intensity = 0.0f;
    }

    private void OnEnable()
    {
        InputAction.Enable();
        InputAction.Player.Movement.performed += OnMovementPerformed;
        InputAction.Player.Movement.canceled += OnMovementCanceled;
    }

    private void OnDisable()
    {
        InputAction.Enable();
        InputAction.Player.Movement.performed -= OnMovementPerformed;
        InputAction.Player.Movement.canceled -= OnMovementCanceled;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveDirection = value.ReadValue<Vector2>().y;
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveDirection = 0f;
    }

    private void AssignLevelValues()
    {
        transform.localScale = GameManager.Instance.playerScale;
        playerRB.mass = GameManager.Instance.playerMass;
        playerRB.drag = GameManager.Instance.playerDrag;
        moveForceMagnitude = GameManager.Instance.playerMoveForce;
        focalpoint = GameObject.Find("Focal Point").transform;
    }

    private void Move()
    {
        if (focalpoint != null)
        {
            playerRB.AddForce(focalpoint.forward.normalized * moveForceMagnitude * moveDirection);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Startup"))
        {
            collision.gameObject.tag = "Ground";
            playerCollider.material.bounciness = GameManager.Instance.playerBounce;
            AssignLevelValues();
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }

    private IEnumerator PowerUpCooldown(float cooldown)
    {
        return null;
    }
}
