using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    Knife m_Kunai;
    [SerializeField]
    Vector3 m_KunaiPosition;
    [SerializeField]
    Vector3 m_KunaiStartPosition;
    [SerializeField]
    Shield m_Target;
    [SerializeField]
    Vector3 m_TargetPosition;
    [SerializeField]
    Apple m_Apple;

    [SerializeField]
    GameObject m_panelGameOver;
    [SerializeField]
    GameObject m_panelPause;
    [SerializeField]
    GameObject m_panelWin;

    [SerializeField]
    ScoreManager m_scoreManager;

    public int appleCount = 0;

    public Knife currentActiveKnife;

    int m_knivesHited = 0;
    int m_knivesThrowed = 0;

    bool m_isPaused;

    private void Start()
    {
        GetNewKnife();

        m_isPaused = false;

        Time.timeScale = 1;

        m_panelGameOver.SetActive(m_isPaused);

        m_Target = Instantiate(m_Target, m_TargetPosition, Quaternion.identity) as Shield;

        for (int i = 0; i < appleCount; i++)
        {
            int angle = Random.Range(0, 180);

            float x = m_TargetPosition.x + 1.9f * Mathf.Cos(angle);

            float y = m_TargetPosition.y + 1.9f * Mathf.Sin(angle);

            Vector3 applePosition = new Vector3(x, y, 0);

            Apple apple = Instantiate(m_Apple, applePosition, Quaternion.identity) as Apple;

            apple.gameObject.transform.SetParent(m_Target.transform);
        }

        StartCoroutine(StartGame());
    }

    private void GetNewKnife()
    {
        currentActiveKnife = null;
        GameObject newKnife = Pool.singleton.Get("knife");
        
        if (newKnife != null)
        {
            currentActiveKnife = newKnife.GetComponent<Knife>();
            currentActiveKnife.gameObject.SetActive(true);
            currentActiveKnife.isActive = true;
            currentActiveKnife.gameObject.transform.position = m_KunaiStartPosition;
            currentActiveKnife.Awaking(m_KunaiPosition);
        }

    }

    IEnumerator StartGame()
    {

        yield return new WaitForSeconds(1.2f);

        m_Target.rotate = true;

        m_knivesHited = 0;
    }

    public void ThrowKnife()
    {
        currentActiveKnife.Throw();
        GetNewKnife();
        m_knivesThrowed++;
    }

    void Hited(HitType hitType)
    {
        m_knivesHited++;
        m_scoreManager.Score(hitType);
        if (m_knivesHited>= 7 && currentActiveKnife == null)
        {
            togglePause();
            m_panelWin.SetActive(m_isPaused);
        }
    }

    void GameOver()
    {
        togglePause();
        m_panelGameOver.SetActive(m_isPaused);
        Debug.Log("Game over!");
    }

    void togglePause()
    {
        m_isPaused = !m_isPaused;

        if(m_isPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void Pause()
    {
        togglePause();
        m_panelPause.SetActive(m_isPaused);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Pause();

        if (Input.GetKeyDown(KeyCode.Space))
            ThrowKnife();
    }

    private void OnEnable()
    {
        Knife.HitEvent += Hited;
        Knife.CrashEvent += GameOver;
    }

    private void OnDisable()
    {
        Knife.HitEvent -= Hited;
        Knife.CrashEvent -= GameOver;
    }

}
