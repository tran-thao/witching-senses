using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPuzzle : MonoBehaviour
{
    public GameObject pianoKeys;
    PopUpScript popupScript;
    MusicButtonManager musicButtonManager;

    // Start is called before the first frame update
    void Start()
    {
        musicButtonManager = GameObject.Find("MusicButtonManager").GetComponent<MusicButtonManager>();
        pianoKeys = GameObject.Find("pianoKeys");
        pianoKeys.SetActive(false);
        popupScript = GameObject.Find("Canvas").GetComponent<PopUpScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !musicButtonManager.gameCompleted)
        {
            popupScript.ClosePopUp(popupScript.GoToPianoPopUpPanel);
            pianoKeys.SetActive(true);
            popupScript.ShowPopUp(popupScript.howToPopUpPanel);
            musicButtonManager.Invoke("StartPlayingSequence", 3f);
        }
    }
}
