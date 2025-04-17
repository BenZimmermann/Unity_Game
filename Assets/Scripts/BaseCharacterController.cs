using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class BaseCharacterController : MonoBehaviour
{

    private Vector2 movementInput;
    [SerializeField] private float movementSpeed;
    [Range(0,1)][SerializeField] private float slowedFactor;
    [Range(0, 5)][SerializeField] private float fastFactor;
    private bool isSlowed;
    private bool isFast;

    private void Start()
    {
        isSlowed = false;
        isFast = false;
    }
    public void Movement(CallbackContext ctx)
    {
       movementInput = ctx.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        var actualMovementSpeed = movementSpeed;
        if (isSlowed) actualMovementSpeed *= slowedFactor;
        if (isFast) actualMovementSpeed += fastFactor;

        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * actualMovementSpeed);
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
        {
            isSlowed = true;
        }
        if (col.gameObject.CompareTag("grass"))
        {
            isFast = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
        {
            isSlowed = false;
        }
        if (col.gameObject.CompareTag("grass"))
        {
            isFast = false;
        }
    }
}
