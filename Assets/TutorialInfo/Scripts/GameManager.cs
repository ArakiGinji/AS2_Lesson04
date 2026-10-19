using UnityEngine;

///==========================
/// ゲーム全体の管理クラス
///==========================
public class GameManager : MonoBehaviour
{
    // - クラスの目的
    // ゲーム全体のパラメータやオブジェクトの管理

    // - 使い方
    // GameManagerクラスをシーンに配置するだけでOK

    // === 変数宣言 ===

    private Spawner _spawner;

    // === 現在のゲームの画面状態

    private ISceneState _currentSceneState;

    void Start()
    {
        _spawner = new Spawner(); //オブジェクト生成クラスのインスタンス化
        _spawner.LoadAsync("Prefabs");

        // === 画面の初期設定
        _currentSceneState = new TitleSceneState();
        _currentSceneState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        // SceneStateの繰り返し処理
        _currentSceneState.ExecuteState();

        if (_spawner.IsLoaded)
        {
            _spawner.name_Spawn("Enemy");
            _spawner.name_Spawn("Item");
            //_spawner.Spawn(2); //オブジェクトの生成メソッドを呼び出す
        }
    }

    // === 画面の切り替え処理
    // 引数 : 次のSceneStateのインスタンス
    public void ChangeSceneState(ISceneState nextScene)
    {
        // 起動中のシーンを終了させる
        _currentSceneState.ExitState();

        // 次のシーンに切り替え
        _currentSceneState = nextScene;

        // 新しいシーンを実行
        _currentSceneState.EnterState();
    }
}
