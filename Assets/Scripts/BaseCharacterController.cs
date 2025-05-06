using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class BaseCharacterController : MonoBehaviour
{

    private Vector2 movementInput;
    [SerializeField] private float movementSpeed;
    [Range(0,1)][SerializeField] private float slowedFactor;
    [Range(0, 5)][SerializeField] private float fastFactor;
    [SerializeField] private string gameSceneName;
    private Vector3Int currentPosition;
    private Vector3Int lastEncounterPosition;
    private bool isPlayerInBattle;
    private bool isSlowed;
    private bool isFast;
    private bool isTped;

    public Tilemap tilemap
    {
        get
        {
            if (m_tilemap == null) m_tilemap = FindObjectOfType<Tilemap>();
            return m_tilemap;
        }
    }
    private Tilemap m_tilemap;
    
    private void Start()
    {
        isSlowed = false;
        isFast = false;
        isTped = false;
    }
    public void Movement(CallbackContext ctx)
    {
       movementInput = ctx.ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        if (isPlayerInBattle) return;
        var actualMovementSpeed = movementSpeed;
        if (isSlowed) actualMovementSpeed *= slowedFactor;
        if (isFast) actualMovementSpeed += fastFactor;
        if (isTped) SceneManager.LoadScene(gameSceneName);
        transform.Translate(new Vector3(movementInput.x, movementInput.y, 0) * Time.deltaTime * actualMovementSpeed);
        currentPosition = tilemap.WorldToCell(transform.position);

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("FightEncounter"))
    //    {
    //        CheckForEncounter();
    //    }
    //}
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
        if (col.gameObject.CompareTag("tp"))
        {
            isTped = true;
            SceneManager.LoadScene(gameSceneName);
        }
        else if (col.gameObject.CompareTag("FightEncounter"))
        {
            if (currentPosition != lastEncounterPosition)
            {
                lastEncounterPosition = currentPosition;
                isPlayerInBattle = FightManager.instance.CheckForEncounter();
            }
        }
    }
    private void CheckForEncounter()
    {
        FightManager.instance.CheckForEncounter();
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
        if (col.gameObject.CompareTag("tp"))
        {
            isTped = false;
        }
    }
}
