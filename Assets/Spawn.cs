using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Spawn : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public GameObject Barrier;
    public int playercount;
    public Text countplayer;

    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public int count = 1;
    public float targetTime = 5;
    public Vector2 barrierPos = new Vector2(1.85f, 4.6f);

    private void Start()
    {
        Vector2 randomPlayerSpawnPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Vector2 randomWeaponSpawnPosition = new Vector2(0.17f, 3.02f);
        Vector2 spawnBox = new Vector2(2.6f, 4.5f);
        PhotonNetwork.Instantiate(playerPrefab.name, randomPlayerSpawnPosition, Quaternion.identity);
        if (PhotonNetwork.IsMasterClient == true)
        {
            PhotonNetwork.Instantiate(Barrier.name, barrierPos, Quaternion.identity);
        }
        }
    private void Update()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        Debug.Log(PhotonNetwork.CurrentRoom.PlayerCount);
    }
    void SpawnBarrier()
    {
        if (count == 1)
        {
            if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            {
                if (PhotonNetwork.IsMasterClient == true)
                {
                    PhotonNetwork.Instantiate(Barrier.name, barrierPos, Quaternion.identity);
                    count++;
                }
            }
        }
    }
}