using System.Data;
using NAudio.CoreAudioApi;
using System;


namespace PSP_Web_API.Services
{
    public class AudioService
    {

        private readonly MMDevice _device;

        public AudioService()
        {
            var enumerator = new MMDeviceEnumerator();
            _device = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
        }

        public float GetVolume() => _device.AudioEndpointVolume.MasterVolumeLevelScalar;

        public void SetVolume(float value)
        {
            if (value < 0 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));
            _device.AudioEndpointVolume.MasterVolumeLevelScalar = value;
        }

        public void IncreaseVolume(float step = 0.1f)
        {
            SetVolume(Math.Min(GetVolume() + step, 1f));
        }

        public void DecreaseVolume(float step = 0.1f)
        {
            SetVolume(Math.Max(GetVolume() - step, 0f));
        }



    }
    
}
