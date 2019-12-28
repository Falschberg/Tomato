using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Linq;
using System.Globalization;


//Что нужно реализовать:
// ? Запись данных за прошедший день при смене дня
// Проверка Try-Catch на читаемость файла
// ? Переход на новый месяц, без закрытия программы (Должно автоматом переходить при проверке даты)

namespace Tomatoes
{
    public partial class TomatoesForm : Form
    {
        SoundPlayer splayer = new SoundPlayer("Malatca!.wav");

        List<Data> totalData = new List<Data>();
        Data[] datas;

        private bool _paused = true;

        private DateTime _startTime;
        private TimeSpan _allTime = new TimeSpan(0,0,0);
        private TimeSpan _time;
        private TimeSpan _deltaTime;
        private TimeSpan _timeTomatoes;

        private int _oneTomatoTime = 1500000;
        private int _tomatoesPerMonth;
        private int _totalTomatoes;
        private int _checkTomatoes;

        private string _filePath;


        public TomatoesForm()
        {
            InitializeComponent();           
        }

        private void TomatoesForm_Load(object sender, EventArgs e)
        {
            CheckFile();
            totalData = new List<Data>(datas);
            if (DateTime.Today != totalData[0].Date)
                TodayInit();
            _checkTomatoes = totalData[0].Count;
            _deltaTime = totalData[0].DeltaTime;
            TimeSpan lastInterval = TimeSpan.FromMilliseconds(_oneTomatoTime * totalData[0].Count);
            _allTime = _allTime.Add(lastInterval + _deltaTime);
            //labelTime.Text = "00:00:00";
            labelTime.Text = _deltaTime.ToString(@"hh\:mm\:ss");
            this.Text = String.Format("{0} Tomatoes", totalData[0].Count);
            _tomatoesPerMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month) * 10;
            labelTotal.Text = String.Format("{0} - {1} ({2}%)", CountAllTomatoes(), _tomatoesPerMonth, _totalTomatoes * 100 / _tomatoesPerMonth);
            labelTotalTime.Text = String.Format("TotalTime: {0}", (_allTime + _time).ToString(@"hh\:mm\:ss"));
        }

        private void TodayInit()
        {
            Data today = new Data();
            today.Date = DateTime.Today;
            if (totalData.Count > 0)
                today.DeltaTime = totalData[0].DeltaTime;
            totalData.Insert(0, today);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (_paused)
                StartTimer();
            else
                StopTimer();
        }

        private void StartTimer()
        {
            _paused = false;
            _startTime = DateTime.Now;
            buttonStart.Text = "Stop";
            timer.Enabled = true;
        }

        private void StopTimer()
        {
            _paused = true;
            buttonStart.Text = "Start";
            timer.Enabled = false;
            _allTime = _allTime.Add(_time);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (_paused) return;

            _time = (DateTime.Now - _startTime);
            _timeTomatoes = TimeSpan.FromMilliseconds((_time + _allTime).TotalMilliseconds % _oneTomatoTime);
            CheckNewTomato();
            CheckData();
            totalData[0].DeltaTime = _timeTomatoes;
            labelTime.Text = _timeTomatoes.ToString(@"hh\:mm\:ss");
            labelTotalTime.Text = String.Format("TotalTime: {0}", (_allTime + _time).ToString(@"hh\:mm\:ss"));

        }

        private void CheckNewTomato()
        {
            totalData[0].Count = Convert.ToInt32((_time + _allTime).TotalMilliseconds) / _oneTomatoTime;
            if(totalData[0].Count > _checkTomatoes)
            {
                _checkTomatoes++;
                this.Text = String.Format("{0} Tomatoes", totalData[0].Count);
                labelTotal.Text = String.Format("{0} - {1} ({2}%)", CountAllTomatoes(), _tomatoesPerMonth, _totalTomatoes * 100 / _tomatoesPerMonth);
                splayer.Play();
                SaveToFile();
            }
        }

        private void CheckData()
        {
            if (DateTime.Today != totalData[0].Date)
            {
                TodayInit();
                _allTime = _timeTomatoes;
                _checkTomatoes = 0;
                this.Text = String.Format("{0} Tomatoes", totalData[0].Count);
                labelTotal.Text = String.Format("{0} - {1} ({2}%)", CountAllTomatoes(), _tomatoesPerMonth, _totalTomatoes * 100 / _tomatoesPerMonth);
            }
        }


        private void SaveToFile()
        {
            string rec = JsonConvert.SerializeObject(totalData, Formatting.Indented);
            string file = DateTime.Now.ToString("yyyy-MMMM", CultureInfo.GetCultureInfo("en-us")) + ".json";
            File.WriteAllText(file, rec + Environment.NewLine);
        }

        private void TomatoesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveToFile();
        }

        private int CountAllTomatoes()
        {
            //_totalTomatoes = todayData.Sum(e => e.Count);
            _totalTomatoes = totalData.Count != 0 ? totalData.Sum(e => e.Count) : 0;
            return _totalTomatoes;
            //for (int i = 0; i < todayData.Count; i++)
            //{
            //    _totalTomatoes += todayData[i].Count;
            //}
            //return _totalTomatoes;
        }

        private void ConvertJson()
        {
            var data = File.ReadAllText(_filePath, Encoding.UTF8);
            datas = JsonConvert.DeserializeObject<Data[]>(data);
        }

        private void CheckFile()
        {
            DateTime date = DateTime.Now;
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            _filePath = date.ToString("yyyy-MMMM", CultureInfo.GetCultureInfo("en-us")) + ".json";
            if (!File.Exists(_filePath))
                InitFile();
            ConvertJson();
            if (datas == null)
            {
                InitFile();
                ConvertJson();
            }
        }

        private void InitFile()
        {
            TodayInit();
            SaveToFile();
        }
    }
}
