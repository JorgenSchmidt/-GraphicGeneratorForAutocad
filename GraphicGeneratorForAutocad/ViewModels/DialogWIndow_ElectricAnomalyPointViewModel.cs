using GraphicGeneratorForAutocad.AppService;
using GraphicGeneratorForAutocad.Service;
using GraphicGeneratorForAutocad.ViewModelService;
using GraphicGeneratorForAutocad_Core.Entities;
using GraphicGeneratorForAutocad_Model.CalculateAnomalyService;
using GraphicGeneratorForAutocad_Model.MakeCommandChainService;
using System;
using System.IO;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace GraphicGeneratorForAutocad.ViewModels
{
    public class DialogWIndow_ElectricAnomalyPointViewModel : NotifyPropertyChanged
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

        public double distanceFromXAxis;
        public double DistanceFromXAxis
        {
            get { return distanceFromXAxis; }
            set
            {
                distanceFromXAxis = value;
                CheckChanges();
            }
        }

        public double occurrenceDepth;
        public double OccurrenceDepth
        {
            get { return occurrenceDepth; }
            set
            {
                occurrenceDepth = value;
                CheckChanges();
            }
        }

        public double observationRoute_Y;
        public double ObservationRoute_Y
        {
            get { return observationRoute_Y; }
            set
            {
                observationRoute_Y = value;
                CheckChanges();
            }
        }

        public double observationRoute_h;
        public double ObservationRoute_h
        {
            get { return observationRoute_h; }
            set
            {
                observationRoute_h = value;
                CheckChanges();
            }
        }

        public double resistanceValue;
        public double ResistanceValue
        {
            get { return resistanceValue; }
            set { 
                resistanceValue = value; 
                CheckChanges();
            }
        }

        public double electricStrength;
        public double ElectricStrength
        {
            get { return electricStrength; }
            set
            {
                electricStrength = value;
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
                    async (obj) =>
                    {
                        try
                        {
                            if (ResistanceValue > 0 && ElectricStrength > 0)
                            {
                                AnomalyDescription Desc = CalculateElectricAnomalyClass.CalculateElectricAnomalyForPoint(DistanceFromZeroPoint, DistanceFromXAxis, OccurrenceDepth, ObservationRoute_Y, ObservationRoute_h, ResistanceValue, ElectricStrength);
                                AppOutput Ans = CommandsMakerForAnomalies.MakeCommandsForAnomalies(Coord_X, Coord_Y, Desc);

                                DataInteractor.GraphicDescription = Ans.GetGraphicParameters();
                                DataInteractor.AxisInfo = Ans.GetAxisSignatureParameters();
                                DataInteractor.Info = "Успешно";

                                using (StreamWriter writer = new StreamWriter(DataInteractor.Path + "\\" + DataInteractor.FileName + ".txt", false))
                                {
                                    await writer.WriteLineAsync(Ans.GetCommandChain());
                                }

                                DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint.Close();
                                DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint = null;
                            }
                            else
                            {
                                MessageBox.Show("Значение сопротивления и силы тока должны быть больше, чем 0.");
                            }
                        }
                        catch (Exception e)
                        {
                            DataInteractor.Info = e.ToString();
                            DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint.Close();
                            DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint = null;
                        }
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
                        DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint.Close();
                        DialogWindowsOperator.DialogWindow_ElectricAnomalyPoint = null;
                    }
                );
            }
        }
        #endregion
    }
}