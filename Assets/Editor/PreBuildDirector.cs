using UnityEngine;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor;
using UnityEditor.SceneManagement;

public class PreBuildDirector : IPreprocessBuildWithReport
{
    public int callbackOrder => 1;

    public void OnPreprocessBuild(BuildReport report)
    {
      Debug.Log("ビルド前処理");
    
        //ビルドするシーンをすべて取得
        var scenes = EditorBuildSettings.scenes;
        
        foreach (var scene in scenes)
        {
            //シーンを開く
            EditorSceneManager.OpenScene(scene.path);

            //処理を行う
            var sceneTransitions = GameObject.FindObjectsOfType<SceneTransition>();
            foreach (var _sceneTransition in sceneTransitions)
            {
                _sceneTransition.SetDestSceneName();
                
                /*プレハブのインスタンスだったら以下の処理も必要
                PrefabUtility.RecordPrefabInstancePropertyModifications(sample);
                */
            }

            //シーンのセーブ
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            EditorSceneManager.SaveOpenScenes();
        }
    }
}
