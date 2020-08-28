using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class animate_script : MonoBehaviour {
    private string all_message;
    private string[] all_message_cutted;
    private bool waits;
    private bool anim_work;
    private int counter;
    private Animator anim;
    public Text text_cutted;
    public Text whole_text;
    public float tim;
    public bool start_cutting;
	// Use this for initialization
	void Start () {
        start_cutting = false;
        all_message="";
        counter = 0;
        waits = false;
        this.anim_work = false;
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(start_cutting&&!this.waits)
        {
            words(counter);
            StartCoroutine(waitTime());
            counter++;
        }
	}
    public void words(int i)
    {
        if (all_message_cutted.Length-1==i&&start_cutting)
        {
            start_cutting = false;
            counter = 0;
            text_cutted.text = "";
        }
        text_cutted.text = all_message_cutted[i];
        whole_text.text = all_message;
        Debug.Log(all_message_cutted[i]);
        
    }
    public void set_Text(string all_text)
    {
        counter = 0;
        all_message = all_text;
        this.all_message_cutted = all_message.Split(' ');
        start_cutting = true;
    }
    IEnumerator waitTime()
    {
        this.waits = true;
            if (!anim_work)
            {
                this.anim_work = true;
                anim.SetTrigger(text_cutted.text);
            }
        yield return new WaitForSeconds(this.tim);
        anim.SetTrigger("idle");
        this.anim_work = false;
        this.waits = false;
        
    }
}
