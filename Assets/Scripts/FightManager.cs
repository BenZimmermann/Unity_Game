using UnityEngine;

public class FightManager : MonoBehaviour
{
    public static FightManager instance { get; private set; }
    [Range(0, 100), SerializeField] private int chanceToEncounter;
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public bool CheckForEncounter()
    {
        if (Random.Range(0, 100) < chanceToEncounter)
        {
            Debug.Log("start encounter");
            return true;
        }
        else {
            Debug.Log("No encounter");
            return false;
        }
    }
}