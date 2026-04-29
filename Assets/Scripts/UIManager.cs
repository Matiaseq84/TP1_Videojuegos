using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private GameObject[] hearts;

    [SerializeField] private TMP_Text stageText;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateHearts(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < lives);
        }
    }

    public void ShowStage(string message)
    {
        StartCoroutine(ShowStageRoutine(message));
    }

    IEnumerator ShowStageRoutine(string message)
    {
        stageText.gameObject.SetActive(true);
        stageText.text = message;

        yield return new WaitForSeconds(2f);

        stageText.gameObject.SetActive(false);
    }
}