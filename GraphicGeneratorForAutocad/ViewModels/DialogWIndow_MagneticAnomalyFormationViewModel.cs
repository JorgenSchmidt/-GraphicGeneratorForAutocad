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
                    async (obj) =>
                    {
                        try
                        {
                            if (InductionValue > 0 && SusceptibilityValue > 0)
                            {
                                AnomalyDescription Desc = CalculateMagneticAnomalyClass.CalculateMagneticAnomalyForLedge(Depth, FormationCapacity, DistanceFromZeroPoint, InductionValue, SusceptibilityValue);
                                AppOutput Ans = CommandsMakerForAnomalies.MakeCommandsForAnomalies(Coord_X, Coord_Y, Desc);

                                DataInteractor.GraphicDescription = Ans.GetGraphicParameters();
                                DataInteractor.AxisInfo = Ans.GetAxisSignatureParameters();
                                DataInteractor.Info = "Успешно";

                                using (StreamWriter writer = new StreamWriter(DataInteractor.Path + "\\" + DataInteractor.FileName + ".txt", false))
                                {
                                    await writer.WriteLineAsync(Ans.GetCommandChain());
                                }

                                DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation.Close();
                                DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation = null;
                            }
                            else
                            {
                                MessageBox.Show("Значение индукции или магнитной восприимчивости должно быть больше 0.");
                            }
                        }
                        catch (Exception e)
                        {
                            DataInteractor.Info = e.ToString();
                            DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation.Close();
                            DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation = null;
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
                        DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation.Close();
                        DialogWindowsOperator.DialogWindow_MagneticAnomalyFormation = null;
                    }
                );
            }
        }
        #endregion
    }
}