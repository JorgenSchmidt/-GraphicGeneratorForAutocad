﻿using GraphicGeneratorForAutocad.AppService;
using GraphicGeneratorForAutocad.Service;
using GraphicGeneratorForAutocad.ViewModelService;

namespace GraphicGeneratorForAutocad.ViewModels
{
    public class DialogWIndow_GravityAnomalySphereViewModel : NotifyPropertyChanged
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

        public double sphereDepth;
        public double SphereDepth
        {
            get { return sphereDepth; }
            set
            {
                sphereDepth = value;
                CheckChanges();
            }
        }

        public double sphereRadius;
        public double SphereRadius
        {
            get { return sphereRadius; }
            set
            {
                sphereRadius = value;
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