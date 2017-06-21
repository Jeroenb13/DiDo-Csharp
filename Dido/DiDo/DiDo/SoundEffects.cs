using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace DiDo
{
    public enum SoundEfxEnum
    {
        BACKGROUND,
        SHOOT,
        RELOAD
    }

    public class SoundEffects
    {
        private Dictionary<SoundEfxEnum, MediaElement> effects;

        public SoundEffects()
        {
            effects = new Dictionary<SoundEfxEnum, MediaElement>();
            LoadEfx().Wait();
        }

        private async Task LoadEfx()
        {
            try
            {
                Debug.WriteLine("Add Backgroundsound");
                effects.Add(SoundEfxEnum.BACKGROUND, await LoadSoundFile("ms-appx:///Assets/Sound/Zapper-16-Bit.mp3"));
                Debug.WriteLine("Backgroundsound is added");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            
            effects.Add(SoundEfxEnum.SHOOT, await LoadSoundFile("ms-appx:///Assets/Sound/shot.mp3"));
            effects.Add(SoundEfxEnum.RELOAD, await LoadSoundFile("ms-appx:///Assets/Sound/reload.mp3"));
        }

        private async Task<MediaElement> LoadSoundFile(string v)
        {
            Debug.WriteLine("LoadSoundFile voor: " + v);
            MediaElement snd = new MediaElement();

            snd.AutoPlay = false;
            Debug.WriteLine("Voor StorageFile");
            StorageFile file = await Windows.Storage.StorageFile.GetFileFromApplicationUriAsync(new Uri(v));
            Debug.WriteLine("Voor openAsync");
            var stream = await file.OpenAsync(FileAccessMode.Read);
            Debug.WriteLine("Voor setSource");
            snd.SetSource(stream, file.ContentType);
            Debug.WriteLine("Einde van LoadSoundFile voor: " + v);
            return snd;
        }

        public async Task Play(SoundEfxEnum efx)
        {
            var mediaElement = effects[efx];

            await mediaElement.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                mediaElement.Stop();
                mediaElement.Play();
            });
        }
    }
}
