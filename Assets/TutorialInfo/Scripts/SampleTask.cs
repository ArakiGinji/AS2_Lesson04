using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class SampleTask : MonoBehaviour
{
    // === 非同期処理 === //
    // async（エーシンク） と await（エーウェイト）
    async void Start()
    {
        await UniTask.WaitForSeconds(0.5f);

        for (int i = 0; i < 1000; i++)
        {
            Debug.Log("スタートの処理だよ");
        }

        // === Addressablesによるアセットの読み込み処理 ===//
        var handle = Addressables.LoadAssetAsync<GameObject>("Prefabs");
        GameObject prefab = await handle.ToUniTask();
        // =============================================== //

        Debug.Log($" 読み込み済み => {prefab.name}");
        Instantiate(prefab);

        // === Addressablesによる複数アセットの読み込み処理 === //
        var handles = Addressables.LoadAssetsAsync<GameObject>("Prefabs");
        IList<GameObject> prefabs = await handles.ToUniTask();
        // ==================================================== //

        for (int i = 0; i < prefabs.Count; i++)
        {
            Debug.Log($"読み込み済み => {prefabs[i].name}");
            Instantiate(prefabs[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("アップデートの処理だよ");
    }

    async void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag.Equals("Hoge"))
        {
            await UniTask.WaitForSeconds(0.5f);
            //SceneManager.LoadScene("HogeScene");
        }
    }
}