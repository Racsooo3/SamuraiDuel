using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenuTransition : MonoBehaviour
{
    [SerializeField]Transform rectangleParent;
    [SerializeField] float transitionTimePerTick;

    private void Start()
    {
        TransitionReturn();
        //TransitionStart();
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

    private float Transition(float level)
    {
        List<Transform> rectangleList = GetListOfChildren(rectangleParent);

        foreach (Transform rectangle in rectangleList)
        {
            rectangle.GetComponent<RectTransform>().localScale += new Vector3(0, level, 0);
        }

        return rectangleList[0].GetComponent<RectTransform>().localScale.y;
    }

    public void TransitionStart()
    {
        List<Transform> rectangleList = GetListOfChildren(rectangleParent);

        foreach (Transform rectangle in rectangleList)
        {
            rectangle.GetComponent<RectTransform>().localScale = new Vector3(0, 0, 0);
        }

        rectangleParent.gameObject.SetActive(true);
        if (Transition(-0.25f) > 0)
        {
            Invoke("TransitionStart", transitionTimePerTick);
        } else
        {
            rectangleParent.gameObject.SetActive(false);
        }
    }

    private float ReverseTransition(float level)
    {
        List<Transform> rectangleList = GetListOfChildren(rectangleParent);

        foreach (Transform rectangle in rectangleList)
        {
            rectangle.GetComponent<RectTransform>().localScale -= new Vector3(0, level, 0);
        }

        return rectangleList[0].GetComponent<RectTransform>().localScale.y;
    }

    public void TransitionReturn()
    {
        List<Transform> rectangleList = GetListOfChildren(rectangleParent);

        foreach (Transform rectangle in rectangleList)
        {
            rectangle.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 0);
        }

        rectangleParent.gameObject.SetActive(true);
        if (ReverseTransition(-0.25f) < 1)
        {
            Invoke("TransitionReturn", transitionTimePerTick);
        }
        else
        {
            rectangleParent.gameObject.SetActive(false);
        }
    }
}
