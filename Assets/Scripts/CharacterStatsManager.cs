using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsManager : MonoBehaviour
{
    public static CharacterStatsManager instance { get; private set; }
    [SerializeField] private int Xp;
    [SerializeField] private int Level;
    [SerializeField] private int Health;
    [SerializeField] private int MaxHealth;
    private Dictionary<string, bool> equipment;
    private Dictionary<string, int> itmes;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Load()
    {
        Xp = 0;
        Level = 0;
        Health = 0;
        MaxHealth = 0;

        equipment = new Dictionary<string, bool>();
        itmes = new Dictionary<string, int>();
    }
}
