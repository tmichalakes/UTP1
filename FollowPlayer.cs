using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Player.transform.position +
                              Player.transform.forward * DistanceBack * -1 +
                              Player.transform.up * DistanceUp +
                              Player.transform.right * DistanceRight;
        transform.LookAt(Player.transform.position);
    }

    #region properties
    public float DistanceBack = 8f;
    public float DistanceUp = 4f;
    public float DistanceRight = 0f;
    public GameObject Player;
    #endregion
}
