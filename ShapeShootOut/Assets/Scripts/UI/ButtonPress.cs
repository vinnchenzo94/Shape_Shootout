using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour {

    public string scene_to_load;

    public void Scene_Changer (string _scene_name) {
        SceneManager.LoadScene(_scene_name);
    }
}
