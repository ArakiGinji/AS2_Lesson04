using UnityEngine;

/// <summary>
/// ○○SceneStateのインターフェース
/// ===============================
/// ここに書かれているメソッドは継承者で<必ず>
/// 実装しなければならない
/// </summary>
public interface ISceneState
{
    void EnterState();
    void ExecuteState();
    void ExitState();
}
