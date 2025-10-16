using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteAlways]
public class HorizontalContainer : MonoBehaviour
{
    public Transform headPos;
    private List<Transform> elmList = new List<Transform>();
    //Ԫ�ذ뾶
    public float radius;
    //Ԫ�صļ��
    public float spacing;
    public int count => elmList.Count;

    //׷��Ԫ��
    public void Add(Transform trans)
    {
        trans.SetParent(transform);

        //Debug.Log("HorizontalContainer:--" + elmList.Count);
        if (elmList.Count > 0)
            trans.position = elmList.Last().position + interval;
        else
            trans.position = headPos.position;

        elmList.Add(trans);
    }

    Vector3 interval;

    private void Start()
    {
        interval = new Vector3(2 * radius + spacing, 0, 0);
    }
    public void Remove(Transform trans, float waitDelay)
    {
        int delPos = elmList.IndexOf(trans);

        trans.SetParent(null);
        //���������б���ʾ
        if (elmList.Count > 1)
            StartCoroutine(adjustList(delPos, waitDelay));
        else 
            elmList.RemoveAt(0);
    }

    IEnumerator adjustList(int delPos, float delay)
    {
        yield return new WaitForSeconds(delay);
        for (int i = delPos+1; i < elmList.Count; i++)
        {
            Transform ele = elmList[i];
            ele.DOMove(ele.position - interval, 0.1f);
            yield return new WaitForSeconds(0.1f);
        }
        elmList.RemoveAt(delPos);

    }

    private void Update()
    {
        //interval = new Vector3(2 * radius + spacing, 0, 0);

        //if (elmList.Count > 0)
        //{
        //    �� spacing �� radius ����Ԫ�صļ��
        //    for (int i = 0; i < elmList.Count; i++)
        //    {
        //        elmList[i].position = headPos.position + i * interval;
        //    }
        //}

    }
}
