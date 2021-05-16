using UnityEngine;
using Mirror;

public class NetworkManagerHaxball : NetworkManager
{
    // public Transform leftRacketSpawn;
    //public Transform rightRacketSpawn;
    GameObject ball;
    [SerializeField]
    private GameObject Goal_Blue;
    [SerializeField]
    private GameObject Goal_Red;

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
        if (numPlayers == 2)
        {
            ball = Instantiate(spawnPrefabs.Find(prefab => prefab.name == "Ball"));
            NetworkServer.Spawn(ball);

            GameObject Red = Instantiate(Goal_Red) as GameObject;
            NetworkServer.Spawn(Red);

            GameObject Blue = Instantiate(Goal_Blue) as GameObject;
            NetworkServer.Spawn(Blue);
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
