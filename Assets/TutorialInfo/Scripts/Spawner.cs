using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;

///==========================
/// オブジェクト生成クラス
///==========================
public class Spawner : MonoBehaviour
{
    // - クラスの目的
    // オブジェクト(プレハブ)を生成する事。
    // 1.Speaw()メソッドを呼び出すだけ
    // ======== 変数宣言 =========
    private GameObject[] _prefabs;

    public bool IsLoaded = false;
    void Start()
    {
        
    }

    // === アセット読み込みメソッド（非同期） ===
    public async void LoadAsync( string label )
    {
        var handle = Addressables.LoadAssetsAsync<GameObject>( label );
        IList<GameObject> result = await handle.ToUniTask();
        // ===== await より後は読み込みが終わっている =====

        // 変数に読み込みが終わっている
        _prefabs = result.ToArray();
        IsLoaded = true;
    }

    public void Spawn(int index)
    {
        if (IsLoaded)
        {
            GameObject.Instantiate(_prefabs[index]);
        }
        else
        {
            Debug.Log("[Spawner.cs] Now Loading...");
        }
    }

    public void name_Spawn(string assetName)
    {
        for (int index = 0; index < _prefabs.Length; index++)
        {
            Debug.Log($"検索中...読み込みアセット名:{_prefabs[index].name}");
            if (_prefabs[index].name == assetName)
            {
                // プレハブの生成
                GameObject.Instantiate(_prefabs[index]);
                break;
            }
        }
    }

}
