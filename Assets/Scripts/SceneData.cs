using UnityEngine;

public class SceneData : MonoBehaviour
{
    private static int home = 0;
    private static int main = 1;

    public static int GetHome()
    {
        return home;
    }

    public static int GetMain()
    {
        return main;
    }
}
