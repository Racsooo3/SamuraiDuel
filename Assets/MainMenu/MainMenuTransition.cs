using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuTransition : MonoBehaviour
{
    [SerializeField]Transform rectangleParent;
    [SerializeField] float transitionTimePerTick;

    private void Start()
    {
        TransitionStart();
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
        rectangleParent.gameObject.SetActive(true);
        if (Transition(-0.25f) > 0)
        {
            Invoke("TransitionStart", transitionTimePerTick);
        } else
        {
            rectangleParent.gameObject.SetActive(false);
        }
    }
}
