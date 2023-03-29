using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;

    private void Update()
    {
        if(player)
        {
            transform.LookAt(player);
        }
    }
}
