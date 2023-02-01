using GraphicGeneratorForAutocad.AppService;
using GraphicGeneratorForAutocad.Service;

namespace GraphicGeneratorForAutocad.ViewModels
{
    public class DialogWIndow_GravityAnomalySphereViewModel
    {
        #region parameters

        #endregion

        #region buttons
        public Command MakeCommands
        {
            get
            {
                return new Command(
                    (obj) =>
                    {

                    }
                );
            }
        }
        public Command Close
        {
            get
            {
                return new Command(
                    (obj) =>
                    {
                        DialogWindowsOperator.DialogWindow_GravityAnomalySphere.Close();
                        DialogWindowsOperator.DialogWindow_GravityAnomalySphere = null;
                    }
                );
            }
        }
        #endregion
    }
}