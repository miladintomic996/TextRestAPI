using Microsoft.Win32;
using NetCoreRepositoryAndUnitOfWorkPattern.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows;
using TextRestAPI.Model;

namespace TextRestAPI.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
            populateDatagrid();

        }

        private async void populateDatagrid()
        {
            var response = await client.GetAsync("https://localhost:5001/api/dbtext/all");
            List<Text> textList = JsonConvert.DeserializeObject<List<Text>>(await response.Content.ReadAsStringAsync());
            ObservableCollection<Text> collection = new ObservableCollection<Text>(textList);
            dgvDbTexts.ItemsSource = collection;
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var content = new StringContent(txtContent.Text);
            var response = await client.PostAsync("https://localhost:5001/api/text", content);
            TextResponse textResponse = JsonConvert.DeserializeObject<TextResponse>(await response.Content.ReadAsStringAsync());

            txtCount.Text = textResponse.WordsCount.ToString();
            txtError.Text = (textResponse.Error != null) ? textResponse.Error : "";
        }

        private async void btnCount_Click(object sender, RoutedEventArgs e)
        {
            if (dgvDbTexts.SelectedItem == null)
            {
                MessageBox.Show("Please select record!");
                return;
            }
            Text textRecord = (Text)dgvDbTexts.SelectedItem;
            var endpoint = $"https://localhost:5001/api/text/db/{textRecord.Id}";
            var response = await client.GetAsync(endpoint);
            TextResponse textResponse = JsonConvert.DeserializeObject<TextResponse>(await response.Content.ReadAsStringAsync());

            txtCountDb.Text = textResponse.WordsCount.ToString();
            txtErrorDb.Text = (textResponse.Error != null) ? textResponse.Error : "";
        }

        private async void btnChooseFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.DefaultExt = ".txt"; // Required file extension 
            fileDialog.Filter = "Text documents (.txt)|*.txt"; // Optional file extensions

            Nullable<bool> result = fileDialog.ShowDialog();

            if ((bool)result)
            {
                txtFilename.Text = fileDialog.FileName;
                string readText = File.ReadAllText(fileDialog.FileName);
                txtFileContent.Text = readText;
                var content = new StringContent(readText);
                var response = await client.PostAsync("https://localhost:5001/api/text", content);
                TextResponse textResponse = JsonConvert.DeserializeObject<TextResponse>(await response.Content.ReadAsStringAsync());

                txtCountFile.Text = textResponse.WordsCount.ToString();
                txtErrorFile.Text = (textResponse.Error != null) ? textResponse.Error : "";
            }
        }
    }
}
