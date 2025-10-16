using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

[ExecuteAlways]
public class HorizontalContainer : MonoBehaviour
{
    public Transform headPos;
    private List<Transform> elmList=new List<Transform>();
    //Ԫ�ذ뾶
    public float radius;
    //Ԫ�صļ��
    public float spacing;
    //׷��Ԫ��
    public void Add(Transform trans){
        elmList.Add(trans);
        trans.SetParent(transform);
        trans.position =  elmList.Last().position+ interval; 
    }

    Vector3 interval;

    private void Start()
    {
        interval= new Vector3(2*radius+spacing,0,0);   
    }
    public void Remove(Transform trans, float waitDelay)
    {
        int delPos = elmList.IndexOf(trans);
        elmList.Remove(trans);
        trans.SetParent(null);
        //���������б���ʾ
        StartCoroutine(adjustList(delPos, waitDelay));
    }

    IEnumerator adjustList( int delPos, float delay=0) {
        yield return new WaitForSeconds(delay);

        for (int i = delPos+1; i < elmList.Count; i++)
        {
            Transform ele= elmList[i];
            ele.DOLocalMove(-interval,0.15f);
            yield return new WaitForSeconds(0.05f);
        }
    }
    [ExecuteInEditMode]
    private void Update()
    {
        if (elmList.Count>0)
        {
            //�� spacing �� radius ����Ԫ�صļ��
            for (int i = 0; i < elmList.Count; i++)
            {
                elmList[i].position = headPos.position + i * interval;
            }
        }
    }
}
