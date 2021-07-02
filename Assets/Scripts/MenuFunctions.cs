using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public Animation cameraPan;

    public void CameraPan()
    {
        cameraPan.Play();
    }

    private void Update()
    {

    }

    IEnumerator gameover()
    {
        yield return new WaitForSeconds(10);
    }
    public void restart()
    {
        StartCoroutine(gameover());
        SceneManager.LoadScene(0);
    }
}
