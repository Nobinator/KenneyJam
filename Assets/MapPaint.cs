
using UnityEditor;
using UnityEngine;

public class MapPaint : EditorWindow{
    private GameObject prefab;
	
    [MenuItem("Window/MapPaint")]
    public static void Init(){
        var win = GetWindow<MapPaint>();
        win.Show();
    }

    private bool IsActive;
    private bool secondActive;

    private Transform root;

    private void OnEnable(){
        SceneView.onSceneGUIDelegate -= this.OnSceneGUI;
        SceneView.onSceneGUIDelegate += this.OnSceneGUI;
    }

    private void OnDisable(){
        SceneView.onSceneGUIDelegate -= this.OnSceneGUI;
    }

    private void OnGUI(){
        IsActive = EditorGUILayout.Toggle("Active", IsActive);
        prefab = (GameObject)EditorGUILayout.ObjectField("Prefab", prefab, typeof(GameObject), true);
        root = (Transform)EditorGUILayout.ObjectField("Root", root, typeof(Transform), true);
    }

    private Vector2 mouse;
    private bool drag;

    private void OnSceneGUI(SceneView sceneView){
        Tools.hidden = true;
        if (IsActive){

            var old = mouse;
            mouse = SnapV(MousePosition());
            if (mouse != old){
                drag = true;
            }
            else{
                drag = false;
            }
            
            if (Event.current.type == EventType.mouseDown && Event.current.button == 0 && Clr()){
                secondActive = !secondActive;
                drag = true;
            }

            
            Handles.DotHandleCap(0, mouse, Quaternion.identity, .1f, EventType.Repaint);

            if (drag && secondActive && Clr()){
                Instantiate(prefab, mouse, Quaternion.identity, root);
            }

            HandleUtility.Repaint();
        }
    }

    Vector3 MousePosition(){
        var worldRay = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
        float enter;
        Plane xz = new Plane(new Vector3(0f, 0f, 1f), 0);
        xz.Raycast(worldRay, out enter);
        return worldRay.GetPoint(enter);
    }

    public Vector3 snap = Vector3.one * 0.25f;
    
    Vector3 SnapV(Vector3 value){
        return new Vector3(
            Mathf.Round(value.x / snap.x) * snap.x,
            Mathf.Round(value.y / snap.y) * snap.y,
            Mathf.Round(value.z / snap.z) * snap.z
        );
    }

    bool Clr(){
        return !Event.current.alt && !Event.current.control && !Event.current.shift;
    }
}