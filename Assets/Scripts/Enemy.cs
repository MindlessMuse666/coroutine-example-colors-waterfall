using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetColor(Color nextColor, float recoloringDuration)
    {
        StartCoroutine(ChangeColor(nextColor, recoloringDuration));
    }

    private IEnumerator ChangeColor(Color nextColor, float recoloringDuration)
    {
        var startColor = _renderer.material.color;
        var recoloringTime = 0f;

        while (recoloringTime < recoloringDuration)
        {
            _renderer.material.color = Color.Lerp(startColor, nextColor, recoloringTime / recoloringDuration);
            recoloringTime += Time.deltaTime;
            yield return null;
        }

        _renderer.material.color = nextColor;
    }
}