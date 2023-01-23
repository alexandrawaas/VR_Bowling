using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public static GameUIController instance;
    public PinDespawner pinDespawner;
    public int playerNumber = 2;
    private List<Player> players = new List<Player>();
    public Player playerPrefab;
    public Player currPlayer { get; private set; }
    private int currPlayerIndex = 0;
    
    Color currPlayerColor = new (0.12f, 0.43f, 0.62f, 0.7803922f);
    
    public int round { get; private set; } = 1;
    
    private void Awake() 
    {
        instance = this;
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < playerNumber; i++)
        {
            AddPlayer();
        }
        currPlayer = players[currPlayerIndex];
		currPlayer.SetActiveColor(currPlayerColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayer()
    {
        Player player = Instantiate(playerPrefab, new Vector3 (0, 0, 0), Quaternion.identity);
        Debug.Log(player);
        player.transform.SetParent(this.gameObject.transform, false);
        players.Add(player);
    }
    
    public void EndTurn() 
    {
        currPlayerIndex++;
        Debug.Log("Player" + (currPlayerIndex + 1));
        pinDespawner.DespawnAll();
        pinDespawner.ResetFallen();
        pinDespawner.SpawnAll();
        Pin.fallenPins = 0;
        if (currPlayerIndex > players.Count - 1) EndRound();
        currPlayer = players[currPlayerIndex];
        currPlayer.SetActiveColor(currPlayerColor);
    }
    private void EndRound() 
    {
        round++;
        currPlayerIndex = 0;
    }
}