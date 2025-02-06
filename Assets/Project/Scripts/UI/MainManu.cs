using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManu : MonoBehaviour
{
    // Start is called before the first frame update
    public float n, loadingTime = 5, time;
    [SerializeField] UnityEngine.UI.Slider loadingBar;
    [SerializeField] GameObject playbuttonDisable;
    private void Update()
    {
        LoadingBar();
        QuitApplication();
    }
    void LoadingBar()
    {
        n += Time.deltaTime;
        if (n >= 1 && time <= loadingTime)
        {

            time += n;
            loadingBar.value = time;
            n = 0;
        }

        if (time >= loadingTime)
        {
            playbuttonDisable.SetActive(false);
        }
        if (time < loadingTime)
        {
            playbuttonDisable.SetActive(true);

        }
    }
    void QuitApplication()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
