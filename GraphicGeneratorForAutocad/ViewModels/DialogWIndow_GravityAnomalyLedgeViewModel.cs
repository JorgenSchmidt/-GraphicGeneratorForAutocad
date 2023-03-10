using GraphicGeneratorForAutocad.AppService;
using GraphicGeneratorForAutocad.Service;
using GraphicGeneratorForAutocad.ViewModelService;
using GraphicGeneratorForAutocad_Core.Entities;
using GraphicGeneratorForAutocad_Model.CalculateAnomalyService;
using GraphicGeneratorForAutocad_Model.MakeCommandChainService;
using System.IO;
using System.Windows;
using System;

namespace GraphicGeneratorForAutocad.ViewModels
{
    public class DialogWIndow_GravityAnomalyLedgeViewModel : NotifyPropertyChanged
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

        public double lowerEdgeDepth;
        public double LowerEdgeDepth
        {
            get { return lowerEdgeDepth; }
            set
            {
                lowerEdgeDepth = value;
                CheckChanges();
            }
        }

        public double upperEdgeDepth;
        public double UpperEdgeDepth
        {
            get { return upperEdgeDepth; }
            set
            {
                upperEdgeDepth = value;
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

        public double densitiesDifference;
        public double DensitiesDifference
        {
            get { return densitiesDifference; }
            set
            {
                densitiesDifference = value;
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
                            if (DensitiesDifference != 0)
                            {
                                AnomalyDescription Desc = CalculateGravitationAnomalyClass.CalculateAnomalyForLedge(LowerEdgeDepth, UpperEdgeDepth, DistanceFromZeroPoint,DensitiesDifference);
                                AppOutput Ans = CommandsMakerForAnomalies.MakeCommandsForAnomalies(Coord_X, Coord_Y, Desc);

                                DataInteractor.GraphicDescription = Ans.GetGraphicParameters();
                                DataInteractor.AxisInfo = Ans.GetAxisSignatureParameters();
                                DataInteractor.Info = "Успешно";

                                using (StreamWriter writer = new StreamWriter(DataInteractor.Path + "\\" + DataInteractor.FileName + ".txt", false))
                                {
                                    await writer.WriteLineAsync(Ans.GetCommandChain());
                                }

                                DialogWindowsOperator.DialogWindow_GravityAnomalyLedge.Close();
                                DialogWindowsOperator.DialogWindow_GravityAnomalyLedge = null;
                            }
                            else
                            {
                                MessageBox.Show("Значение разницы плотностей не должно равняться 0.");
                            }
                        }
                        catch (Exception e)
                        {
                            DataInteractor.Info = e.ToString();
                            DialogWindowsOperator.DialogWindow_GravityAnomalyLedge.Close();
                            DialogWindowsOperator.DialogWindow_GravityAnomalyLedge = null;
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
                        DialogWindowsOperator.DialogWindow_GravityAnomalyLedge.Close();
                        DialogWindowsOperator.DialogWindow_GravityAnomalyLedge = null;
                    }
                );
            }
        }
        #endregion
    }
}