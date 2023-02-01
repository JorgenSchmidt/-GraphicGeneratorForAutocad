﻿using GraphicGeneratorForAutocad.AppService;
using GraphicGeneratorForAutocad.Service;

namespace GraphicGeneratorForAutocad.ViewModels
{
    public class DialogWIndow_CarotageViewModel
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
                        DialogWindowsOperator.DialogWindow_Carotage.Close();
                        DialogWindowsOperator.DialogWindow_Carotage = null;
                    }
                );
            }
        }
        #endregion
    }
}