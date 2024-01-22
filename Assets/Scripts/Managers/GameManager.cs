using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Fields")]
    public Vector3 playerScale;
    public float playerMass, playerDrag, playerMoveForce, playerRepelForce, playerBounce;

    [Header("Scene Fields")]
    public GameObject[] waypoints;

    [Header("Debug Fields")]
    public bool debugSpawnWaves, debugSpawnPortal, debugSpawnPowerUp, debugPowerUpRepel;
    public bool switchLevels { private get; set; }
    public bool gameOver { private get; set; }
    public bool playerHasPowerUp { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void EnablePlayer()
    {

    }

    private void SwitchLevels()
    {

    }
}