using GraphicGeneratorForAutocad.AppService;
using GraphicGeneratorForAutocad.Service;

namespace GraphicGeneratorForAutocad.ViewModels
{
    public class DialogWIndow_GravityAnomalyLedgeViewModel
    {
        #region parameters

        #endregion

        #region buttons

        #endregion
        public Command Close
        {
            get
            {
                return new Command(
                    (obj) =>
                    {
                        DialogWindowsOperator.DialogWindow_GravityAnomalyLedge.Close();
                        DialogWindowsOperator.DialogWindow_GravityAnomalyLedge = null;
                    }
                );
            }
        }

    }
}