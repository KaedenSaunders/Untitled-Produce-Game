using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanObjectController : MonoBehaviour
{
    public float knifeCooldown; //how long it takes each object to respawn
    public float forkCooldown;
    public float pepperCooldown;

    private bool knifeInUse = false;
    private bool forkInUse = false;
    private bool pepperInUse = false;
    private bool handInUseP1 = false;
    private bool handInUseP2 = false;

    public GameObject knifeOnTable;
    public GameObject forkOnTable;
    public GameObject pepperOnTable;

    public GameObject knifeP1;
    public GameObject forkP1;
    public GameObject pepperP1;
    public GameObject knifeP2;
    public GameObject forkP2;
    public GameObject pepperP2;

    public KnifeAnimation knifeAnimationP1;
    public KnifeAnimation knifeAnimationP2;
    public ForkAnimation forkAnimationP1;
    public ForkAnimation forkAnimationP2;
    public AnimationActivation pepperAnimationP1;
    public AnimationActivation pepperAnimationP2;

    public void KnifeSelect(bool playerOne)
    {
        if (knifeInUse == false)
        {
            if (playerOne == true && handInUseP1 == false)
            {
                knifeInUse = true; //prevents both players getting the same obj
                handInUseP1 = true; //prevents having multiple obj in your hand
                knifeOnTable.SetActive(false); //turns off the obj on the table
                knifeP1.SetActive(true); //and activates the obj in the player's hand
            }
            if (playerOne == false && handInUseP2 == false)
            {
                knifeInUse = true;
                handInUseP2 = true;
                knifeOnTable.SetActive(false);
                knifeP2.SetActive(true);
            }

        }
    }

    public void ForkSelect(bool playerOne)
    {
        if (forkInUse == false)
        {
            if (playerOne == true && handInUseP1 == false)
            {
                forkInUse = true;
                handInUseP1 = true;
                forkOnTable.SetActive(false);
                forkP1.SetActive(true);
            }
            if (playerOne == false && handInUseP2 == false)
            {
                forkInUse = true;
                handInUseP2 = true;
                forkOnTable.SetActive(false);
                forkP2.SetActive(true);
            }

        }
    }

    public void PepperSelect(bool playerOne)
    {
        if (pepperInUse == false)
        {
            if (playerOne == true && handInUseP1 == false)
            {
                pepperInUse = true;
                handInUseP1 = true;
                pepperOnTable.SetActive(false);
                pepperP1.SetActive(true);
            }
            if (playerOne == false && handInUseP2 == false)
            {
                pepperInUse = true;
                handInUseP2 = true;
                pepperOnTable.SetActive(false);
                pepperP2.SetActive(true);
            }

        }
    }

    public void KnifeAttack(bool playerOne)
    {
        if (knifeInUse == true)
        {
            if (playerOne == true && handInUseP1 == true)
            {
                handInUseP1 = false;
                StartCoroutine(waitThenDeactive(2.5f, knifeP1, playerOne)); //timed with the anim to disapear after use
                knifeAnimationP1.PlayAnim(); //calls anim
                StartCoroutine("knifeWaitTime"); //starts cooldown
            }
            if (playerOne == false && handInUseP2 == true)
            {
                handInUseP2 = false;
                StartCoroutine(waitThenDeactive(2.5f, knifeP2, playerOne));
                knifeAnimationP2.PlayAnim();
                StartCoroutine("knifeWaitTime");
            }

        }
    }

    public void ForkAttack(bool playerOne)
    {
        if (forkInUse == true)
        {
            if (playerOne == true /*&& handInUseP1 == true*/) //weird bug where fork wouldnt not attack because handinuse was false. couldnt figure it out
            {
                handInUseP1 = false;
                StartCoroutine(waitThenDeactive(1.3f, forkP1, playerOne));
                forkAnimationP1.PlayAnim();
                StartCoroutine("forkWaitTime");
            }
            if (playerOne == false /*&& handInUseP2 == true*/)
            {
                handInUseP2 = false;
                StartCoroutine(waitThenDeactive(1.3f, forkP2, playerOne));
                forkAnimationP2.PlayAnim();
                StartCoroutine("forkWaitTime");
            }

        }
    }

    public void PepperAttack(bool playerOne)
    {
        if (pepperInUse == true)
        {
            print(handInUseP1);
            if (playerOne == true /*&& handInUseP1 == true*/)
            {
                handInUseP1 = false;
                StartCoroutine(waitThenDeactive(1.5f, pepperP1, playerOne));
                pepperAnimationP1.PlayAnim();
                StartCoroutine("pepperWaitTime");
            }
            if (playerOne == false /*&& handInUseP2 == true*/)
            {
                handInUseP2 = false;
                StartCoroutine(waitThenDeactive(1.5f, pepperP2, playerOne));
                pepperAnimationP2.PlayAnim();
                StartCoroutine("pepperWaitTime");
            }

        }
    }


    public IEnumerator waitThenDeactive(float waitTime, GameObject gameObj, bool playerOne)
    {
        yield return new WaitForSeconds(waitTime);
        gameObj.SetActive(false); //resets obj

    }

    public IEnumerator knifeWaitTime()
    {
        yield return new WaitForSeconds(knifeCooldown);
        knifeOnTable.SetActive(true);
        knifeInUse = false;
        StopCoroutine("knifeWaitTime");


    }

    public IEnumerator forkWaitTime()
    {
        yield return new WaitForSeconds(forkCooldown);
        forkOnTable.SetActive(true);
        forkInUse = false;
        StopCoroutine("forkWaitTime");

    }

    public IEnumerator pepperWaitTime()
    {
        yield return new WaitForSeconds(pepperCooldown);
        pepperOnTable.SetActive(true);
        pepperInUse = false;
        StopCoroutine("pepperWaitTime");

    }


}
