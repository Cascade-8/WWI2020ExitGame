using UnityEngine;

namespace Task
{
    public class ButtonHandler : MonoBehaviour
    {
        public AudioClip[] soundeffects;
        private AudioClip _currentSource;
        // ReSharper disable Unity.PerformanceAnalysis
        public void PlaySoundeffect(int i)
        {
            if (i != 0)
            {
                _currentSource = soundeffects[i];
                Invoke(nameof(DelayedPlay),1);
            }
            transform.GetComponent<AudioSource>().PlayOneShot(soundeffects[0]);
        }

        private void DelayedPlay()
        {
            transform.GetComponent<AudioSource>().PlayOneShot(_currentSource);
        }
    }
}
