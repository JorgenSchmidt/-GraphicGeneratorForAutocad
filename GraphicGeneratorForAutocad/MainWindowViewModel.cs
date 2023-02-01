using GraphicGeneratorForAutocad.AppService;
using GraphicGeneratorForAutocad.Service;
using GraphicGeneratorForAutocad.ViewModelService;

namespace GraphicGeneratorForAutocad
{
    /// <summary>
    /// Логика взаимодействия с элементами основного окна.
    /// </summary>
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        #region output elements
        public string infoPanel;
        public string InfoPanel
        {
            get { return infoPanel; }
            set
            {
                infoPanel = value;
                CheckChanges();
            }
        }

        public string output;
        public string Output
        {
            get { return output; }
            set
            {
                output = value;
                CheckChanges();
            }
        }
        #endregion

        #region buttons for call dialog windows
        public Command GravityAnomaly_Sphere
        {
            get
            {
                return new Command(
                    (obj) =>
                    {
                        DialogWindowsOperator.DialogWindow_GravityAnomalySphere = new();

                        if (DialogWindowsOperator.DialogWindow_GravityAnomalySphere.ShowDialog() == true)
                        {
                            DialogWindowsOperator.DialogWindow_GravityAnomalySphere.Show();
                        }

                        InfoPanel = DataInteractor.Info;
                        Output = DataInteractor.Output;
                    }
                );
            }
        }

        public Command GravityAnomaly_Ledge
        {
            get
            {
                return new Command(
                    (obj) =>
                    {
                        DialogWindowsOperator.DialogWindow_GravityAnomalyLedge = new();
                        
                        if (DialogWindowsOperator.DialogWindow_GravityAnomalyLedge.ShowDialog() == true)
                        {
                            DialogWindowsOperator.DialogWindow_GravityAnomalyLedge.Show();
                        }

                        InfoPanel = DataInteractor.Info;
                        Output = DataInteractor.Output;
                    }
                );
            }
        }

        public Command MagneticAnomaly_Sphere
        {
            get
            {
                return new Command(
                    (obj) =>
                    {
                        DialogWindowsOperator.DialogWindow_MagneticAnomalySphere = new();

                        if (DialogWindowsOperator.DialogWindow_MagneticAnomalySphere.ShowDialog() == true)
                        {
                            DialogWindowsOperator.DialogWindow_MagneticAnomalySphere.Show();
                        }

                        InfoPanel = DataInteractor.Info;
                        Output = DataInteractor.Output;
                    }
                );
            }
        }

        public Command MagneticAnomaly_Formation
        {
            get
            {
                return new Command(
                    (obj) =>
                    {
                        DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation = new();

                        if (DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation.ShowDialog() == true)
                        {
                            DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation.Show();
                        }

                        InfoPanel = DataInteractor.Info;
                        Output = DataInteractor.Output;
                    }
                );
            }
        }

        public Command ElectricAnomaly_Point
        {
            get
            {
                return new Command(
                    (obj) =>
                    {
                        DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint = new();

                        if (DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint.ShowDialog() == true)
                        {
                            DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint.Show();
                        }

                        InfoPanel = DataInteractor.Info;
                        Output = DataInteractor.Output;
                    }
                );
            }
        }

        public Command Carotage
        {
            get
            {
                return new Command(
                    (obj) =>
                    {
                        DialogWindowsOperator.DialogWindow_Carotage = new();

                        if (DialogWindowsOperator.DialogWindow_Carotage.ShowDialog() == true)
                        {
                            DialogWindowsOperator.DialogWindow_Carotage.Show();
                        }

                        InfoPanel = DataInteractor.Info;
                        Output = DataInteractor.Output;
                    }
                );
            }
        }
        #endregion
    }
}