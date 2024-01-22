using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FocalPointRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    private PlayerInputActions inputAction;
    private float moveDirection;

    private void Awake()
    {
        inputAction = new PlayerInputActions();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, moveDirection * rotationSpeed * Time.deltaTime);
    }

    private void OnEnable()
    {
        inputAction.Enable();
        inputAction.Player.Movement.performed += OnMovementPerformed;
        inputAction.Player.Movement.canceled += OnMovementCanceled;

    }

    private void OnDisable()
    {
        inputAction.Disable();
        inputAction.Player.Movement.performed -= OnMovementPerformed;
        inputAction.Player.Movement.performed -= OnMovementPerformed;

    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveDirection = value.ReadValue<Vector2>().x;
    }

    private void OnMovementCanceled(InputAction.CallbackContext value)
    {
        moveDirection = 0f;
    }
}
