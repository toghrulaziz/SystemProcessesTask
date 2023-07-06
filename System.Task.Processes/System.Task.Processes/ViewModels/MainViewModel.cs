using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Task.Processes.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        ObservableCollection<Process> processes;

        public ObservableCollection<Process> Processes
        {
            get { return processes; }
            set { Set(ref processes, value); }
        }

        Process? selectedProcess;

        public Process? SelectedProcess
        {
            get { return selectedProcess; }
            set { Set(ref selectedProcess, value); }
        }

        string? processToCreate;

        public string? ProcessToCreate
        {
            get { return processToCreate; }
            set { Set(ref processToCreate, value); }
        }

        public MainViewModel()
        {
            Processes = new ObservableCollection<Process>(Process.GetProcesses());
        }


        

        public RelayCommand EndButton
        {
            get => new(() =>
            {
                var processToRemove = SelectedProcess;

                if (processToRemove != null)
                {
                    processToRemove.Kill();
                    Processes.Remove(processToRemove);
                }
            });
        }



        public RelayCommand CreateButton
        {
            get => new(() =>
            {
                if (processToCreate != null)
                {
                    var temp = Process.Start(processToCreate);

                    Processes.Add(temp);
                }
            });
        }


    }
}
