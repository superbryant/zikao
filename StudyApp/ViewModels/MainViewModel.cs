using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StudyApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace StudyApp
{
    //[PropertyChanged.AddINotifyPropertyChangedInterface]
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            RegexCommand = new RelayCommand(RegexFallacies);
            HomeSickleCommand = new RelayCommand(HomeSickle);
            GoCommand = new RelayCommand(Go);
            
            DeserializeObject();
        }

        private void HomeSickle()
        {
            StudyUrl = "https://appgqcqo6fl9508.h5.xiaoeknow.com/p/course/column/p_5ee23e1537146_4ULtQtSX?type=3";
        }

        private void Go()
        {
            
        }

        private void RegexFallacies()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resources", "fallacyis.json");
           var json= File.ReadAllText(path);
            List<FallaciesModel> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<FallaciesModel>>(json);
            StringBuilder sb = new StringBuilder();
            foreach (var item in list)
            {
                var text = @$"{item.title}({item.name})
    {item.head}
    {item.description}
    {item.exampleText}
";
                sb.Append(text);
            }
            var s = sb.ToString();
        }

        const string STUDY_CONFIG = "study.config";
        string studyUrl;
        string recordUrl;

        public string StudyUrl
        {
            get => studyUrl; set
            {
                if (studyUrl != value)
                {
                    studyUrl = value;

                    OnPropertyChanged("StudyUrl");
                    SerializeObject();
                }
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
                if (File.Exists(path) == false)
                    return;
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

        public RelayCommand RegexCommand { get; }
        public RelayCommand HomeSickleCommand { get; }
        public RelayCommand GoCommand { get; }
        

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
