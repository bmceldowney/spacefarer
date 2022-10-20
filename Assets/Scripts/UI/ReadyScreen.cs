using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReadyScreen : StatefulBehaviour
{
    [SerializeField]
    TMP_Text _text;
    WaitForSeconds _twoSecondWait = new WaitForSeconds(2);

    protected override void HandleStateChange(GameState previous, GameState current)
    {
        //noop
    }

    void OnEnable()
    {
        StartCoroutine("DoReady");
    }

    void OnDisable()
    {
        _text.text = "Get Ready";
        StopCoroutine("DoReady");
    }

    IEnumerator DoReady()
    {
        yield return _twoSecondWait;
        _text.text = "GO";
        yield return _twoSecondWait;
        ChangeState(GameState.Play);
    }
}
