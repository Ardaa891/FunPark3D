using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Current;

    public Image blackCanvas;
    public Canvas mainCanvas;

    public GameObject lineObject;
    public GameObject circleClipper;

    public TextMeshProUGUI text1, text2;

    public Image pointerHand, pointerArrow;

    Sequence seq;

    void Start()
    {
        Current = this;
        lineObject = GameObject.FindGameObjectWithTag("LineObject");
        seq = DOTween.Sequence();
    }

    
    void Update()
    {
        
    }

    private void OnEnable()
    {
        blackCanvas.gameObject.SetActive(true);
        LevelController.Current.gameActive = false;
        TutorialTweenPartOne();
    }



    public void TutorialTweenPartOne()
    {
        // seq.Append(text1.rectTransform.DOScale(1.5f, 0.75f).SetEase(Ease.OutQuad).SetLoops(6, LoopType.Yoyo).OnComplete(()=>text2.gameObject.SetActive(true)));

        // seq.Append(text2.rectTransform.DOScale(1.75f, 0.75f).SetEase(Ease.OutQuad).SetLoops(6, LoopType.Yoyo).OnComplete(()=>pointerHand.gameObject.SetActive(true)));
        pointerHand.gameObject.SetActive(true);
        pointerHand.rectTransform.DOLocalMove(new Vector3(300f, -150f, 0), 1f).SetEase(Ease.OutQuad).SetLoops(-1, LoopType.Restart);

        lineObject.GetComponent<LineObjectScript>().enabled = true;
        circleClipper.GetComponent<RuntimeCircleClipper>().enabled = true;

    }

    private void OnDisable()
    {
        LevelController.Current.gameActive = true;
        //lineObject.GetComponent<LineObjectScript>().enabled = true;
        //circleClipper.GetComponent<RuntimeCircleClipper>().enabled = true;
    }


}
