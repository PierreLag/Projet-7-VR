using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomTests
{
    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator RoomTestsSwitchScene()
    {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(1);

        Button tvButton = GameObject.Find("TV_FlatWallMounted").GetComponentInChildren<Canvas>().GetComponentInChildren<Button>();

        tvButton.onClick.Invoke();

        yield return new WaitForSeconds(1);

        Assert.IsTrue(SceneManager.GetActiveScene().buildIndex == 1);
    }
}
