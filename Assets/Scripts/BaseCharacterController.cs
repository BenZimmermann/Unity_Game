using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class BaseCharacterController : MonoBehaviour
{

    private Vector2 movementInput;
    [SerializeField] float movementSpeed;
    private bool isSlowed;

    private void Start()
    {
        isSlowed = false;
    }
    public void Movement(CallbackContext ctx)
    {
       movementInput = ctx.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * movementSpeed);
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
        {
            isSlowed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Swamp"))
        {
            isSlowed = false;
        }
    }
}
