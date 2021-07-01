using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BowlDestuctionManager : MonoBehaviour
{
    public int RequiredDamage;

    private int DamageDealt;

    public GameObject[] Cracks;

    public float MinTimeToCreateCrack = 15;
    public float MaxTimeToCreateCrack = 45;
    
    public float MinTimeUntilCrackRemoved = 10;
    public float MaxTimeUntilCrackRemoved = 20;

    public bool doCrackCooldown = true;

    private bool isCrackActive = false;

    private float currentRandomTime = 0;

    public UnityEvent onBowlDestroyed;

    private void Awake()
    {
        currentRandomTime = Random.Range(MinTimeToCreateCrack, MaxTimeToCreateCrack);
    }

    // Update is called once per frame
    void Update()
    {
        if (doCrackCooldown)
            currentRandomTime -= Time.deltaTime;
        if (currentRandomTime <= 0)
        {
            if (isCrackActive)
            {
                DeactivateCurrentCrack();

            } 
            else
                SelectAndActivateRandomCrack();
        }
    }


    public void SelectAndActivateRandomCrack()
    {
        uint temp = (uint)Mathf.RoundToInt(Random.Range(0, Cracks.Length));
        Cracks[temp].SetActive(true);
        currentRandomTime = Random.Range(MinTimeUntilCrackRemoved, MaxTimeUntilCrackRemoved);
        isCrackActive = true;
    }

    private void DeactivateCurrentCrack()
    {
        foreach (GameObject crack in Cracks)
        {
            crack.SetActive(false);
        }
        currentRandomTime = Random.Range(MinTimeToCreateCrack, MaxTimeToCreateCrack);
        isCrackActive = false;
    }


    public void getHit()
    {
        print("Ouch, bowl got hit.");
        DamageDealt += 1;
        if (DamageDealt == RequiredDamage)
        {
            doCrackCooldown = false;
            onBowlDestroyed.Invoke();
        }
    }
}
