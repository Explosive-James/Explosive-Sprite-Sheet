using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

// ToDo: Async Await for Saving - Fix empty square problem - Bug Fixing
namespace ExplosiveSpriteSheet
{
    public partial class ExplosiveSpriteSheet : Form
    {
        private enum Priority { X, Y };

        #region Consts
        private const string imageFiter = "Images (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|";
        private const string allFilter = "All files (*.*)|*.*";
        #endregion

        #region Data
        private List<Bitmap> images;

        private Vector2 imageResolution;
        private Vector2 gridSize;
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

            // Disabling User Input
            AssignUserInput();
        }

        private void GridSizeX_TextChanged(object sender, EventArgs e)
        {
            if (gridSizeX.Text == string.Empty)
                return;

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

            // Setting other Value
            SetGridSize(Priority.X);
        }
        private void GridSizeY_TextChanged(object sender, EventArgs e)
        {
            if (gridSizeY.Text == string.Empty)
                return;

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

            // Setting other Value
            SetGridSize(Priority.Y);
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

        private void OpenFiles_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // Reading files
                foreach (string file in openFileDialog.FileNames)
                {
                    try
                    {
                        // Loading Images
                        Bitmap image = (Bitmap)Image.FromFile(file);
                        Vector2 resolution = new Vector2(image.Width, image.Height);

                        // Setting Image Resolution
                        if (images.Count == 0)
                            imageResolution = resolution;

                        // Adding Image to List
                        if (resolution.x == imageResolution.x && resolution.y == imageResolution.y)
                        {
                            images.Add(image);
                            imagesDisplay.Items.Add(file.Substring(file.LastIndexOf("\\")).TrimStart('\\'));
                        }
                        // Inconsistent image size
                        else
                        {
                            MessageBox.Show(
                                $"Image : {file} is not consistent with other image resolutions. \n\n" +
                                $"Image resolution needs to be {imageResolution.x} x {imageResolution.y}", "Inconsistent Size");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Could not load the image
                        MessageBox.Show($"Cannot load image: {file} ! \n" +
                            $"Error: {ex.Message}", "Loading Error");
                    }
                }
            }

            AssignUserInput();

            // Setting Grid Size
            if (images.Count > 0)
            {
                gridSize = new Vector2((int)Math.Sqrt(images.Count), (int)Math.Round(Math.Sqrt(images.Count)));
                gridSizeX.Text = gridSize.x.ToString();
                gridSizeY.Text = gridSize.y.ToString();
            }
        }
        private void RemoveImage_Click(object sender, EventArgs e)
        {
            if (imagesDisplay.SelectedIndex != -1)
            {
                images.RemoveAt(imagesDisplay.SelectedIndex);
                imagesDisplay.Items.RemoveAt(imagesDisplay.SelectedIndex);

                AssignUserInput();
            }
        }
        private void MoveUp_Click(object sender, EventArgs e)
        {
            if(imagesDisplay.SelectedIndex > 0 &&
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
            if(imagesDisplay.SelectedIndex < images.Count - 1 && 
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
        private void SaveImage_Click(object sender, EventArgs e)
        {
            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // Saving file
                StitchImages(saveFileDialog.FileName);
                MessageBox.Show(saveFileDialog.FileName, "Image Saved");
            }
        }
        #endregion

        #region Custom Functions
        private void StitchImages(string path)
        {
            // Output
            Bitmap bit = new Bitmap(imageResolution.x * gridSize.x, imageResolution.y * gridSize.y);

            // Setting Progress Bar
            progressBar.Maximum = bit.Height * bit.Width;
            progressBar.Value = 0;

            // Assigning Pixels
            for (int i = 0; i < images.Count; i++)
                for (int x = 0; x < imageResolution.x; x++)
                    for (int y = 0; y < imageResolution.y; y++)
                    {
                        bit.SetPixel(imageResolution.x * (i % gridSize.x) + x, imageResolution.y * (i / gridSize.x) + y, images[i].GetPixel(x, y));
                        progressBar.Increment(1);
                    }

            bit.Save(path);
        }

        private void SetGridSize(Priority preference)
        {
            if (preference == Priority.X)
            {
                int newY = (int)Math.Round((double)(images.Count / gridSize.x));
                gridSizeY.Text = newY.ToString();
                gridSize.y = newY;
            }
            else if (preference == Priority.Y)
            {
                int newX = (int)Math.Round((double)(images.Count / gridSize.y));
                gridSizeX.Text = newX.ToString();
                gridSize.x = newX;
            }
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
        #endregion

    }
}
