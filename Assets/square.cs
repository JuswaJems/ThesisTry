using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class square : MonoBehaviour
{

    public float targetTime = 8.0f;
    public Text countTF;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Update()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            countTF.text = targetTime.ToString("F0");
            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                countTF.text = "GO!!";
                PhotonNetwork.Destroy(gameObject);
            }

        }
        else
        {
            countTF.text = "Waiting for other Players...";
        }
    }
}
