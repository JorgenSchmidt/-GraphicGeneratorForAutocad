using GraphicGeneratorForAutocad.AppService;
using GraphicGeneratorForAutocad.Service;
using GraphicGeneratorForAutocad.ViewModelService;

namespace GraphicGeneratorForAutocad.ViewModels
{
    public class DialogWIndow_MagneticAnomalyFormationViewModel : NotifyPropertyChanged
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

        public double depth;
        public double Depth
        {
            get { return depth; }
            set
            {
                depth = value;
                CheckChanges();
            }
        }

        public double formationCapacity;
        public double FormationCapacity
        {
            get { return formationCapacity; }
            set
            {
                formationCapacity = value;
                CheckChanges();
            }
        }

        public double distanceFromZeroPoint;
        public double DistanceFromZeroPoint
        {
            get { return distanceFromZeroPoint; }
            set
            {
                distanceFromZeroPoint = value;
                CheckChanges();
            }
        }

        public double inductionValue;
        public double InductionValue
        {
            get { return inductionValue; }
            set
            {
                inductionValue = value;
                CheckChanges();
            }
        }

        public double susceptibilityValue;
        public double SusceptibilityValue
        {
            get { return susceptibilityValue; }
            set
            {
                susceptibilityValue = value;
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