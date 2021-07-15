using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Panel : MonoBehaviour
{
    public GameObject RestartMenu;
    public GameObject CellPrefab;
    public Text Quest;
    
    private Sprite[] _spriteLetters;
    private List<Cell> _cells;
    public int _cellGroupNums = 3;
    private const int _singleGroupCell = 3;

    public void NextLevel()
    {
        if (_cellGroupNums != 9)
        {
            _cellGroupNums += 3;
            GenerationCell();
        }
        else
        {
            RestartMenu.SetActive(true);
        }
    }

    private void Start()
    {
        _cells = new List<Cell>();
        _spriteLetters = Resources.LoadAll<Sprite>("Letters");
        GenerationCell();
    }
    private void GenerationCell()
    {
        for (int c = _cellGroupNums - _singleGroupCell; transform.childCount != _cellGroupNums; c++)
        {
            GameObject SpawnCells = Instantiate(CellPrefab);
            Cell cell = SpawnCells.GetComponent<Cell>();
            _cells.Add(cell);
            _cells[c].transform.SetParent(transform, false);
            if (_cellGroupNums > 3) Destroy(_cells[c].GetComponent<Animator>());
            _cells[c].BG = GetComponent<Panel>();
        }
        GenerationAnswer();
    }
    public void GenerationAnswer()
    {
        int RandomAnswer = Random.Range(0, transform.childCount);
        _cells[RandomAnswer].SwapInTrue();
        GenerateLetters();
        Quest.GetComponent<Text>().text = "Touch to " + _cells[RandomAnswer].Sprite.sprite.name;
    }
    private void GenerateLetters()
    {
        for (int CellLetters = 0; CellLetters != transform.childCount; CellLetters++)
        {
            int RandomLetters = Random.Range(0, _spriteLetters.Length);
            for(int CellSprite = 0; CellSprite != transform.childCount; CellSprite++)
            {
                if (_cells[CellSprite].Sprite.sprite == _spriteLetters[RandomLetters])
                {
                    RandomLetters = Random.Range(0, _spriteLetters.Length);
                }
            }
            _cells[CellLetters].Sprite.sprite = _spriteLetters[RandomLetters];
        }
    }
}