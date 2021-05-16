using UnityEngine;
using Mirror;

public class NetworkManagerHaxball : NetworkManager
{
    // public Transform leftRacketSpawn;
    //public Transform rightRacketSpawn;
    [SerializeField]
    private GameObject BallPrefab;
    [SerializeField]
    private GameObject Goal_BluePrefab;
    [SerializeField]
    private GameObject Goal_RedPrefab;
    [SerializeField]
    private GameObject GameManagerPrefab;
    [SerializeField]
    private GameObject GameCanvasPrefab;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        // add player at correct spawn position
        //Transform start = numPlayers == 0 ? leftRacketSpawn : rightRacketSpawn;
        //GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        //NetworkServer.AddPlayerForConnection(conn, player);
            Transform startPos = GetStartPosition();
            GameObject player = startPos != null
                ? Instantiate(playerPrefab, startPos.position, startPos.rotation)
                : Instantiate(playerPrefab);

            // instantiating a "Player" prefab gives it the name "Player(clone)"
            // => appending the connectionId is WAY more useful for debugging!
            player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
            NetworkServer.AddPlayerForConnection(conn, player);
        
        
        // spawn ball if two players
        if (numPlayers == 1)
        {
            GameObject Ball = Instantiate(BallPrefab) as GameObject;
            NetworkServer.Spawn(Ball);

            GameObject Goal_Red = Instantiate(Goal_RedPrefab) as GameObject;
            NetworkServer.Spawn(Goal_Red);

            GameObject Goal_Blue = Instantiate(Goal_BluePrefab) as GameObject;
            NetworkServer.Spawn(Goal_Blue);

            GameObject GameManager = Instantiate(GameManagerPrefab) as GameObject;
            NetworkServer.Spawn(GameManager);

            GameObject GC = Instantiate(GameCanvasPrefab) as GameObject;
            NetworkServer.Spawn(GC);
        }
    }

    /*
    public override void OnServerDisconnect(NetworkConnection conn)
    {
        // destroy ball
        if (ball != null)
            NetworkServer.Destroy(ball);

        // call base functionality (actually destroys the player)
        base.OnServerDisconnect(conn);
    }*/
}
