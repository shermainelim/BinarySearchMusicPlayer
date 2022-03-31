using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MP3_Player
{
    public partial class MusicPlayerApp : Form
    {
        public MusicPlayerApp()
        {
            InitializeComponent();
        }

        //Create Global Variables of String Type Array to save the titles/names of the Tracks and path of the track
        //2 arrays
        //paths will hold all the selected music, files will hold all the music
        String[] paths, files;

        private void btnSelectSongs_Click(object sender, EventArgs e)
        {
            //Select multiple songs
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = ofd.SafeFileNames; //Save the names of the track in files array
                paths = ofd.FileNames;  //Save the paths of the tracks in path arrays

                //Display the music titles in listbox
                for(int i=0; i < files.Length; i++)
                {
                    listBoxSongs.Items.Add(files[i]); //Display Songs in Listbox
                }
            }
        }

        private void listBoxSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Play Music
            axWindowsMediaPlayer1.URL = paths[listBoxSongs.SelectedIndex];
        }

        private void sort_Click(object sender, EventArgs e)
        {
            Array.Sort(files);
            Array.Sort(paths);
            listBoxSongs.Items.Clear();
            for (int i = 0; i < files.Length; i++)
            {
                listBoxSongs.Items.Add(files[i]); //Display Songs in Listbox
            }


        }

        private void btn_search_Click(object sender, EventArgs e)
        {

            string x = textBox1.Text.ToLower();

            //time measurement
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            //Begin timing
            stopwatch.Start();

            //BinarySearch on sorted array
            int index = Array.BinarySearch<string>(files, x);

            //Console.WriteLine("index "+ index);
            //Console.WriteLine("first name"+ files[Math.Abs(index)]+ "second name"+ files[Math.Abs(index + 1)]);

            //listBoxSongs.SetSelected(Math.Abs(index), true);

            listBoxSongs.SetSelected(Math.Abs(index + 1), true);

            //Stop timing
            stopwatch.Stop();

            Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);


            ////Clear previous selected item
            //listBoxSongs.SelectedItems.Clear();
            //int l = 0; int r = listBoxSongs.Items.Count - 1;
            //while (true)
            //{
            //    int m = l + (r - 1) / 2;
            //    int res = x.CompareTo(listBoxSongs.Items[m]);

            //    //Check if x is present at mid
            //    if (res == 0)
            //    {

            //        listBoxSongs.SetSelected(m, true);
            //        break;
            //    }

            //    // If x greater, ignore left half
            //    if (res > 0)
            //        l = m + 1;

            //    // If x is smaller, ignore right half
            //    else
            //        r = m - 1;
            //}

            //listBoxSongs.SelectedItems.Clear();
            ////time measurement
            //System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            //// Begin timing
            //stopwatch.Start();
            //for (int i = listBoxSongs.Items.Count - 1; i > 0; i--)
            //{
            //    //Search independent of its case
            //    if (listBoxSongs.Items[i].ToString().ToLower().Contains(textBox1.Text.ToLower()))
            //    {
            //        listBoxSongs.SetSelected(i, true);
            //    }
            //}

            //Array.Sort(files);
            //Array.Sort(paths);
            //listBoxSongs.Items.Clear();
            //for (int i = 0; i < files.Length; i++)
            //{
            //    listBoxSongs.Items.Add(files[i]); //Display Songs in Listbox
            //}

            ////stop timing
            //stopwatch.Stop();

            //Console.WriteLine("Time taken : {0}", stopwatch.Elapsed);

        }



private void btnClose_Click(object sender, EventArgs e)
        {
            //Code to close the app
            this.Close();
        }
    }
}
