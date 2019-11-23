using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowToast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        onShowToast();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onShowToast()
    {
        SSTools.ShowMessage("MOVE YOUR HEAD UP AND DOWN TO GO BACK", SSTools.Position.bottom, SSTools.Time.threeSecond);
    }

}
