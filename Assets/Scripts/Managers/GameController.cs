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

    public int appleCount = 0;

    public Knife currentActiveKnife;

    int m_knivesHited = 0;
    int m_knivesThrowed = 0;

    private void Start()
    {
        currentActiveKnife = currentActiveKnife = Pool.singleton.Get("knife").GetComponent<Knife>();
        currentActiveKnife.gameObject.SetActive(true);
        currentActiveKnife.gameObject.transform.position = m_KunaiStartPosition;
        currentActiveKnife.Awaking(m_KunaiPosition);

        m_Target = Instantiate(m_Target, m_TargetPosition, Quaternion.identity) as Shield;

        for(int i = 0; i < appleCount; i++)
        {
            int angle = Random.Range(0, 180);

            float x = m_TargetPosition.x + 0.35f * Mathf.Cos(angle);

            float y = m_TargetPosition.y + 0.35f * Mathf.Sin(angle);

            Vector3 applePosition = new Vector3(x, y, 0);

            Apple apple = Instantiate(m_Apple, applePosition, Quaternion.identity) as Apple;

            apple.gameObject.transform.SetParent(m_Target.transform);
        }

        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3f);

        m_Target.rotate = true;

        m_knivesHited = 0;
    }

    public void ThrowKnife()
    {
        currentActiveKnife.Throw();
        currentActiveKnife = Pool.singleton.Get("knife").GetComponent<Knife>();
        currentActiveKnife.gameObject.SetActive(true);
        currentActiveKnife.gameObject.transform.position = m_KunaiStartPosition;
        currentActiveKnife.Awaking(m_KunaiPosition);
        m_knivesThrowed++;
    }

    void Hited()
    {
        m_knivesHited++;
    }

    void GameOver()
    {
        Debug.Log("Game over!");
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
