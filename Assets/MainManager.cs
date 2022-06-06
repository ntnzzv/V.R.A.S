using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static MainManager Instance;
    public string PlayerAge { get; set; }
    public string AqTest { get; set; }
    public float DistanceTowardsA { get; set; }
    public float DistanceTowardsB { get; set; }
    public float DistanceFromA { get; set; }
    public float DistanceFromB { get; set; }

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void GoToScene(FadeScreen fadeScreen, int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(fadeScreen, sceneIndex));
    }
    public void GoToNextScene(FadeScreen fadeScreen)
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(GoToSceneRoutine( fadeScreen, nextSceneIndex ));
    }
    IEnumerator GoToSceneRoutine(FadeScreen fadeScreen, int sceneIndex)
    {
        fadeScreen.FadeOut();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }
}
