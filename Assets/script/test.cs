using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public float time =100f;
    public float target;
    public Text time_text; 
    void Start()
    {
        StartCoroutine("timer");
    }


    IEnumerator timer()
    {
        yield return new WaitUntil(() => {
            if (time <= 0)
            {
                return true;
            }
            else
            {

                if (time <= target)
                {
                    if (dialog.instance.dialog_read(0) && !dialog.instance.running)
                    {
                        IEnumerator dialog_co = dialog.instance.dialog_system_start(0);
                        StartCoroutine(dialog_co);
                        
                        if (dialog.instance.dialog_read(0))
                        {
                            return false;
                        }

                    }else if (!dialog.instance.dialog_read(0) && !dialog.instance.running)
                    {
                        time -= Time.deltaTime;
                        time_text.text = time.ToString();
                    }
                }
                else
                {
                    time -= Time.deltaTime;
                    time_text.text = time.ToString();
                }
                
                return false;
            }
        });
    }
}
