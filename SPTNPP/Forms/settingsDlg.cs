using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kbg.NppPluginNET
{
    public partial class settingsDlg : Form
    {

        List<Binding> bindings = new List<Binding>();
        public settingsDlg()
        {
            InitializeComponent();
            var tickBinding = new Binding("Value", SPTNPP.Config.AppConfig, "ResumeTick", false, DataSourceUpdateMode.OnPropertyChanged);
            var portBinding = new Binding("Value", SPTNPP.Config.AppConfig, "Port", false, DataSourceUpdateMode.OnPropertyChanged);
            var textBinding = new Binding("Text", SPTNPP.Config.AppConfig, "CustomCommand", false, DataSourceUpdateMode.OnPropertyChanged);


            tickBox.DataBindings.Add(tickBinding);
            portBox.DataBindings.Add(portBinding);
            commandBox.DataBindings.Add(textBinding);

            bindings = new List<Binding> { tickBinding, portBinding, textBinding };
        }

		private void saveChangesButton_Click(object sender, EventArgs e)
		{
            SPTNPP.Config.Save();
		}

		private void deleteChangesButton_Click(object sender, EventArgs e)
		{
            SPTNPP.Config.Load();
            foreach (var binding in bindings)
                binding.ReadValue();
		}
	}
}
