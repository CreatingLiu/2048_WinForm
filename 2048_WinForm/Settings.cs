using static _2048_WinForm.PublicVar;
using System.Media;
using System.Diagnostics;

namespace _2048_WinForm.Properties {


    
    
    // 通过此类可以处理设置类的特定事件: 
    //  在更改某个设置的值之前将引发 SettingChanging 事件。
    //  在更改某个设置的值之后将引发 PropertyChanged 事件。
    //  在加载设置值之后将引发 SettingsLoaded 事件。
    //  在保存设置值之前将引发 SettingsSaving 事件。
    public sealed partial class Settings {
        
        public Settings() {
            // // 若要为保存和更改设置添加事件处理程序，请取消注释下列行: 
            //
            // this.SettingChanging += this.SettingChangingEventHandler;
            //
            // this.SettingsSaving += this.SettingsSavingEventHandler;
            //
            SettingsLoaded += SettingsLoadedEventHandler;
            PropertyChanged += SettingChangedEventHandler;
        }
        
        private void SettingChangingEventHandler(object sender, System.Configuration.SettingChangingEventArgs e) {
            // 在此处添加用于处理 SettingChangingEvent 事件的代码。
        }
        
        private void SettingsSavingEventHandler(object sender, System.ComponentModel.CancelEventArgs e) {
            // 在此处添加用于处理 SettingsSaving 事件的代码。
        }

        private void SettingsLoadedEventHandler(object sender, System.Configuration.SettingsLoadedEventArgs e)
        {
            Setting();
        }

        private void SettingChangedEventHandler(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Setting();
        }

        private void Setting ()
        {
            backgroundMusicPlayer = new SoundPlayer();
            Trace.WriteLine("音乐选择"+Default.backgroundImageIndex);
            if (backgroundMusicIndex == 0)
                backgroundMusicPlayer.Stop();

            switch (Default.backgroundMusicIndex)
            {
                case 0:
                    backgroundMusicPlayer = null;
                    break;
                case 1:
                    backgroundMusicPlayer = new SoundPlayer(Resources.backgroundMusic1);
                    break;
                case 2:
                    backgroundMusicPlayer = new SoundPlayer(Resources.backgroundMusic2);
                    break;
                case 3:
                    backgroundMusicPlayer = new SoundPlayer(Resources.backgroundMusic3);
                    break;
            }

            if (backgroundMusicIndex != 0)
                backgroundMusicPlayer.Play();
        }
    }
}
