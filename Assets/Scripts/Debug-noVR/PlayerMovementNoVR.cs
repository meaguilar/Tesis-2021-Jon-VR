using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementNoVR : MonoBehaviour
{
    public DebugMovement controls;
    public CharacterController controller;
    private Vector2 direction;
    private bool isMoving = false;
    private Vector2 rotation = new Vector2();

    void Awake()
    {
        controls = new DebugMovement();
        controls.Player.Movement.performed += ctx => ActivateMove(ctx.ReadValue<Vector2>());
        controls.Player.Movement.canceled += _ => CancelMove();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        MoveCamera();
    }

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }


    void MovePlayer()
    {
        if (isMoving)
        {
            
            Vector3 movement = new Vector3(direction.x, 0, direction.y);
            controller.Move(movement * Time.deltaTime * 3.14f);
        }

    }


    void MoveCamera()
    {
        Vector2 mouseVelocity = Mouse.current.delta.ReadValue() * (new Vector2(10,10));

        rotation += mouseVelocity * Time.deltaTime;
        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
    }

    void ActivateMove(Vector2 direction)
    {
        isMoving = true;
        this.direction = direction;
    }

    void CancelMove()
    {
        isMoving = false;
    }
}
