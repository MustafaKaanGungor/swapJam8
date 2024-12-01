using UnityEngine;

public class GameManager : MonoBehaviour
{
    //5 hediye ve 3 goblin yakalasayýnca oyun bitiyor 
    [HideInInspector] public int giftCount;
    [HideInInspector] public int goblinCount;
    #region class referance
    SceneLoader loader;
    noelFatherController controller;
    #endregion


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loader = FindAnyObjectByType<SceneLoader>();
        controller = FindAnyObjectByType<noelFatherController>();
    }

    // Update is called once per frame
    void Update()
    {
        FinishTheGame();
    }
    public void FinishTheGame()
    {
        if (giftCount >= 5 && goblinCount >= 3)
        {
            loader.GoEndScene();
        }
    }
}
