using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlBreaking : MonoBehaviour
{
    public void BreakBowl()
    {
        foreach (GameObject child in transform)
            child.SetActive(child.activeSelf);
    }
}
