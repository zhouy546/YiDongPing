using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUICTR : MonoBehaviour
{
    public DealWithUDPMessage dealWithUDPMessage;
    public PlaneBG planeBG;

    public static float Threshhold = 10f;

    [System.Serializable]
    public struct Node
    {
        int ID;
        public float DisplayNum;
        public float maxNum { get { return DisplayNum + Threshhold; } }
        public float minNum { get { return DisplayNum - Threshhold; } }
    }

    public class Section
    {
        public bool IsBlack;
        public int ID;
        public float maxNum;
        public float minNum;

        public Section(bool _IsBlack, int _ID, float _minNum, float _maxNum)
        {
            IsBlack = _IsBlack;
            ID = _ID;
            maxNum = _maxNum;
            minNum = _minNum;
        }
    }

    public List<Node> nodes = new List<Node>();
    List<Section> sections = new List<Section>();

    void initialization()
    {
        Section section0 = new Section(false, -1, -1, nodes[0].minNum);
        sections.Add(section0);
        for (int i = 0; i < nodes.Count * 2 - 1; i++)
        {
            if (i % 2 == 0)
            {
                Section section = new Section(true, i / 2, nodes[i/2].minNum, nodes[i/2].maxNum);
                sections.Add(section);
            }
            else
            {
                Section section = new Section(false, -1, nodes[(i - 1)/2].maxNum, nodes[(i+1)/2].minNum);
                sections.Add(section);
            }
        }

        Section sectionEnd= new Section(false, -1,nodes[nodes.Count-1].maxNum, dealWithUDPMessage.inputMax);
        sections.Add(sectionEnd);
        //foreach (var section in sections)
        //{
        //    Debug.Log("ID: "+section.ID+"isBlack: "+section.IsBlack+"MinNum: "+section.minNum+"maxNum: "+section.maxNum);

        //}

    }

    // Use this for initialization
    void Start()
    {
        initialization();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ShowUI(int num)
    {
        planeBG.GetComponent<Animator>().SetInteger("Animation", num+1);
    }
    private void HideUI()
    {
        planeBG.GetComponent<Animator>().SetInteger("Animation", 0);
    }



    public void Check(float value)
    {
        //   if(value)
        foreach (var section in sections)
        {
            int num = sections.IndexOf(section);

            if (value > section.minNum && value < section.maxNum)
            {

                if (section.IsBlack)
                {
                    Debug.Log(section.ID);
                    Debug.Log("Show");
                    ShowUI(section.ID);
                }
                else{
                    Debug.Log("Hide");
                    HideUI();
                }
            }
        }

    }


    //public void UpdatecheckNumsList(float value)
    //{
    //    float temp=0;
    //    foreach (var item in sections)
    //    {
    //        if (value > item.maxNum)
    //        {
    //            if (temp < item.maxNum) {
    //                temp = item.maxNum;
    //            }



    //        }
    //        if(temp>)
         
    //    }
    //}
}



