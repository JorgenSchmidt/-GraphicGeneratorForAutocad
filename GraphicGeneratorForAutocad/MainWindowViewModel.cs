using GraphicGeneratorForAutocad.AppService;
using GraphicGeneratorForAutocad.Service;
using GraphicGeneratorForAutocad.ViewModelService;
using System.IO;
using System.Windows;

namespace GraphicGeneratorForAutocad
{
    /// <summary>
    /// Логика взаимодействия с элементами основного окна.
    /// </summary>
    public class MainWindowViewModel : NotifyPropertyChanged
    {
        // Директива region включена в кодовую базу для удобства
        #region output elements
        public string? infoPanel;
        public string? InfoPanel
        {
            get { return infoPanel; }
            set
            {
                infoPanel = value;
                CheckChanges();
            }
        }

        public string? path;
        public string? Path
        {
            get { return path; }
            set
            {
                path = value;
                CheckChanges();
            }
        }

        public string? fileName;
        public string? FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                CheckChanges();
            }
        }

        public string? graphicDescription;
        public string? GraphicDescription
        {
            get { return graphicDescription; }
            set
            {
                graphicDescription = value;
                CheckChanges();
            }
        }

        public string? axisInfo;
        public string? AxisInfo
        {
            get { return axisInfo; }
            set
            {
                axisInfo = value;
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
                        if (Directory.Exists(Path))
                        {
                            if (FileName != null)
                            {
                                if (FileName.Length != 0)
                                {
                                    DialogWindowsOperator.DialogWindow_GravityAnomalySphere = new();
                                    DataInteractor.Path = Path;
                                    DataInteractor.FileName = FileName;

                                    if (DialogWindowsOperator.DialogWindow_GravityAnomalySphere.ShowDialog() == true)
                                    {
                                        DialogWindowsOperator.DialogWindow_GravityAnomalySphere.Show();
                                    }

                                    InfoPanel = DataInteractor.Info;
                                    GraphicDescription = DataInteractor.GraphicDescription;
                                    AxisInfo = DataInteractor.AxisInfo;
                                }
                                else
                                {
                                    MessageBox.Show("Введите имя файла.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Введите имя файла.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Указанной директории не существует.");
                        }
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
                        if (Directory.Exists(Path))
                        {
                            if (FileName != null)
                            {
                                if (FileName.Length != 0)
                                {
                                    DialogWindowsOperator.DialogWindow_GravityAnomalyLedge = new();
                                    DataInteractor.Path = Path;
                                    DataInteractor.FileName = FileName;

                                    if (DialogWindowsOperator.DialogWindow_GravityAnomalyLedge.ShowDialog() == true)
                                    {
                                        DialogWindowsOperator.DialogWindow_GravityAnomalyLedge.Show();
                                    }

                                    InfoPanel = DataInteractor.Info;
                                    GraphicDescription = DataInteractor.GraphicDescription;
                                    AxisInfo = DataInteractor.AxisInfo;
                                }
                                else
                                {
                                    MessageBox.Show("Введите имя файла.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Введите имя файла.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Указанной директории не существует.");
                        }
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
                        if (Directory.Exists(Path))
                        {
                            if (FileName != null)
                            {
                                if (FileName.Length != 0)
                                {
                                    DialogWindowsOperator.DialogWindow_MagneticAnomalySphere = new();
                                    DataInteractor.Path = Path;
                                    DataInteractor.FileName = FileName;

                                    if (DialogWindowsOperator.DialogWindow_MagneticAnomalySphere.ShowDialog() == true)
                                    {
                                        DialogWindowsOperator.DialogWindow_MagneticAnomalySphere.Show();
                                    }

                                    InfoPanel = DataInteractor.Info;
                                    GraphicDescription = DataInteractor.GraphicDescription;
                                    AxisInfo = DataInteractor.AxisInfo;
                                }
                                else
                                {
                                    MessageBox.Show("Введите имя файла.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Введите имя файла.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Указанной директории не существует.");
                        }
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
                        if (Directory.Exists(Path))
                        {
                            if (FileName != null)
                            {
                                if (FileName.Length != 0)
                                {
                                    DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation = new();
                                    DataInteractor.Path = Path;
                                    DataInteractor.FileName = FileName;

                                    if (DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation.ShowDialog() == true)
                                    {
                                        DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation.Show();
                                    }

                                    InfoPanel = DataInteractor.Info;
                                    GraphicDescription = DataInteractor.GraphicDescription;
                                    AxisInfo = DataInteractor.AxisInfo;
                                }
                                else
                                {
                                    MessageBox.Show("Введите имя файла.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Введите имя файла.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Указанной директории не существует.");
                        }
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
                        if (Directory.Exists(Path))
                        {
                            if (FileName != null)
                            {
                                if (FileName.Length != 0)
                                {
                                    DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint = new();
                                    DataInteractor.Path = Path;
                                    DataInteractor.FileName = FileName;

                                    if (DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint.ShowDialog() == true)
                                    {
                                        DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint.Show();
                                    }

                                    InfoPanel = DataInteractor.Info;
                                    GraphicDescription = DataInteractor.GraphicDescription;
                                    AxisInfo = DataInteractor.AxisInfo;
                                }
                                else
                                {
                                    MessageBox.Show("Введите имя файла.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Введите имя файла.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Указанной директории не существует.");
                        }
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
                        if (Directory.Exists(Path))
                        {
                            if (FileName != null)
                            {
                                if (FileName.Length != 0)
                                {
                                    DialogWindowsOperator.DialogWindow_Carotage = new();
                                    DataInteractor.Path = Path;
                                    DataInteractor.FileName = FileName;

                                    if (DialogWindowsOperator.DialogWindow_Carotage.ShowDialog() == true)
                                    {
                                        DialogWindowsOperator.DialogWindow_Carotage.Show();
                                    }

                                    InfoPanel = DataInteractor.Info;
                                    GraphicDescription = DataInteractor.GraphicDescription;
                                    AxisInfo = DataInteractor.AxisInfo;
                                }
                                else
                                {
                                    MessageBox.Show("Введите имя файла.");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Введите имя файла.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Указанной директории не существует.");
                        }
                    }
                );
            }
        }
        #endregion
    }
}