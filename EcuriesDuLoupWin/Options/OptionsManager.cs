using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EcuriesDuLoupWin.Options
{
    public class OptionsManager
    {
        private static OptionsManager instance;
        public static OptionsManager Instance
        {
            get
            {
                if (OptionsManager.instance == null)
                {
                    OptionsManager.instance = new OptionsManager();
                }
                return OptionsManager.instance;
            }
        }

        private String filePath = "options.dat";
        private BinarySerialiserManager<OptionsData> bsm;
        private OptionsData options;      

        private OptionsManager()
        {
            this.bsm = new BinarySerialiserManager<OptionsData>();
            bsm.FilePath = this.filePath;
        }
        public OptionsData GetOptions()
        {
            if (this.options == null)
            {
                OptionsData options = this.bsm.Get();
                if (options == null)
                {
                    options = this.GetDefaultOptions();
                }
                this.options = options;
            }

            return this.options;
        }

        private OptionsData GetDefaultOptions()
        {
            OptionsData defaultOptions = new OptionsData();

            defaultOptions.IsNotificationSoundActivate = true;

            return defaultOptions;
        }

        public void DefineOptions(OptionsData newOptions)
        {
            this.Reverberate(newOptions);
            this.bsm.Save(newOptions);
        }

        private void Reverberate(OptionsData newOptions)
        {
            if (this.options != newOptions)
            {
                this.options.IsNotificationSoundActivate = newOptions.IsNotificationSoundActivate;
            }
        }

        
    }
}
