using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class load : MonoBehaviour
{
    public float delayLoad;
    private void Start()
    {
        ModeSelect();
    }
    public void ModeSelect()
    {
        // cho phép dừng
        StartCoroutine(LoadAfterDelay());
    }
    IEnumerator LoadAfterDelay()
    {
        // đợi trì hoãn bao nhiêu giây
        yield return new WaitForSeconds(delayLoad);

        // nạp scene tiếp theo (tăng 1 index)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}
