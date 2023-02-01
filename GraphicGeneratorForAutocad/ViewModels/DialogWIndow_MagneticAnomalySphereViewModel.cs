using GraphicGeneratorForAutocad.AppService;
using GraphicGeneratorForAutocad.Service;

namespace GraphicGeneratorForAutocad.ViewModels
{
    public class DialogWIndow_MagneticAnomalySphereViewModel
    {
        #region parameters

        #endregion

        #region buttons
        public Command Close
        {
            get
            {
                return new Command(
                    (obj) =>
                    {
                        DialogWindowsOperator.DialogWindow_MagneticAnomalySphere.Close();
                        DialogWindowsOperator.DialogWindow_MagneticAnomalySphere = null;
                    }
                );
            }
        }
        #endregion
    }
}