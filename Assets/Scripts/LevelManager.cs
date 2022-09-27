using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    [SerializeField] PlayerBehaviour _player;
    [SerializeField] KidBehaviour [] _kids;
    [SerializeField] GameObject [] _diamonds;
    [SerializeField] Material [] _diamondMaterials;
    [SerializeField] CollectUI _collectUI;
    [SerializeField] GameObject _gameClearUI;
    [SerializeField] GameObject _gameOverUI;
    int _currentCollect;
    private void Start()
    {
        _collectUI.Init(_diamonds.Length);
        _currentCollect = 0;
        InitDiamonds();
    }
    void InitDiamonds()
    {
        int x = 0;
        for(int i=0; i<_diamonds.Length; i++)
        {
            _diamonds[i].GetComponentInChildren<MeshRenderer>().material 
                            = _diamondMaterials[i % _diamondMaterials.Length];
        }
    }
    void GameClear()
    {
        _player.OnGameClear();
        _gameClearUI.SetActive(true);
        foreach (var kid in _kids)
        {
            kid.ChangeState(new KidStates.LoseState(kid));
            kid.enabled = false;
        }
        SoundManager.Instance.PlaySound(SoundManager.Instance.ClearSound, 1f);
    }
    public void GameOver(KidBehaviour attackedKid)
    {
        _gameOverUI.SetActive(true);
        SoundManager.Instance.PlaySound(SoundManager.Instance.OverSound, 0.65f);
        foreach (var kid in _kids)
        {
            if(kid != attackedKid)
                kid.Animator.SetTrigger("OnlyWin");
            kid.enabled = false;
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("YJScene");
    }
    public void OnCollectDiamond()
    {
        _currentCollect++;
        _collectUI.SetCurrentCount(_currentCollect);
        if(_currentCollect == _diamonds.Length)
        {
            GameClear();
        }
    }
    
}
