using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //coroutine is just function to delay function
            StartCoroutine(LoadNextLevel());
        }
    }

    // coroutine function should have IEnumerator return type and in the function itself it should have
    // yield return new WaitForSeconds body
    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);

        //stored index which scene is loaded.
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        // getting built setting scene number
        int countScenes = SceneManager.sceneCountInBuildSettings;

        if (nextSceneIndex == countScenes)
        {
            nextSceneIndex = 0;
        }

        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
}
