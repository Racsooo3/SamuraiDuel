using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenuTransition : MonoBehaviour
{
    [SerializeField]Transform rectangleParent;
    [SerializeField] float transitionTimePerTick;

    [Header("Transition Animation")]
    [SerializeField] bool transitionAnimationOnEnterScene;

    private void Start()
    {
        rectangleParent.gameObject.SetActive(false);
        if (transitionAnimationOnEnterScene)
        {
            UnblockedTransition();
        }
    }

    public void UnblockedTransition()
    {
        // From blocked to unblocked view
        Blocked();
        TransitionStart();
    }

    public void BlockedTransition()
    {
        // From unblocked to blocked view
        Unblocked();
        TransitionReturn();
    }


    private List<Transform> GetListOfChildren(Transform parent)
    {
        List<Transform> rectangleList = new List<Transform>();
        foreach (Transform child in parent)
        {
            rectangleList.Add(child);
        }
        return rectangleList;
    }

    private void Unblocked()
    {
        rectangleParent.parent.gameObject.SetActive(true);
        rectangleParent.gameObject.SetActive(true);
        List<Transform> rectangleList = GetListOfChildren(rectangleParent);

        foreach (Transform rectangle in rectangleList)
        {
            rectangle.GetComponent<RectTransform>().localScale = new Vector3(1, 0, 1);
        }
    }

    private float Transition(float level)
    {
        List<Transform> rectangleList = GetListOfChildren(rectangleParent);

        foreach (Transform rectangle in rectangleList)
        {
            rectangle.GetComponent<RectTransform>().localScale += new Vector3(0, level, 0);
        }

        return rectangleList[0].GetComponent<RectTransform>().localScale.y;
    }

    private void TransitionStart()
    {
        rectangleParent.gameObject.SetActive(true);

        if (Transition(-0.25f) > 0)
        {
            Invoke("TransitionStart", transitionTimePerTick);
        } else
        {
            rectangleParent.gameObject.SetActive(false);
        }
    }

    private void Blocked()
    {
        rectangleParent.parent.gameObject.SetActive(true);
        rectangleParent.gameObject.SetActive(true);
        List<Transform> rectangleList = GetListOfChildren(rectangleParent);

        foreach (Transform rectangle in rectangleList)
        {
            rectangle.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    private float ReverseTransition(float level)
    {
        List<Transform> rectangleList = GetListOfChildren(rectangleParent);

        foreach (Transform rectangle in rectangleList)
        {
            rectangle.GetComponent<RectTransform>().localScale += new Vector3(0, level, 0);
        }

        return rectangleList[0].GetComponent<RectTransform>().localScale.y;
    }

    private void TransitionReturn()
    {
        if (ReverseTransition(0.25f) < 1)
        {
            Invoke("TransitionReturn", transitionTimePerTick);
        }
    }
}
