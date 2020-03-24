using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenGL_Project.ProjectAssignment3
{
    public partial class ModelControl : UserControl
    {
        public ModelControl()
        {
            InitializeComponent();
        }   

        public GenerateModelEventHandler generate;
        private void GenerateModelButtonClick(object sender, EventArgs e)
        {
            if(generate != null)
            {
                generate.Invoke(this, new GenerateModelEventArgs()
                {
                    Type = (GenerateModelEventArgs.ModelType)_modelTypeList.SelectedItem,
                    XScale = _xScaleTrack.Value,
                    YScale = _yScaleTrack.Value,
                    ZScale = _zScaleTrack.Value,
                    ThetaParam = _thetaParamTrack.Value,
                    PhiParam = _phiParamTrack.Value,
                });
            }
        }

        public delegate void GenerateModelEventHandler(ModelControl sender, GenerateModelEventArgs args);

        private void ModelTypeListValueChange(object sender, EventArgs e)
        {
            if ((GenerateModelEventArgs.ModelType)_modelTypeList.SelectedItem == GenerateModelEventArgs.ModelType.SuperquadricToroid)
            {
                _xScaleTrack.Value = SuperquadricToroid.DefaultXCompParam;
                _yScaleTrack.Value = SuperquadricToroid.DefaultYCompParam;
                _zScaleTrack.Value = SuperquadricToroid.DefaultZCompParam;
                _thetaParamTrack.Value = SuperquadricToroid.DefaultThetaResolParam;
                _phiParamTrack.Value = SuperquadricToroid.DefaultPhiResolParam;
            }
            else
            {
                _xScaleTrack.Value = SuperquadricHyperboloid.DefaultXCompParam;
                _yScaleTrack.Value = SuperquadricHyperboloid.DefaultYCompParam;
                _zScaleTrack.Value = SuperquadricHyperboloid.DefaultZCompParam;
                _thetaParamTrack.Value = SuperquadricHyperboloid.DefaultThetaResolParam;
                _phiParamTrack.Value = SuperquadricHyperboloid.DefaultPhiResolParam;
            }
        }
    }

    public class GenerateModelEventArgs : EventArgs
    {
        public enum ModelType { SuperquadricToroid, SuperquadricHyperboloid}

        public ModelType Type;
        public float XScale;
        public float YScale;
        public float ZScale;
        public float ThetaParam;
        public float PhiParam;
    }
}
