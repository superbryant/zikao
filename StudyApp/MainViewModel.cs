using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;

namespace StudyApp
{
    //[PropertyChanged.AddINotifyPropertyChangedInterface]
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            DeserializeObject();
        }
        const string STUDY_CONFIG = "study.config";
        string studyUrl;
        string recordUrl;

        public string StudyUrl
        {
            get => studyUrl; set
            {
                studyUrl = value;
                OnPropertyChanged("StudyUrl");
                SerializeObject();
            }
        }

        private void SerializeObject()
        {
            try
            {
                JObject keyValuePairs = new JObject();
                keyValuePairs.Add("StudyUrl", studyUrl);
                keyValuePairs.Add("RecordUrl", recordUrl);
                var js = JsonConvert.SerializeObject(keyValuePairs);
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, STUDY_CONFIG);
                File.WriteAllText(path, js);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void DeserializeObject()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, STUDY_CONFIG);

                var js = File.ReadAllText(path);
                JObject keyValuePairs = JsonConvert.DeserializeObject<JObject>(js);

                StudyUrl = (string)keyValuePairs["StudyUrl"];
                RecordUrl = (string)keyValuePairs["RecordUrl"];



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public string RecordUrl
        {
            get => recordUrl; set
            {
                recordUrl = value;
                OnPropertyChanged("RecordUrl");
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
