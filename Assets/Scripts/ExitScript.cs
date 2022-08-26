using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ExitScript : MonoBehaviour
{
    public TextMeshProUGUI moneyText;

    public GameObject tutorialManager;
    
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Character"))
        {
            if (other.GetComponent<CharacterExit>().giveMoney)
            {
                moneyText.rectTransform.DOScale(1.5f, 0.2f).SetDelay(0.5f).SetEase(Ease.OutQuad).SetLoops(2, LoopType.Yoyo);
            }

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                tutorialManager.SetActive(true);
            }
        }
    }
}
