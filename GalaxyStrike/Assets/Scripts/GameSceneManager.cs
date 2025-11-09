using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField] int reloadDelay = 2;

    public void ReloadLevel()
    {
        StartCoroutine(ReloadLevelRoutine(reloadDelay));
    }

    private IEnumerator ReloadLevelRoutine(int waitTime)
    {
        yield return new WaitForSeconds(waitTime); 
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
