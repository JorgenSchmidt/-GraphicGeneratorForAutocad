using GraphicGeneratorForAutocad.Views;
using System.Windows;

namespace GraphicGeneratorForAutocad.AppService
{
    /// <summary>
    /// Класс для взаимодействия основного окна с диалоговыми.
    /// </summary>
    public class DialogWindowsOperator : Window
    {
        public static DialogWindow_Carotage DialogWindow_Carotage;
        public static DialogWindow_ElectricAnomalyPoint DialogWindow_ElectricAnomalyPoint;
        public static DialogWindow_GravityAnomalySphere DialogWindow_GravityAnomalySphere;
        public static DialogWindow_GravityAnomalyLedge DialogWindow_GravityAnomalyLedge;
        public static DialogWindow_MagneticAnomalySphere DialogWindow_MagneticAnomalySphere;
        public static DialogWindow_MagneticAnomalyFormation DialogWindow_MagneticAnomalyFormation;
    }
}