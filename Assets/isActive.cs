using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isActive : MonoBehaviour
{
    public GameObject player;

    public void isActiveSet()
    {
        player.SetActive(true);
    }
}
