using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Cell : MonoBehaviour
{
    public Panel BG;
    public Image Sprite;
    public GameObject Particle;

    private bool _answer = false;
    public void SwapInTrue()
    {
        _answer = true;
    }
    private void OnMouseDown()
    {
        if (!_answer) FalseAnswer();
        else TrueAnswer();
    }
    private void FalseAnswer()
    {
        for(int PosX = - 2; PosX != 64; PosX *= -2)
        {
            Sprite.transform.DOLocalMoveX(PosX, 0.5f);
        }
        Sprite.transform.DOLocalMoveX(0, 0.5f);
    }
    private void TrueAnswer()
    {
        GameObject Part = Instantiate(Particle);
        Part.transform.SetParent(Sprite.transform, false);
        Sprite.transform.DOScale(Vector3.zero, 1);
        Sprite.transform.DOScale(new Vector3(1.2f, 1.2f, 0), 1);
        Sprite.transform.DOScale(new Vector3(0.9f, 0.9f, 0), 1);
        Sprite.transform.DOScale(transform.localScale, 1);
        _answer = false;
        BG.Invoke("NextLevel", 1);
    }
}
