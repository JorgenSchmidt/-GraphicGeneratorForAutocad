using GraphicGeneratorForAutocad.AppService;
using GraphicGeneratorForAutocad.Service;

namespace GraphicGeneratorForAutocad.ViewModels
{
    public class DialogWIndow_MagneticAnomalyFormationViewModel
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
                        DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation.Close();
                        DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation = null;
                    }
                );
            }
        }
        #endregion
    }
}