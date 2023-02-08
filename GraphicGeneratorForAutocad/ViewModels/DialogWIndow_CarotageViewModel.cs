using GraphicGeneratorForAutocad.AppService;
using GraphicGeneratorForAutocad.Service;
using GraphicGeneratorForAutocad.ViewModelService;
using System.Windows;

namespace GraphicGeneratorForAutocad.ViewModels
{
    /// <summary>
    /// Not implemented
    /// </summary>
    public class DialogWIndow_CarotageViewModel : NotifyPropertyChanged
    {
        #region parameters
        public double coord_X;
        public double Coord_X
        {
            get { return coord_X; }
            set
            {
                coord_X = value;
                CheckChanges();
            }
        }

        public double coord_Y;
        public double Coord_Y
        {
            get { return coord_Y; }
            set
            {
                coord_Y = value;
                CheckChanges();
            }
        }

        public string info;
        public string Info
        {
            get { return info; }
            set
            {
                info = value;
                CheckChanges();
            }
        }

        public string path;
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                CheckChanges();
            }
        }
        #endregion

        #region buttons
        public Command Calculate
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

        public Command GetHelp
        {
            get
            {
                return new Command(
                    (obj) =>
                    {
                        MessageBox.Show("Для отрисовки диаграммы необходимо преобразовать данные из .las файла к следующему формату: "
                                        + "первая строчка - обозначение метода, последующие - пара \"Глубина-Значение аномалии\". " 
                                        + "Глубина и значения аномалий должны быть разделены табуляцией.");
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
                        DialogWindowsOperator.DialogWindow_Carotage.Close();
                        DialogWindowsOperator.DialogWindow_Carotage = null;
                    }
                );
            }
        }
        #endregion
    }
}