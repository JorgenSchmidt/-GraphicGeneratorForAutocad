using GraphicGeneratorForAutocad.AppService;
using GraphicGeneratorForAutocad.Service;

namespace GraphicGeneratorForAutocad.ViewModels
{
    public class DialogWIndow_ElectricAnomalyPointViewModel
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
                        DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint.Close();
                        DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint = null;
                    }
                );
            }
        }
        #endregion
    }
}