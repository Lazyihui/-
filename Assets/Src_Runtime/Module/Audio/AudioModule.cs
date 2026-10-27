using System;
using UnityEngine;

namespace Hamdoku {
    public sealed class AudioModule {
        readonly AudioSource effects;

        public AudioModule(AudioSource effects) {
            if (effects == null) {
                throw new ArgumentNullException(nameof(effects));
            }
            this.effects = effects;
        }

        public void PlayOneShot(AudioClip clip, float volume) {
            if (clip == null) {
                throw new ArgumentNullException(nameof(clip));
            }
            effects.PlayOneShot(clip, volume);
        }

        public void Stop() {
            if (effects != null) {
                effects.Stop();
            }
        }
    }
}
