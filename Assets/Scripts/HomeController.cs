using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeController : MonoBehaviour
{
    [Header("Loading")]
    [SerializeField] private GameObject loadingPanel;
    [SerializeField] private Slider loadingSlider;

    [Header("Start")]
    [SerializeField] private GameObject startButton;

    [SerializeField] private float loadingDuration = 2f;

    private void Start()
    {
        if (startButton != null)
            startButton.SetActive(false);

        if (loadingPanel != null)
            loadingPanel.SetActive(true);

        StartCoroutine(PlayLoadingThenShowStart());
    }

    private IEnumerator PlayLoadingThenShowStart()
    {
        if (loadingSlider != null)
            loadingSlider.value = 0f;

        float elapsed = 0f;
        while (elapsed < loadingDuration)
        {
            elapsed += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsed / loadingDuration);
            if (loadingSlider != null)
                loadingSlider.value = progress;
            yield return null;
        }

        if (loadingSlider != null)
            loadingSlider.value = 1f;

        if (loadingPanel != null)
            loadingPanel.SetActive(false);

        if (startButton != null)
            startButton.SetActive(true);
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene(SceneData.GetMain());
    }
}
