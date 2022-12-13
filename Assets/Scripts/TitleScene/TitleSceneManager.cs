using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    [SerializeField] GameObject selectStagePanel;
    [SerializeField] Animator playerAnimator;
    [SerializeField] List<Animator> kidAnimators;
    [SerializeField] float animSpeed = 1f;
    [SerializeField] float scrollSpeed = 1f;
    [SerializeField] float gobackDistance = 1f;
    [SerializeField] Transform camera;

    [SerializeField] List<BGObject > backgroundObjects;

    List<Vector3> kidsStartingPos;

    Vector3 bgForward;
    Vector3 originalCameraPos;

    private void Awake()
    {
        playerAnimator.SetTrigger("Dash");
        bgForward = - new Vector3(playerAnimator.transform.forward.x, 0, playerAnimator.transform.forward.z).normalized;
        foreach (Animator anim in kidAnimators)
            anim.SetTrigger("Follow");
        foreach (BGObject ob in backgroundObjects)
        {
            ob.GoBackVector = -bgForward * gobackDistance;
        }
        kidsStartingPos = new List<Vector3>();
        for (int i = 0; i < kidAnimators.Count; i++)
            kidsStartingPos.Add(kidAnimators[i].transform.position);
        originalCameraPos = camera.transform.position;
    }
    float eTime = 0f;
    void Update()
    {
        foreach(BGObject ob in backgroundObjects)
        {
            ob.transform.position += bgForward * scrollSpeed * animSpeed * Time.deltaTime;
        }
        eTime += Time.deltaTime;
        if (eTime > 100000)
            eTime  -= 100000;
        playerAnimator.SetFloat("Speed", animSpeed);
        float offset = Mathf.PI * 0.7f;
        for(int i=0; i<kidAnimators.Count; i++)
        {
            kidAnimators[i].SetFloat("Speed", animSpeed);
            kidAnimators[i].transform.position = kidsStartingPos[i] + Mathf.Sin(eTime + i * offset) * bgForward;
        }
        camera.transform.position = originalCameraPos + Mathf.Sin(eTime * 1.5f) * new Vector3(0, 1, 0) * 0.2f;
    }
    public void OnStartButtonClick()
    {
        selectStagePanel.SetActive(true);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}

