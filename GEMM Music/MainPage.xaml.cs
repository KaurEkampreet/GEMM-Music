﻿using GEMM_Music.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GEMM_Music
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Music> Musics;
        private List<MenuItem> MenuItems;

        public MainPage()
        {
            this.InitializeComponent();
            Musics = new ObservableCollection<Music>();
            MusicManager.GetAllMusic(Musics);

            MenuItems = new List<MenuItem>();
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/bruno.png", Category = MusicCategory.Brunos });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/demi.png", Category = MusicCategory.Demis });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/drake.png", Category = MusicCategory.Drakes });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/selena.png", Category = MusicCategory.Selenas });
           


            BackButton.Visibility = Visibility.Collapsed;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MysplitView.IsPaneOpen = !MysplitView.IsPaneOpen;
        }

        private void MenuItemsListview_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            CatergoryTextBlock.Text = menuItem.Category.ToString();
            MusicManager.GetMusicsByCategory(Musics, menuItem.Category);
            BackButton.Visibility = Visibility.Visible;
        }

        private void SoundGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var music = (Music)e.ClickedItem;
            MyMediaElement.Source = new Uri(BaseUri, music.AudioFile);
            SelectedImage.ImageSource = new BitmapImage(new Uri(BaseUri, music.ImageFile));
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MusicManager.GetAllMusic(Musics);
            CatergoryTextBlock.Text = "All Musics";
            MenuItemsListview.SelectedItem = null;
            BackButton.Visibility = Visibility.Collapsed;
        }
    }
}
