using UnityEngine;
using Mirror;

public class NetworkManagerHaxball : NetworkManager
{

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

    public GameObject playerPrefab2;
    
    public override void OnServerAddPlayer(NetworkConnection conn)
    {

        if (numPlayers%2 == 0)
        {
            GameObject player = Instantiate(playerPrefab, new Vector2(-3f, (2.9f - (numPlayers/2)*1.25f)), Quaternion.identity);
            player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
            NetworkServer.AddPlayerForConnection(conn, player);
        } else 
        {
            GameObject player = Instantiate(playerPrefab2, new Vector2(3f, (2.9f - (numPlayers/2)*1.25f)), Quaternion.identity);
            player.name = $"{playerPrefab.name} [connId={conn.connectionId}]";
            NetworkServer.AddPlayerForConnection(conn, player);
        }

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
