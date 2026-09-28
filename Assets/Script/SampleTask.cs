using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;

public class SampleTask : MonoBehaviour
{
    public GameObject Bullet;
    // === 非同期処理 === //
    // async と await エーシンク と エーウェイト
    async void Start()
    {
        await UniTask.WaitForSeconds(0.5f);//０．５秒待つ

        for (int i = 0; i < 1000; i++)
        {
            //Debug.Log("スタートの処理だよ。"); 
        }
        // === Addressablesによるアセットの読み込み処理 ===//
        var handle = Addressables.LoadAssetAsync<GameObject>("Prefabs");
        GameObject prafab = await handle.ToUniTask(); //読み込み終わるまで待機
        //  =============================================== //

        Debug.Log($" 読み込み済み => {prafab.name}");
        Instantiate(prafab);

        //  === Addressablesによる複数アセットの読み込み処理 === //
        var handles = Addressables.LoadAssetsAsync<GameObject>("Prefabs");
        IList<GameObject> prefabs = await handles.ToUniTask();
        // ===================================================== //

        for (int i = 0; i < prefabs.Count; i++)
        {
            Debug.Log($"読み込み済み => {prefabs[i].name}");
            Instantiate(prefabs[i]);
        }

    }

    // Update is called once per frame
    async void Update()
    {
        await UniTask.WaitForSeconds(1.0f);
        //Debug.Log("アップロードの処理だよ。");
    }

    async void Hoge()
    {
        await UniTask.WaitForSeconds(0.5f); //数秒待つ
    }

    async void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Hoge"))
        {
            await UniTask.WaitForSeconds(0.5f);
            SceneManager.LoadScene("");
        }
    }
}
