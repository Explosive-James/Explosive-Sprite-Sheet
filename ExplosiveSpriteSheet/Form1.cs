using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace ExplosiveSpriteSheet
{
    public partial class ExplosiveSpriteSheet : Form
    {
        #region Consts
        private const string imageFiter = "Images (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|";
        private const string allFilter = "All files (*.*)|*.*";

        public const string smallGridWarning = "Grid size too small.\n";
        public const string bigGridWarning = "Grid size too big.\n";
        #endregion

        #region Data
        private List<Bitmap> images;
        private List<string> paths;

        private Vector2 imageResolution;
        private Vector2 gridSize;

        private int progress;
        #endregion

        #region Form Functions
        public ExplosiveSpriteSheet()
        {
            InitializeComponent();
        }

        private void ExplosiveSpriteSheet_Load(object sender, EventArgs e)
        {
            // Setting file dialog to filter for images
            openFileDialog.Filter = imageFiter + allFilter;
            saveFileDialog.Filter = imageFiter + allFilter;

            // Allowing User to multi-select
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Select Images";

            // Initializing Images List
            images = new List<Bitmap>();
            paths = new List<string>();

            // Disabling User Input
            AssignUserInput();
            warningLable.Text = string.Empty;
        }

        private void GridSizeX_Leave(object sender, EventArgs e)
        {
            if (gridSizeX.Text == string.Empty)
                gridSizeX.Text = "1";

            // Converting to GridSize
            gridSize = new Vector2(Convert.ToInt32(gridSizeX.Text), Convert.ToInt32(gridSizeY.Text));

            // Preventing zero or lower
            if (gridSize.x <= 0)
            {
                gridSize.x = 1;
                gridSizeX.Text = "1";
            }
            // Preventing too high
            else if (gridSize.x > images.Count)
            {
                gridSize.x = images.Count;
                gridSizeX.Text = images.Count.ToString();
            }

            UpdateLables();
        }
        private void GridSizeY_Leave(object sender, EventArgs e)
        {
            if (gridSizeY.Text == string.Empty)
                gridSizeY.Text = "1";

            // Converting to GridSize
            gridSize = new Vector2(Convert.ToInt32(gridSizeX.Text), Convert.ToInt32(gridSizeY.Text));

            // Preventing zero or lower
            if (gridSize.y <= 0)
            {
                gridSize.y = 1;
                gridSizeY.Text = "1";
            }
            // Preventing too high
            else if (gridSize.y > images.Count)
            {
                gridSize.y = images.Count;
                gridSizeY.Text = images.Count.ToString();
            }

            UpdateLables();
        }
        private void GridSizeX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void GridSizeY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            progressBar.Value = progress;
        }

        private async void OpenFiles_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr != DialogResult.OK)
                return;

            // Setting Up Progress Bar
            progressBar.Value = 0;
            progressBar.Maximum = openFileDialog.FileNames.Length;

            paths = new List<string>(openFileDialog.FileNames);

            // Reading files
            while (paths.Count > 0)
            {
                // Increment Bar
                progressBar.Increment(1);

                // Loading Images
                Bitmap image = await Task.Run(LoadImage);
                Vector2 resolution = new Vector2(image.Width, image.Height);

                // Setting Image Resolution
                if (images.Count == 0)
                    imageResolution = resolution;

                // Adding Image to List
                if (resolution.x == imageResolution.x && resolution.y == imageResolution.y)
                {
                    images.Add(image);
                    imagesDisplay.Items.Add(paths[0].Substring(paths[0].LastIndexOf("\\")).TrimStart('\\'));
                }
                // Inconsistent image size
                else
                {
                    MessageBox.Show(
                        $"Image : {paths[0]} is not consistent with other image resolutions. \n\n" +
                        $"Image resolution needs to be {imageResolution.x} x {imageResolution.y}", "Inconsistent Size");
                }

                paths.RemoveAt(0);
            }

            // Setting Grid Size
            if (images.Count > 0)
            {
                gridSize = new Vector2((int)Math.Sqrt(images.Count), (int)Math.Sqrt(images.Count));
                gridSizeX.Text = ((int)Math.Sqrt(images.Count)).ToString();
                gridSizeY.Text = ((int)Math.Sqrt(images.Count)).ToString();

                AssignUserInput();
                UpdateLables();
            }
        }
        private void RemoveImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (imagesDisplay.SelectedIndex != -1)
                {
                    int index = imagesDisplay.SelectedIndex;

                    images.RemoveAt(index);
                    imagesDisplay.Items.RemoveAt(index);

                    if (images.Count > 0)
                        imagesDisplay.SelectedIndex = index;

                    AssignUserInput();
                    UpdateLables();
                }
            }
            catch (Exception ex)
            {
                // Could not remove the image
                MessageBox.Show($"Cannot remove image! \n" +
                    $"Error: {ex.Message}", "Loading Error");
            }
        }
        private void MoveUp_Click(object sender, EventArgs e)
        {
            if (imagesDisplay.SelectedIndex > 0 &&
                imagesDisplay.SelectedIndex <= images.Count)
            {
                int index = imagesDisplay.SelectedIndex;

                // Moving Images
                images.Insert(index - 1, images[index]);
                images.RemoveAt(index + 1);

                // Moveing Display Text
                imagesDisplay.Items.Insert(index - 1, imagesDisplay.Items[index]);
                imagesDisplay.Items.RemoveAt(index + 1);

                imagesDisplay.SelectedIndex = index - 1;
            }
        }
        private void MoveDown_Click(object sender, EventArgs e)
        {
            if (imagesDisplay.SelectedIndex < images.Count - 1 &&
                imagesDisplay.SelectedIndex != -1)
            {
                int index = imagesDisplay.SelectedIndex;

                // Moving Images
                images.Insert(index + 2, images[index]);
                images.RemoveAt(index);

                // Moveing Display Text
                imagesDisplay.Items.Insert(index + 2, imagesDisplay.Items[index]);
                imagesDisplay.Items.RemoveAt(index);

                imagesDisplay.SelectedIndex = index + 1;
            }
        }
        private async void SaveImage_Click(object sender, EventArgs e)
        {
            if (warningLable.Text != string.Empty)
            {
                string warning = gridSize.x * gridSize.y > images.Count ? bigGridWarning : smallGridWarning;
                DialogResult drw = MessageBox.Show(warning + "Do you want to continue?", "Warning", MessageBoxButtons.OKCancel);
                if (drw == DialogResult.Cancel)
                    return;
            }

            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // Setting ProgressBar
                progress = 0;
                progressBar.Value = 0;
                progressBar.Maximum = (imageResolution.x * gridSize.x) * (imageResolution.y * gridSize.y);
                timer.Start();

                // Rendering File
                Bitmap finalImage = await Task.Run(StitchImages);

                // Stopping ProgressBar
                progressBar.Value = progressBar.Maximum;
                timer.Stop();

                // Saving Image
                try
                {
                    finalImage.Save(saveFileDialog.FileName);
                    MessageBox.Show($"Image Saved: {saveFileDialog.FileName}", "Saved Image");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to save Image {ex.Message}", "Saving Error");
                }
            }
        }
        #endregion

        #region Custom Functions
        private async Task<Bitmap> StitchImages()
        {
            // Output
            Bitmap bit = new Bitmap(imageResolution.x * gridSize.x, imageResolution.y * gridSize.y);

            // Assigning Pixels
            for (int i = 0; i < images.Count; i++)
                for (int x = 0; x < imageResolution.x; x++)
                    for (int y = 0; y < imageResolution.y; y++)
                    {
                        bit.SetPixel(imageResolution.x * (i % gridSize.x) + x, imageResolution.y * (i / gridSize.x) + y, images[i].GetPixel(x, y));
                        progress++;
                    }

            return bit;
        }
        private async Task<Bitmap> LoadImage()
        {
            Bitmap image = null;

            try
            {
                image = (Bitmap)Image.FromFile(paths[0]);
            }
            catch (Exception ex)
            {
                // Could not load the image
                MessageBox.Show($"Cannot load image: {paths[0]} ! \n" +
                    $"Error: {ex.Message}", "Loading Error");
            }

            return image;
        }
        private void AssignUserInput()
        {
            gridSizeX.Enabled = images.Count > 0;
            gridSizeY.Enabled = images.Count > 0;

            saveImage.Enabled = images.Count > 0;
            moveDown.Enabled = images.Count > 0;
            moveUp.Enabled = images.Count > 0;
            removeImage.Enabled = images.Count > 0;
        }
        private void UpdateLables()
        {
            // Updating Warning
            int max = gridSize.x * gridSize.y;
            int small = Math.Min(gridSize.x, gridSize.y);

            if (max >= images.Count + small)
                warningLable.Text = bigGridWarning + $"{max - images.Count} blank slots!";
            else if (max < images.Count)
                warningLable.Text = smallGridWarning + $"{images.Count - max} images will be lost!";
            else
                warningLable.Text = string.Empty;

            // Updating Resolution
            resolutionLable.Text = $"{imageResolution.x * gridSize.x} x {imageResolution.y * gridSize.y}";

            // Updating Images Number
            imageAmounts.Text = "Loaded Images: " + images?.Count.ToString();
        }
        #endregion
    }
}
